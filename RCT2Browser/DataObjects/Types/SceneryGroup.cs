using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A wall object. </summary> */
public class SceneryGroup : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x10E;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public SceneryGroupHeader Header;

	/** <summary> The contents of the scenery group. </summary> */
	public List<string> Contents;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public SceneryGroup() : base() {
		this.Header		= new SceneryGroupHeader();
		this.Contents	= new List<string>();
	}
	/** <summary> Constructs the default object. </summary> */
	public SceneryGroup(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header		= new SceneryGroupHeader();
		this.Contents	= new List<string>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			return ObjectSubtypes.Group;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of frames in the animation. </summary> */
	public override int AnimationFrames {
		get {
			return 2;
		}
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


		// Read Contents
		byte b = reader.ReadByte();

		while (b != 0xFF) {
			reader.BaseStream.Position--;
			uint flag = reader.ReadUInt32();
			string fileName = "";
			for (int i = 0; i < 8; i++) {
				char c = (char)reader.ReadByte();
				if (c != ' ')
					fileName += c;
			}
			Contents.Add(fileName);
			uint checkSum = reader.ReadUInt32();

			b = reader.ReadByte();
		}

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory, Palette.SceneryGroupPalette);
	}

	#endregion
	//--------------------------------
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			g.DrawImage(graphicsData.Images[frame], position.X - 16, position.Y - 14);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			g.DrawImage(graphicsData.Images[1], position.X - 16 + 112 / 2, position.Y - 14 + 112 / 2);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {

		g.DrawImage(graphicsData.Images[frame], position.X - imageDirectory.Entries[frame].Width / 2, position.Y - imageDirectory.Entries[frame].Height / 2);
		return true;
	}

	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for wall objects. </summary> */
public class SceneryGroupHeader : ObjectTypeHeader {

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
	public SceneryGroupHeader() {
		this.BytePositions	= new List<uint>();
		this.NonZeroBytes	= new List<byte>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return SceneryGroup.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Group;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		SceneryGroupHeader header = new SceneryGroupHeader();
		header.Read(reader);
		return ObjectSubtypes.Group;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		for (int i = 0; i < SceneryGroup.HeaderSize; i++) {
			byte b = reader.ReadByte();
			if (b != 0x00) {
				this.BytePositions.Add((uint)i);
				this.NonZeroBytes.Add(b);
			}
		}
	}

	#endregion
}
/** <summary> All flags usable with wall objects. </summary> */
[Flags]
public enum SceneryGroupFlags : byte {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,
	/** <summary> Uses the first remappable color </summary> */
	Color1 = 0x00000001,
	/** <summary> A "glass" object: the first image is the "frame" and the second image is the "glass" </summary> */
	Glass = 0x00000002,
	/** <summary> Must be on a flat surface. Also, walls can't occupy the same tile </summary> */
	Flat = 0x00000004,
	/** <summary> Has a front and a back </summary> */
	TwoSides = 0x00000008,
	/** <summary> Special processing for doorways (36 images). </summary> */
	Door = 0x00000010,
	/** <summary> Uses the second remappable color </summary> */
	Color2 = 0x00000040,
	/** <summary> Uses the third remappable color </summary> */
	Color3 = 0x00000080
}
}
