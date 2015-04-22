using CustomControls;
namespace RCTDataEditor {
	partial class BrowserForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Graphics", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("String Table", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Header", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Header 1", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Header 2", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Header 3", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Header 4", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Group Info", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Optional", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Optional", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Optional", System.Windows.Forms.HorizontalAlignment.Left);
			this.splitContainerSideView = new System.Windows.Forms.SplitContainer();
			this.imageListPaletteButton = new System.Windows.Forms.ImageList(this.components);
			this.splitContainerTabs = new System.Windows.Forms.SplitContainer();
			this.imageListFlags = new System.Windows.Forms.ImageList(this.components);
			this.timerLoadObjects = new System.Windows.Forms.Timer(this.components);
			this.objDataBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainerStatusBar = new System.Windows.Forms.SplitContainer();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.timerExtract = new System.Windows.Forms.Timer(this.components);
			this.rctPanel1 = new CustomControls.RCTPanel();
			this.scrollBarImage = new System.Windows.Forms.HScrollBar();
			this.labelImageOffset = new CustomControls.RCTLabel();
			this.labelImageSize = new CustomControls.RCTLabel();
			this.checkBoxImageView = new CustomControls.RCTCheckBox();
			this.checkBoxDialogView = new CustomControls.RCTCheckBox();
			this.rctTabPanel1 = new CustomControls.RCTTabPanel();
			this.buttonBrowse = new CustomControls.RCTButton();
			this.tabGroupSettings = new System.Windows.Forms.Panel();
			this.checkBoxBackupDeletions = new CustomControls.RCTCheckBox();
			this.checkBoxAllowDeletions = new CustomControls.RCTCheckBox();
			this.buttonOpenDir = new CustomControls.RCTButton();
			this.buttonExtract = new CustomControls.RCTButton();
			this.checkBoxRemapImage = new CustomControls.RCTCheckBox();
			this.buttonAbout = new CustomControls.RCTButton();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.checkBoxQuickLoad = new CustomControls.RCTCheckBox();
			this.buttonSaveSettings = new CustomControls.RCTButton();
			this.buttonBrowseDefault = new CustomControls.RCTButton();
			this.numericUpDownObjectsPerTick = new System.Windows.Forms.NumericUpDown();
			this.textBoxDirectory = new System.Windows.Forms.TextBox();
			this.tabGroupWater = new System.Windows.Forms.ListView();
			this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupParkEntrances = new System.Windows.Forms.ListView();
			this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupSceneryGroups = new System.Windows.Forms.ListView();
			this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupPathAdditions = new System.Windows.Forms.ListView();
			this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupPaths = new System.Windows.Forms.ListView();
			this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupSigns = new System.Windows.Forms.ListView();
			this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupWalls = new System.Windows.Forms.ListView();
			this.columnHeaderFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSubtype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupLargeScenery = new System.Windows.Forms.ListView();
			this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupSmallScenery = new System.Windows.Forms.ListView();
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupAttractions = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupAll = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGroupInfo = new System.Windows.Forms.ListView();
			this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonScan = new CustomControls.RCTButton();
			this.rctPanel2 = new CustomControls.RCTPanel();
			this.tabGroupInfoOld = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.infoImageOffset = new System.Windows.Forms.Label();
			this.infoImageSize = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.infoHeight = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.infoFrames = new System.Windows.Forms.Label();
			this.infoFlags = new System.Windows.Forms.Label();
			this.infoName = new System.Windows.Forms.Label();
			this.infoFileName = new System.Windows.Forms.Label();
			this.statusBar = new CustomControls.RCTStatusBar();
			this.labelObjectsInGroup = new CustomControls.RCTLabel();
			this.labelCurrentObject = new CustomControls.RCTLabel();
			this.labelObjectsScanned = new CustomControls.RCTLabel();
			this.labelScanProgress = new CustomControls.RCTLabel();
			this.panelColorPalette = new System.Windows.Forms.Panel();
			this.objectView = new System.Windows.Forms.PictureBox();
			this.buttonNextObject = new CustomControls.RCTButton();
			this.buttonElevate = new CustomControls.RCTButton();
			this.buttonPreviousObject = new CustomControls.RCTButton();
			this.buttonCorner = new CustomControls.RCTButton();
			this.buttonSlope = new CustomControls.RCTButton();
			this.buttonPreviousFrame = new CustomControls.RCTButton();
			this.buttonRotate = new CustomControls.RCTButton();
			this.buttonNextFrame = new CustomControls.RCTButton();
			this.buttonRemap1 = new System.Windows.Forms.Button();
			this.buttonRemap2 = new System.Windows.Forms.Button();
			this.buttonRemap3 = new System.Windows.Forms.Button();
			this.tabInfo = new CustomControls.RCTTabButton();
			this.tabAll = new CustomControls.RCTTabButton();
			this.tabAttractions = new CustomControls.RCTTabButton();
			this.tabSmallScenery = new CustomControls.RCTTabButton();
			this.tabLargeScenery = new CustomControls.RCTTabButton();
			this.tabWalls = new CustomControls.RCTTabButton();
			this.tabSigns = new CustomControls.RCTTabButton();
			this.tabPaths = new CustomControls.RCTTabButton();
			this.tabPathAdditions = new CustomControls.RCTTabButton();
			this.tabSceneryGroups = new CustomControls.RCTTabButton();
			this.tabParkEntrances = new CustomControls.RCTTabButton();
			this.tabWater = new CustomControls.RCTTabButton();
			this.tabSettings = new CustomControls.RCTTabButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).BeginInit();
			this.splitContainerSideView.Panel1.SuspendLayout();
			this.splitContainerSideView.Panel2.SuspendLayout();
			this.splitContainerSideView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTabs)).BeginInit();
			this.splitContainerTabs.Panel1.SuspendLayout();
			this.splitContainerTabs.Panel2.SuspendLayout();
			this.splitContainerTabs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusBar)).BeginInit();
			this.splitContainerStatusBar.Panel1.SuspendLayout();
			this.splitContainerStatusBar.Panel2.SuspendLayout();
			this.splitContainerStatusBar.SuspendLayout();
			this.rctPanel1.SuspendLayout();
			this.rctTabPanel1.SuspendLayout();
			this.tabGroupSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownObjectsPerTick)).BeginInit();
			this.rctPanel2.SuspendLayout();
			this.tabGroupInfoOld.SuspendLayout();
			this.statusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectView)).BeginInit();
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
			this.splitContainerSideView.Panel1.Controls.Add(this.panelColorPalette);
			this.splitContainerSideView.Panel1.Controls.Add(this.rctPanel1);
			this.splitContainerSideView.Panel1.Controls.Add(this.labelImageOffset);
			this.splitContainerSideView.Panel1.Controls.Add(this.labelImageSize);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonNextObject);
			this.splitContainerSideView.Panel1.Controls.Add(this.checkBoxImageView);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonElevate);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonPreviousObject);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonCorner);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonSlope);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonPreviousFrame);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRotate);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonNextFrame);
			this.splitContainerSideView.Panel1.Controls.Add(this.checkBoxDialogView);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRemap1);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRemap2);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRemap3);
			// 
			// splitContainerSideView.Panel2
			// 
			this.splitContainerSideView.Panel2.Controls.Add(this.splitContainerTabs);
			this.splitContainerSideView.Size = new System.Drawing.Size(761, 400);
			this.splitContainerSideView.SplitterDistance = 207;
			this.splitContainerSideView.SplitterWidth = 1;
			this.splitContainerSideView.TabIndex = 123;
			// 
			// imageListPaletteButton
			// 
			this.imageListPaletteButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPaletteButton.ImageStream")));
			this.imageListPaletteButton.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListPaletteButton.Images.SetKeyName(0, "PaletteButton.png");
			this.imageListPaletteButton.Images.SetKeyName(1, "PaletteButton.png");
			this.imageListPaletteButton.Images.SetKeyName(2, "PaletteButtonPressed.png");
			// 
			// splitContainerTabs
			// 
			this.splitContainerTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerTabs.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerTabs.IsSplitterFixed = true;
			this.splitContainerTabs.Location = new System.Drawing.Point(0, 0);
			this.splitContainerTabs.Name = "splitContainerTabs";
			this.splitContainerTabs.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerTabs.Panel1
			// 
			this.splitContainerTabs.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(103)))), ((int)(((byte)(75)))));
			this.splitContainerTabs.Panel1.Controls.Add(this.rctTabPanel1);
			this.splitContainerTabs.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainerTabs.Panel2
			// 
			this.splitContainerTabs.Panel2.Controls.Add(this.rctPanel2);
			this.splitContainerTabs.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainerTabs.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerTabs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerTabs.Size = new System.Drawing.Size(553, 400);
			this.splitContainerTabs.SplitterDistance = 32;
			this.splitContainerTabs.SplitterWidth = 1;
			this.splitContainerTabs.TabIndex = 33;
			this.splitContainerTabs.TabStop = false;
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
			this.splitContainerStatusBar.Size = new System.Drawing.Size(761, 427);
			this.splitContainerStatusBar.SplitterDistance = 400;
			this.splitContainerStatusBar.SplitterWidth = 1;
			this.splitContainerStatusBar.TabIndex = 33;
			// 
			// toolTips
			// 
			this.toolTips.AutoPopDelay = 5000;
			this.toolTips.InitialDelay = 1000;
			this.toolTips.ReshowDelay = 600;
			// 
			// timerExtract
			// 
			this.timerExtract.Tick += new System.EventHandler(this.ExtractingImages);
			// 
			// rctPanel1
			// 
			this.rctPanel1.Controls.Add(this.scrollBarImage);
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
			// scrollBarImage
			// 
			this.scrollBarImage.Enabled = false;
			this.scrollBarImage.LargeChange = 1;
			this.scrollBarImage.Location = new System.Drawing.Point(1, 238);
			this.scrollBarImage.Maximum = 4;
			this.scrollBarImage.Name = "scrollBarImage";
			this.scrollBarImage.Size = new System.Drawing.Size(190, 17);
			this.scrollBarImage.TabIndex = 42;
			this.scrollBarImage.Visible = false;
			this.scrollBarImage.ValueChanged += new System.EventHandler(this.ScrollImages);
			// 
			// labelImageOffset
			// 
			this.labelImageOffset.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelImageOffset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelImageOffset.Location = new System.Drawing.Point(14, 345);
			this.labelImageOffset.Name = "labelImageOffset";
			this.labelImageOffset.OutlineColor = System.Drawing.Color.Transparent;
			this.labelImageOffset.Size = new System.Drawing.Size(176, 14);
			this.labelImageOffset.TabIndex = 141;
			this.labelImageOffset.Text = "Image Offset:";
			this.labelImageOffset.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// labelImageSize
			// 
			this.labelImageSize.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelImageSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelImageSize.Location = new System.Drawing.Point(14, 329);
			this.labelImageSize.Name = "labelImageSize";
			this.labelImageSize.OutlineColor = System.Drawing.Color.Transparent;
			this.labelImageSize.Size = new System.Drawing.Size(176, 14);
			this.labelImageSize.TabIndex = 131;
			this.labelImageSize.Text = "Image Size:";
			this.labelImageSize.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// checkBoxImageView
			// 
			this.checkBoxImageView.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxImageView.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxImageView.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxImageView.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxImageView.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxImageView.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxImageView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxImageView.Location = new System.Drawing.Point(140, 303);
			this.checkBoxImageView.Name = "checkBoxImageView";
			this.checkBoxImageView.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxImageView.Size = new System.Drawing.Size(50, 11);
			this.checkBoxImageView.TabIndex = 140;
			this.checkBoxImageView.Text = "Image";
			this.checkBoxImageView.CheckStateChanged += new System.EventHandler(this.FrameView);
			// 
			// checkBoxDialogView
			// 
			this.checkBoxDialogView.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxDialogView.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxDialogView.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxDialogView.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxDialogView.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxDialogView.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxDialogView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxDialogView.Location = new System.Drawing.Point(80, 303);
			this.checkBoxDialogView.Name = "checkBoxDialogView";
			this.checkBoxDialogView.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxDialogView.Size = new System.Drawing.Size(52, 11);
			this.checkBoxDialogView.TabIndex = 139;
			this.checkBoxDialogView.Text = "Dialog";
			this.checkBoxDialogView.CheckStateChanged += new System.EventHandler(this.DialogView);
			// 
			// rctTabPanel1
			// 
			this.rctTabPanel1.Controls.Add(this.buttonBrowse);
			this.rctTabPanel1.Controls.Add(this.tabInfo);
			this.rctTabPanel1.Controls.Add(this.tabSettings);
			this.rctTabPanel1.Controls.Add(this.tabAll);
			this.rctTabPanel1.Controls.Add(this.tabWater);
			this.rctTabPanel1.Controls.Add(this.tabAttractions);
			this.rctTabPanel1.Controls.Add(this.tabParkEntrances);
			this.rctTabPanel1.Controls.Add(this.tabSmallScenery);
			this.rctTabPanel1.Controls.Add(this.tabWalls);
			this.rctTabPanel1.Controls.Add(this.tabLargeScenery);
			this.rctTabPanel1.Controls.Add(this.buttonScan);
			this.rctTabPanel1.Controls.Add(this.tabSigns);
			this.rctTabPanel1.Controls.Add(this.tabSceneryGroups);
			this.rctTabPanel1.Controls.Add(this.tabPaths);
			this.rctTabPanel1.Controls.Add(this.tabPathAdditions);
			this.rctTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctTabPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctTabPanel1.Location = new System.Drawing.Point(0, 0);
			this.rctTabPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.rctTabPanel1.Name = "rctTabPanel1";
			this.rctTabPanel1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(103)))), ((int)(((byte)(75)))));
			this.rctTabPanel1.PanelBorderColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctTabPanel1.PanelBorderColorCorner = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctTabPanel1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(63)))), ((int)(((byte)(31)))));
			this.rctTabPanel1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(147)))), ((int)(((byte)(127)))));
			this.rctTabPanel1.Size = new System.Drawing.Size(553, 32);
			this.rctTabPanel1.TabIndex = 141;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.BorderOnHover = false;
			this.buttonBrowse.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonBrowse.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowse.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowse.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowse.Image = null;
			this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Location = new System.Drawing.Point(419, 9);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowse.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonBrowse.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowse.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowse.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowse.TabIndex = 139;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Toggleable = false;
			this.buttonBrowse.Toggled = false;
			this.buttonBrowse.ButtonPressed += new System.EventHandler(this.BrowseDirectory);
			// 
			// tabGroupSettings
			// 
			this.tabGroupSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupSettings.Controls.Add(this.checkBoxBackupDeletions);
			this.tabGroupSettings.Controls.Add(this.checkBoxAllowDeletions);
			this.tabGroupSettings.Controls.Add(this.buttonOpenDir);
			this.tabGroupSettings.Controls.Add(this.buttonExtract);
			this.tabGroupSettings.Controls.Add(this.checkBoxRemapImage);
			this.tabGroupSettings.Controls.Add(this.buttonAbout);
			this.tabGroupSettings.Controls.Add(this.rctLabel2);
			this.tabGroupSettings.Controls.Add(this.rctLabel1);
			this.tabGroupSettings.Controls.Add(this.checkBoxQuickLoad);
			this.tabGroupSettings.Controls.Add(this.buttonSaveSettings);
			this.tabGroupSettings.Controls.Add(this.buttonBrowseDefault);
			this.tabGroupSettings.Controls.Add(this.numericUpDownObjectsPerTick);
			this.tabGroupSettings.Controls.Add(this.textBoxDirectory);
			this.tabGroupSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupSettings.Location = new System.Drawing.Point(1, 1);
			this.tabGroupSettings.Name = "tabGroupSettings";
			this.tabGroupSettings.Size = new System.Drawing.Size(545, 359);
			this.tabGroupSettings.TabIndex = 0;
			this.tabGroupSettings.Visible = false;
			// 
			// checkBoxBackupDeletions
			// 
			this.checkBoxBackupDeletions.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxBackupDeletions.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxBackupDeletions.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxBackupDeletions.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxBackupDeletions.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxBackupDeletions.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxBackupDeletions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxBackupDeletions.Location = new System.Drawing.Point(163, 130);
			this.checkBoxBackupDeletions.Name = "checkBoxBackupDeletions";
			this.checkBoxBackupDeletions.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxBackupDeletions.Size = new System.Drawing.Size(110, 11);
			this.checkBoxBackupDeletions.TabIndex = 153;
			this.checkBoxBackupDeletions.Text = "Backup Deletions";
			this.checkBoxBackupDeletions.CheckStateChanged += new System.EventHandler(this.BackupDeletions);
			// 
			// checkBoxAllowDeletions
			// 
			this.checkBoxAllowDeletions.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxAllowDeletions.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxAllowDeletions.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxAllowDeletions.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxAllowDeletions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxAllowDeletions.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxAllowDeletions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxAllowDeletions.Location = new System.Drawing.Point(15, 130);
			this.checkBoxAllowDeletions.Name = "checkBoxAllowDeletions";
			this.checkBoxAllowDeletions.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxAllowDeletions.Size = new System.Drawing.Size(100, 11);
			this.checkBoxAllowDeletions.TabIndex = 152;
			this.checkBoxAllowDeletions.Text = "Allow Deletions";
			this.checkBoxAllowDeletions.CheckStateChanged += new System.EventHandler(this.AllowDeletions);
			// 
			// buttonOpenDir
			// 
			this.buttonOpenDir.BorderOnHover = false;
			this.buttonOpenDir.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonOpenDir.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonOpenDir.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonOpenDir.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonOpenDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonOpenDir.Image = null;
			this.buttonOpenDir.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOpenDir.Location = new System.Drawing.Point(121, 154);
			this.buttonOpenDir.Name = "buttonOpenDir";
			this.buttonOpenDir.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonOpenDir.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonOpenDir.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonOpenDir.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonOpenDir.Size = new System.Drawing.Size(100, 18);
			this.buttonOpenDir.TabIndex = 151;
			this.buttonOpenDir.Text = "Open Directory";
			this.buttonOpenDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOpenDir.Toggleable = false;
			this.buttonOpenDir.Toggled = false;
			this.buttonOpenDir.ButtonPressed += new System.EventHandler(this.OpenExtractDirectory);
			// 
			// buttonExtract
			// 
			this.buttonExtract.BorderOnHover = false;
			this.buttonExtract.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonExtract.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonExtract.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonExtract.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonExtract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonExtract.Image = null;
			this.buttonExtract.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonExtract.Location = new System.Drawing.Point(14, 154);
			this.buttonExtract.Name = "buttonExtract";
			this.buttonExtract.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonExtract.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonExtract.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonExtract.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonExtract.Size = new System.Drawing.Size(100, 18);
			this.buttonExtract.TabIndex = 150;
			this.buttonExtract.Text = "Extract Images";
			this.buttonExtract.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonExtract.Toggleable = false;
			this.buttonExtract.Toggled = false;
			this.buttonExtract.ButtonPressed += new System.EventHandler(this.ExtractImages);
			// 
			// checkBoxRemapImage
			// 
			this.checkBoxRemapImage.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxRemapImage.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxRemapImage.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxRemapImage.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxRemapImage.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxRemapImage.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxRemapImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxRemapImage.Location = new System.Drawing.Point(163, 105);
			this.checkBoxRemapImage.Name = "checkBoxRemapImage";
			this.checkBoxRemapImage.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxRemapImage.Size = new System.Drawing.Size(116, 11);
			this.checkBoxRemapImage.TabIndex = 149;
			this.checkBoxRemapImage.Text = "Remap Image View";
			this.checkBoxRemapImage.CheckStateChanged += new System.EventHandler(this.RemapImageView);
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
			this.buttonAbout.Location = new System.Drawing.Point(410, 10);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.Size = new System.Drawing.Size(60, 18);
			this.buttonAbout.TabIndex = 148;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.OpenAboutForm);
			// 
			// rctLabel2
			// 
			this.rctLabel2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(14, 16);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel2.Size = new System.Drawing.Size(100, 14);
			this.rctLabel2.TabIndex = 147;
			this.rctLabel2.Text = "Default Directory:";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel1
			// 
			this.rctLabel1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(16, 76);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel1.Size = new System.Drawing.Size(94, 14);
			this.rctLabel1.TabIndex = 146;
			this.rctLabel1.Text = "Objects Per Tick:";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// checkBoxQuickLoad
			// 
			this.checkBoxQuickLoad.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxQuickLoad.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxQuickLoad.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxQuickLoad.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxQuickLoad.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.checkBoxQuickLoad.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxQuickLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxQuickLoad.Location = new System.Drawing.Point(15, 105);
			this.checkBoxQuickLoad.Name = "checkBoxQuickLoad";
			this.checkBoxQuickLoad.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxQuickLoad.Size = new System.Drawing.Size(140, 11);
			this.checkBoxQuickLoad.TabIndex = 142;
			this.checkBoxQuickLoad.Text = "Quick Load Attractions";
			this.checkBoxQuickLoad.CheckStateChanged += new System.EventHandler(this.QuickLoadAttractions);
			// 
			// buttonSaveSettings
			// 
			this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveSettings.BorderOnHover = false;
			this.buttonSaveSettings.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonSaveSettings.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSaveSettings.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSaveSettings.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSaveSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSaveSettings.Image = null;
			this.buttonSaveSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSaveSettings.Location = new System.Drawing.Point(477, 10);
			this.buttonSaveSettings.Name = "buttonSaveSettings";
			this.buttonSaveSettings.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSaveSettings.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSaveSettings.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSaveSettings.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSaveSettings.Size = new System.Drawing.Size(60, 18);
			this.buttonSaveSettings.TabIndex = 140;
			this.buttonSaveSettings.Text = "Save";
			this.buttonSaveSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSaveSettings.Toggleable = false;
			this.buttonSaveSettings.Toggled = false;
			this.buttonSaveSettings.ButtonPressed += new System.EventHandler(this.SaveSettings);
			// 
			// buttonBrowseDefault
			// 
			this.buttonBrowseDefault.BorderOnHover = false;
			this.buttonBrowseDefault.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonBrowseDefault.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseDefault.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseDefault.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowseDefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowseDefault.Image = null;
			this.buttonBrowseDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseDefault.Location = new System.Drawing.Point(118, 13);
			this.buttonBrowseDefault.Name = "buttonBrowseDefault";
			this.buttonBrowseDefault.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowseDefault.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonBrowseDefault.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonBrowseDefault.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonBrowseDefault.Size = new System.Drawing.Size(60, 18);
			this.buttonBrowseDefault.TabIndex = 130;
			this.buttonBrowseDefault.Text = "Browse";
			this.buttonBrowseDefault.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseDefault.Toggleable = false;
			this.buttonBrowseDefault.Toggled = false;
			this.buttonBrowseDefault.ButtonPressed += new System.EventHandler(this.BrowseDefaultDirectory);
			// 
			// numericUpDownObjectsPerTick
			// 
			this.numericUpDownObjectsPerTick.Location = new System.Drawing.Point(114, 72);
			this.numericUpDownObjectsPerTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownObjectsPerTick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownObjectsPerTick.Name = "numericUpDownObjectsPerTick";
			this.numericUpDownObjectsPerTick.Size = new System.Drawing.Size(71, 20);
			this.numericUpDownObjectsPerTick.TabIndex = 128;
			this.toolTips.SetToolTip(this.numericUpDownObjectsPerTick, "Change the amount of objects loaded every 200 milliseconds");
			this.numericUpDownObjectsPerTick.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownObjectsPerTick.ValueChanged += new System.EventHandler(this.ObjectsPerTickChanged);
			// 
			// textBoxDirectory
			// 
			this.textBoxDirectory.Location = new System.Drawing.Point(12, 40);
			this.textBoxDirectory.Name = "textBoxDirectory";
			this.textBoxDirectory.ReadOnly = true;
			this.textBoxDirectory.Size = new System.Drawing.Size(509, 20);
			this.textBoxDirectory.TabIndex = 1;
			// 
			// tabGroupWater
			// 
			this.tabGroupWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupWater.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupWater.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader63});
			this.tabGroupWater.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupWater.FullRowSelect = true;
			this.tabGroupWater.HideSelection = false;
			this.tabGroupWater.Location = new System.Drawing.Point(1, 1);
			this.tabGroupWater.Name = "tabGroupWater";
			this.tabGroupWater.OwnerDraw = true;
			this.tabGroupWater.Size = new System.Drawing.Size(545, 359);
			this.tabGroupWater.SmallImageList = this.imageListFlags;
			this.tabGroupWater.TabIndex = 132;
			this.tabGroupWater.TabStop = false;
			this.tabGroupWater.UseCompatibleStateImageBehavior = false;
			this.tabGroupWater.View = System.Windows.Forms.View.Details;
			this.tabGroupWater.Visible = false;
			this.tabGroupWater.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupWater.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupWater.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupWater.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupWater.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupWater.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupWater.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader46
			// 
			this.columnHeader46.Text = "";
			this.columnHeader46.Width = 32;
			// 
			// columnHeader47
			// 
			this.columnHeader47.Text = "Source";
			this.columnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader47.Width = 59;
			// 
			// columnHeader48
			// 
			this.columnHeader48.Text = "File";
			this.columnHeader48.Width = 110;
			// 
			// columnHeader49
			// 
			this.columnHeader49.Text = "Name";
			this.columnHeader49.Width = 142;
			// 
			// columnHeader50
			// 
			this.columnHeader50.Text = "Type";
			this.columnHeader50.Width = 100;
			// 
			// columnHeader63
			// 
			this.columnHeader63.Text = "Subtype";
			this.columnHeader63.Width = 80;
			// 
			// tabGroupParkEntrances
			// 
			this.tabGroupParkEntrances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupParkEntrances.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupParkEntrances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader57});
			this.tabGroupParkEntrances.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupParkEntrances.FullRowSelect = true;
			this.tabGroupParkEntrances.HideSelection = false;
			this.tabGroupParkEntrances.Location = new System.Drawing.Point(1, 1);
			this.tabGroupParkEntrances.Name = "tabGroupParkEntrances";
			this.tabGroupParkEntrances.OwnerDraw = true;
			this.tabGroupParkEntrances.Size = new System.Drawing.Size(545, 359);
			this.tabGroupParkEntrances.SmallImageList = this.imageListFlags;
			this.tabGroupParkEntrances.TabIndex = 131;
			this.tabGroupParkEntrances.TabStop = false;
			this.tabGroupParkEntrances.UseCompatibleStateImageBehavior = false;
			this.tabGroupParkEntrances.View = System.Windows.Forms.View.Details;
			this.tabGroupParkEntrances.Visible = false;
			this.tabGroupParkEntrances.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupParkEntrances.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupParkEntrances.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupParkEntrances.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupParkEntrances.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupParkEntrances.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupParkEntrances.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader41
			// 
			this.columnHeader41.Text = "";
			this.columnHeader41.Width = 32;
			// 
			// columnHeader42
			// 
			this.columnHeader42.Text = "Source";
			this.columnHeader42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader42.Width = 59;
			// 
			// columnHeader43
			// 
			this.columnHeader43.Text = "File";
			this.columnHeader43.Width = 110;
			// 
			// columnHeader44
			// 
			this.columnHeader44.Text = "Name";
			this.columnHeader44.Width = 142;
			// 
			// columnHeader45
			// 
			this.columnHeader45.Text = "Type";
			this.columnHeader45.Width = 100;
			// 
			// columnHeader57
			// 
			this.columnHeader57.Text = "Subtype";
			this.columnHeader57.Width = 80;
			// 
			// tabGroupSceneryGroups
			// 
			this.tabGroupSceneryGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupSceneryGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupSceneryGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader61});
			this.tabGroupSceneryGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupSceneryGroups.FullRowSelect = true;
			this.tabGroupSceneryGroups.HideSelection = false;
			this.tabGroupSceneryGroups.Location = new System.Drawing.Point(1, 1);
			this.tabGroupSceneryGroups.Name = "tabGroupSceneryGroups";
			this.tabGroupSceneryGroups.OwnerDraw = true;
			this.tabGroupSceneryGroups.Size = new System.Drawing.Size(545, 359);
			this.tabGroupSceneryGroups.SmallImageList = this.imageListFlags;
			this.tabGroupSceneryGroups.TabIndex = 130;
			this.tabGroupSceneryGroups.TabStop = false;
			this.tabGroupSceneryGroups.UseCompatibleStateImageBehavior = false;
			this.tabGroupSceneryGroups.View = System.Windows.Forms.View.Details;
			this.tabGroupSceneryGroups.Visible = false;
			this.tabGroupSceneryGroups.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupSceneryGroups.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupSceneryGroups.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupSceneryGroups.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupSceneryGroups.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupSceneryGroups.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupSceneryGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader36
			// 
			this.columnHeader36.Text = "";
			this.columnHeader36.Width = 32;
			// 
			// columnHeader37
			// 
			this.columnHeader37.Text = "Source";
			this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader37.Width = 59;
			// 
			// columnHeader38
			// 
			this.columnHeader38.Text = "File";
			this.columnHeader38.Width = 110;
			// 
			// columnHeader39
			// 
			this.columnHeader39.Text = "Name";
			this.columnHeader39.Width = 142;
			// 
			// columnHeader40
			// 
			this.columnHeader40.Text = "Type";
			this.columnHeader40.Width = 100;
			// 
			// columnHeader61
			// 
			this.columnHeader61.Text = "Subtype";
			this.columnHeader61.Width = 80;
			// 
			// tabGroupPathAdditions
			// 
			this.tabGroupPathAdditions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupPathAdditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupPathAdditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader58});
			this.tabGroupPathAdditions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupPathAdditions.FullRowSelect = true;
			this.tabGroupPathAdditions.HideSelection = false;
			this.tabGroupPathAdditions.Location = new System.Drawing.Point(1, 1);
			this.tabGroupPathAdditions.Name = "tabGroupPathAdditions";
			this.tabGroupPathAdditions.OwnerDraw = true;
			this.tabGroupPathAdditions.Size = new System.Drawing.Size(545, 359);
			this.tabGroupPathAdditions.SmallImageList = this.imageListFlags;
			this.tabGroupPathAdditions.TabIndex = 129;
			this.tabGroupPathAdditions.TabStop = false;
			this.tabGroupPathAdditions.UseCompatibleStateImageBehavior = false;
			this.tabGroupPathAdditions.View = System.Windows.Forms.View.Details;
			this.tabGroupPathAdditions.Visible = false;
			this.tabGroupPathAdditions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupPathAdditions.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupPathAdditions.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupPathAdditions.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupPathAdditions.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupPathAdditions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupPathAdditions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader31
			// 
			this.columnHeader31.Text = "";
			this.columnHeader31.Width = 32;
			// 
			// columnHeader32
			// 
			this.columnHeader32.Text = "Source";
			this.columnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader32.Width = 59;
			// 
			// columnHeader33
			// 
			this.columnHeader33.Text = "File";
			this.columnHeader33.Width = 110;
			// 
			// columnHeader34
			// 
			this.columnHeader34.Text = "Name";
			this.columnHeader34.Width = 142;
			// 
			// columnHeader35
			// 
			this.columnHeader35.Text = "Type";
			this.columnHeader35.Width = 100;
			// 
			// columnHeader58
			// 
			this.columnHeader58.Text = "Subtype";
			this.columnHeader58.Width = 80;
			// 
			// tabGroupPaths
			// 
			this.tabGroupPaths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupPaths.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader59});
			this.tabGroupPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupPaths.FullRowSelect = true;
			this.tabGroupPaths.HideSelection = false;
			this.tabGroupPaths.Location = new System.Drawing.Point(1, 1);
			this.tabGroupPaths.Name = "tabGroupPaths";
			this.tabGroupPaths.OwnerDraw = true;
			this.tabGroupPaths.Size = new System.Drawing.Size(545, 359);
			this.tabGroupPaths.SmallImageList = this.imageListFlags;
			this.tabGroupPaths.TabIndex = 127;
			this.tabGroupPaths.TabStop = false;
			this.tabGroupPaths.UseCompatibleStateImageBehavior = false;
			this.tabGroupPaths.View = System.Windows.Forms.View.Details;
			this.tabGroupPaths.Visible = false;
			this.tabGroupPaths.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupPaths.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupPaths.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupPaths.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupPaths.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupPaths.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupPaths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader21
			// 
			this.columnHeader21.Text = "";
			this.columnHeader21.Width = 32;
			// 
			// columnHeader22
			// 
			this.columnHeader22.Text = "Source";
			this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader22.Width = 59;
			// 
			// columnHeader23
			// 
			this.columnHeader23.Text = "File";
			this.columnHeader23.Width = 110;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "Name";
			this.columnHeader24.Width = 142;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "Type";
			this.columnHeader25.Width = 100;
			// 
			// columnHeader59
			// 
			this.columnHeader59.Text = "Subtype";
			this.columnHeader59.Width = 80;
			// 
			// tabGroupSigns
			// 
			this.tabGroupSigns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupSigns.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupSigns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader60});
			this.tabGroupSigns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupSigns.FullRowSelect = true;
			this.tabGroupSigns.HideSelection = false;
			this.tabGroupSigns.Location = new System.Drawing.Point(1, 1);
			this.tabGroupSigns.Name = "tabGroupSigns";
			this.tabGroupSigns.OwnerDraw = true;
			this.tabGroupSigns.Size = new System.Drawing.Size(545, 359);
			this.tabGroupSigns.SmallImageList = this.imageListFlags;
			this.tabGroupSigns.TabIndex = 128;
			this.tabGroupSigns.TabStop = false;
			this.tabGroupSigns.UseCompatibleStateImageBehavior = false;
			this.tabGroupSigns.View = System.Windows.Forms.View.Details;
			this.tabGroupSigns.Visible = false;
			this.tabGroupSigns.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupSigns.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupSigns.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupSigns.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupSigns.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupSigns.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupSigns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader26
			// 
			this.columnHeader26.Text = "";
			this.columnHeader26.Width = 32;
			// 
			// columnHeader27
			// 
			this.columnHeader27.Text = "Source";
			this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader27.Width = 59;
			// 
			// columnHeader28
			// 
			this.columnHeader28.Text = "File";
			this.columnHeader28.Width = 110;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "Name";
			this.columnHeader29.Width = 142;
			// 
			// columnHeader30
			// 
			this.columnHeader30.Text = "Type";
			this.columnHeader30.Width = 100;
			// 
			// columnHeader60
			// 
			this.columnHeader60.Text = "Subtype";
			this.columnHeader60.Width = 80;
			// 
			// tabGroupWalls
			// 
			this.tabGroupWalls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupWalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupWalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFlag,
            this.columnHeaderSource,
            this.columnHeaderFile,
            this.columnHeaderName,
            this.columnHeaderType,
            this.columnHeaderSubtype});
			this.tabGroupWalls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupWalls.FullRowSelect = true;
			this.tabGroupWalls.HideSelection = false;
			this.tabGroupWalls.Location = new System.Drawing.Point(1, 1);
			this.tabGroupWalls.Name = "tabGroupWalls";
			this.tabGroupWalls.OwnerDraw = true;
			this.tabGroupWalls.Size = new System.Drawing.Size(545, 359);
			this.tabGroupWalls.SmallImageList = this.imageListFlags;
			this.tabGroupWalls.TabIndex = 122;
			this.tabGroupWalls.TabStop = false;
			this.tabGroupWalls.UseCompatibleStateImageBehavior = false;
			this.tabGroupWalls.View = System.Windows.Forms.View.Details;
			this.tabGroupWalls.Visible = false;
			this.tabGroupWalls.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupWalls.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupWalls.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupWalls.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupWalls.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupWalls.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupWalls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeaderFlag
			// 
			this.columnHeaderFlag.Text = "";
			this.columnHeaderFlag.Width = 32;
			// 
			// columnHeaderSource
			// 
			this.columnHeaderSource.Text = "Source";
			this.columnHeaderSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderSource.Width = 59;
			// 
			// columnHeaderFile
			// 
			this.columnHeaderFile.Text = "File";
			this.columnHeaderFile.Width = 110;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 142;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 100;
			// 
			// columnHeaderSubtype
			// 
			this.columnHeaderSubtype.Text = "Subtype";
			this.columnHeaderSubtype.Width = 80;
			// 
			// tabGroupLargeScenery
			// 
			this.tabGroupLargeScenery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupLargeScenery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupLargeScenery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader56});
			this.tabGroupLargeScenery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupLargeScenery.FullRowSelect = true;
			this.tabGroupLargeScenery.HideSelection = false;
			this.tabGroupLargeScenery.Location = new System.Drawing.Point(1, 1);
			this.tabGroupLargeScenery.Name = "tabGroupLargeScenery";
			this.tabGroupLargeScenery.OwnerDraw = true;
			this.tabGroupLargeScenery.Size = new System.Drawing.Size(545, 359);
			this.tabGroupLargeScenery.SmallImageList = this.imageListFlags;
			this.tabGroupLargeScenery.TabIndex = 126;
			this.tabGroupLargeScenery.TabStop = false;
			this.tabGroupLargeScenery.UseCompatibleStateImageBehavior = false;
			this.tabGroupLargeScenery.View = System.Windows.Forms.View.Details;
			this.tabGroupLargeScenery.Visible = false;
			this.tabGroupLargeScenery.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupLargeScenery.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupLargeScenery.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupLargeScenery.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupLargeScenery.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupLargeScenery.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupLargeScenery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
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
			// tabGroupSmallScenery
			// 
			this.tabGroupSmallScenery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupSmallScenery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupSmallScenery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader62});
			this.tabGroupSmallScenery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupSmallScenery.FullRowSelect = true;
			this.tabGroupSmallScenery.HideSelection = false;
			this.tabGroupSmallScenery.Location = new System.Drawing.Point(1, 1);
			this.tabGroupSmallScenery.Name = "tabGroupSmallScenery";
			this.tabGroupSmallScenery.OwnerDraw = true;
			this.tabGroupSmallScenery.Size = new System.Drawing.Size(545, 359);
			this.tabGroupSmallScenery.SmallImageList = this.imageListFlags;
			this.tabGroupSmallScenery.TabIndex = 125;
			this.tabGroupSmallScenery.TabStop = false;
			this.tabGroupSmallScenery.UseCompatibleStateImageBehavior = false;
			this.tabGroupSmallScenery.View = System.Windows.Forms.View.Details;
			this.tabGroupSmallScenery.Visible = false;
			this.tabGroupSmallScenery.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupSmallScenery.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupSmallScenery.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupSmallScenery.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupSmallScenery.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupSmallScenery.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupSmallScenery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "";
			this.columnHeader11.Width = 32;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Source";
			this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader12.Width = 59;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "File";
			this.columnHeader13.Width = 110;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Name";
			this.columnHeader14.Width = 142;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Type";
			this.columnHeader15.Width = 100;
			// 
			// columnHeader62
			// 
			this.columnHeader62.Text = "Subtype";
			this.columnHeader62.Width = 80;
			// 
			// tabGroupAttractions
			// 
			this.tabGroupAttractions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupAttractions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupAttractions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader55,
            this.columnHeader64});
			this.tabGroupAttractions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupAttractions.FullRowSelect = true;
			this.tabGroupAttractions.HideSelection = false;
			this.tabGroupAttractions.Location = new System.Drawing.Point(1, 1);
			this.tabGroupAttractions.Name = "tabGroupAttractions";
			this.tabGroupAttractions.OwnerDraw = true;
			this.tabGroupAttractions.Size = new System.Drawing.Size(545, 359);
			this.tabGroupAttractions.SmallImageList = this.imageListFlags;
			this.tabGroupAttractions.TabIndex = 124;
			this.tabGroupAttractions.TabStop = false;
			this.tabGroupAttractions.UseCompatibleStateImageBehavior = false;
			this.tabGroupAttractions.View = System.Windows.Forms.View.Details;
			this.tabGroupAttractions.Visible = false;
			this.tabGroupAttractions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupAttractions.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupAttractions.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupAttractions.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupAttractions.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupAttractions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupAttractions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "";
			this.columnHeader6.Width = 32;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Source";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 59;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "File";
			this.columnHeader8.Width = 110;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Name";
			this.columnHeader9.Width = 142;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Type";
			this.columnHeader10.Width = 100;
			// 
			// columnHeader55
			// 
			this.columnHeader55.Text = "Ride Type";
			this.columnHeader55.Width = 80;
			// 
			// columnHeader64
			// 
			this.columnHeader64.Text = "Track Type";
			this.columnHeader64.Width = 160;
			// 
			// tabGroupAll
			// 
			this.tabGroupAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader54});
			this.tabGroupAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupAll.FullRowSelect = true;
			this.tabGroupAll.HideSelection = false;
			this.tabGroupAll.Location = new System.Drawing.Point(1, 1);
			this.tabGroupAll.Name = "tabGroupAll";
			this.tabGroupAll.OwnerDraw = true;
			this.tabGroupAll.Size = new System.Drawing.Size(545, 359);
			this.tabGroupAll.SmallImageList = this.imageListFlags;
			this.tabGroupAll.TabIndex = 123;
			this.tabGroupAll.TabStop = false;
			this.tabGroupAll.UseCompatibleStateImageBehavior = false;
			this.tabGroupAll.View = System.Windows.Forms.View.Details;
			this.tabGroupAll.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnSort);
			this.tabGroupAll.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupAll.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupAll.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.tabGroupAll.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ObjectDrag);
			this.tabGroupAll.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ObjectChanged);
			this.tabGroupAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabGroupDeleteSelection);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 32;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Source";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 59;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "File";
			this.columnHeader3.Width = 110;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Name";
			this.columnHeader4.Width = 142;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Type";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader54
			// 
			this.columnHeader54.Text = "Subtype";
			this.columnHeader54.Width = 80;
			// 
			// tabGroupInfo
			// 
			this.tabGroupInfo.AutoArrange = false;
			this.tabGroupInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tabGroupInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53});
			this.tabGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabGroupInfo.FullRowSelect = true;
			listViewGroup1.Header = "General";
			listViewGroup1.Name = "general";
			listViewGroup2.Header = "Graphics";
			listViewGroup2.Name = "graphics";
			listViewGroup3.Header = "String Table";
			listViewGroup3.Name = "strings";
			listViewGroup4.Header = "Header";
			listViewGroup4.Name = "header";
			listViewGroup5.Header = "Header 1";
			listViewGroup5.Name = "header1";
			listViewGroup6.Header = "Header 2";
			listViewGroup6.Name = "header2";
			listViewGroup7.Header = "Header 3";
			listViewGroup7.Name = "header3";
			listViewGroup8.Header = "Header 4";
			listViewGroup8.Name = "header4";
			listViewGroup9.Header = "Group Info";
			listViewGroup9.Name = "groupInfo";
			listViewGroup10.Header = "Optional";
			listViewGroup10.Name = "optional";
			listViewGroup11.Header = "Optional";
			listViewGroup11.Name = "optional1";
			listViewGroup12.Header = "Optional";
			listViewGroup12.Name = "optional2";
			this.tabGroupInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12});
			this.tabGroupInfo.Location = new System.Drawing.Point(1, 1);
			this.tabGroupInfo.MultiSelect = false;
			this.tabGroupInfo.Name = "tabGroupInfo";
			this.tabGroupInfo.OwnerDraw = true;
			this.tabGroupInfo.Size = new System.Drawing.Size(545, 359);
			this.tabGroupInfo.TabIndex = 133;
			this.tabGroupInfo.TabStop = false;
			this.tabGroupInfo.UseCompatibleStateImageBehavior = false;
			this.tabGroupInfo.View = System.Windows.Forms.View.Details;
			this.tabGroupInfo.Visible = false;
			this.tabGroupInfo.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.tabGroupInfo.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.tabGroupInfo.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			// 
			// columnHeader51
			// 
			this.columnHeader51.Text = " ";
			this.columnHeader51.Width = 32;
			// 
			// columnHeader52
			// 
			this.columnHeader52.Text = "Name";
			this.columnHeader52.Width = 116;
			// 
			// columnHeader53
			// 
			this.columnHeader53.Text = "Value";
			this.columnHeader53.Width = 387;
			// 
			// buttonScan
			// 
			this.buttonScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonScan.BorderOnHover = false;
			this.buttonScan.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonScan.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonScan.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonScan.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonScan.Image = null;
			this.buttonScan.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonScan.Location = new System.Drawing.Point(486, 9);
			this.buttonScan.Name = "buttonScan";
			this.buttonScan.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonScan.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonScan.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonScan.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonScan.Size = new System.Drawing.Size(60, 18);
			this.buttonScan.TabIndex = 131;
			this.buttonScan.Text = "Scan";
			this.buttonScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonScan.Toggleable = false;
			this.buttonScan.Toggled = false;
			this.buttonScan.ButtonPressed += new System.EventHandler(this.StartScan);
			// 
			// rctPanel2
			// 
			this.rctPanel2.Controls.Add(this.tabGroupSettings);
			this.rctPanel2.Controls.Add(this.tabGroupInfo);
			this.rctPanel2.Controls.Add(this.tabGroupWater);
			this.rctPanel2.Controls.Add(this.tabGroupParkEntrances);
			this.rctPanel2.Controls.Add(this.tabGroupSceneryGroups);
			this.rctPanel2.Controls.Add(this.tabGroupPathAdditions);
			this.rctPanel2.Controls.Add(this.tabGroupSigns);
			this.rctPanel2.Controls.Add(this.tabGroupPaths);
			this.rctPanel2.Controls.Add(this.tabGroupLargeScenery);
			this.rctPanel2.Controls.Add(this.tabGroupSmallScenery);
			this.rctPanel2.Controls.Add(this.tabGroupAttractions);
			this.rctPanel2.Controls.Add(this.tabGroupAll);
			this.rctPanel2.Controls.Add(this.tabGroupWalls);
			this.rctPanel2.Controls.Add(this.tabGroupInfoOld);
			this.rctPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel2.Location = new System.Drawing.Point(3, 3);
			this.rctPanel2.Name = "rctPanel2";
			this.rctPanel2.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel2.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctPanel2.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel2.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel2.Size = new System.Drawing.Size(547, 361);
			this.rctPanel2.TabIndex = 141;
			// 
			// tabGroupInfoOld
			// 
			this.tabGroupInfoOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.tabGroupInfoOld.Controls.Add(this.label4);
			this.tabGroupInfoOld.Controls.Add(this.label2);
			this.tabGroupInfoOld.Controls.Add(this.infoImageOffset);
			this.tabGroupInfoOld.Controls.Add(this.infoImageSize);
			this.tabGroupInfoOld.Controls.Add(this.label1);
			this.tabGroupInfoOld.Controls.Add(this.infoHeight);
			this.tabGroupInfoOld.Controls.Add(this.label8);
			this.tabGroupInfoOld.Controls.Add(this.label6);
			this.tabGroupInfoOld.Controls.Add(this.label5);
			this.tabGroupInfoOld.Controls.Add(this.label7);
			this.tabGroupInfoOld.Controls.Add(this.infoFrames);
			this.tabGroupInfoOld.Controls.Add(this.infoFlags);
			this.tabGroupInfoOld.Controls.Add(this.infoName);
			this.tabGroupInfoOld.Controls.Add(this.infoFileName);
			this.tabGroupInfoOld.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGroupInfoOld.Location = new System.Drawing.Point(1, 1);
			this.tabGroupInfoOld.Name = "tabGroupInfoOld";
			this.tabGroupInfoOld.Size = new System.Drawing.Size(545, 359);
			this.tabGroupInfoOld.TabIndex = 21;
			this.tabGroupInfoOld.TabStop = false;
			this.tabGroupInfoOld.Text = "Information";
			this.tabGroupInfoOld.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "Image Offset:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "Image Size:";
			// 
			// infoImageOffset
			// 
			this.infoImageOffset.AutoSize = true;
			this.infoImageOffset.Location = new System.Drawing.Point(79, 130);
			this.infoImageOffset.Name = "infoImageOffset";
			this.infoImageOffset.Size = new System.Drawing.Size(82, 13);
			this.infoImageOffset.TabIndex = 32;
			this.infoImageOffset.Text = "InfoImageOffset";
			// 
			// infoImageSize
			// 
			this.infoImageSize.AutoSize = true;
			this.infoImageSize.Location = new System.Drawing.Point(79, 111);
			this.infoImageSize.Name = "infoImageSize";
			this.infoImageSize.Size = new System.Drawing.Size(74, 13);
			this.infoImageSize.TabIndex = 32;
			this.infoImageSize.Text = "InfoImageSize";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "Height:";
			// 
			// infoHeight
			// 
			this.infoHeight.AutoSize = true;
			this.infoHeight.Location = new System.Drawing.Point(79, 93);
			this.infoHeight.Name = "infoHeight";
			this.infoHeight.Size = new System.Drawing.Size(56, 13);
			this.infoHeight.TabIndex = 30;
			this.infoHeight.Text = "InfoHeight";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 161);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "Flags:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 47);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 27;
			this.label6.Text = "Name:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "File Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 75);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "Frames:";
			// 
			// infoFrames
			// 
			this.infoFrames.AutoSize = true;
			this.infoFrames.Location = new System.Drawing.Point(79, 75);
			this.infoFrames.Name = "infoFrames";
			this.infoFrames.Size = new System.Drawing.Size(59, 13);
			this.infoFrames.TabIndex = 26;
			this.infoFrames.Text = "InfoFrames";
			// 
			// infoFlags
			// 
			this.infoFlags.AutoSize = true;
			this.infoFlags.Location = new System.Drawing.Point(79, 161);
			this.infoFlags.Name = "infoFlags";
			this.infoFlags.Size = new System.Drawing.Size(50, 13);
			this.infoFlags.TabIndex = 25;
			this.infoFlags.Text = "InfoFlags";
			// 
			// infoName
			// 
			this.infoName.AutoSize = true;
			this.infoName.Location = new System.Drawing.Point(79, 47);
			this.infoName.Name = "infoName";
			this.infoName.Size = new System.Drawing.Size(53, 13);
			this.infoName.TabIndex = 25;
			this.infoName.Text = "InfoName";
			// 
			// infoFileName
			// 
			this.infoFileName.AutoSize = true;
			this.infoFileName.Location = new System.Drawing.Point(79, 28);
			this.infoFileName.Name = "infoFileName";
			this.infoFileName.Size = new System.Drawing.Size(69, 13);
			this.infoFileName.TabIndex = 24;
			this.infoFileName.Text = "InfoFileName";
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
			this.statusBar.Size = new System.Drawing.Size(761, 26);
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
			// panelColorPalette
			// 
			this.panelColorPalette.BackgroundImage = global::RCTDataEditor.Properties.Resources.ColorPalette1;
			this.panelColorPalette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panelColorPalette.Location = new System.Drawing.Point(100, 345);
			this.panelColorPalette.Margin = new System.Windows.Forms.Padding(0);
			this.panelColorPalette.Name = "panelColorPalette";
			this.panelColorPalette.Padding = new System.Windows.Forms.Padding(2);
			this.panelColorPalette.Size = new System.Drawing.Size(100, 52);
			this.panelColorPalette.TabIndex = 33;
			this.panelColorPalette.Visible = false;
			// 
			// objectView
			// 
			this.objectView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.objectView.Cursor = System.Windows.Forms.Cursors.Default;
			this.objectView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objectView.ErrorImage = global::RCTDataEditor.Properties.Resources.MissingImagesError;
			this.objectView.Location = new System.Drawing.Point(1, 1);
			this.objectView.Margin = new System.Windows.Forms.Padding(0);
			this.objectView.Name = "objectView";
			this.objectView.Size = new System.Drawing.Size(190, 254);
			this.objectView.TabIndex = 9;
			this.objectView.TabStop = false;
			// 
			// buttonNextObject
			// 
			this.buttonNextObject.BorderOnHover = true;
			this.buttonNextObject.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonNextObject.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextObject.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonNextObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonNextObject.Image = global::RCTDataEditor.Properties.Resources.ButtonRight;
			this.buttonNextObject.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextObject.Location = new System.Drawing.Point(134, 266);
			this.buttonNextObject.Name = "buttonNextObject";
			this.buttonNextObject.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNextObject.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNextObject.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextObject.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextObject.Size = new System.Drawing.Size(20, 24);
			this.buttonNextObject.TabIndex = 138;
			this.buttonNextObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextObject.Toggleable = false;
			this.buttonNextObject.Toggled = false;
			this.buttonNextObject.ButtonPressed += new System.EventHandler(this.NextObject);
			// 
			// buttonElevate
			// 
			this.buttonElevate.BorderOnHover = true;
			this.buttonElevate.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonElevate.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonElevate.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonElevate.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonElevate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonElevate.Image = global::RCTDataEditor.Properties.Resources.ButtonElevate;
			this.buttonElevate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonElevate.Location = new System.Drawing.Point(109, 266);
			this.buttonElevate.Name = "buttonElevate";
			this.buttonElevate.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonElevate.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonElevate.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonElevate.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonElevate.Size = new System.Drawing.Size(24, 24);
			this.buttonElevate.TabIndex = 134;
			this.buttonElevate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonElevate.Toggleable = false;
			this.buttonElevate.Toggled = false;
			this.buttonElevate.ButtonPressed += new System.EventHandler(this.ChangeElevation);
			// 
			// buttonPreviousObject
			// 
			this.buttonPreviousObject.BorderOnHover = true;
			this.buttonPreviousObject.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPreviousObject.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousObject.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousObject.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPreviousObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPreviousObject.Image = global::RCTDataEditor.Properties.Resources.ButtonLeft;
			this.buttonPreviousObject.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousObject.Location = new System.Drawing.Point(13, 266);
			this.buttonPreviousObject.Name = "buttonPreviousObject";
			this.buttonPreviousObject.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPreviousObject.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPreviousObject.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousObject.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousObject.Size = new System.Drawing.Size(20, 24);
			this.buttonPreviousObject.TabIndex = 137;
			this.buttonPreviousObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousObject.Toggleable = false;
			this.buttonPreviousObject.Toggled = false;
			this.buttonPreviousObject.ButtonPressed += new System.EventHandler(this.PreviousObject);
			// 
			// buttonCorner
			// 
			this.buttonCorner.BorderOnHover = true;
			this.buttonCorner.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonCorner.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonCorner.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonCorner.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonCorner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonCorner.Image = global::RCTDataEditor.Properties.Resources.ButtonCorner;
			this.buttonCorner.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCorner.Location = new System.Drawing.Point(84, 266);
			this.buttonCorner.Name = "buttonCorner";
			this.buttonCorner.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonCorner.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonCorner.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonCorner.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonCorner.Size = new System.Drawing.Size(24, 24);
			this.buttonCorner.TabIndex = 133;
			this.buttonCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCorner.Toggleable = false;
			this.buttonCorner.Toggled = false;
			this.buttonCorner.ButtonPressed += new System.EventHandler(this.RotateCorner);
			// 
			// buttonSlope
			// 
			this.buttonSlope.BorderOnHover = true;
			this.buttonSlope.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonSlope.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSlope.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSlope.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSlope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSlope.Image = global::RCTDataEditor.Properties.Resources.ButtonSlope;
			this.buttonSlope.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSlope.Location = new System.Drawing.Point(59, 266);
			this.buttonSlope.Name = "buttonSlope";
			this.buttonSlope.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSlope.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSlope.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSlope.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSlope.Size = new System.Drawing.Size(24, 24);
			this.buttonSlope.TabIndex = 132;
			this.buttonSlope.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSlope.Toggleable = false;
			this.buttonSlope.Toggled = false;
			this.buttonSlope.ButtonPressed += new System.EventHandler(this.RotateSlope);
			// 
			// buttonPreviousFrame
			// 
			this.buttonPreviousFrame.BorderOnHover = true;
			this.buttonPreviousFrame.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPreviousFrame.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousFrame.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousFrame.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPreviousFrame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPreviousFrame.Image = global::RCTDataEditor.Properties.Resources.ButtonBack;
			this.buttonPreviousFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousFrame.Location = new System.Drawing.Point(13, 297);
			this.buttonPreviousFrame.Name = "buttonPreviousFrame";
			this.buttonPreviousFrame.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPreviousFrame.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPreviousFrame.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPreviousFrame.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPreviousFrame.Size = new System.Drawing.Size(24, 24);
			this.buttonPreviousFrame.TabIndex = 135;
			this.buttonPreviousFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPreviousFrame.Toggleable = false;
			this.buttonPreviousFrame.Toggled = false;
			this.buttonPreviousFrame.ButtonPressed += new System.EventHandler(this.PreviousFrame);
			// 
			// buttonRotate
			// 
			this.buttonRotate.BorderOnHover = true;
			this.buttonRotate.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRotate.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonRotate.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonRotate.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonRotate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonRotate.Image = global::RCTDataEditor.Properties.Resources.ButtonRotate;
			this.buttonRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRotate.Location = new System.Drawing.Point(34, 266);
			this.buttonRotate.Name = "buttonRotate";
			this.buttonRotate.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonRotate.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonRotate.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonRotate.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonRotate.Size = new System.Drawing.Size(24, 24);
			this.buttonRotate.TabIndex = 131;
			this.buttonRotate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRotate.Toggleable = false;
			this.buttonRotate.Toggled = false;
			this.buttonRotate.ButtonPressed += new System.EventHandler(this.RotateObject);
			// 
			// buttonNextFrame
			// 
			this.buttonNextFrame.BorderOnHover = true;
			this.buttonNextFrame.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonNextFrame.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextFrame.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextFrame.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonNextFrame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonNextFrame.Image = global::RCTDataEditor.Properties.Resources.ButtonForward;
			this.buttonNextFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextFrame.Location = new System.Drawing.Point(38, 297);
			this.buttonNextFrame.Name = "buttonNextFrame";
			this.buttonNextFrame.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNextFrame.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNextFrame.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNextFrame.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNextFrame.Size = new System.Drawing.Size(24, 24);
			this.buttonNextFrame.TabIndex = 136;
			this.buttonNextFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextFrame.Toggleable = false;
			this.buttonNextFrame.Toggled = false;
			this.buttonNextFrame.ButtonPressed += new System.EventHandler(this.NextFrame);
			// 
			// buttonRemap1
			// 
			this.buttonRemap1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap1.FlatAppearance.BorderSize = 0;
			this.buttonRemap1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemap1.ImageIndex = 0;
			this.buttonRemap1.ImageList = this.imageListPaletteButton;
			this.buttonRemap1.Location = new System.Drawing.Point(159, 271);
			this.buttonRemap1.Name = "buttonRemap1";
			this.buttonRemap1.Size = new System.Drawing.Size(13, 13);
			this.buttonRemap1.TabIndex = 34;
			this.buttonRemap1.TabStop = false;
			this.buttonRemap1.UseVisualStyleBackColor = true;
			this.buttonRemap1.Click += new System.EventHandler(this.ChangeRemap);
			this.buttonRemap1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
			this.buttonRemap1.MouseLeave += new System.EventHandler(this.ButtonLeave);
			this.buttonRemap1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonHover);
			this.buttonRemap1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
			// 
			// buttonRemap2
			// 
			this.buttonRemap2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap2.FlatAppearance.BorderSize = 0;
			this.buttonRemap2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemap2.ImageIndex = 0;
			this.buttonRemap2.ImageList = this.imageListPaletteButton;
			this.buttonRemap2.Location = new System.Drawing.Point(171, 271);
			this.buttonRemap2.Name = "buttonRemap2";
			this.buttonRemap2.Size = new System.Drawing.Size(13, 13);
			this.buttonRemap2.TabIndex = 35;
			this.buttonRemap2.TabStop = false;
			this.buttonRemap2.UseVisualStyleBackColor = true;
			this.buttonRemap2.Click += new System.EventHandler(this.ChangeRemap);
			this.buttonRemap2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
			this.buttonRemap2.MouseLeave += new System.EventHandler(this.ButtonLeave);
			this.buttonRemap2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonHover);
			this.buttonRemap2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
			// 
			// buttonRemap3
			// 
			this.buttonRemap3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap3.FlatAppearance.BorderSize = 0;
			this.buttonRemap3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonRemap3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemap3.ImageIndex = 0;
			this.buttonRemap3.ImageList = this.imageListPaletteButton;
			this.buttonRemap3.Location = new System.Drawing.Point(183, 271);
			this.buttonRemap3.Name = "buttonRemap3";
			this.buttonRemap3.Size = new System.Drawing.Size(13, 13);
			this.buttonRemap3.TabIndex = 36;
			this.buttonRemap3.TabStop = false;
			this.buttonRemap3.UseVisualStyleBackColor = true;
			this.buttonRemap3.Click += new System.EventHandler(this.ChangeRemap);
			this.buttonRemap3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
			this.buttonRemap3.MouseLeave += new System.EventHandler(this.ButtonLeave);
			this.buttonRemap3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonHover);
			this.buttonRemap3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
			// 
			// tabInfo
			// 
			this.tabInfo.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabInfo.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabInfo.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabInfo.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabInfo.Image = global::RCTDataEditor.Properties.Resources.TabInfo;
			this.tabInfo.Location = new System.Drawing.Point(4, 5);
			this.tabInfo.Name = "tabInfo";
			this.tabInfo.NextTabButton = this.tabAll;
			this.tabInfo.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabInfo.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabInfo.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabInfo.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabInfo.PreviousTabButton = null;
			this.tabInfo.Size = new System.Drawing.Size(31, 27);
			this.tabInfo.TabControlIndex = ((uint)(0u));
			this.tabInfo.TabIndex = 126;
			this.tabInfo.TabPage = this.tabGroupInfo;
			this.tabInfo.Text = "rctTabButton1";
			this.tabInfo.Toggled = false;
			this.tabInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabAll
			// 
			this.tabAll.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabAll.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabAll.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabAll.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabAll.Image = global::RCTDataEditor.Properties.Resources.TabAll;
			this.tabAll.Location = new System.Drawing.Point(35, 5);
			this.tabAll.Name = "tabAll";
			this.tabAll.NextTabButton = this.tabAttractions;
			this.tabAll.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabAll.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabAll.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabAll.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabAll.PreviousTabButton = this.tabInfo;
			this.tabAll.Size = new System.Drawing.Size(31, 27);
			this.tabAll.TabControlIndex = ((uint)(1u));
			this.tabAll.TabIndex = 127;
			this.tabAll.TabPage = this.tabGroupAll;
			this.tabAll.Text = "rctTabButton1";
			this.tabAll.Toggled = true;
			this.tabAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabAttractions
			// 
			this.tabAttractions.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabAttractions.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabAttractions.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabAttractions.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabAttractions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabAttractions.Image = global::RCTDataEditor.Properties.Resources.TabAttractions;
			this.tabAttractions.Location = new System.Drawing.Point(66, 5);
			this.tabAttractions.Name = "tabAttractions";
			this.tabAttractions.NextTabButton = this.tabSmallScenery;
			this.tabAttractions.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabAttractions.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabAttractions.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabAttractions.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabAttractions.PreviousTabButton = this.tabAll;
			this.tabAttractions.Size = new System.Drawing.Size(31, 27);
			this.tabAttractions.TabControlIndex = ((uint)(2u));
			this.tabAttractions.TabIndex = 128;
			this.tabAttractions.TabPage = this.tabGroupAttractions;
			this.tabAttractions.Text = "rctTabButton1";
			this.tabAttractions.Toggled = false;
			this.tabAttractions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabSmallScenery
			// 
			this.tabSmallScenery.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabSmallScenery.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabSmallScenery.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSmallScenery.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSmallScenery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabSmallScenery.Image = global::RCTDataEditor.Properties.Resources.TabSmallScenery;
			this.tabSmallScenery.Location = new System.Drawing.Point(97, 5);
			this.tabSmallScenery.Name = "tabSmallScenery";
			this.tabSmallScenery.NextTabButton = this.tabLargeScenery;
			this.tabSmallScenery.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSmallScenery.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabSmallScenery.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabSmallScenery.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSmallScenery.PreviousTabButton = this.tabAttractions;
			this.tabSmallScenery.Size = new System.Drawing.Size(31, 27);
			this.tabSmallScenery.TabControlIndex = ((uint)(3u));
			this.tabSmallScenery.TabIndex = 129;
			this.tabSmallScenery.TabPage = this.tabGroupSmallScenery;
			this.tabSmallScenery.Text = "rctTabButton1";
			this.tabSmallScenery.Toggled = false;
			this.tabSmallScenery.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabLargeScenery
			// 
			this.tabLargeScenery.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabLargeScenery.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabLargeScenery.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabLargeScenery.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabLargeScenery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabLargeScenery.Image = global::RCTDataEditor.Properties.Resources.TabLargeScenery;
			this.tabLargeScenery.Location = new System.Drawing.Point(128, 5);
			this.tabLargeScenery.Name = "tabLargeScenery";
			this.tabLargeScenery.NextTabButton = this.tabWalls;
			this.tabLargeScenery.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabLargeScenery.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabLargeScenery.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabLargeScenery.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabLargeScenery.PreviousTabButton = this.tabSmallScenery;
			this.tabLargeScenery.Size = new System.Drawing.Size(31, 27);
			this.tabLargeScenery.TabControlIndex = ((uint)(4u));
			this.tabLargeScenery.TabIndex = 130;
			this.tabLargeScenery.TabPage = this.tabGroupLargeScenery;
			this.tabLargeScenery.Text = "rctTabButton2";
			this.tabLargeScenery.Toggled = false;
			this.tabLargeScenery.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabWalls
			// 
			this.tabWalls.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabWalls.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabWalls.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabWalls.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabWalls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabWalls.Image = global::RCTDataEditor.Properties.Resources.TabWalls;
			this.tabWalls.Location = new System.Drawing.Point(159, 5);
			this.tabWalls.Name = "tabWalls";
			this.tabWalls.NextTabButton = this.tabSigns;
			this.tabWalls.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabWalls.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabWalls.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabWalls.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabWalls.PreviousTabButton = this.tabLargeScenery;
			this.tabWalls.Size = new System.Drawing.Size(31, 27);
			this.tabWalls.TabControlIndex = ((uint)(5u));
			this.tabWalls.TabIndex = 135;
			this.tabWalls.TabPage = this.tabGroupWalls;
			this.tabWalls.Text = "rctTabButton7";
			this.tabWalls.Toggled = false;
			this.tabWalls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabSigns
			// 
			this.tabSigns.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabSigns.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabSigns.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSigns.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSigns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabSigns.Image = global::RCTDataEditor.Properties.Resources.TabSigns;
			this.tabSigns.Location = new System.Drawing.Point(190, 5);
			this.tabSigns.Name = "tabSigns";
			this.tabSigns.NextTabButton = this.tabPaths;
			this.tabSigns.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSigns.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabSigns.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabSigns.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSigns.PreviousTabButton = this.tabWalls;
			this.tabSigns.Size = new System.Drawing.Size(31, 27);
			this.tabSigns.TabControlIndex = ((uint)(6u));
			this.tabSigns.TabIndex = 131;
			this.tabSigns.TabPage = this.tabGroupSigns;
			this.tabSigns.Text = "rctTabButton3";
			this.tabSigns.Toggled = false;
			this.tabSigns.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabPaths
			// 
			this.tabPaths.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabPaths.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabPaths.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabPaths.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabPaths.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabPaths.Image = global::RCTDataEditor.Properties.Resources.TabPaths;
			this.tabPaths.Location = new System.Drawing.Point(221, 5);
			this.tabPaths.Name = "tabPaths";
			this.tabPaths.NextTabButton = this.tabPathAdditions;
			this.tabPaths.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabPaths.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabPaths.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabPaths.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabPaths.PreviousTabButton = this.tabSigns;
			this.tabPaths.Size = new System.Drawing.Size(31, 27);
			this.tabPaths.TabControlIndex = ((uint)(7u));
			this.tabPaths.TabIndex = 132;
			this.tabPaths.TabPage = this.tabGroupPaths;
			this.tabPaths.Text = "rctTabButton4";
			this.tabPaths.Toggled = false;
			this.tabPaths.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabPathAdditions
			// 
			this.tabPathAdditions.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabPathAdditions.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabPathAdditions.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabPathAdditions.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabPathAdditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabPathAdditions.Image = global::RCTDataEditor.Properties.Resources.TabPathAdditions;
			this.tabPathAdditions.Location = new System.Drawing.Point(252, 5);
			this.tabPathAdditions.Name = "tabPathAdditions";
			this.tabPathAdditions.NextTabButton = this.tabSceneryGroups;
			this.tabPathAdditions.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabPathAdditions.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabPathAdditions.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabPathAdditions.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabPathAdditions.PreviousTabButton = this.tabPaths;
			this.tabPathAdditions.Size = new System.Drawing.Size(31, 27);
			this.tabPathAdditions.TabControlIndex = ((uint)(8u));
			this.tabPathAdditions.TabIndex = 133;
			this.tabPathAdditions.TabPage = this.tabGroupPathAdditions;
			this.tabPathAdditions.Text = "rctTabButton5";
			this.tabPathAdditions.Toggled = false;
			this.tabPathAdditions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabSceneryGroups
			// 
			this.tabSceneryGroups.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabSceneryGroups.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabSceneryGroups.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSceneryGroups.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSceneryGroups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabSceneryGroups.Image = global::RCTDataEditor.Properties.Resources.TabSceneryGroups;
			this.tabSceneryGroups.Location = new System.Drawing.Point(283, 5);
			this.tabSceneryGroups.Name = "tabSceneryGroups";
			this.tabSceneryGroups.NextTabButton = this.tabParkEntrances;
			this.tabSceneryGroups.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSceneryGroups.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabSceneryGroups.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabSceneryGroups.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSceneryGroups.PreviousTabButton = this.tabPathAdditions;
			this.tabSceneryGroups.Size = new System.Drawing.Size(31, 27);
			this.tabSceneryGroups.TabControlIndex = ((uint)(9u));
			this.tabSceneryGroups.TabIndex = 134;
			this.tabSceneryGroups.TabPage = this.tabGroupSceneryGroups;
			this.tabSceneryGroups.Text = "rctTabButton6";
			this.tabSceneryGroups.Toggled = false;
			this.tabSceneryGroups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabParkEntrances
			// 
			this.tabParkEntrances.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabParkEntrances.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabParkEntrances.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabParkEntrances.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabParkEntrances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabParkEntrances.Image = global::RCTDataEditor.Properties.Resources.TabParkEntrances;
			this.tabParkEntrances.Location = new System.Drawing.Point(314, 5);
			this.tabParkEntrances.Name = "tabParkEntrances";
			this.tabParkEntrances.NextTabButton = this.tabWater;
			this.tabParkEntrances.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabParkEntrances.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabParkEntrances.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabParkEntrances.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabParkEntrances.PreviousTabButton = this.tabSceneryGroups;
			this.tabParkEntrances.Size = new System.Drawing.Size(31, 27);
			this.tabParkEntrances.TabControlIndex = ((uint)(10u));
			this.tabParkEntrances.TabIndex = 136;
			this.tabParkEntrances.TabPage = this.tabGroupParkEntrances;
			this.tabParkEntrances.Text = "rctTabButton8";
			this.tabParkEntrances.Toggled = false;
			this.tabParkEntrances.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabWater
			// 
			this.tabWater.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabWater.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabWater.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabWater.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabWater.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabWater.Image = global::RCTDataEditor.Properties.Resources.TabWater;
			this.tabWater.Location = new System.Drawing.Point(345, 5);
			this.tabWater.Name = "tabWater";
			this.tabWater.NextTabButton = this.tabSettings;
			this.tabWater.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabWater.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabWater.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabWater.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabWater.PreviousTabButton = this.tabParkEntrances;
			this.tabWater.Size = new System.Drawing.Size(31, 27);
			this.tabWater.TabControlIndex = ((uint)(11u));
			this.tabWater.TabIndex = 137;
			this.tabWater.TabPage = this.tabGroupWater;
			this.tabWater.Text = "rctTabButton9";
			this.tabWater.Toggled = false;
			this.tabWater.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// tabSettings
			// 
			this.tabSettings.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.tabSettings.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(99)))), ((int)(((byte)(59)))));
			this.tabSettings.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSettings.DepressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.tabSettings.Image = global::RCTDataEditor.Properties.Resources.TabSettings;
			this.tabSettings.Location = new System.Drawing.Point(376, 5);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.NextTabButton = null;
			this.tabSettings.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.tabSettings.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.tabSettings.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.tabSettings.PressedBorderColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.tabSettings.PreviousTabButton = this.tabWater;
			this.tabSettings.Size = new System.Drawing.Size(31, 27);
			this.tabSettings.TabControlIndex = ((uint)(12u));
			this.tabSettings.TabIndex = 138;
			this.tabSettings.TabPage = this.tabGroupSettings;
			this.tabSettings.Text = "rctTabButton10";
			this.tabSettings.Toggled = false;
			this.tabSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabDown);
			// 
			// BrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(761, 427);
			this.Controls.Add(this.splitContainerStatusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(777, 430);
			this.Name = "BrowserForm";
			this.Text = "RCT2 Content Browser";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.splitContainerSideView.Panel1.ResumeLayout(false);
			this.splitContainerSideView.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).EndInit();
			this.splitContainerSideView.ResumeLayout(false);
			this.splitContainerTabs.Panel1.ResumeLayout(false);
			this.splitContainerTabs.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTabs)).EndInit();
			this.splitContainerTabs.ResumeLayout(false);
			this.splitContainerStatusBar.Panel1.ResumeLayout(false);
			this.splitContainerStatusBar.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusBar)).EndInit();
			this.splitContainerStatusBar.ResumeLayout(false);
			this.rctPanel1.ResumeLayout(false);
			this.rctTabPanel1.ResumeLayout(false);
			this.tabGroupSettings.ResumeLayout(false);
			this.tabGroupSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownObjectsPerTick)).EndInit();
			this.rctPanel2.ResumeLayout(false);
			this.tabGroupInfoOld.ResumeLayout(false);
			this.tabGroupInfoOld.PerformLayout();
			this.statusBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox objectView;
		private System.Windows.Forms.GroupBox tabGroupInfoOld;
		private System.Windows.Forms.Label infoFrames;
		private System.Windows.Forms.Label infoFileName;
		private System.Windows.Forms.Label infoName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label infoFlags;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label infoImageOffset;
		private System.Windows.Forms.Label infoImageSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label infoHeight;
		private System.Windows.Forms.SplitContainer splitContainerSideView;
		private System.Windows.Forms.SplitContainer splitContainerTabs;
		private System.Windows.Forms.ListView tabGroupWalls;
		private System.Windows.Forms.ColumnHeader columnHeaderFile;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.ColumnHeader columnHeaderSource;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderFlag;
		private System.Windows.Forms.ImageList imageListFlags;
		private System.Windows.Forms.Timer timerLoadObjects;
		private System.Windows.Forms.ListView tabGroupWater;
		private System.Windows.Forms.ColumnHeader columnHeader46;
		private System.Windows.Forms.ColumnHeader columnHeader47;
		private System.Windows.Forms.ColumnHeader columnHeader48;
		private System.Windows.Forms.ColumnHeader columnHeader49;
		private System.Windows.Forms.ColumnHeader columnHeader50;
		private System.Windows.Forms.ListView tabGroupParkEntrances;
		private System.Windows.Forms.ColumnHeader columnHeader41;
		private System.Windows.Forms.ColumnHeader columnHeader42;
		private System.Windows.Forms.ColumnHeader columnHeader43;
		private System.Windows.Forms.ColumnHeader columnHeader44;
		private System.Windows.Forms.ColumnHeader columnHeader45;
		private System.Windows.Forms.ListView tabGroupSceneryGroups;
		private System.Windows.Forms.ColumnHeader columnHeader36;
		private System.Windows.Forms.ColumnHeader columnHeader37;
		private System.Windows.Forms.ColumnHeader columnHeader38;
		private System.Windows.Forms.ColumnHeader columnHeader39;
		private System.Windows.Forms.ColumnHeader columnHeader40;
		private System.Windows.Forms.ListView tabGroupPathAdditions;
		private System.Windows.Forms.ColumnHeader columnHeader31;
		private System.Windows.Forms.ColumnHeader columnHeader32;
		private System.Windows.Forms.ColumnHeader columnHeader33;
		private System.Windows.Forms.ColumnHeader columnHeader34;
		private System.Windows.Forms.ColumnHeader columnHeader35;
		private System.Windows.Forms.ListView tabGroupSigns;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.ListView tabGroupPaths;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ListView tabGroupLargeScenery;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ListView tabGroupSmallScenery;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ListView tabGroupAttractions;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ListView tabGroupAll;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Panel panelColorPalette;
		private System.Windows.Forms.Button buttonRemap1;
		private System.Windows.Forms.Button buttonRemap3;
		private System.Windows.Forms.Button buttonRemap2;
		private System.Windows.Forms.ListView tabGroupInfo;
		private System.Windows.Forms.ColumnHeader columnHeader52;
		private System.Windows.Forms.ColumnHeader columnHeader53;
		private System.Windows.Forms.ColumnHeader columnHeader51;
		private System.Windows.Forms.FolderBrowserDialog objDataBrowserDialog;
		private System.Windows.Forms.SplitContainer splitContainerStatusBar;
		private System.Windows.Forms.Panel tabGroupSettings;
		private System.Windows.Forms.NumericUpDown numericUpDownObjectsPerTick;
		private System.Windows.Forms.TextBox textBoxDirectory;
		private System.Windows.Forms.ImageList imageListPaletteButton;
		private System.Windows.Forms.ColumnHeader columnHeader54;
		private System.Windows.Forms.ColumnHeader columnHeader63;
		private System.Windows.Forms.ColumnHeader columnHeader57;
		private System.Windows.Forms.ColumnHeader columnHeader61;
		private System.Windows.Forms.ColumnHeader columnHeader58;
		private System.Windows.Forms.ColumnHeader columnHeader60;
		private System.Windows.Forms.ColumnHeader columnHeader59;
		private System.Windows.Forms.ColumnHeader columnHeader56;
		private System.Windows.Forms.ColumnHeader columnHeader62;
		private System.Windows.Forms.ColumnHeader columnHeader55;
		private System.Windows.Forms.ColumnHeader columnHeaderSubtype;
		private System.Windows.Forms.HScrollBar scrollBarImage;
		private System.Windows.Forms.ToolTip toolTips;
		private RCTButton buttonBrowseDefault;
		private RCTTabButton tabInfo;
		private RCTTabButton tabAll;
		private RCTTabButton tabAttractions;
		private RCTTabButton tabSmallScenery;
		private RCTButton buttonScan;
		private RCTTabButton tabSceneryGroups;
		private RCTTabButton tabPathAdditions;
		private RCTTabButton tabPaths;
		private RCTTabButton tabSigns;
		private RCTTabButton tabLargeScenery;
		private RCTTabButton tabWalls;
		private RCTTabButton tabSettings;
		private RCTTabButton tabWater;
		private RCTTabButton tabParkEntrances;
		private RCTButton buttonBrowse;
		private RCTButton buttonRotate;
		private RCTButton buttonSlope;
		private RCTButton buttonCorner;
		private RCTButton buttonElevate;
		private RCTButton buttonPreviousFrame;
		private RCTButton buttonNextFrame;
		private RCTButton buttonPreviousObject;
		private RCTButton buttonNextObject;
		private RCTCheckBox checkBoxDialogView;
		private RCTCheckBox checkBoxImageView;
		private RCTLabel labelImageOffset;
		private RCTLabel labelImageSize;
		private RCTButton buttonSaveSettings;
		private RCTLabel labelObjectsInGroup;
		private RCTLabel labelObjectsScanned;
		private RCTLabel labelScanProgress;
		private RCTLabel labelCurrentObject;
		private RCTStatusBar statusBar;
		private RCTPanel rctPanel1;
		private RCTPanel rctPanel2;
		private RCTTabPanel rctTabPanel1;
		private System.Windows.Forms.ColumnHeader columnHeader64;
		private RCTButton buttonAbout;
		private RCTLabel rctLabel2;
		private RCTLabel rctLabel1;
		private RCTCheckBox checkBoxQuickLoad;
		private RCTCheckBox checkBoxRemapImage;
		private RCTButton buttonOpenDir;
		private RCTButton buttonExtract;
		private System.Windows.Forms.Timer timerExtract;
		private RCTCheckBox checkBoxAllowDeletions;
		private RCTCheckBox checkBoxBackupDeletions;
	}
}

