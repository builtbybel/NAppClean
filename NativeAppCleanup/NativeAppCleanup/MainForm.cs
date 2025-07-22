using NAppClean;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NativeAppCleanup
{
    public partial class MainForm : Form
    {
        private AboutForm aboutForm;

        // Array holding all user views to display
        private readonly UserControl[] views;
        // Index of the currently visible view
        private int currentViewIndex = 0;
        // Shared UI context with references to common UI elements
        private readonly UiContext _uiContext;

        public MainForm()
        {
            InitializeComponent();
            Logger.Initialize(textComment, this);

            // Initialize the UI context, passing common controls to child views
            _uiContext = new UiContext
            {
                HeaderLabel = lblHeader,
                CommentBox = textComment,
                SupportedBox = textSupported,
                HelpBox = textHelp,
                RadioEnabled = radioEnabled,
                RadioDisabled = radioDisabled,
            };

            // Create instances of all views, injecting the shared UI context
            var fixerView = new FixerControlView(_uiContext);
            var appView = new AppControlView(_uiContext);

            // Store views in array for easy navigation
            views = new UserControl[] { appView, fixerView };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Set up the main form properties
            btnRefresh.Text = "\uE72C";
            btnPrevious.Text = "\uE76B";
            btnNext.Text = "\uE76C";

            // Show the initial view on form load
            ShowCurrentView();
        }

        // Displays the current view inside the main panel
        private void ShowCurrentView()
        {
            if (currentViewIndex < 0 || currentViewIndex >= views.Length)
                return;

            var control = views[currentViewIndex];

            control.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(control);

            // Enable or disable navigation buttons based on position
            btnPrevious.Enabled = currentViewIndex > 0;
            btnNext.Enabled = currentViewIndex < views.Length - 1;

            // Notify the view to update header/help info on MainForm
            var activateMethod = control.GetType().GetMethod("ActivateView");
            activateMethod?.Invoke(control, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var currentView = views[currentViewIndex];

            if (currentView is IRefreshableView refreshable)
            {
                refreshable.RefreshView();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentViewIndex < views.Length - 1)
            {
                currentViewIndex++;
                ShowCurrentView();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentViewIndex > 0)
            {
                currentViewIndex--;
                ShowCurrentView();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (aboutForm == null || aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm();
                aboutForm.StartPosition = FormStartPosition.Manual;
                aboutForm.Owner = this;
                aboutForm.Show();
            }
            PositionAboutForm();
        }

        private void PositionAboutForm()
        {
            if (aboutForm != null && !aboutForm.IsDisposed)
            {
                int x = this.Left + (this.Width - aboutForm.Width) / 2;
                int y = this.Top + (this.Height - aboutForm.Height) / 2;
                aboutForm.Location = new Point(x, y);
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            PositionAboutForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
           => Close();
    }
}