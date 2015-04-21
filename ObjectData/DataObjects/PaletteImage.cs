using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {
/** <summary> An image structured based on palette indexes. </summary> */
public class PaletteImage {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The image entry of the palette image. </summary> */
	internal ImageEntry entry;
	/** <summary> The palette pixels in the image. </summary> */
	internal byte[,] pixels;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default palette image. </summary> */
	public PaletteImage() {
		this.pixels			= new byte[1, 1];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.DirectBitmap;
		this.entry.Width	= 1;
		this.entry.Height	= 1;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette image with the specified dimensions. </summary> */
	public PaletteImage(int width, int height) {
		this.pixels			= new byte[width, height];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.DirectBitmap;
		this.entry.Width	= (short)width;
		this.entry.Height	= (short)height;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette image with the specified dimensions. </summary> */
	public PaletteImage(Size size) {
		this.pixels			= new byte[size.Width, size.Height];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.DirectBitmap;
		this.entry.Width	= (short)size.Width;
		this.entry.Height	= (short)size.Height;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette image with the specified dimensions and compression type. </summary> */
	public PaletteImage(int width, int height, int xOffset, int yOffset, ImageFlags compressionType) {
		this.pixels			= new byte[width, height];
		this.entry			= new ImageEntry();
		this.entry.Flags	= compressionType;
		this.entry.Width	= (short)width;
		this.entry.Height	= (short)height;
		this.entry.XOffset	= (short)xOffset;
		this.entry.YOffset	= (short)yOffset;
	}
	/** <summary> Constructs a palette image with the specified dimensions and compression type. </summary> */
	public PaletteImage(Size size, Point offset, ImageFlags compressionType) {
		this.pixels			= new byte[size.Width, size.Height];
		this.entry			= new ImageEntry();
		this.entry.Flags	= compressionType;
		this.entry.Width	= (short)size.Width;
		this.entry.Height	= (short)size.Height;
		this.entry.XOffset	= (short)offset.X;
		this.entry.YOffset	= (short)offset.Y;
	}
	/** <summary> Constructs a palette image from the specified image entry. </summary> */
	internal PaletteImage(ImageEntry entry) {
		this.pixels			= new byte[entry.Width, entry.Height];
		this.entry			= entry;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the palette pixels in the image. </summary> */
	public byte[,] Pixels {
		get { return this.pixels; }
	}
	/** <summary> Gets the size of the palette image. </summary> */
	public Size Size {
		get { return new Size(this.pixels.GetLength(0), this.pixels.GetLength(1)); }
	}
	/** <summary> Gets the width of the palette image. </summary> */
	public int Width {
		get { return this.pixels.GetLength(0); }
	}
	/** <summary> Gets the height of the palette image. </summary> */
	public int Height {
		get { return this.pixels.GetLength(1); }
	}
	/** <summary> Gets or sets the offset of the palette image. </summary> */
	public Point Offset {
		get { return new Point(this.entry.XOffset, this.entry.YOffset); }
		set {
			this.entry.XOffset = (short)value.X;
			this.entry.YOffset = (short)value.Y;
		}
	}
	/** <summary> Gets or sets the x offset of the palette image. </summary> */
	public int XOffset {
		get { return this.entry.XOffset; }
		set { this.entry.XOffset = (short)value; }
	}
	/** <summary> Gets or sets the y offset of the palette image. </summary> */
	public int YOffset {
		get { return this.entry.YOffset; }
		set { this.entry.YOffset = (short)value; }
	}
	/** <summary> Gets or sets the compression type of the palette image. </summary> */
	public ImageFlags CompressionType {
		get { return this.entry.Flags; }
		set {
			if (value == ImageFlags.DirectBitmap || value == ImageFlags.CompactedBitmap)
				this.entry.Flags = value;
		}
	}

	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Draws the palette image into the specified graphics. </summary> */
	public void Draw(Graphics g, int x, int y, Palette palette, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(pixels[x1, y1], palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(x + x1, y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	/** <summary> Draws the palette image into the specified graphics. </summary> */
	public void Draw(Graphics g, Point point, Palette palette, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(pixels[x1, y1], palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(point.X + x1, point.Y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	/** <summary> Draws the palette image into the specified graphics using the image entry's offset. </summary> */
	public void DrawWithOffset(Graphics g, int x, int y, Palette palette, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		x += this.entry.XOffset;
		y += this.entry.YOffset;
		
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(pixels[x1, y1], palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(x + x1, y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	/** <summary> Draws the palette image into the specified graphics using the image entry's offset. </summary> */
	public void DrawWithOffset(Graphics g, Point point, Palette palette, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		point.X += this.entry.XOffset;
		point.Y += this.entry.YOffset;

		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				Brush brush = new SolidBrush(GetColorRemapped(pixels[x1, y1], palette, remap1, remap2, remap3));
				g.FillRectangle(brush, new Rectangle(point.X + x1, point.Y + y1, 1, 1));
				brush.Dispose();
			}
		}
	}
	/** <summary> Gets the remapped version of the specified color. </summary> */
	private Color GetColorRemapped(byte source, Palette palette, RemapColors remap1, RemapColors remap2, RemapColors remap3) {
		byte pixel = source;
		if (remap1 != RemapColors.None && pixel >= 243 && pixel < 255) {
			pixel = ColorRemapping.RemapPalettes[(int)remap1].remapIndexes[pixel - 243];
		}
		else if (remap2 != RemapColors.None && pixel >= 202 && pixel < 214) {
			pixel = ColorRemapping.RemapPalettes[(int)remap2].remapIndexes[pixel - 202];
		}
		else if (remap3 != RemapColors.None && pixel >= 46 && pixel < 58) {
			pixel = ColorRemapping.RemapPalettes[(int)remap3].remapIndexes[pixel - 46];
		}
		return palette.Colors[pixel];
	}
	/** <summary> Creates a bitmap from the specified palette. </summary> */
	public Bitmap CreateImage(Palette palette, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		Bitmap image = new Bitmap(Width, Height);
		for (int x = 0; x < Width; x++) {
			for (int y = 0; y < Height; y++) {
				image.SetPixel(x, y, GetColorRemapped(pixels[x, y], palette, remap1, remap2, remap3));
			}
		}
		return image;
	}

	/** <summary> Draws the palette image into the specified palette image. </summary> */
	public void Draw(PaletteImage p, int x, int y, int darkness, bool glass, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				if (x1 + x >= 0 && y1 + y >= 0 && x1 + x < p.Width && y1 + y < p.Height) {
					p.pixels[x1 + x, y1 + y] = GetColorIndexRemapped(pixels[x1, y1], p.pixels[x1 + x, y1 + y], darkness, glass, remap1, remap2, remap3);
				}
			}
		}
	}
	/** <summary> Draws the palette image into the specified palette image. </summary> */
	public void Draw(PaletteImage p, Point point, int darkness, bool glass, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				if (x1 + point.X >= 0 && y1 + point.Y >= 0 && x1 + point.X < p.Width && y1 + point.Y < p.Height) {
					p.pixels[x1 + point.X, y1 + point.Y] = GetColorIndexRemapped(pixels[x1, y1], p.pixels[x1 + point.X, y1 + point.Y], darkness, glass, remap1, remap2, remap3);
				}
			}
		}
	}
	/** <summary> Draws the palette image into the specified palette image using the image entry's offset. </summary> */
	public void DrawWithOffset(PaletteImage p, int x, int y, int darkness, bool glass, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		x += this.entry.XOffset;
		y += this.entry.YOffset;
		
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				if (x1 + x >= 0 && y1 + y >= 0 && x1 + x < p.Width && y1 + y < p.Height) {
					p.pixels[x1 + x, y1 + y] = GetColorIndexRemapped(pixels[x1, y1], p.pixels[x1 + x, y1 + y], darkness, glass, remap1, remap2, remap3);
				}
			}
		}
	}
	/** <summary> Draws the palette image into the specified palette image using the image entry's offset. </summary> */
	public void DrawWithOffset(PaletteImage p, Point point, int darkness, bool glass, RemapColors remap1 = RemapColors.None, RemapColors remap2 = RemapColors.None, RemapColors remap3 = RemapColors.None) {
		point.X += this.entry.XOffset;
		point.Y += this.entry.YOffset;
		
		for (int x1 = 0; x1 < Width; x1++) {
			for (int y1 = 0; y1 < Height; y1++) {
				if (x1 + point.X >= 0 && y1 + point.Y >= 0 && x1 + point.X < p.Width && y1 + point.Y < p.Height) {
					p.pixels[x1 + point.X, y1 + point.Y] = GetColorIndexRemapped(pixels[x1, y1], p.pixels[x1 + point.X, y1 + point.Y], darkness, glass, remap1, remap2, remap3);
				}
			}
		}
	}
	/** <summary> Gets the remapped version of the specified color. </summary> */
	private byte GetColorIndexRemapped(byte source, byte destination, int darkness, bool glass, RemapColors remap1, RemapColors remap2, RemapColors remap3) {
		byte pixel = source;
		if (remap1 != RemapColors.None && pixel >= 243 && pixel < 255) {
			if (glass)
				pixel = ColorRemapping.GlassPalettes[(int)remap1].remapIndexes[destination];
			else
				pixel = ColorRemapping.RemapPalettes[(int)remap1].remapIndexes[pixel - 243];
		}
		else if (remap2 != RemapColors.None && pixel >= 202 && pixel < 214) {
			if (glass)
				pixel = ColorRemapping.GlassPalettes[(int)remap2].remapIndexes[destination];
			else
				pixel = ColorRemapping.RemapPalettes[(int)remap2].remapIndexes[pixel - 202];
		}
		else if (remap3 != RemapColors.None && pixel >= 46 && pixel < 58) {
			if (glass)
				pixel = ColorRemapping.GlassPalettes[(int)remap3].remapIndexes[destination];
			else
				pixel = ColorRemapping.RemapPalettes[(int)remap3].remapIndexes[pixel - 46];
		}
		else if (glass && pixel >= 1 && pixel <= 5) {
			pixel = ColorRemapping.WaterPalettes[pixel - 1].remapIndexes[destination];
		}
		if (darkness > 0) {
			pixel = ColorRemapping.RemapPalettes[darkness - 1].remapIndexes[pixel];
		}
		if (source == 0) {
			pixel = destination;
		}
		return pixel;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Saves the palette image to the specified file path. </summary> */
	public void Save(string path) {
		BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);
		graphicsData.Add(this);

		long imageDirectoryPosition = writer.BaseStream.Position;
		imageDirectory.Write(writer);
		graphicsData.Write(writer);
		writer.BaseStream.Position = imageDirectoryPosition;
		imageDirectory.Write(writer);

		writer.Close();
	}

	/** <summary> Returns the color delta between two colors. </summary> */
	private static int GetColorDelta(Color imageColor, Color paletteColor) {
		return	Math.Abs(imageColor.R - paletteColor.R) +
				Math.Abs(imageColor.G - paletteColor.G) +
				Math.Abs(imageColor.B - paletteColor.B) +
				Math.Abs(imageColor.A - paletteColor.A) * 4;
	}
	/** <summary> Returns a palette image loaded from the specified bitmap image. </summary> */
	public static PaletteImage FromImage(Bitmap image, Palette palette) {
		PaletteImage paletteImage = new PaletteImage(image.Size);

		for (int x = 0; x < image.Width; x++) {
			for (int y = 0; y < image.Height; y++) {
				Color imageColor = image.GetPixel(x, y);
				int minDelta = GetColorDelta(imageColor, palette.Colors[0]);
				int minDeltaIndex = 0;
				for (int i = 10; i < palette.NumColors; i++) {
					int delta = GetColorDelta(imageColor, palette.Colors[i]);
					if (delta < minDelta) {
						minDelta = delta;
						minDeltaIndex = i;
					}
				}
				paletteImage.pixels[x, y] = (byte)minDeltaIndex;
			}
		}

		return paletteImage;
	}
	/** <summary> Returns a palette image loaded from the specified stream. </summary> */
	public static PaletteImage FromStream(Stream stream) {
		BinaryReader reader = new BinaryReader(stream);
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);
		imageDirectory.Read(reader);
		graphicsData.Read(reader);
		reader.Close();
		return graphicsData.GetPaletteImage(0);
	}
	/** <summary> Returns a palette image loaded from the specified buffer. </summary> */
	public static PaletteImage FromBuffer(byte[] buffer) {
		return FromStream(new MemoryStream(buffer));
	}
	/** <summary> Returns a palette image loaded from the specified file. </summary> */
	public static PaletteImage FromFile(string path) {
		return FromStream(new FileStream(path, FileMode.Open, FileAccess.Read));
	}

	#endregion
}
}
