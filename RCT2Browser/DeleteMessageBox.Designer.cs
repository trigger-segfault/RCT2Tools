namespace RCTDataEditor {
	partial class DeleteMessageBox {
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
			this.buttonAbout = new CustomControls.RCTButton();
			this.rctButton1 = new CustomControls.RCTButton();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.labelDeletedObject = new CustomControls.RCTLabel();
			this.SuspendLayout();
			// 
			// buttonAbout
			// 
			this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAbout.BorderOnHover = false;
			this.buttonAbout.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonAbout.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonAbout.Image = null;
			this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Location = new System.Drawing.Point(50, 75);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.Size = new System.Drawing.Size(60, 18);
			this.buttonAbout.TabIndex = 149;
			this.buttonAbout.Text = "Yes";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.YesPressed);
			// 
			// rctButton1
			// 
			this.rctButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rctButton1.BorderOnHover = false;
			this.rctButton1.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton1.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton1.Image = null;
			this.rctButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Location = new System.Drawing.Point(131, 75);
			this.rctButton1.Name = "rctButton1";
			this.rctButton1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton1.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton1.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.Size = new System.Drawing.Size(60, 18);
			this.rctButton1.TabIndex = 150;
			this.rctButton1.Text = "No";
			this.rctButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Toggleable = false;
			this.rctButton1.Toggled = false;
			this.rctButton1.ButtonPressed += new System.EventHandler(this.NoPressed);
			// 
			// rctLabel2
			// 
			this.rctLabel2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(24, 23);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel2.Size = new System.Drawing.Size(200, 14);
			this.rctLabel2.TabIndex = 151;
			this.rctLabel2.Text = "Delete the following object file?";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelDeletedObject
			// 
			this.labelDeletedObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelDeletedObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelDeletedObject.Location = new System.Drawing.Point(41, 43);
			this.labelDeletedObject.Name = "labelDeletedObject";
			this.labelDeletedObject.OutlineColor = System.Drawing.Color.Transparent;
			this.labelDeletedObject.Size = new System.Drawing.Size(180, 14);
			this.labelDeletedObject.TabIndex = 152;
			this.labelDeletedObject.Text = "1920CAR.DAT";
			this.labelDeletedObject.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// DeleteMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(246, 107);
			this.Controls.Add(this.labelDeletedObject);
			this.Controls.Add(this.rctLabel2);
			this.Controls.Add(this.rctButton1);
			this.Controls.Add(this.buttonAbout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeleteMessageBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Delete Object";
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RCTButton buttonAbout;
		private CustomControls.RCTButton rctButton1;
		private CustomControls.RCTLabel rctLabel2;
		private CustomControls.RCTLabel labelDeletedObject;
	}
}