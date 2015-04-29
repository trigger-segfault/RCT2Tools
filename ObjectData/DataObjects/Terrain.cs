using RCT2ObjectData.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {
public class Terrain {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> A collection of all land tile images used for the terrain. </summary> */
	private static PaletteImage[] LandTiles;

	#endregion
	//=========== LOADING ============
	#region Loading

	/** <summary> Loads the terrain resources. </summary> */
	public static void LoadResources() {
		GraphicsData graphicsData = GraphicsData.FromBuffer(Resources.Terrain);

		LandTiles = new PaletteImage[5];
		graphicsData.paletteImages.CopyTo(LandTiles);
	}

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The origin of the center tile. </summary> */
	public Point Origin;
	/** <summary> The size of the tiles. </summary> */
	public Size Size;
	/** <summary> The slope of the tiles. </summary> */
	public int Slope;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default terrain. </summary> */
	public Terrain() {
		this.Origin = Point.Empty;
		this.Size = new Size(1, 1);
		this.Slope = -1;
	}

	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Draws the terrain to the specified palette image. </summary> */
	public void Draw(PaletteImage p, Point point, int darkness) {
		point.X -= 32 + ((Origin.X - Origin.Y) * 32);
		point.Y -= 15 + ((Origin.X + Origin.Y) * 16);
		for (int x1 = 0; x1 < Size.Width; x1++) {
			for (int y1 = 0; y1 < Size.Height; y1++) {
				if (Slope != -1 &&
					((Slope == 0 && x1 < Origin.X - 0) || (Slope == 2 && x1 > Origin.X + 2) ||
					(Slope == 1 && y1 < Origin.Y - 1) || (Slope == 3 && y1 > Origin.Y + 1))) {
					LandTiles[0].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1 - 1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == -1 ||
					(Slope % 2 == 0 && (x1 < Origin.X - 0 || x1 > Origin.X + 2)) ||
					(Slope % 2 == 1 && (y1 < Origin.Y - 1 || y1 > Origin.Y + 1))) {
					/*(Slope % 2 == 0 && (x1 < Origin.X - 0 || x1 > Origin.X + 2)) ||
					(Slope % 2 == 1 && (y1 < Origin.Y - 1 || y1 > Origin.Y + 1))) {*/
					LandTiles[0].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 0 && x1 == Origin.X + 2) {
					LandTiles[1].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 1 && y1 == Origin.Y + 1) {
					LandTiles[2].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 2 && x1 == Origin.X - 0) {
					LandTiles[3].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 3 && y1 == Origin.Y - 1) {
					LandTiles[4].DrawWithOffset(p, point.X + ((x1 - y1) * 32), point.Y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
			}
		}
	}
	/** <summary> Draws the terrain to the specified palette image. </summary> */
	public void Draw(PaletteImage p, int x, int y, int darkness) {
		x -= 32 + ((Origin.X - Origin.Y) * 32);
		y -= 15 + ((Origin.X + Origin.Y) * 16);
		for (int x1 = 0; x1 < Size.Width; x1++) {
			for (int y1 = 0; y1 < Size.Height; y1++) {
				if (Slope == -1 ||
					(Slope % 2 == 0 && x1 < Origin.X - 1 && x1 > Origin.X + 1) ||
					(Slope % 2 == 1 && y1 < Origin.Y - 1 && y1 > Origin.Y + 1)) {
					LandTiles[0].DrawWithOffset(p, x + ((x1 - y1) * 32), y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 0 && x1 == Origin.X + 1) {
					LandTiles[1].DrawWithOffset(p, x + ((x1 - y1) * 32), y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 1 && y1 == Origin.Y + 1) {
					LandTiles[2].DrawWithOffset(p, x + ((x1 - y1) * 32), y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 2 && x1 == Origin.X - 1) {
					LandTiles[3].DrawWithOffset(p, x + ((x1 - y1) * 32), y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
				else if (Slope == 3 && y1 == Origin.Y - 1) {
					LandTiles[4].DrawWithOffset(p, x + ((x1 - y1) * 32), y + ((x1 + y1) * 16),
						darkness, false, RemapColors.None, RemapColors.None, RemapColors.None
					);
				}
			}
		}
	}

	#endregion
}
}
