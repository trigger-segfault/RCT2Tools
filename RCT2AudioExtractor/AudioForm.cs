using CustomControls;
using NAudio;
using NAudio.Lame;
using NAudio.Wave;
using RCT2AudioExtractor.Properties;
using RCT2ObjectData.Drawing;
using RCT2ObjectData.Objects;
using RCT2ObjectData.Objects.Types;
using RCT2ObjectData.Objects.Types.AttractionInfo;
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

namespace RCT2AudioExtractor {
	public partial class AudioForm : Form {

		//========== CONSTANTS ===========
		#region Constants

		#endregion
		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The directory containing css files. </summary> */
		string dataDirectory = "";
		/** <summary> The output directory for the files. </summary> */
		string outputDirectory = "";
		/** <summary> True if the files are named. </summary> */
		bool nameFormat = true;
		/** <summary> Extracts music as well. </summary> */
		bool extractMusicAsMp3 = true;

		#endregion
		//--------------------------------
		#region Extracting

		/** <summary> The offsets for the sounds in css1.dat. </summary> */
		uint[] css1Offsets = null;
		/** <summary> The number of sounds in css1.dat. </summary> */
		uint css1NumSounds = 0;
		/** <summary> The current file being extracted from. </summary> */
		int extractFileIndex = 1;
		/** <summary> The index of the currently extracted image. </summary> */
		int css1Index = 0;
		/** <summary> The starting time of extraction. </summary> */
		DateTime extractStart = DateTime.Now;
		/** <summary> The file reader for extraction. </summary> */
		BinaryReader reader = null;
		
		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public AudioForm() {
			InitializeComponent();

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
		}

		#endregion
		//=========== SETTINGS ===========
		#region Settings

		/** <summary> Called to load the settings file. </summary> */
		private void LoadSettings(object sender, EventArgs e) {
			string pathToSettings = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Audio Extractor.xml");
			if (File.Exists(pathToSettings)) {
				XmlDocument doc = new XmlDocument();
				doc.Load(pathToSettings);
				XmlNodeList element;

				element = doc.GetElementsByTagName("DataDirectory");
				if (element.Count != 0) this.dataDirectory = element[0].InnerText;

				element = doc.GetElementsByTagName("OutputDirectory");
				if (element.Count != 0) this.outputDirectory = element[0].InnerText;

				element = doc.GetElementsByTagName("NameFormat");
				if (element.Count != 0) this.nameFormat = Boolean.Parse(element[0].InnerText);

				element = doc.GetElementsByTagName("ExtractMusicAsMP3");
				if (element.Count != 0) this.extractMusicAsMp3 = Boolean.Parse(element[0].InnerText);

				this.checkBoxDecimal.CheckState = (!this.nameFormat ? CheckState.Checked : CheckState.Unchecked);
				this.checkBoxNames.CheckState = (this.nameFormat ? CheckState.Checked : CheckState.Unchecked);
				this.checkBoxMusic.CheckState = (this.extractMusicAsMp3 ? CheckState.Checked : CheckState.Unchecked);
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

			element = doc.CreateElement("OutputDirectory");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.outputDirectory));

