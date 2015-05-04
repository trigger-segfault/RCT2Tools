namespace RCT2MusicManager {
	partial class AboutBox {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.labelCopyright = new CustomControls.RCTLabel();
			this.labelVersion = new CustomControls.RCTLabel();
			this.rctLabel4 = new CustomControls.RCTLabel();
			this.labelTitle = new CustomControls.RCTLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::RCT2MusicManager.Properties.Resources.AboutImage;
			this.pictureBox1.Location = new System.Drawing.Point(160, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 160);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// rctLabel1
			// 
			this.rctLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rctLabel1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(12, 189);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel1.Size = new System.Drawing.Size(290, 14);
			this.rctLabel1.TabIndex = 8;
			this.rctLabel1.Text = "Website:   http://trigger-death.github.io/RCT2Tools/";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rctLabel1.Click += new System.EventHandler(this.OpenWebsitePage);
			// 
			// labelCopyright
			// 
			this.labelCopyright.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(203)))), ((int)(((byte)(27)))));
			this.labelCopyright.Location = new System.Drawing.Point(0, 93);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelCopyright.Size = new System.Drawing.Size(160, 14);
			this.labelCopyright.TabIndex = 7;
			this.labelCopyright.Text = "© Robert Jordan 2015";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelVersion
			// 
			this.labelVersion.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(203)))), ((int)(((byte)(27)))));
			this.labelVersion.Location = new System.Drawing.Point(0, 73);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelVersion.Size = new System.Drawing.Size(160, 14);
			this.labelVersion.TabIndex = 6;
			this.labelVersion.Text = "Version 1.0.0.0";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// rctLabel4
			// 
			this.rctLabel4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rctLabel4.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel4.Location = new System.Drawing.Point(12, 169);
			this.rctLabel4.Name = "rctLabel4";
			this.rctLabel4.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel4.Size = new System.Drawing.Size(290, 14);
			this.rctLabel4.TabIndex = 4;
			this.rctLabel4.Text = "GitHub:   https://github.com/trigger-death/RCT2Tools";
			this.rctLabel4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rctLabel4.Click += new System.EventHandler(this.OpenGitHubPage);
			// 
			// labelTitle
			// 
			this.labelTitle.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(203)))), ((int)(((byte)(27)))));
			this.labelTitle.Location = new System.Drawing.Point(0, 53);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelTitle.Size = new System.Drawing.Size(160, 14);
			this.labelTitle.TabIndex = 3;
			this.labelTitle.Text = "RCT2 Program";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(323, 210);
			this.Controls.Add(this.rctLabel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.rctLabel4);
			this.Controls.Add(this.labelTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private CustomControls.RCTLabel rctLabel4;
		private CustomControls.RCTLabel labelTitle;
		private CustomControls.RCTLabel labelCopyright;
		private CustomControls.RCTLabel labelVersion;
		private CustomControls.RCTLabel rctLabel1;

	}
}
