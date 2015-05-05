using CustomControls;
namespace RCT2AudioExtractor {
	partial class AudioForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioForm));
			this.buttonAbout = new CustomControls.RCTButton();
			this.buttonExtract = new CustomControls.RCTButton();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.buttonBrowseOut = new CustomControls.RCTButton();
			this.buttonBrowseIn = new CustomControls.RCTButton();
			this.labelComplete = new CustomControls.RCTLabel();
			this.rctStatusBar1 = new CustomControls.RCTStatusBar();
			this.labelError = new CustomControls.RCTLabel();
			this.loadingBar = new System.Windows.Forms.PictureBox();
			this.rctLabel3 = new CustomControls.RCTLabel();
			this.checkBoxNames = new CustomControls.RCTCheckBox();
			this.checkBoxDecimal = new CustomControls.RCTCheckBox();
			this.checkBoxMusic = new CustomControls.RCTCheckBox();
			this.folderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
			this.timerExtract = new System.Windows.Forms.Timer(this.components);
			this.rctStatusBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadingBar)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAbout
			// 
			this.buttonAbout.BorderOnHover = false;
			this.buttonAbout.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonAbout.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonAbout.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonAbout.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonAbout.Image = null;
			this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Location = new System.Drawing.Point(145, 151);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonAbout.Size = new System.Drawing.Size(80, 22);
			this.buttonAbout.TabIndex = 148;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.About);
			// 
			// buttonExtract
			// 
			this.buttonExtract.BorderOnHover = false;
			this.buttonExtract.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonExtract.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonExtract.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonExtract.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonExtract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonExtract.Image = null;
			this.buttonExtract.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonExtract.Location = new System.Drawing.Point(40, 151);
			this.buttonExtract.Name = "buttonExtract";
			this.buttonExtract.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonExtract.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonExtract.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonExtract.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonExtract.Size = new System.Drawing.Size(80, 22);
			this.buttonExtract.TabIndex = 145;
			this.buttonExtract.Text = "Extract";
			this.buttonExtract.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonExtract.Toggleable = false;
			this.buttonExtract.Toggled = false;
			this.buttonExtract.ButtonPressed += new System.EventHandler(this.Extract);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Choose the RCT2 Data directory";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// rctLabel2
			// 
			this.rctLabel2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(44, 47);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel2.Size = new System.Drawing.Size(98, 14);
			this.rctLabel2.TabIndex = 154;
			this.rctLabel2.Text = "Output Directory:";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel1
			// 
			this.rctLabel1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(44, 20);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel1.Size = new System.Drawing.Size(98, 14);
			this.rctLabel1.TabIndex = 153;
			this.rctLabel1.Text = "Data Directory:";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// buttonBrowseOut
			// 
			this.buttonBrowseOut.BorderOnHover = false;
			this.buttonBrowseOut.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonBrowseOut.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowseOut.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowseOut.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowseOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowseOut.Image = null;
			this.buttonBrowseOut.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseOut.Location = new System.Drawing.Point(151, 45);
			this.buttonBrowseOut.Name = "buttonBrowseOut";
			this.buttonBrowseOut.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowseOut.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonBrowseOut.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowseOut.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowseOut.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowseOut.TabIndex = 152;
			this.buttonBrowseOut.Text = "Browse";
			this.buttonBrowseOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseOut.Toggleable = false;
			this.buttonBrowseOut.Toggled = false;
			this.buttonBrowseOut.ButtonPressed += new System.EventHandler(this.ChangeOutputDirectory);
			// 
			// buttonBrowseIn
			// 
			this.buttonBrowseIn.BorderOnHover = false;
			this.buttonBrowseIn.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonBrowseIn.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowseIn.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowseIn.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowseIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowseIn.Image = null;
			this.buttonBrowseIn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseIn.Location = new System.Drawing.Point(151, 17);
			this.buttonBrowseIn.Name = "buttonBrowseIn";
			this.buttonBrowseIn.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowseIn.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonBrowseIn.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowseIn.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowseIn.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowseIn.TabIndex = 151;
			this.buttonBrowseIn.Text = "Browse";
			this.buttonBrowseIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseIn.Toggleable = false;
			this.buttonBrowseIn.Toggled = false;
			this.buttonBrowseIn.ButtonPressed += new System.EventHandler(this.ChangeDataDirectory);
			// 
			// labelComplete
			// 
			this.labelComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.labelComplete.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelComplete.Location = new System.Drawing.Point(17, 6);
			this.labelComplete.Name = "labelComplete";
			this.labelComplete.OutlineColor = System.Drawing.Color.Transparent;
			this.labelComplete.Size = new System.Drawing.Size(230, 14);
			this.labelComplete.TabIndex = 7;
			this.labelComplete.Text = "Extraction Finished";
			this.labelComplete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelComplete.Visible = false;
			// 
			// rctStatusBar1
			// 
			this.rctStatusBar1.Controls.Add(this.labelComplete);
			this.rctStatusBar1.Controls.Add(this.labelError);
			this.rctStatusBar1.Controls.Add(this.loadingBar);
			this.rctStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.rctStatusBar1.Location = new System.Drawing.Point(0, 186);
			this.rctStatusBar1.Name = "rctStatusBar1";
			this.rctStatusBar1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
			this.rctStatusBar1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.rctStatusBar1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.rctStatusBar1.Size = new System.Drawing.Size(282, 26);
			this.rctStatusBar1.TabIndex = 155;
			// 
			// labelError
			// 
			this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelError.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.labelError.Location = new System.Drawing.Point(17, 6);
			this.labelError.Name = "labelError";
			this.labelError.OutlineColor = System.Drawing.Color.Transparent;
			this.labelError.Size = new System.Drawing.Size(230, 14);
			this.labelError.TabIndex = 7;
			this.labelError.Text = "Error loading G1.dat";
			this.labelError.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelError.Visible = false;
			// 
			// loadingBar
			// 
			this.loadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.loadingBar.Location = new System.Drawing.Point(4, 4);
			this.loadingBar.Margin = new System.Windows.Forms.Padding(4);
			this.loadingBar.Name = "loadingBar";
			this.loadingBar.Padding = new System.Windows.Forms.Padding(4);
			this.loadingBar.Size = new System.Drawing.Size(274, 18);
			this.loadingBar.TabIndex = 9;
			this.loadingBar.TabStop = false;
			this.loadingBar.Visible = false;
			// 
			// rctLabel3
			// 
			this.rctLabel3.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel3.Location = new System.Drawing.Point(44, 77);
			this.rctLabel3.Name = "rctLabel3";
			this.rctLabel3.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel3.Size = new System.Drawing.Size(128, 14);
			this.rctLabel3.TabIndex = 12;
			this.rctLabel3.Text = "Sound Naming Format:";
			this.rctLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// checkBoxNames
			// 
			this.checkBoxNames.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.checkBoxNames.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.checkBoxNames.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBoxNames.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.checkBoxNames.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNames.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxNames.Location = new System.Drawing.Point(120, 99);
			this.checkBoxNames.Name = "checkBoxNames";
			this.checkBoxNames.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxNames.Size = new System.Drawing.Size(54, 11);
			this.checkBoxNames.TabIndex = 11;
			this.checkBoxNames.Text = "Names";
			this.checkBoxNames.CheckStateChanged += new System.EventHandler(this.NameFormat);
			// 
			// checkBoxDecimal
			// 
			this.checkBoxDecimal.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.checkBoxDecimal.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.checkBoxDecimal.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBoxDecimal.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.checkBoxDecimal.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxDecimal.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxDecimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxDecimal.Location = new System.Drawing.Point(50, 99);
			this.checkBoxDecimal.Name = "checkBoxDecimal";
			this.checkBoxDecimal.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxDecimal.Size = new System.Drawing.Size(64, 11);
			this.checkBoxDecimal.TabIndex = 10;
			this.checkBoxDecimal.Text = "Numbers";
			this.checkBoxDecimal.CheckStateChanged += new System.EventHandler(this.NumberFormat);
			// 
			// checkBoxMusic
			// 
			this.checkBoxMusic.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.checkBoxMusic.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.checkBoxMusic.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.checkBoxMusic.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
			this.checkBoxMusic.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxMusic.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxMusic.Location = new System.Drawing.Point(50, 125);
			this.checkBoxMusic.Name = "checkBoxMusic";
			this.checkBoxMusic.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxMusic.Size = new System.Drawing.Size(134, 11);
			this.checkBoxMusic.TabIndex = 156;
			this.checkBoxMusic.Text = "Extract Music as MP3";
			this.checkBoxMusic.CheckStateChanged += new System.EventHandler(this.ExtractMusic);
			// 
			// folderBrowserDialogOutput
			// 
			this.folderBrowserDialogOutput.Description = "Choose the output directory";
			// 
			// timerExtract
			// 
			this.timerExtract.Tick += new System.EventHandler(this.Extracting);
			// 
			// AudioForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(282, 212);
			this.Controls.Add(this.checkBoxMusic);
			this.Controls.Add(this.rctLabel3);
			this.Controls.Add(this.checkBoxNames);
			this.Controls.Add(this.rctStatusBar1);
			this.Controls.Add(this.checkBoxDecimal);
			this.Controls.Add(this.rctLabel2);
			this.Controls.Add(this.rctLabel1);
			this.Controls.Add(this.buttonBrowseOut);
			this.Controls.Add(this.buttonBrowseIn);
			this.Controls.Add(this.buttonAbout);
			this.Controls.Add(this.buttonExtract);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(298, 250);
			this.Name = "AudioForm";
			this.Text = "Trigger\'s Audio Extractor";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.rctStatusBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.loadingBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private RCTButton buttonExtract;
		private RCTButton buttonAbout;
		private RCTLabel rctLabel2;
		private RCTLabel rctLabel1;
		private RCTButton buttonBrowseOut;
		private RCTButton buttonBrowseIn;
		private RCTLabel labelComplete;
		private RCTStatusBar rctStatusBar1;
		private RCTLabel labelError;
		private System.Windows.Forms.PictureBox loadingBar;
		private RCTLabel rctLabel3;
		private RCTCheckBox checkBoxNames;
		private RCTCheckBox checkBoxDecimal;
		private RCTCheckBox checkBoxMusic;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutput;
		private System.Windows.Forms.Timer timerExtract;
	}
}

