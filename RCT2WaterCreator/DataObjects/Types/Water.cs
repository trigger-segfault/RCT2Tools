using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A water object. </summary> */
public class Water : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0E;

	private static Palette[] WaterPalettes = new Palette[]{
		new Palette(new Color[]{Color.FromArgb(55, 155, 151), Color.FromArgb(39, 143, 135), Color.FromArgb(27, 131, 123), Color.FromArgb(15, 119, 111),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135)}),/*
		new Palette(new Color[]{Color.FromArgb(23, 127, 119), Color.FromArgb(15, 115, 107), Color.FromArgb(7, 107, 99), Color.FromArgb(0, 95, 87),
								Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79),
								Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79),
								Color.FromArgb(0, 95, 87), Color.FromArgb(7, 103, 95), Color.FromArgb(15, 115, 107)}),
		new Palette(new Color[]{Color.FromArgb(7, 107, 99), Color.FromArgb(0, 99, 91), Color.FromArgb(0, 91, 83), Color.FromArgb(0, 83, 75),
								Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67),
								Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67),
								Color.FromArgb(0, 83, 75), Color.FromArgb(0, 91, 83), Color.FromArgb(0, 99, 91)}),*/
		new Palette(new Color[]{Color.FromArgb(199, 255, 255), Color.FromArgb(155, 227, 227), Color.FromArgb(115, 203, 203), Color.FromArgb(83, 179, 175),
								Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151),
								Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151),
								Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203), Color.FromArgb(155, 227, 227)})/*,
		new Palette(new Color[]{Color.FromArgb(171, 231, 231), Color.FromArgb(123, 203, 203), Color.FromArgb(83, 179, 175), Color.FromArgb(47, 151, 147),
								Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119),
								Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119),
								Color.FromArgb(47, 151, 147), Color.FromArgb(83, 175, 175), Color.FromArgb(123, 203, 203)}),
		new Palette(new Color[]{Color.FromArgb(131, 207, 207), Color.FromArgb(87, 179, 179), Color.FromArgb(55, 155, 151), Color.FromArgb(27, 131, 123),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(27, 131, 123), Color.FromArgb(51, 155, 151), Color.FromArgb(87, 179, 179)})*/
	};


	/** <summary> The default water color palette for the game </summary> */
	public static Palette WaterPalette = new Palette(new Color[]{
		
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

	private static PaletteImage WaterSparkle;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public WaterHeader Header;
	/** <summary> The preview image for the water. </summary> */
	public Image PreviewImage;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public Water() : base() {
		this.Header = new WaterHeader();
		this.PreviewImage = new Bitmap(64, 48);
	}
	/** <summary> Constructs the default object. </summary> */
	public Water(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header = new WaterHeader();
		this.PreviewImage = new Bitmap(64, 48);
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			return ObjectSubtypes.Water;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of frames in the animation. </summary> */
	public override int AnimationFrames {
		get {
			return 15;
		}
	}

	#endregion
	//========== OVERRIDES ===========
	#region Overrides
	//--------------------------------
	#region Reading

	/** <summary> Reads the object. </summary> */
	public override void Read(BinaryReader reader) {
		Header.Read(reader);

		stringTable.Read(reader);

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);

	}
	/** <summary> Writes the object. </summary> */
	public override void Write(BinaryWriter writer) {
		// Write the header
		Header.Write(writer);

		// Write the 1 string table entry
		stringTable.Write(writer);

		long imageDirectoryPosition = writer.BaseStream.Position;

		// Write the image directory and graphics data
		imageDirectory.Write(writer);
		graphicsData.Write(writer, imageDirectory);

		// Rewrite the image directory after the image addresses are known
		long finalPosition = writer.BaseStream.Position;
		writer.BaseStream.Position = imageDirectoryPosition;
		imageDirectory.Write(writer);

		// Set the position to the end of the file so the file size is known
		writer.BaseStream.Position = finalPosition;
	}

	#endregion
	//--------------------------------
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			g.DrawImage(PreviewImage, position.X - 32, position.Y - 16);
			for (int i = 0; i < 5; i++)
				Water.WaterPalette.Colors[230 + i] = graphicsData.Palettes[1].Colors[(i * 3 + frame) % 15];
			for (int i = 0; i < 5; i++)
				Water.WaterPalette.Colors[235 + i] = graphicsData.Palettes[4].Colors[(i * 3 + frame) % 15];
			Water.WaterSparkle.Draw(g, position.X + 11 - 32, position.Y + 2 - 16, Water.WaterPalette, -1, -1, -1);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			g.DrawImage(PreviewImage, position.X - 32 + 112 / 2, position.Y - 16 + 112 / 2);
			for (int i = 0; i < 5; i++)
				Water.WaterPalette.Colors[230 + i] = graphicsData.Palettes[1].Colors[(i * 3) % 15];
			for (int i = 0; i < 5; i++)
				Water.WaterPalette.Colors[235 + i] = graphicsData.Palettes[4].Colors[(i * 3) % 15];
			Water.WaterSparkle.Draw(g, position.X + 11 - 32 + 112 / 2, position.Y + 2 - 16 + 112 / 2, Water.WaterPalette, -1, -1, -1);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {
		try {
			g.DrawImage(graphicsData.Images[frame], position.X - graphicsData.Images[frame].Width / 2, position.Y - graphicsData.Images[frame].Height / 2);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}

	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for water objects. </summary> */
public class WaterHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> 14 bytes that are always zero in dat files. </summary> */
	public byte[] Reserved0;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public WaterHeader() {
		this.Reserved0	= new byte[14];
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return Water.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Water;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		WaterHeader header = new WaterHeader();
		header.Read(reader);
		return ObjectSubtypes.Water;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		reader.Read(this.Reserved0, 0, this.Reserved0.Length);
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
	}

	#endregion
}
}
