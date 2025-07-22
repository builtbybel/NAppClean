namespace NativeAppCleanup
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblOptions = new System.Windows.Forms.Label();
            this.lblSupported = new System.Windows.Forms.Label();
            this.textSupported = new System.Windows.Forms.TextBox();
            this.textComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.textHelp = new System.Windows.Forms.TextBox();
            this.radioDisabled = new System.Windows.Forms.RadioButton();
            this.radioEnabled = new System.Windows.Forms.RadioButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.assetAppSymbol = new System.Windows.Forms.PictureBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetAppSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(560, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAbout.ForeColor = System.Drawing.Color.Black;
            this.btnAbout.Location = new System.Drawing.Point(459, 6);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(95, 32);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "About";
            this.btnAbout.UseCompatibleTextRendering = true;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Variable Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(47, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(460, 21);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Header";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Location = new System.Drawing.Point(0, 188);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(315, 305);
            this.panelControls.TabIndex = 3;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(1, 152);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(47, 20);
            this.lblOptions.TabIndex = 5;
            this.lblOptions.Text = "Options:";
            this.lblOptions.UseCompatibleTextRendering = true;
            // 
            // lblSupported
            // 
            this.lblSupported.AutoSize = true;
            this.lblSupported.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupported.Location = new System.Drawing.Point(135, 84);
            this.lblSupported.Name = "lblSupported";
            this.lblSupported.Size = new System.Drawing.Size(75, 20);
            this.lblSupported.TabIndex = 6;
            this.lblSupported.Text = "Supported on:";
            this.lblSupported.UseCompatibleTextRendering = true;
            // 
            // textSupported
            // 
            this.textSupported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSupported.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textSupported.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F);
            this.textSupported.ForeColor = System.Drawing.Color.Black;
            this.textSupported.Location = new System.Drawing.Point(220, 86);
            this.textSupported.Multiline = true;
            this.textSupported.Name = "textSupported";
            this.textSupported.ReadOnly = true;
            this.textSupported.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSupported.Size = new System.Drawing.Size(435, 51);
            this.textSupported.TabIndex = 7;
            // 
            // textComment
            // 
            this.textComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.textComment.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textComment.Location = new System.Drawing.Point(220, 14);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textComment.Size = new System.Drawing.Size(435, 65);
            this.textComment.TabIndex = 8;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(135, 11);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(57, 20);
            this.lblComment.TabIndex = 9;
            this.lblComment.Text = "Comment:";
            this.lblComment.UseCompatibleTextRendering = true;
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(322, 152);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(31, 20);
            this.lblHelp.TabIndex = 10;
            this.lblHelp.Text = "Help:";
            this.lblHelp.UseCompatibleTextRendering = true;
            // 
            // textHelp
            // 
            this.textHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.textHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textHelp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textHelp.Location = new System.Drawing.Point(324, 188);
            this.textHelp.Multiline = true;
            this.textHelp.Name = "textHelp";
            this.textHelp.ReadOnly = true;
            this.textHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textHelp.Size = new System.Drawing.Size(329, 305);
            this.textHelp.TabIndex = 11;
            // 
            // radioDisabled
            // 
            this.radioDisabled.AutoSize = true;
            this.radioDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioDisabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDisabled.Location = new System.Drawing.Point(14, 45);
            this.radioDisabled.Name = "radioDisabled";
            this.radioDisabled.Size = new System.Drawing.Size(69, 22);
            this.radioDisabled.TabIndex = 12;
            this.radioDisabled.Text = "Disabled";
            this.radioDisabled.UseCompatibleTextRendering = true;
            this.radioDisabled.UseVisualStyleBackColor = true;
            // 
            // radioEnabled
            // 
            this.radioEnabled.AutoSize = true;
            this.radioEnabled.Checked = true;
            this.radioEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioEnabled.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioEnabled.Location = new System.Drawing.Point(14, 14);
            this.radioEnabled.Name = "radioEnabled";
            this.radioEnabled.Size = new System.Drawing.Size(65, 22);
            this.radioEnabled.TabIndex = 13;
            this.radioEnabled.TabStop = true;
            this.radioEnabled.Text = "Enabled";
            this.radioEnabled.UseCompatibleTextRendering = true;
            this.radioEnabled.UseVisualStyleBackColor = true;
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.panelContainer.Controls.Add(this.textComment);
            this.panelContainer.Controls.Add(this.textHelp);
            this.panelContainer.Controls.Add(this.panelControls);
            this.panelContainer.Controls.Add(this.radioEnabled);
            this.panelContainer.Controls.Add(this.lblOptions);
            this.panelContainer.Controls.Add(this.radioDisabled);
            this.panelContainer.Controls.Add(this.lblSupported);
            this.panelContainer.Controls.Add(this.textSupported);
            this.panelContainer.Controls.Add(this.lblHelp);
            this.panelContainer.Controls.Add(this.lblComment);
            this.panelContainer.Location = new System.Drawing.Point(6, 42);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(658, 505);
            this.panelContainer.TabIndex = 15;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(235)))));
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Controls.Add(this.btnAbout);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 552);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(670, 45);
            this.panelBottom.TabIndex = 16;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.btnNext);
            this.panelHeader.Controls.Add(this.assetAppSymbol);
            this.panelHeader.Controls.Add(this.btnPrevious);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(670, 37);
            this.panelHeader.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Location = new System.Drawing.Point(547, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 29);
            this.btnRefresh.TabIndex = 332;
            this.btnRefresh.Text = "...";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Location = new System.Drawing.Point(631, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 29);
            this.btnNext.TabIndex = 331;
            this.btnNext.Text = "...";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // assetAppSymbol
            // 
            this.assetAppSymbol.Image = global::NAppClean.Properties.Resources.AppIcon24;
            this.assetAppSymbol.Location = new System.Drawing.Point(10, 7);
            this.assetAppSymbol.Name = "assetAppSymbol";
            this.assetAppSymbol.Size = new System.Drawing.Size(31, 29);
            this.assetAppSymbol.TabIndex = 328;
            this.assetAppSymbol.TabStop = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.25F);
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrevious.Location = new System.Drawing.Point(595, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 29);
            this.btnPrevious.TabIndex = 327;
            this.btnPrevious.Text = "...";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(670, 597);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelContainer);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Native App Cleanup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetAppSymbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Label lblSupported;
        private System.Windows.Forms.TextBox textSupported;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.TextBox textHelp;
        private System.Windows.Forms.RadioButton radioDisabled;
        private System.Windows.Forms.RadioButton radioEnabled;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox assetAppSymbol;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRefresh;
    }
}