			element = doc.CreateElement("NameFormat");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.nameFormat.ToString()));

			element = doc.CreateElement("ExtractMusicAsMP3");
			settings.AppendChild(element);
			element.AppendChild(doc.CreateTextNode(this.extractMusicAsMp3.ToString()));


			doc.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Settings - Audio Extractor.xml"));
		}

		#endregion
		//========== EXTRACTING ==========
		#region Extracting

		/** <summary> Called by the timer to extract the images. </summary> */
		private void Extracting(object sender, EventArgs e) {

			if (this.extractFileIndex == 1) {
				for (int i = 0; i < 5 && this.css1Index < this.css1NumSounds; i++, this.css1Index++) {
					reader.BaseStream.Position = (long)this.css1Offsets[this.css1Index];
					WaveFormat format = new WaveFormat(22050, 16, 1);
					string soundName = (this.nameFormat ? GetSoundName(this.extractFileIndex, this.css1Index) : this.extractFileIndex.ToString() + "-" + this.css1Index.ToString());
					if (this.css1Index == 28 || this.css1Index == 44) { // A stereo sound
						format = new WaveFormat(22050, 16, 2);
					}
					using (WaveFileWriter writer = new WaveFileWriter(Path.Combine(this.outputDirectory, soundName + ".wav"), format)) {
						uint length = reader.ReadUInt32();
						reader.ReadBytes(20);
						for (int j = 0; j < length; j++) {
							writer.WriteByte(reader.ReadByte());
						}
						writer.Close();
					}
				}
				if (this.css1Index == this.css1NumSounds) {
					reader.Close();
					this.extractFileIndex++;
				}
			}
			else {
				if (IsSong(this.extractFileIndex)) {
					SongInfo info = GetSongInfo(this.extractFileIndex);
					if (this.extractMusicAsMp3) {
						WriteSong(
							Path.Combine(this.dataDirectory, "css" + this.extractFileIndex.ToString() + ".dat"),
							Path.Combine(this.outputDirectory, "Music", info.RCT2Title + ".mp3"),
							info
						);
					}
					else {
						File.Copy(
							Path.Combine(this.dataDirectory, "css" + this.extractFileIndex.ToString() + ".dat"),
							Path.Combine(this.outputDirectory, "Music", info.RCT2Title + ".wav"),
							true
						);
					}
				}
				else if (this.extractFileIndex != 10 && this.extractFileIndex != 16) {
					string soundName = (this.nameFormat ? GetSoundName(this.extractFileIndex, 0) : this.extractFileIndex.ToString());
					File.Copy(
						Path.Combine(this.dataDirectory, "css" + this.extractFileIndex.ToString() + ".dat"),
						Path.Combine(this.outputDirectory, soundName + ".wav"),
						true
					);
				}
				this.extractFileIndex++;
			}
			this.loadingBar.Width = 274 * (this.css1Index + this.extractFileIndex - 1) / ((int)this.css1NumSounds + 46);
			if ((this.css1Index + this.extractFileIndex - 1) == ((int)this.css1NumSounds + 46)) {
				reader.Close();
				this.labelComplete.Visible = true;
				this.labelComplete.Text = "Finished - Took " + Math.Round((DateTime.Now - this.extractStart).TotalSeconds) + " seconds";
				this.timerExtract.Stop();
			}
		}

		#endregion
		//============ EVENTS ============
		#region Events

		/** <summary> Shows the about box. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
		/** <summary> Changes the g1.dat directory. </summary> */
		private void ChangeDataDirectory(object sender, EventArgs e) {
			if (!this.timerExtract.Enabled) {
				this.folderBrowserDialog.SelectedPath = this.dataDirectory;
				if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					this.dataDirectory = this.folderBrowserDialog.SelectedPath;
				}
			}
		}
		/** <summary> Changes the output directory. </summary> */
		private void ChangeOutputDirectory(object sender, EventArgs e) {
			if (!this.timerExtract.Enabled) {
				this.folderBrowserDialogOutput.SelectedPath = this.outputDirectory;
				if (this.folderBrowserDialogOutput.ShowDialog() == DialogResult.OK) {
					this.outputDirectory = this.folderBrowserDialogOutput.SelectedPath;
				}
			}
		}
		/** <summary> Changes the numbering format to decimal. </summary> */
		private void NumberFormat(object sender, EventArgs e) {
			if (this.timerExtract.Enabled) {
				this.checkBoxDecimal.CheckState = (!this.nameFormat ? CheckState.Checked : CheckState.Unchecked);
			}
			else if (this.checkBoxDecimal.CheckState == CheckState.Checked) {
				this.nameFormat = false;
				this.checkBoxNames.CheckState = CheckState.Unchecked;
			}
			else {
				this.nameFormat = true;
				this.checkBoxNames.CheckState = CheckState.Checked;
			}
		}
		/** <summary> Changes the numbering format to hex. </summary> */
		private void NameFormat(object sender, EventArgs e) {
			if (this.timerExtract.Enabled) {
				this.checkBoxNames.CheckState = (this.nameFormat ? CheckState.Checked : CheckState.Unchecked);
			}
			else if (this.checkBoxNames.CheckState == CheckState.Checked) {
				this.nameFormat = true;
				this.checkBoxDecimal.CheckState = CheckState.Unchecked;
			}
			else {
				this.nameFormat = false;
				this.checkBoxDecimal.CheckState = CheckState.Checked;
			}
		}
		/** <summary> Extracts RCT2 versions of the images. </summary> */
		private void ExtractMusic(object sender, EventArgs e) {
			this.extractMusicAsMp3 = (this.checkBoxMusic.CheckState == CheckState.Checked);
		}
		/** <summary> Starts the image extraction. </summary> */
		private void Extract(object sender, EventArgs e) {
			if (!this.timerExtract.Enabled) {
				SaveSettings(null, null);
				this.loadingBar.Visible = false;
				this.labelComplete.Visible = false;
				if (File.Exists(Path.Combine(this.dataDirectory, "g1.dat"))) {
					if (Directory.Exists(this.outputDirectory)) {
						this.extractFileIndex = 1;
						this.labelError.Visible = false;
						this.css1Index = 0;
						this.css1NumSounds = 0;
						this.css1Offsets = null;
						this.loadingBar.Width = 0;
						this.loadingBar.Visible = true;

						this.extractStart = DateTime.Now;

						if (!Directory.Exists(Path.Combine(this.outputDirectory, "Music"))) {
							Directory.CreateDirectory(Path.Combine(this.outputDirectory, "Music"));
						}

						this.reader = new BinaryReader(new FileStream(Path.Combine(this.dataDirectory, "css1.dat"), FileMode.Open, FileAccess.Read), Encoding.Unicode);

						this.css1NumSounds = this.reader.ReadUInt32();
						this.css1Offsets = new uint[this.css1NumSounds];
						for (int i = 0; i < (int)this.css1NumSounds; i++) {
							this.css1Offsets[i] = this.reader.ReadUInt32();
						}
						this.reader.ReadUInt32();

						this.timerExtract.Start();
					}
					else {
						this.labelError.Visible = true;
						this.labelError.Text = "Error with output directory";
					}
				}
				else {
					this.labelError.Visible = true;
					this.labelError.Text = "Error with Data directory";
				}
			}
		}

		public static void WriteSong(string waveFileName, string mp3FileName, SongInfo info) {

			using (AudioFileReader reader = new AudioFileReader(waveFileName)) {
				//Console.WriteLine(reader.WaveFormat.BitsPerSample);
				WaveFormat format = WaveFormat.CreateIeeeFloatWaveFormat(reader.WaveFormat.SampleRate, reader.WaveFormat.Channels);//new WaveFormat(reader.WaveFormat.SampleRate, 16, 2)
				using (var resampler = new MediaFoundationResampler(reader, format)) {
					// resampler.ResamplerQuality = 60;
					WaveFileWriter.CreateWaveFile(Path.GetFileNameWithoutExtension(mp3FileName) + ".wav", resampler);
				}
			}

			using (WaveFileReader reader = new WaveFileReader(Path.GetFileNameWithoutExtension(mp3FileName) + ".wav")) {
				using (LameMP3FileWriter writer = new LameMP3FileWriter(mp3FileName, reader.WaveFormat, 705)) {
					//Console.WriteLine(reader.WaveFormat.BitsPerSample);
					reader.CopyTo(writer);
				}
			}

			File.Delete(Path.GetFileNameWithoutExtension(mp3FileName) + ".wav");

			TagLib.File f = TagLib.File.Create(mp3FileName);
			f.Tag.Album = info.Album;
			f.Tag.Artists = new string[] { info.Artist };
			f.Tag.AlbumArtists = new string[] { info.Artist };
			f.Tag.Title = info.Title;
			f.Tag.Genres = new string[] { "Soundtrack" };
			f.Tag.Track = (uint)info.TrackNumber;
			f.Save();
		}
		public bool IsSong(int cssIndex) {
			return GetSongInfo(cssIndex).TrackNumber != 0;
		}

		public SongInfo GetSongInfo(int cssIndex) {
			// Artists (To prevent mispelling multiple times)
			string allister = "Allister Brimble";
			string julius = "Julius Fucik";
			string jonny = "Jonny Heykens";
			string johann = "Johann Strauss II";
			string franz = "Franz von Suppe";
			string scott = "Scott Joplin";
			string steve = "Steve Blenkinsopp";
			string charles = "Charles-Marie Widor";

			string anonymous = "[anonymous]";
			string traditional = "[traditional]";

			switch (cssIndex) {
			// Title
			case 17: return new SongInfo(1, "RollerCoaster Tycoon 2 Title Music", "Title Music", allister);

			// Merry-Go-Round
			case 4: return new SongInfo(2, "Children of the Regiment", "Fairground Organ Style 1", julius);
			case 5: return new SongInfo(3, "Seranade, op. 21", "Fairground Organ Style 2", jonny);
			case 6: return new SongInfo(4, "In Continental Mood", "Fairground Organ Style 3", anonymous);
			case 7: return new SongInfo(5, "Wedding Journey", "Fairground Organ Style 4", traditional);
			case 8: return new SongInfo(6, "Tales from the Vienna Woods", "Fairground Organ Style 5", johann);
			case 9: return new SongInfo(7, "Slavonic Dance", "Fairground Organ Style 6", traditional);
			case 11: return new SongInfo(8, "Das Alpenhorn", "Fairground Organ Style 7", traditional);
			case 13: return new SongInfo(9, "The Blond Sailor", "Fairground Organ Style 8", traditional);
			case 14: return new SongInfo(10, "Poet & Peasant Overture", "Fairground Organ Style 9", franz);
			case 15: return new SongInfo(11, "Waltz Medley", "Fairground Organ Style 10", johann);
			case 12: return new SongInfo(12, "Bella Bella Bimba", "Fairground Organ Style 11", traditional);

			// Ride Songs
			case 3: return new SongInfo(13, "Dodgems Beat", "Dodgems Beat Style", allister);
			case 29: return new SongInfo(14, "Mid Summer's Heat", "Summer Style", allister);
			case 22: return new SongInfo(15, "Pharaoh's Tomb", "Egyptian Style", allister);
			case 18: return new SongInfo(16, "Caesar's March", "Roman Fanfare Style", allister);
			case 28: return new SongInfo(17, "Drifting to Heaven", "Gentle Style", allister);
			case 20: return new SongInfo(18, "Invaders", "Martian Style", allister);
			case 23: return new SongInfo(19, "Eternal Toybox", "Toyland Style", allister);
			case 21: return new SongInfo(20, "Jungle Juice", "Jungle Drums Style", allister);
			case 19: return new SongInfo(21, "Ninja's Noodles", "Oriental Style", allister);
			case 25: return new SongInfo(22, "Voyage to Andromeda", "Space Style", allister);
			case 27: return new SongInfo(23, "Brimble's Beat", "Techno Style", allister);
			case 30: return new SongInfo(24, "Atlantis", "Water Style", allister);
			case 31: return new SongInfo(25, "Wild West Kid", "Wild West Style", allister);
			case 26: return new SongInfo(26, "Vampire's Lair", "Horror Style", allister);
			case 32: return new SongInfo(27, "Blockbuester", "Jurassic Style", allister);
			case 33: return new SongInfo(28, "Airtime Rock", "Rock Style", allister);

			case 34: return new SongInfo(29, "Searchlight Rag", "Ragtime Style", scott);

			case 35: return new SongInfo(30, "Flight of Fantasy", "Fantasy Style", steve);

			case 36: return new SongInfo(31, "Big Rock", "Rock Style 2", allister);
			case 37: return new SongInfo(32, "Hypothermia", "Ice Style", allister);
			case 38: return new SongInfo(33, "Last Sleigh Ride", "Snow Style", allister);
			case 39: return new SongInfo(34, "Pipes of Glencairn", "Medieval Style", allister);
			case 40: return new SongInfo(35, "Traffic Jam", "Urban Style", allister);

			case 41: return new SongInfo(36, "Toccata", "Organ Style", charles);

			case 45: return new SongInfo(37, "Space Rock", "Rock Style 3", allister);
			case 42: return new SongInfo(38, "Manic Mechanic", "Mechanical Style", allister);
			case 43: return new SongInfo(39, "Techno Torture", "Modern Style", allister);
			case 46: return new SongInfo(40, "Sweat Dreams", "Candy Style", allister);

			case 44: return new SongInfo(41, "What Shall we do with the Drunken Sailor", "Pirates Style", traditional);
			}
			return new SongInfo();
		}

		public string GetSoundName(int cssIndex, int css1Index = 0) {
			if (cssIndex == 1) {
				switch (css1Index) {
				case 0: return "Chain Lift 1";
				case 1: return "Coaster 1";
				case 2: return "Coaster 2";
				case 3: return "Scream 1";
				case 4: return "Click 1";
				case 5: return "Click 2";
				case 6: return "Place Land";
				case 7: return "Scream 2";
				case 8: return "Scream 3";
				case 9: return "Scream 4";
				case 10: return "Scream 5";
				case 11: return "Scream 6";
				case 12: return "Chain Lift 2";
				case 13: return "Money";
				case 14: return "Explosion";
				case 15: return "Place Water";
				case 16: return "Splash 1";
				case 17: return "Splash 2";
				case 18: return "Train Whistle";
				case 19: return "Train Whistle Chugging";
				case 20: return "Boat Splash";
				case 21: return "Go Karts";
				case 22: return "Vertical Launch 1";
				case 23: return "Vertical Launch 2";
				case 24: return "Cough 1";
				case 25: return "Cough 2";
				case 26: return "Cough 3";
				case 27: return "Cough 4";
				case 28: return "Rain 1"; // Stereo
				case 29: return "Thunder 1";
				case 30: return "Thunder 2";

				case 31: return "Miniature Train Running";
				case 32: return "Rain 2";

				case 33: return "Balloon Pop";
				case 34: return "Repair Broken Brakes";
				case 35: return "Scream 7";
				case 36: return "Toilet Flush";
				case 37: return "Click 3";
				case 38: return "Duck Quack";
				case 39: return "Notification";
				case 40: return "Window Open";
				case 41: return "Happy 1";
				case 42: return "Happy 2";
				case 43: return "Happy 3";
				case 44: return "Scenario Complete"; // Stereo
				case 45: return "Haunted House";
				case 46: return "Haunted House Scream";
				case 47: return "Cry 1";
				case 48: return "Brakes 1";
				case 49: return "Brakes 2";
				case 50: return "Error";
				case 51: return "Brakes 3";
				case 52: return "Chain Lift 3";
				case 53: return "Chain Lift 4";
				case 54: return "Coaster 3";
				case 55: return "Chain Lift 5";
				case 56: return "Chain Lift 6";
				case 57: return "Coaster 4";
				case 58: return "Cry 2";
				case 59: return "Tram Bell";
				case 60: return "Door Squeaky Open";
				case 61: return "Door Squeaky Close";
				case 62: return "Door Portcullis Open";
				}
			}
			else if (cssIndex == 2) {
				return "Crowd";
			}
			else if (cssIndex == 24) {
				return "Circus";
			}
			return "I MISSED A SOUND NAME";
		}

		#endregion
		//=========== LOADING ============
		#region Loading

		/** <summary> Called when the form loads. </summary> */
		private void OnFormLoad(object sender, EventArgs e) {
			SetFeatureToAllControls(this.Controls);
		}

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
	}
	public struct SongInfo {
		public string Title;
		public string Artist;
		public string Album;
		public string RCT2Title;
		public int TrackNumber;

		public SongInfo(int trackNo, string name, string rct2Name, string artist) {
			this.TrackNumber = trackNo;
			this.Title = name;
			this.RCT2Title = rct2Name;
			this.Artist = artist;
			this.Album = "RollerCoaster Tycoon 2";
		}
	}
}
