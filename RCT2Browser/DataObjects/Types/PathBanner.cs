using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A path banner scenery object. </summary> */
public class PathBanner : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0C;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public PathBannerHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public PathBanner() : base() {
		this.Header				= new PathBannerHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	public PathBanner(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new PathBannerHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			return ObjectSubtypes.TextScrolling;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return (Header.Flags.HasFlag(PathBannerFlags.Color1) ? 1 : 0); }
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
		groupInfo.Read(reader);

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
	}

	#endregion
	//--------------------------------
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			graphicsData.PaletteImages[rotation * 2 + 0].Draw(g,
				position.X + imageDirectory.Entries[rotation * 2 + 0].XOffset,
				position.Y + imageDirectory.Entries[rotation * 2 + 0].YOffset,
				Palette.DefaultPalette,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? GraphicsData.ColorRemap1 : -1,
				-1,
				-1
			);
			graphicsData.PaletteImages[rotation * 2 + 1].Draw(g,
				position.X + imageDirectory.Entries[rotation * 2 + 1].XOffset,
				position.Y + imageDirectory.Entries[rotation * 2 + 1].YOffset,
				Palette.DefaultPalette,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? GraphicsData.ColorRemap1 : -1,
				-1,
				-1
			);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			graphicsData.PaletteImages[rotation * 2 + 0].Draw(g,
				position.X + imageDirectory.Entries[rotation * 2 + 0].XOffset + 112 / 2,
				position.Y + imageDirectory.Entries[rotation * 2 + 0].YOffset + 112 / 2,
				Palette.DefaultPalette,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? GraphicsData.ColorRemap1 : -1,
				-1,
				-1
			);
			graphicsData.PaletteImages[rotation * 2 + 1].Draw(g,
				position.X + imageDirectory.Entries[rotation * 2 + 1].XOffset + 112 / 2,
				position.Y + imageDirectory.Entries[rotation * 2 + 1].YOffset + 112 / 2,
				Palette.DefaultPalette,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? GraphicsData.ColorRemap1 : -1,
				-1,
				-1
			);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + imageDirectory.Entries[frame].XOffset,
			position.Y + imageDirectory.Entries[frame].YOffset,
			Palette.DefaultPalette,
			Header.Flags.HasFlag(PathBannerFlags.Color1) ? GraphicsData.ColorRemap1 : -1,
			-1,
			-1
		);
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for path banner scenery objects. </summary> */
public class PathBannerHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Always zero in files. </summary> */
	public ushort Reserved0;
	/** <summary> Always zero in files. </summary> */
	public uint Reserved1;
	/** <summary> 0xFF if not scrolling, otherwise, indicates scrolling direction, location. </summary> */
	public byte Scrolling;
	/** <summary> The flags used by the object. </summary> */
	public PathBannerFlags Flags;
	/** <summary> X 10. refund is 75% (rounded down). </summary> */
	public ushort BuildCost;
	/** <summary> Always zero in files. </summary> */
	public ushort Reserved2;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public PathBannerHeader() {
		this.Reserved0	= 0;
		this.Reserved1	= 0;
		this.Scrolling	= 0;
		this.Flags		= PathBannerFlags.None;
		this.BuildCost	= 0;
		this.Reserved2	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return PathBanner.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.TextScrolling;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		PathBannerHeader header = new PathBannerHeader();
		header.Read(reader);
		return ObjectSubtypes.TextScrolling;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		this.Reserved0	= reader.ReadUInt16();
		this.Reserved1	= reader.ReadUInt32();
		this.Scrolling	= reader.ReadByte();
		this.Flags		= (PathBannerFlags)reader.ReadByte();
		this.BuildCost	= reader.ReadUInt16();
		this.Reserved2	= reader.ReadUInt16();
	}

	#endregion
}
/** <summary> All flags usable with path banner scenery objects. </summary> */
[Flags]
public enum PathBannerFlags : byte {
	/** <summary> No flags are set. </summary> */
	None = 0x00,
	/** <summary> Uses the first remappable color </summary> */
	Color1 = 0x01
}
}
