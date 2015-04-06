using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
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
	public Wall(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header = new WallHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			if (Header.Flags.HasFlag(WallFlags.Door))
				return ObjectSubtypes.Door;
			if (Header.Flags.HasFlag(WallFlags.Glass))
				return ObjectSubtypes.Glass;
			if ((Header.Effects & 0x10) != 0x00)
				return ObjectSubtypes.Animation;
			if (Header.Scrolling != 0xFF)
				return ObjectSubtypes.TextScrolling;
			return ObjectSubtypes.Basic;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return !Header.Flags.HasFlag(WallFlags.Flat); }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return (Header.Flags.HasFlag(WallFlags.Color3) ? 3 : (Header.Flags.HasFlag(WallFlags.Color2) ? 2 : (Header.Flags.HasFlag(WallFlags.Color1) ? 1 : 0))); }
	}
	/** <summary> Gets the number of frames in the animation. </summary> */
	public override int AnimationFrames {
		get {
			if (Header.Flags.HasFlag(WallFlags.Door))
				return 5;
			if ((Header.Effects & 0x10) != 0x0)
				return 8;
			return 1;
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

		groupInfo.Read(reader);
		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
	}
	/** <summary> Writes the object. </summary> */
	public void Write(BinaryWriter writer) {
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

	private void DrawDialogFrame(Graphics g, Point position, int frame, int rotation, bool glass = false) {
		int offsetX = (rotation % 2 == 0 ? 16 : -16);
		int offsetY = 16;

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + offsetX + imageDirectory.Entries[frame].XOffset + 112 / 2,
			position.Y + offsetY + imageDirectory.Entries[frame].YOffset + (112) / 2,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(WallFlags.Color1) || Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? (glass ? GraphicsData.ColorRemap1 : GraphicsData.ColorRemap2) : -1,
			Header.Flags.HasFlag(WallFlags.Color3) ? GraphicsData.ColorRemap3 : -1
		);
	}
	private void DrawFrame(Graphics g, Point position, int frame, int rotation, int slope, bool glass = false) {
		int offsetX = 0, offsetY = 0;
		if (slope != -1 && CanSlope) {
			if (slope == rotation) {
				if (slope < 2) offsetY = -16;
			}
			else if (slope % 2 != rotation % 2) {
				switch (slope) {
				case 0: if (rotation == 3) { offsetX = -32; offsetY = 16; } break;
				case 1: if (rotation == 2) { offsetX =  32; offsetY = 16; } break;
				case 2: if (rotation == 1) { offsetX = -32; offsetY = 16; } break;
				case 3: if (rotation == 0) { offsetX =  32; offsetY = 16; } break;
				}
			}
			else {
				if (slope < 2) offsetY = 16;
				offsetX = (slope % 2 == 0 ? 32 : -32);
			}
		}
		else if (rotation == 2) { offsetX = 32; offsetY = 16; }
		else if (rotation == 3) { offsetX = -32; offsetY = 16; }

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + offsetX + imageDirectory.Entries[frame].XOffset,
			position.Y + offsetY + imageDirectory.Entries[frame].YOffset,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(WallFlags.Color1) || Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? (glass ? GraphicsData.ColorRemap1 : GraphicsData.ColorRemap2) : -1,
			Header.Flags.HasFlag(WallFlags.Color3) ? GraphicsData.ColorRemap3 : -1
		);
	}
	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			bool flat = Header.Flags.HasFlag(WallFlags.Flat);
			bool twoSides = Header.Flags.HasFlag(WallFlags.TwoSides);
			bool door = Header.Flags.HasFlag(WallFlags.Door);
			bool glass = Header.Flags.HasFlag(WallFlags.Glass);
			bool animation = ((Header.Effects >> 4) & 0x1) == 0x1;

			int offset = (2 + (!flat ? 4 : 0)) * (twoSides ? 2 : 1) * (door ? 2 : 1);
			int slopeRotation = (rotation % (twoSides ? 4 : 2)) * (door ? 2 : 1);
			if (slope >= 0 && !flat) {
				if (slope % 2 != rotation % 2) {
					if (slope >= 2) slopeRotation = (7 - slope) * (door ? 2 : 1);
					else slopeRotation = (3 - slope) * (door ? 2 : 1);
				}
			}

			DrawFrame(g, position, slopeRotation + frame * offset, rotation, slope);
			if (door)
				DrawFrame(g, position, slopeRotation + 1 + frame * offset, rotation, slope);
			if (glass)
				DrawFrame(g, position, offset + slopeRotation + frame * offset, rotation, slope, true);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			bool flat = Header.Flags.HasFlag(WallFlags.Flat);
			bool twoSides = Header.Flags.HasFlag(WallFlags.TwoSides);
			bool door = Header.Flags.HasFlag(WallFlags.Door);
			bool glass = Header.Flags.HasFlag(WallFlags.Glass);

			int offset = (2 + (!flat ? 4 : 0)) * (twoSides ? 2 : 1) * (door ? 2 : 1);
			int slopeRotation = (rotation % (twoSides ? 4 : 2)) * (door ? 2 : 1);

			DrawDialogFrame(g, position, slopeRotation, rotation);
			if (door)
				DrawDialogFrame(g, position, slopeRotation + 1, rotation);
			if (glass)
				DrawDialogFrame(g, position, offset + slopeRotation, rotation, true);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {

		graphicsData.PaletteImages[frame].Draw(g,
			position.X - imageDirectory.Entries[frame].Width / 2,
			position.Y - imageDirectory.Entries[frame].Height / 2,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(WallFlags.Color1) || Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(WallFlags.Color2) || Header.Flags.HasFlag(WallFlags.Color3)) ? GraphicsData.ColorRemap2 : -1,
			Header.Flags.HasFlag(WallFlags.Color3) ? GraphicsData.ColorRemap3 : -1
		);
		return true;
	}

	#endregion
	//--------------------------------
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
