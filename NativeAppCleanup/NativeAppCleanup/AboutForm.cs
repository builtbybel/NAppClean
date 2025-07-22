using NativeAppCleanup;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NAppClean
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            lblAppVersion.Text = Program.GetAppVersion();
            btnClose.Text = "\uEF2C";
            ApplyRoundedCorners();
        }

        private void ApplyRoundedCorners()
        {
            int radius = 60; // Corner radius
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // top-left
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // top-right
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // bottom-right
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // bottom-left
            path.CloseFigure();

            this.Region = new Region(path); // Apply the rounded shape
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners(); // Reapply on resize
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 45;
            int borderWidth = 1;

            // Adjust drawing rectangle
            var rect = new Rectangle(borderWidth / 2, borderWidth / 2, Width - borderWidth, Height - borderWidth);
            radius = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2); // Clamp radius

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawPath(new Pen(Color.DarkGray, borderWidth), path); // Draw border

            this.Region = new Region(path); // apply rounded region
        }


        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/NAppClean");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}