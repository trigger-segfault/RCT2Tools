using CustomControls;
using RCTDataEditor.DataObjects;
using RCT2GroupCreator.Properties;
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
using RCT2ObjectData.DataObjects.Types;
using RCT2ObjectData.DataObjects;

namespace RCT2GroupCreator {
	public partial class GroupForm : Form {

		//========== CONSTANTS ===========
		#region Constants


		#endregion
		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The default number of objects to load per tick. </summary> */
		int objectsPerTick = 50;

		#endregion
		//--------------------------------
		#region Objects

		/** <summary> The current object being viewed. </summary> */
		ObjectData objectData;
		/** <summary> The index of the object in the file directory. </summary> */
		int objectIndex = 0;
		bool dialogView = true;
		/** <summary> The image to draw the object to. </summary> */
		Image objectImage;
		PaletteImage objectPaletteImage = new PaletteImage(new Size(190, 254));
		/** <summary> The scenery group being edited. </summary> */
		SceneryGroup sceneryGroup = null;

		DrawSettings drawSettings;

		Image iconImage = new Bitmap(46, 46);

		bool changed = false;

		string fileName = "";

		#endregion
		//--------------------------------
		#region Sorting

		/** <summary> The list of tab sort columns. </summary> */
		int currentColumn = 0;
		/** <summary> The list of tab solumn sort orders. </summary> */
		bool currentListOrder = false;

		#endregion
		//--------------------------------
		#region Scanning

		/** <summary> The start time of the scan. </summary> */
		DateTime scanStart;
		/** <summary> The current directory. </summary> */
		string directory = "C:\\Programs\\Games\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\ObjData";
		/** <summary> The index of the next file in the list to load. </summary> */
		int fileIndex = 0;

		#endregion
		//--------------------------------
		#region Other

		/** <summary> The sbold RCT sprite font. </summary> */
		SpriteFont fontBold;

		PaletteImage tabBack = PaletteImage.FromBuffer(Resources.TabBack);
		PaletteImage tabFront = PaletteImage.FromBuffer(Resources.TabFront);

		//AboutBox aboutForm = new AboutBox();

		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public GroupForm(string[] args) {
			InitializeComponent();

			Pathing.SetPathSprites();
			Water.LoadResources();
			ColorRemapping.LoadResources();
			Terrain.LoadResources();

			this.fontBold = new SpriteFont(Resources.BoldFont, ' ', 'z', 10);

			this.drawSettings.Remap1 = RemapColors.IndianRed;
			this.drawSettings.Remap2 = RemapColors.Gold;
			this.drawSettings.Remap3 = RemapColors.Bark;
			this.drawSettings.Slope = -1;



			this.labelCurrentObject.Text = "";

			this.objectImage = new Bitmap(190, 254);


			this.LoadSettings(null, null);

			//this.directory = this.defaultDirectory;

			this.sceneryGroup = new SceneryGroup();

			this.sceneryGroup = (SceneryGroup)ObjectData.FromBuffer(Resources.SCGCUST);
			LoadSceneryGroup();
		}

		#endregion
		//=========== LOADING ============
		#region Loading

