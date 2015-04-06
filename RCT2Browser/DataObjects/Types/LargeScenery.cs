using RCTDataEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A large scenery object. </summary> */
public class LargeScenery : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x1A;

	#endregion
	//=========== SETTINGS ===========
	#region Settings

	/** <summary> True if large scenery should display the tile grid when drawing. </summary> */
	public static bool DrawTileGrid = false;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public LargeSceneryHeader Header;
	/** <summary> The 3D text data. </summary> */
	public List<byte> Text3D;
	/** <summary> The list of tile headers in the object. </summary> */
	public List<LargeSceneryTileHeader> Tiles;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public LargeScenery() : base() {
		this.Header	= new LargeSceneryHeader();
		this.Text3D	= new List<byte>();
		this.Tiles	= new List<LargeSceneryTileHeader>();
	}
	/** <summary> Constructs the default object. </summary> */
	public LargeScenery(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header	= new LargeSceneryHeader();
		this.Text3D	= new List<byte>();
		this.Tiles	= new List<LargeSceneryTileHeader>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			if (Header.Flags.HasFlag(LargeSceneryFlags.Text3D))
				return ObjectSubtypes.Text3D;
			if (Header.Flags.HasFlag(LargeSceneryFlags.TextScrolling))
				return ObjectSubtypes.TextScrolling;
			if (Header.Flags.HasFlag(LargeSceneryFlags.Photogenic))
				return ObjectSubtypes.Photogenic;
			return ObjectSubtypes.Basic;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return (Header.Flags.HasFlag(LargeSceneryFlags.Color2) ? 2 : (Header.Flags.HasFlag(LargeSceneryFlags.Color1) ? 1 : 0)); }
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

		// Read the 3D text
		if (Header.Flags.HasFlag(LargeSceneryFlags.Text3D)) {
			for (int i = 0; i < 0x40E; i++) {
				this.Text3D.Add(reader.ReadByte());
			}
		}
		// Read the tiles
		ushort flag = reader.ReadUInt16();
		while (flag != 0xFFFF) {
			reader.BaseStream.Position -= 2;
			LargeSceneryTileHeader tile = new LargeSceneryTileHeader();
			tile.Read(reader);
			this.Tiles.Add(tile);
			flag = reader.ReadUInt16();
		}

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

		// Write the 3D text
		if (Header.Flags.HasFlag(LargeSceneryFlags.Text3D)) {
			for (int i = 0; i < 0x40E; i++) {
				writer.Write(this.Text3D[i]);
			}
		}
		// Write the tiles
		for (int i = 0; i < this.Tiles.Count; i++) {
			this.Tiles[i].Write(writer);
		}
		writer.Write((ushort)0xFFFF);

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

	private void DrawFrame(Graphics g, Point position, int frame) {

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + imageDirectory.Entries[frame].XOffset,
			position.Y + imageDirectory.Entries[frame].YOffset,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(LargeSceneryFlags.Color1) || Header.Flags.HasFlag(LargeSceneryFlags.Color2)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(LargeSceneryFlags.Color2)) ? GraphicsData.ColorRemap2 : -1,
			-1
		);
	}
	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			LargeSceneryTileHeader[] tiles = new LargeSceneryTileHeader[Tiles.Count];
			Rectangle bounds = new Rectangle(100, 100, 0, 0);
			for (int i = 0; i < Tiles.Count; i++) {
				tiles[i] = Tiles[i];
				tiles[i].Row /= 32;
				tiles[i].Column /= 32;
				tiles[i].Index = i;
				switch (rotation) {
				case 0: tiles[i].Depth = (float)tiles[i].Row * 1.001f - (float)tiles[i].Column; break;
				case 1: tiles[i].Depth = (float)tiles[i].Row + (float)tiles[i].Column * 1.001f; break;
				case 2: tiles[i].Depth = (float)-tiles[i].Row * 1.001f - (float)tiles[i].Column; break;
				case 3: tiles[i].Depth = (float)-tiles[i].Row + (float)tiles[i].Column * 1.001f; break;
				}
				if (tiles[i].Row < bounds.X)	bounds.X = tiles[i].Row;
				if (tiles[i].Column < bounds.Y)	bounds.Y = tiles[i].Column;
				if (tiles[i].Row >= bounds.Width)		bounds.Width = tiles[i].Row + 1;
				if (tiles[i].Column >= bounds.Height)	bounds.Height = tiles[i].Column + 1;
			}

			// Insertion sort the tile depths
			for (int i = 1; i < tiles.Length; i++) {
				LargeSceneryTileHeader tile = tiles[i];
				int j;

				for (j = i - 1; j >= 0; j--) {
					if (tile.Depth >= tiles[j].Depth)
						break;
					tiles[j + 1] = tiles[j];
				}
				tiles[j + 1] = tile;
			}

			// Get tht tile corner
			Point cornerPos = Point.Empty;
			switch (rotation) {
			case 0: cornerPos = new Point(bounds.Width - 1, bounds.Y); break;
			case 1: cornerPos = new Point(bounds.Width - 1, bounds.Height - 1); break;
			case 2: cornerPos = new Point(bounds.X, bounds.Height - 1); break;
			case 3: cornerPos = new Point(bounds.X, bounds.Y); break;
			}

			// Draw each tile
			for (int i = 0; i < tiles.Length; i++) {
				int rot = (rotation % 2 == 0 ? -1 :  1);
				Point point = new Point(
					(Math.Abs(tiles[i].Row - cornerPos.X) * rot + Math.Abs(tiles[i].Column - cornerPos.Y) * -rot),
					(Math.Abs(tiles[i].Row - cornerPos.X) * -1 + Math.Abs(tiles[i].Column - cornerPos.Y) * -1)
				);

				DrawFrame(g, new Point(
					position.X + point.X * 32,
					position.Y + point.Y * 16
				), 4 + tiles[i].Index * 4 + (rotation + 3) % 4);
			}
			// Draw the tile overlay info
			if (DrawTileGrid) {
				for (int i = 0; i < tiles.Length; i++) {
					int rot = (rotation % 2 == 0 ? -1 :  1);
					Point point = new Point(
						(Math.Abs(tiles[i].Row - cornerPos.X) * rot + Math.Abs(tiles[i].Column - cornerPos.Y) * -rot),
						(Math.Abs(tiles[i].Row - cornerPos.X) * -1 + Math.Abs(tiles[i].Column - cornerPos.Y) * -1)
					);

					g.DrawImage(Resources.Selector, new Point(
						position.X + point.X * 32 - 32,
						position.Y + point.Y * 16
					));
					Font font = new Font("Courier", 10f, FontStyle.Bold);
					Brush brush = new SolidBrush(Color.Cyan);
					g.DrawString(tiles[i].Row.ToString(), font, brush, new Point(
						position.X + point.X * 32 + 12 - 32,
						position.Y + point.Y * 16 + 8
					));
					g.DrawString(tiles[i].Column.ToString(), font, brush, new Point(
						position.X + point.X * 32 + 36 - 32,
						position.Y + point.Y * 16 + 8
					));
					font.Dispose();
				}
			}
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			DrawFrame(g, new Point(
				position.X + 112 / 2,
				position.Y + (112 - 78) / 2
			), rotation);
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
			(Header.Flags.HasFlag(LargeSceneryFlags.Color1) || Header.Flags.HasFlag(LargeSceneryFlags.Color2)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(LargeSceneryFlags.Color2)) ? GraphicsData.ColorRemap2 : -1,
			-1
		);
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for large scenery objects. </summary> */
public class LargeSceneryHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Always zero in files. </summary> */
	public ushort Reserved0;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved1;
	/** <summary> The cursor to use when placing the object. </summary> */
	public byte Cursor;
	/** <summary> The flags used by the object. </summary> */
	public LargeSceneryFlags Flags;
	/** <summary> The cost to build the object. </summary> */
	public ushort BuildCost;
	/** <summary> The cost to remove the object. </summary> */
	public short RemoveCost;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved2;
	/** <summary> Always zero in files. </summary> */
	public byte Reserved3;
	/** <summary> 0xFF if not scrolling, otherwise, indicates scrolling direction, location. </summary> */
	public byte Scrolling;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved4;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved5;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public LargeSceneryHeader() {
		this.Reserved0 = 0;
		this.Reserved1 = 0;
		this.Cursor = 0;
		this.Flags = LargeSceneryFlags.None;
		this.BuildCost = 0;
		this.RemoveCost = 0;
		this.Reserved2 = 0;
		this.Reserved3 = 0;
		this.Scrolling = 0;
		this.Reserved4 = 0;
		this.Reserved5 = 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return LargeScenery.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			if (Flags.HasFlag(LargeSceneryFlags.Text3D))
				return ObjectSubtypes.Text3D;
			if (Flags.HasFlag(LargeSceneryFlags.TextScrolling))
				return ObjectSubtypes.TextScrolling;
			if (Flags.HasFlag(LargeSceneryFlags.Photogenic))
				return ObjectSubtypes.Photogenic;
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		LargeSceneryHeader header = new LargeSceneryHeader();
		header.Read(reader);
		if (header.Flags.HasFlag(LargeSceneryFlags.Text3D))
			return ObjectSubtypes.Text3D;
		if (header.Flags.HasFlag(LargeSceneryFlags.TextScrolling))
			return ObjectSubtypes.TextScrolling;
		if (header.Flags.HasFlag(LargeSceneryFlags.Photogenic))
			return ObjectSubtypes.Photogenic;
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
		this.Flags		= (LargeSceneryFlags)reader.ReadByte();
		this.BuildCost	= reader.ReadUInt16();
		this.RemoveCost	= reader.ReadInt16();
		this.Reserved2	= reader.ReadUInt32();
		this.Reserved3	= reader.ReadByte();
		this.Scrolling	= reader.ReadByte();
		this.Reserved4	= reader.ReadUInt32();
		this.Reserved5	= reader.ReadUInt32();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Reserved1);
		writer.Write(this.Cursor);
		writer.Write((byte)this.Flags);
		writer.Write(this.BuildCost);
		writer.Write(this.RemoveCost);
		writer.Write(this.Reserved2);
		writer.Write(this.Reserved3);
		writer.Write(this.Scrolling);
		writer.Write(this.Reserved4);
		writer.Write(this.Reserved5);
	}

	#endregion
}
/** <summary> The header used for large scenery tiles. </summary> */
public struct LargeSceneryTileHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The row index of the tile. </summary> */
	public short Row;
	/** <summary> The column index of the tile. </summary> */
	public short Column;
	/** <summary> The base height of the tile. </summary> */
	public short BaseHeight;
	/** <summary> The clearance  of the tile. </summary> */
	public byte Clearance;
	/** <summary> Bit 5 is set to indicate no supports. </summary> */
	public byte Unknown1;
	/** <summary> The flags used by the tile. </summary> */
	public LargeSceneryTileFlags Flags;

	/** <summary> The depth used for drawing tiles. </summary> */
	public float Depth;
	/** <summary> The index used for drawing tiles. </summary> */
	public int Index;

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the tile header. </summary> */
	public void Read(BinaryReader reader) {
		this.Row = reader.ReadInt16();
		this.Column = reader.ReadInt16();
		this.BaseHeight = reader.ReadInt16();
		this.Clearance = reader.ReadByte();
		this.Unknown1 = reader.ReadByte();
		this.Flags = (LargeSceneryTileFlags)reader.ReadByte();
	}
	/** <summary> Writes the tile header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Row);
		writer.Write(this.Column);
		writer.Write(this.BaseHeight);
		writer.Write(this.Clearance);
		writer.Write(this.Unknown1);
		writer.Write((byte)this.Flags);
	}

	#endregion
}
/** <summary> All flags usable with large scenery objects. </summary> */
[Flags]
public enum LargeSceneryFlags : byte {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,
	/** <summary> Uses the first remappable color. </summary> */
	Color1 = 0x00000001,
	/** <summary> Uses the second remappable color. </summary> */
	Color2 = 0x00000002,
	/** <summary> Uses 3D text as a sign. </summary> */
	Text3D = 0x00000004,
	/** <summary> Uses standard scrolling text technique. </summary> */
	TextScrolling = 0x00000008,
	/** <summary> Guests appreciate the scenery object (and photograph it). </summary> */
	Photogenic = 0x00000010,
}
/** <summary> All flags usable with large scenery tiles. </summary> */
[Flags]
public enum LargeSceneryTileFlags : byte {
	/** <summary> No flags are set. </summary> */
	None = 0x00,
	/** <summary> The north-west wall is placable. </summary> */
	WallNW = 0x01,
	/** <summary> The north-east wall is placable. </summary> */
	WallNE = 0x02,
	/** <summary> The south-east wall is placable. </summary> */
	WallSE = 0x04,
	/** <summary> The south-west wall is placable. </summary> */
	WallSW = 0x08,
	/** <summary> The east corner of the tile is occupied. </summary> */
	CornerE = 0x10,
	/** <summary> The south corner of the tile is occupied. </summary> */
	CornerS = 0x20,
	/** <summary> The west corner of the tile is occupied. </summary> */
	CornerW = 0x40,
	/** <summary> The north corner of the tile is occupied. </summary> */
	CornerN = 0x80,
}
}
