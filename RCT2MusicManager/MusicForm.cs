using CustomControls;
using NAudio;
using NAudio.Wave;
using NAudio.MediaFoundation;
using RCT2MusicManager.Properties;
using RCT2ObjectData.DataObjects;
using RCT2ObjectData.DataObjects.Types;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;
using RCTDataEditor.DataObjects;
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
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NAudio.Lame;

namespace RCT2MusicManager {
	public partial class MusicForm : Form {

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

		/** <summary> The data directory. </summary> */
		string dataDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Rollercoaster Tycoon 2\\Data";
		/** <summary> The list of songs in the custom music directory. </summary> */
		List<string> loadedSongs = new List<string>();
		/** <summary> The 2 current custom songs being used. </summary> */
		string[] customSongs = new string[]{"", ""};
		/** <summary> The currently selected song. </summary> */
		SoundPlayer currentSong = null;
		/** <summary> True if a song is playing. </summary> */
		bool playing = false;
		/** <summary> True if a song being played is custom. </summary> */
		bool playingCustom = false;

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

		SpriteFont fontBold;

		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public MusicForm() {
			InitializeComponent();

			Pathing.SetPathSprites();
			Water.LoadResources();
			Terrain.LoadResources();
			ColorRemapping.LoadResources();

			this.fontBold = new SpriteFont(Resources.BoldFont, ' ', 'z', 10);

			this.dataDirectory = "";
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
					this.dataDirectory = Environment.ExpandEnvironmentVariables(possibleDirectories[i]);
					break;
				}
			}
			this.LoadSettings(null, null);

			this.LoadSongs(null, null);

			if (!Directory.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music"))) {
				Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music"));
			}

			/*LameMP3FileWriter mp3Writer = null;

			WaveFormat format = new WaveFormat(22050, 2);

			using (AudioFileReader reader = new AudioFileReader(file)) {
				using (var resampler = new MediaFoundationResampler(reader, format)) {
					// resampler.ResamplerQuality = 60;
					using (LameMP3FileWriter writer = new LameMP3FileWriter("css.mp3", format, 22050)) {
						writer.
					}
					LameMP3FileWriter.CreateWaveFile(destination, resampler);
				}
			}*/

			WaveToMP3(Path.Combine(this.dataDirectory, "css3.dat"), "Dodgems Style.mp3", 705);

			TagLib.File f = TagLib.File.Create("Dodgems Style.mp3");
			f.Tag.Album = "RollerCoaster Tycoon 2";
			f.Tag.Artists = new string[] { "Allister Brimble" };
			f.Tag.AlbumArtists = new string[] { "Allister Brimble" };
			f.Tag.Title = "Dodgems Beat";
			f.Tag.Genres = new string[] { "Soundtrack" };
			f.Tag.Track = 13;
			f.Save();

			//Console.WriteLine(MediaFoundationEncoder.GetOutputMediaTypes(AudioSubtypes.MFAudioFormat_MP3));

			/*using (var reader = new MediaFoundationReader(Path.Combine(dataDirectory, "css3.dat"))) {
				MediaFoundationEncoder.EncodeToMp3(reader, "css3.mp3");
			}*/

