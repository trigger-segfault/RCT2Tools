using RCT2ObjectData.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MazeGenerator {
	public partial class MazeForm : Form {
		public MazeForm() {
			InitializeComponent();

			this.KeyPreview = true;
			TrackDesign maze = TrackDesign.ReadTrackDesign(@"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6");
			mazeEditor1.LoadMaze(maze);
			UpdateMazeSize();
		}

		private void UpdateMazeSize() {
			this.labelMazeSize.Text = "Maze Size: " + mazeEditor1.MazeSize.Width + "x" + mazeEditor1.MazeSize.Height;
		}

		private void ResizeMazeMinusX(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(-1, 0)));
			UpdateMazeSize();
		}
		private void ResizeMazeMinusY(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(0, -1)));
			UpdateMazeSize();
		}
		private void ResizeMazePlusX(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(1, 0)));
			UpdateMazeSize();
		}
		private void ResizeMazePlusY(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(0, 1)));
			UpdateMazeSize();
		}

		private void TranslateMazeMinusX(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(-1, 0));
		}
		private void TranslateMazeMinusY(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(0, -1));
		}
		private void TranslateMazePlusX(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(1, 0));
		}
		private void TranslateMazePlusY(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(0, 1));
		}

		private void PlaceModeWalls(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Walls;
		}
		private void PlaceModeTiles(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Tiles;
		}
		private void PlaceModeEntrance(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Entrance;
		}
		private void PlaceModeExit(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Exit;
		}
		private void PlaceModeGenerate(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Generate;
		}
		private void PlaceModeRestrict(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Restrict;
		}

		private void WallStyleBrickWalls(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.BrickWalls;
		}
		private void WallStyleHedges(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.Hedges;
		}
		private void WallStyleIceBlocks(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.IceBlocks;
		}
		private void WallStyleWoodenFences(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.WoodenFences;
		}


		/** <summary> Opens the about form. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
	}
}
