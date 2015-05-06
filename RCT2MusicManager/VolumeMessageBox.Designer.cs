namespace RCT2MusicManager {
	partial class VolumeMessageBox {
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
			this.buttonOK = new CustomControls.RCTButton();
			this.buttonCancel = new CustomControls.RCTButton();
			this.labelText1 = new CustomControls.RCTLabel();
			this.labelVolume = new CustomControls.RCTLabel();
			this.trackBarVolume = new RCT2MusicManager.NoFocusTrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.BorderOnHover = false;
			this.buttonOK.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonOK.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonOK.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonOK.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonOK.Image = null;
			this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOK.Location = new System.Drawing.Point(50, 75);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonOK.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonOK.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonOK.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonOK.Size = new System.Drawing.Size(60, 18);
			this.buttonOK.TabIndex = 149;
			this.buttonOK.Text = "OK";
			this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOK.Toggleable = false;
			this.buttonOK.Toggled = false;
			this.buttonOK.ButtonPressed += new System.EventHandler(this.YesPressed);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.BorderOnHover = false;
			this.buttonCancel.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonCancel.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonCancel.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonCancel.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonCancel.Image = null;
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCancel.Location = new System.Drawing.Point(131, 75);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonCancel.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonCancel.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonCancel.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonCancel.Size = new System.Drawing.Size(60, 18);
			this.buttonCancel.TabIndex = 150;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCancel.Toggleable = false;
			this.buttonCancel.Toggled = false;
			this.buttonCancel.ButtonPressed += new System.EventHandler(this.NoPressed);
			// 
			// labelText1
			// 
			this.labelText1.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelText1.Location = new System.Drawing.Point(12, 22);
			this.labelText1.Name = "labelText1";
			this.labelText1.OutlineColor = System.Drawing.Color.Transparent;
			this.labelText1.Size = new System.Drawing.Size(140, 14);
			this.labelText1.TabIndex = 155;
			this.labelText1.Text = "Change the song\'s volume.";
			this.labelText1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelVolume
			// 
			this.labelVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelVolume.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelVolume.Location = new System.Drawing.Point(174, 22);
			this.labelVolume.Name = "labelVolume";
			this.labelVolume.OutlineColor = System.Drawing.Color.Transparent;
			this.labelVolume.Size = new System.Drawing.Size(60, 14);
			this.labelVolume.TabIndex = 157;
			this.labelVolume.Text = "100%";
			this.labelVolume.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// trackBarVolume
			// 
			this.trackBarVolume.Location = new System.Drawing.Point(12, 42);
			this.trackBarVolume.Maximum = 100;
			this.trackBarVolume.Minimum = 1;
			this.trackBarVolume.Name = "trackBarVolume";
			this.trackBarVolume.Size = new System.Drawing.Size(222, 45);
			this.trackBarVolume.TabIndex = 158;
			this.trackBarVolume.TabStop = false;
			this.trackBarVolume.TickFrequency = 5;
			this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarVolume.Value = 100;
			this.trackBarVolume.ValueChanged += new System.EventHandler(this.VolumeChanged);
			// 
			// VolumeMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(246, 107);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.trackBarVolume);
			this.Controls.Add(this.labelVolume);
			this.Controls.Add(this.labelText1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VolumeMessageBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Volume";
			((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CustomControls.RCTButton buttonOK;
		private CustomControls.RCTButton buttonCancel;
		private CustomControls.RCTLabel labelText1;
		private CustomControls.RCTLabel labelVolume;
		private NoFocusTrackBar trackBarVolume;
	}
}