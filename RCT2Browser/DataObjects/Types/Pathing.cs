using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A small scenery object. </summary> */
public class Pathing : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0E;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public PathingHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public Pathing() : base() {
		this.Header				= new PathingHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	public Pathing(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
			this.Header				= new PathingHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
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

	/** <summary> Constructs the default object. </summary> */
	public override void Read(BinaryReader reader) {
		Header.Read(reader);

		stringTable.Read(reader);

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
	}

	#endregion
	//--------------------------------
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			g.DrawImage(graphicsData.Images[0], new Point(
				position.X + imageDirectory.Entries[0].XOffset,
				position.Y + imageDirectory.Entries[0].YOffset
			));
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			g.DrawImage(graphicsData.Images[71], new Point(
				position.X + imageDirectory.Entries[71].XOffset + 112 / 2 - 4 - 44,
				position.Y + imageDirectory.Entries[71].YOffset + (112 - 33) / 2
			));
			g.DrawImage(graphicsData.Images[72], new Point(
				position.X + imageDirectory.Entries[72].XOffset + 112 / 2 + 4,
				position.Y + imageDirectory.Entries[72].YOffset + (112 - 33) / 2
			));
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
/** <summary> The header used for small scenery objects. </summary> */
public class PathingHeader : ObjectTypeHeader {

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
	public PathingHeader() {
		this.BytePositions	= new List<uint>();
		this.NonZeroBytes	= new List<byte>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return Pathing.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		PathingHeader header = new PathingHeader();
		header.Read(reader);
		return ObjectSubtypes.Basic;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		for (int i = 0; i < Pathing.HeaderSize; i++) {
			byte b = reader.ReadByte();
			if (b != 0x00) {
				this.BytePositions.Add((uint)i);
				this.NonZeroBytes.Add(b);
			}
		}
	}

	#endregion
}
/** <summary> All flags usable with small scenery objects. </summary> */
[Flags]
public enum PathingFlags : uint {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,
	/** <summary> Full square tile (else: a quarter tile object). </summary> */
	FullSquare = 0x00000001,
	/** <summary> Image vertical reference is based on the center of the tile (else: it is based on the top of the tile) </summary> */
	Offset = 0x00000002,
	/** <summary> Must be on a flat surface. Also, walls can't occupy the same tile </summary> */
	Flat = 0x00000004,
	/** <summary> Provide a rotation button in the scenery dialog </summary> */
	Rotatable = 0x00000008,
	/** <summary> Animated object = multiple frames and animation sequence present </summary> */
	Animation = 0x00000010,
	/** <summary> Garden draw logic - three frames which progress over time without water (wither) </summary> */
	GardenWither = 0x00000020,
	/** <summary> Garden draw logic - the frames can regress with water (allows handymen to water them) </summary> */
	GardenWater = 0x00000040,
	/** <summary> Combine the first 2 frames when drawing the item in the scenery dialog </summary> */
	DrawDialogTwo = 0x00000080,
	/** <summary> Diagonal object - check ThreeFourthsSpace </summary> */
	DiagonalSpace = 0x00000100,
	/** <summary> A "glass" object: the first image is the "frame" and the second image is the "glass" </summary> */
	Glass = 0x00000200,
	/** <summary> Uses the first remappable color </summary> */
	Color1 = 0x00000400,
	/** <summary> Use fountain drawing logic = 2 frames: the first frame is stationary and the second is animated </summary> */
	FountainSpray1 = 0x00000800,
	/** <summary> Use fountain/4 drawing logic = the first frame is stationary; there are "back" and "front" animations (for 4 fountain sprays) </summary> */
	FountainSpray4 = 0x00001000,
	/** <summary> Use clock drawing logic = the first frame is stationary; there are two animations (the hands of the clock - which are timed to real time) </summary> */
	Clock = 0x00002000,
	/** <summary> Use the same image for all 4 views; plus animate 16 frames </summary> */
	SwampGoo = 0x00004000,
	/** <summary> Has animation sequence data (a sequence after the "Group Info") </summary> */
	AnimationData = 0x00008000,
	/** <summary> This specifies that the object should use 2 frames instead of 1 for the object on the main game screen </summary> */
	DrawMainTwo = 0x00010000,
	/** <summary> Can be stacked and/or placed on water (e.g. trees dont have this bit set) </summary> */
	Stack = 0x00020000,
	/** <summary> Specifies that no walls may be built at the same location as this object (can be built below and above) </summary> */
	NoWalls = 0x00040000,
	/** <summary> Uses the second remappable color </summary> */
	Color2 = 0x00080000,
	/** <summary> No supports - useful for "building" components: walls/roofs, etc </summary> */
	NoSupports = 0x00100000,
	/** <summary> First set of frames are only for the scenery dialog </summary> */
	DialogFrames = 0x00200000,
	/** <summary> ? - only used for the small cogwheel </summary> */
	SmallCog = 0x00400000,
	/** <summary> ? - unknown </summary> */
	Unknown = 0x00800000,
	/** <summary> Occupies half of a tile </summary> */
	HalfSpace = 0x01000000,
	/** <summary> Occupies 3/4 of a tile - T1_SPACEA must be set also </summary> */
	ThreeFourthsSpace = 0x02000000,
	/** <summary> Supports are painted with the first remappable color (else they are painted black) </summary> */
	PaintSupports = 0x04000000,
	/** <summary> ? - only used for suppleg1.dat </summary> */
	Pole = 0x08000000
}
}
