using RCT2ObjectData.DataObjects;
using RCT2ObjectData.DataObjects.Types;
using RCT2WaterCreator.Properties;
using RCTDataEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2WaterCreator {
	public partial class WaterForm : Form {

		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The animation image being drawn to. </summary> */
		Bitmap animationImage;

		/** <summary> The current animation frame. </summary> */
		int animationFrame = 0;
		/** <summary> The weather to display. </summary> */
		int weather = 0;
		/** <summary> The type of water image to display. </summary> */
		int waterType = 0;

		/** <summary> The currently selected palette. </summary> */
		int selectedPalette = 0;
		/** <summary> The selected color in the currently selected palette. </summary> */
		int selectedColor = 0;
		/** <summary> The current color. </summary> */
		Color currentColor = Color.White;

		/** <summary> The water object being edited. </summary> */
		Water waterObject;
		/** <summary> The file name for the water object. </summary> */
		string fileName = "";
		/** <summary> True if the water object was changed. </summary> */
		bool changed = false;

		#endregion
		//--------------------------------
		#region Settings

		/** <summary> The first palette image. </summary> */
		Bitmap palette0Image;
		/** <summary> The second palette image. </summary> */
		Bitmap palette1Image;
		/** <summary> The third palette image. </summary> */
		Bitmap palette2Image;
		/** <summary> The fourth palette image. </summary> */
		Bitmap palette3Image;
		/** <summary> The fifth palette image. </summary> */
		Bitmap palette4Image;
		/** <summary> The sixth palette image. </summary> */
		Bitmap palette5Image;
		/** <summary> The seventh palette image. </summary> */
		Bitmap palette6Image;
		/** <summary> The first palette. </summary> */
		Color[] palette0 = new Color[12];
		/** <summary> The second palette. </summary> */
		Color[] palette1 = new Color[15];
		/** <summary> The third palette. </summary> */
		Color[] palette2 = new Color[15];
		/** <summary> The fourth palette. </summary> */
		Color[] palette3 = new Color[15];
		/** <summary> The fifth palette. </summary> */
		Color[] palette4 = new Color[15];
		/** <summary> The sixth palette. </summary> */
		Color[] palette5 = new Color[15];
		/** <summary> The seventh palette. </summary> */
		Color[] palette6 = new Color[15];
		
		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public WaterForm() {
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			InitializeComponent();

			waterObject = (Water)ObjectData.FromBuffer(Resources.WTRCYAN);
			waterObject.Source = SourceTypes.Custom;
			LoadFromObject();
			UpdatePalettes();

			this.animationImage = new Bitmap(180, 208);

			SelectColor();

			changed = false;
		}

		#endregion
		//=========== BUTTONS ============
		#region Buttons

		/** <summary> Changes the water type to pure water. </summary> */
		private void ChangeTypePureWater(object sender, EventArgs e) {
			this.waterType = 0;
		}
		/** <summary> Changes the water type to water ride. </summary> */
		private void ChangeTypeWaterRide(object sender, EventArgs e) {
			this.waterType = 1;
		}
		/** <summary> Changes the weather to sun. </summary> */
		private void ChangeWeatherSun(object sender, EventArgs e) {
			this.weather = 0;
		}
		/** <summary> Changes the weather to sun. </summary> */
		private void ChangeWeatherCloud(object sender, EventArgs e) {
			this.weather = 1;
		}
		/** <summary> Changes the weather to sun. </summary> */
		private void ChangeWeatherRain(object sender, EventArgs e) {
			this.weather = 2;
		}
		/** <summary> Changes the language names. </summary> */
		private void ChangeNames(object sender, EventArgs e) {
			using (NamesForm form = new NamesForm()) {
				form.Names = waterObject.StringTable.Entries[0].Languages;
				form.ShowDialog(this);
				waterObject.StringTable.Entries[0].Languages = form.Names;
				changed = true;
			}
		}

		#endregion
		//============ COLORS ============
		#region Colors

		/** <summary> Opens the color dialog. </summary> */
		private void PickColorDoubleClick(object sender, MouseEventArgs e) {
			colorDialog.Color = currentColor;
			colorDialog.FullOpen = true;
			if (colorDialog.ShowDialog(this) == DialogResult.OK) {
				currentColor = colorDialog.Color;
				this.numericUpDownRed.Value = currentColor.R;
				this.numericUpDownGreen.Value = currentColor.G;
				this.numericUpDownBlue.Value = currentColor.B;
				this.pictureBoxCurrentColor.BackColor = currentColor;
				this.colorSelector.BackColor = currentColor;
				changed = true;
			}
		}
		/** <summary> Opens the color dialog. </summary> */
		private void PickColor(object sender, EventArgs e) {
			colorDialog.Color = currentColor;
			colorDialog.FullOpen = true;
			if (colorDialog.ShowDialog(this) == DialogResult.OK) {
				currentColor = colorDialog.Color;
				this.numericUpDownRed.Value = currentColor.R;
				this.numericUpDownGreen.Value = currentColor.G;
				this.numericUpDownBlue.Value = currentColor.B;
				this.pictureBoxCurrentColor.BackColor = currentColor;
				this.colorSelector.BackColor = currentColor;
				changed = true;
			}
		}
		/** <summary> Changes the red value of the color. </summary> */
		private void RedValueChanged(object sender, EventArgs e) {
			currentColor = Color.FromArgb((int)(sender as NumericUpDown).Value, currentColor.G, currentColor.B);
			SetColor();
			UpdatePalettes();
			this.pictureBoxCurrentColor.BackColor = currentColor;
			this.colorSelector.BackColor = currentColor;
			changed = true;
		}
		/** <summary> Changes the green value of the color. </summary> */
		private void GreenValueChanged(object sender, EventArgs e) {
			currentColor = Color.FromArgb(currentColor.R, (int)(sender as NumericUpDown).Value, currentColor.B);
			SetColor();
			UpdatePalettes();
			this.pictureBoxCurrentColor.BackColor = currentColor;
			this.colorSelector.BackColor = currentColor;
			changed = true;
		}
		/** <summary> Changes the blue value of the color. </summary> */
		private void BlueValueChanged(object sender, EventArgs e) {
			currentColor = Color.FromArgb(currentColor.R, currentColor.G, (int)(sender as NumericUpDown).Value);
			SetColor();
			UpdatePalettes();
			this.pictureBoxCurrentColor.BackColor = currentColor;
			this.colorSelector.BackColor = currentColor;
			changed = true;
		}
		/** <summary> Changes the currently selected color. </summary> */
		private void ChangeCurrentColor(object sender, MouseEventArgs e) {
			(sender as Control).Focus();
			currentColor = Color.FromArgb((int)this.numericUpDownRed.Value, (int)this.numericUpDownGreen.Value, (int)this.numericUpDownBlue.Value);
			SetColor();
			bool changedBefore = changed;
			UpdatePalettes();
			this.pictureBoxCurrentColor.BackColor = currentColor;
			this.colorSelector.BackColor = currentColor;

			this.selectedPalette = Int32.Parse(((Control)sender).Name.Replace("paletteBox", ""));
			Point locationOnForm = (sender as Control).FindForm().PointToClient((sender as Control).Parent.PointToScreen((sender as Control).Location));
			if (selectedPalette == 0) {
				this.selectedColor = e.X / 20;
				this.colorSelector.Location = new Point(
					locationOnForm.X + this.selectedColor * 20 - 2,
					locationOnForm.Y - 2
				);
				this.colorSelector.Image = Resources.ColorSelectorLarge;
				this.colorSelector.Size = new Size(24, 24);
			}
			else {
				this.selectedColor = e.X / 14;
				this.colorSelector.Location = new Point(
					locationOnForm.X + this.selectedColor * 14 - 2,
					locationOnForm.Y - 2
				);
				this.colorSelector.Image = Resources.ColorSelector;
				this.colorSelector.Size = new Size(18, 18);
			}
			SelectColor();
			changed = changedBefore;
		}

		/** <summary> Activates the currently selected color from the palettes. </summary> */
		private void SelectColor() {
			switch (selectedPalette) {
			case 0: currentColor = palette0[selectedColor]; break;
			case 1: currentColor = palette1[selectedColor]; break;
			case 2: currentColor = palette2[selectedColor]; break;
			case 3: currentColor = palette3[selectedColor]; break;
			case 4: currentColor = palette4[selectedColor]; break;
			case 5: currentColor = palette5[selectedColor]; break;
			case 6: currentColor = palette6[selectedColor]; break;
			}
			this.numericUpDownRed.Value = currentColor.R;
			this.numericUpDownGreen.Value = currentColor.G;
			this.numericUpDownBlue.Value = currentColor.B;
			this.pictureBoxCurrentColor.BackColor = currentColor;
			this.colorSelector.BackColor = currentColor;
		}
		/** <summary> Sets the currently selected color to the palettes. </summary> */
		private void SetColor() {
			switch (selectedPalette) {
			case 0: palette0[selectedColor] = currentColor; break;
			case 1: palette1[selectedColor] = currentColor; break;
			case 2: palette2[selectedColor] = currentColor; break;
			case 3: palette3[selectedColor] = currentColor; break;
			case 4: palette4[selectedColor] = currentColor; break;
			case 5: palette5[selectedColor] = currentColor; break;
			case 6: palette6[selectedColor] = currentColor; break;
			}
		}
		/** <summary> Updates the color palettes. </summary> */
		private void UpdatePalettes() {
			palette1Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			Graphics g = Graphics.FromImage(palette1Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette1[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox1.Image = palette1Image;

			palette2Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			g = Graphics.FromImage(palette2Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette2[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox2.Image = palette2Image;

			palette3Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			g = Graphics.FromImage(palette3Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette3[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox3.Image = palette3Image;

			palette4Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			g = Graphics.FromImage(palette4Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette4[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox4.Image = palette4Image;

			palette5Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			g = Graphics.FromImage(palette5Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette5[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox5.Image = palette5Image;

			palette6Image = new Bitmap(this.paletteBox1.Width, this.paletteBox1.Height);
			g = Graphics.FromImage(palette6Image);
			for (int i = 0; i < this.palette1.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette6[i]), new Rectangle(new Point(this.paletteBox1.Width / this.palette1.Length * i, 0), new Size(this.paletteBox1.Width / this.palette1.Length, this.paletteBox1.Height)));
			g.Dispose();
			this.paletteBox6.Image = palette6Image;

			palette0Image = new Bitmap(this.paletteBox0.Width, this.paletteBox0.Height);
			g = Graphics.FromImage(palette0Image);
			for (int i = 0; i < this.palette0.Length; i++)
				g.FillRectangle(new SolidBrush(this.palette0[i]), new Rectangle(new Point(this.paletteBox0.Width / this.palette0.Length * i, 0), new Size(this.paletteBox0.Width / this.palette0.Length, this.paletteBox0.Height)));
			g.Dispose();
			this.paletteBox0.Image = palette0Image;
		}

		#endregion
		//=========== DRAWING ============
		#region Drawing

		/** <summary> Creates a color map. </summary> */
		private ColorMap GetColorMap(int oldR, int oldG, int oldB, Color newColor) {
			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = Color.FromArgb(oldR, oldG, oldB);
			colorMap.NewColor = newColor;
			return colorMap;
		}
		/** <summary> Animates the water image. </summary> */
		private void AnimateImage(object sender, EventArgs e) {
			animationFrame = (animationFrame - 1 + 15) % 15;

			Graphics g = Graphics.FromImage(this.animationImage);

			ColorMap[] colorMaps = new ColorMap[]{
				// General
				GetColorMap(0, 51, 47, palette0[0]), GetColorMap(0, 63, 55, palette0[1]), GetColorMap(0, 75, 67, palette0[2]), GetColorMap(0, 87, 79, palette0[3]),
				GetColorMap(7, 107, 99, palette0[4]), GetColorMap(23, 127, 119, palette0[5]), GetColorMap(43, 147, 143, palette0[6]), GetColorMap(71, 167, 163, palette0[7]),
				GetColorMap(99, 187, 187, palette0[8]), GetColorMap(131, 207, 207, palette0[9]), GetColorMap(171, 231, 231, palette0[10]), GetColorMap(207, 255, 255, palette0[11]),

				// Waves
				GetColorMap(50, 0, 0, palette1[animationFrame]), GetColorMap(100, 0, 0, palette1[(animationFrame + 3) % 15]), GetColorMap(150, 0, 0, palette1[(animationFrame + 6) % 15]),
				GetColorMap(200, 0, 0, palette1[(animationFrame + 9) % 15]), GetColorMap(250, 0, 0, palette1[(animationFrame + 12) % 15]),
				
				GetColorMap(50, 50, 0, palette2[animationFrame]), GetColorMap(100, 100, 0, palette2[(animationFrame + 3) % 15]), GetColorMap(150, 150, 0, palette2[(animationFrame + 6) % 15]),
				GetColorMap(200, 200, 0, palette2[(animationFrame + 9) % 15]), GetColorMap(250, 250, 0, palette2[(animationFrame + 12) % 15]),
				
				GetColorMap(50, 0, 50, palette3[animationFrame]), GetColorMap(100, 0, 100, palette3[(animationFrame + 3) % 15]), GetColorMap(150, 0, 150, palette3[(animationFrame + 6) % 15]),
				GetColorMap(200, 0, 200, palette3[(animationFrame + 9) % 15]), GetColorMap(250, 0, 250, palette3[(animationFrame + 12) % 15]),

				// Sparkles
				GetColorMap(0, 50, 0, palette4[animationFrame]), GetColorMap(0, 100, 0, palette4[(animationFrame + 3) % 15]), GetColorMap(0, 150, 0, palette4[(animationFrame + 6) % 15]),
				GetColorMap(0, 200, 0, palette4[(animationFrame + 9) % 15]), GetColorMap(0, 250, 0, palette4[(animationFrame + 12) % 15]),
				
				GetColorMap(0, 50, 50, palette5[animationFrame]), GetColorMap(0, 100, 100, palette5[(animationFrame + 3) % 15]), GetColorMap(0, 150, 150, palette5[(animationFrame + 6) % 15]),
				GetColorMap(0, 200, 200, palette5[(animationFrame + 9) % 15]), GetColorMap(0, 250, 250, palette5[(animationFrame + 12) % 15]),
				
				GetColorMap(0, 0, 50, palette6[animationFrame]), GetColorMap(0, 0, 100, palette6[(animationFrame + 3) % 15]), GetColorMap(0, 0, 150, palette6[(animationFrame + 6) % 15]),
				GetColorMap(0, 0, 200, palette6[(animationFrame + 9) % 15]), GetColorMap(0, 0, 250, palette6[(animationFrame + 12) % 15])
			};

			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(colorMaps);

			Bitmap drawImage = null;

			switch (waterType * 3 + weather) {
			case 0: drawImage = Resources.PureWaterSun; break;
			case 1: drawImage = Resources.PureWaterCloud; break;
			case 2: drawImage = Resources.PureWaterRain; break;
			case 3: drawImage = Resources.WaterRideSun; break;
			case 4: drawImage = Resources.WaterRideCloud; break;
			case 5: drawImage = Resources.WaterRideRain; break;
			}
			g.DrawImage(drawImage, new Rectangle(0, 0, 180, 208), 0, 0, 180, 208, GraphicsUnit.Pixel, imageAttributes);

			g.Dispose();
			this.pictureBoxPreview.Image = animationImage;
		}

		#endregion
		//=========== READING ============
		#region Reading

		/** <summary> Saves the palettes to the water object. </summary> */
		private void SaveToObject() {
			for (int i = 0; i < this.palette0.Length; i++)
				waterObject.GraphicsData.GetPalette(0).Colors[180 + i] = this.palette0[i];

			for (int i = 0; i < this.palette1.Length; i++)
				waterObject.GraphicsData.GetPalette(1).Colors[i] = this.palette1[i];
			for (int i = 0; i < this.palette2.Length; i++)
				waterObject.GraphicsData.GetPalette(2).Colors[i] = this.palette2[i];
			for (int i = 0; i < this.palette3.Length; i++)
				waterObject.GraphicsData.GetPalette(3).Colors[i] = this.palette3[i];
			for (int i = 0; i < this.palette4.Length; i++)
				waterObject.GraphicsData.GetPalette(4).Colors[i] = this.palette4[i];
			for (int i = 0; i < this.palette5.Length; i++)
				waterObject.GraphicsData.GetPalette(5).Colors[i] = this.palette5[i];
			for (int i = 0; i < this.palette6.Length; i++)
				waterObject.GraphicsData.GetPalette(6).Colors[i] = this.palette6[i];

		}
		/** <summary> Loads the palettes from the water object. </summary> */
		private void LoadFromObject() {
			for (int i = 0; i < this.palette0.Length; i++)
				this.palette0[i] = waterObject.GraphicsData.GetPalette(0).Colors[180 + i];

			for (int i = 0; i < this.palette1.Length; i++)
				this.palette1[i] = waterObject.GraphicsData.GetPalette(1).Colors[i];
			for (int i = 0; i < this.palette2.Length; i++)
				this.palette2[i] = waterObject.GraphicsData.GetPalette(2).Colors[i];
			for (int i = 0; i < this.palette3.Length; i++)
				this.palette3[i] = waterObject.GraphicsData.GetPalette(3).Colors[i];
			for (int i = 0; i < this.palette4.Length; i++)
				this.palette4[i] = waterObject.GraphicsData.GetPalette(4).Colors[i];
			for (int i = 0; i < this.palette5.Length; i++)
				this.palette5[i] = waterObject.GraphicsData.GetPalette(5).Colors[i];
			for (int i = 0; i < this.palette6.Length; i++)
				this.palette6[i] = waterObject.GraphicsData.GetPalette(6).Colors[i];

		}
		/** <summary> Opens the about form. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
		/** <summary> Creates a new water object. </summary> */
		private void New(object sender, EventArgs e) {
			if (!changed || WarningMessageBox.Show(this, "Water object has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				waterObject = (Water)ObjectData.FromBuffer(Resources.WTRCYAN);
				waterObject.Source = SourceTypes.Custom;
				LoadFromObject();
				UpdatePalettes();
				SelectColor();
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
			if (!changed || WarningMessageBox.Show(this, "Water object has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
					fileName = openFileDialog.FileName;
					ObjectData obj = ObjectData.FromFile(fileName);
					bool invalid = false;
					if (obj is Water) {
						waterObject = (Water)obj;
						if (waterObject.GraphicsData.NumPalettes == 7 && waterObject.GraphicsData.NumImages == 0 &&
							waterObject.GraphicsData.GetPalette(0).Colors.Length == 236 &&
							waterObject.GraphicsData.GetPalette(1).Colors.Length == 15 &&
							waterObject.GraphicsData.GetPalette(2).Colors.Length == 15 &&
							waterObject.GraphicsData.GetPalette(3).Colors.Length == 15 &&
							waterObject.GraphicsData.GetPalette(4).Colors.Length == 15 &&
							waterObject.GraphicsData.GetPalette(5).Colors.Length == 15 &&
							waterObject.GraphicsData.GetPalette(6).Colors.Length == 15) {
							LoadFromObject();
							SelectColor();
							changed = false;
						}
						else {
							invalid = true;
						}
					}
					else {
						invalid = true;
					}
					if (invalid) {
						ErrorMessageBox.Show(this, "Failed to load water object.", "Object may be invalid.");
					}
				}
			}
		}
		/** <summary> Saves the water object. </summary> */
		private void Save(object sender, EventArgs e) {
			if (fileName == "" || waterObject.Source != SourceTypes.Custom) {
				SaveAs(null, null);
			}
			else {
				SaveToObject();
				waterObject.Save(fileName);
			}
		}
		/** <summary> Saves as the water object. </summary> */
		private void SaveAs(object sender, EventArgs e) {
			if (fileName == "") {
				saveFileDialog.InitialDirectory = "";
				saveFileDialog.FileName = "UNTITLED";
			}
			else if (waterObject.Source != SourceTypes.Custom) {
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				saveFileDialog.FileName = "UNTITLED";
			}
			else {
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				saveFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
			}
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
				fileName = saveFileDialog.FileName;
				waterObject.ObjectHeader.FileName = Path.GetFileNameWithoutExtension(fileName).Substring(0, Math.Min(Path.GetFileNameWithoutExtension(fileName).Length, 8));
				SaveToObject();
				waterObject.Source = SourceTypes.Custom;
				waterObject.Save(fileName);
			}
		}

		#endregion

		/** <summary> Removes focus from the numeric up downs. </summary> */
		private void RemoveTextFocus(object sender, MouseEventArgs e) {
			this.paletteBox0.Focus();
		}

		/** <summary> Checks if Ctrl+C or Ctrl+V has been pressed. </summary> */
		private void CaptureHotkeys(object sender, PreviewKeyDownEventArgs e) {
			if (!this.numericUpDownRed.Focused && !this.numericUpDownGreen.Focused && !this.numericUpDownBlue.Focused) {
				if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) {
					Clipboard.SetData("CF_COLOR", currentColor);
				}
				else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) {
					object data = Clipboard.GetData("CF_COLOR");
					if (data != null) {
						currentColor = (Color)data;
						SetColor();
						UpdatePalettes();
						this.numericUpDownRed.Value = currentColor.R;
						this.numericUpDownGreen.Value = currentColor.G;
						this.numericUpDownBlue.Value = currentColor.B;
						this.pictureBoxCurrentColor.BackColor = currentColor;
						this.colorSelector.BackColor = currentColor;
					}
				}
			}
		}
	}
}
