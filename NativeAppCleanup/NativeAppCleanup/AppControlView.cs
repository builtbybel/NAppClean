using NAppClean;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Management.Deployment;

namespace NativeAppCleanup
{
    public partial class AppControlView : UserControl, IRefreshableView
    {
        private Dictionary<string, string> _appDirectory = new Dictionary<string, string>();
        private string currentSearchTerm = string.Empty;
        private readonly UiContext _ui;

        public void ActivateView()
        {
            // Update UI elements in MainForm via _ui
            _ui.HeaderLabel.Text = "Remove Default Microsoft Store packages from the system";
            _ui.HelpBox.Text =
               "Remove Default Microsoft Store packages from the system.\r\n" +
               "If you enable this policy, the selected Microsoft Store apps in the provided list will be uninstalled from the system.\r\n" +
               "You can make adjustments to the default settings via Patterns Button.\r\n\r\n" +
               "Unselected apps in the list will not be removed.\r\n\r\n" +
               "** Whitelist and Pattern Configuration\r\n" +
               "You can whitelist apps to prevent them from being flagged by prefixing the entry with an exclamation mark (!):\r\n\r\n" +
               "*To globally hide all apps via a wildcard pattern, use: !*.*";

            _ui.SupportedBox.Text = "Windows 10, Windows 11, Windows Server 2022, Windows Server 2025";
        }

        public AppControlView(UiContext uiContext)
        {
            InitializeComponent();
            _ui = uiContext;
        }

        private async void AppControlView_Load(object sender, EventArgs e)
        {
            await LoadAndDisplayApps();
            //_ui.HelpBox.Text = "This is help text";
            _ui.HeaderLabel.Text = "Remove Default Microsoft Store packages from the system.";
            //_ui.SupportedBox.Text = "Windows 10/11";
        }

        // Loads all installed apps and displays matches in the checked list
        private async Task LoadAndDisplayApps()
        {
            checkedListBoxApps.Items.Clear();

            var (bloatware, whitelist, scanAll) = LoadNativeAppPatterns();
            await LoadInstalledAppsAsync();

            foreach (var app in _appDirectory)
            {
                string appNameLower = app.Key.ToLower();

                // Skip whitelisted apps
                if (whitelist.Any(w => appNameLower.Contains(w)))
                    continue;

                // Apply search filter
                if (!string.IsNullOrEmpty(currentSearchTerm) &&
                    !appNameLower.Contains(currentSearchTerm))
                    continue;

                // Show all apps if wildcard is enabled, or match by pattern
                if (scanAll || bloatware.Any(b => appNameLower.Contains(b)))
                {
                    checkedListBoxApps.Items.Add(app.Key, false);
                }
            }
        }

        // Loads installed UWP apps into the internal dictionary
        private async Task LoadInstalledAppsAsync()
        {
            _appDirectory.Clear();
            var pm = new PackageManager();

            var packages = await Task.Run(() =>
                pm.FindPackagesForUserWithPackageTypes(string.Empty, PackageTypes.Main));

            foreach (var p in packages)
            {
                string name = p.Id.Name;
                string fullName = p.Id.FullName;

                if (!_appDirectory.ContainsKey(name))
                {
                    _appDirectory[name] = fullName;
                }
            }
        }

        // Loads bloatware patterns and whitelist from text file
        private (string[] bloatware, string[] whitelist, bool scanAll) LoadNativeAppPatterns()
        {
            var bloatware = new List<string>();
            var whitelist = new List<string>();
            bool scanAll = false;

            string pathToUse = GetActivePatternFilePath();

            if (string.IsNullOrEmpty(pathToUse) || !File.Exists(pathToUse))
                return (Array.Empty<string>(), Array.Empty<string>(), false);

            foreach (var rawLine in File.ReadLines(pathToUse))
            {
                string line = rawLine.Split('#')[0].Trim();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line == "*" || line == "*.*")
                {
                    scanAll = true;
                    continue;
                }

                if (line.StartsWith("!"))
                    whitelist.Add(line.Substring(1).Trim().ToLowerInvariant());
                else
                    bloatware.Add(line.ToLowerInvariant());
            }

            return (bloatware.ToArray(), whitelist.ToArray(), scanAll);
        }

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            _ui.CommentBox.Text = "Starting cleanup...";
            progressBar.Visible = true;

            var toRemove = new List<string>();

            // Get selected app full names from checked list
            foreach (var item in checkedListBoxApps.CheckedItems)
            {
                string appName = item.ToString();
                if (_appDirectory.TryGetValue(appName, out var fullName))
                {
                    toRemove.Add(fullName);
                }
            }

            if (toRemove.Count == 0)
            {
                MessageBox.Show("Please select at least one app.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progressBar.Minimum = 0;
            progressBar.Maximum = toRemove.Count;
            progressBar.Value = 0;

            int count = 0;

            foreach (var fullName in toRemove)
            {
                string name = _appDirectory.FirstOrDefault(x => x.Value == fullName).Key;

                _ui.CommentBox.Text = $"Removing {name}...";
                bool success = await UninstallAppAsync(fullName);

                count++;
                progressBar.Value = count;

                if (!success)
                    _ui.CommentBox.Text = $"Failed to remove {name}";
                else
                    _ui.CommentBox.Text = $"Removed {name}";

                await Task.Delay(200); // Optional pause to visualize progress
            }

            MessageBox.Show("Uninstallation completed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh app list after cleanup
            await LoadAndDisplayApps();
            progressBar.Value = 0;
            progressBar.Visible = false;
            _ui.CommentBox.Text = "Cleanup finished.";
        }

        // Uninstalls a UWP app using its full package name
        private async Task<bool> UninstallAppAsync(string fullName)
        {
            try
            {
                var pm = new PackageManager();
                var operation = pm.RemovePackageAsync(fullName);

                var resetEvent = new ManualResetEvent(false);
                operation.Completed = (o, s) => resetEvent.Set();

                await Task.Run(() => resetEvent.WaitOne());

                return operation.Status == AsyncStatus.Completed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uninstalling:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public async void RefreshView()
        {
            await LoadAndDisplayApps();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = GetActivePatternFilePath(ensureExists: true);
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening pattern file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = textSearch.Text.Trim().ToLower();
            _ = LoadAndDisplayApps(); // Re-run with filter
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Clear();
        }

        // Gets the path to the active policy patterns file, ensuring it exists
        private string GetActivePatternFilePath(bool ensureExists = false)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string primaryPath = Path.Combine(baseDir, "PolicyPatterns.txt");
            string fallbackPath = Path.Combine(baseDir, "Plugins", "CFEnhancer.txt");

            string pathToUse = File.Exists(primaryPath) ? primaryPath :
                               File.Exists(fallbackPath) ? fallbackPath : primaryPath; // fallback *use* fallback, else fallback to primary for creation

            if (ensureExists && !File.Exists(pathToUse))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathToUse));
                File.WriteAllText(pathToUse, "# Add your app detection patterns here\n");
            }

            return pathToUse;
        }
    }
}