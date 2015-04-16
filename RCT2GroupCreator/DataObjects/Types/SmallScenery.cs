using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A small scenery object. </summary> */
public class SmallScenery : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x1C;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public SmallSceneryHeader Header;
	/** <summary> The index of each frame in the animation sequence. </summary> */
	public List<byte> AnimationSequence;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public SmallScenery() : base() {
		this.Header				= new SmallSceneryHeader();
		this.AnimationSequence	= new List<byte>();
	}
	/** <summary> Constructs the default object. </summary> */
	public SmallScenery(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new SmallSceneryHeader();
		this.AnimationSequence	= new List<byte>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			if (Header.Flags.HasFlag(SmallSceneryFlags.FountainSpray1) || Header.Flags.HasFlag(SmallSceneryFlags.FountainSpray4))
				return ObjectSubtypes.Fountain;
			if (Header.Flags.HasFlag(SmallSceneryFlags.Clock))
				return ObjectSubtypes.Clock;
			if (Header.Flags.HasFlag(SmallSceneryFlags.GardenWither) || Header.Flags.HasFlag(SmallSceneryFlags.GardenWater))
				return ObjectSubtypes.Garden;
			if (Header.Flags.HasFlag(SmallSceneryFlags.Animation) || Header.Flags.HasFlag(SmallSceneryFlags.SwampGoo))
				return ObjectSubtypes.Animation;
			if (Header.Flags.HasFlag(SmallSceneryFlags.Glass))
				return ObjectSubtypes.Glass;
			return ObjectSubtypes.Basic;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return (Header.Flags.HasFlag(SmallSceneryFlags.Color2) ? 2 : (Header.Flags.HasFlag(SmallSceneryFlags.Color1) ? 1 : 0)); }
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

		// Animation sequence
		if (Header.Flags.HasFlag(SmallSceneryFlags.AnimationData)) {
			byte b = reader.ReadByte();

			while (b != 0xFF) {
				AnimationSequence.Add(b);
				b = reader.ReadByte();
			}
		}

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

		// Animation sequence
		if (Header.Flags.HasFlag(SmallSceneryFlags.AnimationData)) {
			for (int i = 0; i < this.AnimationSequence.Count; i++) {
				writer.Write(this.AnimationSequence[i]);
			}
			writer.Write((byte)0xFF);
		}

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

	private void DrawFrame(Graphics g, Point position, int frame, int corner, bool glass = false) {
		bool offset = Header.Flags.HasFlag(SmallSceneryFlags.Offset);
		bool fullSquare = Header.Flags.HasFlag(SmallSceneryFlags.FullSquare);
		bool half = Header.Flags.HasFlag(SmallSceneryFlags.HalfSpace);
		bool threeFourths = Header.Flags.HasFlag(SmallSceneryFlags.ThreeFourthsSpace);
		int cornerX = 0, cornerY = 0;
		switch (corner) {
		case 0: cornerX = -16; cornerY = 0; break;
		case 1: cornerX = 0; cornerY = -8; break;
		case 2: cornerX = 16; cornerY = 0; break;
		case 3: cornerX = 0; cornerY = 8; break;
		}

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + (fullSquare ? 0 : cornerX) + (offset ? 0 : 0) + (half ? 0 : 0) + imageDirectory.Entries[frame].XOffset,
			position.Y + (fullSquare ? 0 : cornerY) + (offset ? (!fullSquare ? 13 : 0) + (half ? 11 : 0) + 3 : 16) + (half ? -12 : 0) + imageDirectory.Entries[frame].YOffset,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(SmallSceneryFlags.Color1) || Header.Flags.HasFlag(SmallSceneryFlags.Color2)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(SmallSceneryFlags.Color2) || (Header.Flags.HasFlag(SmallSceneryFlags.Color1) && glass)) ? (glass ? GraphicsData.ColorRemap1 : GraphicsData.ColorRemap2) : -1,
			-1
		);
	}
	private void DrawDialogFrame(Graphics g, Point position, int frame, int corner, bool glass = false) {
		bool offset = Header.Flags.HasFlag(SmallSceneryFlags.Offset);
		bool fullSquare = Header.Flags.HasFlag(SmallSceneryFlags.FullSquare);
		bool half = Header.Flags.HasFlag(SmallSceneryFlags.HalfSpace);
		bool threeFourths = Header.Flags.HasFlag(SmallSceneryFlags.ThreeFourthsSpace);
		int cornerX = 0, cornerY = 0;
		switch (corner) {
		case 0: cornerX = -16; cornerY = 0; break;
		case 1: cornerX = 0; cornerY = -8; break;
		case 2: cornerX = 16; cornerY = 0; break;
		case 3: cornerX = 0; cornerY = 8; break;
		}

		graphicsData.PaletteImages[frame].Draw(g,
			position.X + (fullSquare ? 0 : cornerX) + (offset ? 0 : 0) + (half ? 0 : 0) + imageDirectory.Entries[frame].XOffset + 112 / 2,
			position.Y + (fullSquare ? 0 : cornerY) + (offset ? (!fullSquare ? 13 : 0) + (half ? 11 : 0) + 3 : 16) + (half ? -12 : 0) + imageDirectory.Entries[frame].YOffset + 112 / 2,
			Palette.DefaultPalette,
			(Header.Flags.HasFlag(SmallSceneryFlags.Color1) || Header.Flags.HasFlag(SmallSceneryFlags.Color2)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(SmallSceneryFlags.Color2) || (Header.Flags.HasFlag(SmallSceneryFlags.Color1) && glass)) ? (glass ? GraphicsData.ColorRemap1 : GraphicsData.ColorRemap2) : -1,
			-1
		);
	}
	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			bool fullSquare = Header.Flags.HasFlag(SmallSceneryFlags.FullSquare);
			bool drawMain2 = Header.Flags.HasFlag(SmallSceneryFlags.DrawMainTwo);
			bool dialogFrames = Header.Flags.HasFlag(SmallSceneryFlags.DialogFrames);
			bool glass = Header.Flags.HasFlag(SmallSceneryFlags.Glass);
			bool spray1 = Header.Flags.HasFlag(SmallSceneryFlags.FountainSpray1);
			bool spray4 = Header.Flags.HasFlag(SmallSceneryFlags.FountainSpray4);
			bool clock = Header.Flags.HasFlag(SmallSceneryFlags.Clock);
			bool animation = Header.Flags.HasFlag(SmallSceneryFlags.Animation);

			int offset = (dialogFrames ? 4 : 0);

			if (spray1) {
				DrawFrame(g, position, offset + rotation, corner);
				DrawFrame(g, position, offset + 4 + rotation + frame * 4, corner);
			}
			else if (spray4) {
				DrawFrame(g, position, offset + rotation, corner);
				DrawFrame(g, position, offset + 8 + rotation + frame * 4, corner);
				DrawFrame(g, position, offset + 4 + rotation, corner);
				DrawFrame(g, position, offset + 24 + rotation + frame * 4, corner);
			}
			else if (clock) {
				DrawFrame(g, position, offset + rotation, corner);
				DrawFrame(g, position, offset + 68 + (frame / 15 + rotation * 12) % 48, corner);
				DrawFrame(g, position, offset + 8 + (frame % 60 + rotation * 15) % 60, corner);
			}
			else {
				DrawFrame(g, position, offset + rotation + frame * 4, corner);
				if (drawMain2)
					DrawFrame(g, position, offset + 4 + rotation + frame * 4, corner);
				else if (glass)
					DrawFrame(g, position, offset + 4 + rotation + frame * 4, corner, true);
			}
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			bool fullSquare = Header.Flags.HasFlag(SmallSceneryFlags.FullSquare);
			bool drawDialog2 = Header.Flags.HasFlag(SmallSceneryFlags.DrawDialogTwo);
			bool glass = Header.Flags.HasFlag(SmallSceneryFlags.Glass);

			DrawDialogFrame(g, position, rotation, -1);
			if (drawDialog2)
				DrawDialogFrame(g, position, 4 + rotation, -1);
			else if (glass)
				DrawDialogFrame(g, position, 4 + rotation, -1, true);
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
			(Header.Flags.HasFlag(SmallSceneryFlags.Color1) || Header.Flags.HasFlag(SmallSceneryFlags.Color2)) ? GraphicsData.ColorRemap1 : -1,
			(Header.Flags.HasFlag(SmallSceneryFlags.Color2)) ? GraphicsData.ColorRemap2 : -1,
			-1
		);
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for small scenery objects. </summary> */
public class SmallSceneryHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Unknown. </summary> */
	public ushort MessageRef;
	/** <summary> Unknown. </summary> */
	public uint Fill1;
	/** <summary> The flags used by the object. </summary> */
	public SmallSceneryFlags Flags;
	/** <summary> The height of the object. </summary> */
	public byte Height;
	/** <summary> The cursor to use when placing the object. </summary> */
	public byte Cursor;
	/** <summary> The cost to build the object. </summary> */
	public short BuildCost;
	/** <summary> The cost to remove the object. </summary> */
	public short RemoveCost;
	/** <summary> Zero in data files. </summary> */
	public uint GraphicsStart;
	/** <summary> Delay between individual frames of animation - controls speed </summary> */
	public ushort Animation1;
	/** <summary> Delay between individual frames of animation - controls speed
	 * <para>bits0..4: animation counter mask (ie. sequence length - 1)</para>
	 * <para>bit 5: 0=continuous animation (sequence length should be a power of 2)</para>
	 * <para>bit 5: 1=intermittent; bits 6 and up indicate interval length</para>
	 * </summary> */
	public ushort Animation2;
	/** <summary> Length of animation sequence (limit to 0x80) </summary> */
	public ushort Animation3;
	/** <summary> Zero in data files. </summary> */
	public byte BaseIndex;
	/** <summary> Zero in data files. </summary> */
	public byte Fill2;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public SmallSceneryHeader() {
		this.MessageRef = 0;
		this.Fill1 = 0;
		this.Flags = SmallSceneryFlags.None;
		this.Height = 0;
		this.Cursor = 0;
		this.BuildCost = 0;
		this.RemoveCost = 0;
		this.GraphicsStart = 0;
		this.Animation1 = 0;
		this.Animation2 = 0;
		this.Animation3 = 0;
		this.BaseIndex = 0;
		this.Fill2 = 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return SmallScenery.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			if (Flags.HasFlag(SmallSceneryFlags.FountainSpray1) || Flags.HasFlag(SmallSceneryFlags.FountainSpray4))
				return ObjectSubtypes.Fountain;
			if (Flags.HasFlag(SmallSceneryFlags.Clock))
				return ObjectSubtypes.Clock;
			if (Flags.HasFlag(SmallSceneryFlags.GardenWither) || Flags.HasFlag(SmallSceneryFlags.GardenWater))
				return ObjectSubtypes.Garden;
			if (Flags.HasFlag(SmallSceneryFlags.Animation) || Flags.HasFlag(SmallSceneryFlags.SwampGoo))
				return ObjectSubtypes.Animation;
			if (Flags.HasFlag(SmallSceneryFlags.Glass))
				return ObjectSubtypes.Glass;
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		SmallSceneryHeader header = new SmallSceneryHeader();
		header.Read(reader);
		if (header.Flags.HasFlag(SmallSceneryFlags.FountainSpray1) || header.Flags.HasFlag(SmallSceneryFlags.FountainSpray4))
			return ObjectSubtypes.Fountain;
		if (header.Flags.HasFlag(SmallSceneryFlags.Clock))
			return ObjectSubtypes.Clock;
		if (header.Flags.HasFlag(SmallSceneryFlags.GardenWither) || header.Flags.HasFlag(SmallSceneryFlags.GardenWater))
			return ObjectSubtypes.Garden;
		if (header.Flags.HasFlag(SmallSceneryFlags.Animation) || header.Flags.HasFlag(SmallSceneryFlags.SwampGoo))
			return ObjectSubtypes.Animation;
		if (header.Flags.HasFlag(SmallSceneryFlags.Glass))
			return ObjectSubtypes.Glass;
		return ObjectSubtypes.Basic;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		MessageRef = reader.ReadUInt16();
		Fill1 = reader.ReadUInt32();
		Flags = (SmallSceneryFlags)reader.ReadUInt32();
		Height = reader.ReadByte();
		Cursor = reader.ReadByte();
		BuildCost = reader.ReadInt16();
		RemoveCost = reader.ReadInt16();
		GraphicsStart = reader.ReadUInt32();
		Animation1 = reader.ReadUInt16();
		Animation2 = reader.ReadUInt16();
		Animation3 = reader.ReadUInt16();
		BaseIndex = reader.ReadByte();
		Fill2 = reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	public override void Write(BinaryWriter writer) {
		writer.Write(this.MessageRef);
		writer.Write(this.Fill1);
		writer.Write((uint)this.Flags);
		writer.Write(this.Height);
		writer.Write(this.Cursor);
		writer.Write(this.BuildCost);
		writer.Write(this.RemoveCost);
		writer.Write(this.GraphicsStart);
		writer.Write(this.Animation1);
		writer.Write(this.Animation2);
		writer.Write(this.Animation3);
		writer.Write(this.BaseIndex);
		writer.Write(this.Fill2);
	}

	#endregion
}
/** <summary> All flags usable with small scenery objects. </summary> */
[Flags]
public enum SmallSceneryFlags : uint {
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
