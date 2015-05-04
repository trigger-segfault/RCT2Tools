using CustomControls;
namespace RCT2MusicManager {
	partial class MusicForm {
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
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Custom Music", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Music List", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicForm));
			this.splitContainerSideView = new System.Windows.Forms.SplitContainer();
			this.buttonRename = new CustomControls.RCTButton();
			this.buttonRefresh = new CustomControls.RCTButton();
			this.buttonAbout = new CustomControls.RCTButton();
			this.buttonBrowse = new CustomControls.RCTButton();
			this.buttonSetCustom2 = new CustomControls.RCTButton();
			this.buttonSetCustom1 = new CustomControls.RCTButton();
			this.buttonPlay = new CustomControls.RCTButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rctPanel1 = new CustomControls.RCTPanel();
			this.listViewSongs = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListPlaying = new System.Windows.Forms.ImageList(this.components);
			this.dataBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).BeginInit();
			this.splitContainerSideView.Panel1.SuspendLayout();
			this.splitContainerSideView.Panel2.SuspendLayout();
			this.splitContainerSideView.SuspendLayout();
			this.panel1.SuspendLayout();
			this.rctPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainerSideView
			// 
			this.splitContainerSideView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.splitContainerSideView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSideView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerSideView.IsSplitterFixed = true;
			this.splitContainerSideView.Location = new System.Drawing.Point(0, 0);
			this.splitContainerSideView.Name = "splitContainerSideView";
			// 
			// splitContainerSideView.Panel1
			// 
			this.splitContainerSideView.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRename);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonRefresh);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonAbout);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonBrowse);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonSetCustom2);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonSetCustom1);
			this.splitContainerSideView.Panel1.Controls.Add(this.buttonPlay);
			// 
			// splitContainerSideView.Panel2
			// 
			this.splitContainerSideView.Panel2.Controls.Add(this.panel1);
			this.splitContainerSideView.Size = new System.Drawing.Size(489, 252);
			this.splitContainerSideView.SplitterDistance = 100;
			this.splitContainerSideView.SplitterWidth = 1;
			this.splitContainerSideView.TabIndex = 123;
			// 
			// buttonRename
			// 
			this.buttonRename.BorderOnHover = false;
			this.buttonRename.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonRename.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonRename.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonRename.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonRename.Image = null;
			this.buttonRename.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRename.Location = new System.Drawing.Point(12, 84);
			this.buttonRename.Name = "buttonRename";
			this.buttonRename.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonRename.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonRename.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonRename.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonRename.Size = new System.Drawing.Size(80, 18);
			this.buttonRename.TabIndex = 150;
			this.buttonRename.Text = "Rename";
			this.buttonRename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRename.Toggleable = false;
			this.buttonRename.Toggled = false;
			this.buttonRename.ButtonPressed += new System.EventHandler(this.RenameSong);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.BorderOnHover = false;
			this.buttonRefresh.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonRefresh.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonRefresh.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonRefresh.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonRefresh.Image = null;
			this.buttonRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRefresh.Location = new System.Drawing.Point(12, 132);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonRefresh.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonRefresh.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonRefresh.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonRefresh.Size = new System.Drawing.Size(80, 18);
			this.buttonRefresh.TabIndex = 149;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRefresh.Toggleable = false;
			this.buttonRefresh.Toggled = false;
			this.buttonRefresh.ButtonPressed += new System.EventHandler(this.Refresh);
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
			this.buttonAbout.Location = new System.Drawing.Point(12, 156);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonAbout.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonAbout.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonAbout.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonAbout.Size = new System.Drawing.Size(80, 18);
			this.buttonAbout.TabIndex = 148;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonAbout.Toggleable = false;
			this.buttonAbout.Toggled = false;
			this.buttonAbout.ButtonPressed += new System.EventHandler(this.About);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.BorderOnHover = false;
			this.buttonBrowse.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonBrowse.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowse.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowse.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonBrowse.Image = null;
			this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Location = new System.Drawing.Point(12, 108);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonBrowse.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonBrowse.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonBrowse.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonBrowse.Size = new System.Drawing.Size(80, 18);
			this.buttonBrowse.TabIndex = 145;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowse.Toggleable = false;
			this.buttonBrowse.Toggled = false;
			this.buttonBrowse.ButtonPressed += new System.EventHandler(this.BrowseDataDirectory);
			// 
			// buttonSetCustom2
			// 
			this.buttonSetCustom2.BorderOnHover = false;
			this.buttonSetCustom2.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonSetCustom2.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonSetCustom2.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonSetCustom2.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSetCustom2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSetCustom2.Image = null;
			this.buttonSetCustom2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSetCustom2.Location = new System.Drawing.Point(12, 60);
			this.buttonSetCustom2.Name = "buttonSetCustom2";
			this.buttonSetCustom2.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSetCustom2.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonSetCustom2.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonSetCustom2.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonSetCustom2.Size = new System.Drawing.Size(80, 18);
			this.buttonSetCustom2.TabIndex = 144;
			this.buttonSetCustom2.Text = "Set Custom 2";
			this.buttonSetCustom2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSetCustom2.Toggleable = false;
			this.buttonSetCustom2.Toggled = false;
			this.buttonSetCustom2.ButtonPressed += new System.EventHandler(this.SetCustom2);
			// 
			// buttonSetCustom1
			// 
			this.buttonSetCustom1.BorderOnHover = false;
			this.buttonSetCustom1.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonSetCustom1.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonSetCustom1.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonSetCustom1.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonSetCustom1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonSetCustom1.Image = null;
			this.buttonSetCustom1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSetCustom1.Location = new System.Drawing.Point(12, 36);
			this.buttonSetCustom1.Name = "buttonSetCustom1";
			this.buttonSetCustom1.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonSetCustom1.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonSetCustom1.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonSetCustom1.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonSetCustom1.Size = new System.Drawing.Size(80, 18);
			this.buttonSetCustom1.TabIndex = 143;
			this.buttonSetCustom1.Text = "Set Custom 1";
			this.buttonSetCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonSetCustom1.Toggleable = false;
			this.buttonSetCustom1.Toggled = false;
			this.buttonSetCustom1.Click += new System.EventHandler(this.SetCustom1);
			// 
			// buttonPlay
			// 
			this.buttonPlay.BorderOnHover = false;
			this.buttonPlay.DepressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.buttonPlay.DepressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonPlay.DepressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonPlay.FontType = CustomControls.Visuals.FontType.Bold;
			this.buttonPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPlay.Image = null;
			this.buttonPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlay.Location = new System.Drawing.Point(12, 12);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.OutlineColor = System.Drawing.Color.Transparent;
			this.buttonPlay.PressedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
			this.buttonPlay.PressedBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.buttonPlay.PressedBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.buttonPlay.Size = new System.Drawing.Size(80, 18);
			this.buttonPlay.TabIndex = 142;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPlay.Toggleable = false;
			this.buttonPlay.Toggled = false;
			this.buttonPlay.ButtonPressed += new System.EventHandler(this.PlaySong);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rctPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(388, 252);
			this.panel1.TabIndex = 142;
			// 
			// rctPanel1
			// 
			this.rctPanel1.Controls.Add(this.listViewSongs);
			this.rctPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rctPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.rctPanel1.Location = new System.Drawing.Point(3, 3);
			this.rctPanel1.Name = "rctPanel1";
			this.rctPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.rctPanel1.PanelBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.rctPanel1.PanelBorderColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.rctPanel1.PanelBorderColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
			this.rctPanel1.Size = new System.Drawing.Size(382, 246);
			this.rctPanel1.TabIndex = 141;
			// 
			// listViewSongs
			// 
			this.listViewSongs.AllowDrop = true;
			this.listViewSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
			this.listViewSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listViewSongs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSongs.FullRowSelect = true;
			listViewGroup3.Header = "Custom Music";
			listViewGroup3.Name = "customMusic";
			listViewGroup4.Header = "Music List";
			listViewGroup4.Name = "musicList";
			this.listViewSongs.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
			this.listViewSongs.HideSelection = false;
			this.listViewSongs.Location = new System.Drawing.Point(1, 1);
			this.listViewSongs.MultiSelect = false;
			this.listViewSongs.Name = "listViewSongs";
			this.listViewSongs.OwnerDraw = true;
			this.listViewSongs.Size = new System.Drawing.Size(380, 244);
			this.listViewSongs.SmallImageList = this.imageListPlaying;
			this.listViewSongs.TabIndex = 123;
			this.listViewSongs.TabStop = false;
			this.listViewSongs.UseCompatibleStateImageBehavior = false;
			this.listViewSongs.View = System.Windows.Forms.View.Details;
			this.listViewSongs.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListViewDrawColumnHeader);
			this.listViewSongs.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListViewDrawItem);
			this.listViewSongs.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListViewDrawSubItem);
			this.listViewSongs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SongChanged);
			this.listViewSongs.DragDrop += new System.Windows.Forms.DragEventHandler(this.SongDragDrop);
			this.listViewSongs.DragEnter += new System.Windows.Forms.DragEventHandler(this.SongDragEnter);
			this.listViewSongs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteSong);
			this.listViewSongs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SongDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 28;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Song Name";
			this.columnHeader2.Width = 264;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Time";
			this.columnHeader3.Width = 71;
			// 
			// imageListPlaying
			// 
			this.imageListPlaying.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPlaying.ImageStream")));
			this.imageListPlaying.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListPlaying.Images.SetKeyName(0, "NotPlayingIcon.png");
			this.imageListPlaying.Images.SetKeyName(1, "PlayingIcon.png");
			// 
			// dataBrowserDialog
			// 
			this.dataBrowserDialog.Description = "Data Folder Location";
			this.dataBrowserDialog.SelectedPath = "Environment.SpecialFolder.Desktop";
			this.dataBrowserDialog.ShowNewFolderButton = false;
			// 
			// MusicForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(489, 252);
			this.Controls.Add(this.splitContainerSideView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(380, 224);
			this.Name = "MusicForm";
			this.Text = "Trigger\'s Music Manager";
			this.Load += new System.EventHandler(this.OnFormLoad);
			this.splitContainerSideView.Panel1.ResumeLayout(false);
			this.splitContainerSideView.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSideView)).EndInit();
			this.splitContainerSideView.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.rctPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerSideView;
		private System.Windows.Forms.ListView listViewSongs;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.FolderBrowserDialog dataBrowserDialog;
		private RCTPanel rctPanel1;
		private RCTButton buttonPlay;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel1;
		private RCTButton buttonBrowse;
		private RCTButton buttonSetCustom2;
		private RCTButton buttonSetCustom1;
		private System.Windows.Forms.ImageList imageListPlaying;
		private RCTButton buttonAbout;
		private RCTButton buttonRefresh;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private RCTButton buttonRename;
	}
}

