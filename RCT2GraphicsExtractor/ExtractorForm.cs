using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCTDataEditor.DataObjects;
using System.IO;
using System.Drawing.Drawing2D;
using CustomControls;

namespace RCT2GraphicsExtractor {
	public partial class ExtractorForm : Form {

		//========== CONSTANTS ===========
		#region Constants

		#endregion
		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The directory containing g1.dat. </summary> */
		string g1Directory = "";
		/** <summary> The output directory for the files. </summary> */
		string outputDirectory = "";
		/** <summary> True if the files are numbered using hex. </summary> */
		bool hexFormat = false;
		/** <summary> Extracts RCT2 versions of the images. </summary> */
		bool extractRCT2Images = false;

		#endregion
		//--------------------------------
		#region Extracting

		/** <summary> The image directory listings. </summary> */
		ImageDirectory imageDirectory = new ImageDirectory();
		/** <summary> The graphics data. </summary> */
		GraphicsData graphicsData = new GraphicsData();

		/** <summary> The file start position for graphics data. </summary> */
		long startPosition = 0;
		/** <summary> The index of the currently extracted image. </summary> */
		int extractIndex = 0;
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
		public ExtractorForm() {
			InitializeComponent();
		}

		#endregion
		//========== EXTRACTING ==========
		#region Extracting

		/** <summary> Called by the timer to extract the images. </summary> */
		private void Extracting(object sender, EventArgs e) {

			for (int i = 0; this.extractIndex < this.imageDirectory.Count && i < 50; i++, this.extractIndex++) {
				Bitmap image = this.graphicsData.Read(reader, startPosition, this.extractIndex, this.imageDirectory, Palette.DefaultPalette);
				if (image != null) {
					if (this.imageDirectory.Entries[this.extractIndex].Flags == RCTDataEditor.DataObjects.ImageFlags.PaletteEntries) {
						image.Save(Path.Combine(this.outputDirectory, "Palettes", this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".png"), System.Drawing.Imaging.ImageFormat.Png);
						StreamWriter writer = new StreamWriter(Path.Combine(this.outputDirectory, "Palettes", this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".txt"));
						writer.Write(GraphicsData.LastPaletteText);
						writer.Close();

						if (this.extractRCT2Images) {
							ImageDirectory id = new ImageDirectory();
							id.Count = 1;
							id.ScanLineLength = this.imageDirectory.ScanLineLength;
							id.Entries.Add(this.imageDirectory.Entries[this.extractIndex]);

							GraphicsData gd = new GraphicsData();
							gd.Palettes.Add(this.graphicsData.ReadPalette(reader, startPosition, this.extractIndex, this.imageDirectory, Palette.DefaultPalette));

							BinaryWriter stream = new BinaryWriter(new FileStream(Path.Combine(this.outputDirectory, "Palettes", this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".rct2img"), FileMode.OpenOrCreate));

							long imageDirectoryPosition = stream.BaseStream.Position;

							// Write the image directory and graphics data
							id.Write(stream);
							gd.Write(stream, id);

							// Rewrite the image directory after the image addresses are known
							long finalPosition = stream.BaseStream.Position;
							stream.BaseStream.Position = imageDirectoryPosition;
							id.Write(stream);

							stream.Close();
						}
					}
					else {
						image.Save(Path.Combine(this.outputDirectory, this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".png"), System.Drawing.Imaging.ImageFormat.Png);
						if (this.extractRCT2Images) {
							ImageDirectory id = new ImageDirectory();
							id.Count = 1;
							id.ScanLineLength = this.imageDirectory.ScanLineLength;
							id.Entries.Add(this.imageDirectory.Entries[this.extractIndex]);

							GraphicsData gd = new GraphicsData();
							gd.PaletteImages.Add(this.graphicsData.ReadPaletteImage(reader, startPosition, this.extractIndex, this.imageDirectory, Palette.DefaultPalette));

							BinaryWriter stream = new BinaryWriter(new FileStream(Path.Combine(this.outputDirectory, this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".rct2img"), FileMode.OpenOrCreate));

							long imageDirectoryPosition = stream.BaseStream.Position;

							// Write the image directory and graphics data
							id.Write(stream);
							gd.Write(stream, id);

							// Rewrite the image directory after the image addresses are known
							long finalPosition = stream.BaseStream.Position;
							stream.BaseStream.Position = imageDirectoryPosition;
							id.Write(stream);

							stream.Close();
						}
					}
				}
			}
			this.loadingBar.Width = 254 * this.extractIndex / this.imageDirectory.Count;
			if (this.extractIndex == this.imageDirectory.Count) {
				reader.Close();
				this.labelComplete.Visible = true;
				this.labelComplete.Text = "Finished - Took " + Math.Round((DateTime.Now - this.extractStart).TotalSeconds) + " seconds";
				this.timerExtract.Stop();
			}
		}
		/** <summary> Extracts the specified letters into a sprite font. </summary> */
		private void ExtractSpriteFont(BinaryReader reader, string name, bool outline, int startIndex, int endIndex, int imageWidth, int imageHeight, int fontHeight) {
			Point fontPos = new Point(1, 1);

			Bitmap spriteFont = new Bitmap(imageWidth, imageHeight);

			Graphics g = Graphics.FromImage(spriteFont);
			g.CompositingMode = CompositingMode.SourceCopy;
			g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, imageWidth, imageHeight));