			/*FileStream stream = new FileStream(Path.Combine(this.dataDirectory, "CSS1.DAT"), FileMode.Open, FileAccess.Read);

			BinaryReader reader = new BinaryReader(stream);

			uint NumSounds = reader.ReadUInt32();
			uint[] Offsets = new uint[NumSounds];
			for (uint i = 0; i < NumSounds; i++) {
				Offsets[i] = reader.ReadUInt32();
			}
			uint DataSize = reader.ReadUInt32();
			WaveFormat format = new WaveFormat(22050, 16, 1);
			for (uint i = 0; i < NumSounds; i++) {
				stream.Position = (long)Offsets[i];
				using (WaveFileWriter writer = new WaveFileWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Sounds", i.ToString() + ".wav"), format)) {
					uint length = reader.ReadUInt32();
					Console.WriteLine(length + " " + (i + 1 < NumSounds ? (Offsets[i + 1] - Offsets[i]).ToString() : ""));
					reader.ReadBytes(24);
					for (int j = 0; j < length; j++) {
						writer.WriteByte(reader.ReadByte());
					}
					writer.Close();
				}
				using (WaveFileReader waveReader = new WaveFileReader(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Sounds", i.ToString() + ".wav"))) {
					//WaveOut outDevice = new WaveOut();
					//outDevice.Init(waveReader);
					//outDevice.Play();
					SoundPlayer song = new SoundPlayer(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Sounds", i.ToString() + ".wav"));
					song.Play();
					Thread.Sleep((int)waveReader.TotalTime.TotalMilliseconds);
				}
			}

			SoundPlayer song2 = new SoundPlayer(Path.Combine(this.dataDirectory, "CSS43.DAT"));
			song2.Play();

			stream.Close();*/
		}

		public static void WaveToMP3(string waveFileName, string mp3FileName, int bitRate = 128) {
			using (var reader = new WaveFileReader(waveFileName))
			using (var writer = new LameMP3FileWriter(mp3FileName, reader.WaveFormat, bitRate))
				reader.CopyTo(writer);
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
			string pathToSettings = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Music Manager.xml");
			if (File.Exists(pathToSettings)) {
				XmlDocument doc = new XmlDocument();
				doc.Load(pathToSettings);
				XmlNodeList element;

				element = doc.GetElementsByTagName("DataDirectory");
				if (element.Count != 0) this.dataDirectory = element[0].InnerText;

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

			XmlElement element = doc.CreateElement("DataDirectory");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.dataDirectory));

			doc.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Music Manager.xml"));
		}
		/** <summary> Called when the browse data directory button is pressed. </summary> */
		private void BrowseDataDirectory(object sender, EventArgs e) {
			this.dataBrowserDialog.SelectedPath = this.dataDirectory;
			if (this.dataBrowserDialog.ShowDialog() == DialogResult.OK) {
				this.dataDirectory = this.dataBrowserDialog.SelectedPath;
				this.SaveSettings(null, null);
				LoadSongs(null, null);
			}
		}
		private void LoadCustomSongs() {
			for (int i = 0; i < this.listViewSongs.Items.Count; i++) {
				if (this.listViewSongs.Items[i].Group == this.listViewSongs.Groups["customMusic"]) {
					this.listViewSongs.Items.RemoveAt(i);
					i--;
				}
			}

			for (int i = 1; i < 3; i++) {
				try {
					SoundPlayer song = new SoundPlayer(Path.Combine(this.dataDirectory, "CUSTOM" + i.ToString() + ".WAV"));
					song.Dispose();

					ListViewItem item = new ListViewItem(this.listViewSongs.Groups["customMusic"]);
					item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "CUSTOM" + i.ToString() + ".WAV"));

					using (WaveFileReader reader = new WaveFileReader(Path.Combine(this.dataDirectory, "CUSTOM" + i.ToString() + ".WAV"))) {
						item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader.TotalTime.ToString((reader.TotalTime.TotalHours >= 1) ? @"hh\:mm\:ss" : @"mm\:ss")));
					}

					this.listViewSongs.Items.Add(item);
				}
				catch (Exception) {

				}
			}
		}

		/** <summary> Loads the custom songs from the file directory. </summary> */
		private void LoadSongs(object sender, EventArgs e) {
			if (playing) {
				playing = false;
				playingCustom = false;
				this.currentSong.Stop();
				this.buttonPlay.Text = "Play";
			}

			try {
				string[] files = null;
				files = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music"));

				this.listViewSongs.Items.Clear();

				for (int i = 1; i < 3; i++) {
					try {
						if (File.Exists(Path.Combine(this.dataDirectory, "CUSTOM" + i.ToString() + ".WAV"))) {
							SoundPlayer song = new SoundPlayer(Path.Combine(this.dataDirectory, "CUSTOM" + i.ToString() + ".WAV"));
							song.Dispose();

							ListViewItem item = new ListViewItem(this.listViewSongs.Groups["customMusic"]);
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "CUSTOM" + i.ToString() + ".WAV"));

							using (WaveFileReader reader = new WaveFileReader(Path.Combine(this.dataDirectory, "CUSTOM" + i.ToString() + ".WAV"))) {
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader.TotalTime.ToString((reader.TotalTime.TotalHours >= 1) ? @"hh\:mm\:ss" : @"mm\:ss")));
							}

							this.listViewSongs.Items.Add(item);


						}
					}
					catch (Exception) {

					}
				}

				for (int i = 0; i < files.Length; i++) {
					try {
						if (Path.GetExtension(files[i]).ToLower() == ".wav") {
							SoundPlayer song = new SoundPlayer(files[i]);
							song.Dispose();

							ListViewItem item = new ListViewItem(this.listViewSongs.Groups["musicList"]);
							item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(files[i])));

							using (WaveFileReader reader = new WaveFileReader(files[i])) {
								item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader.TotalTime.ToString((reader.TotalTime.TotalHours >= 1) ? @"hh\:mm\:ss" : @"mm\:ss")));
							}

							this.listViewSongs.Items.Add(item);
						}
					}
					catch (Exception) {

					}
				}
			}
			catch (Exception) {

			}
		}

		private void ConvertMusicFile(string file, string destination) {
			WaveFormat format = new WaveFormat(22050, 2);

			using (AudioFileReader reader = new AudioFileReader(file)) {
				using (var resampler = new MediaFoundationResampler(reader, format)) {
					// resampler.ResamplerQuality = 60;
					WaveFileWriter.CreateWaveFile(destination, resampler);
				}
			}
		}

		private void PlaySong(object sender, EventArgs e) {
			if (sender == null || !playing) {
				if (this.listViewSongs.SelectedItems.Count > 0) {
					try {
						if (this.listViewSongs.SelectedItems[0].Group == this.listViewSongs.Groups["customMusic"]) {
							this.currentSong = new SoundPlayer(Path.Combine(this.dataDirectory, this.listViewSongs.SelectedItems[0].SubItems[1].Text));
							playingCustom = true;
						}
						else {
							this.currentSong = new SoundPlayer(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", this.listViewSongs.SelectedItems[0].SubItems[1].Text));
							playingCustom = false;
						}
						this.currentSong.PlayLooping();
						this.buttonPlay.Text = "Stop";
						playing = true;
						for (int i = 0; i < this.listViewSongs.Items.Count; i++) {
							this.listViewSongs.Items[i].ImageIndex = 0;
						}
						this.listViewSongs.SelectedItems[0].ImageIndex = 1;
					}
					catch (Exception) {

					}
				}
			}
			else {
				if (this.currentSong != null) {
					this.currentSong.Stop();
				}
				this.buttonPlay.Text = "Play";
				playing = false;
				playingCustom = false;
				for (int i = 0; i < this.listViewSongs.Items.Count; i++) {
					this.listViewSongs.Items[i].ImageIndex = 0;
				}
			}
		}

		private void SetCustom1(object sender, EventArgs e) {
			try {
				if (this.listViewSongs.SelectedItems.Count > 0) {
					if (this.listViewSongs.SelectedItems[0].Group != this.listViewSongs.Groups["customMusic"]) {
						File.Copy(
							Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", this.listViewSongs.SelectedItems[0].SubItems[1].Text),
							Path.Combine(this.dataDirectory, "CUSTOM1.WAV")
						, true);
						LoadCustomSongs();
						if (playingCustom) {
							this.currentSong.Stop();
							this.playing = false;
							this.playingCustom = false;
							this.buttonPlay.Text = "Play";
						}
					}
				}
			}
			catch (Exception exception) {

			}
		}

		private void SetCustom2(object sender, EventArgs e) {
			try {
				if (this.listViewSongs.SelectedItems.Count > 0) {
					if (this.listViewSongs.SelectedItems[0].Group != this.listViewSongs.Groups["customMusic"]) {
						File.Copy(
							Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", this.listViewSongs.SelectedItems[0].SubItems[1].Text),
							Path.Combine(this.dataDirectory, "CUSTOM2.WAV")
						, true);
						LoadCustomSongs();
						if (playingCustom) {
							this.currentSong.Stop();
							this.playing = false;
							this.playingCustom = false;
							this.buttonPlay.Text = "Play";
						}
					}
				}
			}
			catch (Exception exception) {

			}
		}

		private void RenameSong(object sender, EventArgs e) {

			if (this.listViewSongs.SelectedItems.Count > 0) {
				if (this.listViewSongs.SelectedItems[0].Group != this.listViewSongs.Groups["customMusic"]) {
					using (RenameMessageBox messageBox = new RenameMessageBox(Path.GetFileNameWithoutExtension(this.listViewSongs.SelectedItems[0].SubItems[1].Text))) {
						if (messageBox.ShowDialog(this) == DialogResult.OK) {
							string newName = Path.GetFileNameWithoutExtension(messageBox.NewName) + ".wav";
							if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", newName))) {
								ErrorMessageBox.Show(this, "A song already exists with that name.", "");
							}
							else {
								File.Move(
									Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", this.listViewSongs.SelectedItems[0].SubItems[1].Text),
									Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", newName)
								);
								this.listViewSongs.SelectedItems[0].SubItems[1].Text = newName;
								if (this.listViewSongs.SelectedItems[0].ImageIndex == 1) {
									this.listViewSongs.SelectedItems[0].ImageIndex = 0;
									this.currentSong.Stop();
									this.playing = false;
									this.playingCustom = false;
									this.buttonPlay.Text = "Play";
								}
							}
						}
					}
				}
			}
		}

		/** <summary> Called when an object is selected from the list. </summary> */
		private void SongChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
			
		}

		private void SongDoubleClick(object sender, MouseEventArgs e) {
			if (this.listViewSongs.GetItemAt(e.Location.X, e.Location.Y) != null) {
				PlaySong(null, null);
			}
		}


		private void Refresh(object sender, EventArgs e) {
			LoadSongs(null, null);
		}
		/** <summary> Opens the about form. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
		/** <summary> Called when the delete button is pressed in the scenery list. </summary> */
		private void DeleteSong(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				if (WarningMessageBox.Show(this, "Are you sure you want to delete", "these songs?") == DialogResult.Yes) {
					for (int i = this.listViewSongs.SelectedItems.Count - 1; i >= 0; i--) {
						if (this.listViewSongs.SelectedItems[i].ImageIndex == 1) {
							this.currentSong.Stop();
							this.playing = false;
							this.playingCustom = false;
							this.buttonPlay.Text = "Play";
						}
						if (this.listViewSongs.SelectedItems[i].Group == this.listViewSongs.Groups["customMusic"]) {
							File.Delete(Path.Combine(this.dataDirectory, this.listViewSongs.SelectedItems[i].SubItems[1].Text));
							this.listViewSongs.Items.RemoveAt(this.listViewSongs.SelectedItems[i].Index);
						}
						else {
							File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", this.listViewSongs.SelectedItems[i].SubItems[1].Text));
							this.listViewSongs.Items.RemoveAt(this.listViewSongs.SelectedItems[i].Index);
						}
					}
				}
			}
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
		

		#endregion
		//============= TABS =============
		#region Tabs


		#endregion
		//=========== BUTTONS ============
		#region Buttons


		#endregion
		//=========== VISUALS ============
		#region Visuals

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

			fontBold.DrawAligned(e.Graphics, new Rectangle(e.Bounds.Left + 8, e.Bounds.Top, e.Bounds.Width - 16, e.Bounds.Height), HorizontalAlignment.Left, e.Header.Text, Color.Black);

			e.DrawDefault = false;
		}

		private void ListViewDrawItem(object sender, DrawListViewItemEventArgs e) {
			e.DrawDefault = true;
		}

		private void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			e.DrawDefault = true;
		}

		/** <summary> Called when a dragged object has entered the list. </summary> */
		private void SongDragEnter(object sender, DragEventArgs e) {
			e.Effect= DragDropEffects.All;
		}
		private void SongDragDrop(object sender, DragEventArgs e) {

			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				bool invalid = false;
				bool invalidType = false;
				bool alreadyExists = false;
				bool error = false;
				string[] fileDrops = (string[])(e.Data.GetData(DataFormats.FileDrop));
				for (int i = 0; i < fileDrops.Length; i++) {
					try {
						string file = fileDrops[i];
						if (File.Exists(file)) {
							if (Path.GetExtension(file).ToLower() == ".wav") {
								using (WaveFileReader reader = new WaveFileReader(file)) {
									if (reader.WaveFormat.SampleRate == 22050 && reader.WaveFormat.Encoding == WaveFormatEncoding.Pcm && reader.WaveFormat.Channels == 2) {
										if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", Path.GetFileName(file)))) {
											SoundPlayer song = new SoundPlayer(file);
											song.Dispose();

											File.Copy(
												file,
												Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", Path.GetFileName(file))
											, false);

											ListViewItem item = new ListViewItem(this.listViewSongs.Groups["musicList"]);
											item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(file)));

											using (WaveFileReader reader2 = new WaveFileReader(file)) {
												item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader2.TotalTime.ToString((reader2.TotalTime.TotalHours >= 1) ? @"hh\:mm\:ss" : @"mm\:ss")));
											}

											this.listViewSongs.Items.Add(item);
										}
										else {
											alreadyExists = true;
										}
									}
									else {
										invalidType = true;
									}
								}
							}
							else {
								invalidType = true;
							}
							if (invalidType) {
								try {
									string newfile = Path.GetFileNameWithoutExtension(file) + ".wav";
									this.ConvertMusicFile(file, Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", Path.GetFileName(newfile)));

									ListViewItem item = new ListViewItem(this.listViewSongs.Groups["musicList"]);
									item.SubItems.Add(new ListViewItem.ListViewSubItem(item, Path.GetFileName(newfile)));

									using (WaveFileReader reader = new WaveFileReader(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Custom Music", Path.GetFileName(newfile)))) {
										item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader.TotalTime.ToString((reader.TotalTime.TotalHours >= 1) ? @"hh\:mm\:ss" : @"mm\:ss")));
									}

									this.listViewSongs.Items.Add(item);
								}
								catch (Exception) {
									error = true;
								}
							}
						}
						else {
							invalid = true;
						}
					}
					catch (Exception) {
						invalid = true;
					}
				}
				if (error) {
					ErrorMessageBox.Show(this, "There was an error converting some", "songs and they were not added.");
				}
				else if (invalidType) {
					ErrorMessageBox.Show(this, "Some songs were not the proper", "format and were converted.");
				}
				if (alreadyExists) {
					ErrorMessageBox.Show(this, "Some songs already existed with", "their name and were not added.");
				}
				if (invalid) {
					ErrorMessageBox.Show(this, "Some songs were invalid or missing", "and were not added.");
				}
			}
		}
	}
}
