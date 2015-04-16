using System;
using System.Collections.Generic;
using System.Drawing;
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
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(x1, y1, palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(x + x1, y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	public void Draw(Bitmap b, Palette palette, int remap1, int remap2, int remap3) {
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
}

/** <summary> A palette used for storing colors. </summary> */
public class Palette {

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
		
		Color.Transparent, Color.Black,/* Color.FromArgb, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,*/
		Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), Color.FromArgb(75, 75, 75),
		Color.FromArgb(100, 100, 100), Color.FromArgb(125, 125, 125), Color.FromArgb(150, 150, 150), Color.FromArgb(175, 175, 175), Color.FromArgb(200, 200, 200),

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
	/** <summary> The default color palette for the game </summary> */
	public static Palette FontPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Transparent, Color.Transparent, Color.Transparent,
		Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent,

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
	/** <summary> The default color palette for the game </summary> */
	public static Palette FontOutlinePalette = new Palette(new Color[]{
		
		Color.Transparent, Color.White, Color.Black, Color.Black, Color.Black,
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
	/** <summary> The default color palette for the game </summary> */
	public static Palette ChrisSawyerPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

		Color.FromArgb(0, 0, 0), Color.FromArgb(7, 7, 11), Color.FromArgb(7, 11, 15), Color.FromArgb(11, 11, 15),
		Color.FromArgb(7, 15, 23), Color.FromArgb(11, 19, 27), Color.FromArgb(23, 23, 23), Color.FromArgb(15, 27, 39),
		Color.FromArgb(23, 31, 35), Color.FromArgb(15, 35, 43), Color.FromArgb(23, 39, 47), Color.FromArgb(19, 39, 55),

		Color.FromArgb(35, 35, 35), Color.FromArgb(35, 39, 43), Color.FromArgb(43, 43, 43), Color.FromArgb(39, 47, 51),
		Color.FromArgb(47, 51, 51), Color.FromArgb(55, 55, 55), Color.FromArgb(27, 55, 75), Color.FromArgb(31, 63, 83),
		Color.FromArgb(43, 59, 67), Color.FromArgb(51, 63, 71), Color.FromArgb(31, 67, 87), Color.FromArgb(35, 71, 91),

		Color.FromArgb(55, 67, 75), Color.FromArgb(59, 75, 87), Color.FromArgb(39, 75, 99), Color.FromArgb(43, 83, 111),
		Color.FromArgb(43, 91, 119), Color.FromArgb(51, 79, 99), Color.FromArgb(63, 87, 107), Color.FromArgb(59, 95, 119),
		Color.FromArgb(59, 99, 123), Color.FromArgb(71, 71, 71), Color.FromArgb(79, 79, 83), Color.FromArgb(75, 83, 87),

		Color.FromArgb(87, 87, 87), Color.FromArgb(71, 95, 111), Color.FromArgb(83, 95, 99), Color.FromArgb(75, 103, 119),
		Color.FromArgb(87, 103, 111), Color.FromArgb(103, 103, 103), Color.FromArgb(107, 119, 127), Color.FromArgb(119, 119, 119),
		Color.FromArgb(55, 103, 139), Color.FromArgb(55, 111, 151), Color.FromArgb(63, 119, 159), Color.FromArgb(63, 127, 171),

		Color.FromArgb(75, 115, 143), Color.FromArgb(75, 119, 151), Color.FromArgb(87, 115, 135), Color.FromArgb(87, 127, 155),
		Color.FromArgb(99, 123, 139), Color.FromArgb(127, 103, 135), Color.FromArgb(95, 131, 155), Color.FromArgb(75, 135, 175),
		Color.FromArgb(67, 139, 183), Color.FromArgb(83, 139, 179), Color.FromArgb(95, 151, 187), Color.FromArgb(103, 131, 151),

		Color.FromArgb(111, 139, 187), Color.FromArgb(107, 155, 191), Color.FromArgb(115, 135, 179), Color.FromArgb(123, 163, 187),
		Color.FromArgb(75, 147, 195), Color.FromArgb(79, 159, 211), Color.FromArgb(79, 163, 219), Color.FromArgb(95, 167, 215),
		Color.FromArgb(87, 175, 235), Color.FromArgb(95, 179, 239), Color.FromArgb(95, 183, 247), Color.FromArgb(95, 187, 247),

		Color.FromArgb(95, 191, 251), Color.FromArgb(111, 143, 195), Color.FromArgb(107, 151, 199), Color.FromArgb(103, 159, 211),
		Color.FromArgb(99, 163, 203), Color.FromArgb(103, 167, 223), Color.FromArgb(123, 167, 219), Color.FromArgb(99, 171, 231),
		Color.FromArgb(107, 183, 235), Color.FromArgb(99, 191, 251), Color.FromArgb(119, 187, 235), Color.FromArgb(103, 195, 255),

		Color.FromArgb(107, 195, 255), Color.FromArgb(119, 195, 247), Color.FromArgb(115, 199, 255), Color.FromArgb(119, 203, 255),
		Color.FromArgb(123, 199, 251), Color.FromArgb(123, 203, 255), Color.FromArgb(159, 11, 15), Color.FromArgb(159, 15, 19),
		Color.FromArgb(155, 19, 27), Color.FromArgb(155, 27, 35), Color.FromArgb(151, 39, 51), Color.FromArgb(167, 0, 0),

		Color.FromArgb(183, 7, 7), Color.FromArgb(183, 27, 27), Color.FromArgb(143, 55, 75), Color.FromArgb(139, 63, 83),
		Color.FromArgb(147, 47, 67), Color.FromArgb(147, 51, 67), Color.FromArgb(167, 91, 107), Color.FromArgb(179, 95, 111),
		Color.FromArgb(195, 11, 11), Color.FromArgb(207, 27, 27), Color.FromArgb(219, 23, 23), Color.FromArgb(207, 47, 47),

		Color.FromArgb(203, 59, 59), Color.FromArgb(215, 43, 43), Color.FromArgb(219, 59, 59), Color.FromArgb(235, 27, 27),
		Color.FromArgb(243, 31, 31), Color.FromArgb(235, 43, 43), Color.FromArgb(227, 63, 63), Color.FromArgb(255, 35, 35),
		Color.FromArgb(251, 47, 51), Color.FromArgb(255, 55, 55), Color.FromArgb(251, 63, 67), Color.FromArgb(215, 75, 75),

		Color.FromArgb(219, 95, 107), Color.FromArgb(211, 107, 123), Color.FromArgb(223, 115, 127), Color.FromArgb(235, 71, 71),
		Color.FromArgb(227, 87, 87), Color.FromArgb(255, 67, 67), Color.FromArgb(255, 87, 87), Color.FromArgb(235, 103, 115),
		Color.FromArgb(227, 115, 123), Color.FromArgb(255, 107, 107), Color.FromArgb(255, 119, 119), Color.FromArgb(139, 111, 143),

		Color.FromArgb(167, 127, 155), Color.FromArgb(219, 123, 139), Color.FromArgb(231, 123, 131), Color.FromArgb(243, 127, 131),
		Color.FromArgb(135, 135, 135), Color.FromArgb(139, 139, 139), Color.FromArgb(139, 147, 155), Color.FromArgb(151, 151, 151),
		Color.FromArgb(143, 139, 179), Color.FromArgb(131, 159, 175), Color.FromArgb(131, 147, 191), Color.FromArgb(139, 167, 187),

		Color.FromArgb(159, 163, 167), Color.FromArgb(163, 163, 163), Color.FromArgb(163, 167, 171), Color.FromArgb(171, 171, 171),
		Color.FromArgb(175, 179, 183), Color.FromArgb(179, 179, 179), Color.FromArgb(191, 191, 191), Color.FromArgb(139, 159, 199),
		Color.FromArgb(147, 159, 199), Color.FromArgb(139, 171, 219), Color.FromArgb(143, 179, 199), Color.FromArgb(135, 187, 219),

		Color.FromArgb(155, 167, 207), Color.FromArgb(147, 171, 211), Color.FromArgb(155, 179, 195), Color.FromArgb(155, 183, 219),
		Color.FromArgb(135, 191, 235), Color.FromArgb(151, 191, 231), Color.FromArgb(163, 167, 203), Color.FromArgb(167, 175, 211),
		Color.FromArgb(179, 191, 199), Color.FromArgb(139, 195, 235), Color.FromArgb(131, 207, 255), Color.FromArgb(139, 199, 243),

		Color.FromArgb(143, 203, 247), Color.FromArgb(139, 207, 255), Color.FromArgb(135, 211, 255), Color.FromArgb(143, 211, 255),
		Color.FromArgb(147, 199, 235), Color.FromArgb(151, 207, 247), Color.FromArgb(147, 211, 255), Color.FromArgb(155, 215, 255),
		Color.FromArgb(159, 219, 255), Color.FromArgb(175, 195, 207), Color.FromArgb(183, 195, 203), Color.FromArgb(163, 215, 255),

		Color.FromArgb(163, 219, 255), Color.FromArgb(171, 219, 247), Color.FromArgb(171, 223, 255), Color.FromArgb(179, 211, 235),
		Color.FromArgb(179, 223, 255), Color.FromArgb(191, 223, 247), Color.FromArgb(175, 227, 255), Color.FromArgb(183, 227, 255),
		Color.FromArgb(187, 227, 255), Color.FromArgb(207, 135, 135), Color.FromArgb(223, 143, 155), Color.FromArgb(219, 147, 159),

		Color.FromArgb(203, 147, 167), Color.FromArgb(215, 147, 163), Color.FromArgb(227, 135, 143), Color.FromArgb(227, 139, 151),
		Color.FromArgb(255, 131, 131), Color.FromArgb(255, 155, 155), Color.FromArgb(247, 159, 163), Color.FromArgb(235, 179, 179),
		Color.FromArgb(255, 163, 163), Color.FromArgb(255, 183, 183), Color.FromArgb(203, 203, 203), Color.FromArgb(203, 215, 219),

		Color.FromArgb(211, 199, 207), Color.FromArgb(223, 203, 215), Color.FromArgb(215, 215, 215), Color.FromArgb(203, 223, 235),
		Color.FromArgb(215, 219, 231), Color.FromArgb(195, 231, 255), Color.FromArgb(199, 235, 255), Color.FromArgb(207, 231, 247),
		Color.FromArgb(203, 235, 255), Color.FromArgb(219, 227, 235), Color.FromArgb(211, 231, 247), Color.FromArgb(211, 235, 247),

		Color.FromArgb(211, 239, 255), Color.FromArgb(219, 235, 247), Color.FromArgb(219, 239, 255), Color.FromArgb(215, 243, 255),
		Color.FromArgb(223, 243, 255), Color.FromArgb(239, 203, 211), Color.FromArgb(255, 207, 207), Color.FromArgb(255, 219, 219),
		Color.FromArgb(251, 223, 227), Color.FromArgb(231, 231, 231), Color.FromArgb(231, 235, 243), Color.FromArgb(227, 243, 255),

		Color.FromArgb(235, 247, 255), Color.FromArgb(239, 251, 255), Color.FromArgb(255, 231, 231), Color.FromArgb(243, 243, 243),
		Color.FromArgb(243, 251, 255), Color.FromArgb(255, 243, 243), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 0, 255),

		Color.White, Color.White, Color.White, Color.White, Color.White,
		Color.White, Color.White, Color.White, Color.White, Color.White
	});
	/** <summary> The default color palette for the game </summary> */
	public static Palette LogoPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

		Color.FromArgb(54, 41, 56), Color.FromArgb(59, 52, 39), Color.FromArgb(55, 53, 56), Color.FromArgb(4, 23, 75),
		Color.FromArgb(7, 19, 109), Color.FromArgb(13, 33, 89), Color.FromArgb(15, 37, 109), Color.FromArgb(34, 30, 71),
		Color.FromArgb(38, 14, 120), Color.FromArgb(44, 47, 79), Color.FromArgb(44, 51, 110), Color.FromArgb(62, 64, 26),

		Color.FromArgb(54, 68, 86), Color.FromArgb(57, 69, 110), Color.FromArgb(80, 10, 9), Color.FromArgb(76, 46, 18),
		Color.FromArgb(76, 51, 48), Color.FromArgb(113, 14, 14), Color.FromArgb(111, 21, 46), Color.FromArgb(104, 53, 22),
		Color.FromArgb(112, 47, 37), Color.FromArgb(85, 10, 75), Color.FromArgb(64, 8, 102), Color.FromArgb(70, 58, 78),

		Color.FromArgb(68, 55, 109), Color.FromArgb(99, 13, 71), Color.FromArgb(122, 63, 66), Color.FromArgb(81, 68, 27),
		Color.FromArgb(87, 72, 41), Color.FromArgb(118, 77, 16), Color.FromArgb(111, 80, 45), Color.FromArgb(122, 102, 27),
		Color.FromArgb(120, 102, 48), Color.FromArgb(69, 67, 69), Color.FromArgb(73, 70, 86), Color.FromArgb(71, 84, 90),

		Color.FromArgb(88, 71, 71), Color.FromArgb(85, 73, 88), Color.FromArgb(92, 82, 73), Color.FromArgb(89, 84, 90),
		Color.FromArgb(78, 77, 110), Color.FromArgb(92, 97, 93), Color.FromArgb(87, 102, 110), Color.FromArgb(107, 86, 79),
		Color.FromArgb(102, 88, 105), Color.FromArgb(120, 103, 81), Color.FromArgb(104, 101, 104), Color.FromArgb(106, 102, 116),

		Color.FromArgb(103, 113, 106), Color.FromArgb(104, 118, 119), Color.FromArgb(120, 104, 101), Color.FromArgb(116, 104, 114),
		Color.FromArgb(122, 118, 104), Color.FromArgb(121, 119, 119), Color.FromArgb(22, 9, 137), Color.FromArgb(22, 19, 165),
		Color.FromArgb(25, 43, 135), Color.FromArgb(25, 39, 165), Color.FromArgb(38, 22, 147), Color.FromArgb(38, 25, 168),

		Color.FromArgb(42, 47, 147), Color.FromArgb(53, 52, 170), Color.FromArgb(54, 53, 197), Color.FromArgb(58, 67, 152),
		Color.FromArgb(61, 67, 163), Color.FromArgb(68, 57, 139), Color.FromArgb(70, 56, 174), Color.FromArgb(99, 62, 190),
		Color.FromArgb(74, 60, 197), Color.FromArgb(84, 54, 235), Color.FromArgb(105, 60, 249), Color.FromArgb(79, 76, 139),

		Color.FromArgb(82, 76, 175), Color.FromArgb(89, 102, 136), Color.FromArgb(91, 101, 172), Color.FromArgb(101, 85, 141),
		Color.FromArgb(100, 86, 185), Color.FromArgb(111, 111, 141), Color.FromArgb(105, 99, 186), Color.FromArgb(86, 68, 202),
		Color.FromArgb(93, 66, 234), Color.FromArgb(104, 81, 204), Color.FromArgb(120, 77, 236), Color.FromArgb(119, 103, 198),

		Color.FromArgb(122, 99, 233), Color.FromArgb(126, 128, 84), Color.FromArgb(118, 132, 122), Color.FromArgb(120, 132, 145),
		Color.FromArgb(121, 131, 163), Color.FromArgb(127, 128, 214), Color.FromArgb(142, 21, 22), Color.FromArgb(152, 28, 33),
		Color.FromArgb(144, 36, 28), Color.FromArgb(151, 39, 35), Color.FromArgb(174, 18, 20), Color.FromArgb(170, 28, 34),

		Color.FromArgb(168, 35, 28), Color.FromArgb(177, 44, 41), Color.FromArgb(170, 60, 69), Color.FromArgb(135, 87, 12),
		Color.FromArgb(142, 85, 42), Color.FromArgb(147, 112, 3), Color.FromArgb(143, 113, 52), Color.FromArgb(165, 90, 28),
		Color.FromArgb(173, 78, 47), Color.FromArgb(170, 107, 22), Color.FromArgb(176, 111, 45), Color.FromArgb(138, 89, 72),

		Color.FromArgb(141, 112, 76), Color.FromArgb(139, 117, 105), Color.FromArgb(178, 80, 73), Color.FromArgb(185, 93, 96),
		Color.FromArgb(172, 114, 72), Color.FromArgb(207, 14, 16), Color.FromArgb(213, 30, 33), Color.FromArgb(199, 41, 25),
		Color.FromArgb(207, 53, 50), Color.FromArgb(229, 16, 16), Color.FromArgb(227, 30, 32), Color.FromArgb(231, 49, 51),

		Color.FromArgb(214, 62, 64), Color.FromArgb(234, 61, 65), Color.FromArgb(210, 68, 58), Color.FromArgb(208, 121, 46),
		Color.FromArgb(229, 68, 59), Color.FromArgb(228, 125, 41), Color.FromArgb(213, 74, 69), Color.FromArgb(207, 107, 78),
		Color.FromArgb(200, 114, 102), Color.FromArgb(235, 82, 79), Color.FromArgb(251, 93, 96), Color.FromArgb(241, 99, 88),

		Color.FromArgb(252, 107, 109), Color.FromArgb(141, 120, 136), Color.FromArgb(128, 114, 190), Color.FromArgb(129, 90, 239),
		Color.FromArgb(140, 116, 207), Color.FromArgb(133, 101, 240), Color.FromArgb(254, 126, 130), Color.FromArgb(157, 130, 15),
		Color.FromArgb(152, 132, 55), Color.FromArgb(171, 143, 18), Color.FromArgb(173, 141, 57), Color.FromArgb(186, 163, 26),

		Color.FromArgb(186, 165, 38), Color.FromArgb(153, 135, 77), Color.FromArgb(145, 137, 111), Color.FromArgb(159, 160, 80),
		Color.FromArgb(175, 146, 73), Color.FromArgb(169, 144, 108), Color.FromArgb(183, 168, 78), Color.FromArgb(178, 170, 108),
		Color.FromArgb(191, 195, 79), Color.FromArgb(214, 136, 52), Color.FromArgb(197, 174, 26), Color.FromArgb(201, 177, 46),

		Color.FromArgb(237, 147, 55), Color.FromArgb(251, 170, 60), Color.FromArgb(203, 151, 71), Color.FromArgb(205, 142, 106),
		Color.FromArgb(207, 174, 77), Color.FromArgb(205, 181, 105), Color.FromArgb(230, 153, 68), Color.FromArgb(236, 130, 107),
		Color.FromArgb(251, 179, 70), Color.FromArgb(230, 185, 104), Color.FromArgb(216, 195, 28), Color.FromArgb(214, 202, 48),

		Color.FromArgb(232, 214, 52), Color.FromArgb(245, 248, 45), Color.FromArgb(214, 203, 80), Color.FromArgb(214, 203, 103),
		Color.FromArgb(222, 225, 81), Color.FromArgb(251, 206, 80), Color.FromArgb(244, 216, 101), Color.FromArgb(253, 246, 83),
		Color.FromArgb(253, 247, 105), Color.FromArgb(134, 135, 135), Color.FromArgb(137, 134, 150), Color.FromArgb(136, 149, 137),

		Color.FromArgb(138, 152, 152), Color.FromArgb(153, 133, 136), Color.FromArgb(145, 138, 151), Color.FromArgb(146, 154, 140),
		Color.FromArgb(151, 152, 151), Color.FromArgb(140, 147, 173), Color.FromArgb(154, 167, 155), Color.FromArgb(154, 165, 172),
		Color.FromArgb(170, 137, 139), Color.FromArgb(166, 157, 160), Color.FromArgb(179, 173, 145), Color.FromArgb(165, 169, 169),

		Color.FromArgb(164, 169, 185), Color.FromArgb(169, 180, 166), Color.FromArgb(170, 181, 182), Color.FromArgb(178, 172, 161),
		Color.FromArgb(178, 182, 168), Color.FromArgb(180, 186, 186), Color.FromArgb(152, 132, 211), Color.FromArgb(149, 136, 237),
		Color.FromArgb(156, 162, 208), Color.FromArgb(162, 140, 212), Color.FromArgb(166, 152, 246), Color.FromArgb(176, 180, 200),

		Color.FromArgb(179, 171, 243), Color.FromArgb(185, 196, 182), Color.FromArgb(188, 194, 203), Color.FromArgb(198, 184, 140),
		Color.FromArgb(194, 190, 163), Color.FromArgb(253, 140, 143), Color.FromArgb(254, 157, 160), Color.FromArgb(253, 172, 175),
		Color.FromArgb(198, 186, 248), Color.FromArgb(254, 190, 192), Color.FromArgb(209, 204, 146), Color.FromArgb(208, 208, 176),

		Color.FromArgb(222, 225, 153), Color.FromArgb(233, 213, 137), Color.FromArgb(230, 219, 172), Color.FromArgb(250, 249, 141),
		Color.FromArgb(251, 250, 174), Color.FromArgb(197, 202, 201), Color.FromArgb(199, 201, 216), Color.FromArgb(202, 211, 199),
		Color.FromArgb(205, 211, 212), Color.FromArgb(209, 216, 204), Color.FromArgb(213, 218, 216), Color.FromArgb(211, 210, 233),

		Color.FromArgb(218, 227, 215), Color.FromArgb(220, 226, 229), Color.FromArgb(253, 205, 207), Color.FromArgb(232, 221, 240),
		Color.FromArgb(246, 247, 202), Color.FromArgb(229, 231, 230), Color.FromArgb(233, 232, 246), Color.FromArgb(236, 243, 231),

		Color.White, Color.White, Color.White, Color.White, Color.White,
		Color.White, Color.White, Color.White, Color.White, Color.White
	});

	/** <summary> The list of colors in the palette. </summary> */
	public Color[] Colors;

	/** <summary> Constructs the default palette. </summary> */
	public Palette(int numColors) {
		this.Colors = new Color[numColors];
	}
	/** <summary> Constructs the default palette. </summary> */
	public Palette(Color[] colors) {
		this.Colors = colors;
	}
}
}
