namespace RCTDataEditor {
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
			this.rctLabel4 = new CustomControls.RCTLabel();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.rctLabel3 = new CustomControls.RCTLabel();
			this.labelVersion = new CustomControls.RCTLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
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
			// rctLabel2
			// 
			this.rctLabel2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
			this.rctLabel2.Location = new System.Drawing.Point(25, 53);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Size = new System.Drawing.Size(140, 14);
			this.rctLabel2.TabIndex = 3;
			this.rctLabel2.Text = "RCT2 Water Creator";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel3
			// 
			this.rctLabel3.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
			this.rctLabel3.Location = new System.Drawing.Point(19, 93);
			this.rctLabel3.Name = "rctLabel3";
			this.rctLabel3.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel3.Size = new System.Drawing.Size(160, 14);
			this.rctLabel3.TabIndex = 7;
			this.rctLabel3.Text = "© Robert Jordan 2015";
			this.rctLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelVersion
			// 
			this.labelVersion.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
			this.labelVersion.Location = new System.Drawing.Point(36, 73);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelVersion.Size = new System.Drawing.Size(90, 14);
			this.labelVersion.TabIndex = 6;
			this.labelVersion.Text = "Version 1.0.0.0";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::RCT2WaterCreator.Properties.Resources.AboutImage;
			this.pictureBox1.Location = new System.Drawing.Point(160, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 160);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(323, 191);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.rctLabel3);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.rctLabel4);
			this.Controls.Add(this.rctLabel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About RCT2 Water Creator";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private CustomControls.RCTLabel rctLabel4;
		private CustomControls.RCTLabel rctLabel2;
		private CustomControls.RCTLabel rctLabel3;
		private CustomControls.RCTLabel labelVersion;

	}
}
