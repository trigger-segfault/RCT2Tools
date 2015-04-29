using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
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
	internal PathBanner(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new PathBannerHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Reading

	/** <summary> Gets the number of string table entries in the object. </summary> */
	protected override int NumStringTableEntries {
		get { return 1; }
	}
	/** <summary> Returns true if the object has a group info section. </summary> */
	protected override bool HasGroupInfo {
		get { return true; }
	}

	#endregion
	//--------------------------------
	#region Information

	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get { return ObjectSubtypes.TextScrolling; }
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return (Header.Flags.HasFlag(PathBannerFlags.Color1) ? 1 : 0); }
	}
	/** <summary> Gets if the dialog view has color remaps. </summary> */
	public override bool HasDialogColorRemaps {
		get { return true; }
	}
	/** <summary> Gets the number of frames in the animation. </summary> */
	public override int AnimationFrames {
		get { return 1; }
	}

	#endregion
	//--------------------------------
	#endregion
	//=========== READING ============
	#region Reading
	
	/** <summary> Reads the object header. </summary> */
	protected override void ReadHeader(BinaryReader reader) {
		Header.Read(reader);
	}
	/** <summary> Writes the object. </summary> */
	protected override void WriteHeader(BinaryWriter writer) {
		Header.Write(writer);
	}
	
	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
		try {
			graphicsData.paletteImages[drawSettings.Rotation * 2 + 0].DrawWithOffset(p, position, drawSettings.Darkness, false,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? drawSettings.Remap1 : RemapColors.None,
				RemapColors.None,
				RemapColors.None
			);
			graphicsData.paletteImages[drawSettings.Rotation * 2 + 1].DrawWithOffset(p, position, drawSettings.Darkness, false,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? drawSettings.Remap1 : RemapColors.None,
				RemapColors.None,
				RemapColors.None
			);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(PaletteImage p, Point position, Size dialogSize, DrawSettings drawSettings) {
		try {
			position = Point.Add(position, new Size(dialogSize.Width / 2, dialogSize.Height / 2));
			graphicsData.paletteImages[drawSettings.Rotation * 2 + 0].DrawWithOffset(p, position, drawSettings.Darkness, false,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? drawSettings.Remap1 : RemapColors.None,
				RemapColors.None,
				RemapColors.None
			);
			graphicsData.paletteImages[drawSettings.Rotation * 2 + 1].DrawWithOffset(p, position, drawSettings.Darkness, false,
				Header.Flags.HasFlag(PathBannerFlags.Color1) ? drawSettings.Remap1 : RemapColors.None,
				RemapColors.None,
				RemapColors.None
			);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	
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
	internal override uint HeaderSize {
		get { return PathBanner.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	internal override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.TextScrolling;
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	internal override void Read(BinaryReader reader) {
		this.Reserved0	= reader.ReadUInt16();
		this.Reserved1	= reader.ReadUInt32();
		this.Scrolling	= reader.ReadByte();
		this.Flags		= (PathBannerFlags)reader.ReadByte();
		this.BuildCost	= reader.ReadUInt16();
		this.Reserved2	= reader.ReadUInt16();
	}
	/** <summary> Writes the object header. </summary> */
	internal override void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Reserved1);
		writer.Write(this.Scrolling);
		writer.Write((byte)this.Flags);
		writer.Write(this.BuildCost);
		writer.Write(this.Reserved2);
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
