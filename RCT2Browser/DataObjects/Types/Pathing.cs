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

	/** <summary> The index of each path sprite depending on certain straights and corners connecting. </summary> */
	public static Dictionary<uint, int> PathSpriteIndexes = new Dictionary<uint, int>();

	public static bool Queue = false;
	public static uint PathConnections = 0x00000000;

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
		get { return true; }
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

	/** <summary> Draws the path railing. </summary> */
	public void DrawRailing(Graphics g, Point position, int slope, int elevation, bool queue, uint pathConnections) {
		int offset = (queue ? 51 : 0);
		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections) && !(elevation > 0 && !Header.Flags.HasFlag(PathingFlags.OverlayPath))) {
			connection = Pathing.PathSpriteIndexes[pathConnections];
		}
		else if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			pathConnections &= 0xF;
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}

		if (slope == -1) {
			if (queue)
				offset = 87;
			else if (elevation > 0)
				offset = 73;

			if (queue || elevation > 0) {
				if (CheckConnections(pathConnections, "####00#1")) {
					g.DrawImage(graphicsData.Images[offset + 3], new Point(
						position.X + imageDirectory.Entries[offset + 3].XOffset + 4,
						position.Y + imageDirectory.Entries[offset + 3].YOffset + 2
					));
				}
				if (CheckConnections(pathConnections, "#####001")) {
					g.DrawImage(graphicsData.Images[offset + 3], new Point(
						position.X + imageDirectory.Entries[offset + 3].XOffset + 32 - 4,
						position.Y + imageDirectory.Entries[offset + 3].YOffset + 16 - 2
					));
				}
				if (CheckConnections(pathConnections, "####0#10")) {
					g.DrawImage(graphicsData.Images[offset + 4], new Point(
						position.X + imageDirectory.Entries[offset + 4].XOffset - 4,
						position.Y + imageDirectory.Entries[offset + 4].YOffset + 2
					));
				}
				if (CheckConnections(pathConnections, "####001#")) {
					g.DrawImage(graphicsData.Images[offset + 4], new Point(
						position.X + imageDirectory.Entries[offset + 4].XOffset - 32 + 4,
						position.Y + imageDirectory.Entries[offset + 4].YOffset + 16 - 2
					));
				}
				if (CheckConnections(pathConnections, "#####100")) {
					g.DrawImage(graphicsData.Images[offset + 5], new Point(
						position.X + imageDirectory.Entries[offset + 5].XOffset + 32 - 4,
						position.Y + imageDirectory.Entries[offset + 5].YOffset + 16 - 2
					));
				}
				if (CheckConnections(pathConnections, "####01#0")) {
					g.DrawImage(graphicsData.Images[offset + 5], new Point(
						position.X + imageDirectory.Entries[offset + 5].XOffset + 4,
						position.Y + imageDirectory.Entries[offset + 5].YOffset + 2
					));
				}
				if (CheckConnections(pathConnections, "####100#")) {
					g.DrawImage(graphicsData.Images[offset + 2], new Point(
						position.X + imageDirectory.Entries[offset + 2].XOffset - 32 + 4,
						position.Y + imageDirectory.Entries[offset + 2].YOffset + 16 - 2
					));
				}
				if (CheckConnections(pathConnections, "####1#00")) {
					g.DrawImage(graphicsData.Images[offset + 2], new Point(
						position.X + imageDirectory.Entries[offset + 2].XOffset - 4,
						position.Y + imageDirectory.Entries[offset + 2].YOffset + 2
					));
				}

				if (CheckConnections(pathConnections, "####01#1")) {
					g.DrawImage(graphicsData.Images[offset + 1], new Point(
						position.X + imageDirectory.Entries[offset + 1].XOffset + 4,
						position.Y + imageDirectory.Entries[offset + 1].YOffset + 2
					));
				}
				if (CheckConnections(pathConnections, "#####101")) {
					g.DrawImage(graphicsData.Images[offset + 1], new Point(
						position.X + imageDirectory.Entries[offset + 1].XOffset + 32 - 4,
						position.Y + imageDirectory.Entries[offset + 1].YOffset + 16 - 2
					));
				}
				if (CheckConnections(pathConnections, "####1#10")) {
					g.DrawImage(graphicsData.Images[offset + 0], new Point(
						position.X + imageDirectory.Entries[offset + 0].XOffset - 4,
						position.Y + imageDirectory.Entries[offset + 0].YOffset + 2
					));
				}
				if (CheckConnections(pathConnections, "####101#")) {
					g.DrawImage(graphicsData.Images[offset + 0], new Point(
						position.X + imageDirectory.Entries[offset + 0].XOffset - 32 + 4,
						position.Y + imageDirectory.Entries[offset + 0].YOffset + 16 - 2
					));
				}

				if (CheckConnections(pathConnections, "###0##11")) {
					g.DrawImage(graphicsData.Images[offset + 11], new Point(
						position.X + imageDirectory.Entries[offset + 11].XOffset,
						position.Y + imageDirectory.Entries[offset + 11].YOffset
					));
				}
				if (CheckConnections(pathConnections, "##0##11#")) {
					g.DrawImage(graphicsData.Images[offset + 12], new Point(
						position.X + imageDirectory.Entries[offset + 12].XOffset,
						position.Y + imageDirectory.Entries[offset + 12].YOffset
					));
				}
				if (CheckConnections(pathConnections, "#0##11##")) {
					g.DrawImage(graphicsData.Images[offset + 13], new Point(
						position.X + imageDirectory.Entries[offset + 13].XOffset,
						position.Y + imageDirectory.Entries[offset + 13].YOffset
					));
				}
				if (CheckConnections(pathConnections, "0###1##1")) {
					g.DrawImage(graphicsData.Images[offset + 10], new Point(
						position.X + imageDirectory.Entries[offset + 10].XOffset,
						position.Y + imageDirectory.Entries[offset + 10].YOffset
					));
				}
			}
		}
		else {
			if (queue)
				offset = 87;
			else
				offset = 73;

			switch (slope) {
			case 0:
				g.DrawImage(graphicsData.Images[offset + 6], new Point(
					position.X + imageDirectory.Entries[offset + 6].XOffset - 4,
					position.Y + imageDirectory.Entries[offset + 6].YOffset + 2
				));
				g.DrawImage(graphicsData.Images[offset + 6], new Point(
					position.X + imageDirectory.Entries[offset + 6].XOffset - 32 + 4,
					position.Y + imageDirectory.Entries[offset + 6].YOffset + 16 - 2
				));
				break;
			case 1:
				g.DrawImage(graphicsData.Images[offset + 8], new Point(
					position.X + imageDirectory.Entries[offset + 8].XOffset + 4,
					position.Y + imageDirectory.Entries[offset + 8].YOffset + 2
				));
				g.DrawImage(graphicsData.Images[offset + 8], new Point(
					position.X + imageDirectory.Entries[offset + 8].XOffset + 32 - 4,
					position.Y + imageDirectory.Entries[offset + 8].YOffset + 16 - 2
				));
				break;
			case 2:
				g.DrawImage(graphicsData.Images[offset + 7], new Point(
					position.X + imageDirectory.Entries[offset + 7].XOffset - 4,
					position.Y + imageDirectory.Entries[offset + 7].YOffset + 2
				));
				g.DrawImage(graphicsData.Images[offset + 7], new Point(
					position.X + imageDirectory.Entries[offset + 7].XOffset - 32 + 4,
					position.Y + imageDirectory.Entries[offset + 7].YOffset + 16 - 2
				));
				break;
			case 3:
				g.DrawImage(graphicsData.Images[offset + 9], new Point(
					position.X + imageDirectory.Entries[offset + 9].XOffset + 4,
					position.Y + imageDirectory.Entries[offset + 9].YOffset + 2
				));
				g.DrawImage(graphicsData.Images[offset + 9], new Point(
					position.X + imageDirectory.Entries[offset + 9].XOffset + 32 - 4,
					position.Y + imageDirectory.Entries[offset + 9].YOffset + 16 - 2
				));
				break;
			}
		}
	}
	/** <summary> Draws the path pole supports. </summary> */
	public void DrawPoleSupport(Graphics g, Point position, int slope, int elevation) {
		position.Y += elevation * 2;
		if (slope != -1)
			position.Y -= elevation / 2;
		int offset = 129;
		while (elevation > 8) {
			g.DrawImage(graphicsData.Images[offset + 15], new Point(
				position.X + imageDirectory.Entries[offset + 15].XOffset,
				position.Y + imageDirectory.Entries[offset + 15].YOffset
			));
			elevation -= 8;
			position.Y += 16;
		}
		if (Header.Flags.HasFlag(PathingFlags.PoleBase)) {
			position.Y -= 6;
			g.DrawImage(graphicsData.Images[offset + 9], new Point(
				position.X + imageDirectory.Entries[offset + 9].XOffset,
				position.Y + imageDirectory.Entries[offset + 9].YOffset
			));
			int slopeOffset = 17;
			switch (slope) {
			case 0: slopeOffset = 19; break;
			case 1: slopeOffset = 25; break;
			case 2: slopeOffset = 26; break;
			case 3: slopeOffset = 20; break;
			}
			g.DrawImage(graphicsData.Images[offset + slopeOffset], new Point(
				position.X + imageDirectory.Entries[offset + slopeOffset].XOffset,
				position.Y + imageDirectory.Entries[offset + slopeOffset].YOffset + 6
			));
		}
		else {
			g.DrawImage(graphicsData.Images[offset + 15], new Point(
				position.X + imageDirectory.Entries[offset + 15].XOffset,
				position.Y + imageDirectory.Entries[offset + 15].YOffset
			));
		}
	}
	/** <summary> Draws the path scaffold supports. </summary> */
	public void DrawScaffoldSupport(Graphics g, Point position, int rotation, int slope, int elevation) {
		int offset = 109;

		if (slope == -1) {
			g.DrawImage(graphicsData.Images[offset + (rotation % 2 == 0 ? 46 : 22)], new Point(
				position.X + imageDirectory.Entries[offset + (rotation % 2 == 0 ? 46 : 22)].XOffset + 12,
				position.Y + imageDirectory.Entries[offset + (rotation % 2 == 0 ? 46 : 22)].YOffset + 32 - 6
			));
		}
		else {
			int offset2 = 0;
			switch (slope) {
			case 0: offset2 = 5; break;
			case 1: offset2 = 11; break;
			case 2: offset2 = 8; break;
			case 3: offset2 = 2; break;
			}
			g.DrawImage(graphicsData.Images[offset + (slope % 2 == 0 ? 24 : 0) + offset2], new Point(
				position.X + imageDirectory.Entries[offset + (slope % 2 == 0 ? 24 : 0) + offset2].XOffset + 12,
				position.Y + imageDirectory.Entries[offset + (slope % 2 == 0 ? 24 : 0) + offset2].YOffset + 32 - 6
			));
			g.DrawImage(graphicsData.Images[offset + (slope % 2 == 0 ? 47 : 23)], new Point(
				position.X + imageDirectory.Entries[offset + (slope % 2 == 0 ? 47 : 23)].XOffset + 12,
				position.Y + imageDirectory.Entries[offset + (slope % 2 == 0 ? 47 : 23)].YOffset + 16 - 6
			));
			offset = 164;
			g.DrawImage(graphicsData.Images[offset + (slope + 3) % 4], new Point(
				position.X + imageDirectory.Entries[offset + (slope + 3) % 4].XOffset + 12,
				position.Y + imageDirectory.Entries[offset + (slope + 3) % 4].YOffset - 6
			));
		}
	}
	/** <summary> Draws the path supports. </summary> */
	public void DrawSupports(Graphics g, Point position, int rotation, int slope, int elevation, bool queue, uint pathConnections) {
		if (elevation == 0)
			return;

		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}
		if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
			if (CheckConnections(pathConnections, "#######0"))
				DrawPoleSupport(g, Point.Add(position, new Size(12, -6)), slope, elevation);
			if (CheckConnections(pathConnections, "####0###"))
				DrawPoleSupport(g, Point.Add(position, new Size(-12, -6)), slope, elevation);
			if (CheckConnections(pathConnections, "######0#"))
				DrawPoleSupport(g, Point.Add(position, new Size(12, 6)), slope, elevation);
			if (CheckConnections(pathConnections, "#####0##"))
				DrawPoleSupport(g, Point.Add(position, new Size(-12, 6)), slope, elevation);
		}
		else {
			DrawScaffoldSupport(g, Point.Add(position, new Size(-12, 6)), rotation, slope, elevation);
		}
	}
	/** <summary> Draws the elevated path. </summary> */
	public void DrawElevatedPath(Graphics g, Point position, int rotation, int slope, int elevation, bool queue, uint pathConnections) {
		if (elevation == 0)
			return;

		int offset = 109;
		int connection = 0;
		if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF)) {
			connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];
		}

		if (slope == -1) {
			if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
				g.DrawImage(graphicsData.Images[offset + connection], new Point(
					position.X + imageDirectory.Entries[offset + connection].XOffset,
					position.Y + imageDirectory.Entries[offset + connection].YOffset
				));
			}
			else {
				offset = 158;
				g.DrawImage(graphicsData.Images[offset + ((rotation + 1) % 2)], new Point(
					position.X + imageDirectory.Entries[offset + ((rotation + 1) % 2)].XOffset,
					position.Y + imageDirectory.Entries[offset + ((rotation + 1) % 2)].YOffset
				));
			}
		}
		else {
			if (Header.Flags.HasFlag(PathingFlags.PoleSupports)) {
				g.DrawImage(graphicsData.Images[offset + 16 + (slope + 3) % 4], new Point(
					position.X + imageDirectory.Entries[offset + 16 + (slope + 3) % 4].XOffset,
					position.Y + imageDirectory.Entries[offset + 16 + (slope + 3) % 4].YOffset
				));
			}
			else {
				offset = 158;
				g.DrawImage(graphicsData.Images[offset + 2 + (slope + 3) % 4], new Point(
					position.X + imageDirectory.Entries[offset + 2 + (slope + 3) % 4].XOffset,
					position.Y + imageDirectory.Entries[offset + 2 + (slope + 3) % 4].YOffset
				));
			}
		}
	}
	/** <summary> Draws the path base. </summary> */
	public void DrawPath(Graphics g, Point position, int slope, int elevation, bool queue, uint pathConnections) {
		if (elevation > 0 && !Header.Flags.HasFlag(PathingFlags.OverlayPath))
			return;

		int offset = (queue ? 51 : 0);

		if (slope == -1) {
			int connection = 0;
			if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections))
				connection = Pathing.PathSpriteIndexes[pathConnections];
			else if (Pathing.PathSpriteIndexes.ContainsKey(pathConnections & 0xF))
				connection = Pathing.PathSpriteIndexes[pathConnections & 0xF];

			g.DrawImage(graphicsData.Images[offset + connection], new Point(
				position.X + imageDirectory.Entries[offset + connection].XOffset,
				position.Y + imageDirectory.Entries[offset + connection].YOffset
			));
		}
		else {
			g.DrawImage(graphicsData.Images[offset + 16 + (slope + 3) % 4], new Point(
				position.X + imageDirectory.Entries[offset + 16 + (slope + 3) % 4].XOffset,
				position.Y + imageDirectory.Entries[offset + 16 + (slope + 3) % 4].YOffset
			));
		}
	}
	/** <summary> Draws all 4 parts of the path in order. </summary> */
	public void DrawPathParts(Graphics g, Point position, int slope, int elevation, bool queue, uint pathConnections, bool[,] connections) {
		int[] indexes = { 7, 3, 0, 6, -1, 4, 2, 1, 5 };
		for (int type = 0; type < 4; type++) {
			for (int i = 0; i < indexes.Length; i++) {
				if (indexes[i] == -1) {
					switch (type) {
					case 0: DrawSupports(g, position, Math.Max(0, slope), slope, elevation, queue, pathConnections); break;
					case 1: DrawElevatedPath(g, position, Math.Max(0, slope), slope, elevation, queue, pathConnections); break;
					case 2: DrawPath(g, position, slope, elevation, queue, pathConnections); break;
					case 3: DrawRailing(g, position, slope, elevation, queue, pathConnections); break;
					}
				}
				else if ((pathConnections & (1 << indexes[i])) != 0) {
					switch (type) {
					case 0: DrawSupports(g, GetConnectionPoint(position, indexes[i], slope), Math.Max(0, slope), -1, elevation, queue, ConvertConnections(connections, indexes[i])); break;
					case 1: DrawElevatedPath(g, GetConnectionPoint(position, indexes[i], slope), Math.Max(0, slope), -1, elevation, queue, ConvertConnections(connections, indexes[i])); break;
					case 2: DrawPath(g, GetConnectionPoint(position, indexes[i], slope), -1, elevation, queue, ConvertConnections(connections, indexes[i])); break;
					case 3: DrawRailing(g, GetConnectionPoint(position, indexes[i], slope), -1, elevation, queue, ConvertConnections(connections, indexes[i])); break;
					}
				}
			}
		}
	}

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		position.Y -= elevation * 2;
		uint pathConnections = Pathing.PathConnections;
		bool queue = Pathing.Queue;
		if (queue)
			pathConnections &= 0x0000000F;
		int offset = (queue ? 51 : 0);

		bool[,] connections = new bool[5, 5];

		for (int x = 0; x < 5; x++) {
			for (int y = 0; y < 5; y++) {
				connections[x, y] = false;
			}
		}

		switch (slope) {
		case 0:
		case 2: pathConnections = Convert.ToUInt32("1010", 2); break;
		case 1:
		case 3: pathConnections = Convert.ToUInt32("0101", 2); break;
		}

		connections[2, 2] = true;

		connections[3, 2] = (pathConnections & Convert.ToUInt32("00000001", 2)) != 0;
		connections[2, 3] = (pathConnections & Convert.ToUInt32("00000010", 2)) != 0;
		connections[1, 2] = (pathConnections & Convert.ToUInt32("00000100", 2)) != 0;
		connections[2, 1] = (pathConnections & Convert.ToUInt32("00001000", 2)) != 0;

		connections[3, 3] = (pathConnections & Convert.ToUInt32("00010000", 2)) != 0;
		connections[1, 3] = (pathConnections & Convert.ToUInt32("00100000", 2)) != 0;
		connections[1, 1] = (pathConnections & Convert.ToUInt32("01000000", 2)) != 0;
		connections[3, 1] = (pathConnections & Convert.ToUInt32("10000000", 2)) != 0;

		try {
			DrawPathParts(g, position, slope, elevation, queue, pathConnections, connections);
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
	//--------------------------------
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

	/** <summary> The flags used by the object. </summary> */
	public PathingFlags Flags;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public PathingHeader() {
		this.Flags	= PathingFlags.None;
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
		reader.ReadBytes(10);
		this.Flags = (PathingFlags)reader.ReadUInt16();
		reader.ReadBytes(2);
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
