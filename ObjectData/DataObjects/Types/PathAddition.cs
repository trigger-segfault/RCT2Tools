using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A path addition scenery object. </summary> */
public class PathAddition : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0E;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public PathAdditionHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public PathAddition() : base() {
		this.Header				= new PathAdditionHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	public PathAddition(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new PathAdditionHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			if (Header.Flags.HasFlag(PathAdditionFlags.QueueTV))
				return ObjectSubtypes.QueueTV;
			if (Header.Subtype.HasFlag(PathAdditionSubtypes.Bench))
				return ObjectSubtypes.Bench;
			if (Header.Subtype.HasFlag(PathAdditionSubtypes.LitterBin))
				return ObjectSubtypes.LitterBin;
			if (Header.Subtype.HasFlag(PathAdditionSubtypes.Lamp))
				return ObjectSubtypes.Lamp;
			if (Header.Subtype.HasFlag(PathAdditionSubtypes.JumpFountain))
				return ObjectSubtypes.JumpingFountain;
			return ObjectSubtypes.Basic;
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
		groupInfo.Read(reader);

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
	}
	/** <summary> Writes the object. </summary> */
	public override void Write(BinaryWriter writer) {
		// Write the header
		Header.Write(writer);

		// Write the 1 string table entry
		stringTable.Write(writer);

		// Write the group info
		groupInfo.Write(writer);

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
			if (Header.Flags.HasFlag(PathAdditionFlags.JumpFountain) || Header.Flags.HasFlag(PathAdditionFlags.JumpSnowball)) {
				g.DrawImage(graphicsData.Images[1 + 0], new Point(
					position.X + imageDirectory.entries[1 + 0].XOffset,
					position.Y + imageDirectory.entries[1 + 0].YOffset
				));
				g.DrawImage(graphicsData.Images[1 + 1], new Point(
					position.X + imageDirectory.entries[1 + 1].XOffset,
					position.Y + imageDirectory.entries[1 + 1].YOffset
				));
				g.DrawImage(graphicsData.Images[1 + 2], new Point(
					position.X + imageDirectory.entries[1 + 2].XOffset,
					position.Y + imageDirectory.entries[1 + 2].YOffset
				));
				g.DrawImage(graphicsData.Images[1 + 3], new Point(
					position.X + imageDirectory.entries[1 + 3].XOffset,
					position.Y + imageDirectory.entries[1 + 3].YOffset
				));
			}
			else {
				Point offset = Point.Empty;
				if (Header.Subtype == PathAdditionSubtypes.Bench || Header.Subtype == PathAdditionSubtypes.LitterBin) {
					switch (rotation) {
					case 0: offset = new Point(16 - 4, 8 + 2); break;
					case 1: offset = new Point(16 - 4, 24 - 4); break;
					case 2: offset = new Point(-16 + 4, 24 - 4); break;
					case 3: offset = new Point(-16 + 4, 8 + 4); break;
					}
				}
				else {
					switch (rotation) {
					case 0: offset = new Point(16, 8); break;
					case 1: offset = new Point(16, 24); break;
					case 2: offset = new Point(-16, 24); break;
					case 3: offset = new Point(-16, 8); break;
					}
				}
				g.DrawImage(graphicsData.Images[1 + rotation], new Point(
					position.X + imageDirectory.entries[1 + rotation].XOffset + offset.X,
					position.Y + imageDirectory.entries[1 + rotation].YOffset + offset.Y
				));
			}
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			g.DrawImage(graphicsData.Images[0], new Point(
				position.X + imageDirectory.entries[0].XOffset + 112 / 2 - 20,
				position.Y + imageDirectory.entries[0].YOffset + 112 / 2 - 16
			));
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {

		g.DrawImage(graphicsData.Images[frame], position.X - imageDirectory.entries[frame].Width / 2, position.Y - imageDirectory.entries[frame].Height / 2);
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for path banner scenery objects. </summary> */
public class PathAdditionHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Always zero in files. </summary> */
	public ushort Reserved0;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved1;
	/** <summary> The flags used by the object. </summary> */
	public PathAdditionFlags Flags;
	/** <summary> The subtype of the path addition such as bench or litterbin. </summary> */
	public PathAdditionSubtypes Subtype;
	/** <summary> The cursor to use when placing the object. </summary> */
	public byte Cursor;
	/** <summary> X 10. </summary> */
	public ushort BuildCost;
	/** <summary> Always zero in files. </summary> */
	public byte Reserved2;
	/** <summary> Always zero in files. </summary> */
	public byte Reserved3;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public PathAdditionHeader() {
		this.Reserved0	= 0;
		this.Reserved1	= 0;
		this.Flags		= PathAdditionFlags.None;
		this.Subtype	= PathAdditionSubtypes.Lamp;
		this.Cursor		= 0;
		this.BuildCost	= 0;
		this.Reserved2	= 0;
		this.Reserved3	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return PathAddition.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			if (Flags.HasFlag(PathAdditionFlags.QueueTV))
				return ObjectSubtypes.QueueTV;
			if (Subtype.HasFlag(PathAdditionSubtypes.Bench))
				return ObjectSubtypes.Bench;
			if (Subtype.HasFlag(PathAdditionSubtypes.LitterBin))
				return ObjectSubtypes.LitterBin;
			if (Subtype.HasFlag(PathAdditionSubtypes.Lamp))
				return ObjectSubtypes.Lamp;
			if (Subtype.HasFlag(PathAdditionSubtypes.JumpFountain))
				return ObjectSubtypes.JumpingFountain;
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		PathAdditionHeader header = new PathAdditionHeader();
		header.Read(reader);
		if (header.Flags.HasFlag(PathAdditionFlags.QueueTV))
			return ObjectSubtypes.QueueTV;
		if (header.Subtype.HasFlag(PathAdditionSubtypes.Bench))
			return ObjectSubtypes.Bench;
		if (header.Subtype.HasFlag(PathAdditionSubtypes.LitterBin))
			return ObjectSubtypes.LitterBin;
		if (header.Subtype.HasFlag(PathAdditionSubtypes.Lamp))
			return ObjectSubtypes.Lamp;
		if (header.Subtype.HasFlag(PathAdditionSubtypes.JumpFountain))
			return ObjectSubtypes.JumpingFountain;
		return ObjectSubtypes.Basic;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		this.Reserved0	= reader.ReadUInt16();
		this.Reserved1	= reader.ReadUInt32();
		this.Flags		= (PathAdditionFlags)reader.ReadUInt16();
		this.Subtype	= (PathAdditionSubtypes)reader.ReadByte();
		this.Cursor		= reader.ReadByte();
		this.BuildCost	= reader.ReadUInt16();
		this.Reserved2	= reader.ReadByte();
		this.Reserved3	= reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Reserved1);
		writer.Write((ushort)this.Flags);
		writer.Write((byte)this.Subtype);
		writer.Write(this.Cursor);
		writer.Write(this.BuildCost);
		writer.Write(this.Reserved2);
		writer.Write(this.Reserved3);
	}

	#endregion
}
/** <summary> All flags usable with path banner scenery objects. </summary> */
[Flags]
public enum PathAdditionFlags : ushort {
	/** <summary> No flags are set. </summary> */
	None = 0x0000,
	/** <summary> The addition can hold trash (has an extra static frame). </summary> */
	HoldTrash = 0x0001,
	/** <summary> Guests can sit on this addition. </summary> */
	CanSit = 0x0002,
	/** <summary> The addition can be vandilized. </summary> */
	CanVandal = 0x0004,
	/** <summary> The addition is a light. </summary> */
	Light = 0x0008,
	/** <summary> The addition is a jump fountain. </summary> */
	JumpFountain = 0x0010,
	/** <summary> The addition is a jump snowball fountain. </summary> */
	JumpSnowball = 0x0020,
	/** <summary> Set for benches and jumping fountains/snowballs and Litter bins. </summary> */
	Unknown1 = 0x0040,
	/** <summary> Set for benches and jumping fountains/snowballs. </summary> */
	Unknown2 = 0x0080,
	/** <summary> The addition is a queue line TV. </summary> */
	QueueTV = 0x0100
}
/** <summary> All the subtypes of the path addition scenery objects. </summary> */
public enum PathAdditionSubtypes : byte {
	/** <summary> (edge centered, 1 dialog view, 2 frames of static (normal and vandalized). </summary> */
	Lamp = 0x00,
	/** <summary> (edge centered/inset, 1 dialog view, 3 frames of static (normal and vandalized, and full). </summary> */
	LitterBin = 0x01,
	/** <summary> (edge centered/inset, 1 dialog view, 2 frames of static (normal and vandalized). </summary> */
	Bench = 0x02,
	/** <summary> (corners, 1 dialog view, 1 frame of static). </summary> */
	JumpFountain = 0x03
}
}
