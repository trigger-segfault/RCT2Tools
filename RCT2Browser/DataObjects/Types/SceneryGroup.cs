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

	/** <summary> Reads the object. </summary> */
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
	/** <summary> Writes the object. </summary> */
	public override void Write(BinaryWriter writer) {
		// Write the header
		Header.Write(writer);

		// Write the 1 string table entry
		stringTable.Write(writer);

		// Write Contents
		for (int i = 0; i < this.Contents.Count; i++) {
			writer.Write((uint)0x00000000);
			for (int j = 0; j < 8; j++) {
				if (j < this.Contents[i].Length)
					writer.Write(this.Contents[i][j]);
				else
					writer.Write(' ');
			}
			writer.Write((uint)0x00000000);
		}
		writer.Write((byte)0xFF);

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

	/** <summary> 0x108 bytes of data that are always zero in dat files. </summary> */
	public byte[] Reserved0;
	/** <summary> An unknown byte that is never zero. </summary> */
	public byte Unknown0x108;
	/** <summary> Always zero in dat files. </summary> */
	public byte Reserved1;
	/** <summary> An unknown byte that is most often zero. </summary> */
	public byte Unknown0x10A;
	/** <summary> An unknown byte that is most often zero. </summary> */
	public byte Unknown0x10B;
	/** <summary> Always zero in dat files. </summary> */
	public ushort Reserved2;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public SceneryGroupHeader() {
		this.Reserved0		= new byte[0x108];
		this.Unknown0x108	= 0;
		this.Reserved1		= 0;
		this.Unknown0x10A	= 0;
		this.Unknown0x10B	= 0;
		this.Reserved2		= 0;
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
		reader.Read(this.Reserved0, 0, this.Reserved0.Length);
		this.Unknown0x108	= reader.ReadByte();
		this.Reserved1		= reader.ReadByte();
		this.Unknown0x10A	= reader.ReadByte();
		this.Unknown0x10B	= reader.ReadByte();
		this.Reserved2		= reader.ReadUInt16();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Unknown0x108);
		writer.Write(this.Reserved1);
		writer.Write(this.Unknown0x10A);
		writer.Write(this.Unknown0x10B);
		writer.Write(this.Reserved2);
	}

	#endregion
}
}
