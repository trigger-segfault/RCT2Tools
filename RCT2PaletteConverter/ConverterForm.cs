using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCT2ObjectData.DataObjects;
using System.IO;
using RCT2ObjectData.DataObjects.Types;
using RCT2PaletteConverter.Properties;

namespace RCT2PaletteConverter {
	public partial class ConverterForm : Form {

		Bitmap image;
		PaletteImage p;
		Terrain terrain;
		ObjectData obj;
		DrawSettings drawSettings;
		string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6";
		string MazePath2 = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\TestMaze3.TD6";
		//string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\MicroMazeReddBaron.TD6";
		//string MazePath = @"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6";

		public ConverterForm() {
			InitializeComponent();

			TrackDesign track = TrackDesign.FromFile(MazePath);
			//track.Save(MazePath2);
			//Save("");
			//track.ChainLiftSpeed = 0;
			//image = (Bitmap)Bitmap.FromFile("");
			//GraphicsData.FromFile(@"C:\Users\Jrob\My Projects\C#\RCT2Tools\ObjectData\Resources\Water.rct2imgs");
			/*GraphicsData g1 = GraphicsData.FromFile(@"C:\Program Files (x86)\GOG\Games\RollerCoaster Tycoon 2 Triple Thrill Pack\Data\g1.dat");
			
			GraphicsData waterSprites = new GraphicsData();

			waterSprites.Add(g1.GetPaletteImage(5048));
			waterSprites.Add(g1.GetPaletteImage(5053));

			waterSprites.Add(g1.GetPaletteImage(1915));

			waterSprites.Add(g1.GetPaletteImage(1579));
			waterSprites.Add(g1.GetPaletteImage(1584));

			waterSprites.Save("Water.rct2imgs");*/

			image = new Bitmap(400, 400);
			p = new PaletteImage(400, 400);

			PaletteImage dialog = new PaletteImage(112, 112);

			for (int x = 0; x < dialog.Width; x++) {
				for (int y = 0; y < dialog.Height; y++) {
					dialog.Pixels[x, y] = 150;
				}
			}

			//ObjectData obj = ObjectData.FromFile(@"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\ObjData\1A.DAT");
			/*obj = ObjectData.FromFile(@"C:\Program Files (x86)\GOG\Games\RollerCoaster Tycoon 2 Triple Thrill Pack\ObjData\WTRCYAN.DAT");

			Terrain.LoadResources();
			ColorRemapping.LoadResources();
			Water.LoadResources();

			terrain = new Terrain();
			terrain.Size = new Size(30, 30);
			terrain.Origin = new Point(15, 15);
			terrain.Slope = -1;

			drawSettings = new DrawSettings();
			drawSettings.Slope = -1;
			drawSettings.Remap1 = RemapColors.Maroon;
			drawSettings.Remap2 = RemapColors.Gold;
			drawSettings.Remap3 = RemapColors.Bark;

			terrain.Draw(p, new Point(200, 200), 0);
			obj.Draw(p, new Point(200, 216), drawSettings);*/

			//p.Draw(g, 0, 0, obj.GetPalette(drawSettings));

			/*Graphics g = Graphics.FromImage(image);
			g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			int P = 10;
			int W = 2;
			int WW = P + W * 3;
			int WO = P + W * 1;
			int WO2 = P * 2 + W * 3;
			int PO = P + W * 3;
			Color pathColor = Color.FromArgb(91, 63, 31);
			Color[] hedgeColors = new Color[]{
				Color.FromArgb(23, 35, 35),
				Color.FromArgb(115, 155, 67),
				Color.FromArgb(175, 231, 251),
				Color.FromArgb(203, 175, 111)
			};
			Color entranceColor = Color.FromArgb(163, 59, 59);

			Point offset = Point.Empty;
			for (int i = 0; i < track.MazeTiles.Count; i++) {
				MazeTile tile = track.MazeTiles[i];
				if (tile.X < 0 && -tile.X > offset.X)
					offset.X = -tile.X;
				if (tile.Y < 0 && -tile.Y > offset.Y)
					offset.Y = -tile.Y;
			}

			for (int i = 0; i < track.MazeTiles.Count; i++) {
				MazeTile tile = track.MazeTiles[i];
				Point pos = new Point((offset.X + tile.X) * (P * 2 + W * 4),
									(offset.Y + tile.Y) * (P * 2 + W * 4));
				if (tile.IsEntrance || tile.IsExit) {
					Brush b = new SolidBrush(entranceColor);
					g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
					b.Dispose();
				}
				else {
					Brush b = new SolidBrush(pathColor);
					g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
					b.Dispose();
				}
			}
			for (int i = 0; i < track.MazeTiles.Count; i++) {
				MazeTile tile = track.MazeTiles[i];
				Point pos = new Point((offset.X + tile.X) * (P * 2 + W * 4),
									(offset.Y + tile.Y) * (P * 2 + W * 4));
				if (tile.IsEntrance || tile.IsExit) {
					Brush b = new SolidBrush(entranceColor);
					g.FillRectangle(b, new Rectangle(pos, new Size(P * 2 + W * 4, P * 2 + W * 4)));
					b.Dispose();
				}
				else {
					Brush b = new SolidBrush(hedgeColors[(int)track.TrackSupportColors[0]]);
					if (tile.Walls.HasFlag(MazeWalls.Quadrant1))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + W, P, P));
					if (tile.Walls.HasFlag(MazeWalls.Quadrant2))
						g.FillRectangle(b, new Rectangle(pos.X + PO, pos.Y + PO, P, P));
					if (tile.Walls.HasFlag(MazeWalls.Quadrant3))
						g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + PO, P, P));
					if (tile.Walls.HasFlag(MazeWalls.Quadrant4))
						g.FillRectangle(b, new Rectangle(pos.X + W, pos.Y + W, P, P));

					if (tile.Walls.HasFlag(MazeWalls.NorthRight))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, WW, W));
					if (tile.Walls.HasFlag(MazeWalls.NorthMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y, W*2, WW));
					if (tile.Walls.HasFlag(MazeWalls.NorthLeft))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y, WW, W));

					if (tile.Walls.HasFlag(MazeWalls.SouthRight))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO2, WW, W));
					if (tile.Walls.HasFlag(MazeWalls.SouthMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO, W*2, WW));
					if (tile.Walls.HasFlag(MazeWalls.SouthLeft))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO2, WW, W));

					if (tile.Walls.HasFlag(MazeWalls.EastTop))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y, W, WW));
					if (tile.Walls.HasFlag(MazeWalls.EastMiddle))
						g.FillRectangle(b, new Rectangle(pos.X + WO, pos.Y + WO, WW, W*2));
					if (tile.Walls.HasFlag(MazeWalls.EastBottom))
						g.FillRectangle(b, new Rectangle(pos.X + WO2, pos.Y + WO, W, WW));

					if (tile.Walls.HasFlag(MazeWalls.WestTop))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y, W, WW));
					if (tile.Walls.HasFlag(MazeWalls.WestMiddle))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO, WW, W*2));
					if (tile.Walls.HasFlag(MazeWalls.WestBottom))
						g.FillRectangle(b, new Rectangle(pos.X, pos.Y + WO, W, WW));

					b.Dispose();
				}
			}

			g.Dispose();*/
			//this.pictureBox1.Image = image;
			this.mazeEditor1.LoadMaze(track);
		}

		private int GetColorDelta(Color imageColor, Color paletteColor) {
			return Math.Abs(imageColor.R - paletteColor.R) +
				Math.Abs(imageColor.G - paletteColor.G) +
				Math.Abs(imageColor.B - paletteColor.B) +
				Math.Abs(imageColor.A - paletteColor.A) * 4;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			/*drawSettings.Frame = (drawSettings.Frame + 1) % 15;

			//terrain.Draw(p, new Point(200, 200), 0);
			obj.Draw(p, new Point(200, 216), drawSettings);

			Graphics g = Graphics.FromImage(image);
			p.Draw(g, 0, 0, obj.GetPalette(drawSettings));

			g.Dispose();
			this.pictureBox1.Image = image;*/
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {

		}
	}
}
