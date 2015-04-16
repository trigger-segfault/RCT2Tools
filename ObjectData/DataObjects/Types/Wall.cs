using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A wall object. </summary> */
public class Wall : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0E;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public WallHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public Wall() : base() {
		this.Header = new WallHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	internal Wall(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header = new WallHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the number of string table entries in the object. </summary> */
	private override int NumStringTableEntries {
		get { return 1; }
	}
	/** <summary> Returns true if the object has a group info section. </summary> */
	private override bool HasGroupInfo {
		get { return true; }
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void ReadHeader(BinaryReader reader) {
		Header.Read(reader);
	}
	/** <summary> Writes the object. </summary> */
	public override void WriteHeader(BinaryWriter writer) {
		Header.Write(writer);
	}

	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
		try {
			bool flat = Header.Flags.HasFlag(WallFlags.Flat);
			bool twoSides = Header.Flags.HasFlag(WallFlags.TwoSides);
			bool door = Header.Flags.HasFlag(WallFlags.Door);
			bool glass = Header.Flags.HasFlag(WallFlags.Glass);
			bool animation = ((Header.Effects >> 4) & 0x1) == 0x1;

			int offset = (2 + (!flat ? 4 : 0)) * (twoSides ? 2 : 1) * (door ? 2 : 1);
			int slopeRotation = (drawSettings.Rotation % (twoSides ? 4 : 2)) * (door ? 2 : 1);
			if (drawSettings.Slope >= 0 && !flat) {
				if (drawSettings.Slope % 2 != drawSettings.Rotation % 2) {
					if (drawSettings.Slope >= 2) slopeRotation = (7 - drawSettings.Slope) * (door ? 2 : 1);
					else slopeRotation = (3 - drawSettings.Slope) * (door ? 2 : 1);
				}
			}

			DrawFrame(p, position, drawSettings, slopeRotation + drawSettings.Frame * offset, false);
			if (door)
				DrawFrame(p, position, drawSettings, slopeRotation + 1 + drawSettings.Frame * offset, false);
			if (glass)
				DrawFrame(p, position, drawSettings, offset + slopeRotation + drawSettings.Frame * offset, true);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(PaletteImage p, Point position, DrawSettings drawSettings) {
		try {
			bool flat = Header.Flags.HasFlag(WallFlags.Flat);
			bool twoSides = Header.Flags.HasFlag(WallFlags.TwoSides);
			bool door = Header.Flags.HasFlag(WallFlags.Door);
			bool glass = Header.Flags.HasFlag(WallFlags.Glass);

			int offset = (2 + (!flat ? 4 : 0)) * (twoSides ? 2 : 1) * (door ? 2 : 1);

			DrawDialogFrame(p, position, drawSettings, 0, false);
			if (door)
				DrawDialogFrame(p, position, drawSettings, 1, false);
			if (glass)
				DrawDialogFrame(p, position, drawSettings, offset, true);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	private void DrawFrame(PaletteImage p, Point position, DrawSettings drawSettings, int frame, bool glass) {
		Size offset = Size.Empty;
		if (drawSettings.Slope != -1 && !Header.Flags.HasFlag(WallFlags.Flat)) {
			if (drawSettings.Slope == drawSettings.Rotation) {
				if (drawSettings.Slope < 2) offset.Height = -16;
			}
			else if (drawSettings.Slope % 2 != drawSettings.Rotation % 2) {
				switch (drawSettings.Slope) {
				case 0: if (drawSettings.Rotation == 3) { offset.Width = -32; offset.Height = 16; } break;
				case 1: if (drawSettings.Rotation == 2) { offset.Width =  32; offset.Height = 16; } break;
				case 2: if (drawSettings.Rotation == 1) { offset.Width = -32; offset.Height = 16; } break;
				case 3: if (drawSettings.Rotation == 0) { offset.Width =  32; offset.Height = 16; } break;
				}
			}
			else {
				if (drawSettings.Slope < 2) offset.Height = 16;
				offset.Width = (drawSettings.Slope % 2 == 0 ? 32 : -32);
			}
		}
		else if (drawSettings.Rotation == 2) { offset.Width = 32; offset.Height = 16; }
		else if (drawSettings.Rotation == 3) { offset.Width = -32; offset.Height = 16; }

		graphicsData.paletteImages[frame].Draw(p, Point.Add(position, offset), drawSettings.Darkness, glass,
			(Header.Flags.HasFlag(WallFlags.Color1) || Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? drawSettings.Remap1 : RemapColors.None,
			(Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? (glass ? drawSettings.Remap1 : drawSettings.Remap2) : RemapColors.None,
			Header.Flags.HasFlag(WallFlags.Color3) ? drawSettings.Remap3 : RemapColors.None
		);
	}
	private void DrawDialogFrame(PaletteImage p, Point position, DrawSettings drawSettings, int frame, bool glass) {
		Size offset = new Size(16, 16);

		graphicsData.paletteImages[frame].Draw(p, Point.Add(position, offset), drawSettings.Darkness, glass,
			(Header.Flags.HasFlag(WallFlags.Color1) || Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? drawSettings.Remap1 : RemapColors.None,
			(Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? (glass ? drawSettings.Remap1 : drawSettings.Remap2) : RemapColors.None,
			Header.Flags.HasFlag(WallFlags.Color3) ? drawSettings.Remap3 : RemapColors.None
		);
	}

	#endregion
}
/** <summary> The header used for wall objects. </summary> */
public class WallHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Always zero in files. </summary> */
	public ushort Reserved0;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved1;
	/** <summary> The cursor to use when placing the object. </summary> */
	public byte Cursor;
	/** <summary> The flags used by the object. </summary> */
	public WallFlags Flags;
	/** <summary> The height of the object. </summary> */
	public byte Clearance;
	/** <summary> first nibble = visibility (0 = opaque), upper nibble: 1 = animated (8 frames) </summary> */
	public byte Effects;
	/** <summary> The cost to build the object x 10. </summary> */
	public ushort BuildCost;
	/** <summary> Always zero in files. </summary> */
	public byte Reserved2;
	/** <summary> 0xFF if not scrolling. </summary> */
	public byte Scrolling;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public WallHeader() {
		this.Reserved0	= 0;
		this.Reserved1	= 0;
		this.Cursor		= 0;
		this.Flags		= WallFlags.None;
		this.Clearance	= 32;
		this.Effects	= 0;
		this.BuildCost	= 1;
		this.Reserved2	= 0;
		this.Scrolling	= 0xFF;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return Wall.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			if (Flags.HasFlag(WallFlags.Door))
				return ObjectSubtypes.Door;
			if (Flags.HasFlag(WallFlags.Glass))
				return ObjectSubtypes.Glass;
			if ((Effects & 0x10) != 0x00)
				return ObjectSubtypes.Animation;
			if (Scrolling != 0xFF)
				return ObjectSubtypes.TextScrolling;
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		WallHeader header = new WallHeader();
		header.Read(reader);
		if (header.Flags.HasFlag(WallFlags.Door))
			return ObjectSubtypes.Door;
		if (header.Flags.HasFlag(WallFlags.Glass))
			return ObjectSubtypes.Glass;
		if ((header.Effects & 0x10) != 0x00)
			return ObjectSubtypes.Animation;
		if (header.Scrolling != 0xFF)
			return ObjectSubtypes.TextScrolling;
		return ObjectSubtypes.Basic;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		this.Reserved0	= reader.ReadUInt16();
		this.Reserved1	= reader.ReadUInt32();
		this.Cursor		= reader.ReadByte();
		this.Flags		= (WallFlags)reader.ReadByte();
		this.Clearance	= reader.ReadByte();
		this.Effects	= reader.ReadByte();
		this.BuildCost	= reader.ReadUInt16();
		this.Reserved2	= reader.ReadByte();
		this.Scrolling	= reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Reserved1);
		writer.Write(this.Cursor);
		writer.Write((byte)this.Flags);
		writer.Write(this.Clearance);
		writer.Write(this.Effects);
		writer.Write(this.BuildCost);
		writer.Write(this.Reserved2);
		writer.Write(this.Scrolling);
	}

	#endregion
}
/** <summary> All flags usable with wall objects. </summary> */
[Flags]
public enum WallFlags : byte {
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
