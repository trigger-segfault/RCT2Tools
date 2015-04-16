using CustomControls.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Visuals {
public class SpriteFont {

	//========== CONSTANTS ===========
	#region Constants

	public static SpriteFont FontRegular = new SpriteFont(Resource.FontRegularOutline, ' ', (char)255, 12);
	public static SpriteFont FontBold = new SpriteFont(Resource.FontBoldOutline, ' ', (char)255, 12);
	public static SpriteFont FontSmall = new SpriteFont(Resource.FontSmallOutline, ' ', (char)255, 10);

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

		this.image			= image;
		this.minRange		= minRange;
		this.maxRange		= maxRange;
		this.height			= height;
		this.charSpacing	= new byte[(int)maxRange - (int)minRange + 1];
		this.charPositions	= new Point[(int)maxRange - (int)minRange + 1];

		int charWidth = 0;
		int charIndex = 0;

		while (this.image.GetPixel(position.X, position.Y) != backColor) {

			while (this.image.GetPixel(position.X, position.Y) != backColor) {

				charWidth = 0;
				charPositions[charIndex] = position;

				while (this.image.GetPixel(position.X, position.Y) != backColor) {
					position.X++;
					charWidth++;
				}
				this.charSpacing[charIndex] = (byte)charWidth;
				charIndex++;

				position.X++;
			}

			position.X = 1;
			position.Y += height + 1;
		}
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
			spacing += charSpacing[(int)text[i] - (int)minRange] - (i != 0 ? 1 : 0);
		}
		return new Size(spacing - 1, height);
	}
	/** <summary> Draws the text. </summary> */
	public void Draw(Graphics g, Point position, string text, Color color, Color outline) {

		int spacing = 0;

		ColorMap colorMap = new ColorMap();
		colorMap.OldColor = Color.White;
		colorMap.NewColor = color;
		ColorMap outlineMap = new ColorMap();
		outlineMap.OldColor = Color.Black;
		outlineMap.NewColor = outline;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetRemapTable(new ColorMap[] { colorMap, outlineMap });

		for (int i = 0; i < text.Length; i++) {
			g.DrawImage(image,
				new Rectangle(position.X + spacing, position.Y, charSpacing[(int)text[i] - (int)minRange]/* - 1*/, height),
				(int)charPositions[(int)text[i] - (int)minRange].X,
				(int)charPositions[(int)text[i] - (int)minRange].Y,
				(int)charSpacing[(int)text[i] - (int)minRange],// - (int)1,
				(int)height,
				GraphicsUnit.Pixel, imageAttributes
			);
			spacing += charSpacing[(int)text[i] - (int)minRange] - 1;
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
	public void DrawAligned(Graphics g, Rectangle rect, ContentAlignment align, string text, Color color, Color outline) {

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
		colorMap.OldColor = Color.White;
		colorMap.NewColor = color;
		ColorMap outlineMap = new ColorMap();
		outlineMap.OldColor = Color.Black;
		outlineMap.NewColor = outline;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetRemapTable(new ColorMap[] { colorMap, outlineMap });

		for (int i = 0; i < text.Length; i++) {
			g.DrawImage(image,
				new Rectangle(rect.X + point.X + spacing, rect.Y + point.Y, charSpacing[(int)text[i] - (int)minRange]/* - 1*/, height),
				(int)charPositions[(int)text[i] - (int)minRange].X,
				(int)charPositions[(int)text[i] - (int)minRange].Y,
				(int)charSpacing[(int)text[i] - (int)minRange],//- (int)1,
				(int)height,
				GraphicsUnit.Pixel, imageAttributes
			);
			spacing += charSpacing[(int)text[i] - (int)minRange] - 1;
		}
	}

	#endregion
}
/** <summary> The types of fonts usable with controls. </summary> */
public enum FontType {
	/** <summary> The regular font. </summary> */
	Regular = 0,
	/** <summary> The bold font, this is the default font. </summary> */
	Bold = 1,
	/** <summary> The small font. </summary> */
	Small = 2
}
}
