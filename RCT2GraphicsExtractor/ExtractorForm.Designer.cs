namespace RCT2GraphicsExtractor {
	partial class ExtractorForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractorForm));
			this.buttonBrowseIn = new CustomControls.RCTButton();
			this.buttonBrowseOut = new CustomControls.RCTButton();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.checkBoxDecimal = new CustomControls.RCTCheckBox();
			this.checkBoxHex = new CustomControls.RCTCheckBox();
			this.rctLabel3 = new CustomControls.RCTLabel();
			this.labelError = new CustomControls.RCTLabel();
			this.rctStatusBar1 = new CustomControls.RCTStatusBar();
			this.labelComplete = new CustomControls.RCTLabel();
			this.loadingBar = new System.Windows.Forms.PictureBox();
			this.rctButton1 = new CustomControls.RCTButton();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.timerExtract = new System.Windows.Forms.Timer(this.components);
			this.rctStatusBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadingBar)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonBrowseIn
			// 
			this.buttonBrowseIn.BorderOnHover = false;
			this.buttonBrowseIn.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonBrowseIn.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseIn.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowseIn.Image = null;
			this.buttonBrowseIn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseIn.Location = new System.Drawing.Point(151, 17);
			this.buttonBrowseIn.Name = "buttonBrowseIn";
			this.buttonBrowseIn.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonBrowseIn.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseIn.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseIn.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowseIn.TabIndex = 0;
			this.buttonBrowseIn.Text = "Browse";
			this.buttonBrowseIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseIn.Toggleable = false;
			this.buttonBrowseIn.Toggled = false;
			this.buttonBrowseIn.Click += new System.EventHandler(this.ChangeG1Directory);
			// 
			// buttonBrowseOut
			// 
			this.buttonBrowseOut.BorderOnHover = false;
			this.buttonBrowseOut.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonBrowseOut.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseOut.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowseOut.Image = null;
			this.buttonBrowseOut.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseOut.Location = new System.Drawing.Point(151, 45);
			this.buttonBrowseOut.Name = "buttonBrowseOut";
			this.buttonBrowseOut.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonBrowseOut.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseOut.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseOut.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowseOut.TabIndex = 1;
			this.buttonBrowseOut.Text = "Browse";
			this.buttonBrowseOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseOut.Toggleable = false;
			this.buttonBrowseOut.Toggled = false;
			this.buttonBrowseOut.Click += new System.EventHandler(this.ChangeOutputDirectory);
			// 
			// rctLabel1
			// 
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(44, 20);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.Size = new System.Drawing.Size(98, 14);
			this.rctLabel1.TabIndex = 2;
			this.rctLabel1.Text = "G1.dat Directory:";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel2
			// 
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(44, 47);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.Size = new System.Drawing.Size(98, 14);
			this.rctLabel2.TabIndex = 3;
			this.rctLabel2.Text = "Output Directory:";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// checkBoxDecimal
			// 
			this.checkBoxDecimal.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxDecimal.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxDecimal.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxDecimal.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxDecimal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDecimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxDecimal.Location = new System.Drawing.Point(50, 99);
			this.checkBoxDecimal.Name = "checkBoxDecimal";
			this.checkBoxDecimal.Size = new System.Drawing.Size(60, 11);
			this.checkBoxDecimal.TabIndex = 4;
			this.checkBoxDecimal.Text = "Decimal";
			this.checkBoxDecimal.CheckStateChanged += new System.EventHandler(this.DecimalFormat);
			// 
			// checkBoxHex
			// 
			this.checkBoxHex.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxHex.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxHex.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxHex.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxHex.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxHex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxHex.Location = new System.Drawing.Point(116, 99);
			this.checkBoxHex.Name = "checkBoxHex";
			this.checkBoxHex.Size = new System.Drawing.Size(50, 11);
			this.checkBoxHex.TabIndex = 5;
			this.checkBoxHex.Text = "Hex";
			this.checkBoxHex.CheckStateChanged += new System.EventHandler(this.HexFormat);
			// 
			// rctLabel3
			// 
			this.rctLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel3.Location = new System.Drawing.Point(44, 77);
			this.rctLabel3.Name = "rctLabel3";
			this.rctLabel3.Size = new System.Drawing.Size(108, 14);
			this.rctLabel3.TabIndex = 6;
			this.rctLabel3.Text = "Numbering Format:";
			this.rctLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelError
			// 
			this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.labelError.Location = new System.Drawing.Point(17, 6);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(230, 14);
			this.labelError.TabIndex = 7;
			this.labelError.Text = "Error loading G1.dat";
			this.labelError.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelError.Visible = false;
			// 
			// rctStatusBar1
			// 
			this.rctStatusBar1.Controls.Add(this.labelComplete);
			this.rctStatusBar1.Controls.Add(this.labelError);
			this.rctStatusBar1.Controls.Add(this.loadingBar);
			this.rctStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.rctStatusBar1.Location = new System.Drawing.Point(0, 161);
			this.rctStatusBar1.Name = "rctStatusBar1";
			this.rctStatusBar1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctStatusBar1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctStatusBar1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctStatusBar1.Size = new System.Drawing.Size(262, 26);
			this.rctStatusBar1.TabIndex = 8;
			// 
			// labelComplete
			// 
			this.labelComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.labelComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelComplete.Location = new System.Drawing.Point(17, 6);
			this.labelComplete.Name = "labelComplete";
			this.labelComplete.Size = new System.Drawing.Size(230, 14);
			this.labelComplete.TabIndex = 7;
			this.labelComplete.Text = "Extraction Finished";
			this.labelComplete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelComplete.Visible = false;
			// 
			// loadingBar
			// 
			this.loadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.loadingBar.Location = new System.Drawing.Point(4, 4);
			this.loadingBar.Margin = new System.Windows.Forms.Padding(4);
			this.loadingBar.Name = "loadingBar";
			this.loadingBar.Padding = new System.Windows.Forms.Padding(4);
			this.loadingBar.Size = new System.Drawing.Size(254, 18);
			this.loadingBar.TabIndex = 9;
			this.loadingBar.TabStop = false;
			this.loadingBar.Visible = false;
			// 
			// rctButton1
			// 
			this.rctButton1.BorderOnHover = false;
			this.rctButton1.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton1.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton1.Image = null;
			this.rctButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Location = new System.Drawing.Point(94, 126);
			this.rctButton1.Name = "rctButton1";
			this.rctButton1.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton1.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.Size = new System.Drawing.Size(80, 22);
			this.rctButton1.TabIndex = 9;
			this.rctButton1.Text = "Extract";
			this.rctButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Toggleable = false;
			this.rctButton1.Toggled = false;
			this.rctButton1.ButtonPressed += new System.EventHandler(this.Extract);
			// 
			// timerExtract
			// 
			this.timerExtract.Tick += new System.EventHandler(this.Extracting);
			// 
			// ExtractorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(262, 187);
			this.Controls.Add(this.rctButton1);
			this.Controls.Add(this.rctStatusBar1);
			this.Controls.Add(this.rctLabel3);
			this.Controls.Add(this.checkBoxHex);
			this.Controls.Add(this.checkBoxDecimal);
			this.Controls.Add(this.rctLabel2);
			this.Controls.Add(this.rctLabel1);
			this.Controls.Add(this.buttonBrowseOut);
			this.Controls.Add(this.buttonBrowseIn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ExtractorForm";
			this.Text = "RCT2 Graphics Extractor";
			this.rctStatusBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.loadingBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RCTButton buttonBrowseIn;
		private CustomControls.RCTButton buttonBrowseOut;
		private CustomControls.RCTLabel rctLabel1;
		private CustomControls.RCTLabel rctLabel2;
		private CustomControls.RCTCheckBox checkBoxDecimal;
		private CustomControls.RCTCheckBox checkBoxHex;
		private CustomControls.RCTLabel rctLabel3;
		private CustomControls.RCTLabel labelError;
		private CustomControls.RCTStatusBar rctStatusBar1;
		private System.Windows.Forms.PictureBox loadingBar;
		private CustomControls.RCTButton rctButton1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Timer timerExtract;
		private CustomControls.RCTLabel labelComplete;
	}
}

