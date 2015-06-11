using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCT2ObjectData.DataObjects;
using System.IO;
using RCT2ObjectData.DataObjects.Types;
using RCT2PaletteConverter.Properties;

namespace RCT2PaletteConverter {
	public partial class ConverterForm : Form {

		Bitmap image;
		PaletteImage p;
		Terrain terrain;
		ObjectData obj;
		DrawSettings drawSettings;
		string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6";
		string MazePath2 = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\TestMaze3.TD6";
		//string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\MicroMazeReddBaron.TD6";
		//string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6";

		public ConverterForm() {
			InitializeComponent();

			Bitmap bitmap = (Bitmap)Bitmap.FromFile("Letters.png");

			Color previousColor = Color.Black;
			int previousCount = 0;
			for (int i = 0; i < 33; i++) {
				Color color = (i != 32 ? bitmap.GetPixel(0, i * 12) : Color.Black);
				if (color.R == previousColor.R && color.G == previousColor.G && color.B == previousColor.B) {
					previousCount++;
				}
				else if (i != 0) {
					int index = 0;
					Palette palette = Palette.DefaultPalette;
					for (int j = 0; j < palette.NumColors; j++) {
						if (palette.Colors[j] == previousColor) {
							index = j;
							break;
						}
					}
					Console.WriteLine((previousCount != 0 ? ((i - previousCount - 1) + "-") : "") + (i - 1) + ":\t" + previousColor.R + ", " + previousColor.G + ", " + previousColor.B + " (" + index + ")");
					previousCount = 0;
				}
				previousColor = color;
			}

			Color[] colors = new Color[]{
				Color.FromArgb(131, 151, 151),
				Color.FromArgb(239, 243, 243),
				Color.FromArgb(239, 243, 243),
				Color.FromArgb(119, 119, 175),
				Color.FromArgb(239, 239, 255),
				Color.FromArgb(243, 235, 255),
				Color.FromArgb( 67, 135, 227),
				Color.FromArgb(215, 247, 255),
				Color.FromArgb(215, 247, 255),
				Color.FromArgb(207, 255, 255),
				Color.FromArgb(207, 255, 255),
				Color.FromArgb( 71, 175,  39),
				Color.FromArgb(207, 243, 223),
				Color.FromArgb(183, 219, 103),
				Color.FromArgb(195, 255, 179),
				Color.FromArgb(223, 247, 191),
				Color.FromArgb(223, 227, 163),
				Color.FromArgb(255, 255, 195),
				Color.FromArgb(255, 255, 195),
				Color.FromArgb(243, 203,  27),
				Color.FromArgb(255, 219, 163),
				Color.FromArgb(255, 111,  23),
				Color.FromArgb(247, 239, 195),
				Color.FromArgb(203, 175, 111),
				Color.FromArgb(231, 219, 195),
				Color.FromArgb(255, 227, 195),
				Color.FromArgb(255, 191, 191),
				Color.FromArgb(227,   7,   0),
				Color.FromArgb(255, 219, 215),
				Color.FromArgb(219,  59, 143),
				Color.FromArgb(255, 215, 239),
				Color.FromArgb(255, 219, 215)
			};

			for (int i = 0; i < 32; i++) {

				CustomControls.RCTLabel label2 = new CustomControls.RCTLabel();
				label2.FontType = CustomControls.Visuals.FontType.Bold;
				label2.ForeColor = colors[i];
				label2.Location = new System.Drawing.Point(164, 26 + i * 14);
				label2.Name = "rctColorLabel" + i;
				label2.OutlineColor = System.Drawing.Color.FromArgb(23, 35, 35);
				label2.Size = new System.Drawing.Size(140, 14);
				label2.TabIndex = 22;
				label2.Text = ((RemapColors)i).ToString();
				label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
				this.Controls.Add(label2);

				CustomControls.RCTLabel label = new CustomControls.RCTLabel();
				label.ForeColor = Color.FromArgb(23, 35, 35);
				label.Location = new System.Drawing.Point(140, 26 + i * 14);
				label.Name = "rctColorIndexLabel" + i;
				label.Size = new System.Drawing.Size(24, 14);
				label.TabIndex = 22;
				label.FontType = CustomControls.Visuals.FontType.Regular;
				label.Text = "(" + i + ")";
				label.TextAlign = System.Drawing.ContentAlignment.TopLeft;
				this.Controls.Add(label);
			}

			//WritePalette("palette_water.pal", PaletteWithWater);
			//WritePalette("palette_no_water.pal", PaletteNoWater);
			image = new Bitmap(300, 400);
			Graphics g = Graphics.FromImage(image);
			for (int i = 0; i < PaletteWithWater.Length; i++) {
				int size = 10;
				int x = (i % 12) * size;
				int y = (i / 12) * size;
				Brush brush = new SolidBrush(PaletteWithWater[i]);
				g.FillRectangle(brush, new Rectangle(x, y, size, size));
				brush.Dispose();
			}
			g.Dispose();
			this.pictureBox1.Image = image;
		}

