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

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The color indexes used for general remaps. </summary> */
	public static RemapPalette[] RemapPalettes = new RemapPalette[32];
	/** <summary> The color indexes used for glass transparency. </summary> */
	public static RemapPalette[] GlassPalettes = new RemapPalette[32];
	/** <summary> The color indexes used for water transparency. </summary> */
	public static RemapPalette[] WaterPalettes = new RemapPalette[5];
	/** <summary> The color indexes used for darkness. </summary> */
	public static RemapPalette[] DarknessPalettes = new RemapPalette[4];

	#endregion
	//=========== LOADING ============
	#region Loading

	/** <summary> Loads the color remapping resources. </summary> */
	public static void LoadResources() {
		/*ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);

		BinaryReader reader = new BinaryReader(new MemoryStream(Resources.RemapStrips));
		imageDirectory.Read(reader);
		graphicsData.Read(reader);*/
		GraphicsData graphicsData = GraphicsData.FromBuffer(Resources.RemapStrips);

		for (int i = 0; i < 32; i++) {
			RemapPalette remaps = new RemapPalette(12);
			for (int j = 0; j < 12; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[4915 + i - 4915].Pixels[243 + j, 0];
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
		for (int i = 0; i < 5; i++) {
			RemapPalette remaps = new RemapPalette(256);
			for (int j = 0; j < 256; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[4947 - 4915].Pixels[j, i];
			}
			WaterPalettes[i] = remaps;
		}
		for (int i = 0; i < 4; i++) {
			RemapPalette remaps = new RemapPalette(256);
			for (int j = 0; j < 256; j++) {
				remaps.remapIndexes[j] = graphicsData.paletteImages[4951 + i - 4915].Pixels[j, 0];
			}
			DarknessPalettes[i] = remaps;
		}
	}

	#endregion
}
/** <summary> A palette for translating colors with during remaps. </summary> */
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
/** <summary> An enumeration for the RCT2 remap colors. </summary> */
public enum RemapColors : int {
	None = -1,

	Black = 0,
	Gray = 1,
	White = 2,
	Indigo = 3,
	SlateBlue = 4,
	Purple = 5,
	Blue = 6,
	LightBlue = 7,

	Frost = 8,
	Water = 9,
	LightWater = 10,
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
}
