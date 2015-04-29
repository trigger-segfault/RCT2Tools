using CustomControls;
using RCT2GroupCreator.Properties;
namespace RCT2GroupCreator {
	partial class GroupForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupForm));
			this.splitContainerSideView = new System.Windows.Forms.SplitContainer();
			this.buttonNextObject = new CustomControls.RCTButton();
			this.buttonPreviousObject = new CustomControls.RCTButton();
			this.rctButton3 = new CustomControls.RCTButton();
			this.rctButton2 = new CustomControls.RCTButton();
			this.rctButton1 = new CustomControls.RCTButton();
			this.rctPanel3 = new CustomControls.RCTPanel();
			this.iconView = new System.Windows.Forms.PictureBox();
			this.rctPanel4 = new CustomControls.RCTPanel();
			this.buttonNames = new CustomControls.RCTButton();
			this.buttonBrowse = new CustomControls.RCTButton();
			this.buttonSave = new CustomControls.RCTButton();
			this.buttonAbout = new CustomControls.RCTButton();
			this.buttonNew = new CustomControls.RCTButton();
			this.buttonSaveAs = new CustomControls.RCTButton();
			this.buttonOpen = new CustomControls.RCTButton();
			this.rctPanel1 = new CustomControls.RCTPanel();
			this.objectView = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rctPanel2 = new CustomControls.RCTPanel();
			this.tabGroupScenery = new System.Windows.Forms.ListView();
			this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListFlags = new System.Windows.Forms.ImageList();
			this.timerLoadObjects = new System.Windows.Forms.Timer();
			this.objDataBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainerStatusBar = new System.Windows.Forms.SplitContainer();
			this.statusBar = new CustomControls.RCTStatusBar();
			this.labelObjectsInGroup = new CustomControls.RCTLabel();
			this.labelCurrentObject = new CustomControls.RCTLabel();
			this.labelObjectsScanned = new CustomControls.RCTLabel();
			this.labelScanProgress = new CustomControls.RCTLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialogIcon = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogScenery = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).BeginInit();
			this.splitContainerSideView.Panel1.SuspendLayout();
			this.splitContainerSideView.Panel2.SuspendLayout();
			this.splitContainerSideView.SuspendLayout();
			this.rctPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconView)).BeginInit();
			this.rctPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectView)).BeginInit();
			this.panel1.SuspendLayout();
			this.rctPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusBar)).BeginInit();
			this.splitContainerStatusBar.Panel1.SuspendLayout();
			this.splitContainerStatusBar.Panel2.SuspendLayout();
			this.splitContainerStatusBar.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainerSideView
			// 
			this.splitContainerSideView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSideView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerSideView.IsSplitterFixed = true;
			this.splitContainerSideView.Location = new System.Drawing.Point(0, 0);
			this.splitContainerSideView.Name = "splitContainerSideView";
			// 
			// splitContainerSideView.Panel1
			// 
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonNextObject);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonPreviousObject);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctButton3);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctButton2);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctButton1);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctPanel3);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctPanel4);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonNames);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonBrowse);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonSave);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonAbout);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonNew);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonSaveAs);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonOpen);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctPanel1);
			// 
			// splitContainerSideView.Panel2
			// 
			this.splitContainerSideView.Panel2.Controls.Add(this.panel1);
			this.splitContainerSideView.Size = new System.Drawing.Size(756, 360);
			this.splitContainerSideView.SplitterDistance = 207;
			this.splitContainerSideView.SplitterWidth = 1;
			this.splitContainerSideView.TabIndex = 123;
			// 
			// buttonNextObject
			// 
			this.buttonNextObject.BorderOnHover = true;
			this.buttonNextObject.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonNextObject.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextObject.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonNextObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonNextObject.Image = global::RCT2GroupCreator.Properties.Resources.ButtonRight;
			this.buttonNextObject.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextObject.Location = new System.Drawing.Point(34, 266);
			this.buttonNextObject.Name = "buttonNextObject";
			this.buttonNextObject.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNextObject.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNextObject.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextObject.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextObject.Size = new System.Drawing.Size(20, 24);
			this.buttonNextObject.TabIndex = 148;
			this.buttonNextObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextObject.Toggleable = false;
			this.buttonNextObject.Toggled = false;
			this.buttonNextObject.ButtonPressed += new System.EventHandler(this.NextObject);
			// 
			// buttonPreviousObject
			// 
			this.buttonPreviousObject.BorderOnHover = true;
			this.buttonPreviousObject.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPreviousObject.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousObject.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPreviousObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPreviousObject.Image = global::RCT2GroupCreator.Properties.Resources.ButtonLeft;
			this.buttonPreviousObject.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousObject.Location = new System.Drawing.Point(13, 266);
			this.buttonPreviousObject.Name = "buttonPreviousObject";
			this.buttonPreviousObject.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPreviousObject.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPreviousObject.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousObject.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousObject.Size = new System.Drawing.Size(20, 24);
			this.buttonPreviousObject.TabIndex = 147;
			this.buttonPreviousObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousObject.Toggleable = false;
			this.buttonPreviousObject.Toggled = false;
			this.buttonPreviousObject.ButtonPressed += new System.EventHandler(this.PreviousObject);
			// 
			// rctButton3
			// 
			this.rctButton3.BorderOnHover = true;
			this.rctButton3.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton3.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton3.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton3.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton3.Image = global::RCT2GroupCreator.Properties.Resources.ButtonMinus;
			this.rctButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton3.Location = new System.Drawing.Point(100, 266);
			this.rctButton3.Name = "rctButton3";
			this.rctButton3.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton3.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton3.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton3.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton3.Size = new System.Drawing.Size(24, 24);
			this.rctButton3.TabIndex = 146;
			this.rctButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton3.Toggleable = false;
			this.rctButton3.Toggled = false;
			this.rctButton3.ButtonPressed += new System.EventHandler(this.RemoveScenery);
			// 
			// rctButton2
			// 
			this.rctButton2.BorderOnHover = true;
			this.rctButton2.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton2.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton2.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton2.Image = global::RCT2GroupCreator.Properties.Resources.ButtonPlus;
			this.rctButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton2.Location = new System.Drawing.Point(75, 266);
			this.rctButton2.Name = "rctButton2";
			this.rctButton2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton2.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton2.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton2.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton2.Size = new System.Drawing.Size(24, 24);
			this.rctButton2.TabIndex = 145;
			this.rctButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton2.Toggleable = false;
			this.rctButton2.Toggled = false;
			this.rctButton2.ButtonPressed += new System.EventHandler(this.AddScenery);
			// 
			// rctButton1
			// 
			this.rctButton1.BorderOnHover = true;
			this.rctButton1.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctButton1.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctButton1.Image = global::RCT2GroupCreator.Properties.Resources.ButtonIcon;
			this.rctButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Location = new System.Drawing.Point(169, 266);
			this.rctButton1.Name = "rctButton1";
			this.rctButton1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctButton1.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.rctButton1.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctButton1.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctButton1.Size = new System.Drawing.Size(24, 24);
			this.rctButton1.TabIndex = 144;
			this.rctButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rctButton1.Toggleable = false;
			this.rctButton1.Toggled = false;
			this.rctButton1.ButtonPressed += new System.EventHandler(this.ChangeTabIcon);
			// 
			// rctPanel3
			// 
			this.rctPanel3.Controls.Add(this.iconView);
			this.rctPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel3.Location = new System.Drawing.Point(9, 8);
			this.rctPanel3.Name = "rctPanel3";
			this.rctPanel3.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel3.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.rctPanel3.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel3.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel3.Size = new System.Drawing.Size(48, 48);
			this.rctPanel3.TabIndex = 142;
			// 
			// iconView
			// 
			this.iconView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.iconView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.iconView.Location = new System.Drawing.Point(1, 1);
			this.iconView.Name = "iconView";
			this.iconView.Size = new System.Drawing.Size(46, 46);
			this.iconView.TabIndex = 0;
			this.iconView.TabStop = false;
			// 
			// rctPanel4
			// 
			this.rctPanel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel4.Location = new System.Drawing.Point(10, 9);
			this.rctPanel4.Name = "rctPanel4";
			this.rctPanel4.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.rctPanel4.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel4.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel4.Size = new System.Drawing.Size(48, 48);
			this.rctPanel4.TabIndex = 143;
			// 
			// buttonNames
			// 
			this.buttonNames.BorderOnHover = true;
			this.buttonNames.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonNames.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNames.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNames.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonNames.Image = global::RCT2GroupCreator.Properties.Resources.ButtonNames;
			this.buttonNames.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNames.Location = new System.Drawing.Point(144, 266);
			this.buttonNames.Name = "buttonNames";
			this.buttonNames.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNames.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNames.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNames.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNames.Size = new System.Drawing.Size(24, 24);
			this.buttonNames.TabIndex = 143;
			this.buttonNames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNames.Toggleable = false;
			this.buttonNames.Toggled = false;
			this.buttonNames.ButtonPressed += new System.EventHandler(this.ChangeNames);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonBrowse.BorderOnHover = false;
			this.buttonBrowse.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonBrowse.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowse.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowse.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowse.Image = null;
			this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Location = new System.Drawing.Point(140, 308);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowse.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonBrowse.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowse.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowse.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowse.TabIndex = 140;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Toggleable = false;
			this.buttonBrowse.Toggled = false;
			this.buttonBrowse.ButtonPressed += new System.EventHandler(this.BrowseDirectory);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSave.BorderOnHover = false;
			this.buttonSave.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonSave.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSave.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSave.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSave.Image = null;
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSave.Location = new System.Drawing.Point(74, 308);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSave.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSave.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSave.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSave.Size = new System.Drawing.Size(60, 18);
			this.buttonSave.TabIndex = 140;
			this.buttonSave.Text = "Save";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSave.Toggleable = false;
			this.buttonSave.Toggled = false;
			this.buttonSave.ButtonPressed += new System.EventHandler(this.Save);
			// 
			// buttonAbout
			// 
			this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAbout.BorderOnHover = false;
			this.buttonAbout.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonAbout.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonAbout.Image = null;
			this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Location = new System.Drawing.Point(140, 333);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.Size = new System.Drawing.Size(60, 18);
			this.buttonAbout.TabIndex = 140;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.About);
			// 
			// buttonNew
			// 
			this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNew.BorderOnHover = false;
			this.buttonNew.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonNew.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNew.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNew.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonNew.Image = null;
			this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNew.Location = new System.Drawing.Point(8, 308);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNew.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNew.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNew.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNew.Size = new System.Drawing.Size(60, 18);
			this.buttonNew.TabIndex = 140;
			this.buttonNew.Text = "New";
			this.buttonNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNew.Toggleable = false;
			this.buttonNew.Toggled = false;
			this.buttonNew.ButtonPressed += new System.EventHandler(this.New);
			// 
			// buttonSaveAs
			// 
			this.buttonSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSaveAs.BorderOnHover = false;
			this.buttonSaveAs.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonSaveAs.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSaveAs.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSaveAs.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSaveAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSaveAs.Image = null;
			this.buttonSaveAs.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSaveAs.Location = new System.Drawing.Point(74, 333);
			this.buttonSaveAs.Name = "buttonSaveAs";
			this.buttonSaveAs.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSaveAs.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSaveAs.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSaveAs.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSaveAs.Size = new System.Drawing.Size(60, 18);
			this.buttonSaveAs.TabIndex = 140;
			this.buttonSaveAs.Text = "Save As";
			this.buttonSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSaveAs.Toggleable = false;
			this.buttonSaveAs.Toggled = false;
			this.buttonSaveAs.ButtonPressed += new System.EventHandler(this.SaveAs);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonOpen.BorderOnHover = false;
			this.buttonOpen.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonOpen.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonOpen.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonOpen.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonOpen.Image = null;
			this.buttonOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOpen.Location = new System.Drawing.Point(8, 333);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonOpen.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonOpen.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonOpen.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonOpen.Size = new System.Drawing.Size(60, 18);
			this.buttonOpen.TabIndex = 140;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOpen.Toggleable = false;
			this.buttonOpen.Toggled = false;
			this.buttonOpen.ButtonPressed += new System.EventHandler(this.Open);
			// 
			// rctPanel1
			// 
			this.rctPanel1.Controls.Add(this.objectView);
			this.rctPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel1.Location = new System.Drawing.Point(9, 8);
			this.rctPanel1.Name = "rctPanel1";
			this.rctPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctPanel1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel1.Size = new System.Drawing.Size(192, 256);
			this.rctPanel1.TabIndex = 141;
			// 
			// objectView
			// 
			this.objectView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.objectView.Cursor = System.Windows.Forms.Cursors.Default;
			this.objectView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objectView.Location = new System.Drawing.Point(1, 1);
			this.objectView.Margin = new System.Windows.Forms.Padding(0);
			this.objectView.Name = "objectView";
			this.objectView.Size = new System.Drawing.Size(190, 254);
			this.objectView.TabIndex = 9;
			this.objectView.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rctPanel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(548, 360);
			this.panel1.TabIndex = 128;
			// 
			// rctPanel2
			// 
			this.rctPanel2.Controls.Add(this.tabGroupScenery);
			this.rctPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel2.Location = new System.Drawing.Point(3, 3);
			this.rctPanel2.Name = "rctPanel2";
			this.rctPanel2.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel2.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctPanel2.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel2.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel2.Size = new System.Drawing.Size(542, 354);
			this.rctPanel2.TabIndex = 127;
			// 
			// tabGroupScenery
			// 
			this.tabGroupScenery.AllowDrop = true;
			this.tabGroupScenery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupScenery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupScenery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader56});
			this.tabGroupScenery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupScenery.FullRowSelect = true;
			this.tabGroupScenery.HideSelection = false;
			this.tabGroupScenery.Location = new System.Drawing.Point(1, 1);
			this.tabGroupScenery.Name = "tabGroupScenery";
			this.tabGroupScenery.OwnerDraw = true;
			this.tabGroupScenery.Size = new System.Drawing.Size(540, 352);
			this.tabGroupScenery.SmallImageList = this.imageListFlags;
			this.tabGroupScenery.TabIndex = 126;
			this.tabGroupScenery.TabStop = false;
			this.tabGroupScenery.UseCompatibleStateImageBehavior = false;
			this.tabGroupScenery.View = System.Windows.Forms.View.Details;
			this.tabGroupScenery.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupScenery.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupScenery.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupScenery.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupScenery.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupScenery.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupScenery.DragDrop += new System.Windows.Forms.DragEventHandler(this.SceneryListDragDrop);
			this.tabGroupScenery.DragEnter += new System.Windows.Forms.DragEventHandler(this.SceneryListDragEnter);
			this.tabGroupScenery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteScenery);
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "";
			this.columnHeader16.Width = 32;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Source";
			this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader17.Width = 59;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "File";
			this.columnHeader18.Width = 110;
			// 
			// columnHeader19
			// 
			this.columnHeader19.Text = "Name";
			this.columnHeader19.Width = 142;
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "Type";
			this.columnHeader20.Width = 100;
			// 
			// columnHeader56
			// 
			this.columnHeader56.Text = "Subtype";
			this.columnHeader56.Width = 80;
			// 
			// imageListFlags
			// 
			this.imageListFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFlags.ImageStream")));
			this.imageListFlags.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListFlags.Images.SetKeyName(0, "CloseFlag.png");
			this.imageListFlags.Images.SetKeyName(1, "TestFlag.png");
			this.imageListFlags.Images.SetKeyName(2, "OpenFlagDown.png");
			this.imageListFlags.Images.SetKeyName(3, "BrokenFlagDown.png");
			// 
			// timerLoadObjects
			// 
			this.timerLoadObjects.Interval = 200;
			this.timerLoadObjects.Tick += new System.EventHandler(this.LoadObjects);
			// 
			// objDataBrowserDialog
			// 
			this.objDataBrowserDialog.Description = "ObjData Folder Location";
			this.objDataBrowserDialog.SelectedPath = "Environment.SpecialFolder.Desktop";
			this.objDataBrowserDialog.ShowNewFolderButton = false;
			// 
			// splitContainerStatusBar
			// 
			this.splitContainerStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerStatusBar.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerStatusBar.IsSplitterFixed = true;
			this.splitContainerStatusBar.Location = new System.Drawing.Point(0, 0);
			this.splitContainerStatusBar.Name = "splitContainerStatusBar";
			this.splitContainerStatusBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerStatusBar.Panel1
			// 
			this.splitContainerStatusBar.Panel1.Controls.Add(this.splitContainerSideView);
			this.splitContainerStatusBar.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainerStatusBar.Panel2
			// 
			this.splitContainerStatusBar.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.splitContainerStatusBar.Panel2.Controls.Add(this.statusBar);
			this.splitContainerStatusBar.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerStatusBar.Panel2MinSize = 26;
			this.splitContainerStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerStatusBar.Size = new System.Drawing.Size(756, 387);
			this.splitContainerStatusBar.SplitterDistance = 360;
			this.splitContainerStatusBar.SplitterWidth = 1;
			this.splitContainerStatusBar.TabIndex = 33;
			// 
			// statusBar
			// 
			this.statusBar.Controls.Add(this.labelObjectsInGroup);
			this.statusBar.Controls.Add(this.labelCurrentObject);
			this.statusBar.Controls.Add(this.labelObjectsScanned);
			this.statusBar.Controls.Add(this.labelScanProgress);
			this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusBar.Location = new System.Drawing.Point(0, 0);
			this.statusBar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.statusBar.Name = "statusBar";
			this.statusBar.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.statusBar.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.statusBar.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.statusBar.Separators.Add(202);
			this.statusBar.Separators.Add(410);
			this.statusBar.Size = new System.Drawing.Size(756, 26);
			this.statusBar.TabIndex = 141;
			// 
			// labelObjectsInGroup
			// 
			this.labelObjectsInGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelObjectsInGroup.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelObjectsInGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelObjectsInGroup.Location = new System.Drawing.Point(586, 5);
			this.labelObjectsInGroup.Name = "labelObjectsInGroup";
			this.labelObjectsInGroup.OutlineColor = System.Drawing.Color.Transparent;
			this.labelObjectsInGroup.Size = new System.Drawing.Size(150, 14);
			this.labelObjectsInGroup.TabIndex = 145;
			this.labelObjectsInGroup.Text = "All: 0";
			this.labelObjectsInGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelCurrentObject
			// 
			this.labelCurrentObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelCurrentObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelCurrentObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelCurrentObject.Location = new System.Drawing.Point(14, 5);
			this.labelCurrentObject.Name = "labelCurrentObject";
			this.labelCurrentObject.OutlineColor = System.Drawing.Color.Transparent;
			this.labelCurrentObject.Size = new System.Drawing.Size(176, 14);
			this.labelCurrentObject.TabIndex = 142;
			this.labelCurrentObject.Text = "CurrentObject";
			this.labelCurrentObject.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelObjectsScanned
			// 
			this.labelObjectsScanned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelObjectsScanned.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelObjectsScanned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelObjectsScanned.Location = new System.Drawing.Point(430, 5);
			this.labelObjectsScanned.Name = "labelObjectsScanned";
			this.labelObjectsScanned.OutlineColor = System.Drawing.Color.Transparent;
			this.labelObjectsScanned.Size = new System.Drawing.Size(150, 14);
			this.labelObjectsScanned.TabIndex = 144;
			this.labelObjectsScanned.Text = "Objects Scanned: 0";
			this.labelObjectsScanned.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelScanProgress
			// 
			this.labelScanProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.labelScanProgress.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelScanProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelScanProgress.Location = new System.Drawing.Point(222, 5);
			this.labelScanProgress.Name = "labelScanProgress";
			this.labelScanProgress.OutlineColor = System.Drawing.Color.Transparent;
			this.labelScanProgress.Size = new System.Drawing.Size(186, 14);
			this.labelScanProgress.TabIndex = 143;
			this.labelScanProgress.Text = "Ready to Scan";
			this.labelScanProgress.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "DAT";
			this.openFileDialog.Filter = "RCT2 Object Files|*.DAT";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "DAT";
			// 
			// openFileDialogIcon
			// 
			this.openFileDialogIcon.Filter = "Image Files|*.bmp;*.png;*.jpg";
			// 
			// openFileDialogScenery
			// 
			this.openFileDialogScenery.DefaultExt = "DAT";
			this.openFileDialogScenery.Filter = "RCT2 Object Files|*.DAT";
			this.openFileDialogScenery.Multiselect = true;
			// 
			// GroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(756, 387);
			this.Controls.Add(this.splitContainerStatusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(772, 425);
			this.Name = "GroupForm";
			this.Text = "Trigger\'s Group Creator";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.splitContainerSideView.Panel1.ResumeLayout(false);
			this.splitContainerSideView.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).EndInit();
			this.splitContainerSideView.ResumeLayout(false);
			this.rctPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.iconView)).EndInit();
			this.rctPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.rctPanel2.ResumeLayout(false);
			this.splitContainerStatusBar.Panel1.ResumeLayout(false);
			this.splitContainerStatusBar.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusBar)).EndInit();
			this.splitContainerStatusBar.ResumeLayout(false);
			this.statusBar.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox objectView;
		private System.Windows.Forms.SplitContainer splitContainerSideView;
		private System.Windows.Forms.ImageList imageListFlags;
		private System.Windows.Forms.Timer timerLoadObjects;
		private System.Windows.Forms.ListView tabGroupScenery;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.FolderBrowserDialog objDataBrowserDialog;
		private System.Windows.Forms.SplitContainer splitContainerStatusBar;
		private System.Windows.Forms.ColumnHeader columnHeader56;
		private RCTLabel labelObjectsInGroup;
		private RCTLabel labelObjectsScanned;
		private RCTLabel labelScanProgress;
		private RCTLabel labelCurrentObject;
		private RCTStatusBar statusBar;
		private RCTPanel rctPanel1;
		private RCTPanel rctPanel3;
		private RCTPanel rctPanel2;
		private RCTButton buttonNames;
		private RCTButton buttonBrowse;
		private RCTButton buttonSave;
		private RCTButton buttonAbout;
		private RCTButton buttonNew;
		private RCTButton buttonSaveAs;
		private RCTButton buttonOpen;
		private RCTPanel rctPanel4;
		private System.Windows.Forms.Panel panel1;
		private RCTButton rctButton1;
		private RCTButton rctButton2;
		private RCTButton rctButton3;
		private RCTButton buttonNextObject;
		private RCTButton buttonPreviousObject;
		private System.Windows.Forms.PictureBox iconView;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialogIcon;
		private System.Windows.Forms.OpenFileDialog openFileDialogScenery;
	}
}