		public void WritePalette(string file, Color[] colors) {
			uint fileLength = (uint)colors.Length * 4 + 4+4+4+4+4+2+2;
			uint dataSize = (uint)colors.Length * 4 + 4;
			ushort numColors = (ushort)colors.Length;

			BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write));

			writer.Write((byte)'R');
			writer.Write((byte)'I');
			writer.Write((byte)'F');
			writer.Write((byte)'F');

			writer.Write(fileLength);

			writer.Write((byte)'P');
			writer.Write((byte)'A');
			writer.Write((byte)'L');
			writer.Write((byte)' ');
			writer.Write((byte)'d');
			writer.Write((byte)'a');
			writer.Write((byte)'t');
			writer.Write((byte)'a');

			writer.Write(dataSize);

			writer.Write((byte)0x00);
			writer.Write((byte)0x03);

			writer.Write(numColors);

			for (int i = 0; i < colors.Length; i++) {
				writer.Write(colors[i].R);
				writer.Write(colors[i].G);
				writer.Write(colors[i].B);
				writer.Write(colors[i].A);
			}

			writer.Close();
		}


		public static Color[] PaletteWithWater = new Color[]{
		
			Color.FromArgb(23, 35, 35), Color.FromArgb(35, 51, 51), Color.FromArgb(47, 67, 67), Color.FromArgb(63, 83, 83),
			Color.FromArgb(75, 99, 99), Color.FromArgb(91, 115, 115), Color.FromArgb(111, 131, 131), Color.FromArgb(131, 151, 151),
			Color.FromArgb(159, 175, 175), Color.FromArgb(183, 195, 195), Color.FromArgb(211, 219, 219), Color.FromArgb(239, 243, 243),

			Color.FromArgb(51, 47, 0), Color.FromArgb(63, 59, 0), Color.FromArgb(79, 75, 11), Color.FromArgb(91, 91, 19),
			Color.FromArgb(107, 107, 31), Color.FromArgb(119, 123, 47), Color.FromArgb(135, 139, 59), Color.FromArgb(151, 155, 79),
			Color.FromArgb(167, 175, 95), Color.FromArgb(187, 191, 115), Color.FromArgb(203, 207, 139), Color.FromArgb(223, 227, 163),

			Color.FromArgb(67, 43, 7), Color.FromArgb(87, 59, 11), Color.FromArgb(111, 75, 23), Color.FromArgb(127, 87, 31),
			Color.FromArgb(143, 99, 39), Color.FromArgb(159, 115, 51), Color.FromArgb(179, 131, 67), Color.FromArgb(191, 151, 87),
			Color.FromArgb(203, 175, 111), Color.FromArgb(219, 199, 135), Color.FromArgb(231, 219, 163), Color.FromArgb(247, 239, 195),

			Color.FromArgb(71, 27, 0), Color.FromArgb(95, 43, 0), Color.FromArgb(119, 63, 0), Color.FromArgb(143, 83, 7),
			Color.FromArgb(167, 111, 7), Color.FromArgb(191, 139, 15), Color.FromArgb(215, 167, 19), Color.FromArgb(243, 203, 27),
			Color.FromArgb(255, 231, 47), Color.FromArgb(255, 243, 95), Color.FromArgb(255, 251, 143), Color.FromArgb(255, 255, 195),

			Color.FromArgb(35, 0, 0), Color.FromArgb(79, 0, 0), Color.FromArgb(95, 7, 7), Color.FromArgb(111, 15, 15),
			Color.FromArgb(127, 27, 27), Color.FromArgb(143, 39, 39), Color.FromArgb(163, 59, 59), Color.FromArgb(179, 79, 79),
			Color.FromArgb(199, 103, 103), Color.FromArgb(215, 127, 127), Color.FromArgb(235, 159, 159), Color.FromArgb(255, 191, 191),

			Color.FromArgb(27, 51, 19), Color.FromArgb(35, 63, 23), Color.FromArgb(47, 79, 31), Color.FromArgb(59, 95, 39),
			Color.FromArgb(71, 111, 43), Color.FromArgb(87, 127, 51), Color.FromArgb(99, 143, 59), Color.FromArgb(115, 155, 67),
			Color.FromArgb(131, 171, 75), Color.FromArgb(147, 187, 83), Color.FromArgb(163, 203, 95), Color.FromArgb(183, 219, 103),

			Color.FromArgb(31, 55, 27), Color.FromArgb(47, 71, 35), Color.FromArgb(59, 83, 43), Color.FromArgb(75, 99, 55),
			Color.FromArgb(91, 111, 67), Color.FromArgb(111, 135, 79), Color.FromArgb(135, 159, 95), Color.FromArgb(159, 183, 111),
			Color.FromArgb(183, 207, 127), Color.FromArgb(195, 219, 147), Color.FromArgb(207, 231, 167), Color.FromArgb(223, 247, 191),

			Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
			Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
			Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

			Color.FromArgb(79, 43, 19), Color.FromArgb(99, 55, 27), Color.FromArgb(119, 71, 43), Color.FromArgb(139, 87, 59),
			Color.FromArgb(167, 99, 67), Color.FromArgb(187, 115, 83), Color.FromArgb(207, 131, 99), Color.FromArgb(215, 151, 115),
			Color.FromArgb(227, 171, 131), Color.FromArgb(239, 191, 151), Color.FromArgb(247, 207, 171), Color.FromArgb(255, 227, 195),

			Color.FromArgb(15, 19, 55), Color.FromArgb(39, 43, 87), Color.FromArgb(51, 55, 103), Color.FromArgb(63, 67, 119),
			Color.FromArgb(83, 83, 139), Color.FromArgb(99, 99, 155), Color.FromArgb(119, 119, 175), Color.FromArgb(139, 139, 191),
			Color.FromArgb(159, 159, 207), Color.FromArgb(183, 183, 223), Color.FromArgb(211, 211, 239), Color.FromArgb(239, 239, 255),

			Color.FromArgb(0, 27, 111), Color.FromArgb(0, 39, 151), Color.FromArgb(7, 51, 167), Color.FromArgb(15, 67, 187),
			Color.FromArgb(27, 83, 203), Color.FromArgb(43, 103, 223), Color.FromArgb(67, 135, 227), Color.FromArgb(91, 163, 231),
			Color.FromArgb(119, 187, 239), Color.FromArgb(143, 211, 243), Color.FromArgb(175, 231, 251), Color.FromArgb(215, 247, 255),

			Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
			Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
			Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

			Color.FromArgb(63, 0, 95), Color.FromArgb(75, 7, 115), Color.FromArgb(83, 15, 127), Color.FromArgb(95, 31, 143),
			Color.FromArgb(107, 43, 155), Color.FromArgb(123, 63, 171), Color.FromArgb(135, 83, 187), Color.FromArgb(155, 103, 199),
			Color.FromArgb(171, 127, 215), Color.FromArgb(191, 155, 231), Color.FromArgb(215, 195, 243), Color.FromArgb(243, 235, 255),

			Color.FromArgb(63, 0, 0), Color.FromArgb(87, 0, 0), Color.FromArgb(115, 0, 0), Color.FromArgb(143, 0, 0),
			Color.FromArgb(171, 0, 0), Color.FromArgb(199, 0, 0), Color.FromArgb(227, 7, 0), Color.FromArgb(255, 7, 0),
			Color.FromArgb(255, 79, 67), Color.FromArgb(255, 123, 115), Color.FromArgb(255, 171, 163), Color.FromArgb(255, 219, 215),

			Color.FromArgb(79, 39, 0), Color.FromArgb(111, 51, 0), Color.FromArgb(147, 63, 0), Color.FromArgb(183, 71, 0),
			Color.FromArgb(219, 79, 0), Color.FromArgb(255, 83, 0), Color.FromArgb(255, 111, 23), Color.FromArgb(255, 139, 51),
			Color.FromArgb(255, 163, 79), Color.FromArgb(255, 183, 107), Color.FromArgb(255, 203, 135), Color.FromArgb(255, 219, 163),

			Color.FromArgb(0, 51, 47), Color.FromArgb(0, 63, 55), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 87, 79),
			Color.FromArgb(7, 107, 99), Color.FromArgb(23, 127, 119), Color.FromArgb(43, 147, 143), Color.FromArgb(71, 167, 163),
			Color.FromArgb(99, 187, 187), Color.FromArgb(131, 207, 207), Color.FromArgb(171, 231, 231), Color.FromArgb(207, 255, 255),

			Color.FromArgb(63, 0, 27), Color.FromArgb(103, 0, 51), Color.FromArgb(123, 11, 63), Color.FromArgb(143, 23, 79),
			Color.FromArgb(163, 31, 95), Color.FromArgb(183, 39, 111), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
			Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

			Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
			Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
			Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223)

		};

		public static Color[] PaletteNoWater = new Color[]{
		
			Color.FromArgb(23, 35, 35), Color.FromArgb(35, 51, 51), Color.FromArgb(47, 67, 67), Color.FromArgb(63, 83, 83),
			Color.FromArgb(75, 99, 99), Color.FromArgb(91, 115, 115), Color.FromArgb(111, 131, 131), Color.FromArgb(131, 151, 151),
			Color.FromArgb(159, 175, 175), Color.FromArgb(183, 195, 195), Color.FromArgb(211, 219, 219), Color.FromArgb(239, 243, 243),

			Color.FromArgb(51, 47, 0), Color.FromArgb(63, 59, 0), Color.FromArgb(79, 75, 11), Color.FromArgb(91, 91, 19),
			Color.FromArgb(107, 107, 31), Color.FromArgb(119, 123, 47), Color.FromArgb(135, 139, 59), Color.FromArgb(151, 155, 79),
			Color.FromArgb(167, 175, 95), Color.FromArgb(187, 191, 115), Color.FromArgb(203, 207, 139), Color.FromArgb(223, 227, 163),

			Color.FromArgb(67, 43, 7), Color.FromArgb(87, 59, 11), Color.FromArgb(111, 75, 23), Color.FromArgb(127, 87, 31),
			Color.FromArgb(143, 99, 39), Color.FromArgb(159, 115, 51), Color.FromArgb(179, 131, 67), Color.FromArgb(191, 151, 87),
			Color.FromArgb(203, 175, 111), Color.FromArgb(219, 199, 135), Color.FromArgb(231, 219, 163), Color.FromArgb(247, 239, 195),

			Color.FromArgb(71, 27, 0), Color.FromArgb(95, 43, 0), Color.FromArgb(119, 63, 0), Color.FromArgb(143, 83, 7),
			Color.FromArgb(167, 111, 7), Color.FromArgb(191, 139, 15), Color.FromArgb(215, 167, 19), Color.FromArgb(243, 203, 27),
			Color.FromArgb(255, 231, 47), Color.FromArgb(255, 243, 95), Color.FromArgb(255, 251, 143), Color.FromArgb(255, 255, 195),

			Color.FromArgb(35, 0, 0), Color.FromArgb(79, 0, 0), Color.FromArgb(95, 7, 7), Color.FromArgb(111, 15, 15),
			Color.FromArgb(127, 27, 27), Color.FromArgb(143, 39, 39), Color.FromArgb(163, 59, 59), Color.FromArgb(179, 79, 79),
			Color.FromArgb(199, 103, 103), Color.FromArgb(215, 127, 127), Color.FromArgb(235, 159, 159), Color.FromArgb(255, 191, 191),

			Color.FromArgb(27, 51, 19), Color.FromArgb(35, 63, 23), Color.FromArgb(47, 79, 31), Color.FromArgb(59, 95, 39),
			Color.FromArgb(71, 111, 43), Color.FromArgb(87, 127, 51), Color.FromArgb(99, 143, 59), Color.FromArgb(115, 155, 67),
			Color.FromArgb(131, 171, 75), Color.FromArgb(147, 187, 83), Color.FromArgb(163, 203, 95), Color.FromArgb(183, 219, 103),

			Color.FromArgb(31, 55, 27), Color.FromArgb(47, 71, 35), Color.FromArgb(59, 83, 43), Color.FromArgb(75, 99, 55),
			Color.FromArgb(91, 111, 67), Color.FromArgb(111, 135, 79), Color.FromArgb(135, 159, 95), Color.FromArgb(159, 183, 111),
			Color.FromArgb(183, 207, 127), Color.FromArgb(195, 219, 147), Color.FromArgb(207, 231, 167), Color.FromArgb(223, 247, 191),

			Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
			Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
			Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

			Color.FromArgb(79, 43, 19), Color.FromArgb(99, 55, 27), Color.FromArgb(119, 71, 43), Color.FromArgb(139, 87, 59),
			Color.FromArgb(167, 99, 67), Color.FromArgb(187, 115, 83), Color.FromArgb(207, 131, 99), Color.FromArgb(215, 151, 115),
			Color.FromArgb(227, 171, 131), Color.FromArgb(239, 191, 151), Color.FromArgb(247, 207, 171), Color.FromArgb(255, 227, 195),

			Color.FromArgb(15, 19, 55), Color.FromArgb(39, 43, 87), Color.FromArgb(51, 55, 103), Color.FromArgb(63, 67, 119),
			Color.FromArgb(83, 83, 139), Color.FromArgb(99, 99, 155), Color.FromArgb(119, 119, 175), Color.FromArgb(139, 139, 191),
			Color.FromArgb(159, 159, 207), Color.FromArgb(183, 183, 223), Color.FromArgb(211, 211, 239), Color.FromArgb(239, 239, 255),

			Color.FromArgb(0, 27, 111), Color.FromArgb(0, 39, 151), Color.FromArgb(7, 51, 167), Color.FromArgb(15, 67, 187),
			Color.FromArgb(27, 83, 203), Color.FromArgb(43, 103, 223), Color.FromArgb(67, 135, 227), Color.FromArgb(91, 163, 231),
			Color.FromArgb(119, 187, 239), Color.FromArgb(143, 211, 243), Color.FromArgb(175, 231, 251), Color.FromArgb(215, 247, 255),

			Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
			Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
			Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

			Color.FromArgb(63, 0, 95), Color.FromArgb(75, 7, 115), Color.FromArgb(83, 15, 127), Color.FromArgb(95, 31, 143),
			Color.FromArgb(107, 43, 155), Color.FromArgb(123, 63, 171), Color.FromArgb(135, 83, 187), Color.FromArgb(155, 103, 199),
			Color.FromArgb(171, 127, 215), Color.FromArgb(191, 155, 231), Color.FromArgb(215, 195, 243), Color.FromArgb(243, 235, 255),

			Color.FromArgb(63, 0, 0), Color.FromArgb(87, 0, 0), Color.FromArgb(115, 0, 0), Color.FromArgb(143, 0, 0),
			Color.FromArgb(171, 0, 0), Color.FromArgb(199, 0, 0), Color.FromArgb(227, 7, 0), Color.FromArgb(255, 7, 0),
			Color.FromArgb(255, 79, 67), Color.FromArgb(255, 123, 115), Color.FromArgb(255, 171, 163), Color.FromArgb(255, 219, 215),

			Color.FromArgb(79, 39, 0), Color.FromArgb(111, 51, 0), Color.FromArgb(147, 63, 0), Color.FromArgb(183, 71, 0),
			Color.FromArgb(219, 79, 0), Color.FromArgb(255, 83, 0), Color.FromArgb(255, 111, 23), Color.FromArgb(255, 139, 51),
			Color.FromArgb(255, 163, 79), Color.FromArgb(255, 183, 107), Color.FromArgb(255, 203, 135), Color.FromArgb(255, 219, 163),

			Color.FromArgb(63, 0, 27), Color.FromArgb(103, 0, 51), Color.FromArgb(123, 11, 63), Color.FromArgb(143, 23, 79),
			Color.FromArgb(163, 31, 95), Color.FromArgb(183, 39, 111), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
			Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

			Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
			Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
			Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223)
		};

		private int GetColorDelta(Color imageColor, Color paletteColor) {
			return Math.Abs(imageColor.R - paletteColor.R) +
				Math.Abs(imageColor.G - paletteColor.G) +
				Math.Abs(imageColor.B - paletteColor.B) +
				Math.Abs(imageColor.A - paletteColor.A) * 4;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			/*drawSettings.Frame = (drawSettings.Frame + 1) % 15;

			//terrain.Draw(p, new Point(200, 200), 0);
			obj.Draw(p, new Point(200, 216), drawSettings);

			Graphics g = Graphics.FromImage(image);
			p.Draw(g, 0, 0, obj.GetPalette(drawSettings));

			g.Dispose();
			this.pictureBox1.Image = image;*/
		}
	}
}
