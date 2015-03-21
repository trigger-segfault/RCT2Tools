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

	/** <summary> Constructs the default object. </summary> */
	public override void Read(BinaryReader reader) {
		Header.Read(reader);

		stringTable.Read(reader);

		//groupInfo.Read(reader);
		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);

		Graphics g = Graphics.FromImage(PreviewImage);
		g.DrawImage(Resources.Water, Point.Empty);
		g.Dispose();

		for (int x = 0; x < PreviewImage.Width; x++) {
			for (int y = 0; y < 32; y++) {
				//Console.WriteLine(x + " " + y);
				for (int i = 190; i < 240; i++) {
					if (Palette.DefaultPalette.Colors[i] == (PreviewImage as Bitmap).GetPixel(x, y)) {
						(PreviewImage as Bitmap).SetPixel(x, y, graphicsData.Palettes[0].Colors[i - 10]);
						break;
					}
					if (i == 201)
						i = 229;
				}
			}
		}
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

		return false;
	}

	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for water objects. </summary> */
public class WaterHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The positions of all non-zero bytes. </summary> */
	public List<uint> BytePositions;
	/** <summary> The list of all non-zero bytes. </summary> */
	public List<byte> NonZeroBytes;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public WaterHeader() {
		this.BytePositions	= new List<uint>();
		this.NonZeroBytes	= new List<byte>();
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
		for (int i = 0; i < Water.HeaderSize; i++) {
			byte b = reader.ReadByte();
			if (b != 0x00) {
				this.BytePositions.Add((uint)i);
				this.NonZeroBytes.Add(b);
			}
		}
	}

	#endregion
}
}
