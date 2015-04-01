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
				Bitmap image = this.graphicsData.Read(reader, startPosition, this.extractIndex, this.imageDirectory);
				if (image != null) {
					if (this.imageDirectory.Entries[this.extractIndex].Flags == RCTDataEditor.DataObjects.ImageFlags.PaletteEntries) {
						image.Save(Path.Combine(this.outputDirectory, "Palettes", this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".png"), System.Drawing.Imaging.ImageFormat.Png);
						StreamWriter writer = new StreamWriter(Path.Combine(this.outputDirectory, "Palettes", this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".txt"));
						writer.Write(GraphicsData.LastPaletteText);
						writer.Close();
					}
					else {
						image.Save(Path.Combine(this.outputDirectory, this.extractIndex.ToString(this.hexFormat ? "X8" : "D") + ".png"), System.Drawing.Imaging.ImageFormat.Png);
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

		#endregion
		//============ EVENTS ============
		#region Events

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
				this.folderBrowserDialog.SelectedPath = this.outputDirectory;
				if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					this.outputDirectory = this.folderBrowserDialog.SelectedPath;
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

						this.imageDirectory.Read(this.reader);

						this.startPosition = this.reader.BaseStream.Position;

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
