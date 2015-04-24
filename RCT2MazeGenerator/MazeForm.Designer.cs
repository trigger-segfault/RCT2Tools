namespace RCT2MazeGenerator {
	partial class MazeForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.buttonPlaceModeRestrict = new CustomControls.RCTButton();
			this.buttonSave = new CustomControls.RCTButton();
			this.buttonPlaceModeGenerate = new CustomControls.RCTButton();
			this.buttonAbout = new CustomControls.RCTButton();
			this.rctLabel7 = new CustomControls.RCTLabel();
			this.buttonNew = new CustomControls.RCTButton();
			this.buttonSaveAs = new CustomControls.RCTButton();
			this.buttonOpen = new CustomControls.RCTButton();
			this.labelMazeSize = new CustomControls.RCTLabel();
			this.buttonPlaceModeTiles = new CustomControls.RCTButton();
			this.buttonPlaceModeWalls = new CustomControls.RCTButton();
			this.buttonPlaceModeExit = new CustomControls.RCTButton();
			this.buttonPlaceModeEntrance = new CustomControls.RCTButton();
			this.rctLabel4 = new CustomControls.RCTLabel();
			this.rctLabel3 = new CustomControls.RCTLabel();
			this.rctLabel2 = new CustomControls.RCTLabel();
			this.rctLabel1 = new CustomControls.RCTLabel();
			this.rctPanel3 = new CustomControls.RCTPanel();
			this.rctPanel2 = new CustomControls.RCTPanel();
			this.rctPanel1 = new CustomControls.RCTPanel();
			this.rctPanel4 = new CustomControls.RCTPanel();
			this.rctLabel5 = new CustomControls.RCTLabel();
			this.buttonGrid = new CustomControls.RCTButton();
			this.buttonZoomOut = new CustomControls.RCTButton();
			this.buttonZoomIn = new CustomControls.RCTButton();
			this.buttonStyleWoodenFences = new CustomControls.RCTButton();
			this.buttonStyleIceBlocks = new CustomControls.RCTButton();
			this.buttonStyleHedges = new CustomControls.RCTButton();
			this.buttonStyleBrickWalls = new CustomControls.RCTButton();
			this.buttonTranslateMinusX = new CustomControls.RCTButton();
			this.buttonTranslatePlusX = new CustomControls.RCTButton();
			this.buttonTranslatePlusY = new CustomControls.RCTButton();
			this.buttonTranslateMinusY = new CustomControls.RCTButton();
			this.buttonResizeMinusX = new CustomControls.RCTButton();
			this.buttonResizePlusX = new CustomControls.RCTButton();
			this.buttonResizePlusY = new CustomControls.RCTButton();
			this.buttonResizeMinusY = new CustomControls.RCTButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.checkBoxWallsMakeTiles = new CustomControls.RCTCheckBox();
			this.timerGenerator = new System.Windows.Forms.Timer(this.components);
			this.mazeEditor1 = new RCT2MazeGenerator.MazeEditor();
			this.checkBoxFastGeneration = new CustomControls.RCTCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.rctPanel3.SuspendLayout();
			this.rctPanel2.SuspendLayout();
			this.rctPanel1.SuspendLayout();
			this.rctPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.checkBoxFastGeneration);
			this.splitContainer1.Panel1.Controls.Add(this.checkBoxWallsMakeTiles);
			this.splitContainer1.Panel1.Controls.Add(this.buttonGrid);
			this.splitContainer1.Panel1.Controls.Add(this.buttonZoomOut);
			this.splitContainer1.Panel1.Controls.Add(this.buttonZoomIn);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel5);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeRestrict);
			this.splitContainer1.Panel1.Controls.Add(this.buttonSave);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeGenerate);
			this.splitContainer1.Panel1.Controls.Add(this.buttonAbout);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel7);
			this.splitContainer1.Panel1.Controls.Add(this.buttonNew);
			this.splitContainer1.Panel1.Controls.Add(this.buttonSaveAs);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStyleWoodenFences);
			this.splitContainer1.Panel1.Controls.Add(this.buttonOpen);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStyleIceBlocks);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStyleHedges);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStyleBrickWalls);
			this.splitContainer1.Panel1.Controls.Add(this.labelMazeSize);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeTiles);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeWalls);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeExit);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPlaceModeEntrance);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel4);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel3);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel2);
			this.splitContainer1.Panel1.Controls.Add(this.rctLabel1);
			this.splitContainer1.Panel1.Controls.Add(this.rctPanel3);
			this.splitContainer1.Panel1.Controls.Add(this.rctPanel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rctPanel1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer1.Size = new System.Drawing.Size(662, 480);
			this.splitContainer1.SplitterDistance = 210;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "TD6";
			this.saveFileDialog.Filter = "RCT Track Designs|*.TD6";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "TD6";
			this.openFileDialog.Filter = "RCT Track Designs|*.TD6";
			// 
			// buttonPlaceModeRestrict
			// 
			this.buttonPlaceModeRestrict.BorderOnHover = false;
			this.buttonPlaceModeRestrict.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeRestrict.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeRestrict.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeRestrict.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeRestrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeRestrict.Image = null;
			this.buttonPlaceModeRestrict.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeRestrict.Location = new System.Drawing.Point(117, 129);
			this.buttonPlaceModeRestrict.Name = "buttonPlaceModeRestrict";
			this.buttonPlaceModeRestrict.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeRestrict.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeRestrict.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeRestrict.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeRestrict.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeRestrict.TabIndex = 21;
			this.buttonPlaceModeRestrict.Text = "Restrict";
			this.buttonPlaceModeRestrict.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeRestrict.Toggleable = false;
			this.buttonPlaceModeRestrict.Toggled = false;
			this.buttonPlaceModeRestrict.ButtonPressed += new System.EventHandler(this.PlaceModeRestrict);
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
			this.buttonSave.Location = new System.Drawing.Point(78, 427);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSave.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSave.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSave.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSave.Size = new System.Drawing.Size(60, 18);
			this.buttonSave.TabIndex = 142;
			this.buttonSave.Text = "Save";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSave.Toggleable = false;
			this.buttonSave.Toggled = false;
			this.buttonSave.ButtonPressed += new System.EventHandler(this.Save);
			// 
			// buttonPlaceModeGenerate
			// 
			this.buttonPlaceModeGenerate.BorderOnHover = false;
			this.buttonPlaceModeGenerate.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeGenerate.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeGenerate.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeGenerate.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeGenerate.Image = null;
			this.buttonPlaceModeGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeGenerate.Location = new System.Drawing.Point(17, 129);
			this.buttonPlaceModeGenerate.Name = "buttonPlaceModeGenerate";
			this.buttonPlaceModeGenerate.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeGenerate.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeGenerate.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeGenerate.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeGenerate.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeGenerate.TabIndex = 20;
			this.buttonPlaceModeGenerate.Text = "Generate";
			this.buttonPlaceModeGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeGenerate.Toggleable = false;
			this.buttonPlaceModeGenerate.Toggled = false;
			this.buttonPlaceModeGenerate.ButtonPressed += new System.EventHandler(this.PlaceModeGenerate);
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
			this.buttonAbout.Location = new System.Drawing.Point(144, 452);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonAbout.Size = new System.Drawing.Size(60, 18);
			this.buttonAbout.TabIndex = 143;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.About);
			// 
			// rctLabel7
			// 
			this.rctLabel7.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel7.Location = new System.Drawing.Point(12, 295);
			this.rctLabel7.Name = "rctLabel7";
			this.rctLabel7.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel7.Size = new System.Drawing.Size(75, 14);
			this.rctLabel7.TabIndex = 19;
			this.rctLabel7.Text = "Wall Style:";
			this.rctLabel7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.buttonNew.Location = new System.Drawing.Point(12, 427);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonNew.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonNew.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonNew.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonNew.Size = new System.Drawing.Size(60, 18);
			this.buttonNew.TabIndex = 144;
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
			this.buttonSaveAs.Location = new System.Drawing.Point(78, 452);
			this.buttonSaveAs.Name = "buttonSaveAs";
			this.buttonSaveAs.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSaveAs.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonSaveAs.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonSaveAs.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonSaveAs.Size = new System.Drawing.Size(60, 18);
			this.buttonSaveAs.TabIndex = 145;
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
			this.buttonOpen.Location = new System.Drawing.Point(12, 452);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonOpen.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonOpen.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonOpen.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonOpen.Size = new System.Drawing.Size(60, 18);
			this.buttonOpen.TabIndex = 146;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOpen.Toggleable = false;
			this.buttonOpen.Toggled = false;
			this.buttonOpen.ButtonPressed += new System.EventHandler(this.Open);
			// 
			// labelMazeSize
			// 
			this.labelMazeSize.FontType = CustomControls.Visuals.FontType.Bold;
			this.labelMazeSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelMazeSize.Location = new System.Drawing.Point(11, 403);
			this.labelMazeSize.Name = "labelMazeSize";
			this.labelMazeSize.OutlineColor = System.Drawing.Color.Transparent;
			this.labelMazeSize.Size = new System.Drawing.Size(180, 14);
			this.labelMazeSize.TabIndex = 12;
			this.labelMazeSize.Text = "Maze Size: 24x24";
			this.labelMazeSize.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// buttonPlaceModeTiles
			// 
			this.buttonPlaceModeTiles.BorderOnHover = false;
			this.buttonPlaceModeTiles.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeTiles.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeTiles.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeTiles.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeTiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeTiles.Image = null;
			this.buttonPlaceModeTiles.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeTiles.Location = new System.Drawing.Point(17, 58);
			this.buttonPlaceModeTiles.Name = "buttonPlaceModeTiles";
			this.buttonPlaceModeTiles.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeTiles.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeTiles.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeTiles.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeTiles.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeTiles.TabIndex = 11;
			this.buttonPlaceModeTiles.Text = "Tiles";
			this.buttonPlaceModeTiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeTiles.Toggleable = false;
			this.buttonPlaceModeTiles.Toggled = false;
			this.buttonPlaceModeTiles.ButtonPressed += new System.EventHandler(this.PlaceModeTiles);
			// 
			// buttonPlaceModeWalls
			// 
			this.buttonPlaceModeWalls.BorderOnHover = false;
			this.buttonPlaceModeWalls.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeWalls.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeWalls.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeWalls.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeWalls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeWalls.Image = null;
			this.buttonPlaceModeWalls.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeWalls.Location = new System.Drawing.Point(17, 32);
			this.buttonPlaceModeWalls.Name = "buttonPlaceModeWalls";
			this.buttonPlaceModeWalls.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeWalls.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeWalls.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeWalls.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeWalls.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeWalls.TabIndex = 10;
			this.buttonPlaceModeWalls.Text = "Walls";
			this.buttonPlaceModeWalls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeWalls.Toggleable = false;
			this.buttonPlaceModeWalls.Toggled = false;
			this.buttonPlaceModeWalls.ButtonPressed += new System.EventHandler(this.PlaceModeWalls);
			// 
			// buttonPlaceModeExit
			// 
			this.buttonPlaceModeExit.BorderOnHover = false;
			this.buttonPlaceModeExit.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeExit.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeExit.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeExit.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeExit.Image = null;
			this.buttonPlaceModeExit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeExit.Location = new System.Drawing.Point(117, 58);
			this.buttonPlaceModeExit.Name = "buttonPlaceModeExit";
			this.buttonPlaceModeExit.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeExit.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeExit.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeExit.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeExit.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeExit.TabIndex = 9;
			this.buttonPlaceModeExit.Text = "Exit";
			this.buttonPlaceModeExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeExit.Toggleable = false;
			this.buttonPlaceModeExit.Toggled = false;
			this.buttonPlaceModeExit.ButtonPressed += new System.EventHandler(this.PlaceModeExit);
			// 
			// buttonPlaceModeEntrance
			// 
			this.buttonPlaceModeEntrance.BorderOnHover = false;
			this.buttonPlaceModeEntrance.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonPlaceModeEntrance.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeEntrance.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeEntrance.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlaceModeEntrance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlaceModeEntrance.Image = null;
			this.buttonPlaceModeEntrance.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeEntrance.Location = new System.Drawing.Point(117, 32);
			this.buttonPlaceModeEntrance.Name = "buttonPlaceModeEntrance";
			this.buttonPlaceModeEntrance.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlaceModeEntrance.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonPlaceModeEntrance.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonPlaceModeEntrance.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonPlaceModeEntrance.Size = new System.Drawing.Size(70, 20);
			this.buttonPlaceModeEntrance.TabIndex = 8;
			this.buttonPlaceModeEntrance.Text = "Entrance";
			this.buttonPlaceModeEntrance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlaceModeEntrance.Toggleable = false;
			this.buttonPlaceModeEntrance.Toggled = false;
			this.buttonPlaceModeEntrance.ButtonPressed += new System.EventHandler(this.PlaceModeEntrance);
			// 
			// rctLabel4
			// 
			this.rctLabel4.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel4.Location = new System.Drawing.Point(12, 109);
			this.rctLabel4.Name = "rctLabel4";
			this.rctLabel4.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel4.Size = new System.Drawing.Size(75, 14);
			this.rctLabel4.TabIndex = 7;
			this.rctLabel4.Text = "Generation:";
			this.rctLabel4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel3
			// 
			this.rctLabel3.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel3.Location = new System.Drawing.Point(12, 12);
			this.rctLabel3.Name = "rctLabel3";
			this.rctLabel3.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel3.Size = new System.Drawing.Size(75, 14);
			this.rctLabel3.TabIndex = 7;
			this.rctLabel3.Text = "Place Mode:";
			this.rctLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel2
			// 
			this.rctLabel2.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel2.Location = new System.Drawing.Point(112, 179);
			this.rctLabel2.Name = "rctLabel2";
			this.rctLabel2.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel2.Size = new System.Drawing.Size(75, 14);
			this.rctLabel2.TabIndex = 6;
			this.rctLabel2.Text = "Translate:";
			this.rctLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctLabel1
			// 
			this.rctLabel1.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel1.Location = new System.Drawing.Point(12, 179);
			this.rctLabel1.Name = "rctLabel1";
			this.rctLabel1.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel1.Size = new System.Drawing.Size(75, 14);
			this.rctLabel1.TabIndex = 5;
			this.rctLabel1.Text = "Resize:";
			this.rctLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rctPanel3
			// 
			this.rctPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctPanel3.Controls.Add(this.buttonTranslateMinusX);
			this.rctPanel3.Controls.Add(this.buttonTranslatePlusX);
			this.rctPanel3.Controls.Add(this.buttonTranslatePlusY);
			this.rctPanel3.Controls.Add(this.buttonTranslateMinusY);
			this.rctPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel3.Location = new System.Drawing.Point(112, 199);
			this.rctPanel3.Name = "rctPanel3";
			this.rctPanel3.Padding = new System.Windows.Forms.Padding(3);
			this.rctPanel3.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctPanel3.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel3.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel3.Size = new System.Drawing.Size(84, 84);
			this.rctPanel3.TabIndex = 4;
			// 
			// rctPanel2
			// 
			this.rctPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctPanel2.Controls.Add(this.buttonResizeMinusX);
			this.rctPanel2.Controls.Add(this.buttonResizePlusX);
			this.rctPanel2.Controls.Add(this.buttonResizePlusY);
			this.rctPanel2.Controls.Add(this.buttonResizeMinusY);
			this.rctPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel2.Location = new System.Drawing.Point(12, 199);
			this.rctPanel2.Name = "rctPanel2";
			this.rctPanel2.Padding = new System.Windows.Forms.Padding(3);
			this.rctPanel2.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(135)))), ((int)(((byte)(95)))));
			this.rctPanel2.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel2.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel2.Size = new System.Drawing.Size(84, 84);
			this.rctPanel2.TabIndex = 3;
			// 
			// rctPanel1
			// 
			this.rctPanel1.Controls.Add(this.rctPanel4);
			this.rctPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel1.Location = new System.Drawing.Point(3, 3);
			this.rctPanel1.Name = "rctPanel1";
			this.rctPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctPanel1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel1.Size = new System.Drawing.Size(442, 474);
			this.rctPanel1.TabIndex = 0;
			// 
			// rctPanel4
			// 
			this.rctPanel4.AutoScroll = true;
			this.rctPanel4.Controls.Add(this.mazeEditor1);
			this.rctPanel4.Controls.Add(this.pictureBox1);
			this.rctPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel4.Location = new System.Drawing.Point(1, 1);
			this.rctPanel4.Name = "rctPanel4";
			this.rctPanel4.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.rctPanel4.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.rctPanel4.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.rctPanel4.Size = new System.Drawing.Size(440, 472);
			this.rctPanel4.TabIndex = 0;
			// 
			// rctLabel5
			// 
			this.rctLabel5.FontType = CustomControls.Visuals.FontType.Bold;
			this.rctLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctLabel5.Location = new System.Drawing.Point(12, 367);
			this.rctLabel5.Name = "rctLabel5";
			this.rctLabel5.OutlineColor = System.Drawing.Color.Transparent;
			this.rctLabel5.Size = new System.Drawing.Size(180, 14);
			this.rctLabel5.TabIndex = 149;
			this.rctLabel5.Text = "View:";
			this.rctLabel5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// buttonGrid
			// 
			this.buttonGrid.BorderOnHover = false;
			this.buttonGrid.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonGrid.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonGrid.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonGrid.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonGrid.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonGrid;
			this.buttonGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonGrid.Location = new System.Drawing.Point(134, 357);
			this.buttonGrid.Name = "buttonGrid";
			this.buttonGrid.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonGrid.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonGrid.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonGrid.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonGrid.Size = new System.Drawing.Size(32, 32);
			this.buttonGrid.TabIndex = 150;
			this.buttonGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonGrid.Toggleable = false;
			this.buttonGrid.Toggled = false;
			this.buttonGrid.ButtonPressed += new System.EventHandler(this.ShowGrid);
			// 
			// buttonZoomOut
			// 
			this.buttonZoomOut.BorderOnHover = false;
			this.buttonZoomOut.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonZoomOut.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonZoomOut.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonZoomOut.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonZoomOut.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonZoomOut;
			this.buttonZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonZoomOut.Location = new System.Drawing.Point(58, 357);
			this.buttonZoomOut.Name = "buttonZoomOut";
			this.buttonZoomOut.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonZoomOut.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonZoomOut.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonZoomOut.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonZoomOut.Size = new System.Drawing.Size(32, 32);
			this.buttonZoomOut.TabIndex = 148;
			this.buttonZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonZoomOut.Toggleable = false;
			this.buttonZoomOut.Toggled = false;
			this.buttonZoomOut.ButtonPressed += new System.EventHandler(this.ZoomOut);
			// 
			// buttonZoomIn
			// 
			this.buttonZoomIn.BorderOnHover = false;
			this.buttonZoomIn.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonZoomIn.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonZoomIn.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonZoomIn.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonZoomIn.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonZoomIn;
			this.buttonZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonZoomIn.Location = new System.Drawing.Point(96, 357);
			this.buttonZoomIn.Name = "buttonZoomIn";
			this.buttonZoomIn.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonZoomIn.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonZoomIn.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonZoomIn.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonZoomIn.Size = new System.Drawing.Size(32, 32);
			this.buttonZoomIn.TabIndex = 147;
			this.buttonZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonZoomIn.Toggleable = false;
			this.buttonZoomIn.Toggled = false;
			this.buttonZoomIn.ButtonPressed += new System.EventHandler(this.ZoomIn);
			// 
			// buttonStyleWoodenFences
			// 
			this.buttonStyleWoodenFences.BorderOnHover = false;
			this.buttonStyleWoodenFences.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonStyleWoodenFences.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleWoodenFences.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleWoodenFences.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonStyleWoodenFences.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonStyleWoodenFences.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonWoodenFences;
			this.buttonStyleWoodenFences.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleWoodenFences.Location = new System.Drawing.Point(134, 315);
			this.buttonStyleWoodenFences.Name = "buttonStyleWoodenFences";
			this.buttonStyleWoodenFences.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonStyleWoodenFences.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonStyleWoodenFences.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleWoodenFences.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleWoodenFences.Size = new System.Drawing.Size(32, 32);
			this.buttonStyleWoodenFences.TabIndex = 18;
			this.buttonStyleWoodenFences.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleWoodenFences.Toggleable = false;
			this.buttonStyleWoodenFences.Toggled = false;
			this.buttonStyleWoodenFences.ButtonPressed += new System.EventHandler(this.WallStyleWoodenFences);
			// 
			// buttonStyleIceBlocks
			// 
			this.buttonStyleIceBlocks.BorderOnHover = false;
			this.buttonStyleIceBlocks.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonStyleIceBlocks.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleIceBlocks.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleIceBlocks.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonStyleIceBlocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonStyleIceBlocks.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonIceBlocks;
			this.buttonStyleIceBlocks.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleIceBlocks.Location = new System.Drawing.Point(96, 315);
			this.buttonStyleIceBlocks.Name = "buttonStyleIceBlocks";
			this.buttonStyleIceBlocks.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonStyleIceBlocks.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonStyleIceBlocks.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleIceBlocks.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleIceBlocks.Size = new System.Drawing.Size(32, 32);
			this.buttonStyleIceBlocks.TabIndex = 17;
			this.buttonStyleIceBlocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleIceBlocks.Toggleable = false;
			this.buttonStyleIceBlocks.Toggled = false;
			this.buttonStyleIceBlocks.ButtonPressed += new System.EventHandler(this.WallStyleIceBlocks);
			// 
			// buttonStyleHedges
			// 
			this.buttonStyleHedges.BorderOnHover = false;
			this.buttonStyleHedges.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonStyleHedges.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleHedges.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleHedges.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonStyleHedges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonStyleHedges.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonHedges;
			this.buttonStyleHedges.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleHedges.Location = new System.Drawing.Point(58, 315);
			this.buttonStyleHedges.Name = "buttonStyleHedges";
			this.buttonStyleHedges.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonStyleHedges.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonStyleHedges.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleHedges.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleHedges.Size = new System.Drawing.Size(32, 32);
			this.buttonStyleHedges.TabIndex = 16;
			this.buttonStyleHedges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleHedges.Toggleable = false;
			this.buttonStyleHedges.Toggled = false;
			this.buttonStyleHedges.ButtonPressed += new System.EventHandler(this.WallStyleHedges);
			// 
			// buttonStyleBrickWalls
			// 
			this.buttonStyleBrickWalls.BorderOnHover = false;
			this.buttonStyleBrickWalls.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonStyleBrickWalls.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleBrickWalls.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleBrickWalls.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonStyleBrickWalls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonStyleBrickWalls.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonBrickWalls;
			this.buttonStyleBrickWalls.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleBrickWalls.Location = new System.Drawing.Point(20, 315);
			this.buttonStyleBrickWalls.Name = "buttonStyleBrickWalls";
			this.buttonStyleBrickWalls.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonStyleBrickWalls.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonStyleBrickWalls.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonStyleBrickWalls.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonStyleBrickWalls.Size = new System.Drawing.Size(32, 32);
			this.buttonStyleBrickWalls.TabIndex = 15;
			this.buttonStyleBrickWalls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonStyleBrickWalls.Toggleable = false;
			this.buttonStyleBrickWalls.Toggled = false;
			this.buttonStyleBrickWalls.ButtonPressed += new System.EventHandler(this.WallStyleBrickWalls);
			// 
			// buttonTranslateMinusX
			// 
			this.buttonTranslateMinusX.BorderOnHover = false;
			this.buttonTranslateMinusX.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonTranslateMinusX.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslateMinusX.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslateMinusX.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonTranslateMinusX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonTranslateMinusX.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonLeft2;
			this.buttonTranslateMinusX.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslateMinusX.Location = new System.Drawing.Point(5, 30);
			this.buttonTranslateMinusX.Name = "buttonTranslateMinusX";
			this.buttonTranslateMinusX.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonTranslateMinusX.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonTranslateMinusX.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslateMinusX.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslateMinusX.Size = new System.Drawing.Size(24, 24);
			this.buttonTranslateMinusX.TabIndex = 0;
			this.buttonTranslateMinusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslateMinusX.Toggleable = false;
			this.buttonTranslateMinusX.Toggled = false;
			this.buttonTranslateMinusX.ButtonPressed += new System.EventHandler(this.TranslateMazeMinusX);
			// 
			// buttonTranslatePlusX
			// 
			this.buttonTranslatePlusX.BorderOnHover = false;
			this.buttonTranslatePlusX.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonTranslatePlusX.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslatePlusX.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslatePlusX.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonTranslatePlusX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonTranslatePlusX.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonRight2;
			this.buttonTranslatePlusX.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslatePlusX.Location = new System.Drawing.Point(55, 30);
			this.buttonTranslatePlusX.Name = "buttonTranslatePlusX";
			this.buttonTranslatePlusX.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonTranslatePlusX.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonTranslatePlusX.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslatePlusX.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslatePlusX.Size = new System.Drawing.Size(24, 24);
			this.buttonTranslatePlusX.TabIndex = 2;
			this.buttonTranslatePlusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslatePlusX.Toggleable = false;
			this.buttonTranslatePlusX.Toggled = false;
			this.buttonTranslatePlusX.ButtonPressed += new System.EventHandler(this.TranslateMazePlusX);
			// 
			// buttonTranslatePlusY
			// 
			this.buttonTranslatePlusY.BorderOnHover = false;
			this.buttonTranslatePlusY.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonTranslatePlusY.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslatePlusY.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslatePlusY.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonTranslatePlusY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonTranslatePlusY.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonDown2;
			this.buttonTranslatePlusY.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslatePlusY.Location = new System.Drawing.Point(30, 55);
			this.buttonTranslatePlusY.Name = "buttonTranslatePlusY";
			this.buttonTranslatePlusY.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonTranslatePlusY.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonTranslatePlusY.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslatePlusY.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslatePlusY.Size = new System.Drawing.Size(24, 24);
			this.buttonTranslatePlusY.TabIndex = 2;
			this.buttonTranslatePlusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslatePlusY.Toggleable = false;
			this.buttonTranslatePlusY.Toggled = false;
			this.buttonTranslatePlusY.ButtonPressed += new System.EventHandler(this.TranslateMazePlusY);
			// 
			// buttonTranslateMinusY
			// 
			this.buttonTranslateMinusY.BorderOnHover = false;
			this.buttonTranslateMinusY.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonTranslateMinusY.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslateMinusY.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslateMinusY.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonTranslateMinusY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonTranslateMinusY.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonUp2;
			this.buttonTranslateMinusY.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslateMinusY.Location = new System.Drawing.Point(30, 5);
			this.buttonTranslateMinusY.Name = "buttonTranslateMinusY";
			this.buttonTranslateMinusY.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonTranslateMinusY.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonTranslateMinusY.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonTranslateMinusY.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonTranslateMinusY.Size = new System.Drawing.Size(24, 24);
			this.buttonTranslateMinusY.TabIndex = 1;
			this.buttonTranslateMinusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonTranslateMinusY.Toggleable = false;
			this.buttonTranslateMinusY.Toggled = false;
			this.buttonTranslateMinusY.ButtonPressed += new System.EventHandler(this.TranslateMazeMinusY);
			// 
			// buttonResizeMinusX
			// 
			this.buttonResizeMinusX.BorderOnHover = false;
			this.buttonResizeMinusX.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonResizeMinusX.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizeMinusX.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizeMinusX.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonResizeMinusX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonResizeMinusX.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonLeft2;
			this.buttonResizeMinusX.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizeMinusX.Location = new System.Drawing.Point(5, 30);
			this.buttonResizeMinusX.Name = "buttonResizeMinusX";
			this.buttonResizeMinusX.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonResizeMinusX.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonResizeMinusX.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizeMinusX.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizeMinusX.Size = new System.Drawing.Size(24, 24);
			this.buttonResizeMinusX.TabIndex = 0;
			this.buttonResizeMinusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizeMinusX.Toggleable = false;
			this.buttonResizeMinusX.Toggled = false;
			this.buttonResizeMinusX.ButtonPressed += new System.EventHandler(this.ResizeMazeMinusX);
			// 
			// buttonResizePlusX
			// 
			this.buttonResizePlusX.BorderOnHover = false;
			this.buttonResizePlusX.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonResizePlusX.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizePlusX.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizePlusX.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonResizePlusX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonResizePlusX.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonRight2;
			this.buttonResizePlusX.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizePlusX.Location = new System.Drawing.Point(55, 30);
			this.buttonResizePlusX.Name = "buttonResizePlusX";
			this.buttonResizePlusX.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonResizePlusX.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonResizePlusX.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizePlusX.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizePlusX.Size = new System.Drawing.Size(24, 24);
			this.buttonResizePlusX.TabIndex = 2;
			this.buttonResizePlusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizePlusX.Toggleable = false;
			this.buttonResizePlusX.Toggled = false;
			this.buttonResizePlusX.ButtonPressed += new System.EventHandler(this.ResizeMazePlusX);
			// 
			// buttonResizePlusY
			// 
			this.buttonResizePlusY.BorderOnHover = false;
			this.buttonResizePlusY.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonResizePlusY.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizePlusY.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizePlusY.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonResizePlusY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonResizePlusY.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonDown2;
			this.buttonResizePlusY.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizePlusY.Location = new System.Drawing.Point(30, 55);
			this.buttonResizePlusY.Name = "buttonResizePlusY";
			this.buttonResizePlusY.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonResizePlusY.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonResizePlusY.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizePlusY.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizePlusY.Size = new System.Drawing.Size(24, 24);
			this.buttonResizePlusY.TabIndex = 2;
			this.buttonResizePlusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizePlusY.Toggleable = false;
			this.buttonResizePlusY.Toggled = false;
			this.buttonResizePlusY.ButtonPressed += new System.EventHandler(this.ResizeMazePlusY);
			// 
			// buttonResizeMinusY
			// 
			this.buttonResizeMinusY.BorderOnHover = false;
			this.buttonResizeMinusY.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.buttonResizeMinusY.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizeMinusY.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizeMinusY.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonResizeMinusY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonResizeMinusY.Image = global::RCT2MazeGenerator.Properties.Resources.ButtonUp2;
			this.buttonResizeMinusY.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizeMinusY.Location = new System.Drawing.Point(30, 5);
			this.buttonResizeMinusY.Name = "buttonResizeMinusY";
			this.buttonResizeMinusY.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonResizeMinusY.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(175)))), ((int)(((byte)(139)))));
			this.buttonResizeMinusY.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.buttonResizeMinusY.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.buttonResizeMinusY.Size = new System.Drawing.Size(24, 24);
			this.buttonResizeMinusY.TabIndex = 1;
			this.buttonResizeMinusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonResizeMinusY.Toggleable = false;
			this.buttonResizeMinusY.Toggled = false;
			this.buttonResizeMinusY.ButtonPressed += new System.EventHandler(this.ResizeMazeMinusY);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::RCT2MazeGenerator.Properties.Resources.Grass;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(440, 472);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// checkBoxWallsMakeTiles
			// 
			this.checkBoxWallsMakeTiles.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxWallsMakeTiles.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxWallsMakeTiles.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxWallsMakeTiles.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxWallsMakeTiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxWallsMakeTiles.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxWallsMakeTiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxWallsMakeTiles.Location = new System.Drawing.Point(20, 88);
			this.checkBoxWallsMakeTiles.Name = "checkBoxWallsMakeTiles";
			this.checkBoxWallsMakeTiles.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxWallsMakeTiles.Size = new System.Drawing.Size(110, 11);
			this.checkBoxWallsMakeTiles.TabIndex = 151;
			this.checkBoxWallsMakeTiles.Text = "Walls make tiles";
			this.checkBoxWallsMakeTiles.CheckStateChanged += new System.EventHandler(this.WallsMakeTiles);
			// 
			// timerGenerator
			// 
			this.timerGenerator.Tick += new System.EventHandler(this.ContinueGeneration);
			// 
			// mazeEditor1
			// 
			this.mazeEditor1.BackgroundImage = global::RCT2MazeGenerator.Properties.Resources.Grass;
			this.mazeEditor1.Location = new System.Drawing.Point(0, 0);
			this.mazeEditor1.MazeSize = new System.Drawing.Size(10, 10);
			this.mazeEditor1.Name = "mazeEditor1";
			this.mazeEditor1.PlaceMode = RCT2MazeGenerator.PlaceModes.Walls;
			this.mazeEditor1.ShowGrid = true;
			this.mazeEditor1.Size = new System.Drawing.Size(440, 440);
			this.mazeEditor1.TabIndex = 2;
			this.mazeEditor1.Text = "mazeEditor2";
			this.mazeEditor1.WallsMakeTiles = true;
			this.mazeEditor1.WallStyle = RCT2MazeGenerator.WallStyles.Hedges;
			this.mazeEditor1.MazeChanged += new System.EventHandler(this.MazeChanged);
			this.mazeEditor1.GenerationStarted += new System.EventHandler(this.GenerationStarted);
			this.mazeEditor1.GenerationFinished += new System.EventHandler(this.GenerationFinished);
			// 
			// checkBoxFastGeneration
			// 
			this.checkBoxFastGeneration.CheckBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.checkBoxFastGeneration.CheckBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(115)))), ((int)(((byte)(75)))));
			this.checkBoxFastGeneration.CheckBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(199)))), ((int)(((byte)(167)))));
			this.checkBoxFastGeneration.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(243)))), ((int)(((byte)(223)))));
			this.checkBoxFastGeneration.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFastGeneration.FontType = CustomControls.Visuals.FontType.Bold;
			this.checkBoxFastGeneration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.checkBoxFastGeneration.Location = new System.Drawing.Point(20, 159);
			this.checkBoxFastGeneration.Name = "checkBoxFastGeneration";
			this.checkBoxFastGeneration.OutlineColor = System.Drawing.Color.Transparent;
			this.checkBoxFastGeneration.Size = new System.Drawing.Size(110, 11);
			this.checkBoxFastGeneration.TabIndex = 152;
			this.checkBoxFastGeneration.Text = "Fast generation";
			this.checkBoxFastGeneration.CheckStateChanged += new System.EventHandler(this.FastGeneration);
			// 
			// MazeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(155)))), ((int)(((byte)(119)))));
			this.ClientSize = new System.Drawing.Size(662, 480);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(550, 518);
			this.Name = "MazeForm";
			this.Text = "RCT2 Maze Generator";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.rctPanel3.ResumeLayout(false);
			this.rctPanel2.ResumeLayout(false);
			this.rctPanel1.ResumeLayout(false);
			this.rctPanel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private CustomControls.RCTPanel rctPanel1;
		private CustomControls.RCTButton buttonResizeMinusX;
		private CustomControls.RCTPanel rctPanel2;
		private CustomControls.RCTButton buttonResizePlusY;
		private CustomControls.RCTButton buttonResizePlusX;
		private CustomControls.RCTButton buttonResizeMinusY;
		private CustomControls.RCTButton buttonPlaceModeEntrance;
		private CustomControls.RCTLabel rctLabel3;
		private CustomControls.RCTLabel rctLabel2;
		private CustomControls.RCTLabel rctLabel1;
		private CustomControls.RCTPanel rctPanel3;
		private CustomControls.RCTButton buttonTranslateMinusX;
		private CustomControls.RCTButton buttonTranslatePlusX;
		private CustomControls.RCTButton buttonTranslatePlusY;
		private CustomControls.RCTButton buttonTranslateMinusY;
		private CustomControls.RCTLabel labelMazeSize;
		private CustomControls.RCTButton buttonPlaceModeTiles;
		private CustomControls.RCTButton buttonPlaceModeWalls;
		private CustomControls.RCTButton buttonPlaceModeExit;
		private CustomControls.RCTButton buttonStyleHedges;
		private CustomControls.RCTButton buttonStyleBrickWalls;
		private CustomControls.RCTLabel rctLabel7;
		private CustomControls.RCTButton buttonStyleWoodenFences;
		private CustomControls.RCTButton buttonStyleIceBlocks;
		private CustomControls.RCTButton buttonPlaceModeGenerate;
		private System.Windows.Forms.PictureBox pictureBox1;
		private CustomControls.RCTButton buttonPlaceModeRestrict;
		private CustomControls.RCTLabel rctLabel4;
		private CustomControls.RCTButton buttonSave;
		private CustomControls.RCTButton buttonAbout;
		private CustomControls.RCTButton buttonNew;
		private CustomControls.RCTButton buttonSaveAs;
		private CustomControls.RCTButton buttonOpen;
		private CustomControls.RCTPanel rctPanel4;
		private MazeEditor mazeEditor1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private CustomControls.RCTButton buttonZoomIn;
		private CustomControls.RCTButton buttonZoomOut;
		private CustomControls.RCTLabel rctLabel5;
		private CustomControls.RCTButton buttonGrid;
		private CustomControls.RCTCheckBox checkBoxWallsMakeTiles;
		private System.Windows.Forms.Timer timerGenerator;
		private CustomControls.RCTCheckBox checkBoxFastGeneration;
	}
}

