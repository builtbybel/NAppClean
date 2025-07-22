using NativeAppCleanup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAppClean
{
    public partial class FixerControlView : UserControl, IRefreshableView
    {
        private readonly FeatureManager _featureManager;
        private readonly UiContext _ui;
        private List<FeatureNode> _currentTweaks;

        public void ActivateView()
        {
            _ui.HeaderLabel.Text = "Apply various system tweaks to customize and optimize your Windows experience";
            _ui.HelpBox.Text =
                "This section allows you to apply various system tweaks to customize and optimize your Windows experience.\r\n\r\n" +
                "• Select a category from the dropdown to browse available tweaks.\r\n" +
                "• Check or uncheck tweaks to enable or disable them.\r\n" +
                "• Click 'Apply' to save your changes.\r\n\r\n" +
                "Each tweak includes detailed info and supported OS versions shown in the 'Supported' box.\r\n" +
                "Be careful when applying tweaks — some changes may require a system restart.\r\n\r\n";
            _ui.SupportedBox.Text =
                "Windows 10, Windows 11, Windows Server 2019 and later";
        }

        public FixerControlView(UiContext uiContext)
        {
            InitializeComponent();
            _ui = uiContext ?? throw new ArgumentNullException(nameof(uiContext));
            _featureManager = new FeatureManager();

            // Load categories when control is loaded
            Load += (_, __) => InitializeView();
        }

        /// <summary>
        /// Initializes the category dropdown.
        /// </summary>
        private void InitializeView()
        {
            comboCategories.Items.Clear();
            comboCategories.Items.AddRange(_featureManager.GetCategories().ToArray());

            //  if (comboCategories.Items.Count > 0)
            // comboCategories.SelectedIndex = 0; //Triggers category load
        }

        /// <summary>
        /// Loads tweak list when category changes.
        /// </summary>
        private async void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboCategories.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(category))
            {
                await LoadTweaksForCategory(category);
            }
        }

        /// <summary>
        /// Loads tweak nodes and their current state for the selected category.
        /// </summary>
        private async Task LoadTweaksForCategory(string category)
        {
            listTweaks.Items.Clear();
            _currentTweaks = _featureManager.GetFeaturesByCategory(category);

            foreach (var tweak in _currentTweaks)
            {
                bool isEnabled = await _featureManager.IsEnabled(tweak);
                listTweaks.Items.Add(tweak, isEnabled);
            }

            if (_currentTweaks.Count > 0)
                listTweaks.SelectedIndex = 0; // Select first tweak to show info
            else
                UpdateUiContextForNoneSelected();
        }

        /// <summary>
        /// Displays tweak information and reflects state in the shared UI.
        /// </summary>
        private async void listTweaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listTweaks.SelectedIndex;
            if (index < 0 || index >= _currentTweaks.Count)
            {
                UpdateUiContextForNoneSelected();
                return;
            }

            var node = _currentTweaks[index];
            var feature = node.Feature;

            // Update UI
            _ui.HelpBox.Text = $"{feature.Info()}\r\n\r\nDetails:\r\n{feature.GetFeatureDetails()}";
            _ui.SupportedBox.Text = feature.SupportedOS();

            bool isEnabled = await _featureManager.IsEnabled(node);
            _ui.RadioEnabled.Checked = isEnabled;
            _ui.RadioDisabled.Checked = !isEnabled;
        }

        /// <summary>
        /// Applies or undoes tweaks based on checkbox state.
        /// </summary>
        private async void btnApply_Click(object sender, EventArgs e)
        {
            var appliedTweaks = new List<string>();

            for (int i = 0; i < listTweaks.Items.Count; i++)
            {
                var node = _currentTweaks[i];
                bool shouldEnable = listTweaks.GetItemChecked(i);
                bool isCurrentlyEnabled = await _featureManager.IsEnabled(node);

                if (shouldEnable && !isCurrentlyEnabled)
                {
                    if (await _featureManager.ApplyFeature(node))
                        appliedTweaks.Add($"✔ Applied: {node.Feature.ID()}");
                    else
                        MessageBox.Show($"Failed to apply: {node.Feature.ID()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!shouldEnable && isCurrentlyEnabled)
                {
                    if (_featureManager.UndoFeature(node))
                        appliedTweaks.Add($"✖ Reverted: {node.Feature.ID()}");
                    else
                        MessageBox.Show($"Failed to undo: {node.Feature.ID()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Show applied tweaks or fallback message
            _ui.CommentBox.Text = appliedTweaks.Count > 0
                ? string.Join(Environment.NewLine, appliedTweaks)
                : "No changes were made.";

            await ReloadCurrentCategory(); // Refresh the list to reflect changes
        }


        /// <summary>
        /// Refreshes checkbox states after apply/undo operations.
        /// </summary>
        private async Task ReloadCurrentCategory()
        {
            for (int i = 0; i < _currentTweaks.Count; i++)
            {
                var node = _currentTweaks[i];
                bool isEnabled = await _featureManager.IsEnabled(node);
                listTweaks.SetItemChecked(i, isEnabled);
            }

            if (_currentTweaks.Count > 0)
            {
                listTweaks.SelectedIndex = 0;
            }
            else
            {
                UpdateUiContextForNoneSelected();
            }
        }

        /// <summary>
        /// Clears shared UI when no tweak is selected.
        /// </summary>
        private void UpdateUiContextForNoneSelected()
        {
            _ui.HelpBox.Text = "";
            _ui.CommentBox.Text = "";
            _ui.SupportedBox.Text = "";
            _ui.HeaderLabel.Text = "";
            _ui.RadioEnabled.Checked = false;
            _ui.RadioDisabled.Checked = false;
        }

        /// <summary>
        /// Refreshes the view by reloading the current category's tweaks.
        /// </summary>
        public void RefreshView()
        {
            if (comboCategories.SelectedItem is string selectedCategory)
            {
                _ = LoadTweaksForCategory(selectedCategory);
            }
        }
    }
}