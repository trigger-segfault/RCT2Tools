using RCTDataEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects {
public class Terrain {

	static Image landTile = Resources.LandTile;
	static Image[] slopeTiles = new Image[] { Resources.SlopeNW, Resources.SlopeNE, Resources.SlopeSE, Resources.SlopeSW };

	public static void DrawTerrain(Graphics g, int width, int height, int offsetX = 0, int offsetY = 0) {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY);
			}
		}
	}
	public static void DrawSlopedTerrain(Graphics g, int slope, int slopeLevel, int width, int height, int offsetX = 0, int offsetY = 0) {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (slope == 0) {
					if (y + x + 1 == slopeLevel)
						g.DrawImage(slopeTiles[slope], x * 64 - offsetX, y * 32 - offsetY - 16);
					else if (y + x < slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY - 16);
					else if (y + (x == 0 ? 1 : x) - 1 > slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY);
				}
				else if (slope == 1) {
					if (y - x == slopeLevel)
						g.DrawImage(slopeTiles[slope], x * 64 - offsetX, y * 32 - offsetY - 16);
					else if (y - (x == 0 ? 1 : x) + 1 < slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY - 16);
					else if (y - x - 1 > slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY);
				}
				else if (slope == 2) {
					if (y + x + 1 == slopeLevel)
						g.DrawImage(slopeTiles[slope], x * 64 - offsetX, y * 32 - offsetY);
					else if (y + x < slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY);
					else if (y + (x == 0 ? 1 : x) > slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY + 16);
				}
				else if (slope == 3) {
					if (y - x == slopeLevel)
						g.DrawImage(slopeTiles[slope], x * 64 - offsetX, y * 32 - offsetY);
					else if (y - (x == 0 ? 1 : x) + 1 < slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY);
					else if (y - x + 1 > slopeLevel)
						g.DrawImage(landTile, x * 64 - offsetX, y * 32 - offsetY + 16);
				}
			}
		}
	}

}
}