		/** <summary> Called when the form loads. </summary> */
		private void OnFormLoad(object sender, EventArgs e) {
			SetFeatureToAllControls(this.Controls);
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
		/** <summary> Called to load the settings file. </summary> */
		private void LoadSettings(object sender, EventArgs e) {
			string pathToSettings = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Group Creator.xml");
			if (File.Exists(pathToSettings)) {
				XmlDocument doc = new XmlDocument();
				doc.Load(pathToSettings);
				XmlNodeList element;

				element = doc.GetElementsByTagName("DefaultDirectory");
				if (element.Count != 0) this.directory = element[0].InnerText;
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
			element.AppendChild(doc.CreateTextNode(this.directory));

			doc.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Group Creator.xml"));
		}
		/** <summary> Loads objects from the directory every tick. </summary> */
		private void LoadObjects(object sender, EventArgs e) {
			int count = 0;
			for (int i = fileIndex; i < this.sceneryGroup.Items.Count && count < objectsPerTick; i++, fileIndex++, count++) {
				string file = Path.Combine(this.directory, this.sceneryGroup.Items[i].FileName + ".DAT");
				if (File.Exists(file)) {
					ObjectDataInfo info = ObjectDataInfo.FromFile(file, true);
					if (!info.Invalid) {
						
						ListViewItem item = new ListViewItem();
						item.ImageIndex = 1;
						if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
						else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Source.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Name));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Type.ToString()));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Subtype.ToString()));
						this.tabGroupScenery.Items.Add(item);

					}
					else {
						ListViewItem item = new ListViewItem();
						item.ForeColor = Color.FromArgb(200, 0, 0);
						//item.Font = new Font(item.Font, FontStyle.Bold);
						item.ImageIndex = 3;
						if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
						else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
						this.tabGroupScenery.Items.Add(item);
					}
				}
			}
			if (fileIndex >= this.sceneryGroup.Items.Count) {
				this.labelScanProgress.Text = "Scan Finished - Took " + Math.Round((DateTime.Now - this.scanStart).TotalSeconds) + " seconds";
				this.timerLoadObjects.Stop();
			}
			else {
				this.labelScanProgress.Text = "Scanning - " + Math.Round((double)fileIndex / (double)this.sceneryGroup.Items.Count * 100.0) + "%";
			}
			this.labelObjectsScanned.Text = "Objects Scanned: " + fileIndex;
			this.labelObjectsInGroup.Text = "Scenery" + ": " + this.tabGroupScenery.Items.Count;
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
			/*if (e.Column != 0) {
				string name = (sender as ListView).Name.Replace("tabGroup", "");
				if (e.Column == currentColumn) {
					currentListOrder = !currentListOrder;
				}
				else {
					currentColumn = e.Column;
					currentListOrder = false;
				}
				(sender as ListView).ListViewItemSorter = new ListViewItemComparer(e.Column, currentListOrder);
				(sender as ListView).Refresh();
			}*/
		}
		
		/** <summary> Called when the browse button is pressed. </summary> */
		private void BrowseDirectory(object sender, EventArgs e) {
			this.objDataBrowserDialog.SelectedPath = this.directory;

			if (this.objDataBrowserDialog.ShowDialog() == DialogResult.OK) {
				this.directory = this.objDataBrowserDialog.SelectedPath;

				this.tabGroupScenery.Items.Clear();

				this.objectData = null;
				this.objectIndex = 0;

				this.UpdateImages();

				this.timerLoadObjects.Stop();

				this.fileIndex = 0;
				this.labelScanProgress.Text = "Ready to Scan";
				this.labelObjectsScanned.Text = "Objects Scanned: 0";
				this.labelObjectsInGroup.Text = "Scenery: " + this.tabGroupScenery.Items.Count;

				SaveSettings(null, null);
				StartScan(null, null);
			}
		}

		/** <summary> Called when the scan button is pressed. </summary> */
		private void StartScan(object sender, EventArgs e) {
			if (!this.timerLoadObjects.Enabled) {
				this.tabGroupScenery.Items.Clear();

				this.objectData = null;
				this.objectIndex = 0;

				this.UpdateImages();

				try {
					this.fileIndex = 0;
					this.labelScanProgress.Text = "Ready to Scan";
					this.labelObjectsScanned.Text = "Objects Scanned: 0";
					this.labelObjectsInGroup.Text = "Scenery: " + this.tabGroupScenery.Items.Count;

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

		/** <summary> Called when an object is selected from the list. </summary> */
		private void ObjectChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
			if (e.Item.Selected && ((sender as ListView).SelectedItems.Count == 0 || (sender as ListView).SelectedItems[0] == e.Item)) {
				objectIndex = e.ItemIndex;
				objectData = ObjectData.FromFile(Path.Combine(directory, e.Item.SubItems[2].Text));
				this.UpdateImages();
				this.labelCurrentObject.Text = (objectData != null ? objectData.ObjectHeader.FileName + ".DAT" : "");
				if (objectData == null) {
					this.labelCurrentObject.Text =  "";
				}
				else {
					this.labelCurrentObject.Text = objectData.ObjectHeader.FileName + ".DAT";
				}
				
			}
		}

		#endregion
		//=========== READING ============
		#region Reading

		/** <summary> Loads the scenery group into the editor. </summary> */
		private void LoadSceneryGroup() {
			StartScan(null, null);
			Graphics g = Graphics.FromImage(this.iconImage);

			Image icon = this.sceneryGroup.GraphicsData.GetPaletteImage(1).CreateImage(Palette.SceneryGroupPalette);
			g.DrawImage(icon, (46 - icon.Width) / 2, (46 - icon.Height) / 2);
			g.Dispose();

			this.iconView.Image = iconImage;
			this.sceneryGroup.Header.Unknown0x108 = 0x28;
			this.sceneryGroup.Header.Unknown0x10A = 0x0;
			this.sceneryGroup.Header.Unknown0x10B = 0x0;
		}
		/** <summary> Saves the scenery group from the editor. </summary> */
		private void SaveSceneryGroup() {
			
		}
		/** <summary> Changes the language names. </summary> */
		private void ChangeNames(object sender, EventArgs e) {
			using (NamesForm form = new NamesForm()) {
				form.Names = sceneryGroup.StringTable.Entries[0].Languages;
				form.ShowDialog(this);
				sceneryGroup.StringTable.Entries[0].Languages = form.Names;
				changed = true;
			}
		}
		/** <summary> Opens the about form. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
		/** <summary> Creates a new water object. </summary> */
		private void New(object sender, EventArgs e) {
			if (!changed || WarningMessageBox.Show(this, "Scenery group has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				sceneryGroup = (SceneryGroup)ObjectData.FromBuffer(Resources.SCGCUST);
				LoadSceneryGroup();
				fileName = "";
			}
		}
		/** <summary> Opens the water object. </summary> */
		private void Open(object sender, EventArgs e) {
			if (fileName == "") {
				openFileDialog.InitialDirectory = "";
				openFileDialog.FileName = "";
			}
			else {
				openFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				openFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
			}
			if (!changed || WarningMessageBox.Show(this, "Scenery group has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
					fileName = openFileDialog.FileName;
					ObjectData obj = ObjectData.FromFile(fileName);
					bool invalid = false;
					if (obj is SceneryGroup && (obj as SceneryGroup).GraphicsData.NumImages == 2) {
						this.sceneryGroup = (SceneryGroup)obj;
						LoadSceneryGroup();
					}
					else {
						invalid = true;
					}
					if (invalid) {
						ErrorMessageBox.Show(this, "Failed to load scenery group.", "Object may be invalid.");
					}
				}
			}
		}
		/** <summary> Saves the water object. </summary> */
		private void Save(object sender, EventArgs e) {
			if (fileName == "" || sceneryGroup.Source != SourceTypes.Custom) {
				SaveAs(null, null);
			}
			else {
				SaveSceneryGroup();
				sceneryGroup.Save(fileName);
			}
		}
		/** <summary> Saves as the water object. </summary> */
		private void SaveAs(object sender, EventArgs e) {
			if (fileName == "") {
				saveFileDialog.InitialDirectory = "";
				saveFileDialog.FileName = "UNTITLED";
			}
			else if (sceneryGroup.Source != SourceTypes.Custom) {
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				saveFileDialog.FileName = "UNTITLED";
			}
			else {
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				saveFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
			}
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
				fileName = saveFileDialog.FileName;
				sceneryGroup.ObjectHeader.FileName = Path.GetFileNameWithoutExtension(fileName).Substring(0, Math.Min(Path.GetFileNameWithoutExtension(fileName).Length, 8));
				sceneryGroup.Source = SourceTypes.Custom;
				SaveSceneryGroup();
				sceneryGroup.Save(fileName);
			}
		}

		#endregion
		//=========== BUTTONS ============
		#region Buttons

		/** <summary> Switches to the previous object. </summary> */
		private void PreviousObject(object sender, EventArgs e) {
			if (this.tabGroupScenery.Items.Count > 0) {
				while (this.tabGroupScenery.SelectedItems.Count != 0) {
					this.tabGroupScenery.SelectedItems[0].Selected = false;
				}
				objectIndex--;
				if (objectIndex < 0)
					objectIndex = this.tabGroupScenery.Items.Count - 1;
				this.tabGroupScenery.Items[objectIndex].Selected = true;
				this.tabGroupScenery.Select();
			}
		}
		/** <summary> Switches to the next object. </summary> */
		private void NextObject(object sender, EventArgs e) {
			if (this.tabGroupScenery.Items.Count > 0) {
				while (this.tabGroupScenery.SelectedItems.Count != 0) {
					this.tabGroupScenery.SelectedItems[0].Selected = false;
				}
				objectIndex++;
				if (objectIndex >= this.tabGroupScenery.Items.Count)
					objectIndex = 0;
				this.tabGroupScenery.Items[objectIndex].Selected = true;
				this.tabGroupScenery.Select();
			}
		}

		#endregion
		//=========== SCENERY ============
		#region Scenery Management

		/** <summary> Opens a file dialog to add scenery. </summary> */
		private void AddScenery(object sender, EventArgs e) {
			if (this.openFileDialogScenery.ShowDialog(this) == DialogResult.OK) {
				bool invalid = false;
				bool invalidType = false;
				for (int i = 0; i < this.openFileDialogScenery.FileNames.Length; i++) {
					string file = this.openFileDialogScenery.FileNames[i];
					if (File.Exists(file)) {
						ObjectDataInfo info = ObjectDataInfo.FromFile(file, true);
						if (!info.Invalid) {

							if (info.Type != ObjectTypes.SmallScenery && info.Type != ObjectTypes.LargeScenery &&
								info.Type != ObjectTypes.PathAddition && info.Type != ObjectTypes.PathBanner &&
								info.Type != ObjectTypes.Wall) {
								invalidType = true;
							}
							else {
								ListViewItem item = new ListViewItem();
								item.ImageIndex = 1;
								if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
								else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Source.ToString()));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Name));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Type.ToString()));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Subtype.ToString()));
								this.tabGroupScenery.Items.Add(item);
								this.sceneryGroup.Items.Add(new SceneryGroupItem(info.Flags, info.FileName, info.CheckSum));
							}
						}
						else {
							/*ListViewItem item = new ListViewItem();
							item.ForeColor = Color.FromArgb(200, 0, 0);
							//item.Font = new Font(item.Font, FontStyle.Bold);
							item.ImageIndex = 3;
							if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
							else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							this.tabGroupScenery.Items.Add(item);*/
							invalid = true;
						}
					}
				}
				if (invalid) {
					ErrorMessageBox.Show(this, "Some items were invalid objects and", "not added.");
				}
				if (invalidType) {
					ErrorMessageBox.Show(this, "Some items were invalid object types", "and not added.");
				}
			}
		}
		/** <summary> Removes the selected scenery items. </summary> */
		private void RemoveScenery(object sender, EventArgs e) {
			for (int i = this.tabGroupScenery.SelectedItems.Count - 1; i >= 0; i--) {
				this.tabGroupScenery.Items.Remove(this.tabGroupScenery.SelectedItems[i]);
			}
		}
		/** <summary> Called when the delete button is pressed in the scenery list. </summary> */
		private void DeleteScenery(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				RemoveScenery(null, null);
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

			DoDragDrop(e.Item, DragDropEffects.Link);
			/*if (files.Length != 0) {
				DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
			}*/
		}
		/** <summary> Called when a dragged object is dropped into the list. </summary> */
		private void SceneryListDragDrop(object sender, DragEventArgs e) {
			Point cp = this.tabGroupScenery.PointToClient(new Point(e.X, e.Y));
			ListViewItem dragToItem = this.tabGroupScenery.GetItemAt(cp.X, cp.Y);
			int dropIndex = (dragToItem != null ? dragToItem.Index : this.tabGroupScenery.Items.Count);
			if (dragToItem != null) {
				if (this.tabGroupScenery.GetItemAt(cp.X, cp.Y + 12) != dragToItem)
					dropIndex++;
			}
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				bool invalid = false;
				bool invalidType = false;
				string[] fileDrops = (string[])(e.Data.GetData(DataFormats.FileDrop));
				for (int i = 0; i < fileDrops.Length; i++) {
					string file = fileDrops[i];
					if (File.Exists(file)) {
						ObjectDataInfo info = ObjectDataInfo.FromFile(file, true);
						if (!info.Invalid) {

							if (info.Type != ObjectTypes.SmallScenery && info.Type != ObjectTypes.LargeScenery &&
								info.Type != ObjectTypes.PathAddition && info.Type != ObjectTypes.PathBanner &&
								info.Type != ObjectTypes.Wall) {
								invalidType = true;
							}
							else {
								ListViewItem item = new ListViewItem();
								item.ImageIndex = 1;
								if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
								else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Source.ToString()));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Name));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Type.ToString()));
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, info.Subtype.ToString()));
								this.tabGroupScenery.Items.Insert(dropIndex + i, item);
								this.sceneryGroup.Items.Insert(dropIndex + i, new SceneryGroupItem(info.Flags, info.FileName, info.CheckSum));
							}
						}
						else {
							/*ListViewItem item = new ListViewItem();
							item.ForeColor = Color.FromArgb(200, 0, 0);
							//item.Font = new Font(item.Font, FontStyle.Bold);
							item.ImageIndex = 3;
							if (info.Source == SourceTypes.Custom) item.ImageIndex = 2;
							else if (info.Source == SourceTypes.RCT2) item.ImageIndex = 0;
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
							this.tabGroupScenery.Items.Insert(dropIndex + i, item);*/
							invalid = true;
						}
					}
				}
				if (invalid) {
					ErrorMessageBox.Show(this, "Some items were invalid objects and", "not added.");
				}
				if (invalidType) {
					ErrorMessageBox.Show(this, "Some items were invalid object types", "and not added.");
				}
			}
			else {
				int itemsBefore = 0;
				int itemsAfter = 0;
				for (int i = 0; i < this.tabGroupScenery.SelectedItems.Count; i++) {
					if (this.tabGroupScenery.SelectedItems[i].Index <= dropIndex)
						itemsBefore++;
					else
						itemsAfter++;
				}
				List<ListViewItem> items = new List<ListViewItem>();
				List<SceneryGroupItem> sgItems = new List<SceneryGroupItem>();
				for (int i = this.tabGroupScenery.SelectedItems.Count - 1; i >= 0; i--) {
					items.Add(this.tabGroupScenery.SelectedItems[i]);
					sgItems.Add(this.sceneryGroup.Items[i]);
					this.sceneryGroup.Items.RemoveAt(this.tabGroupScenery.SelectedItems[i].Index);
					this.tabGroupScenery.Items.RemoveAt(this.tabGroupScenery.SelectedItems[i].Index);
				}
				for (int i = 0; i < items.Count; i++) {
					this.tabGroupScenery.Items.Insert(Math.Max(0, dropIndex - itemsBefore) + i, items[items.Count - 1 - i]);
					this.sceneryGroup.Items.Insert(Math.Max(0, dropIndex - itemsBefore) + i, sgItems[items.Count - 1 - i]);
				}
			}
			changed = true;
		}
		/** <summary> Called when a dragged object has entered the list. </summary> */
		private void SceneryListDragEnter(object sender, DragEventArgs e) {
			if (e.AllowedEffect == DragDropEffects.Link) {
				e.Effect= DragDropEffects.Link;
			}
			else {
				e.Effect= DragDropEffects.All;
			}
		}

		private void ChangeTabIcon(object sender, EventArgs e) {
			if (this.openFileDialogIcon.ShowDialog(this) == DialogResult.OK) {
				try {
					this.sceneryGroup.GraphicsData.Set(0, PaletteImage.FromBuffer(Resources.TabBack));
					this.sceneryGroup.GraphicsData.Set(1, PaletteImage.FromBuffer(Resources.TabFront));

					Bitmap icon = (Bitmap)Bitmap.FromFile(this.openFileDialogIcon.FileName);
					Color transparentColor = icon.GetPixel(0, 0);

					for (int i = 0; i < 2; i++) {
						for (int x = 0; x < this.sceneryGroup.GraphicsData.GetPaletteImage(i).Width; x++) {
							for (int y = 0; y < this.sceneryGroup.GraphicsData.GetPaletteImage(i).Height; y++) {
								if (x < icon.Width && y < icon.Height && (i == 1 || y < 26)) {
									int colorIndex = FindClosestColor(icon.GetPixel(x, y), transparentColor);
									if (colorIndex != 0) {
										this.sceneryGroup.GraphicsData.GetPaletteImage(i).Pixels[x, y] = (byte)colorIndex;
									}
								}
							}
						}
					}

					Graphics g = Graphics.FromImage(this.iconImage);

					PaletteImage icon2 = this.sceneryGroup.GraphicsData.GetPaletteImage(1);
					icon2.Draw(g, (46 - icon2.Width) / 2, (46 - icon2.Height) / 2, Palette.SceneryGroupPalette);
					g.Dispose();

					this.iconView.Image = this.iconImage;

					changed = true;
				}
				catch (Exception) {
					ErrorMessageBox.Show(this, "Error using image for tab icon.", "File may not be an image.");
				}
			}
		}
		private int FindClosestColor(Color imageColor, Color transparentColor) {
			Palette palette = Palette.DefaultPalette;

			int[] delta = new int[256];

			for (int i = 0; i < 256; i++) {
				delta[i] = GetColorDelta((imageColor == transparentColor) ? Color.Transparent : imageColor, palette.Colors[i]);
			}
			int minDelta = delta[0];
			int minDeltaIndex = 0;
			for (int i = 10; i < 243; i++) {
				if (delta[i] < minDelta) {
					minDelta = delta[i];
					minDeltaIndex = i;
				}
			}
			return minDeltaIndex;
		}
		private int GetColorDelta(Color imageColor, Color paletteColor) {
			return Math.Abs(imageColor.R - paletteColor.R) +
				Math.Abs(imageColor.G - paletteColor.G) +
				Math.Abs(imageColor.B - paletteColor.B) +
				Math.Abs(imageColor.A - paletteColor.A) * 4;
		}


		#endregion
		//=========== DRAWING ============
		#region Drawing

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
			else if (dialogView) {


				for (int x = 0; x < 190; x++) {
					for (int y = 0; y < 254; y++) {
						if (x >= 40 && x < 40 + 112 && y >= 72 && y < 72 + 112) {
							objectPaletteImage.Pixels[x, y] = 149;
						}
					}
				}

				error = !objectData.DrawDialog(objectPaletteImage, new Point(40, 72), new Size(112, 112), drawSettings);

				for (int x = 0; x < 190; x++) {
					for (int y = 0; y < 254; y++) {
						if (x >= 40 && x < 40 + 112 && y >= 72 && y < 72 + 112) {

						}
						else if ((x == 39 && y >= 71 && y < 71 + 114) || (y == 71 && x >= 39 && x < 39 + 114))
							objectPaletteImage.Pixels[x, y] = 146;
						else if ((x == 39 + 113 && y >= 72 && y < 71 + 114) || (y == 71 + 113 && x >= 40 && x < 39 + 114))
							objectPaletteImage.Pixels[x, y] = 150;
						else
							objectPaletteImage.Pixels[x, y] = 148;
					}
				}
				if (!error) {
					objectPaletteImage.Draw(g, Point.Empty, objectData.GetPalette(drawSettings));
				}
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


			g = Graphics.FromImage(this.iconImage);

			PaletteImage icon2 = this.sceneryGroup.GraphicsData.GetPaletteImage(1);
			icon2.Draw(g, (46 - icon2.Width) / 2, (46 - icon2.Height) / 2, Palette.SceneryGroupPalette);
			g.Dispose();

			this.iconView.Image = this.iconImage;
		}
		/** <summary> Draws the list view columns. </summary> */
		private void ListViewDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
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

			if (currentColumn == e.ColumnIndex) {
				if (currentListOrder)
					e.Graphics.DrawImage(Resources.SortDown, new Point(e.Bounds.Right - 12, e.Bounds.Top + 9));
				else
					e.Graphics.DrawImage(Resources.SortUp, new Point(e.Bounds.Right - 12, e.Bounds.Top + 9));
			}
			fontBold.DrawAligned(e.Graphics, new Rectangle(e.Bounds.Left + 8, e.Bounds.Top, e.Bounds.Width - 16, e.Bounds.Height), HorizontalAlignment.Left, e.Header.Text, Color.Black);

			e.DrawDefault = false;
		}
		/** <summary> Draws the list view items. </summary> */
		private void ListViewDrawItem(object sender, DrawListViewItemEventArgs e) {
			e.DrawDefault = true;
		}
		/** <summary> Draws the list view sub items. </summary> */
		private void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			e.DrawDefault = true;
		}

		#endregion
	}
}
