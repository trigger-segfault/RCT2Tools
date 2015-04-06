using CustomControls;
using RCTDataEditor.DataObjects;
using RCTDataEditor.DataObjects.Types;
using RCTDataEditor.DataObjects.Types.AttractionInfo;
using RCTDataEditor.FileIO;
using RCTDataEditor.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RCTDataEditor {
	public partial class BrowserForm : Form {

		//========== CONSTANTS ===========
		#region Constants

		/** <summary> The list of tab names. </summary> */
		string[] tabList = new string[]{
			"Info",
			"All",
			"Attractions",
			"SmallScenery",
			"LargeScenery",
			"Walls",
			"Signs",
			"Paths",
			"PathAdditions",
			"SceneryGroups",
			"ParkEntrances",
			"Water",
			"Settings"
		};
		/** <summary> The list of real tab names. </summary> */
		string[] tabNames = new string[]{
			"Information",
			"All",
			"Attractions",
			"Small Scenery",
			"Large Scenery",
			"Walls",
			"Banners",
			"Paths",
			"Path Additions",
			"Scenery Groups",
			"Park Entrances",
			"Water",
			"Settings",
			"About"
		};

		#endregion
		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The default directory to start in. </summary> */
		string defaultDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\ObjData";
		/** <summary> The default number of objects to load per tick. </summary> */
		int objectsPerTick = 50;
		/** <summary> True if the image view should have remap options. </summary> */
		bool remapImageView = false;
		/** <summary> True if files are allowed to be deleted. </summary> */
		bool allowDeletion = false;
		/** <summary> True if files are backed up after being deleted. </summary> */
		bool backupDeletion = true;

		#endregion
		//--------------------------------
		#region Objects

		/** <summary> The current object being viewed. </summary> */
		ObjectData objectData;
		/** <summary> The index of the object in the file directory. </summary> */
		int objectIndex = 0;
		/** <summary> The rotation of the object view. </summary> */
		int rotation = 0;
		/** <summary> The slope of the object view. </summary> */
		int slope = -1;
		/** <summary> The corner of the object view. </summary> */
		int corner = 0;
		/** <summary> The elevation of the object view. </summary> */
		int elevation = 0;
		/** <summary> The connections of the current path. </summary> */
		uint pathConnections = 0x00000000;
		/** <summary> True if the queue path is being drawn. </summary> */
		bool queue = false;
		/** <summary> The frame of the object view. </summary> */
		int frame = 0;
		/** <summary> True if only viewing a dialog image. </summary> */
		bool dialogView = false;
		/** <summary> True if only viewing a single image. </summary> */
		bool imageView = false;
		/** <summary> The current color being remapped. </summary> */
		int colorRemap = 0;
		/** <summary> The image to draw the object to. </summary> */
		Image objectImage;

		#endregion
		//--------------------------------
		#region Tabs

		/** <summary> The name of the current tab. </summary> */
		string currentTab = "Info";
		/** <summary> The current list containing the object. </summary> */
		string currentList;
		/** <summary> The list of tab sort columns. </summary> */
		int[] currentColumn = new int[]{
			0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0
		};
		/** <summary> The list of tab solumn sort orders. </summary> */
		bool[] currentListOrder = new bool[]{
			false, false, false, false, false, false, false, false, false, false, false, false, false, false
		};

		#endregion
		//--------------------------------
		#region Scanning

		/** <summary> The start time of the scan. </summary> */
		DateTime scanStart;
		/** <summary> The current directory. </summary> */
		string directory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\ObjData";
		/** <summary> The list of files to load. </summary> */
		string[] files = null;
		/** <summary> The index of the next file in the list to load. </summary> */
		int fileIndex = 0;

		#endregion
		//--------------------------------
		#region Extracting

		/** <summary> The start time of the extraction. </summary> */
		DateTime extractStart;
		/** <summary> The index of the next image in the list to extract. </summary> */
		int extractIndex = 0;
		/** <summary> The object used for extracting. </summary> */
		ObjectData extractObject = null;

		#endregion
		//--------------------------------
		#region Other

		/** <summary> The sbold RCT sprite font. </summary> */
		SpriteFont fontBold;
		/** <summary> The palette buttons. </summary> */
		Button[] paletteButtons;
		/** <summary> The image lists for the palette buttons. </summary> */
		ImageList[] paletteImageLists;

		AboutBox aboutForm = new AboutBox();

		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public BrowserForm(string[] args) {
			InitializeComponent();

			Pathing.SetPathSprites();

			this.fontBold = new SpriteFont(Resources.BoldFont, ' ', 'z', 10);

			this.labelCurrentObject.Text = "";
			this.labelImageSize.Text = "";
			this.labelImageOffset.Text = "";

			this.currentList = "";

			this.objectImage = new Bitmap(190, 254);

			this.defaultDirectory = "";
			string[] possibleDirectories = {
				"%PROGRAMFILES%\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\ObjData",
				"%PROGRAMFILES%\\Infogrames\\Rollercoaster Tycoon 2\\ObjData",
				"%PROGRAMFILES%\\Atari\\Rollercoaster Tycoon 2\\ObjData",
				"%PROGRAMFILES(x86)%\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\ObjData",
				"%PROGRAMFILES(x86)%\\Infogrames\\Rollercoaster Tycoon 2\\ObjData",
				"%PROGRAMFILES(x86)%\\Atari\\Rollercoaster Tycoon 2\\ObjData",
				"%USERPROFILE%\\Desktop"
			};

			for (int i = 0; i < possibleDirectories.Length; i++) {
				if (Directory.Exists(Environment.ExpandEnvironmentVariables(possibleDirectories[i]))) {
					this.defaultDirectory = Environment.ExpandEnvironmentVariables(possibleDirectories[i]);
					break;
				}
			}
			this.textBoxDirectory.Text = this.defaultDirectory;

			this.LoadSettings(null, null);

			this.directory = this.defaultDirectory;


			#region Palette Buttons
			Bitmap paletteButton = Resources.PaletteButton;
			Bitmap paletteButtonPressed = Resources.PaletteButtonPressed;
			PaletteImage paleteButtonImage = new PaletteImage(12, 12);
			PaletteImage paleteButtonPressedImage = new PaletteImage(12, 12);

			for (int x = 0; x < 12; x++) {
				for (int y = 0; y < 12; y++) {
					Color c = paletteButton.GetPixel(x, y);
					for (int i = 0; i < 12; i++) {
						if (c == Palette.DefaultPalette.Colors[10 + i]) {
							paleteButtonImage.Pixels[x, y] = (byte)(243 + i);
							break;
						}
					}
					c = paletteButtonPressed.GetPixel(x, y);
					for (int i = 0; i < 12; i++) {
						if (c == Palette.DefaultPalette.Colors[10 + i]) {
							paleteButtonPressedImage.Pixels[x, y] = (byte)(243 + i);
							break;
						}
					}
				}
			}
			this.paletteButtons = new Button[32];
			this.paletteImageLists = new ImageList[32];
			//for (int i = 31; i >= 0; i--) {
			for (int i = 0; i < 32; i++) {
				ImageList imageList = new ImageList(this.components);
				imageList.ColorDepth = ColorDepth.Depth24Bit;
				imageList.TransparentColor = Color.Transparent;
				imageList.ImageSize = new Size(12, 12);
				imageList.Images.Add("PaletteButton", paleteButtonImage.CreateImage(Palette.DefaultPalette, i, -1, -1));
				imageList.Images.Add("PaletteButtonPressed", paleteButtonPressedImage.CreateImage(Palette.DefaultPalette, i, -1, -1));
				imageList.Images.Add("PaletteButtonPressed2", paleteButtonPressedImage.CreateImage(Palette.DefaultPalette, i, -1, -1));

				Button button = new Button();

				button.BackColor = Color.FromArgb(79, 135, 95);
				button.FlatAppearance.BorderColor = Color.FromArgb(79, 135, 95);
				button.FlatAppearance.BorderSize = 0;
				button.FlatAppearance.MouseDownBackColor = Color.FromArgb(79, 135, 95);
				button.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 135, 95);
				button.FlatStyle = FlatStyle.Flat;
				button.ImageIndex = 0;
				button.ImageList = imageList;
				button.Location = new Point((i % 8) * 12 + 1, (i / 8) * 12 + 1);
				button.Name = "buttonPaletteRemap" + (i + 1);
				button.Size = new Size(13, 13);
				button.TabIndex = 300 + i;
				button.TabStop = false;
				button.UseVisualStyleBackColor = true;
				button.Click += new EventHandler(this.SelectRemapColor);
				button.MouseDown += new MouseEventHandler(this.ButtonDown);
				button.MouseLeave += new EventHandler(this.ButtonLeave);
				button.MouseMove += new MouseEventHandler(this.ButtonHover);
				button.MouseUp += new MouseEventHandler(this.ButtonUp);

				this.panelColorPalette.Controls.Add(button);
				this.paletteButtons[i] = button;
				this.paletteImageLists[i] = imageList;
			}
			this.buttonRemap1.ImageList = this.paletteImageLists[GraphicsData.ColorRemap1];
			this.buttonRemap2.ImageList = this.paletteImageLists[GraphicsData.ColorRemap2];
			this.buttonRemap3.ImageList = this.paletteImageLists[GraphicsData.ColorRemap3];
			#endregion

			if (args.Length > 0) {
				this.directory = Path.GetDirectoryName(args[0]);
				this.objectData = ObjectData.ReadObject(args[0]);
				this.UpdateImages();
				this.UpdateColorRemap();
				this.UpdateInfo();

				string name = "Info";
				currentTab = "Info";
				this.labelObjectsInGroup.Text = tabNames[GetTabIndex(name)];

				this.tabInfo.ToggleTab();

				this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));
			}

			Attraction o;

			/*o = (Attraction)ObjectData.ReadObject(this.directory + "\\ZLOG.DAT");
			o.Source = SourceTypes.Custom;
			o.Header.Flags &= ~(AttractionFlags.DisableShuttleMode);
			o.StringTable.Entries[0][Languages.British] = "ALog2";
			o.StringTable.Entries[0][Languages.American] = "ALog2";
			o.ObjectHeader.FileName = "ZLOG2";
			ObjectData.WriteObject("ZLOG2.DAT", o);*/
			/*o = (Attraction)ObjectData.ReadObject(this.directory + "\\ARRX.DAT");
			o.Source = SourceTypes.Custom;
			o.Header.CarTypeList[0].Flags &= ~CarFlags.Invertable2;
			o.StringTable.Entries[0][Languages.British] = "AMulti3";
			o.StringTable.Entries[0][Languages.American] = "AMulti3";
			o.ObjectHeader.FileName = "ARRX3";
			ObjectData.WriteObject("ARRX3.DAT", o);*/
			/*o = (Attraction)ObjectData.ReadObject(this.directory + "\\DING1.DAT");
			o.Source = SourceTypes.Custom;
			o.Header.CarTypeList[0].Flags |= CarFlags.SwingingMoreFrames;
			o.Header.CarTypeList[0].CarBehavior = CarBehaviors.Default;
			o.StringTable.Entries[0][Languages.British] = "ADing2";
			o.StringTable.Entries[0][Languages.American] = "ADing2";
			o.ObjectHeader.FileName = "DING12";
			ObjectData.WriteObject("DING12.DAT", o);
			o = (Attraction)ObjectData.ReadObject(this.directory + "\\INTBOB.DAT");
			o.Source = SourceTypes.Custom;
			o.Header.CarTypeList[0].Flags &= ~CarFlags.SwingingMoreFrames;
			o.StringTable.Entries[0][Languages.British] = "ATurns2";
			o.StringTable.Entries[0][Languages.American] = "ATurns2";
			o.ObjectHeader.FileName = "INTBOB2";
			ObjectData.WriteObject("INTBOB2.DAT", o);*/
		}

		private void SavePieces(Attraction o, ulong basePieces, ulong pieces, string name) {
			o.Source = SourceTypes.Custom;
			o.ObjectHeader.FileName = name;
			o.StringTable.Entries[0][Languages.British] = "A (" + pieces.ToString("X16") + ")";
			o.StringTable.Entries[0][Languages.American] ="A (" + pieces.ToString("X16") + ")";
			o.Header.AvailableTrackSections = (TrackSections)(basePieces | pieces);
			ObjectData.WriteObject(name + ".DAT", o);
		}

		#endregion
		//=========== LOADING ============
		#region Loading

		/** <summary> Called when the form loads. </summary> */
		private void OnFormLoad(object sender, EventArgs e) {
			SetFeatureToAllControls(this.Controls);
		}
		/** <summary> Called to load the settings file. </summary> */
		private void LoadSettings(object sender, EventArgs e) {
			string pathToSettings = Path.Combine(Path.GetDirectoryName (Assembly.GetEntryAssembly().Location), "Settings.xml");
			if (File.Exists(pathToSettings)) {
				XmlDocument doc = new XmlDocument();
				doc.Load(pathToSettings);
				XmlNodeList element;

				element = doc.GetElementsByTagName("DefaultDirectory");
				if (element.Count != 0) this.defaultDirectory = element[0].InnerText;

				element = doc.GetElementsByTagName("ObjectsPerTick");
				if (element.Count != 0) this.objectsPerTick = Int32.Parse(element[0].InnerText);

				element = doc.GetElementsByTagName("QuickLoad");
				if (element.Count != 0) Attraction.QuickLoad = Boolean.Parse(element[0].InnerText);

				element = doc.GetElementsByTagName("RemapImage");
				if (element.Count != 0) this.remapImageView = Boolean.Parse(element[0].InnerText);

				element = doc.GetElementsByTagName("AllowDeletion");
				if (element.Count != 0) this.allowDeletion = Boolean.Parse(element[0].InnerText);

				element = doc.GetElementsByTagName("BackupDeletion");
				if (element.Count != 0) this.backupDeletion = Boolean.Parse(element[0].InnerText);

				this.textBoxDirectory.Text = this.defaultDirectory;
				this.numericUpDownObjectsPerTick.Value = this.objectsPerTick;
				this.checkBoxQuickLoad.CheckState = (Attraction.QuickLoad ? CheckState.Checked : CheckState.Unchecked);
				this.checkBoxRemapImage.CheckState = (this.remapImageView ? CheckState.Checked : CheckState.Unchecked);
				this.checkBoxAllowDeletions.CheckState = (this.allowDeletion ? CheckState.Checked : CheckState.Unchecked);
				this.checkBoxBackupDeletions.CheckState = (this.backupDeletion ? CheckState.Checked : CheckState.Unchecked);
			}
			else {
				SaveSettings(null, null);
			}
		}
		/** <summary> Called to save the settings file. </summary> */
		private void SaveSettings(object sender, EventArgs e) {
			XmlDocument doc = new XmlDocument();
			doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));

			XmlElement settings = doc.CreateElement("Settings");
			doc.AppendChild(settings);

			XmlElement element = doc.CreateElement("DefaultDirectory");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.defaultDirectory));

			element = doc.CreateElement("ObjectsPerTick");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.objectsPerTick.ToString()));

			element = doc.CreateElement("QuickLoad");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(Attraction.QuickLoad.ToString()));

			element = doc.CreateElement("RemapImage");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.remapImageView.ToString()));

			element = doc.CreateElement("AllowDeletion");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.allowDeletion.ToString()));

			element = doc.CreateElement("BackupDeletion");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.backupDeletion.ToString()));

			doc.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings.xml"));
		}
		/** <summary> Called when the browse default button is pressed. </summary> */
		private void BrowseDefaultDirectory(object sender, EventArgs e) {
			this.objDataBrowserDialog.SelectedPath = this.directory;
			if (this.objDataBrowserDialog.ShowDialog() == DialogResult.OK) {
				this.defaultDirectory = this.objDataBrowserDialog.SelectedPath;
				this.textBoxDirectory.Text = this.defaultDirectory;
			}
		}
		/** <summary> Called when the browse default button is pressed. </summary> */
		private void ObjectsPerTickChanged(object sender, EventArgs e) {
			this.objectsPerTick = (int)(sender as NumericUpDown).Value;
		}
		/** <summary> Loads objects from the directory every tick. </summary> */
		private void LoadObjects(object sender, EventArgs e) {
			int count = 0;
			for (int i = fileIndex; i < files.Length && count < objectsPerTick; i++, fileIndex++, count++) {
				if (files[i].EndsWith(".DAT", true, CultureInfo.DefaultThreadCurrentCulture)) {
					ObjectDataInfo info = ObjectData.ReadObjectInfo(files[i], true);
					if (!info.Invalid) {
						
						ListViewItem item = new ListViewItem();
						item.ImageIndex = 1;
						if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
						else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Source.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(files[i])));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Name));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Type.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Subtype.ToString()));
						this.tabGroupAll.Items.Add(item);

						item = new ListViewItem();
						item.ImageIndex = 1;
						if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
						else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Source.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(files[i])));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Name));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Type.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Subtype.ToString()));

						if (info.Type == ObjectTypes.Attraction)
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (info.Header as AttractionHeader).TrackType.ToString()));

						switch (info.Type) {
						case ObjectTypes.Attraction: this.tabGroupAttractions.Items.Add(item); break;
						case ObjectTypes.SmallScenery: this.tabGroupSmallScenery.Items.Add(item); break;
						case ObjectTypes.LargeScenery: this.tabGroupLargeScenery.Items.Add(item); break;
						case ObjectTypes.Wall: this.tabGroupWalls.Items.Add(item); break;
						case ObjectTypes.PathBanner: this.tabGroupSigns.Items.Add(item); break;
						case ObjectTypes.Path: this.tabGroupPaths.Items.Add(item); break;
						case ObjectTypes.PathAddition: this.tabGroupPathAdditions.Items.Add(item); break;
						case ObjectTypes.SceneryGroup: this.tabGroupSceneryGroups.Items.Add(item); break;
						case ObjectTypes.ParkEntrance: this.tabGroupParkEntrances.Items.Add(item); break;
						case ObjectTypes.Water: this.tabGroupWater.Items.Add(item); break;
						}
					}
					else {
						ListViewItem item = new ListViewItem();
						item.ForeColor = Color.FromArgb(200, 0, 0);
						//item.Font = new Font(item.Font, FontStyle.Bold);
						item.ImageIndex = 3;
						if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
						else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(files[i])));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						this.tabGroupAll.Items.Add(item);
					}
				}
			}
			if (fileIndex >= files.Length) {
				this.labelScanProgress.Text = "Scan Finished - Took " + Math.Round((DateTime.Now - this.scanStart).TotalSeconds) + " seconds";
				this.timerLoadObjects.Stop();
			}
			else {
				//this.labelScanStatus.Text = "Scanning - " + Math.Round((double)fileIndex / (double)files.Length * 100.0) + "%";
				this.labelScanProgress.Text = "Scanning - " + Math.Round((double)fileIndex / (double)files.Length * 100.0) + "%";
			}
			this.labelObjectsScanned.Text = "Objects Scanned: " + fileIndex;
			if (currentTab != "Info" && currentTab != "Settings" && currentTab != "About")
				this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)] + ": " + (this.Controls.Find("tabGroup" + currentTab, true)[0] as ListView).Items.Count;
			else
				this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)];
		}

		#endregion
		//=========== SORTING ============
		#region Sorting

		/** <summary> The class used to sort the columns. </summary> */
		class ListViewItemComparer : IComparer {
			private int col;
			private bool reverse;
			public ListViewItemComparer() {
				this.col = 0;
			}
			public ListViewItemComparer(int column, bool reverse = false) {
				this.col = column;
				this.reverse = reverse;
			}
			public int Compare(object x, object y) {
				return String.Compare(((ListViewItem)(reverse ? y : x)).SubItems[col].Text, ((ListViewItem)(reverse ? x : y)).SubItems[col].Text);
			}
		}
		/** <summary> Sorts the specified column. </summary> */
		private void ColumnSort(object sender, ColumnClickEventArgs e) {
			if (e.Column != 0) {
				string name = (sender as ListView).Name.Replace("tabGroup", "");
				int index = 0;
				//Console.WriteLine(name);
				for (int i = 0; i < tabList.Length; i++) {
					if (tabList[i] == name) {
						index = i;
						break;
					}
				}
				//Console.WriteLine(index);
				//Console.WriteLine(GetTabIndex(name));
				if (e.Column == currentColumn[index]) {
					currentListOrder[index] = !currentListOrder[index];
				}
				else {
					currentColumn[index] = e.Column;
					currentListOrder[index] = false;
				}
				//Console.WriteLine("Sort");
				//currentListColumn = e.Column;
				//listSortOrder = currentListOrder[index];
				(sender as ListView).ListViewItemSorter = new ListViewItemComparer(e.Column, currentListOrder[index]);
				(sender as ListView).Refresh();
			}
		}
		
		/** <summary> Called when the browse button is pressed. </summary> */
		private void BrowseDirectory(object sender, EventArgs e) {
			this.objDataBrowserDialog.SelectedPath = this.directory;

			if (this.objDataBrowserDialog.ShowDialog() == DialogResult.OK) {
				this.directory = this.objDataBrowserDialog.SelectedPath;

				this.tabGroupInfo.Items.Clear();
				for (int i = 1; i < this.tabList.Length; i++) {
					if (tabList[i] != "Settings")
						(this.Controls.Find("tabGroup" + this.tabList[i], true)[0] as ListView).Items.Clear();
				}

				this.objectData = null;
				this.objectIndex = 0;

				this.UpdateImages();
				this.UpdateInfo();

				this.timerLoadObjects.Stop();
				this.scrollBarImage.Enabled = false;
				this.scrollBarImage.Visible = false;
				this.labelImageSize.Text = "";
				this.labelImageOffset.Text = "";

				this.files = Directory.GetFiles(directory);
				this.fileIndex = 0;
				this.labelScanProgress.Text = "Ready to Scan";
				this.labelObjectsScanned.Text = "Objects Scanned: 0";
				if (currentTab != "Info" && currentTab != "Settings" && currentTab != "About")
					this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)] + ": " + (this.Controls.Find("tabGroup" + currentTab, true)[0] as ListView).Items.Count;
				else
					this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)];
			}
		}

		/** <summary> Called when the scan button is pressed. </summary> */
		private void StartScan(object sender, EventArgs e) {
			if (!this.timerLoadObjects.Enabled && !this.timerExtract.Enabled) {
				this.tabGroupInfo.Items.Clear();
				for (int i = 1; i < this.tabList.Length; i++) {
					if (tabList[i] != "Settings")
						(this.Controls.Find("tabGroup" + this.tabList[i], true)[0] as ListView).Items.Clear();
				}
				this.scrollBarImage.Enabled = false;
				this.scrollBarImage.Visible = false;
				this.labelImageSize.Text = "";
				this.labelImageOffset.Text = "";

				this.objectData = null;
				this.objectIndex = 0;

				this.UpdateImages();
				this.UpdateInfo();

				try {
					this.files = Directory.GetFiles(directory);
					this.fileIndex = 0;
					//this.labelScanStatus.Text = "Ready to Scan";
					this.labelScanProgress.Text = "Ready to Scan";
					this.labelObjectsScanned.Text = "Objects Scanned: 0";
					if (currentTab != "Info" && currentTab != "Settings" && currentTab != "About")
						this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)] + ": " + (this.Controls.Find("tabGroup" + currentTab, true)[0] as ListView).Items.Count;
					else
						this.labelObjectsInGroup.Text = tabNames[GetTabIndex(currentTab)];

					this.timerLoadObjects.Start();
					this.scanStart = DateTime.Now;
				}
				catch (Exception) {
					this.labelObjectsInGroup.Text = "Please select directory";
				}
			}
		}

		#endregion
		//============= TABS =============
		#region Tabs

		/** <summary> Called when a tab is switched to. </summary> */
		private void TabDown(object sender, MouseEventArgs e) {
			string name = (sender as RCTTabButton).Name.Replace("tab", "");
			currentTab = name;

			this.ActiveControl = (sender as RCTTabButton).TabPage;


			if (currentTab != "Info" && currentTab != "Settings" && currentTab != "About") {
				this.labelObjectsInGroup.Text = tabNames[GetTabIndex(name)] + ": " + (this.Controls.Find("tabGroup" + currentTab, true)[0] as ListView).Items.Count;
				//(sender as RCTTabButton).TabPage.Refresh();
			}
			else
				this.labelObjectsInGroup.Text = tabNames[GetTabIndex(name)];
		}
		/** <summary> Called when an object is selected from the list. </summary> */
		private void ObjectChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
			string name = (sender as ListView).Name.Replace("tabGroup", "");
			int index = 0;
			for (int i = 0; i < tabList.Length; i++) {
				if (tabList[i] == name) {
					index = i;
					break;
				}
			}
			if (e.Item.Selected && ((sender as ListView).SelectedItems.Count == 0 || (sender as ListView).SelectedItems[0] == e.Item)) {
				currentList = name;
				objectIndex = e.ItemIndex;
				objectData = ObjectData.ReadObject(Path.Combine(directory, e.Item.SubItems[2].Text));
				this.frame = 0;
				Attraction.CurrentCar = 0;
				Attraction.CarRotationFrame = 0;
				this.UpdateImages(); this.UpdateInfo(); this.UpdateColorRemap();
				this.labelCurrentObject.Text = (objectData != null ? objectData.ObjectHeader.FileName + ".DAT" : "");
				if (objectData == null) {
					this.labelCurrentObject.Text =  "";
					this.scrollBarImage.Enabled = false;
					this.scrollBarImage.Visible = false;
					this.labelImageSize.Text = "";
					this.labelImageOffset.Text = "";
				}
				else {
					this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));

					if (this.imageView && objectData.ImageDirectory.Entries.Count > 0) {
						this.labelImageSize.Text = "Image Size:  " + objectData.ImageDirectory.Entries[0].Width + ", " + objectData.ImageDirectory.Entries[frame].Height + "";
						this.labelImageOffset.Text = "Image Offset:  " + objectData.ImageDirectory.Entries[0].XOffset + ", " + objectData.ImageDirectory.Entries[frame].YOffset + "";
					}

					if (this.imageView && objectData.ImageDirectory.Count > 1) {
						this.scrollBarImage.Enabled = true;
						this.scrollBarImage.Visible = true;
						this.scrollBarImage.Maximum = objectData.ImageDirectory.Count - 1;
						this.scrollBarImage.Value = 0;
					}
					else {
						this.scrollBarImage.Enabled = false;
						this.scrollBarImage.Visible = false;
					}
				}
				
			}
		}
		/** <summary> Called when an object is dragged from the list. </summary> */
		private void ObjectDrag(object sender, ItemDragEventArgs e) {
			string name = (sender as ListView).Name.Replace("tabGroup", "");
			ListView listView = sender as ListView;

			string[] files = new string[listView.SelectedItems.Count];
			for (int i = 0; i < listView.SelectedItems.Count; i++) {
				files[i] = Path.GetFullPath(directory + "/" + listView.SelectedItems[i].SubItems[2].Text);
			}

			if (files.Length != 0) {
				DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
			}
		}
		/** <summary> Cets the index of the tab name. </summary> */
		private int GetTabIndex(string name) {
			for (int i = 0; i < tabList.Length; i++) {
				if (tabList[i] == name)
					return i;
			}
			return 0;
		}

		#endregion
		//========== REMAPPING ===========
		#region Remapping

		/** <summary> Changes the remapped color to the selected color. </summary> */
		private void ChangeRemap(object sender, EventArgs e) {
			string name = (sender as Button).Name.Replace("buttonRemap", "");
			int newRemap = Int32.Parse(name);
			if (newRemap == colorRemap) {
				this.colorRemap = 0;
				this.panelColorPalette.Visible = false;
			}
			else {
				this.colorRemap = newRemap;
				this.panelColorPalette.Location = new Point(
					(sender as Button).Location.X - this.panelColorPalette.Width + 13,
					(sender as Button).Location.Y + 13
				);
				this.panelColorPalette.Visible = true;
			}
		}
		/** <summary> Changes the remapped color to the third color. </summary> */
		private void SelectRemapColor(object sender, EventArgs e) {
			string name = (sender as Button).Name.Replace("buttonPaletteRemap", "");
			int index = Int32.Parse(name) - 1;
			(Controls.Find("buttonRemap" + colorRemap, true)[0] as Button).ImageList = paletteImageLists[index];
			switch (colorRemap) {
			case 1: GraphicsData.ColorRemap1 = index; break;
			case 2: GraphicsData.ColorRemap2 = index; break;
			case 3: GraphicsData.ColorRemap3 = index; break;
			}

			panelColorPalette.Visible = false;
			colorRemap = 0;
			UpdateImages();
		}

		#endregion
		//=========== BUTTONS ============
		#region Buttons

		/** <summary> Called when the delete button is pressed. </summary> */
		private void TabGroupDeleteSelection(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete && allowDeletion) {
				DeleteObject(sender, e);
			}
		}
		/** <summary> Deletes the selected object. </summary> */
		private void DeleteObject(object sender, EventArgs e) {
			ListView currentListView = (this.Controls.Find("tabGroup" + currentList, true)[0] as ListView); 
			if (currentListView.SelectedItems.Count != 0) {
				DialogResult result = DeleteMessageBox.Show(this, (currentListView.SelectedItems.Count > 1 ? "[multiple objects]" : currentListView.SelectedItems[0].SubItems[2].Text));
				bool error = false;
				if (result == DialogResult.Yes) {
					string backupDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Deleted Objects");
					if (backupDeletion && !Directory.Exists(backupDirectory))
						Directory.CreateDirectory(backupDirectory);
					for (int j = currentListView.SelectedItems.Count - 1; j >= 0; j--) {
						try {
							if (currentListView.SelectedItems[j].SubItems.Count <= 2)
								continue;
							if (currentListView.SelectedItems[j].SubItems[1].Text != "Custom" && currentListView.SelectedItems[j].SubItems[1].Text != "")
								continue;
							string fileName = currentListView.SelectedItems[j].SubItems[2].Text;

							if (backupDeletion)
								File.Move(Path.Combine(this.directory, fileName), Path.Combine(backupDirectory, fileName));
							else
								File.Delete(Path.Combine(this.directory, fileName));

							for (int i = 0; i < this.tabGroupAll.Items.Count; i++) {
								if (this.tabGroupAll.Items[i].SubItems.Count > 2) {
									if (fileName == this.tabGroupAll.Items[i].SubItems[2].Text) {
										this.tabGroupAll.Items.RemoveAt(i);
									}
								}
							}
							ListView listView = this.tabGroupAttractions;
							for (int k = 0; k < 10; k++) {
								switch ((ObjectTypes)k) {
								case ObjectTypes.Attraction: listView = this.tabGroupAttractions; break;
								case ObjectTypes.SmallScenery: listView = this.tabGroupSmallScenery; break;
								case ObjectTypes.LargeScenery: listView = this.tabGroupLargeScenery; break;
								case ObjectTypes.Wall: listView = this.tabGroupWalls; break;
								case ObjectTypes.PathBanner: listView = this.tabGroupSigns; break;
								case ObjectTypes.Path: listView = this.tabGroupPaths; break;
								case ObjectTypes.PathAddition: listView = this.tabGroupPathAdditions; break;
								case ObjectTypes.SceneryGroup: listView = this.tabGroupSceneryGroups; break;
								case ObjectTypes.ParkEntrance: listView = this.tabGroupParkEntrances; break;
								case ObjectTypes.Water: listView = this.tabGroupWater; break;
								}
								for (int i = 0; i < listView.Items.Count; i++) {
									if (listView.Items[i].SubItems.Count > 2) {
										if (fileName == listView.Items[i].SubItems[2].Text) {
											listView.Items.RemoveAt(i);
										}
									}
								}
							}
						}
						catch (Exception) {
							error = true;
						}
					}
				}
				if (error) {
					ErrorForm.Show(this, "Error deleting object file!", "You may need to run as administrator.");
				}
			}
		}
		/** <summary> Opens the about window. </summary> */
		private void OpenAboutForm(object sender, EventArgs e) {
			if (aboutForm.IsDisposed)
				aboutForm = new AboutBox();
			aboutForm.ShowDialog(this);
		}
		/** <summary> Changes the quick load setting. </summary> */
		private void QuickLoadAttractions(object sender, EventArgs e) {
			Attraction.QuickLoad = (sender as RCTCheckBox).CheckState == CheckState.Checked;
		}
		/** <summary> Changes the remap image view setting. </summary> */
		private void RemapImageView(object sender, EventArgs e) {
			this.remapImageView = (sender as RCTCheckBox).CheckState == CheckState.Checked;
			this.UpdateColorRemap();
		}
		/** <summary> Changes the allow deletions setting. </summary> */
		private void AllowDeletions(object sender, EventArgs e) {
			this.allowDeletion = (sender as RCTCheckBox).CheckState == CheckState.Checked;
		}
		/** <summary> Changes the backup deletions setting. </summary> */
		private void BackupDeletions(object sender, EventArgs e) {
			this.backupDeletion = (sender as RCTCheckBox).CheckState == CheckState.Checked;
		}
		/** <summary> Changes the dialog view. </summary> */
		private void DialogView(object sender, EventArgs e) {
			this.dialogView = (sender as RCTCheckBox).CheckState == CheckState.Checked;
			this.frame = 0;
			if (this.checkBoxImageView.CheckState == CheckState.Checked) {
				this.imageView = false;
				this.checkBoxImageView.CheckState = CheckState.Unchecked;
			}
			if (objectData != null && !objectData.Invalid) {
				this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));
				this.UpdateImages();
			}
			this.scrollBarImage.Enabled = false;
			this.scrollBarImage.Visible = false;
			this.labelImageSize.Text = "";
			this.labelImageOffset.Text = "";
			this.UpdateColorRemap();
		}
		/** <summary> Changes the frame view. </summary> */
		private void FrameView(object sender, EventArgs e) {
			this.imageView = (sender as RCTCheckBox).CheckState == CheckState.Checked;
			this.frame = 0;
			if (this.checkBoxDialogView.CheckState == CheckState.Checked) {
				this.dialogView = false;
				this.checkBoxDialogView.CheckState = CheckState.Unchecked;
			}
			if (objectData != null && !objectData.Invalid) {
				this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));
				this.UpdateImages();
				if (this.imageView && objectData.ImageDirectory.Count > 1) {
					this.scrollBarImage.Enabled = true;
					this.scrollBarImage.Visible = true;
					this.scrollBarImage.Maximum = objectData.ImageDirectory.Count - 1;
					this.scrollBarImage.Value = 0;
				}
				else {
					this.scrollBarImage.Enabled = false;
					this.scrollBarImage.Visible = false;
				}
				if (this.imageView) {
					this.labelImageSize.Text = "Image Size:  " + objectData.ImageDirectory.Entries[frame].Width + ", " + objectData.ImageDirectory.Entries[frame].Height + "";
					this.labelImageOffset.Text = "Image Offset:  " + objectData.ImageDirectory.Entries[frame].XOffset + ", " + objectData.ImageDirectory.Entries[frame].YOffset + "";
				}
				else {
					this.labelImageSize.Text = "";
					this.labelImageOffset.Text = "";
				}
			}
			else {
				this.scrollBarImage.Enabled = false;
				this.scrollBarImage.Visible = false;
				this.labelImageSize.Text = "";
				this.labelImageOffset.Text = "";
			}
			this.UpdateColorRemap();
		}

		/** <summary> Rotates the object. </summary> */
		private void RotateObject(object sender, EventArgs e) {
			this.rotation++;
			if (rotation > 3) rotation = 0;

			bool validQueueConnection = true;
			do {
				this.pathConnections += 1;
				if (this.pathConnections >= 256)
					this.pathConnections = 0;
				if ((this.pathConnections & 0x0F) == this.pathConnections)
					validQueueConnection = true;
				int dirCount = 0;
				for (int i = 0; i < 4; i++) {
					if ((this.pathConnections & (1 << i)) != 0)
						dirCount++;
				}
				if (dirCount > 2)
					validQueueConnection = false;
			} while (!Pathing.PathSpriteIndexes.ContainsKey(this.pathConnections) || (this.queue && !validQueueConnection));
			Pathing.PathConnections = this.pathConnections;
			if (objectData is Attraction) {
				Attraction.CarRotationFrame = (Attraction.CarRotationFrame + 1) % (objectData as Attraction).RotationFrames;
			}
			this.UpdateImages();
		}
		/** <summary> Rotates the slope. </summary> */
		private void RotateSlope(object sender, EventArgs e) {
			this.slope++;
			if (slope > 3) slope = -1;
			this.UpdateImages();
		}
		/** <summary> Rotates the corner. </summary> */
		private void RotateCorner(object sender, EventArgs e) {
			this.corner++;
			if (corner > 3) corner = 0;
			this.queue = !this.queue;
			Pathing.Queue = this.queue;
			if (this.queue) {
				bool validQueueConnection = false;
				if ((this.pathConnections & 0x0F) == this.pathConnections)
					validQueueConnection = true;
				int dirCount = 0;
				for (int i = 0; i < 4; i++) {
					if ((this.pathConnections & (1 << i)) != 0)
						dirCount++;
				}
				if (dirCount > 2)
					validQueueConnection = false;
				while (!Pathing.PathSpriteIndexes.ContainsKey(this.pathConnections) || (this.queue && !validQueueConnection)) {
					this.pathConnections += 1;
					if (this.pathConnections >= 256)
						this.pathConnections = 0;
					if ((this.pathConnections & 0x0F) == this.pathConnections)
						validQueueConnection = true;
					dirCount = 0;
					for (int i = 0; i < 4; i++) {
						if ((this.pathConnections & (1 << i)) != 0)
							dirCount++;
					}
					if (dirCount > 2)
						validQueueConnection = false;
				}
				Pathing.PathConnections = this.pathConnections;
			}
			if (objectData is Attraction) {
				Attraction.CurrentCar = (Attraction.CurrentCar + 1) % (objectData as Attraction).Header.CarCount;
				this.UpdateColorRemap();
			}

			this.UpdateImages();
		}
		/** <summary> Changes the elevation. </summary> */
		private void ChangeElevation(object sender, EventArgs e) {
			if (this.elevation == 16)
				this.elevation = 0;
			else
				this.elevation = 16;

			this.UpdateImages();
		}
		/** <summary> Switches to the previous object. </summary> */
		private void PreviousObject(object sender, EventArgs e) {
			if (currentList != "") {
				ListView list = (this.Controls.Find("tabGroup" + currentList, true)[0] as ListView);
				while (list.SelectedItems.Count != 0) {
					list.SelectedItems[0].Selected = false;
				}
				objectIndex--;
				Attraction.CurrentCar = 0;
				Attraction.CarRotationFrame = 0;
				if (objectIndex < 0)
					objectIndex = list.Items.Count - 1;
				list.Items[objectIndex].Selected = true;
				list.Select();
			}
		}
		/** <summary> Switches to the next object. </summary> */
		private void NextObject(object sender, EventArgs e) {
			if (currentList != "") {
				ListView list = (this.Controls.Find("tabGroup" + currentList, true)[0] as ListView);
				while (list.SelectedItems.Count != 0) {
					list.SelectedItems[0].Selected = false;
				}
				objectIndex++;
				Attraction.CurrentCar = 0;
				Attraction.CarRotationFrame = 0;
				if (objectIndex >= list.Items.Count)
					objectIndex = 0;
				list.Items[objectIndex].Selected = true;
				list.Select();
			}
		}
		/** <summary> Switches to the previous object. </summary> */
		private void PreviousFrame(object sender, EventArgs e) {
			if (objectData != null && !objectData.Invalid) {
				if (frame > 0)
					frame--;
				this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));
				this.UpdateImages();
				if (imageView) {
					this.scrollBarImage.Value = frame;
					this.labelImageSize.Text = "Image Size:  " + objectData.ImageDirectory.Entries[frame].Width + ", " + objectData.ImageDirectory.Entries[frame].Height + "";
					this.labelImageOffset.Text = "Image Offset:  " + objectData.ImageDirectory.Entries[frame].XOffset + ", " + objectData.ImageDirectory.Entries[frame].YOffset + "";
				}
			}
		}
		/** <summary> Switches to the next object. </summary> */
		private void NextFrame(object sender, EventArgs e) {
			if (objectData != null && !objectData.Invalid) {
				if (frame + 1 < (imageView ? objectData.GraphicsData.Images.Count : objectData.AnimationFrames))
					frame++;
				this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + (imageView ? "image " + frame : (!dialogView ? "frame " + frame : "dialog"));
				this.UpdateImages();
				if (imageView) {
					this.scrollBarImage.Value = frame;
					this.labelImageSize.Text = "Image Size:  " + objectData.ImageDirectory.Entries[frame].Width + ", " + objectData.ImageDirectory.Entries[frame].Height + "";
					this.labelImageOffset.Text = "Image Offset:  " + objectData.ImageDirectory.Entries[frame].XOffset + ", " + objectData.ImageDirectory.Entries[frame].YOffset + "";
				}
			}
		}
		/** <summary> Scrolls the list of frame images. </summary> */
		private void ScrollImages(object sender, EventArgs e) {
			this.frame = (sender as HScrollBar).Value;
			this.UpdateImages();
			this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT - " + "image " + frame;
			this.labelImageSize.Text = "Image Size:  " + objectData.ImageDirectory.Entries[frame].Width + ", " + objectData.ImageDirectory.Entries[frame].Height + "";
			this.labelImageOffset.Text = "Image Offset:  " + objectData.ImageDirectory.Entries[frame].XOffset + ", " + objectData.ImageDirectory.Entries[frame].YOffset + "";
		}
		/** <summary> Extracts the images to the executable directory. </summary> */
		private void ExtractImages(object sender, EventArgs e) {
			if (objectData != null && !this.timerExtract.Enabled && !this.timerLoadObjects.Enabled) {
				string directory = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Extracted Images", objectData.ObjectHeader.FileName);
				string paletteDirectory = Path.Combine(directory, "Palettes");

				if (!Directory.Exists(directory))
					Directory.CreateDirectory(directory);
				if (objectData.GraphicsData.NumPalettes > 0 && !Directory.Exists(paletteDirectory))
					Directory.CreateDirectory(paletteDirectory);

				extractIndex = 0;
				extractObject = objectData;
				extractStart = DateTime.Now;
				this.timerExtract.Start();
			}
		}
		/** <summary> Extracts the images to the executable directory. </summary> */
		private void ExtractingImages(object sender, EventArgs e) {
			string directory = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Extracted Images", extractObject.ObjectHeader.FileName);
			string paletteDirectory = Path.Combine(directory, "Palettes");
			for (int i = 0; i < 100 && extractIndex < extractObject.GraphicsData.Images.Count; i++, extractIndex++) {
				if (extractObject.GraphicsData.Palettes[extractIndex] != null) {
					if (!Directory.Exists(paletteDirectory))
						Directory.CreateDirectory(paletteDirectory);
					extractObject.GraphicsData.Images[extractIndex].Save(Path.Combine(paletteDirectory, extractIndex.ToString() + ".png"), ImageFormat.Png);

					Palette palette = extractObject.GraphicsData.Palettes[extractIndex];
					string paletteText = "Colors: " + palette.Colors.Length.ToString() + "\r\nOffset: " + palette.Offset.ToString();

					// Write each color
					for (int j = 0; j < palette.Colors.Length; j++) {
						if (j % 12 == 0)
							paletteText += "\r\n\r\n";
						else if (j % 4 == 0)
							paletteText += "\r\n";
						else
							paletteText += " ";

						paletteText += "(" + palette.Colors[j].R.ToString() + ", " + palette.Colors[j].G.ToString() + ", " + palette.Colors[j].B.ToString() + ")";
						if (j + 1 < palette.Colors.Length)
							paletteText += ",";
					}

					StreamWriter writer = new StreamWriter(Path.Combine(paletteDirectory, extractIndex.ToString() + ".txt"));
					writer.Write(paletteText);
					writer.Close();
				}
				else {
					objectData.GraphicsData.Images[extractIndex].Save(Path.Combine(directory, extractIndex.ToString() + ".png"), ImageFormat.Png);
				}
			}
			if (extractIndex == extractObject.GraphicsData.Images.Count) {
				labelScanProgress.Text = "Finished - Took " + Math.Round((DateTime.Now - this.extractStart).TotalSeconds) + " seconds";
				this.timerExtract.Stop();
				extractObject = null;
			}
			else {
				this.labelScanProgress.Text = "Extracting - " + Math.Round((double)extractIndex / (double)extractObject.GraphicsData.Images.Count * 100.0) + "%";
			}
		}
		/** <summary> Opens the directory where images are extracted to. </summary> */
		private void OpenExtractDirectory(object sender, EventArgs e) {
			string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			Process.Start(directory);
		}

		#endregion
		//=========== VISUALS ============
		#region Visuals

		/** <summary> Updates the checkbox visuals. </summary> */
		private void CheckStateChanged(object sender, EventArgs e) {
			(sender as CheckBox).ImageIndex = ((sender as CheckBox).CheckState == CheckState.Checked ? 1 : 0);
		}
		/** <summary> Updates the button visuals. </summary> */
		private void ButtonHover(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left)
				(sender as Button).ImageIndex = 1;
		}
		/** <summary> Updates the button visuals. </summary> */
		private void ButtonLeave(object sender, EventArgs e) {
			(sender as Button).ImageIndex = 0;
		}
		/** <summary> Updates the button visuals. </summary> */
		private void ButtonDown(object sender, MouseEventArgs e) {
			(sender as Button).ImageIndex = 2;
		}
		/** <summary> Updates the button visuals. </summary> */
		private void ButtonUp(object sender, MouseEventArgs e) {
			(sender as Button).ImageIndex = 1;
		}
		/** <summary> Sets the control visuals. </summary> */
		private void SetFeatureToAllControls(Control.ControlCollection cc) {
			if (cc != null) {
				foreach (Control control in cc) {
					control.PreviewKeyDown += new PreviewKeyDownEventHandler(ControlPreviewKeyDown);
					SetFeatureToAllControls(control.Controls);
				}
			}
		}
		/** <summary> Prevents control visuals from showing. </summary> */
		void ControlPreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) {
				e.IsInputKey = true;
			}
		}

		#endregion
		//=========== PAINTING ===========
		#region Painting

		/** <summary> Paints the background for the tab panel. </summary> */
		private void PaintTabPanel(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;
			Rectangle rect = new Rectangle(0, 0, (sender as Control).Width, (sender as Control).Height);

			Brush brush = new SolidBrush(Color.FromArgb(123, 103, 75));
			g.FillRectangle(brush, rect);
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(163, 147, 127));
			g.FillRectangle(brush, new Rectangle(rect.X + rect.Width - 1, rect.Y, 1, rect.Height));
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(91, 63, 31));
			g.FillRectangle(brush, new Rectangle(rect.X, rect.Y, rect.Width, 1));
			g.FillRectangle(brush, new Rectangle(rect.X, rect.Y, 1, rect.Height));
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(147, 199, 167));
			g.FillRectangle(brush, new Rectangle(rect.X + 1, rect.Y + rect.Height - 1, rect.Width - 1, 1));
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(59, 115, 75));
			g.FillRectangle(brush, new Rectangle(rect.X, rect.Y + rect.Height - 1, 1, 1));
			brush.Dispose();
		}
		/** <summary> Paints the background for the tab group panels. </summary> */
		private void PaintTabGroupPanel(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;

			Rectangle rect = new Rectangle(0, 0, (sender as Control).Width, (sender as Control).Height);

			Brush brush = new SolidBrush(Color.FromArgb(99, 155, 119));
			brush.Dispose();

			//brush = new SolidBrush(Color.FromArgb(91, 115, 115));
			brush = new SolidBrush(Color.FromArgb(59, 115, 75));
			g.FillRectangle(brush, new Rectangle(3, 3, rect.Width - 6, 1));
			g.FillRectangle(brush, new Rectangle(3, 3, 1, rect.Height - 6));
			brush.Dispose();

			//brush = new SolidBrush(Color.FromArgb(183, 195, 195));
			brush = new SolidBrush(Color.FromArgb(147, 199, 167));
			g.FillRectangle(brush, new Rectangle(rect.Width - 4, 4, 1, rect.Height - 7));
			g.FillRectangle(brush, new Rectangle(4, rect.Height - 4, rect.Width - 7, 1));
			brush.Dispose();
		}
		/** <summary> Paints the background for the status bar </summary> */
		private void PaintStatusBar(object sender, PaintEventArgs e) {

			Graphics g = e.Graphics;
			Rectangle rect = new Rectangle(0, 0, (sender as Control).Width, (sender as Control).Height);

			Brush brush = new SolidBrush(Color.FromArgb(79, 135, 95));
			g.FillRectangle(brush, new Rectangle(3, 0, rect.Width - 6, rect.Height - 3));
			brush.Dispose();

			int separator1 = 206;
			int separator2 = 414;
			int width = 6;

			brush = new SolidBrush(Color.FromArgb(147, 199, 167));
			g.FillRectangle(brush, new Rectangle(rect.Width - 4, 1, 1, rect.Height - 4));
			g.FillRectangle(brush, new Rectangle(4, rect.Height - 4, rect.Width - 7, 1));

			g.FillRectangle(brush, new Rectangle(separator1, 1, 1, rect.Height - 4));
			g.FillRectangle(brush, new Rectangle(separator2, 1, 1, rect.Height - 4));
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(59, 115, 75));
			g.FillRectangle(brush, new Rectangle(3, 0, rect.Width - 6, 1));
			g.FillRectangle(brush, new Rectangle(3, 0, 1, rect.Height - 3));

			g.FillRectangle(brush, new Rectangle(separator1 + width - 1, 0, 1, rect.Height - 3));
			g.FillRectangle(brush, new Rectangle(separator2 + width - 1, 0, 1, rect.Height - 3));
			brush.Dispose();

			brush = new SolidBrush(Color.FromArgb(99, 155, 119));
			g.FillRectangle(brush, new Rectangle(separator1 + 1, 0, width - 2, rect.Height - 3));
			g.FillRectangle(brush, new Rectangle(separator2 + 1, 0, width - 2, rect.Height - 3));
			g.FillRectangle(brush, new Rectangle(rect.Width - 3, 0, 3, rect.Height));
			brush.Dispose();
		}

		#endregion
		//========= INFORMATION ==========
		#region Information

		private void SetOptionalName(string name) {
			this.tabGroupInfo.Groups["optional"].Header = name;
		}
		private void SetHeaderName(string group, string name) {
			this.tabGroupInfo.Groups[group].Header = name;
		}
		private void AddInfoItem(string group, params string[] subItems) {
			ListViewItem item = new ListViewItem(this.tabGroupInfo.Groups[group]);
			//item.ImageIndex = 0;
			//item.Text = "  " + subItems[0];
			for (int i = 0; i < subItems.Length; i++) {
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, subItems[i]));
			}
			this.tabGroupInfo.Items.Add(item);
		}
		/*private void AddInfoColors(string group, string name, byte[] colors) {
			ListViewItem item = new ListViewItem(this.tabGroupInfo.Groups[group]);
			item.SubItems.Add(new ListViewItem.ListViewSubItem(item, name));

			ListViewItem.ListViewSubItem colorSubItem = new ListViewItem.ListViewSubItem(item, "");
			colorSubItem.
			item.SubItems.Add(colorSubItem);

			this.tabGroupInfo.Items.Add(item);
		}*/
		private void AddInfoBytes(string group, string name, byte[] data) {
			//item.ImageIndex = 0;
			//item.Text = "  " + subItems[0];
			for (int i = 0; i < data.Length; ) {
				ListViewItem item = new ListViewItem(this.tabGroupInfo.Groups[group]);
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (i == 0 ? name : "")));
				string bytes = "";
				for (int j = 0; j < 16 && i < data.Length; i++, j++) {
					bytes += data[i].ToString("X2") + " ";
				}
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bytes));
				this.tabGroupInfo.Items.Add(item);
			}
		}
		private void AddInfoFlags(string group, string name, string flags) {
			const int maxLength = 64;
			string text = "";
			int lastSpace = -1;
			bool firstLine = true;
			bool lastLine = false;
			for (int i = 0; i < flags.Length && !lastLine; i++) {
				text += flags[i];

				if (flags[i] == ' ')
					lastSpace = i;

				if (i + 1 == flags.Length) {
					lastLine = true;
					lastSpace = i + 1;
				}
				if ((i == maxLength && lastSpace > 0) || lastLine) {
					ListViewItem item = new ListViewItem(this.tabGroupInfo.Groups[group]);
					item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (firstLine ? name : "")));
					text = text.Substring(0, lastSpace);
					item.SubItems.Add(new ListViewItem.ListViewSubItem(item, text));
					this.tabGroupInfo.Items.Add(item);

					text = "";
					if (!lastLine)
						flags = flags.Substring(lastSpace + 1, flags.Length - (lastSpace + 1));
					firstLine = false;
					lastSpace = -1;
					i = -1;
				}
			}
		}

		/** <summary> Updates the information tab. </summary> */
		private void UpdateInfo(object sender = null, EventArgs e = null) {
			this.tabGroupInfo.Items.Clear();

			if (objectData == null)
				return;
			if (objectData.Invalid)
				return;

			AddInfoItem("general", "File Name", objectData.ObjectHeader.FileName + ".DAT");
			AddInfoItem("general", "Name", (objectData.StringTable.Entries[0][Languages.British].Replace(" ", "").Length != 0 ? objectData.StringTable.Entries[0][Languages.British] : objectData.StringTable.Entries[0][Languages.American]));
			AddInfoItem("general", "Type", objectData.Type.ToString());
			AddInfoItem("general", "Source", objectData.Source.ToString());
			AddInfoItem("graphics", "Images", objectData.GraphicsData.NumImages.ToString());
			AddInfoItem("graphics", "Palettes", objectData.GraphicsData.NumPalettes.ToString());

			for (int i = 0; i < objectData.StringTable.Count; i++) {
				AddInfoItem("strings", "Entry " + (i + 1), objectData.StringTable.Entries[i][Languages.British]);
			}

			if (objectData.GroupInfo.FileName.Length != 0) {
				AddInfoItem("groupInfo", "Scenery Group", objectData.GroupInfo.FileName + ".DAT");
				AddInfoItem("groupInfo", "Flags", objectData.GroupInfo.Flags.ToString());
			}

			if (objectData is Attraction) {
				Attraction obj = (Attraction)objectData;
				//AddInfoItem("header", "Reserved0x00", "0x" + obj.Header.Reserved0x00.ToString("X8"));
				AddInfoFlags("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Track Type", obj.Header.TrackType.ToString());
				AddInfoItem("header", "Preview Index", obj.Header.PreviewIndex.ToString());
				AddInfoItem("header", "Min Cars Per Train", obj.Header.MinCarsPerTrain.ToString());
				AddInfoItem("header", "Max Cars Per Train", obj.Header.MaxCarsPerTrain.ToString());
				AddInfoItem("header", "Flat Cars Per Ride", (obj.Header.CarsPerFlatRide == 0xFF ? "None" : obj.Header.CarsPerFlatRide.ToString()));

				AddInfoItem("header", "Zero Cars", obj.Header.ZeroCars.ToString());
				AddInfoItem("header", "Car Tab Index", obj.Header.CarTabIndex.ToString());

				AddInfoItem("header", "Default Car Type", obj.Header.DefaultCarType.ToString());
				AddInfoItem("header", "Front Car Type", obj.Header.FrontCarType.ToString());
				AddInfoItem("header", "Second Car Type", obj.Header.SecondCarType.ToString());
				AddInfoItem("header", "Rear Car Type", obj.Header.RearCarType.ToString());
				AddInfoItem("header", "Third Car Type", obj.Header.ThirdCarType.ToString());

				//AddInfoItem("header", "Padding0x19", "0x" + obj.Header.Padding0x19.ToString("X2"));

				AddInfoItem("header", "Excitement", obj.Header.Excitement.ToString());
				AddInfoItem("header", "Intensity", obj.Header.Intensity.ToString());
				AddInfoItem("header", "Nausea", obj.Header.Nausea.ToString());
				AddInfoItem("header", "Max Height", obj.Header.MaxHeight.ToString());
				AddInfoFlags("header", "Available Tracks", obj.Header.AvailableTrackSections.ToString());

				AddInfoItem("header", "Ride Type", obj.Header.RideType.ToString());
				AddInfoItem("header", "2nd Ride Type", obj.Header.RideTypeAlternate.ToString());

				AddInfoItem("header", "Sold Item 1", obj.Header.SoldItem1.ToString());
				AddInfoItem("header", "Sold Item 2", obj.Header.SoldItem2.ToString());

				for (int i = 0; i < obj.Header.CarCount; i++) {
					CarHeader car = obj.Header.CarTypeList[i];
					string header = "header" + (i + 1).ToString();

					SetHeaderName(header, "Car Type " + i.ToString());

					AddInfoItem(header, "Last Rotation Frame", car.LastRotationFrame.ToString());
					//AddInfoBytes(header, "Reserved0x01", car.Reserved0x01);
					AddInfoItem(header, "Unknown0x04", "0x" + car.Unknown0x04.ToString("X2") + " (" + car.Unknown0x04.ToString() + ")");
					AddInfoItem(header, "Car Spacing", car.CarSpacing.ToString() + " (" + ((double)car.CarSpacing * 0.01).ToString() + " ft)");
					//AddInfoItem(header, "Reserved0x07", "0x" + car.Reserved0x07.ToString("X2"));
					AddInfoItem(header, "Car Friction", car.CarFriction.ToString());
					AddInfoItem(header, "Car Tab Height", car.CarTabHeight.ToString());
					AddInfoItem(header, "Rider Settings", (car.RiderSettings & 0x7F).ToString() + " Riders" + (((car.RiderSettings & 0x80) != 0) ? " in Pairs" : ""));
					AddInfoFlags(header, "Sprite Flags", car.SpriteFlags.ToString());
					AddInfoBytes(header, "Unknown0x0E", car.Unknown0x0E);
					AddInfoFlags(header, "Flags", car.Flags.ToString());
					//AddInfoItem(header, "Car Behavior", car.CarBehavior.ToString());
					//AddInfoBytes(header, "Reserved0x16", car.Reserved0x16);
					AddInfoItem(header, "Rider Sprites", car.RiderSprites.ToString());
					AddInfoItem(header, "Spinning Inertia", car.SpinningInertia.ToString());
					AddInfoItem(header, "Spinning Friction", car.SpinningFriction.ToString());
					AddInfoBytes(header, "Unknown0x57", car.Unknown0x57);
					AddInfoItem(header, "Powered Acceleration", car.PoweredAcceleration.ToString());
					AddInfoItem(header, "Powered Max Speed", car.PoweredMaxSpeed.ToString());
					AddInfoItem(header, "Car Visuals", car.CarVisual.ToString());
					AddInfoItem(header, "Unknown Setting", car.UnknownSetting.ToString());
					AddInfoItem(header, "Draw Order", car.DrawOrder.ToString());
					AddInfoItem(header, "Special Frames", car.SpecialFrames.ToString());
					//AddInfoItem(header, "Reserved0x61", "0x" + car.Reserved0x61.ToString("X8"));
				}

				SetHeaderName("optional1", "Car Remap Colors");

				for (int i = 0; i < obj.CarColors.Count; i++) {
					AddInfoItem("optional1", "Colors " + i,
						obj.CarColors[i][0].ToString() + " (" + ((int)obj.CarColors[i][0]).ToString() + "), " +
						obj.CarColors[i][1].ToString() + " (" + ((int)obj.CarColors[i][1]).ToString() + "), " +
						obj.CarColors[i][2].ToString() + " (" + ((int)obj.CarColors[i][2]).ToString() + ")");
				}

				SetHeaderName("optional2", "Rider Positions");

				for (int i = 0; i < obj.Header.CarCount; i++) {
					AddInfoItem("optional2", "Car Type " + i + " Length", obj.RiderPositions[i].Length.ToString());
					AddInfoBytes("optional2", "Car Type " + i + " Data", obj.RiderPositions[i]);
				}
			}
			else if (objectData is SmallScenery) {
				SmallScenery obj = (SmallScenery)objectData;
				AddInfoItem("header", "Message Ref", "0x" + obj.Header.MessageRef.ToString("X"));
				AddInfoItem("header", "Fill 1", "0x" + obj.Header.Fill1.ToString("X"));
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Height", obj.Header.Height.ToString());
				AddInfoItem("header", "Cursor", obj.Header.Cursor.ToString());
				AddInfoItem("header", "Build Cost", (obj.Header.BuildCost < 0 ? "-" : "") + "$" + Math.Abs(obj.Header.BuildCost).ToString());
				AddInfoItem("header", "Remove Cost", (obj.Header.RemoveCost < 0 ? "-" : "") + "$" + Math.Abs(obj.Header.RemoveCost).ToString());
				AddInfoItem("header", "Animation 1", "0x" + obj.Header.Animation1.ToString("X"));
				AddInfoItem("header", "Animation 2", "0x" + obj.Header.Animation2.ToString("X"));
				AddInfoItem("header", "Animation 3", "0x" + obj.Header.Animation3.ToString("X"));
			}
			else if (objectData is LargeScenery) {
				LargeScenery obj = (LargeScenery)objectData;
				AddInfoItem("header", "Cursor", obj.Header.Cursor.ToString());
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Build Cost", "$" + obj.Header.BuildCost.ToString());
				AddInfoItem("header", "Remove Cost", (obj.Header.RemoveCost < 0 ? "-" : "") + "$" + Math.Abs(obj.Header.RemoveCost).ToString());
				AddInfoItem("header", "Scrolling", "0x" + obj.Header.Scrolling.ToString("X"));


				SetOptionalName("Tiles");

				for (int i = 0; i < obj.Tiles.Count; i++) {
					LargeSceneryTileHeader tile = obj.Tiles[i];
					AddInfoItem("optional", "[Tile " + (i + 1) + "]");
					AddInfoItem("optional", "Row", tile.Row.ToString());
					AddInfoItem("optional", "Column", tile.Column.ToString());
					AddInfoItem("optional", "BaseHeight", tile.BaseHeight.ToString());
					AddInfoItem("optional", "Clearance", tile.Clearance.ToString());
					AddInfoItem("optional", "Unknown 1", "0x" + tile.Unknown1.ToString("X"));
					AddInfoItem("optional", "Flags", tile.Flags.ToString());
				}
			}
			else if (objectData is Wall) {
				Wall obj = (Wall)objectData;
				AddInfoItem("header", "Cursor", obj.Header.Cursor.ToString());
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Clearance", obj.Header.Clearance.ToString());
				AddInfoItem("header", "Effects", "0x" + obj.Header.Effects.ToString("X"));
				AddInfoItem("header", "Build Cost", "$" + (obj.Header.BuildCost / 10).ToString());
				AddInfoItem("header", "Scrolling", "0x" + obj.Header.Scrolling.ToString("X"));
			}
			else if (objectData is PathBanner) {
				PathBanner obj = (PathBanner)objectData;
				AddInfoItem("header", "Scrolling", "0x" + obj.Header.Scrolling.ToString("X"));
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Build Cost", "$" + (obj.Header.BuildCost / 10).ToString());
			}
			else if (objectData is PathAddition) {
				PathAddition obj = (PathAddition)objectData;
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
				AddInfoItem("header", "Subtype", obj.Header.Subtype.ToString());
				AddInfoItem("header", "Cursor", obj.Header.Cursor.ToString());
				AddInfoItem("header", "Build Cost", "$" + (obj.Header.BuildCost / 10).ToString());
			}
			else if (objectData is SceneryGroup) {
				SceneryGroup obj = (SceneryGroup)objectData;
				AddInfoItem("header", "Unknown0x108", "0x" + obj.Header.Unknown0x108.ToString("X"));
				AddInfoItem("header", "Unknown0x10A", "0x" + obj.Header.Unknown0x10A.ToString("X"));
				AddInfoItem("header", "Unknown0x10B", "0x" + obj.Header.Unknown0x10B.ToString("X"));

				SetOptionalName("Scenery Items");
				for (int i = 0; i < obj.Contents.Count; i++) {
					AddInfoItem("optional", obj.Contents[i] + ".DAT");
				}
			}
			else if (objectData is Pathing) {
				Pathing obj = (Pathing)objectData;
				AddInfoItem("header", "Flags", obj.Header.Flags.ToString());
			}
			else if (objectData is Water) {
				Water obj = (Water)objectData;
				/*string nonZeroStr = "None";
				if (obj.Header.NonZeroBytes.Count > 0) {
					nonZeroStr = "";
					for (int i = 0; i < obj.Header.NonZeroBytes.Count; i++) {
						if (i != 0)
							nonZeroStr += ", ";
						nonZeroStr += "[0x" + obj.Header.BytePositions[i].ToString("X") + ": 0x" + obj.Header.NonZeroBytes[i].ToString("X") + "]";
					}
				}
				AddInfoItem("header", "Non-Zero Bytes", nonZeroStr);*/
			}
			else if (objectData is ParkEntrance) {
				ParkEntrance obj = (ParkEntrance)objectData;
				AddInfoItem("header", "SignX", obj.Header.SignX.ToString());
				AddInfoItem("header", "SignY", obj.Header.SignY.ToString());
			}

		}
		/** <summary> Updates the object view. </summary> */
		private void UpdateImages() {
			if (objectData == null) {
				this.objectView.Image = null;
				return;
			}

			Graphics g = Graphics.FromImage(objectImage);
			g.Clear(Color.Transparent);
			bool error = false;

			if (objectData.Invalid) {
				g.DrawImage(Resources.InvalidError, new Point(
						this.objectView.Width / 2 - Resources.InvalidError.Width / 2,
						this.objectView.Height / 2 - Resources.InvalidError.Height / 2
					)
				);
			}
			else if (imageView) {
				if (objectData.GraphicsData.Images.Count > 0) {

					Rectangle rect = new Rectangle(
						this.objectView.Width / 2 - this.objectData.ImageDirectory.Entries[frame].Width / 2 - 1,
						this.objectView.Height / 2 - this.objectData.ImageDirectory.Entries[frame].Height / 2 - 1,
						this.objectData.ImageDirectory.Entries[frame].Width,
						this.objectData.ImageDirectory.Entries[frame].Height
					);

					if (objectData.GraphicsData.Palettes[frame] != null) {
						rect = new Rectangle(
							this.objectView.Width / 2 - 128 / 2 - 1,
							this.objectView.Height / 2 - 128 / 2 - 1,
							128,
							128
						);
					}

					Brush brush = new SolidBrush(Color.FromArgb(99, 155, 119));
					g.FillRectangle(brush, rect);
					brush.Dispose();

					brush = new SolidBrush(Color.FromArgb(47, 99, 59));
					g.FillRectangle(brush, new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 2, 1));
					g.FillRectangle(brush, new Rectangle(rect.X - 1, rect.Y - 1, 1, rect.Height + 2));
					brush.Dispose();
					brush = new SolidBrush(Color.FromArgb(123, 175, 139));
					g.FillRectangle(brush, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width + 1, 1));
					g.FillRectangle(brush, new Rectangle(rect.X + rect.Width, rect.Y, 1, rect.Height + 1));
					brush.Dispose();
				}
				error = !objectData.DrawSingleFrame(g, new Point(this.objectView.Width / 2 - 1, this.objectView.Height / 2 - 1), frame);
			}
			else if (dialogView) {

				Rectangle rect = new Rectangle(
					0,
					0,
					192,
					256
				);
				Rectangle dialogRect = new Rectangle(
					objectImage.Width / 2 - 112 / 2,
					objectImage.Height / 2 - 112 / 2,
					112,
					112
				);
				SolidBrush brush = new SolidBrush(Color.FromArgb(79, 135, 95));
				g.FillRectangle(brush, rect);
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(99, 155, 119));
				g.FillRectangle(brush, dialogRect);
				brush.Dispose();

				error = !objectData.DrawDialog(g, dialogRect.Location, rotation);

				brush = new SolidBrush(Color.FromArgb(79, 135, 95));
				g.FillRectangle(brush, new Rectangle(0, 0, dialogRect.X, rect.Height));
				g.FillRectangle(brush, new Rectangle(dialogRect.Right, 0, dialogRect.X, rect.Height));
				g.FillRectangle(brush, new Rectangle(0, 0, rect.Width, dialogRect.Y));
				g.FillRectangle(brush, new Rectangle(0, dialogRect.Bottom, rect.Width, dialogRect.Y));
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(47, 99, 59));
				g.FillRectangle(brush, new Rectangle(dialogRect.X - 1, dialogRect.Y - 1, dialogRect.Width + 2, 1));
				g.FillRectangle(brush, new Rectangle(dialogRect.X - 1, dialogRect.Y - 1, 1, dialogRect.Height + 2));
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(123, 175, 139));
				g.FillRectangle(brush, new Rectangle(dialogRect.X, dialogRect.Bottom, dialogRect.Width + 1, 1));
				g.FillRectangle(brush, new Rectangle(dialogRect.Right, dialogRect.Y, 1, dialogRect.Height + 1));
				brush.Dispose();

				/*SolidBrush brush = new SolidBrush(Color.FromArgb(79, 135, 95));
				g.FillRectangle(brush, new Rectangle(0, 0, 192, 256));
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(99, 155, 119));
				g.FillRectangle(brush, new Rectangle(64, 161, 64, 78));
				brush.Dispose();

				error = !objectData.DrawDialog(g, new Point(96, 192), rotation);

				brush = new SolidBrush(Color.FromArgb(79, 135, 95));
				g.FillRectangle(brush, new Rectangle(0, 0, 64, 256));
				g.FillRectangle(brush, new Rectangle(128, 0, 64, 256));
				g.FillRectangle(brush, new Rectangle(0, 0, 192, 161));
				g.FillRectangle(brush, new Rectangle(0, 239, 192, 17));
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(47, 99, 59));
				g.FillRectangle(brush, new Rectangle(64 - 1, 161 - 1, 66, 1));
				g.FillRectangle(brush, new Rectangle(64 - 1, 161 - 1, 1, 80));
				brush.Dispose();
				brush = new SolidBrush(Color.FromArgb(123, 175, 139));
				g.FillRectangle(brush, new Rectangle(64 - 1, 161 - 1 + 79, 65, 1));
				g.FillRectangle(brush, new Rectangle(64 - 1 + 65, 161, 1, 79));
				brush.Dispose();*/
			}
			else {
				int slopeLevel = 4 + (slope % 2 == 0 ? 4 : 0);
				if (slope == -1 || !objectData.CanSlope)
					Terrain.DrawTerrain(g, 5, 8, 65, 1);
				else
					Terrain.DrawSlopedTerrain(g, slope, slopeLevel, 5, 8, 65, 1);

				error = !objectData.Draw(g, new Point(96, 192), rotation, corner, slope, elevation, frame);
			}
			if (error) {
				g.Clear(Color.Transparent);
				g.DrawImage(Resources.MissingImagesError, new Point(
						this.objectView.Width / 2 - Resources.MissingImagesError.Width / 2,
						this.objectView.Height / 2 - Resources.MissingImagesError.Height / 2
					)
				);
			}

			this.objectView.Image = objectImage;
		}
		/** <summary> Updates the color remapping. </summary> */
		private void UpdateColorRemap() {
			this.panelColorPalette.Visible = false;

			if (!this.dialogView && (!this.imageView || this.remapImageView)) {
				GraphicsData.DisableRemap = false;
				this.buttonRemap1.Visible = (objectData != null && objectData.ColorRemaps >= 1);
				this.buttonRemap2.Visible = (objectData != null && objectData.ColorRemaps >= 2);
				this.buttonRemap3.Visible = (objectData != null && objectData.ColorRemaps == 3);
			}
			else {
				GraphicsData.DisableRemap = true;
				this.buttonRemap1.Visible = false;
				this.buttonRemap2.Visible = false;
				this.buttonRemap3.Visible = false;
			}
			this.colorRemap = 0;
		}

		#endregion

		private void ListViewDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
			string name = (sender as ListView).Name.Replace("tabGroup", "");
			Color colorBack = Color.FromArgb(159, 175, 175);
			Color colorDark = Color.FromArgb(111, 131, 131);
			Color colorLight = Color.FromArgb(211, 219, 219);
			if (new Rectangle(e.Bounds.X + (e.Header.DisplayIndex != 0 ? 8 : 0), e.Bounds.Y, e.Bounds.Width + (e.Header.DisplayIndex != 0 ?
				(e.Header.DisplayIndex + 1 == (sender as ListView).Columns.Count && (sender as ListView).Width <= e.Bounds.Right + 24 ? -3 : 0) : 8), e.Bounds.Height).Contains((sender as ListView).PointToClient(Control.MousePosition))) {
				colorBack = Color.FromArgb(183, 195, 195);
				colorDark = Color.FromArgb(131, 151, 151);
				colorLight = Color.FromArgb(239, 243, 243);
			}

			e.Graphics.FillRectangle(new SolidBrush(colorBack), new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 1));

			e.Graphics.DrawLine(new Pen(colorLight), new Point(e.Bounds.Left, e.Bounds.Top), new Point(e.Bounds.Right - 1, e.Bounds.Top));
			e.Graphics.DrawLine(new Pen(colorLight), new Point(e.Bounds.Left, e.Bounds.Top), new Point(e.Bounds.Left, e.Bounds.Bottom - 1));

			e.Graphics.DrawLine(new Pen(colorDark), new Point(e.Bounds.Right - 1, e.Bounds.Top), new Point(e.Bounds.Right - 1, e.Bounds.Bottom - 1));
			e.Graphics.DrawLine(new Pen(colorDark), new Point(e.Bounds.Left, e.Bounds.Bottom - 1), new Point(e.Bounds.Right - 1, e.Bounds.Bottom - 1));

			if (currentColumn[GetTabIndex(name)] == e.ColumnIndex && name != "Info") {
				if (currentListOrder[GetTabIndex(name)])
					e.Graphics.DrawImage(Resources.SortDown, new Point(e.Bounds.Right - 12, e.Bounds.Top + 9));
				else
					e.Graphics.DrawImage(Resources.SortUp, new Point(e.Bounds.Right - 12, e.Bounds.Top + 9));
			}
			fontBold.DrawAligned(e.Graphics, new Rectangle(e.Bounds.Left + 8, e.Bounds.Top, e.Bounds.Width - 16, e.Bounds.Height), HorizontalAlignment.Left, e.Header.Text, Color.Black);

			e.DrawDefault = false;
		}

		private void ListViewDrawItem(object sender, DrawListViewItemEventArgs e) {
			e.DrawDefault = true;
		}

		private void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			e.DrawDefault = true;
		}
	}
}
