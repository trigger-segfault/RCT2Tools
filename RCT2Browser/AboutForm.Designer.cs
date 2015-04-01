namespace RCTDataEditor {
	partial class AboutForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.rctLabel3 = new CustomControls.RCTLabel();
			this.rctLabel4 = new CustomControls.RCTLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// rctLabel1
			// 
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(36, 32);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.Size = new System.Drawing.Size(90, 14);
			this.rctLabel1.TabIndex = 0;
			this.rctLabel1.Text = "Version 1.1.1.0";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel2
			// 
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(19, 12);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.Size = new System.Drawing.Size(140, 14);
			this.rctLabel2.TabIndex = 0;
			this.rctLabel2.Text = "RCT2 Content Browser";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel3
			// 
			this.rctLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel3.Location = new System.Drawing.Point(19, 52);
			this.rctLabel3.Name = "rctLabel3";
			this.rctLabel3.Size = new System.Drawing.Size(160, 14);
			this.rctLabel3.TabIndex = 1;
			this.rctLabel3.Text = "(c) Robert Jordan 2015";
			this.rctLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel4
			// 
			this.rctLabel4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rctLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel4.Location = new System.Drawing.Point(12, 169);
			this.rctLabel4.Name = "rctLabel4";
			this.rctLabel4.Size = new System.Drawing.Size(290, 14);
			this.rctLabel4.TabIndex = 1;
			this.rctLabel4.Text = "GitHub:   https://github.com/trigger-death/RCT2Tools";
			this.rctLabel4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rctLabel4.Click += new System.EventHandler(this.OpenGitHubPage);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::RCTDataEditor.Properties.Resources.AboutImage;
			this.pictureBox1.Location = new System.Drawing.Point(160, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 160);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(325, 190);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.rctLabel4);
			this.Controls.Add(this.rctLabel3);
			this.Controls.Add(this.rctLabel2);
			this.Controls.Add(this.rctLabel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AboutForm";
			this.Text = "About RCT2 Content Browser";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RCTLabel rctLabel1;
		private CustomControls.RCTLabel rctLabel2;
		private CustomControls.RCTLabel rctLabel3;
		private CustomControls.RCTLabel rctLabel4;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}