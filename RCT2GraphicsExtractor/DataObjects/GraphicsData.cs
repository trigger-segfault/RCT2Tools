using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects {
/** <summary> A graphics for each image in the object. </summary> */
public class GraphicsData {

	public static int ColorRemap1 = 26;
	public static int ColorRemap2 = 18;
	public static int ColorRemap3 = 24;

	public static string LastPaletteText = "";

	//=========== MEMBERS ============
	#region Members

	/** <summary> The list of images. </summary> */
	public List<Bitmap> Images;
	/** <summary> The list of palette images. </summary> */
	public List<PaletteImage> PaletteImages;
	/** <summary> The list of palettes. </summary> */
	public List<Palette> Palettes;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default graphics data. </summary> */
	public GraphicsData() {
		this.Images			= new List<Bitmap>();
		this.PaletteImages	= new List<PaletteImage>();
		this.Palettes		= new List<Palette>();
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the graphics data. </summary> */
	public Palette ReadPalette(BinaryReader reader, long startPosition, int i, ImageDirectory directory, Palette colorPalette) {
		ImageEntry entry = directory.Entries[i];
		if (entry.Flags == ImageFlags.PaletteEntries) {
			Palette palette = new Palette(entry.Width);
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			// Read each color
			for (int j = 0; j < entry.Width; j++) {
				// Yes the colors are in the order blue, green, red
				byte blue = reader.ReadByte();
				byte green = reader.ReadByte();
				byte red = reader.ReadByte();

				palette.Colors[j] = Color.FromArgb(red, green, blue);
			}
			return palette;
		}
		return null;
	}
	/** <summary> Reads the graphics data. </summary> */
	public PaletteImage ReadPaletteImage(BinaryReader reader, long startPosition, int i, ImageDirectory directory, Palette colorPalette) {
		ImageEntry entry = directory.Entries[i];
		if (entry.Flags == ImageFlags.DirectBitmap) {
			PaletteImage paletteImage = new PaletteImage(entry.Width, entry.Height);
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			// Read each row
			for (int y = 0; y < entry.Height; y++) {
				for (int x = 0; x < entry.Width; x++) {
					byte b = reader.ReadByte();
					paletteImage.Pixels[x, y] = b;
				}
			}

			return paletteImage;
		}
		else if (entry.Flags == ImageFlags.CompactedBitmap) {
			PaletteImage paletteImage = new PaletteImage(entry.Width, entry.Height);
			uint[] rowOffsets = new uint[entry.Height];
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			// Read the row offsets
			for (int j = 0; j < entry.Height; j++) {
				rowOffsets[j] = reader.ReadUInt16();
			}

			// Read the scan lines in each row
			for (int j = 0; j < entry.Height; j++) {
				reader.BaseStream.Position = startPosition + entry.StartAddress + rowOffsets[j];
				byte b1 = 0;
				byte b2 = 0;

				// A MSB of 1 means the last scan line in a row
				while ((b1 & 0x80) == 0) {
					// Read the number of bytes of data
					b1 = reader.ReadByte();
					// Read the offset from the left edge of the image
					b2 = reader.ReadByte();
					for (int k = 0; k < (int)(b1 & 0x7F); k++) {
						byte b3 = reader.ReadByte();
						try {
							paletteImage.Pixels[(int)b2 + k, j] = b3;
						}
						catch (Exception) {
						}
					}
				}
			}
			
			return paletteImage;
		}
		return null;
	}
	/** <summary> Reads the graphics data. </summary> */
	public Bitmap Read(BinaryReader reader, long startPosition, int i, ImageDirectory directory, Palette colorPalette) {
		GraphicsData.LastPaletteText = "";
		if (i >= 23215 && i <= 23216)
			colorPalette = Palette.ChrisSawyerPalette;
		else if (i >= 23218 && i <= 23223)
			colorPalette = Palette.LogoPalette;

		ImageEntry entry = directory.Entries[i];
		if (entry.Flags == ImageFlags.DirectBitmap) {
			Bitmap image = new Bitmap(entry.Width, entry.Height);
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			// Read each row
			for (int y = 0; y < entry.Height; y++) {
				for (int x = 0; x < entry.Width; x++) {
					byte b = reader.ReadByte();
					image.SetPixel(x, y, colorPalette.Colors[b]);
				}
			}

			return image;
		}
		else if (entry.Flags == ImageFlags.CompactedBitmap) {
			Bitmap image = new Bitmap(entry.Width, entry.Height);
			uint[] rowOffsets = new uint[entry.Height];
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			// Read the row offsets
			for (int j = 0; j < entry.Height; j++) {
				rowOffsets[j] = reader.ReadUInt16();
			}

			// Read the scan lines in each row
			for (int j = 0; j < entry.Height; j++) {
				reader.BaseStream.Position = startPosition + entry.StartAddress + rowOffsets[j];
				byte b1 = 0;
				byte b2 = 0;

				// A MSB of 1 means the last scan line in a row
				while ((b1 & 0x80) == 0) {
					// Read the number of bytes of data
					b1 = reader.ReadByte();
					// Read the offset from the left edge of the image
					b2 = reader.ReadByte();
					for (int k = 0; k < (int)(b1 & 0x7F); k++) {
						byte b3 = reader.ReadByte();
						try {
							image.SetPixel((int)b2 + k, j, colorPalette.Colors[b3]);
						}
						catch (Exception) {
							Console.WriteLine("Help");
						}
					}
				}
			}

			return image;
		}
		else if (entry.Flags == ImageFlags.PaletteEntries) {
			Bitmap image = new Bitmap(16 * 10, 16 * 10);
			reader.BaseStream.Position = startPosition + entry.StartAddress;

			GraphicsData.LastPaletteText += "Colors: " + entry.Width.ToString() + "\r\nOffset: " + entry.XOffset.ToString();

			// Read each color
			for (int j = 0; j < entry.Width; j++) {
				// Yes the colors are in the order blue, green, red
				byte blue = reader.ReadByte();
				byte green = reader.ReadByte();
				byte red = reader.ReadByte();

				if (j % 12 == 0)
					GraphicsData.LastPaletteText += "\r\n\r\n";
				else if (j % 4 == 0)
					GraphicsData.LastPaletteText += "\r\n";
				else
					GraphicsData.LastPaletteText += " ";

				GraphicsData.LastPaletteText += "(" + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
				if (j + 1 < entry.Width)
					GraphicsData.LastPaletteText += ",";

				for (int x = 0; x < 10; x++) {
					for (int y = 0; y < 10; y++) {
						image.SetPixel(((entry.XOffset + j) % 16) * 10 + x, ((entry.XOffset + j) / 16) * 10 + y, Color.FromArgb(red, green, blue));
					}
				}
			}
			return image;
		}
		return null;
	}
	/** <summary> Writes the graphics data. </summary> */
	public void Write(BinaryWriter writer, ImageDirectory directory) {
		long startPosition = writer.BaseStream.Position;

		for (int i = 0; i < directory.Count; i++) {
			ImageEntry entry = directory.Entries[i];
			entry.StartAddress = (uint)(writer.BaseStream.Position - startPosition);

			if (entry.Flags == ImageFlags.DirectBitmap) {
				PaletteImage paletteImage = this.PaletteImages[i];// new PaletteImage(entry.Width, entry.Height);

				// Write each row
				for (int y = 0; y < entry.Height; y++) {
					// Write each pixel in the row
					for (int x = 0; x < entry.Width; x++) {
						writer.Write(paletteImage.Pixels[x, y]);
					}
				}
			}
			else if (entry.Flags == ImageFlags.CompactedBitmap) {
				PaletteImage paletteImage = this.PaletteImages[i];// new PaletteImage(entry.Width, entry.Height);

				List<ScanLine> scanLines = new List<ScanLine>();
				ushort[] rowOffsets = new ushort[entry.Height];
				ushort rowOffset = (ushort)(entry.Height * 2);

				// Write the scan lines in every row and figure out the scan line row offsets
				for (int y = 0; y < (int)entry.Height; y++) {
					rowOffsets[y] = rowOffset;

					ScanLine scanLine = new ScanLine();
					scanLine.Row = (short)y;

					// Continue until the next row
					while ((scanLine.Count & 0x80) == 0x00) {
						// Reset the scan line count
						scanLine.Count = 0;

						// Find each scan line and then check if there's another one in the row
						bool finishedScanLine = false;
						bool lastScanLine = true;
						for (int x = 0; x + (int)scanLine.Offset < (int)entry.Width; x++) {
							if (!finishedScanLine) {
								if (scanLine.Count == 0) {
									// If the scan line hasn't started yet, increment the offset
									if (paletteImage.Pixels[x + scanLine.Offset, y] == 0x00) {
										scanLine.Offset++;
										x--;
									}
									else {
										scanLine.Count = 1;
									}
								}
								else if (paletteImage.Pixels[x + scanLine.Offset, y] == 0x00 || x == 0x7F) {
									// If the next pixel is transparent or the scan line is as big as possible, finish the line
									finishedScanLine = true;
								}
								else {
									// Increment the scan line byte count
									scanLine.Count++;
								}
							}
							else if (paletteImage.Pixels[x + scanLine.Offset, y] != 0x00) {
								// There is another scan line after this
								lastScanLine = false;
								break;
							}
						}
						// Set the end flag if the scan line is the last in the row
						if (lastScanLine)
							scanLine.Count |= 0x80;
						// If the row has all transparent pixels, set the offset to 0
						if (scanLine.Count == 0) {
							scanLine.Offset = 0;
							scanLine.Count = 0;
						}

						rowOffset += (ushort)(2 + (scanLine.Count & 0x7F));
						scanLines.Add(scanLine);

						// Increment the scan line count
						if (!lastScanLine)
							scanLine.Offset += (byte)(scanLine.Count & 0x7F);
					}
				}

				// Write the row offsets
				for (int j = 0; j < entry.Height; j++) {
					writer.Write(rowOffsets[j]);
				}

				// Write the scan lines
				for (int j = 0; j < scanLines.Count; j++) {
					writer.Write(scanLines[j].Count);
					writer.Write(scanLines[j].Offset);
					for (int k = 0; k < (int)(scanLines[j].Count & 0x7F); k++) {
						try {
							writer.Write(paletteImage.Pixels[k + scanLines[j].Offset, scanLines[j].Row]);
						}
						catch (Exception) {
							Console.WriteLine("Help");
						}
					}
				}
			}
			else if (entry.Flags == ImageFlags.PaletteEntries) {
				Palette palette = new Palette(entry.Width);

				// Write each color
				for (int j = 0; j < entry.Width; j++) {
					// Yes the colors are in the order blue, green, red
					writer.Write(palette.Colors[j].B);
					writer.Write(palette.Colors[j].G);
					writer.Write(palette.Colors[j].R);
				}
			}
		}
	}

	#endregion
}
/** <summary> A structure for storing scan lines in an image. </summary> */
public struct ScanLine {
	/** <summary> The row this scan line is on. </summary> */
	public short Row;
	/** <summary> The number of bytes in the scan line. </summary> */
	public byte Count;
	/** <summary> The offset of the scan line from the left side of the image. </summary> */
	public byte Offset;
}
}