			for (int i = startIndex; i <= endIndex; i++) {
				Bitmap image = this.graphicsData.Read(reader, startPosition, i, this.imageDirectory, (outline ? Palette.FontOutlinePalette : Palette.FontPalette));
				ImageEntry entry = imageDirectory.Entries[i];
				if (fontPos.X + (entry.Width + Math.Abs(entry.XOffset)) + 2 > spriteFont.Width) {
					fontPos.X = 1;
					fontPos.Y += fontHeight + 1;
				}
				g.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(fontPos, new Size((entry.Width + Math.Abs(entry.XOffset)), fontHeight)));
				if (image.Height + entry.YOffset <= fontHeight)
					g.DrawImage(image, Point.Add(fontPos, new Size(entry.XOffset, entry.YOffset)));

				fontPos.X += (entry.Width + Math.Abs(entry.XOffset)) + 1;
			}

			g.Dispose();

			spriteFont.Save(Path.Combine(this.outputDirectory, "Fonts", name + ".png"), System.Drawing.Imaging.ImageFormat.Png);
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
		private void ChangeG1Directory(object sender, EventArgs e) {
			if (!this.timerExtract.Enabled) {
				this.folderBrowserDialog.SelectedPath = this.g1Directory;
				if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					this.g1Directory = this.folderBrowserDialog.SelectedPath;
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
		private void DecimalFormat(object sender, EventArgs e) {
			if (this.timerExtract.Enabled) {
				this.checkBoxDecimal.CheckState = (!this.hexFormat ? CheckState.Checked : CheckState.Unchecked);
			}
			else if (this.checkBoxDecimal.CheckState == CheckState.Checked) {
				this.hexFormat = false;
				this.checkBoxHex.CheckState = CheckState.Unchecked;
			}
			else {
				this.hexFormat = true;
				this.checkBoxHex.CheckState = CheckState.Checked;
			}
		}
		/** <summary> Changes the numbering format to hex. </summary> */
		private void HexFormat(object sender, EventArgs e) {
			if (this.timerExtract.Enabled) {
				this.checkBoxHex.CheckState = (this.hexFormat ? CheckState.Checked : CheckState.Unchecked);
			}
			else if (this.checkBoxHex.CheckState == CheckState.Checked) {
				this.hexFormat = true;
				this.checkBoxDecimal.CheckState = CheckState.Unchecked;
			}
			else {
				this.hexFormat = false;
				this.checkBoxDecimal.CheckState = CheckState.Checked;
			}
		}
		/** <summary> Extracts RCT2 versions of the images. </summary> */
		private void ExtractRCT2Images(object sender, EventArgs e) {
			this.extractRCT2Images = (this.checkBoxRCT2Images.CheckState == CheckState.Checked);
		}
		/** <summary> Starts the image extraction. </summary> */
		private void Extract(object sender, EventArgs e) {
			if (!this.timerExtract.Enabled) {
				this.loadingBar.Visible = false;
				this.labelComplete.Visible = false;
				if (File.Exists(Path.Combine(this.g1Directory, "g1.dat"))) {
					if (Directory.Exists(this.outputDirectory)) {
						this.reader = new BinaryReader(new FileStream(Path.Combine(this.g1Directory, "g1.dat"), FileMode.Open, FileAccess.Read), Encoding.Unicode);

						this.labelError.Visible = false;
						this.extractIndex = 0;
						this.loadingBar.Width = 0;
						this.loadingBar.Visible = true;

						this.extractStart = DateTime.Now;

						if (!Directory.Exists(Path.Combine(this.outputDirectory, "Palettes"))) {
							Directory.CreateDirectory(Path.Combine(this.outputDirectory, "Palettes"));
						}
						if (!Directory.Exists(Path.Combine(this.outputDirectory, "Fonts"))) {
							Directory.CreateDirectory(Path.Combine(this.outputDirectory, "Fonts"));
						}

						this.imageDirectory.Read(this.reader);
						this.startPosition = this.reader.BaseStream.Position;

						// Begin with creating sprite fonts

						// Font Indexes:
						// Regular: 3861-4084
						// Bold: 4085-4308
						// Small: 4309-4532
						// Large: 4533-4756
						// Japanese: 4758-4911

						ExtractSpriteFont(reader, "Regular", false, 3861, 4084, 256, 132, 12);
						ExtractSpriteFont(reader, "RegularOutline", true, 3861, 4084, 256, 132, 12);
						ExtractSpriteFont(reader, "Bold", false, 4085, 4308, 256, 132, 12);
						ExtractSpriteFont(reader, "BoldOutline", true, 4085, 4308, 256, 132, 12);
						ExtractSpriteFont(reader, "Small", false, 4309, 4532, 256, 90, 10);
						ExtractSpriteFont(reader, "SmallOutline", true, 4309, 4532, 256, 90, 10);
						ExtractSpriteFont(reader, "Large", false, 4533, 4756, 256, 202, 19);
						ExtractSpriteFont(reader, "Japanese", false, 4758, 4911, 256, 72, 13);
						ExtractSpriteFont(reader, "JapaneseShadow", true, 4758, 4911, 256, 72, 13);

						this.timerExtract.Start();
					}
					else {
						this.labelError.Visible = true;
						this.labelError.Text = "Error with output directory";
					}
				}
				else {
					this.labelError.Visible = true;
					this.labelError.Text = "Error with g1.dat directory";
				}
			}
		}

		#endregion
	}
}
