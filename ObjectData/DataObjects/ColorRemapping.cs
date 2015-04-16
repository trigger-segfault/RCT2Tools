using RCT2ObjectData.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {

/** <summary> The data used for color remapping. </summary> */
public class ColorRemapping {
	
	public static RemapPalette[] RemapPalettes = new RemapPalette[32];
	public static RemapPalette[] GlassPalettes = new RemapPalette[32];
	public static RemapPalette[] DarknessPalettes = new RemapPalette[4];

	public static void LoadPalettes() {
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);

		BinaryReader reader = new BinaryReader(new MemoryStream(Resources.RemapStrips));
		imageDirectory.Read(reader);
		graphicsData.Read(reader);

		for (int i = 0; i < 32; i++) {
			RemapPalette remaps = new RemapPalette(12);
			for (int j = 0; j < 12; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[4915 + i - 4915].Pixels[242 + j, 0];
			}
			RemapPalettes[i] = remaps;
		}
		for (int i = 0; i < 32; i++) {
			RemapPalette remaps = new RemapPalette(256);
			for (int j = 0; j < 256; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[5016 + i - 4915].Pixels[j, 0];
			}
			GlassPalettes[i] = remaps;
		}
		for (int i = 0; i < 4; i++) {
			RemapPalette remaps = new RemapPalette(256);
			for (int j = 0; j < 256; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[4951 + i - 4915].Pixels[j, 0];
			}
			DarknessPalettes[i] = remaps;
		}
	}

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

public class RemapPalette {

	//========== CONSTANTS ===========
	#region Constants

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The new indexes for each palette index. </summary> */
	internal byte[] remapIndexes;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs a remap palette with the specified length. </summary> */
	public RemapPalette(int length) {
		this.remapIndexes = new byte[length];
	}

	#endregion
}
}
