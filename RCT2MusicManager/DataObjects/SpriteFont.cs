
using RCT2MusicManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCTDataEditor.DataObjects {
	public class SpriteFont {
		//========== CONSTANTS ===========
		#region Constants

		public static SpriteFont FontBold = new SpriteFont(
			new byte[]{
			2, 3, 7, 8, 7, 9, 8, 3, 4, 4, 7, 7, 3, 6, 3, 6, 8, 5, 7, 7, 7, 7, 7, 7, 7, 7, 3, 4, 5, 6, 5, 7, 9, 8, 7, 8, 8, 7, 7, 9, 8, 3, 6, 7, 7, 10
			, 8, 9, 7, 9, 7, 7, 7, 8, 9, 12, 10, 9, 8, 4, 5, 4, 6, 6, 3, 6, 6, 6, 6, 6, 6, 6, 6, 3, 5, 6, 3, 9, 6, 6, 6, 6, 5, 6, 5, 6, 7, 10, 7, 7, 6
		},
			new Point[]{
			new Point(1, 1), new Point(4, 1), new Point(8, 1), new Point(16, 1), new Point(25, 1), new Point(33, 1), new Point(43, 1), new Point(52, 1),
			new Point(56, 1), new Point(61, 1), new Point(66, 1), new Point(74, 1), new Point(82, 1), new Point(86, 1), new Point(93, 1), new Point(97, 1),
			new Point(104, 1), new Point(113, 1), new Point(119, 1), new Point(127, 1), new Point(135, 1), new Point(143, 1), new Point(151, 1), new Point(159, 1),
			new Point(167, 1), new Point(175, 1), new Point(183, 1), new Point(187, 1), new Point(192, 1), new Point(198, 1), new Point(205, 1), new Point(211, 1),
			new Point(219, 1), new Point(1, 12), new Point(10, 12), new Point(18, 12), new Point(27, 12), new Point(36, 12), new Point(44, 12), new Point(52, 12),
			new Point(62, 12), new Point(71, 12), new Point(75, 12), new Point(82, 12), new Point(90, 12), new Point(98, 12), new Point(109, 12), new Point(118, 12),
			new Point(128, 12), new Point(136, 12), new Point(146, 12), new Point(154, 12), new Point(162, 12), new Point(170, 12), new Point(179, 12),
			new Point(189, 12), new Point(202, 12), new Point(213, 12), new Point(223, 12), new Point(1, 23), new Point(6, 23), new Point(12, 23), new Point(17, 23),
			new Point(24, 23), new Point(31, 23), new Point(35, 23), new Point(42, 23), new Point(49, 23), new Point(56, 23), new Point(63, 23), new Point(70, 23),
			new Point(77, 23), new Point(84, 23), new Point(91, 23), new Point(95, 23), new Point(101, 23), new Point(108, 23), new Point(112, 23),
			new Point(122, 23), new Point(129, 23), new Point(136, 23), new Point(143, 23), new Point(150, 23), new Point(156, 23), new Point(163, 23),
			new Point(169, 23), new Point(176, 23), new Point(184, 23), new Point(195, 23), new Point(203, 23), new Point(211, 23)
		},
			Resources.BoldFont, ' ', 'z', 10
		);

		#endregion
		//=========== MEMBERS ============
		#region Members

		/** <summary> The image of the sprite font. </summary> */
		private Bitmap image;
		/** <summary> The minimum character allowed. </summary> */
		private char minRange;
		/** <summary> The maximum character allowed. </summary> */
		private char maxRange;
		/** <summary> The height of the characters. </summary> */
		private int height;
		/** <summary> The spacing of each character. </summary> */
		private byte[] charSpacing;
		/** <summary> The positions of each character. </summary> */
		private Point[] charPositions;

		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the default sprite font. </summary> */
		public SpriteFont(Bitmap image, char minRange, char maxRange, int height) {
			Point position = new Point(1, 1);
			Color backColor = Color.FromArgb(255, 0, 0);

			this.image = image;
			this.minRange = minRange;
			this.maxRange = maxRange;
			this.height = height;
			this.charSpacing = new byte[(int)maxRange - (int)minRange + 1];
			this.charPositions = new Point[(int)maxRange - (int)minRange + 1];

			int charWidth = 0;
			int charIndex = 0;

			while (image.GetPixel(position.X, position.Y) != backColor) {

				while (image.GetPixel(position.X, position.Y) != backColor) {

					charWidth = 0;
					charPositions[charIndex] = position;

					while (image.GetPixel(position.X, position.Y) != backColor) {
						position.X++;
						charWidth++;
					}
					charSpacing[charIndex] = (byte)charWidth;
					charIndex++;

					position.X++;
				}

				position.X = 1;
				position.Y += height + 1;
			}
		}
		/** <summary> Constructs the default sprite font. </summary> */
		public SpriteFont(byte[] spacing, Point[] positions, Bitmap image, char minRange, char maxRange, int height) {
			Point position = new Point(1, 1);
			Color backColor = Color.FromArgb(255, 0, 0);

			this.image = image;
			this.minRange = minRange;
			this.maxRange = maxRange;
			this.height = height;
			this.charSpacing = spacing;
			this.charPositions = positions;
		}

		#endregion
		//========== PROPERTIES ==========
		#region Properties


		#endregion
		//=========== DRAWING ============
		#region Drawing

		/** <summary> Gets the size of the specified text. </summary> */
		public Size GetTextSize(string text) {
			int spacing = 0;

			for (int i = 0; i < text.Length; i++) {
				spacing += charSpacing[(int)text[i] - (int)minRange];
			}
			return new Size(spacing - 1, height);
		}
		/** <summary> Draws the text. </summary> */
		public void Draw(Graphics g, Point position, string text, Color color) {

			int spacing = 0;


			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = Color.Black;
			colorMap.NewColor = color;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[] { colorMap });

			for (int i = 0; i < text.Length; i++) {
				g.DrawImage(image,
					new Rectangle(position.X + spacing, position.Y, charSpacing[(int)text[i] - (int)minRange] - 1, height),
					(int)charPositions[(int)text[i] - (int)minRange].X,
					(int)charPositions[(int)text[i] - (int)minRange].Y,
					(int)charSpacing[(int)text[i] - (int)minRange] - (int)1,
					(int)height,
					GraphicsUnit.Pixel//, imageAttributes
				);
				spacing += charSpacing[(int)text[i] - (int)minRange];
			}

			/*for (int i = 0; i < text.Length; i++) {
				g.DrawImage(image, position.X + spacing, position.Y,
					new Rectangle(
						new Point(charPositions[(int)text[i] - (int)minRange].X, charPositions[(int)text[i] - (int)minRange].Y),
						new Size(charSpacing[(int)text[i] - (int)minRange] - 1, height)
					), GraphicsUnit.Pixel
				);
				spacing += charSpacing[(int)text[i] - (int)minRange];
			}*/
		}
		/** <summary> Draws the aligned text. </summary> */
		public void DrawAligned(Graphics g, Rectangle rect, ContentAlignment align, string text, Color color) {

			Point point = Point.Empty;
			Size size = GetTextSize(text);
			int spacing = 0;
			if (align == ContentAlignment.TopLeft || align == ContentAlignment.MiddleLeft || align == ContentAlignment.BottomLeft)
				point.X = 0;
			else if (align == ContentAlignment.TopCenter || align == ContentAlignment.MiddleCenter || align == ContentAlignment.BottomCenter)
				point.X = (rect.Width - size.Width) / 2;
			else if (align == ContentAlignment.TopRight || align == ContentAlignment.MiddleRight || align == ContentAlignment.BottomRight)
				point.X = rect.Width - size.Width;

			if (align == ContentAlignment.TopLeft || align == ContentAlignment.TopCenter || align == ContentAlignment.TopRight)
				point.Y = 0;
			else if (align == ContentAlignment.MiddleLeft || align == ContentAlignment.MiddleCenter || align == ContentAlignment.MiddleRight)
				point.Y = (rect.Height - size.Height) / 2;
			else if (align == ContentAlignment.BottomLeft || align == ContentAlignment.BottomCenter || align == ContentAlignment.BottomRight)
				point.Y = rect.Height - size.Height;

			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = Color.Black;
			colorMap.NewColor = color;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[] { colorMap });

			for (int i = 0; i < text.Length; i++) {
				g.DrawImage(image,
					new Rectangle(rect.X + point.X + spacing, rect.Y + point.Y, charSpacing[(int)text[i] - (int)minRange] - 1, height),
					(int)charPositions[(int)text[i] - (int)minRange].X,
					(int)charPositions[(int)text[i] - (int)minRange].Y,
					(int)charSpacing[(int)text[i] - (int)minRange] - (int)1,
					(int)height,
					GraphicsUnit.Pixel//, imageAttributes
				);
				spacing += charSpacing[(int)text[i] - (int)minRange];
			}
		}
		/** <summary> Draws the aligned text. </summary> */
		public void DrawAligned(Graphics g, Rectangle rect, HorizontalAlignment align, string text, Color color) {

			Point point = Point.Empty;
			Size size = GetTextSize(text);
			int spacing = 0;
			if (align == HorizontalAlignment.Left)
				point.X = 0;
			else if (align == HorizontalAlignment.Center)
				point.X = (rect.Width - size.Width) / 2;
			else if (align == HorizontalAlignment.Right)
				point.X = rect.Width - size.Width;

			point.Y = (rect.Height - size.Height) / 2;

			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = Color.Black;
			colorMap.NewColor = color;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[] { colorMap });

			for (int i = 0; i < text.Length; i++) {
				g.DrawImage(image,
					new Rectangle(rect.X + point.X + spacing, rect.Y + point.Y, charSpacing[(int)text[i] - (int)minRange] - 1, height),
					(int)charPositions[(int)text[i] - (int)minRange].X,
					(int)charPositions[(int)text[i] - (int)minRange].Y,
					(int)charSpacing[(int)text[i] - (int)minRange] - (int)1,
					(int)height,
					GraphicsUnit.Pixel//, imageAttributes
				);
				spacing += charSpacing[(int)text[i] - (int)minRange];
			}
		}

		#endregion
	}
}
