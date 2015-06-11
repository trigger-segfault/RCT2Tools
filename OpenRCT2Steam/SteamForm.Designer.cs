namespace OpenRCT2Steam {
	partial class SteamForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SteamForm));
			this.xButton = new CustomControls.RCTButton();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.rctButton3 = new CustomControls.RCTButton();
			this.rctButton2 = new CustomControls.RCTButton();
			this.rctButton1 = new CustomControls.RCTButton();
			this.SuspendLayout();
			// 
			// xButton
			// 
			this.xButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.xButton.BorderOnHover = false;
			this.xButton.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.xButton.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
			this.xButton.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
			this.xButton.FontType = CustomControls.Visuals.FontType.Bold;
			this.xButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.xButton.Image = global::OpenRCT2Steam.Properties.Resources.X;
			this.xButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xButton.Location = new System.Drawing.Point(447, 2);
			this.xButton.Name = "xButton";
			this.xButton.OutlineColor = System.Drawing.Color.Transparent;
			this.xButton.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
			this.xButton.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
			this.xButton.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
			this.xButton.Size = new System.Drawing.Size(11, 12);
			this.xButton.TabIndex = 4;
			this.xButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xButton.Toggleable = false;
			this.xButton.Toggled = false;
			this.xButton.Click += new System.EventHandler(this.XButtonPressed);
			// 
			// rctLabel1
			// 
			this.rctLabel1.BackgroundImage = global::OpenRCT2Steam.Properties.Resources.Title1;
			this.rctLabel1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.rctLabel1.Location = new System.Drawing.Point(24, 1);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.rctLabel1.Size = new System.Drawing.Size(418, 14);
			this.rctLabel1.TabIndex = 3;
			this.rctLabel1.Text = "RollerCoaster Tycoon 2 Steam Launcher";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// rctButton3
			// 
			this.rctButton3.BorderOnHover = false;
			this.rctButton3.DepressedBackgroundColor = System.Drawing.Color.Transparent;
			this.rctButton3.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton3.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton3.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton3.Image = null;
			this.rctButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton3.Location = new System.Drawing.Point(6, 321);
			this.rctButton3.Name = "rctButton3";
			this.rctButton3.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton3.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton3.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton3.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton3.Size = new System.Drawing.Size(448, 20);
			this.rctButton3.TabIndex = 2;
			this.rctButton3.Text = "OpenRCT2 Launcher";
			this.rctButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton3.Toggleable = false;
			this.rctButton3.Toggled = false;
			this.rctButton3.Click += new System.EventHandler(this.LauncherButtonPressed);
			// 
			// rctButton2
			// 
			this.rctButton2.BorderOnHover = false;
			this.rctButton2.DepressedBackgroundColor = System.Drawing.Color.Transparent;
			this.rctButton2.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton2.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton2.Image = global::OpenRCT2Steam.Properties.Resources.OpenRCT2;
			this.rctButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton2.Location = new System.Drawing.Point(6, 171);
			this.rctButton2.Name = "rctButton2";
			this.rctButton2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton2.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton2.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton2.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton2.Size = new System.Drawing.Size(448, 144);
			this.rctButton2.TabIndex = 1;
			this.rctButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton2.Toggleable = false;
			this.rctButton2.Toggled = false;
			this.rctButton2.Click += new System.EventHandler(this.OpenRCT2ButtonPressed);
			// 
			// rctButton1
			// 
			this.rctButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.rctButton1.BorderOnHover = false;
			this.rctButton1.DepressedBackgroundColor = System.Drawing.Color.Transparent;
			this.rctButton1.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton1.Image = global::OpenRCT2Steam.Properties.Resources.RCT2;
			this.rctButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Location = new System.Drawing.Point(6, 21);
			this.rctButton1.Name = "rctButton1";
			this.rctButton1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton1.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton1.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.Size = new System.Drawing.Size(448, 144);
			this.rctButton1.TabIndex = 0;
			this.rctButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Toggleable = false;
			this.rctButton1.Toggled = false;
			this.rctButton1.Click += new System.EventHandler(this.RCT2ButtonPressed);
			// 
			// SteamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.BackgroundImage = global::OpenRCT2Steam.Properties.Resources.Window;
			this.ClientSize = new System.Drawing.Size(460, 347);
			this.Controls.Add(this.xButton);
			this.Controls.Add(this.rctLabel1);
			this.Controls.Add(this.rctButton3);
			this.Controls.Add(this.rctButton2);
			this.Controls.Add(this.rctButton1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SteamForm";
			this.Padding = new System.Windows.Forms.Padding(6);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RollerCoaster Tycoon 2 Launcher";
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RCTButton rctButton1;
		private CustomControls.RCTButton rctButton2;
		private CustomControls.RCTButton rctButton3;
		private CustomControls.RCTLabel rctLabel1;
		private CustomControls.RCTButton xButton;
	}
}

