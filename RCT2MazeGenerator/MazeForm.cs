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
		}

		private void mazeEditor1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.D1) mazeEditor1.placeMode = 0;
			if (e.KeyCode == Keys.D2) mazeEditor1.placeMode = 1;
			if (e.KeyCode == Keys.D3) mazeEditor1.placeMode = 2;
		}
	}
}
