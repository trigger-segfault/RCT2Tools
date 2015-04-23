using RCT2ObjectData.DataObjects;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;
using RCT2MazeGenerator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MazeGenerator {
public class MazeEditor : Control {

	//========== CONSTANTS ===========
	#region Constants

	public static Color HighlightColor = Color.FromArgb(211, 219, 219);
	public static Color BuildingColor = Color.FromArgb(163, 59, 59);
	public static Color BuildingColor2 = Color.FromArgb(143, 39, 39);
	public static Color BuildingOutlineColor = Color.FromArgb(39, 143, 7);
	public static Color BuildingDoorColor = Color.FromArgb(35, 0, 0);
	public static Color PathColor = Color.FromArgb(91, 63, 31);
	public static Color GridColor = Color.FromArgb(100, 23, 35, 35);
	public static Color GrassOutlineColor = Color.FromArgb(200, 35, 63, 23);
	public static Color RestrictColor = Color.FromArgb(150, 199, 0, 0);
	public static Color GenerateColor = Color.FromArgb(180, 71, 175, 39);

	public static Color[] WallColors = new Color[]{
		Color.FromArgb(23, 35, 35), // Brick Walls
		Color.FromArgb(115, 155, 67), // Hedges
		Color.FromArgb(175, 231, 251), // Ice Blocks
		Color.FromArgb(203, 175, 111) // Wood Fences
	};

	public static Size MaxMazeSize = new Size(127, 127);

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The grid for the maze. </summary> */
	private MazeBlock[,] blocks;

	private int pathWidth;
	private int wallWidth;

	private WallStyles wallStyle;

	private bool drawGrid;

	private MazeWallTypes hoverType;
	private Point hoverPoint;

	private Point generatePoint;

	private PlaceModes placeMode;
	private Point placePoint;
	private MazeBuildingDirections placeDirection;

	private bool wallsMakeTiles;

	private int zoom;

	[Browsable(true)][Category("Action")]
	[DisplayName("MazeChanged")][Description("")]
	public event EventHandler MazeChanged;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public MazeEditor() : base() {
		this.InitializeComponent();
		this.blocks = new MazeBlock[1, 1];
		this.blocks[0, 0] = new MazeBlock();

		this.pathWidth = 16;
		this.wallWidth = 3;
		this.wallStyle = WallStyles.Hedges;
		this.drawGrid = true;

		this.hoverType = MazeWallTypes.None;
		this.hoverPoint = Point.Empty;
		this.generatePoint = Point.Empty;
		this.placeMode = PlaceModes.Walls;
		this.placePoint = Point.Empty;
		this.placeDirection = MazeBuildingDirections.None;

		this.wallsMakeTiles = true;

		this.zoom = 2;
	}

	#endregion
	//======== INITIALIZATION ========
	#region Initialization

	/** <summary> Initializes the component. </summary> */
	public void InitializeComponent() {
		this.SetStyle(ControlStyles.Selectable, false);
		this.SetStyle(ControlStyles.UserPaint, true);
		this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		this.SetStyle(ControlStyles.DoubleBuffer, true);
	}

	#endregion
	//=========== EDITING ============
	#region Editing

	/** <summary> Resizes the maze to the new specified size. </summary> */
	public void ResizeMaze(Size newSize) {
		MazeBlock[,] newBlocks = new MazeBlock[Math.Max(1, Math.Min(MaxMazeSize.Width, newSize.Width)), Math.Max(1, Math.Min(MaxMazeSize.Height, newSize.Height))];
		for (int x = 0; x < newBlocks.GetLength(0); x++) {
			for (int y = 0; y < newBlocks.GetLength(1); y++) {
				if (x < this.blocks.GetLength(0) && y < this.blocks.GetLength(1))
					newBlocks[x, y] = this.blocks[x, y];
				else
					newBlocks[x, y] = new MazeBlock();
			}
		}
		this.blocks = newBlocks;
		this.Width = this.blocks.GetLength(0) * (this.pathWidth * 2 + this.wallWidth * 4);
		this.Height = this.blocks.GetLength(1) * (this.pathWidth * 2 + this.wallWidth * 4);
		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			MazeBlock block = this.blocks[x, 0];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.NorthLeft | MazeWalls.NorthRight);
			block = this.blocks[x, this.blocks.GetLength(1) - 1];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.SouthLeft | MazeWalls.SouthRight);
		}
		for (int y = 0; y < this.blocks.GetLength(1); y++) {
			MazeBlock block = this.blocks[0, y];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.WestTop | MazeWalls.WestBottom);
			block = this.blocks[this.blocks.GetLength(0) - 1, y];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.EastTop | MazeWalls.EastBottom);
		}
		OnMazeChanged(new EventArgs());
		this.Invalidate();
	}
	/** <summary> Translates the maze by the specified distance. </summary> */
	public void TranslateMaze(Point distance) {
		MazeBlock[,] newBlocks = new MazeBlock[this.blocks.GetLength(0), this.blocks.GetLength(1)];
		for (int x = 0; x < newBlocks.GetLength(0); x++) {
			for (int y = 0; y < newBlocks.GetLength(1); y++) {
				if (x - distance.X >= 0 && x - distance.X < this.blocks.GetLength(0) &&
					y - distance.Y >= 0 && y - distance.Y < this.blocks.GetLength(1))
					newBlocks[x, y] = this.blocks[x - distance.X, y - distance.Y];
				else
					newBlocks[x, y] = new MazeBlock();
			}
		}
		this.blocks = newBlocks;
		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			MazeBlock block = this.blocks[x, 0];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.NorthLeft | MazeWalls.NorthRight);
			block = this.blocks[x, this.blocks.GetLength(1) - 1];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.SouthLeft | MazeWalls.SouthRight);
		}
		for (int y = 0; y < this.blocks.GetLength(1); y++) {
			MazeBlock block = this.blocks[0, y];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.WestTop | MazeWalls.WestBottom);
			block = this.blocks[this.blocks.GetLength(0) - 1, y];
			if (!block.IsBuilding && !block.Empty) block.Walls |= (MazeWalls.EastTop | MazeWalls.EastBottom);
		}
		OnMazeChanged(new EventArgs());
		this.Invalidate();
	}
	/** <summary> Loads the specified maze into the editor. </summary> */
	public void LoadMaze(TrackDesign maze) {
		if (maze.TrackType == TrackTypes.HedgeMaze) {
			// Flip the maze (mazes are saved flipped verticaly)
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					this.blocks[x, y] = new MazeBlock();
				}
			}

			Point min = Point.Empty;
			Point max = Point.Empty;
			for (int i = 0; i < maze.MazeTiles.Count; i++) {
				MazeTile tile = maze.MazeTiles[i];
				if (tile.X < min.X) min.X = tile.X;
				if (tile.Y < min.Y) min.Y = tile.Y;
				if (tile.X > max.X) max.X = tile.X;
				if (tile.Y > max.Y) max.Y = tile.Y;
			}
			Size newSize = new Size(-min.X + max.X + 1, -min.Y + max.Y + 1);
			ResizeMaze(newSize);

			for (int i = 0; i < maze.MazeTiles.Count; i++) {
				MazeTile tile = maze.MazeTiles[i];
				this.blocks[tile.X - min.X, -tile.Y + max.Y] = new MazeBlock(FlipWalls(tile.Walls), false);
			}
			this.wallStyle = (WallStyles)maze.TrackSupportColors[0];
			this.Invalidate();
		}
	}
	/** <summary> Saves the editor to the specified maze. </summary> */
	public void SaveMaze(TrackDesign maze) {
		Point min = Point.Empty;
		Point max = Point.Empty;
		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = 0; y < this.blocks.GetLength(1); y++) {
				MazeBlock block = this.blocks[x, y];
				if (!block.Empty) {
					if (x < min.X) min.X = x;
					if (y < min.Y) min.Y = y;
					if (x > max.X) max.X = x;
					if (y > max.Y) max.Y = y;
				}
			}
		}
		Size mazeSize = new Size(-min.X + max.X + 1, -min.Y + max.Y + 1);
		Point center = Point.Empty;// new Point(mazeSize.Width / 2, mazeSize.Height / 2);
		// Set the center to the entrance to avoid it being an invalid tile
		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = this.blocks.GetLength(1) - 1; y >= 0; y--) {
				MazeBlock block = this.blocks[x, y];
				if (block.IsEntrance) {
					center = new Point(x, mazeSize.Height - y - 1);
				}
			}
		}

		maze.TrackSupportColors[0] = (RemapColors)this.wallStyle;
		maze.RideMapWidth = (byte)mazeSize.Width;
		maze.RideMapHeight = (byte)mazeSize.Height;
		maze.MazeTiles.Clear();

		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = this.blocks.GetLength(1) - 1; y >= 0; y--) {
				MazeBlock block = this.blocks[x, y];
				if (!block.Empty && !block.IsBuilding) {
					maze.MazeTiles.Add(new MazeTile(x - min.X - center.X, -y + max.Y - center.Y, FlipWalls(block.Walls)));
				}
			}
		}

		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = this.blocks.GetLength(1) - 1; y >= 0; y--) {
				MazeBlock block = this.blocks[x, y];
				if (block.IsEntrance) {
					maze.MazeTiles.Add(new MazeTile(x - min.X - center.X, -y + max.Y - center.Y, FlipWalls(block.Walls)));
				}
			}
		}
		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = this.blocks.GetLength(1) - 1; y >= 0; y--) {
				MazeBlock block = this.blocks[x, y];
				if (block.IsExit) {
					maze.MazeTiles.Add(new MazeTile(x - min.X - center.X, -y + max.Y - center.Y, FlipWalls(block.Walls)));
				}
			}
		}
	}
	private MazeWalls FlipWalls(MazeWalls walls) {
		MazeWalls newWalls = MazeWalls.None;
		if ((walls & (MazeWalls)0xFF00) == MazeWalls.Entrance || (walls & (MazeWalls)0xFF00) == MazeWalls.Exit) {
			if		(walls == MazeWalls.EntranceNorth) newWalls = MazeWalls.EntranceSouth;
			else if (walls == MazeWalls.EntranceSouth) newWalls = MazeWalls.EntranceNorth;
			else if (walls == MazeWalls.ExitNorth) newWalls = MazeWalls.ExitSouth;
			else if (walls == MazeWalls.ExitSouth) newWalls = MazeWalls.ExitNorth;
			else newWalls = walls;
		}
		else {
			// The only flags that will be the same
			newWalls |= walls & (MazeWalls.WestMiddle | MazeWalls.EastMiddle);

			// Sides
			newWalls |= SwapFlag(walls, MazeWalls.WestTop, MazeWalls.WestBottom);
			newWalls |= SwapFlag(walls, MazeWalls.EastTop, MazeWalls.EastBottom);

			// Bases
			newWalls |= SwapFlag(walls, MazeWalls.NorthLeft, MazeWalls.SouthLeft);
			newWalls |= SwapFlag(walls, MazeWalls.NorthMiddle, MazeWalls.SouthMiddle);
			newWalls |= SwapFlag(walls, MazeWalls.NorthRight, MazeWalls.SouthRight);

			// Quadrants
			newWalls |= SwapFlag(walls, MazeWalls.Quadrant4, MazeWalls.Quadrant3);
			newWalls |= SwapFlag(walls, MazeWalls.Quadrant1, MazeWalls.Quadrant2);
		}
		return newWalls;
	}
	private MazeWalls SwapFlag(MazeWalls walls, MazeWalls flag1, MazeWalls flag2) {
		return (walls.HasFlag(flag1) ? flag2 : MazeWalls.None) | (walls.HasFlag(flag2) ? flag1 : MazeWalls.None);
	}

	/** <summary> Zooms in the editor view. </summary> */
	public void ZoomIn() {
		zoom = Math.Min(5, zoom + 1);
		switch (zoom) {
		case 0: this.wallWidth = 1; this.pathWidth = 5; break;
		case 1: this.wallWidth = 2; this.pathWidth = 10; break;
		case 2: this.wallWidth = 3; this.pathWidth = 16; break;
		case 3: this.wallWidth = 4; this.pathWidth = 22; break;
		case 4: this.wallWidth = 5; this.pathWidth = 28; break;
		case 5: this.wallWidth = 6; this.pathWidth = 34; break;
		}
		this.Width = this.blocks.GetLength(0) * (this.pathWidth * 2 + this.wallWidth * 4);
		this.Height = this.blocks.GetLength(1) * (this.pathWidth * 2 + this.wallWidth * 4);
		this.Invalidate();
	}
	/** <summary> Zooms out the editor view. </summary> */
	public void ZoomOut() {
		zoom = Math.Max(0, zoom - 1);
		switch (zoom) {
		case 0: this.wallWidth = 1; this.pathWidth = 5; break;
		case 1: this.wallWidth = 2; this.pathWidth = 10; break;
		case 2: this.wallWidth = 3; this.pathWidth = 16; break;
		case 3: this.wallWidth = 4; this.pathWidth = 22; break;
		case 4: this.wallWidth = 5; this.pathWidth = 28; break;
		case 5: this.wallWidth = 6; this.pathWidth = 34; break;
		}
		this.Width = this.blocks.GetLength(0) * (this.pathWidth * 2 + this.wallWidth * 4);
		this.Height = this.blocks.GetLength(1) * (this.pathWidth * 2 + this.wallWidth * 4);
		this.Invalidate();
	}

	/** <summary> Gets the maze block at the specified position. Returns empty if one doesn't exist. </summary> */
	public MazeBlock GetBlock(Point point) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			return this.blocks[point.X, point.Y];
		}
		return new MazeBlock();
	}
	/** <summary> Gets the maze block at the specified position. Returns empty if one doesn't exist or it is an entrance/exit. </summary> */
	public MazeBlock GetNormalBlock(Point point) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			if (!this.blocks[point.X, point.Y].Empty && !this.blocks[point.X, point.Y].IsEntrance && !this.blocks[point.X, point.Y].IsExit) {
				return this.blocks[point.X, point.Y];
			}
		}
		return new MazeBlock();
	}
	/** <summary> Returns true if the maze block at the specified position is not empty or an entrance/exit. </summary> */
	public bool IsNormalBlock(Point point) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			if (!this.blocks[point.X, point.Y].Empty && !this.blocks[point.X, point.Y].IsEntrance && !this.blocks[point.X, point.Y].IsExit) {
				return true;
			}
		}
		return false;
	}
	/** <summary> Sets if the specified maze block is usable. </summary> */
	public void SetBlockSolid(Point point, bool solid) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			this.blocks[point.X, point.Y].Empty = false;
			this.blocks[point.X, point.Y].Walls = MazeWalls.All;
			SetQuadrantSolid(new Point(point.X * 2, point.Y * 2), true, true);
			SetQuadrantSolid(new Point(point.X * 2 + 1, point.Y * 2), true, true);
			SetQuadrantSolid(new Point(point.X * 2, point.Y * 2 + 1), true, true);
			SetQuadrantSolid(new Point(point.X * 2 + 1, point.Y * 2 + 1), true, true);
			this.blocks[point.X, point.Y].Walls = MazeWalls.All;
			this.blocks[point.X, point.Y].Restrictions = MazeWalls.None;
			this.blocks[point.X, point.Y].Empty = !solid;

			if (solid) {
				MazeBuildingDirections buildingDirection = MazeBuildingDirections.None;

				if (GetBlock(new Point(point.X - 1, point.Y)).BuildingDirection == MazeBuildingDirections.West && GetBlock(new Point(point.X - 1, point.Y)).IsEntrance)
					buildingDirection = MazeBuildingDirections.West;
				if (GetBlock(new Point(point.X, point.Y - 1)).BuildingDirection == MazeBuildingDirections.North && GetBlock(new Point(point.X, point.Y - 1)).IsEntrance)
					buildingDirection = MazeBuildingDirections.North;
				if (GetBlock(new Point(point.X + 1, point.Y)).BuildingDirection == MazeBuildingDirections.East && GetBlock(new Point(point.X + 1, point.Y )).IsEntrance)
					buildingDirection = MazeBuildingDirections.East;
				if (GetBlock(new Point(point.X, point.Y + 1)).BuildingDirection == MazeBuildingDirections.South && GetBlock(new Point(point.X, point.Y + 1)).IsEntrance)
					buildingDirection = MazeBuildingDirections.South;

				switch (buildingDirection) {
				case MazeBuildingDirections.North:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.NorthLeft | MazeWalls.NorthMiddle | MazeWalls.NorthRight | MazeWalls.Quadrant4 | MazeWalls.Quadrant1);
					break;
				case MazeBuildingDirections.South:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.SouthLeft | MazeWalls.SouthMiddle | MazeWalls.SouthRight | MazeWalls.Quadrant3 | MazeWalls.Quadrant2);
					break;
				case MazeBuildingDirections.West:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.WestTop | MazeWalls.WestMiddle | MazeWalls.WestBottom | MazeWalls.Quadrant4 | MazeWalls.Quadrant3);
					break;
				case MazeBuildingDirections.East:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.EastTop | MazeWalls.EastMiddle | MazeWalls.EastBottom | MazeWalls.Quadrant1 | MazeWalls.Quadrant2);
					break;
				}

				if (GetBlock(new Point(point.X - 1, point.Y)).BuildingDirection == MazeBuildingDirections.West && GetBlock(new Point(point.X - 1, point.Y)).IsExit)
					buildingDirection = MazeBuildingDirections.West;
				if (GetBlock(new Point(point.X, point.Y - 1)).BuildingDirection == MazeBuildingDirections.North && GetBlock(new Point(point.X, point.Y - 1)).IsExit)
					buildingDirection = MazeBuildingDirections.North;
				if (GetBlock(new Point(point.X + 1, point.Y)).BuildingDirection == MazeBuildingDirections.East && GetBlock(new Point(point.X + 1, point.Y)).IsExit)
					buildingDirection = MazeBuildingDirections.East;
				if (GetBlock(new Point(point.X, point.Y + 1)).BuildingDirection == MazeBuildingDirections.South && GetBlock(new Point(point.X, point.Y + 1)).IsExit)
					buildingDirection = MazeBuildingDirections.South;

				switch (buildingDirection) {
				case MazeBuildingDirections.North:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.NorthLeft | MazeWalls.NorthMiddle | MazeWalls.NorthRight | MazeWalls.Quadrant4 | MazeWalls.Quadrant1);
					break;
				case MazeBuildingDirections.South:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.SouthLeft | MazeWalls.SouthMiddle | MazeWalls.SouthRight | MazeWalls.Quadrant3 | MazeWalls.Quadrant2);
					break;
				case MazeBuildingDirections.West:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.WestTop | MazeWalls.WestMiddle | MazeWalls.WestBottom | MazeWalls.Quadrant4 | MazeWalls.Quadrant3);
					break;
				case MazeBuildingDirections.East:
					this.blocks[point.X, point.Y].Walls &= ~(MazeWalls.EastTop | MazeWalls.EastMiddle | MazeWalls.EastBottom | MazeWalls.Quadrant1 | MazeWalls.Quadrant2);
					break;
				}
			}
		}
	}
	/** <summary> Gets if the specified quadrant is restricted from generation. </summary> */
	public bool IsRestricted(Point point) {
		MazeBlock block = GetNormalBlock(new Point(point.X / 2, point.Y / 2));
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0)
				return block.Restrictions.HasFlag(MazeWalls.Quadrant4);
			else
				return block.Restrictions.HasFlag(MazeWalls.Quadrant1);
		}
		else {
			if (point.X % 2 == 0)
				return block.Restrictions.HasFlag(MazeWalls.Quadrant3);
			else
				return block.Restrictions.HasFlag(MazeWalls.Quadrant2);
		}
	}
	/** <summary> Sets the restriction from the generator using this quadrant. </summary> */
	public void SetRestricted(Point point, bool restrict) {
		MazeBlock block = GetNormalBlock(new Point(point.X / 2, point.Y / 2));
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0) {
				if (restrict) block.Restrictions |= MazeWalls.Quadrant4;
				else block.Restrictions &= ~MazeWalls.Quadrant4;
			}
			else {
				if (restrict) block.Restrictions |= MazeWalls.Quadrant1;
				else block.Restrictions &= ~MazeWalls.Quadrant1;
			}
		}
		else {
			if (point.X % 2 == 0) {
				if (restrict) block.Restrictions |= MazeWalls.Quadrant3;
				else block.Restrictions &= ~MazeWalls.Quadrant3;
			}
			else {
				if (restrict) block.Restrictions |= MazeWalls.Quadrant2;
				else block.Restrictions &= ~MazeWalls.Quadrant2;
			}
		}
	}

	/** <summary> Sets the position of the entrance. </summary> */
	public void SetEntrance(Point point) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					MazeBlock block = this.blocks[x, y];
					if (block.IsEntrance) {
						SetBlockSolid(new Point(x, y), false);
					}
				}
			}
			SetBlockSolid(placePoint, true);
			GetBlock(placePoint).Walls = MazeWalls.Entrance | (MazeWalls)placeDirection;
			MazeBlock sideBlock;
			switch (placeDirection) {
			case MazeBuildingDirections.North:
				sideBlock = GetNormalBlock(new Point(placePoint.X, placePoint.Y + 1));
				sideBlock.Walls &= ~(MazeWalls.NorthLeft | MazeWalls.NorthMiddle | MazeWalls.NorthRight | MazeWalls.Quadrant4 | MazeWalls.Quadrant1);
				break;
			case MazeBuildingDirections.South:
				sideBlock = GetNormalBlock(new Point(placePoint.X, placePoint.Y - 1));
				sideBlock.Walls &= ~(MazeWalls.SouthLeft | MazeWalls.SouthMiddle | MazeWalls.SouthRight | MazeWalls.Quadrant3 | MazeWalls.Quadrant2);
				break;
			case MazeBuildingDirections.West:
				sideBlock = GetNormalBlock(new Point(placePoint.X + 1, placePoint.Y));
				sideBlock.Walls &= ~(MazeWalls.WestTop | MazeWalls.WestMiddle | MazeWalls.WestBottom | MazeWalls.Quadrant4 | MazeWalls.Quadrant3);
				break;
			case MazeBuildingDirections.East:
				sideBlock = GetNormalBlock(new Point(placePoint.X - 1, placePoint.Y));
				sideBlock.Walls &= ~(MazeWalls.EastTop | MazeWalls.EastMiddle | MazeWalls.EastBottom | MazeWalls.Quadrant1 | MazeWalls.Quadrant2);
				break;
			}
		}
	}
	/** <summary> Sets the position of the exit. </summary> */
	public void SetExit(Point point) {
		if (point.X >= 0 && point.X < this.blocks.GetLength(0) &&
			point.Y >= 0 && point.Y < this.blocks.GetLength(1)) {
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					MazeBlock block = this.blocks[x, y];
					if (block.IsExit) {
						SetBlockSolid(new Point(x, y), false);
					}
				}
			}
			SetBlockSolid(placePoint, true);
			GetBlock(placePoint).Walls = MazeWalls.Exit | (MazeWalls)placeDirection;
			MazeBlock sideBlock;
			switch (placeDirection) {
			case MazeBuildingDirections.North:
				sideBlock = GetNormalBlock(new Point(placePoint.X, placePoint.Y + 1));
				sideBlock.Walls &= ~(MazeWalls.NorthLeft | MazeWalls.NorthMiddle | MazeWalls.NorthRight | MazeWalls.Quadrant4 | MazeWalls.Quadrant1);
				break;
			case MazeBuildingDirections.South:
				sideBlock = GetNormalBlock(new Point(placePoint.X, placePoint.Y - 1));
				sideBlock.Walls &= ~(MazeWalls.SouthLeft | MazeWalls.SouthMiddle | MazeWalls.SouthRight | MazeWalls.Quadrant3 | MazeWalls.Quadrant2);
				break;
			case MazeBuildingDirections.West:
				sideBlock = GetNormalBlock(new Point(placePoint.X + 1, placePoint.Y));
				sideBlock.Walls &= ~(MazeWalls.WestTop | MazeWalls.WestMiddle | MazeWalls.WestBottom | MazeWalls.Quadrant4 | MazeWalls.Quadrant3);
				break;
			case MazeBuildingDirections.East:
				sideBlock = GetNormalBlock(new Point(placePoint.X - 1, placePoint.Y));
				sideBlock.Walls &= ~(MazeWalls.EastTop | MazeWalls.EastMiddle | MazeWalls.EastBottom | MazeWalls.Quadrant1 | MazeWalls.Quadrant2);
				break;
			}
		}
	}

	/** <summary> Gets if the specified wall is solid. </summary> */
	public bool IsWallXSolid(Point point) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return true;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.WestMiddle);
			else
				return block.Walls.HasFlag(MazeWalls.EastMiddle);
		}
		else {
			if (point.X % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.SouthLeft);
			else
				return block.Walls.HasFlag(MazeWalls.SouthRight);
		}
	}
	/** <summary> Sets if the specified wall is solid. </summary> */
	public void SetWallXSolid(Point point, bool solid) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (block.Empty || block.IsEntrance || block.IsExit)
			return;
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0 && GetBlock(new Point(point.X / 2 - 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.West) {
				if (solid) block.Walls |= MazeWalls.WestMiddle;
				else block.Walls &= ~(MazeWalls.WestMiddle | MazeWalls.Quadrant4 | MazeWalls.Quadrant3);
			}
			else if (point.X % 2 == 1 && GetBlock(new Point(point.X / 2 + 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.East) {
				if (solid) block.Walls |= MazeWalls.EastMiddle;
				else block.Walls &= ~(MazeWalls.EastMiddle | MazeWalls.Quadrant1 | MazeWalls.Quadrant2);
			}
		}
		else if (!GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Empty) {
			if (point.X % 2 == 0) {
				if (solid) {
					block.Walls |= MazeWalls.SouthLeft;
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls |= MazeWalls.NorthLeft;
				}
				else {
					block.Walls &= ~(MazeWalls.SouthLeft | MazeWalls.Quadrant3);
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls &= ~(MazeWalls.NorthLeft | MazeWalls.Quadrant4);
				}
			}
			else {
				if (solid) {
					block.Walls |= MazeWalls.SouthRight;
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls |= MazeWalls.NorthRight;
				}
				else {
					block.Walls &= ~(MazeWalls.SouthRight | MazeWalls.Quadrant2);
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls &= ~(MazeWalls.NorthRight | MazeWalls.Quadrant1);
				}
			}
		}
	}
	/** <summary> Gets if the specified wall is solid. </summary> */
	public bool IsWallYSolid(Point point) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return true;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (point.X % 2 == 0) {
			if (point.Y % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.NorthMiddle);
			else
				return block.Walls.HasFlag(MazeWalls.SouthMiddle);
		}
		else {
			if (point.Y % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.EastTop);
			else
				return block.Walls.HasFlag(MazeWalls.EastBottom);
		}
	}
	/** <summary> Sets if the specified wall is solid. </summary> */
	public void SetWallYSolid(Point point, bool solid) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (block.Empty || block.IsEntrance || block.IsExit)
			return;
		if (point.X % 2 == 0) {
			if (point.Y % 2 == 0 && GetBlock(new Point(point.X / 2, point.Y / 2 - 1)).BuildingDirection != MazeBuildingDirections.North) {
				if (solid) block.Walls |= MazeWalls.NorthMiddle;
				else block.Walls &= ~(MazeWalls.NorthMiddle | MazeWalls.Quadrant4 | MazeWalls.Quadrant1);
			}
			else if (point.Y % 2 == 1 && GetBlock(new Point(point.X / 2, point.Y / 2 + 1)).BuildingDirection != MazeBuildingDirections.South) {
				if (solid) block.Walls |= MazeWalls.SouthMiddle;
				else block.Walls &= ~(MazeWalls.SouthMiddle | MazeWalls.Quadrant3 | MazeWalls.Quadrant2);
			}
		}
		else if (!GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Empty) {
			if (point.Y % 2 == 0) {
				if (solid) {
					
					block.Walls |= MazeWalls.EastTop;
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls |= MazeWalls.WestTop;
				}
				else {
					block.Walls &= ~(MazeWalls.EastTop | MazeWalls.Quadrant1);
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls &= ~(MazeWalls.WestTop | MazeWalls.Quadrant4);
				}
			}
			else {
				if (solid) {
					block.Walls |= MazeWalls.EastBottom;
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls |= MazeWalls.WestBottom;
				}
				else {
					block.Walls &= ~(MazeWalls.EastBottom | MazeWalls.Quadrant2);
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls &= ~(MazeWalls.WestBottom | MazeWalls.Quadrant3);
				}
			}
		}
	}
	/** <summary> Gets if the specified quadrant is solid. </summary> */
	public bool IsQuadrantSolid(Point point) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return true;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.Quadrant4);
			else
				return block.Walls.HasFlag(MazeWalls.Quadrant1);
		}
		else {
			if (point.X % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.Quadrant3);
			else
				return block.Walls.HasFlag(MazeWalls.Quadrant2);
		}
	}
	/** <summary> Sets if the specified quadrant is solid. </summary> */
	public void SetQuadrantSolid(Point point, bool solid, bool surroundingWalls = false) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (block.Empty || block.IsEntrance || block.IsExit)
			return;
		bool valid = true;
		if (point.Y % 2 == 0 && GetBlock(new Point(point.X / 2, point.Y / 2 - 1)).BuildingDirection != MazeBuildingDirections.North) {
			if (point.X % 2 == 0 && GetBlock(new Point(point.X / 2 - 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.West) {
				if (solid) block.Walls |= MazeWalls.Quadrant4;
				else block.Walls &= ~MazeWalls.Quadrant4;
			}
			else if (point.X % 2 == 1 && GetBlock(new Point(point.X / 2 + 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.East) {
				if (solid) block.Walls |= MazeWalls.Quadrant1;
				else block.Walls &= ~MazeWalls.Quadrant1;
			}
			else {
				valid = false;
			}
		}
		else if (point.Y % 2 == 1 && GetBlock(new Point(point.X / 2, point.Y / 2 + 1)).BuildingDirection != MazeBuildingDirections.South) {
			if (point.X % 2 == 0 && GetBlock(new Point(point.X / 2 - 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.West) {
				if (solid) block.Walls |= MazeWalls.Quadrant3;
				else block.Walls &= ~MazeWalls.Quadrant3;
			}
			else if (point.X % 2 == 1 && GetBlock(new Point(point.X / 2 + 1, point.Y / 2)).BuildingDirection != MazeBuildingDirections.East) {
				if (solid) block.Walls |= MazeWalls.Quadrant2;
				else block.Walls &= ~MazeWalls.Quadrant2;
			}
			else {
				valid = false;
			}
		}
		if (solid && (valid || surroundingWalls)) {
			SetWallXSolid(point, true); SetWallXSolid(Point.Add(point, new Size(0, -1)), true);
			SetWallYSolid(point, true); SetWallYSolid(Point.Add(point, new Size(-1, 0)), true);
		}
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	[Browsable(true)][Category("Appearance")]
	[DisplayName("Show Grid")][Description("")]
	public bool ShowGrid {
		get { return this.drawGrid; }
		set {
			this.drawGrid = value;
			this.Invalidate();
		}
	}

	public string[] MazeErrors {
		get {
			string entranceMessage = "";
			string exitMessage = "";
			int entranceError = 2;
			int exitError = 2;
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					MazeBlock block = this.blocks[x, y];
					if (block.IsEntrance) {
						entranceError = 0;
						switch (block.BuildingDirection) {
						case MazeBuildingDirections.North: if (GetNormalBlock(new Point(x, y + 1)).Empty) entranceError = 1; break;
						case MazeBuildingDirections.East: if (GetNormalBlock(new Point(x - 1, y)).Empty) entranceError = 1; break;
						case MazeBuildingDirections.South: if (GetNormalBlock(new Point(x, y - 1)).Empty) entranceError = 1; break;
						case MazeBuildingDirections.West: if (GetNormalBlock(new Point(x + 1, y)).Empty) entranceError = 1; break;
						}
					}
					else if (block.IsExit) {
						exitError = 0;
						switch (block.BuildingDirection) {
						case MazeBuildingDirections.North: if (GetNormalBlock(new Point(x, y + 1)).Empty) exitError = 1; break;
						case MazeBuildingDirections.East: if (GetNormalBlock(new Point(x - 1, y)).Empty) exitError = 1; break;
						case MazeBuildingDirections.South: if (GetNormalBlock(new Point(x, y - 1)).Empty) exitError = 1; break;
						case MazeBuildingDirections.West: if (GetNormalBlock(new Point(x + 1, y)).Empty) exitError = 1; break;
						}
					}
				}
			}
			if (entranceError == 1)
				entranceMessage = "Entrance needs to be connected to maze.";
			else if (entranceError == 2)
				entranceMessage = "No entrance in maze.";
			if (exitError == 1)
				exitMessage = "Exit needs to be connected to maze.";
			else if (exitError == 2)
				exitMessage = "No exit in maze.";

			if (entranceError != 0) {
				if (exitError != 0)
					return new string[] { entranceMessage, exitMessage };
				else
					return new string[] { entranceMessage };
			}
			else if (exitError != 0) {
				return new string[] { exitMessage };
			}
			else {
				return new string[0];
			}
		}
	}

	/** <summary> Gets the maze blocks. </summary> */
	public MazeBlock[,] Blocks {
		get { return this.blocks; }
	}

	public PlaceModes PlaceMode {
		get { return this.placeMode; }
		set {
			this.placeMode = value;
			this.Invalidate();
		}
	}

	[Browsable(true)][Category("Appearance")]
	[DisplayName("Wall Style")][Description("")]
	public WallStyles WallStyle {
		get { return this.wallStyle; }
		set {
			this.wallStyle = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Walls Make Tiles")][Description("")]
	public bool WallsMakeTiles {
		get { return this.wallsMakeTiles; }
		set { this.wallsMakeTiles = value; }
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Maze Size")][Description("")]
	public Size MazeSize {
		get { return new Size(this.blocks.GetLength(0), this.blocks.GetLength(1)); }
		set {
			MazeBlock[,] newBlocks = new MazeBlock[Math.Max(1, Math.Min(MaxMazeSize.Width, value.Width)), Math.Max(1, Math.Min(MaxMazeSize.Height, value.Height))];
			for (int x = 0; x < newBlocks.GetLength(0); x++) {
				for (int y = 0; y < newBlocks.GetLength(1); y++) {
					if (x < this.blocks.GetLength(0) && y < this.blocks.GetLength(1))
						newBlocks[x, y] = this.blocks[x, y];
					else
						newBlocks[x, y] = new MazeBlock();
				}
			}
			this.blocks = newBlocks;
			this.Width = this.blocks.GetLength(0) * (this.pathWidth * 2 + this.wallWidth * 4);
			this.Height = this.blocks.GetLength(1) * (this.pathWidth * 2 + this.wallWidth * 4);
			this.Invalidate();
		}
	}

	#endregion
	//============ EVENTS ============
	#region Events

	/** <summary> Raises the MazeChanged event. </summary> */
	protected void OnMazeChanged(EventArgs e) {
		if (this.MazeChanged != null)
			this.MazeChanged(this, e);
	}
	/** <summary> Called when the mouse button is down. </summary> */
	protected override void OnMouseDown(MouseEventArgs e) {
		if (placeMode == PlaceModes.Walls) {
			if (hoverType != MazeWallTypes.None) {
				bool addWall = (e.Button == MouseButtons.Right);
				if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
					if (/*e.Button == MouseButtons.Left && */wallsMakeTiles) {
						if (GetBlock(new Point(hoverPoint.X / 2, hoverPoint.Y / 2)).Empty) {
							SetBlockSolid(new Point(hoverPoint.X / 2, hoverPoint.Y / 2), true);
						}
						else if (hoverType == MazeWallTypes.WallX && hoverPoint.Y % 2 == 1 &&
							GetBlock(new Point(hoverPoint.X / 2, hoverPoint.Y / 2 + 1)).Empty) {
							SetBlockSolid(new Point(hoverPoint.X / 2, hoverPoint.Y / 2 + 1), true);
						}
						else if (hoverType == MazeWallTypes.WallY && hoverPoint.X % 2 == 1 &&
							GetBlock(new Point(hoverPoint.X / 2 + 1, hoverPoint.Y / 2)).Empty) {
							SetBlockSolid(new Point(hoverPoint.X / 2 + 1, hoverPoint.Y / 2), true);
						}
					}
					//if (!GetBlock(new Point(hoverPoint.X / 2, hoverPoint.Y / 2)).Empty || e.Button == MouseButtons.Left || wallsMakeTiles) {
						switch (hoverType) {
						case MazeWallTypes.WallX: SetWallXSolid(hoverPoint, addWall); break;
						case MazeWallTypes.WallY: SetWallYSolid(hoverPoint, addWall); break;
						case MazeWallTypes.Quadrant: SetQuadrantSolid(hoverPoint, addWall); break;
						}
						OnMazeChanged(new EventArgs());
					//}
				}
			}
		}
		else if (placeMode == PlaceModes.Tiles) {
			Point point = new Point(e.X / (this.pathWidth * 2 + this.wallWidth * 4),
									e.Y / (this.pathWidth * 2 + this.wallWidth * 4));
			if (e.Button == MouseButtons.Left && GetBlock(point).Empty) {
				SetBlockSolid(point, true);
				OnMazeChanged(new EventArgs());
			}
			else if (e.Button == MouseButtons.Right) {
				SetBlockSolid(point, false);
				OnMazeChanged(new EventArgs());
			}
		}
		else if (placeMode == PlaceModes.Entrance || placeMode == PlaceModes.Exit) {
			Point point = new Point(e.X / (this.pathWidth * 2 + this.wallWidth * 4),
									e.Y / (this.pathWidth * 2 + this.wallWidth * 4));
			if (placeDirection != MazeBuildingDirections.None && e.Button == MouseButtons.Left) {
				if (placeMode == PlaceModes.Entrance)
					SetEntrance(point);
					OnMazeChanged(new EventArgs());
				if (placeMode == PlaceModes.Exit)
					SetExit(point);
					OnMazeChanged(new EventArgs());
			}
			else if (e.Button == MouseButtons.Right) {
				if (GetBlock(point).IsBuilding) {
					SetBlockSolid(point, false);
					OnMazeChanged(new EventArgs());
				}
			}
		}
		else if (placeMode == PlaceModes.Generate) {
			if (IsNormalBlock(new Point(generatePoint.X / 2, generatePoint.Y / 2))) {
				if (IsQuadrantSolid(generatePoint) && !IsRestricted(generatePoint)) {
					// StartGeneration(generatePoint);
				}
			}
		}
		else if (placeMode == PlaceModes.Restrict) {
			if (e.Button == MouseButtons.Left) {
				SetRestricted(this.generatePoint, true);
			}
			else if (e.Button == MouseButtons.Right) {
				SetRestricted(this.generatePoint, false);
			}
		}
		base.OnMouseDown(e);
	}
	/** <summary> Called when the mouse button is up. </summary> */
	protected override void OnMouseUp(MouseEventArgs e) {
		
		base.OnMouseUp(e);
	}
	/** <summary> Called when the mouse is hovering. </summary> */
	protected override void OnMouseMove(MouseEventArgs e) {
		Point mousePos = new Point(e.X - this.wallWidth, e.Y - this.wallWidth);
		this.hoverPoint = new Point(mousePos.X / (this.pathWidth + this.wallWidth * 2),
									mousePos.Y / (this.pathWidth + this.wallWidth * 2));
		Point offset = new Point(mousePos.X % (this.pathWidth + this.wallWidth * 2),
								 mousePos.Y % (this.pathWidth + this.wallWidth * 2));
		if (offset.X < this.pathWidth) {
			if (offset.Y < this.pathWidth)
				this.hoverType = MazeWallTypes.Quadrant;
			else
				this.hoverType = MazeWallTypes.WallX;
		}
		else {
			if (offset.Y < this.pathWidth)
				this.hoverType = MazeWallTypes.WallY;
			else
				this.hoverType = MazeWallTypes.None;
		}
		if (this.wallsMakeTiles) {
			if (GetBlock(new Point(this.hoverPoint.X / 2, this.hoverPoint.Y / 2)).IsBuilding ||
				((this.hoverType == MazeWallTypes.WallX && GetBlock(new Point(this.hoverPoint.X / 2, (this.hoverPoint.Y + 1) / 2)).IsBuilding) ||
				(this.hoverType == MazeWallTypes.WallY && GetBlock(new Point((this.hoverPoint.X + 1) / 2, this.hoverPoint.Y / 2)).IsBuilding))) {
				this.hoverType = MazeWallTypes.None;
			}
		}
		else {
			if (!IsNormalBlock(new Point(this.hoverPoint.X / 2, this.hoverPoint.Y / 2)) ||
				((this.hoverType == MazeWallTypes.WallX && !IsNormalBlock(new Point(this.hoverPoint.X / 2, (this.hoverPoint.Y + 1) / 2))) ||
				(this.hoverType == MazeWallTypes.WallY && !IsNormalBlock(new Point((this.hoverPoint.X + 1) / 2, this.hoverPoint.Y / 2))))) {
				this.hoverType = MazeWallTypes.None;
			}
		}

		this.generatePoint = new Point(e.X / (this.pathWidth + this.wallWidth * 2),
									   e.Y / (this.pathWidth + this.wallWidth * 2));

		int TW = this.pathWidth * 2 + this.wallWidth * 4;
		int HW = this.pathWidth + this.wallWidth * 2;
		this.placePoint = new Point(e.X / (this.pathWidth * 2 + this.wallWidth * 4),
									e.Y / (this.pathWidth * 2 + this.wallWidth * 4));
		Point dirPoint = new Point(e.X % (this.pathWidth * 2 + this.wallWidth * 4),
									e.Y % (this.pathWidth * 2 + this.wallWidth * 4));
		if (dirPoint.X + dirPoint.Y < TW) {
			if (dirPoint.X >= dirPoint.Y)
				this.placeDirection = MazeBuildingDirections.South;
			else
				this.placeDirection = MazeBuildingDirections.East;
		}
		else {
			if (dirPoint.X >= dirPoint.Y)
				this.placeDirection = MazeBuildingDirections.West;
			else
				this.placeDirection = MazeBuildingDirections.North;

		}
		if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
			OnMouseDown(e);
		}
		this.Invalidate();

		base.OnMouseMove(e);
	}
	/** <summary> Called when the mouse leaves the control. </summary> */
	protected override void OnMouseLeave(EventArgs e) {
		this.placePoint = new Point(-1, -1);
		this.generatePoint = new Point(-1, -1);
		this.hoverPoint = new Point(-1, -1);
		this.hoverType = MazeWallTypes.None;
		this.Invalidate();
		base.OnMouseLeave(e);
	}
	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		int P = this.pathWidth;
		int W = this.wallWidth;
		int WW = P + W * 3;
		int WO = P + W * 1;
		int WO2 = P * 2 + W * 3;
		int PO = P + W * 3;
		int TW = P * 2 + W * 4;
		int HW = P + W * 2;

		for (int x = 0; x < this.blocks.GetLength(0); x++) {
			for (int y = 0; y < this.blocks.GetLength(1); y++) {
				MazeBlock block = this.blocks[x, y];
				Point pos = new Point(x * (P * 2 + W * 4),
									  y * (P * 2 + W * 4));

				if (block.Empty) {
					Pen p = new Pen(GrassOutlineColor);
					g.DrawRectangle(p, new Rectangle(pos.X, pos.Y, TW - 1, TW - 1));
					p.Dispose();
				}
				else if (block.IsEntrance || block.IsExit) {
					Brush b = new SolidBrush(BuildingColor);
					g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
					b.Dispose();
					if (block.IsEntrance) {
						b = new SolidBrush(BuildingColor2);
						g.FillRectangle(b, new Rectangle(pos.X + W + P /2, pos.Y + W + P /2, P + W*2, P + W*2));
						b.Dispose();
					}
					b = new SolidBrush(BuildingOutlineColor);
					g.FillRectangle(b, new Rectangle(pos.X, pos.Y, TW, W));
					g.FillRectangle(b, new Rectangle(pos.X, pos.Y, W, TW));
					g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO2, TW, W));
					g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y, W, TW));
					b.Dispose();
					b = new SolidBrush(BuildingDoorColor);
					switch (block.BuildingDirection) {
					case MazeBuildingDirections.South: g.FillRectangle(b, new Rectangle(pos.X + (TW - P) / 2, pos.Y, P, P)); break;
					case MazeBuildingDirections.East: g.FillRectangle(b, new Rectangle(pos.X, pos.Y + (TW - P) / 2, P, P)); break;
					case MazeBuildingDirections.North: g.FillRectangle(b, new Rectangle(pos.X + (TW - P) / 2, pos.Y + TW - P, P, P)); break;
					case MazeBuildingDirections.West: g.FillRectangle(b, new Rectangle(pos.X + TW - P, pos.Y + (TW - P) / 2, P, P)); break;
					}
					b.Dispose();
				}
				else {
					Brush b = new SolidBrush(PathColor);
					g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
					b.Dispose();

					b = new SolidBrush(WallColors[(int)wallStyle]);
					if (block.Walls.HasFlag(MazeWalls.Quadrant1))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + W, P, P));
					if (block.Walls.HasFlag(MazeWalls.Quadrant2))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + PO, P, P));
					if (block.Walls.HasFlag(MazeWalls.Quadrant3))
						g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + PO, P, P));
					if (block.Walls.HasFlag(MazeWalls.Quadrant4))
						g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + W, P, P));

					if (block.Walls.HasFlag(MazeWalls.NorthLeft))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, WW, W));
					if (block.Walls.HasFlag(MazeWalls.NorthMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y, W*2, WW));
					if (block.Walls.HasFlag(MazeWalls.NorthRight))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y, WW, W));

					if (block.Walls.HasFlag(MazeWalls.SouthLeft))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO2, WW, W));
					if (block.Walls.HasFlag(MazeWalls.SouthMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO, W*2, WW));
					if (block.Walls.HasFlag(MazeWalls.SouthRight))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO2, WW, W));

					if (block.Walls.HasFlag(MazeWalls.EastTop))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y, W, WW));
					if (block.Walls.HasFlag(MazeWalls.EastMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO, WW, W*2));
					if (block.Walls.HasFlag(MazeWalls.EastBottom))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y + WO, W, WW));

					if (block.Walls.HasFlag(MazeWalls.WestTop))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, W, WW));
					if (block.Walls.HasFlag(MazeWalls.WestMiddle))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO, WW, W*2));
					if (block.Walls.HasFlag(MazeWalls.WestBottom))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO, W, WW));

					if (IsWallXSolid(new Point(x * 2 - 1, y * 2 - 1)) || IsWallYSolid(new Point(x * 2 - 1, y * 2 - 1)))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, W, W));
					if (IsWallXSolid(new Point(x * 2 + 2, y * 2 - 1)) || IsWallYSolid(new Point(x * 2 + 1, y * 2 - 1)))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y, W, W));
					if (IsWallXSolid(new Point(x * 2 - 1, y * 2 + 1)) || IsWallYSolid(new Point(x * 2 - 1, y * 2 + 2)))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO2, W, W));
					if (IsWallXSolid(new Point(x * 2 + 2, y * 2 + 1)) || IsWallYSolid(new Point(x * 2 + 1, y * 2 + 2)))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y + WO2, W, W));

					if (IsWallXSolid(new Point(x * 2 - 1, y * 2)))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO, W, W * 2));
					if (IsWallYSolid(new Point(x * 2, y * 2 - 1)))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y, W * 2, W));
					if (IsWallXSolid(new Point(x * 2 + 2, y * 2)))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y + WO, W, W * 2));
					if (IsWallYSolid(new Point(x * 2, y * 2 + 2)))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO2, W * 2, W));

					b.Dispose();

					b = new SolidBrush(RestrictColor);
					if (block.Restrictions.HasFlag(MazeWalls.Quadrant1))
						g.FillRectangle(b, new Rectangle(pos.X + HW, pos.Y, HW, HW));
					if (block.Restrictions.HasFlag(MazeWalls.Quadrant2))
						g.FillRectangle(b, new Rectangle(pos.X + HW, pos.Y + HW, HW, HW));
					if (block.Restrictions.HasFlag(MazeWalls.Quadrant3))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + HW, HW, HW));
					if (block.Restrictions.HasFlag(MazeWalls.Quadrant4))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, HW, HW));

					b.Dispose();
				}
			}
		}

		if (placeMode == PlaceModes.Walls) {
			if (hoverType != MazeWallTypes.None) {
				int PW2 = (pathWidth + wallWidth * 2);
				int W2 =  wallWidth * 2;
				Brush b = new SolidBrush(HighlightColor);
				switch (hoverType) {
				case MazeWallTypes.WallX:
					g.FillRectangle(b, new Rectangle(W + hoverPoint.X * PW2, W + hoverPoint.Y * PW2 + P, P, W2));
					break;
				case MazeWallTypes.WallY:
					g.FillRectangle(b, new Rectangle(W + hoverPoint.X * PW2 + P, W + hoverPoint.Y * PW2, W2, P));
					break;
				case MazeWallTypes.Quadrant:
					g.FillRectangle(b, new Rectangle(W + hoverPoint.X * PW2, W + hoverPoint.Y * PW2, P, P));
					break;
				}
				b.Dispose();
			}
		}
		else if (placeMode == PlaceModes.Tiles) {
			Brush b = new SolidBrush(HighlightColor);
			g.FillRectangle(b, new Rectangle(placePoint.X * TW, placePoint.Y * TW, TW, TW));
			b.Dispose();
		}
		else if (placeMode == PlaceModes.Restrict) {
			if (IsNormalBlock(new Point(generatePoint.X / 2, generatePoint.Y / 2))) {
				Brush b = new SolidBrush(RestrictColor);
				g.FillRectangle(b, new Rectangle(generatePoint.X * HW, generatePoint.Y * HW, HW, HW));
				b.Dispose();
			}
		}
		else if (placeMode == PlaceModes.Generate) {
			if (IsNormalBlock(new Point(generatePoint.X / 2, generatePoint.Y / 2))) {
				if (IsQuadrantSolid(generatePoint) && !IsRestricted(generatePoint)) {
					Brush b = new SolidBrush(GenerateColor);
					g.FillRectangle(b, new Rectangle(generatePoint.X * HW, generatePoint.Y * HW, HW, HW));
					b.Dispose();
				}
			}
		}

		if (drawGrid) {
			int XL1 = (P * 2 + W * 2);
			int YL1 = (P * 2 + W * 2);
			int XL2 = (P * 2 + W * 4);
			int YL2 = (P * 2 + W * 4);
			Brush b = new SolidBrush(GridColor);
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					if (this.blocks[x, y].Empty || this.blocks[x, y].IsEntrance || this.blocks[x, y].IsExit)
						continue;
					Point pos = new Point(x * (P * 2 + W * 4), y * (P * 2 + W * 4));
					//g.FillRectangle(b, new Rectangle(pos.X - W, pos.Y, 1, YL));
					int yl = YL1;
					if (y + 1 < this.blocks.GetLength(1) && !this.blocks[x, y + 1].Empty &&
						!this.blocks[x, y + 1].IsEntrance && !this.blocks[x, y + 1].IsExit) {
						yl = YL2;
					}
					g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + W, 1, yl));
					g.FillRectangle(b, new Rectangle(pos.X + WO - 1, pos.Y + W, 1, yl));
					g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + W, 1, yl));
					g.FillRectangle(b, new Rectangle(pos.X + WO2 - 1, pos.Y + W, 1, yl));

					int xl = XL1;
					if (x + 1 < this.blocks.GetLength(0) && !this.blocks[x + 1, y].Empty &&
						!this.blocks[x + 1, y].IsEntrance && !this.blocks[x + 1, y].IsExit) {
						xl = XL2;
					}
					g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + W, xl, 1));
					g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + WO - 1, xl, 1));
					g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + PO, xl, 1));
					g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + WO2 - 1, xl, 1));
				}
			}
			b.Dispose();
		}

		if (placeMode == PlaceModes.Entrance || placeMode == PlaceModes.Exit) {
			int alpha = 100;
			Point pos = new Point(placePoint.X * (P * 2 + W * 4),
								  placePoint.Y * (P * 2 + W * 4));

			Brush b = new SolidBrush(NewColor(BuildingColor, alpha));
			g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
			b.Dispose();
			if (placeMode == PlaceModes.Entrance) {
				b = new SolidBrush(NewColor(BuildingColor2, alpha));
				g.FillRectangle(b, new Rectangle(pos.X + W + P /2, pos.Y + W + P /2, P + W*2, P + W*2));
				b.Dispose();
			}
			b = new SolidBrush(NewColor(BuildingOutlineColor, alpha));
			g.FillRectangle(b, new Rectangle(pos.X, pos.Y, TW, W));
			g.FillRectangle(b, new Rectangle(pos.X, pos.Y, W, TW));
			g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO2, TW, W));
			g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y, W, TW));
			b.Dispose();
			b = new SolidBrush(NewColor(BuildingDoorColor, alpha));
			switch (placeDirection) {
			case MazeBuildingDirections.South: g.FillRectangle(b, new Rectangle(pos.X + (TW - P) / 2, pos.Y, P, P)); break;
			case MazeBuildingDirections.East: g.FillRectangle(b, new Rectangle(pos.X, pos.Y + (TW - P) / 2, P, P)); break;
			case MazeBuildingDirections.North: g.FillRectangle(b, new Rectangle(pos.X + (TW - P) / 2, pos.Y + TW - P, P, P)); break;
			case MazeBuildingDirections.West: g.FillRectangle(b, new Rectangle(pos.X + TW - P, pos.Y + (TW - P) / 2, P, P)); break;
			}
			b.Dispose();
		}
	}

	private Color NewColor(Color color, int alpha) {
		return Color.FromArgb(alpha, color.R, color.G, color.B);
	}

	#endregion
}
public class MazeBlock {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The walls which are set on the maze tile. </summary> */
	public MazeWalls Walls;
	/** <summary> The quadrants that are restricted from generation. </summary> */
	public MazeWalls Restrictions;
	/** <summary> True if this block does not show up on the grid. </summary> */
	public bool Empty;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default maze block. </summary> */
	public MazeBlock() {
		this.Walls = MazeWalls.All;
		this.Restrictions = MazeWalls.None;
		this.Empty = true;
	}
	/** <summary> Constructs the default maze block. </summary> */
	public MazeBlock(MazeWalls walls, bool empty = false) {
		this.Walls = walls;
		this.Restrictions = MazeWalls.None;
		this.Empty = empty;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> True if the entrance is on this tile. </summary> */
	public bool IsEntrance {
		get {
			return (Walls == MazeWalls.EntranceWest ||
					Walls == MazeWalls.EntranceNorth ||
					Walls == MazeWalls.EntranceEast ||
					Walls == MazeWalls.EntranceSouth);
		}
	}
	/** <summary> True if the exit is on this tile. </summary> */
	public bool IsExit {
		get {
			return (Walls == MazeWalls.ExitWest ||
					Walls == MazeWalls.ExitNorth ||
					Walls == MazeWalls.ExitEast ||
					Walls == MazeWalls.ExitSouth);
		}
	}
	/** <summary> True if the exit is on this tile. </summary> */
	public bool IsBuilding {
		get {
			return (IsEntrance || IsExit);
		}
	}
	/** <summary> Gets the direction the building on this tile is facing. </summary> */
	public MazeBuildingDirections BuildingDirection {
		get {
			if (!IsEntrance && !IsExit)
				return MazeBuildingDirections.None;
			return (MazeBuildingDirections)((uint)Walls & 0x000F);
		}
	}

	#endregion
}
public enum MazeWallTypes {
	None = 0,
	WallX = 1,
	WallY = 2,
	Quadrant = 3
}
public enum WallStyles {
	BrickWalls = 0,
	Hedges = 1,
	IceBlocks = 2,
	WoodenFences = 3
}
public enum PlaceModes {
	Walls = 0,
	Tiles = 1,
	Entrance = 2,
	Exit = 3,
	Generate = 4,
	Restrict = 5
}
}
