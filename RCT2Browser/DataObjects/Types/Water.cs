using RCTDataEditor.Properties;
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
								Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135)}),
		new Palette(new Color[]{Color.FromArgb(23, 127, 119), Color.FromArgb(15, 115, 107), Color.FromArgb(7, 107, 99), Color.FromArgb(0, 95, 87),
								Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79),
								Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79), Color.FromArgb(0, 87, 79),
								Color.FromArgb(0, 95, 87), Color.FromArgb(7, 103, 95), Color.FromArgb(15, 115, 107)}),
		new Palette(new Color[]{Color.FromArgb(7, 107, 99), Color.FromArgb(0, 99, 91), Color.FromArgb(0, 91, 83), Color.FromArgb(0, 83, 75),
								Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67),
								Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 75, 67),
								Color.FromArgb(0, 83, 75), Color.FromArgb(0, 91, 83), Color.FromArgb(0, 99, 91)}),
		new Palette(new Color[]{Color.FromArgb(199, 255, 255), Color.FromArgb(155, 227, 227), Color.FromArgb(115, 203, 203), Color.FromArgb(83, 179, 175),
								Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151),
								Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151),
								Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203), Color.FromArgb(155, 227, 227)}),
		new Palette(new Color[]{Color.FromArgb(171, 231, 231), Color.FromArgb(123, 203, 203), Color.FromArgb(83, 179, 175), Color.FromArgb(47, 151, 147),
								Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119),
								Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119), Color.FromArgb(23, 127, 119),
								Color.FromArgb(47, 151, 147), Color.FromArgb(83, 175, 175), Color.FromArgb(123, 203, 203)}),
		new Palette(new Color[]{Color.FromArgb(131, 207, 207), Color.FromArgb(87, 179, 179), Color.FromArgb(55, 155, 151), Color.FromArgb(27, 131, 123),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99), Color.FromArgb(7, 107, 99),
								Color.FromArgb(27, 131, 123), Color.FromArgb(51, 155, 151), Color.FromArgb(87, 179, 179)})
	};


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

		Graphics g = Graphics.FromImage(PreviewImage);
		g.DrawImage(Resources.Water, Point.Empty);
		g.Dispose();

		for (int x = 0; x < PreviewImage.Width; x++) {
			for (int y = 0; y < 32; y++) {
				//Console.WriteLine(x + " " + y);
				bool colorFound = false;
				for (int i = 190; i < 202 && !colorFound; i++) {
					if (Palette.DefaultPalette.Colors[i] == (PreviewImage as Bitmap).GetPixel(x, y)) {
						(PreviewImage as Bitmap).SetPixel(x, y, graphicsData.Palettes[0].Colors[i - 10]);
						colorFound = true;
					}
				}
				for (int j = 0; j < Water.WaterPalettes.Length && !colorFound; j++) {
					for (int i = 0; i < Water.WaterPalettes[j].Colors.Length && !colorFound; i++) {
						if (Water.WaterPalettes[j].Colors[i] == (PreviewImage as Bitmap).GetPixel(x, y)) {
							(PreviewImage as Bitmap).SetPixel(x, y, graphicsData.Palettes[j + 1].Colors[i]);
							colorFound = true;
						}
					}
				}
			}
		}
	}
	/** <summary> Writes the object. </summary> */
	public void Write(BinaryWriter writer) {
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
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			g.DrawImage(PreviewImage, position.X - 32 + 112 / 2, position.Y - 16 + 112 / 2);
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
