using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A small scenery object. </summary> */
public class ParkEntrance : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x08;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public ParkEntranceHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public ParkEntrance() : base() {
		this.Header				= new ParkEntranceHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	internal ParkEntrance(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new ParkEntranceHeader();
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
		get { return false; }
	}

	#endregion
	//--------------------------------
	#region Information
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get { return ObjectSubtypes.Entrance; }
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return 0; }
	}
	/** <summary> Gets if the dialog view has color remaps. </summary> */
	public override bool HasDialogColorRemaps {
		get { return false; }
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
			int xoffset = ((drawSettings.Rotation == 1 || drawSettings.Rotation == 2) ? -32 : 32);
			int yoffset = ((drawSettings.Rotation == 2 || drawSettings.Rotation == 3) ? -16 : 16);
			if (drawSettings.Rotation >= 2) { xoffset *= -1; yoffset *= -1; }
			int sideFrame = (drawSettings.Rotation < 2 ? 0 : 1);

			graphicsData.paletteImages[drawSettings.Rotation * 3 + 1 + sideFrame].DrawWithOffset(p,
				Point.Add(position, new Size(-xoffset, -yoffset)), drawSettings.Darkness, false);
			graphicsData.paletteImages[drawSettings.Rotation * 3 + 0].DrawWithOffset(p,
				position, drawSettings.Darkness, false);
			graphicsData.paletteImages[drawSettings.Rotation * 3 + 2 - sideFrame].DrawWithOffset(p,
				Point.Add(position, new Size(xoffset, yoffset)), drawSettings.Darkness, false);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(PaletteImage p, Point position, Size dialogSize, DrawSettings drawSettings) {
		try {
			position = Point.Add(position, new Size(dialogSize.Width / 2, dialogSize.Height / 2));
			int xoffset = ((drawSettings.Rotation == 1 || drawSettings.Rotation == 2) ? -32 : 32);
			int yoffset = ((drawSettings.Rotation == 2 || drawSettings.Rotation == 3) ? -16 : 16);
			if (drawSettings.Rotation >= 2) { xoffset *= -1; yoffset *= -1; }
			int sideFrame = (drawSettings.Rotation < 2 ? 0 : 1);

			graphicsData.paletteImages[drawSettings.Rotation * 3 + 1 + sideFrame].DrawWithOffset(p,
				Point.Add(position, new Size(-xoffset, -yoffset)), drawSettings.Darkness, false);
			graphicsData.paletteImages[drawSettings.Rotation * 3 + 0].DrawWithOffset(p,
				position, drawSettings.Darkness, false);
			graphicsData.paletteImages[drawSettings.Rotation * 3 + 2 - sideFrame].DrawWithOffset(p,
				Point.Add(position, new Size(xoffset, yoffset)), drawSettings.Darkness, false);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}

	#endregion
}
/** <summary> The header used for small scenery objects. </summary> */
public class ParkEntranceHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Six bytes of data that are always zero in dat files. </summary> */
	public byte[] Reserved;
	/** <summary> The x position of the sign text. </summary> */
	public byte SignX;
	/** <summary> The y position of the sign text. </summary> */
	public byte SignY;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public ParkEntranceHeader() {
		this.Reserved = new byte[6];
		this.SignX	= 0;
		this.SignY	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	internal override uint HeaderSize {
		get { return ParkEntrance.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	internal override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Entrance;
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	internal override void Read(BinaryReader reader) {
		reader.Read(this.Reserved, 0, this.Reserved.Length);
		this.SignX	= reader.ReadByte();
		this.SignY	= reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	internal override void Write(BinaryWriter writer) {
		writer.Write(this.Reserved);
		writer.Write(this.SignX);
		writer.Write(this.SignY);
	}

	#endregion
}
}
