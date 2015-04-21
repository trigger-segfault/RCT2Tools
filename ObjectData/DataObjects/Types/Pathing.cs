using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A small scenery object. </summary> */
public class Pathing : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x0E;

	/** <summary> The index of each path sprite depending on certain straights and corners connecting. </summary> */
	public static Dictionary<uint, int> PathSpriteIndexes = new Dictionary<uint, int>();


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
	internal Pathing(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
			this.Header				= new PathingHeader();
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
		get { return ObjectSubtypes.Basic; }
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return true; }
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

	/** <summary> Draws the path railing. </summary> */
	public void DrawRailing(PaletteImage p, Point position, DrawSettings drawSettings, uint pathConnections) {
		int offset = (drawSettings.Queue ? 51 : 0);
		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections) && !(drawSettings.Elevation > 0 && !Header.Flags.HasFlag(PathingFlags.OverlayPath))) {
			connection = Pathing.PathSpriteIndexes[pathConnections];
		}
		else if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			pathConnections &= 0xF;
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}

		if (drawSettings.Slope == -1) {
			if (drawSettings.Queue)
				offset = 87;
			else if (drawSettings.Elevation > 0)
				offset = 73;

			if (drawSettings.Queue || drawSettings.Elevation > 0) {
				if (CheckConnections(pathConnections, "####00#1")) {
					graphicsData.paletteImages[offset + 3].DrawWithOffset(p, Point.Add(position, new Size(4, 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "#####001")) {
					graphicsData.paletteImages[offset + 3].DrawWithOffset(p, Point.Add(position, new Size(32 - 4, 16 - 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####0#10")) {
					graphicsData.paletteImages[offset + 4].DrawWithOffset(p, Point.Add(position, new Size(-4, 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####001#")) {
					graphicsData.paletteImages[offset + 4].DrawWithOffset(p, Point.Add(position, new Size(-32 + 4, 16 - 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "#####100")) {
					graphicsData.paletteImages[offset + 5].DrawWithOffset(p, Point.Add(position, new Size(32 - 4, 16 - 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####01#0")) {
					graphicsData.paletteImages[offset + 5].DrawWithOffset(p, Point.Add(position, new Size(4, 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####100#")) {
					graphicsData.paletteImages[offset + 2].DrawWithOffset(p, Point.Add(position, new Size(-32 + 4, 16 - 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####1#00")) {
					graphicsData.paletteImages[offset + 2].DrawWithOffset(p, Point.Add(position, new Size(-4, 2)), drawSettings.Darkness, false);
				}

				if (CheckConnections(pathConnections, "####01#1")) {
					graphicsData.paletteImages[offset + 1].DrawWithOffset(p, Point.Add(position, new Size(4, 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "#####101")) {
					graphicsData.paletteImages[offset + 1].DrawWithOffset(p, Point.Add(position, new Size(32 - 4, 16 - 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####1#10")) {
					graphicsData.paletteImages[offset + 0].DrawWithOffset(p, Point.Add(position, new Size(-4, 2)), drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "####101#")) {
					graphicsData.paletteImages[offset + 0].DrawWithOffset(p, Point.Add(position, new Size(-32 + 4, 16 - 2)), drawSettings.Darkness, false);
				}

				if (CheckConnections(pathConnections, "###0##11")) {
					graphicsData.paletteImages[offset + 11].DrawWithOffset(p, position, drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "##0##11#")) {
					graphicsData.paletteImages[offset + 12].DrawWithOffset(p, position, drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "#0##11##")) {
					graphicsData.paletteImages[offset + 13].DrawWithOffset(p, position, drawSettings.Darkness, false);
				}
				if (CheckConnections(pathConnections, "0###1##1")) {
					graphicsData.paletteImages[offset + 10].DrawWithOffset(p, position, drawSettings.Darkness, false);
				}
			}
		}
		else {
			if (drawSettings.Queue)
				offset = 87;
			else
				offset = 73;

			switch (drawSettings.Slope) {
			case 0:
				graphicsData.paletteImages[offset + 6].DrawWithOffset(p, Point.Add(position, new Size(-4, 2)), drawSettings.Darkness, false);
				graphicsData.paletteImages[offset + 6].DrawWithOffset(p, Point.Add(position, new Size(-32 + 4, 16 - 2)), drawSettings.Darkness, false);
				break;
			case 1:
				graphicsData.paletteImages[offset + 8].DrawWithOffset(p, Point.Add(position, new Size(4, 2)), drawSettings.Darkness, false);
				graphicsData.paletteImages[offset + 8].DrawWithOffset(p, Point.Add(position, new Size(32 - 4, 16 - 2)), drawSettings.Darkness, false);
				break;
			case 2:
				graphicsData.paletteImages[offset + 7].DrawWithOffset(p, Point.Add(position, new Size(-4, 2)), drawSettings.Darkness, false);
				graphicsData.paletteImages[offset + 7].DrawWithOffset(p, Point.Add(position, new Size(-32 + 4, 16 - 2)), drawSettings.Darkness, false);
				break;
			case 3:
				graphicsData.paletteImages[offset + 9].DrawWithOffset(p, Point.Add(position, new Size(4, 2)), drawSettings.Darkness, false);
				graphicsData.paletteImages[offset + 9].DrawWithOffset(p, Point.Add(position, new Size(32 - 4, 16 - 2)), drawSettings.Darkness, false);
				break;
			}
		}
	}
	/** <summary> Draws the path pole supports. </summary> */
	public void DrawPoleSupport(PaletteImage p, Point position, DrawSettings drawSettings) {
		position.Y += drawSettings.Elevation * 2;
		if (drawSettings.Slope != -1)
			position.Y -= drawSettings.Elevation / 2;
		int offset = 129;
		while (drawSettings.Elevation > 8) {
			graphicsData.paletteImages[offset + 15].DrawWithOffset(p,
				position, drawSettings.Darkness, false);
			drawSettings.Elevation -= 8;
			position.Y += 16;
		}
		if (Header.Flags.HasFlag(PathingFlags.PoleBase)) {
			position.Y -= 6;
			graphicsData.paletteImages[offset + 9].DrawWithOffset(p,
				position, drawSettings.Darkness, false);
			int slopeOffset = 17;
			switch (drawSettings.Slope) {
			case 0: slopeOffset = 19; break;
			case 1: slopeOffset = 25; break;
			case 2: slopeOffset = 26; break;
			case 3: slopeOffset = 20; break;
			}
			graphicsData.paletteImages[offset + slopeOffset].DrawWithOffset(p,
				Point.Add(position, new Size(0, 6)), drawSettings.Darkness, false);
		}
		else {
			graphicsData.paletteImages[offset + 15].DrawWithOffset(p,
				position, drawSettings.Darkness, false);
		}
	}
	/** <summary> Draws the path scaffold supports. </summary> */
	public void DrawScaffoldSupport(PaletteImage p, Point position, DrawSettings drawSettings, int rotation) {
		int offset = 109;

		if (drawSettings.Slope == -1) {
			graphicsData.paletteImages[offset + (rotation % 2 == 0 ? 46 : 22)].DrawWithOffset(p,
				Point.Add(position, new Size(12, 32 - 6)), drawSettings.Darkness, false);
		}
		else {
			int offset2 = 0;
			switch (drawSettings.Slope) {
			case 0: offset2 = 5; break;
			case 1: offset2 = 11; break;
			case 2: offset2 = 8; break;
			case 3: offset2 = 2; break;
			}
			graphicsData.paletteImages[offset + (drawSettings.Slope % 2 == 0 ? 24 : 0) + offset2].DrawWithOffset(p,
				Point.Add(position, new Size(12, 32 - 6)), drawSettings.Darkness, false);
			graphicsData.paletteImages[offset + (drawSettings.Slope % 2 == 0 ? 47 : 23)].DrawWithOffset(p,
				Point.Add(position, new Size(12, 16 - 6)), drawSettings.Darkness, false);
			offset = 164;
			graphicsData.paletteImages[offset + (drawSettings.Slope + 3) % 4].DrawWithOffset(p,
				Point.Add(position, new Size(12, -6)), drawSettings.Darkness, false);
		}
	}
	/** <summary> Draws the path supports. </summary> */
	public void DrawSupports(PaletteImage p, Point position, DrawSettings drawSettings, int rotation, uint pathConnections) {
		if (drawSettings.Elevation == 0)
			return;

		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}
		if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
			if (CheckConnections(pathConnections, "#######0"))
				DrawPoleSupport(p, Point.Add(position, new Size(12, -6)), drawSettings);
			if (CheckConnections(pathConnections, "####0###"))
				DrawPoleSupport(p, Point.Add(position, new Size(-12, -6)), drawSettings);
			if (CheckConnections(pathConnections, "######0#"))
				DrawPoleSupport(p, Point.Add(position, new Size(12, 6)), drawSettings);
			if (CheckConnections(pathConnections, "#####0##"))
				DrawPoleSupport(p, Point.Add(position, new Size(-12, 6)), drawSettings);
		}
		else {
			DrawScaffoldSupport(p, Point.Add(position, new Size(-12, 6)), drawSettings, rotation);
		}
	}
	/** <summary> Draws the elevated path. </summary> */
	public void DrawElevatedPath(PaletteImage p, Point position, DrawSettings drawSettings, int rotation, uint pathConnections) {
		if (drawSettings.Elevation == 0)
			return;

		int offset = 109;
		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}

		if (drawSettings.Slope == -1) {
			if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
				graphicsData.paletteImages[offset + connection].DrawWithOffset(p, position, drawSettings.Darkness, false);
			}
			else {
				offset = 158;
				graphicsData.paletteImages[offset + ((rotation + 1) % 2)].DrawWithOffset(p, position, drawSettings.Darkness, false);
			}
		}
		else {
			if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
				graphicsData.paletteImages[offset + 16 + (drawSettings.Slope + 3) % 4].DrawWithOffset(p, position, drawSettings.Darkness, false);
			}
			else {
				offset = 158;
				graphicsData.paletteImages[offset + 2 + (drawSettings.Slope + 3) % 4].DrawWithOffset(p, position, drawSettings.Darkness, false);
			}
		}
	}
	/** <summary> Draws the path base. </summary> */
	public void DrawPath(PaletteImage p, Point position, DrawSettings drawSettings, uint pathConnections) {
		if (drawSettings.Elevation > 0 && !Header.Flags.HasFlag(PathingFlags.OverlayPath))
			return;

		int offset = (drawSettings.Queue ? 51 : 0);

		if (drawSettings.Slope == -1) {
			int connection = 0;
			if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections))
				connection = Pathing.PathSpriteIndexes[pathConnections];
			else if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF))
				connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];

			graphicsData.paletteImages[offset + connection].DrawWithOffset(p, position, drawSettings.Darkness, false);
		}
		else {
			graphicsData.paletteImages[offset + 16 + (drawSettings.Slope + 3) % 4].DrawWithOffset(p, position, drawSettings.Darkness, false);
		}
	}
	/** <summary> Draws all 4 parts of the path in order. </summary> */
	public void DrawPathParts(PaletteImage p, Point position, DrawSettings drawSettings, bool[,] connections) {
		int[] indexes = { 7, 3, 0, 6, -1, 4, 2, 1, 5 };
		int slope = drawSettings.Slope;
		for (int type = 0; type < 4; type++) {
			for (int i = 0; i < indexes.Length; i++) {
				if (indexes[i] == -1) {
					drawSettings.Slope = slope;
					switch (type) {
					case 0: DrawSupports(p, position, drawSettings, Math.Max(0, slope), drawSettings.PathConnections); break;
					case 1: DrawElevatedPath(p, position, drawSettings, Math.Max(0, slope), drawSettings.PathConnections); break;
					case 2: DrawPath(p, position, drawSettings, drawSettings.PathConnections); break;
					case 3: DrawRailing(p, position, drawSettings, drawSettings.PathConnections); break;
					}
					drawSettings.Slope = -1;
				}
				else if ((drawSettings.PathConnections & (1 << indexes[i])) != 0) {
					switch (type) {
					case 0: DrawSupports(p, GetConnectionPoint(position, indexes[i], slope), drawSettings, Math.Max(0, slope), ConvertConnections(connections, indexes[i])); break;
					case 1: DrawElevatedPath(p, GetConnectionPoint(position, indexes[i], slope), drawSettings, Math.Max(0, slope), ConvertConnections(connections, indexes[i])); break;
					case 2: DrawPath(p, GetConnectionPoint(position, indexes[i], slope), drawSettings, ConvertConnections(connections, indexes[i])); break;
					case 3: DrawRailing(p, GetConnectionPoint(position, indexes[i], slope), drawSettings, ConvertConnections(connections, indexes[i])); break;
					}
				}
			}
		}
	}

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
		position.Y -= drawSettings.Elevation * 2;
		uint pathConnections = drawSettings.PathConnections;
		if (drawSettings.Queue)
			pathConnections &= 0x0000000F;
		int offset = (drawSettings.Queue ? 51 : 0);

		bool[,] connections = new bool[5, 5];

		for (int x = 0; x < 5; x++) {
			for (int y = 0; y < 5; y++) {
				connections[x, y] = false;
			}
		}

		switch (drawSettings.Slope) {
		case 0:
		case 2: drawSettings.PathConnections = Convert.ToByte("1010", 2); break;
		case 1:
		case 3: drawSettings.PathConnections = Convert.ToByte("0101", 2); break;
		}

		connections[2, 2] = true;

		connections[3, 2] = (pathConnections & Convert.ToByte("00000001", 2)) != 0;
		connections[2, 3] = (pathConnections & Convert.ToByte("00000010", 2)) != 0;
		connections[1, 2] = (pathConnections & Convert.ToByte("00000100", 2)) != 0;
		connections[2, 1] = (pathConnections & Convert.ToByte("00001000", 2)) != 0;

		connections[3, 3] = (pathConnections & Convert.ToByte("00010000", 2)) != 0;
		connections[1, 3] = (pathConnections & Convert.ToByte("00100000", 2)) != 0;
		connections[1, 1] = (pathConnections & Convert.ToByte("01000000", 2)) != 0;
		connections[3, 1] = (pathConnections & Convert.ToByte("10000000", 2)) != 0;

		try {
			DrawPathParts(p, position, drawSettings, connections);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(PaletteImage p, Point position, Size dialogSize, DrawSettings drawSettings) {
		try {
			graphicsData.paletteImages[71].Draw(p, Point.Add(position, new Size(-4 - 44, -16)), 0, false);
			graphicsData.paletteImages[72].Draw(p, Point.Add(position, new Size(4, -16)), 0, false);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}

	/** <summary> Checks if a connection condition is true. </summary> */
	public bool CheckConnections(uint pathConnections, string condition) {
		for (int i = 0; i < 8; i++) {
			bool conec = (pathConnections & (1 << i)) != 0;
			char cond = condition[7 - i];
			if ((conec && (cond == '0')) || (!conec && (cond == '1')))
				return false;
		}

		return true;
	}
	/** <summary> Gets the position offset of the connection. </summary> */
	public Point GetConnectionPoint(Point position, int digit, int slope = -1) {
		Point offset = Point.Empty;
		int x = 32;
		int y = 16;
		switch (digit) {
		case 0: offset = new Point(x, -y); break;
		case 1: offset = new Point(x, y); break;
		case 2: offset = new Point(-x, y); break;
		case 3: offset = new Point(-x, -y); break;

		case 4: offset = new Point(x*2, 0); break;
		case 5: offset = new Point(0, y*2); break;
		case 6: offset = new Point(-x*2, 0); break;
		case 7: offset = new Point(0, -y*2); break;
		}
		offset.X += position.X;
		offset.Y += position.Y;
		if (slope != -1 && (slope + 3) % 4 == digit)
			offset.Y -= 16;
		return offset;
	}
	/** <summary> Translates the connections. </summary> */
	public uint ConvertConnections(bool[,] connections, int digit) {
		uint index = 0x00000000;
		Point offset = Point.Empty;
		switch (digit) {
		case 0: offset = new Point(1, 0); break;
		case 1: offset = new Point(0, 1); break;
		case 2: offset = new Point(-1, 0); break;
		case 3: offset = new Point(0, -1); break;

		case 4: offset = new Point(1, 1); break;
		case 5: offset = new Point(-1, 1); break;
		case 6: offset = new Point(-1, -1); break;
		case 7: offset = new Point(1, -1); break;
		}

		if (connections[3 + offset.X, 2 + offset.Y]) index |= 1 << 0;
		if (connections[2 + offset.X, 3 + offset.Y]) index |= 1 << 1;
		if (connections[1 + offset.X, 2 + offset.Y]) index |= 1 << 2;
		if (connections[2 + offset.X, 1 + offset.Y]) index |= 1 << 3;

		if (connections[3 + offset.X, 3 + offset.Y]) index |= 1 << 4;
		if (connections[1 + offset.X, 3 + offset.Y]) index |= 1 << 5;
		if (connections[1 + offset.X, 1 + offset.Y]) index |= 1 << 6;
		if (connections[3 + offset.X, 1 + offset.Y]) index |= 1 << 7;

		for (int i = 0; i < 4; i++) {
			if ((index & (1 << (i + 4))) != 0) {
				if ((index & (1 << i)) == 0 || (index & (1 << ((i + 1) % 4))) == 0)
					index &= ~(uint)(1 << (i + 4));
			}
		}

		return index;
	}

	#endregion
	//========= PATH SPRITES =========
	#region Path Sprites

	/** <summary> Sets the sprites for all the paths connections in the dictionary. </summary> */
	public static void SetPathSprites() {
		// No corners connecting
		for (int i = 0; i < 16; i++) {
			Pathing.PathSpriteIndexes.Add((uint)i, i);
		}

		// All straights connecting
		for (int i = 1; i < 16; i++) {
			Pathing.PathSpriteIndexes.Add((uint)i << 4 | 0xF, 36 + (i - 1));
		}

		// Not all straights connecting (couldn't find a pattern)
		int index = 20;
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00010011", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00100110", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00010111", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00100111", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00110111", 2), index++);

		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("10001001", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00011011", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("10001011", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("10011011", 2), index++);

		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("01001100", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("01001101", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("10001101", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("11001101", 2), index++);

		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("00101110", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("01001110", 2), index++);
		Pathing.PathSpriteIndexes.Add(Convert.ToUInt32("01101110", 2), index++);
	}

	#endregion
}
/** <summary> The header used for small scenery objects. </summary> */
public class PathingHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members
	
	/** <summary> Ten bytes of data that are always zero in dat files. </summary> */
	public byte[] Reserved0;
	/** <summary> The flags used by the object. </summary> */
	public PathingFlags Flags;
	/** <summary> Always zero in dat files. </summary> */
	public ushort Reserved1;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public PathingHeader() {
		this.Reserved0	= new byte[10];
		this.Flags		= PathingFlags.None;
		this.Reserved1	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	internal override uint HeaderSize {
		get { return Pathing.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	internal override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Basic;
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	internal override void Read(BinaryReader reader) {
		reader.Read(this.Reserved0, 0, this.Reserved0.Length);
		this.Flags		= (PathingFlags)reader.ReadUInt16();
		this.Reserved1	= reader.ReadUInt16();
	}
	/** <summary> Writes the object header. </summary> */
	internal override void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write((ushort)this.Flags);
		writer.Write(this.Reserved1);
	}

	#endregion
}
/** <summary> All flags usable with pathing objects. </summary> */
[Flags]
public enum PathingFlags : ushort {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,
	/** <summary> True if pole supports are used, otherwise they are scaffold supports. </summary> */
	PoleSupports = 0x0001,
	/** <summary> True if pole supports have base sprites. </summary> */
	PoleBase = 0x0100,
	/** <summary> True if the primary path should be overlayed on elavated path. </summary> */
	OverlayPath = 0x0200,
	/** <summary> This path is hidden when playing the scenario. </summary> */
	Hidden = 0x0400,
}
}
