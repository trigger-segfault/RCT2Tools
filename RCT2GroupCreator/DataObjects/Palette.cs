using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects {
/** <summary> An enumeration for the RCT2 colors. </summary> */
public enum RemapColors : byte {
	Black = 0,
	Gray = 1,
	White = 2,
	Indigo = 3,
	SlateBlue = 4,
	Purple = 5,
	Blue = 6,
	LightBlue = 7,

	LightWater = 8,
	Water = 9,
	Cyan = 10,
	Green = 11,
	SeaGreen = 12,
	DarkOliveGreen = 13,
	Lime = 14,
	OliveDrab = 15,

	Olive = 16,
	Yellow = 17,
	Gold = 18,
	Goldenrod = 19,
	Orange = 20,
	DarkOrange = 21,
	LightBrown = 22,
	Brown = 23,

	Bark = 24,
	Tan = 25,
	Maroon = 26,
	DarkRed = 27,
	Red = 28,
	Magenta = 29,
	Pink = 30,
	Salmon = 31
}
/** <summary> The data used for color remapping. </summary> */
public class ColorRemapping {

	/** <summary> The indexes of the colors when remapping. </summary> */
	public static byte[,] ColorIndexes = {
		{0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{3, 4, 5, 6, 7, 8, 9, 10, 11, 11, 11, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{3, 4, 5, 6, 7, 8, 9, 10, 10, 11, 11, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{1, 3, 5, 6, 7, 8, 9, 10, 10, 11, 11, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 11, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 5, 6, 7, 7},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8},
		{0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{0, 0, 0, 1, 1, 2, 3, 4, 4, 5, 6, 6},
		{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{5, 6, 7, 8, 9, 10, 10, 10, 11, 11, 11, 11}
	};
	/** <summary> The rows of the colors when remapping. </summary> */
	public static byte[,] ColorRows = {
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
		{9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
		{12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12},
		{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
		{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
		{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
		{15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
		{15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
		{7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7},
		{11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11},
		{5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		{7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7},
		{6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6},
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
		{3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
		{3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
		{14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14},
		{14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14},
		{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
		{2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
		{17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17},
		{8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
		{4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
		{13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13},
		{13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13},
		{16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
		{16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
		{4, 4, 4, 4, 4, 4, 4, 13, 4, 13, 13, 13}
	};
}
/** <summary> An image structured based on palette indexes. </summary> */
public class PaletteImage {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The 8 character file name of the object. </summary> */
	public byte[,] Pixels;

	public int Width;
	public int Height;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default palette image. </summary> */
	public PaletteImage() {
		this.Width = 1;
		this.Height = 1;
		this.Pixels = new byte[this.Width, this.Height];
	}
	/** <summary> Constructs ta palette image with the specified dimensions. </summary> */
	public PaletteImage(int width, int height) {
		this.Width = width;
		this.Height = height;
		this.Pixels = new byte[this.Width, this.Height];
	}

	#endregion
	//============ COLORS ============
	#region Colors

	public Color GetColorRemapped(int x, int y, Palette palette, int remap1, int remap2, int remap3) {
		byte pixel = Pixels[x, y];
		if (remap1 != -1 && pixel >= 243 && pixel < 255) {
			pixel = (byte)(10 + 12 *
				ColorRemapping.ColorRows[remap1, (int)pixel - 243] +
				ColorRemapping.ColorIndexes[remap1, (int)pixel - 243]);
		}
		else if (remap2 != -1 && pixel >= 10 + 12 * 16 && pixel < 10 + 12 * 17) {
			pixel = (byte)(10 + 12 *
				ColorRemapping.ColorRows[remap2, (int)pixel - 10 - 12 * 16] +
				ColorRemapping.ColorIndexes[remap2, (int)pixel - 10 - 12 * 16]);
		}
		else if (remap3 != -1 && pixel >= 10 + 12 * 3 && pixel < 10 + 12 * 4) {
			pixel = (byte)(10 + 12 *
				ColorRemapping.ColorRows[remap3, (int)pixel - 10 - 12 * 3] +
				ColorRemapping.ColorIndexes[remap3, (int)pixel - 10 - 12 * 3]);
		}
		return palette.Colors[pixel];
	}

	public void Draw(Graphics g, int x, int y, Palette palette, int remap1, int remap2, int remap3) {
		if (GraphicsData.DisableRemap) {
			remap1 = -1;
			remap2 = -1;
			remap3 = -1;
		}
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(x1, y1, palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(x + x1, y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	public void Draw(Bitmap b, Palette palette, int remap1, int remap2, int remap3) {
		if (GraphicsData.DisableRemap) {
			remap1 = -1;
			remap2 = -1;
			remap3 = -1;
		}
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				b.SetPixel(x1, y1, GetColorRemapped(x1, y1, palette, remap1, remap2, remap3));
			}
		}
	}
	public Bitmap CreateImage(Palette palette, int remap1, int remap2, int remap3) {
		Bitmap b = new Bitmap(Width, Height);
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				b.SetPixel(x1, y1, GetColorRemapped(x1, y1, palette, remap1, remap2, remap3));
			}
		}
		return b;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Loads the palette image from the specified data. </summary> */
	public static PaletteImage Load(byte[] buffer) {
		BinaryReader reader = new BinaryReader(new MemoryStream(buffer));
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData();
		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
		return graphicsData.PaletteImages[0];
	}

	#endregion
}

/** <summary> A palette used for storing colors. </summary> */
public class Palette {

	/** <summary> The default color palette for the game </summary> */
	public static Palette DefaultPalette2 = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

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

		Color.FromArgb(63, 0, 27), Color.FromArgb(91, 0, 39), Color.FromArgb(119, 0, 59), Color.FromArgb(147, 7, 75),
		Color.FromArgb(179, 11, 99), Color.FromArgb(199, 31, 119), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
		Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

		Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
		Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black,
		//Color.FromArgb(255, 0, 128), Color.FromArgb(0, 128, 255), Color.FromArgb(255, 128, 0), Color.FromArgb(128, 0, 255), Color.FromArgb(128, 255, 0), Color.FromArgb(128, 0, 128), Color.FromArgb(0, 0, 128), Color.FromArgb(0, 128, 128), Color.FromArgb(0, 128, 0), Color.FromArgb(128, 128, 0),
		//Color.FromArgb(128, 0, 0), Color.FromArgb(255, 0, 255), Color.FromArgb(0, 0, 255), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 255, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(255, 0, 0),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),
		Color.Black
		//Color.FromArgb(0, 255, 128)
	});
	/** <summary> The default color palette for the game </summary> */
	public static Palette SceneryGroupPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

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
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.FromArgb(55, 75, 75), Color.FromArgb(255, 183, 0), Color.FromArgb(255, 219, 0), Color.FromArgb(255, 255, 0),
		Color.FromArgb(7, 107, 99), Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135),
		Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203),

		Color.FromArgb(155, 227, 227), Color.FromArgb(199, 255, 255), Color.FromArgb(67, 91, 91), Color.FromArgb(83, 107, 107),
		Color.FromArgb(99, 123, 123), //Color.FromArgb(0, 0, 95), Color.FromArgb(27, 43, 139), Color.FromArgb(39, 59, 151),

		Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
		Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
		Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

		Color.White
	});
	/** <summary> The default color palette for the game </summary> */
	public static Palette DefaultPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

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
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.FromArgb(55, 75, 75), Color.FromArgb(255, 183, 0), Color.FromArgb(255, 219, 0), Color.FromArgb(255, 255, 0),
		Color.FromArgb(7, 107, 99), Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135),
		Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203),

		Color.FromArgb(155, 227, 227), Color.FromArgb(199, 255, 255), Color.FromArgb(67, 91, 91), Color.FromArgb(83, 107, 107),
		Color.FromArgb(99, 123, 123), //Color.FromArgb(0, 0, 95), Color.FromArgb(27, 43, 139), Color.FromArgb(39, 59, 151),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

		Color.White
	});

	/** <summary> The list of colors in the palette. </summary> */
	public Color[] Colors;
	/** <summary> The offset of the colors. </summary> */
	public int Offset;

	/** <summary> Constructs the default palette. </summary> */
	public Palette(int numColors, int offset = 0) {
		this.Colors = new Color[numColors];
		this.Offset = offset;
	}
	/** <summary> Constructs the default palette. </summary> */
	public Palette(Color[] colors, int offset = 0) {
		this.Colors = colors;
		this.Offset = offset;
	}
}
}
