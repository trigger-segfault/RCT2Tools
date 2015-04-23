using RCT2ObjectData.DataObjects;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCT2MazeGenerator {
	public partial class MazeForm : Form {

		//=========== MEMBERS ============
		#region Members
		//--------------------------------
		#region Settings

		/** <summary> The maze design being edited. </summary> */
		TrackDesign maze;
		/** <summary> The file name for the maze. </summary> */
		string fileName = "";
		/** <summary> True if the maze was changed. </summary> */
		bool changed = false;

		#endregion
		//--------------------------------
		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the form. </summary> */
		public MazeForm() {
			InitializeComponent();

			this.KeyPreview = true;
			//maze = TrackDesign.ReadTrackDesign(@"C:\Programs\Games\Steam\steamapps\common\Rollercoaster Tycoon 2\Tracks\Mini Maze.TD6");
			maze = CreateNewMaze();
			//maze.TrackSupportColors[0] = (RemapColors)1;
			//maze.Excitement--;
			//maze.Save("Untitled.TD6");
			mazeEditor1.LoadMaze(maze);
			mazeEditor1.ResizeMaze(new Size(10, 10));
			changed = false;
			UpdateMazeSize();
		}

		private void UpdateMazeSize() {
			this.labelMazeSize.Text = "Maze Size: " + mazeEditor1.MazeSize.Width + "x" + mazeEditor1.MazeSize.Height;
		}

		#endregion
		//============ EVENTS ============
		#region Events

		/** <summary> Resizes the maze. </summary> */
		private void ResizeMazeMinusX(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(-1, 0)));
			UpdateMazeSize();
		}
		/** <summary> Resizes the maze. </summary> */
		private void ResizeMazeMinusY(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(0, -1)));
			UpdateMazeSize();
		}
		/** <summary> Resizes the maze. </summary> */
		private void ResizeMazePlusX(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(1, 0)));
			UpdateMazeSize();
		}
		/** <summary> Resizes the maze. </summary> */
		private void ResizeMazePlusY(object sender, EventArgs e) {
			mazeEditor1.ResizeMaze(Size.Add(mazeEditor1.MazeSize, new Size(0, 1)));
			UpdateMazeSize();
		}

		/** <summary> Translates the maze. </summary> */
		private void TranslateMazeMinusX(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(-1, 0));
		}
		/** <summary> Translates the maze. </summary> */
		private void TranslateMazeMinusY(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(0, -1));
		}
		/** <summary> Translates the maze. </summary> */
		private void TranslateMazePlusX(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(1, 0));
		}
		/** <summary> Translates the maze. </summary> */
		private void TranslateMazePlusY(object sender, EventArgs e) {
			mazeEditor1.TranslateMaze(new Point(0, 1));
		}

		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeWalls(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Walls;
		}
		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeTiles(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Tiles;
		}
		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeEntrance(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Entrance;
		}
		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeExit(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Exit;
		}
		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeGenerate(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Generate;
		}
		/** <summary> Changes the place mode of the maze. </summary> */
		private void PlaceModeRestrict(object sender, EventArgs e) {
			mazeEditor1.PlaceMode = PlaceModes.Restrict;
		}

		/** <summary> Changes the wall style of the maze. </summary> */
		private void WallStyleBrickWalls(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.BrickWalls;
		}
		/** <summary> Changes the wall style of the maze. </summary> */
		private void WallStyleHedges(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.Hedges;
		}
		/** <summary> Changes the wall style of the maze. </summary> */
		private void WallStyleIceBlocks(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.IceBlocks;
		}
		/** <summary> Changes the wall style of the maze. </summary> */
		private void WallStyleWoodenFences(object sender, EventArgs e) {
			mazeEditor1.WallStyle = WallStyles.WoodenFences;
		}
		/** <summary> Zooms the maze view. </summary> */
		private void ZoomIn(object sender, EventArgs e) {
			mazeEditor1.ZoomIn();
		}
		/** <summary> Zooms the maze view. </summary> */
		private void ZoomOut(object sender, EventArgs e) {
			mazeEditor1.ZoomOut();
		}
		/** <summary> Changes the grid in the maze view. </summary> */
		private void ShowGrid(object sender, EventArgs e) {
			this.mazeEditor1.ShowGrid = !this.mazeEditor1.ShowGrid;
		}
		/** <summary> Changes the walls make tiles setting. </summary> */
		private void WallsMakeTiles(object sender, EventArgs e) {
			this.mazeEditor1.WallsMakeTiles = (this.rctCheckBox1.CheckState == CheckState.Checked);
		}

		/** <summary> Sets the maze changed value to true. </summary> */
		private void MazeChanged(object sender, EventArgs e) {
			this.changed = true;
		}

		#endregion
		//=========== READING ============
		#region Reading

		/** <summary> Creates the default maze. </summary> */
		private TrackDesign CreateNewMaze() {
			TrackDesign newMaze = new TrackDesign();
			newMaze.TrackType = TrackTypes.HedgeMaze;
			newMaze.OperatingMode = OperatingModes.MazeMode;
			newMaze.EntranceType = EntranceTypes.Normal;

			newMaze.PoweredSpeedLapsMaxPeople = 4;

			newMaze.NumberOfTrains = 1;
			newMaze.CarsPerTrain = 1;
			newMaze.ChainLiftSpeed = 5;
			newMaze.NumberOfCircuits = 1;

			newMaze.MaximumWaitTime = 60;
			newMaze.MinimumWaitTime = 10;
			newMaze.DepartureControlFlags = 0x43;

			newMaze.Excitement = 12;
			newMaze.Intensity = 6;
			newMaze.Nausea = 0;

			newMaze.VehicleColorScheme = 8;
			newMaze.Unknown0x48 = 1;
			newMaze.Unknown0x5E = 31;

			newMaze.RideMapWidth = 10;
			newMaze.RideMapHeight = 10;

			for (int i = 0; i < 4; i++) {
				newMaze.TrackRailColors[0] = RemapColors.Gray;
				newMaze.TrackSpineColors[0] = RemapColors.Gray;
				newMaze.TrackSupportColors[0] = RemapColors.Gray;
			}
			newMaze.TrackSupportColors[0] = (RemapColors)WallStyles.Hedges;

			newMaze.ObjectHeader.Flags = 0xC58B180;
			newMaze.ObjectHeader.FileName = "HMAZE";
			newMaze.ObjectHeader.CheckSum = 0x2F963BDC;

			return newMaze;
		}
		/** <summary> Opens the about form. </summary> */
		private void About(object sender, EventArgs e) {
			using (AboutBox about = new AboutBox()) {
				about.ShowDialog(this);
			}
		}
		/** <summary> Creates a new maze design. </summary> */
		private void New(object sender, EventArgs e) {
			if (!changed || WarningMessageBox.Show(this, "Maze has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				maze = CreateNewMaze();
				maze.TrackType = TrackTypes.HedgeMaze;
				mazeEditor1.LoadMaze(maze);
				mazeEditor1.ResizeMaze(new Size(10, 10));
				changed = false;
				fileName = "";
			}
		}
		/** <summary> Opens the maze design. </summary> */
		private void Open(object sender, EventArgs e) {
			if (fileName == "") {
				openFileDialog.InitialDirectory = "";
				openFileDialog.FileName = "";
			}
			else {
				openFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				openFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
			}
			if (!changed || WarningMessageBox.Show(this, "Maze has been changed.", "Are you sure you want to continue?") == DialogResult.Yes) {
				if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
					try {
						TrackDesign newMaze = TrackDesign.ReadTrackDesign(openFileDialog.FileName);
						if (newMaze.TrackType == TrackTypes.HedgeMaze) {
							fileName = openFileDialog.FileName;
							changed = false;
							this.maze = newMaze;
							this.mazeEditor1.LoadMaze(newMaze);
							UpdateMazeSize();
						}
						else {
							ErrorMessageBox.Show(this, "Failed to load maze.", "The track design is not a maze.");
						}
					}
					catch (Exception) {
						ErrorMessageBox.Show(this, "Failed to load maze.", "Track design may be invalid.");
					}
				}
			}
		}
		/** <summary> Saves the maze design. </summary> */
		private void Save(object sender, EventArgs e) {
			if (fileName == "") {
				SaveAs(null, null);
			}
			else {
				string[] errors = this.mazeEditor1.MazeErrors;
				if (errors.Length == 0) {
					this.mazeEditor1.SaveMaze(maze);
					maze.Save(fileName);
					changed = false;
				}
				else {
					ErrorMessageBox.Show(this, errors[0], errors.Length >= 2 ? errors[1] : "");
				}
			}
		}
		/** <summary> Saves as the maze design. </summary> */
		private void SaveAs(object sender, EventArgs e) {
			if (fileName == "") {
				saveFileDialog.InitialDirectory = "";
				saveFileDialog.FileName = "Untitled";
			}
			else {
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
				saveFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
			}
			string[] errors = this.mazeEditor1.MazeErrors;
			if (errors.Length == 0) {
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
					fileName = saveFileDialog.FileName;
					this.mazeEditor1.SaveMaze(maze);
					maze.Save(fileName);
					changed = false;
				}
			}
			else {
				ErrorMessageBox.Show(this, errors[0], errors.Length >= 2 ? errors[1] : "");
			}
		}


		#endregion
	}
}
