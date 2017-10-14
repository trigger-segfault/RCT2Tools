using RCT2ObjectData.Objects;
using RCT2ObjectData.Objects.Types.AttractionInfo;
using RCT2ObjectData.Track;
using RCT2PaletteConverter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2PaletteConverter {
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

	public static Color[] WallColors = new Color[]{
		Color.FromArgb(23, 35, 35), // Brick Walls
		Color.FromArgb(115, 155, 67), // Hedges
		Color.FromArgb(175, 231, 251), // Ice Blocks
		Color.FromArgb(203, 175, 111) // Wood Fences
	};

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The grid for the maze. </summary> */
	private MazeBlock[,] blocks;

	private int pathWidth;
	private int wallWidth;

	private int wallStyle;

	private bool drawGrid;

	private MazeWallTypes hoverType;
	private Point hoverPoint;
	

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
		this.wallStyle = 1;
		this.drawGrid = true;

		this.hoverType = MazeWallTypes.None;
		this.hoverPoint = Point.Empty;
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
		MazeBlock[,] newBlocks = new MazeBlock[Math.Max(1, newSize.Width), Math.Max(1, newSize.Height)];
		for (int x = 0; x < newBlocks.GetLength(0); x++) {
			for (int y = 0; y < newBlocks.GetLength(1); y++) {
				if (x < this.blocks.GetLength(0) && y < this.blocks.GetLength(1))
					newBlocks[x, y] = this.blocks[x, y];
				else
					newBlocks[x, y] = new MazeBlock();
			}
		}
		this.blocks = newBlocks;
		this.Invalidate();
	}
	/** <summary> Translates the maze by the specified distance. </summary> */
	public void TranslateMaze(Point distance) {
		MazeBlock[,] newBlocks = new MazeBlock[this.blocks.GetLength(0), this.blocks.GetLength(1)];
		for (int x = 0; x < newBlocks.GetLength(0); x++) {
			for (int y = 0; y < newBlocks.GetLength(1); y++) {
				if (x - distance.X < this.blocks.GetLength(0) && y - distance.Y < this.blocks.GetLength(1))
					newBlocks[x, y] = this.blocks[x - distance.X, y - distance.Y];
				else
					newBlocks[x, y] = new MazeBlock();
			}
		}
		this.blocks = newBlocks;
		this.Invalidate();
	}
	/** <summary> Loads the specified maze into the editor. </summary> */
	public void LoadMaze(TrackDesign maze) {
		if (maze.TrackType == TrackTypes.HedgeMaze) {
			for (int x = 0; x < this.blocks.GetLength(0); x++) {
				for (int y = 0; y < this.blocks.GetLength(1); y++) {
					this.blocks[x, y] = new MazeBlock();
				}
			}

			Point offset = Point.Empty;
			for (int i = 0; i < maze.MazeTiles.Count; i++) {
				MazeTile tile = maze.MazeTiles[i];
				if (tile.X < 0 && -tile.X > offset.X)
					offset.X = -tile.X;
				if (tile.Y < 0 && -tile.Y > offset.Y)
					offset.Y = -tile.Y;
			}

			for (int i = 0; i < maze.MazeTiles.Count; i++) {
				MazeTile tile = maze.MazeTiles[i];
				this.blocks[tile.X + offset.X, tile.Y + offset.Y] = new MazeBlock(tile.Walls, false);
			}
			this.wallStyle = (int)maze.TrackSupportColors[0];
			this.Invalidate();
		}
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
			this.blocks[point.X, point.Y].Empty = !solid;
			this.blocks[point.X, point.Y].Walls = MazeWalls.All;
			SetQuadrantSolid(new Point(point.X * 2, point.Y * 2), true);
			SetQuadrantSolid(new Point(point.X * 2 + 1, point.Y * 2), true);
			SetQuadrantSolid(new Point(point.X * 2, point.Y * 2 + 1), true);
			SetQuadrantSolid(new Point(point.X * 2 + 1, point.Y * 2 + 1), true);
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
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0) {
				if (solid) block.Walls |= MazeWalls.WestMiddle;
				else block.Walls &= ~(MazeWalls.WestMiddle | MazeWalls.QuadrantNorthWest | MazeWalls.QuadrantSouthWest);
			}
			else {
				if (solid) block.Walls |= MazeWalls.EastMiddle;
				else block.Walls &= ~(MazeWalls.EastMiddle | MazeWalls.QuadrantNorthEast | MazeWalls.QuadrantSouthEast);
			}
		}
		else {
			if (point.X % 2 == 0) {
				if (solid) {
					block.Walls |= MazeWalls.SouthLeft;
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls |= MazeWalls.NorthLeft;
				}
				else {
					block.Walls &= ~(MazeWalls.SouthLeft | MazeWalls.QuadrantSouthWest);
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls &= ~(MazeWalls.NorthLeft | MazeWalls.QuadrantNorthWest);
				}
			}
			else {
				if (solid) {
					block.Walls |= MazeWalls.SouthRight;
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls |= MazeWalls.NorthRight;
				}
				else {
					block.Walls &= ~(MazeWalls.SouthRight | MazeWalls.QuadrantSouthEast);
					GetNormalBlock(new Point(point.X / 2, point.Y / 2 + 1)).Walls &= ~(MazeWalls.NorthRight | MazeWalls.QuadrantNorthEast);
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
		if (point.X % 2 == 0) {
			if (point.Y % 2 == 0) {
				if (solid) block.Walls |= MazeWalls.NorthMiddle;
				else block.Walls &= ~(MazeWalls.NorthMiddle | MazeWalls.QuadrantNorthWest | MazeWalls.QuadrantNorthEast);
			}
			else {
				if (solid) block.Walls |= MazeWalls.SouthMiddle;
				else block.Walls &= ~(MazeWalls.SouthMiddle | MazeWalls.QuadrantSouthWest | MazeWalls.QuadrantSouthEast);
			}
		}
		else {
			if (point.Y % 2 == 0) {
				if (solid) {
					block.Walls |= MazeWalls.EastTop;
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls |= MazeWalls.WestTop;
				}
				else {
					block.Walls &= ~(MazeWalls.EastTop | MazeWalls.QuadrantNorthEast);
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls &= ~(MazeWalls.WestTop | MazeWalls.QuadrantNorthWest);
				}
			}
			else {
				if (solid) {
					block.Walls |= MazeWalls.EastBottom;
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls |= MazeWalls.WestBottom;
				}
				else {
					block.Walls &= ~(MazeWalls.EastBottom | MazeWalls.QuadrantSouthEast);
					GetNormalBlock(new Point(point.X / 2 + 1, point.Y / 2)).Walls &= ~(MazeWalls.WestBottom | MazeWalls.QuadrantSouthWest);
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
				return block.Walls.HasFlag(MazeWalls.QuadrantNorthWest);
			else
				return block.Walls.HasFlag(MazeWalls.QuadrantNorthEast);
		}
		else {
			if (point.X % 2 == 0)
				return block.Walls.HasFlag(MazeWalls.QuadrantSouthWest);
			else
				return block.Walls.HasFlag(MazeWalls.QuadrantSouthEast);
		}
	}
	/** <summary> Sets if the specified quadrant is solid. </summary> */
	public void SetQuadrantSolid(Point point, bool solid) {
		if (point.X < 0 || point.X >= this.blocks.GetLength(0) * 2 || point.Y < 0 || point.Y >= this.blocks.GetLength(1) * 2)
			return;

		MazeBlock block = this.blocks[point.X / 2, point.Y / 2];
		if (point.Y % 2 == 0) {
			if (point.X % 2 == 0) {
				if (solid) block.Walls |= MazeWalls.QuadrantNorthWest;
				else block.Walls &= ~MazeWalls.QuadrantNorthWest;
			}
			else {
				if (solid) block.Walls |= MazeWalls.QuadrantNorthEast;
				else block.Walls &= ~MazeWalls.QuadrantNorthEast;
			}
		}
		else {
			if (point.X % 2 == 0) {
				if (solid) block.Walls |= MazeWalls.QuadrantSouthWest;
				else block.Walls &= ~MazeWalls.QuadrantSouthWest;
			}
			else {
				if (solid) block.Walls |= MazeWalls.QuadrantSouthEast;
				else block.Walls &= ~MazeWalls.QuadrantSouthEast;
			}
		}
		if (solid) {
			SetWallXSolid(point, true); SetWallXSolid(Point.Add(point, new Size(0, -1)), true);
			SetWallYSolid(point, true); SetWallYSolid(Point.Add(point, new Size(-1, 0)), true);
		}
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the maze blocks. </summary> */
	public MazeBlock[,] Blocks {
		get { return this.blocks; }
	}

	[Browsable(true)][Category("Behavior")]
	[DisplayName("Maze Size")][Description("")]
	public Size MazeSize {
		get { return new Size(this.blocks.GetLength(0), this.blocks.GetLength(1)); }
		set {
			MazeBlock[,] newBlocks = new MazeBlock[Math.Max(1, value.Width), Math.Max(1, value.Height)];
			for (int x = 0; x < newBlocks.GetLength(0); x++) {
				for (int y = 0; y < newBlocks.GetLength(1); y++) {
					if (x < this.blocks.GetLength(0) && y < this.blocks.GetLength(1))
						newBlocks[x, y] = this.blocks[x, y];
					else
						newBlocks[x, y] = new MazeBlock();
				}
			}
			this.blocks = newBlocks;
			this.Invalidate();
		}
	}

	#endregion
	//============ EVENTS ============
	#region Events

	/** <summary> Called when the mouse button is down. </summary> */
	protected override void OnMouseDown(MouseEventArgs e) {
		if (hoverType != MazeWallTypes.None) {
			bool addWall = (e.Button == MouseButtons.Right);
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
				switch (hoverType) {
				case MazeWallTypes.WallX: SetWallXSolid(hoverPoint, addWall); break;
				case MazeWallTypes.WallY: SetWallYSolid(hoverPoint, addWall); break;
				case MazeWallTypes.Quadrant: SetQuadrantSolid(hoverPoint, addWall); break;
				}
			}
		}
		if (e.Button == MouseButtons.Middle) {
			Point point = new Point(e.X / (this.pathWidth * 2 + this.wallWidth * 4),
									e.Y / (this.pathWidth * 2 + this.wallWidth * 4));
			SetBlockSolid(point, GetBlock(point).Empty);
			/*MazeBlock block = GetBlock(point);
			block.Empty = !block.Empty;
			block.Walls = MazeWalls.All;*/
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
		if (!IsNormalBlock(new Point(this.hoverPoint.X / 2, this.hoverPoint.Y / 2)) ||
			((this.hoverType == MazeWallTypes.WallX && !IsNormalBlock(new Point(this.hoverPoint.X / 2, (this.hoverPoint.Y + 1) / 2))) ||
			(this.hoverType == MazeWallTypes.WallY && !IsNormalBlock(new Point((this.hoverPoint.X + 1) / 2, this.hoverPoint.Y / 2))))) {
			this.hoverType = MazeWallTypes.None;
		}
		if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
			OnMouseDown(e);
		}
		this.Invalidate();

		base.OnMouseMove(e);
	}
	/** <summary> Called when the mouse leaves the control. </summary> */
	protected override void OnMouseLeave(EventArgs e) {
		
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

					b = new SolidBrush(WallColors[wallStyle]);
					if (block.Walls.HasFlag(MazeWalls.QuadrantNorthEast))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + W, P, P));
					if (block.Walls.HasFlag(MazeWalls.QuadrantSouthEast))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + PO, P, P));
					if (block.Walls.HasFlag(MazeWalls.QuadrantSouthWest))
						g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + PO, P, P));
					if (block.Walls.HasFlag(MazeWalls.QuadrantNorthWest))
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
				}
			}
		}

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
	}

	#endregion
}
public class MazeBlock {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The walls which are set on the maze tile. </summary> */
	public MazeWalls Walls;
	/** <summary> True if this block does not show up on the grid. </summary> */
	public bool Empty;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default maze block. </summary> */
	public MazeBlock() {
		this.Walls = MazeWalls.All;
		this.Empty = true;
	}
	/** <summary> Constructs the default maze block. </summary> */
	public MazeBlock(MazeWalls walls, bool empty = false) {
		this.Walls = walls;
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
public class MazeEventArgs : EventArgs {

}
}
