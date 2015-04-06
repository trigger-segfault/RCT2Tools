using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCTDataEditor.DataObjects;

namespace RCT2PaletteConverter {
	public partial class ConverterForm : Form {

		Bitmap image;

		public ConverterForm() {
			InitializeComponent();
			image = (Bitmap)Bitmap.FromFile("");

			Palette palette = Palette.DefaultPalette;

			int[] delta = new int[256];

			for (int x = 0; x < image.Width; x++) {
				for (int y = 0; y < image.Height; y++) {
					Color imageColor = image.GetPixel(x, y);
					for (int i = 0; i < 256; i++) {
						delta[i] = GetColorDelta(imageColor, palette.Colors[i]);
					}
					int minDelta = delta[0];
					int minDeltaIndex = 0;
					for (int i = 1; i < 256; i++) {
						if (delta[i] < minDelta) {
							minDelta = delta[i];
							minDeltaIndex = i;
						}
					}
					image.SetPixel(x, y, palette.Colors[minDeltaIndex]);
				}
			}

			this.pictureBox1.Image = image;
		}

		private int GetColorDelta(Color imageColor, Color paletteColor) {
			return Math.Abs(imageColor.R - paletteColor.R) +
				Math.Abs(imageColor.G - paletteColor.G) +
				Math.Abs(imageColor.B - paletteColor.B) +
				Math.Abs(imageColor.A - paletteColor.A) * 4;
		}
	}
}
