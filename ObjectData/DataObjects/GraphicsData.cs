using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {
/** <summary> A graphics for each image in the object. </summary> */
public class GraphicsData {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The image directory referenced by the graphics data. </summary> */
	internal ImageDirectory imageDirectory;

	/** <summary> The list of palette images. </summary> */
	internal List<PaletteImage> paletteImages;
	/** <summary> The list of palettes. </summary> */
	internal List<Palette> palettes;

	/** <summary> The number of images in the graphics data. </summary> */
	internal int numImages;
	/** <summary> The palettes of images in the graphics data. </summary> */
	internal int numPalettes;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default graphics data with the specified image directory. </summary> */
	public GraphicsData(ImageDirectory imageDirectory) {
		this.imageDirectory	= imageDirectory;

		this.paletteImages	= new List<PaletteImage>();
		this.palettes		= new List<Palette>();
		this.numImages		= 0;
		this.numPalettes	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the number of palette images in the graphics data. </summary> */
	public int NumImages {
		get { return numImages; }
	}
	/** <summary> Gets the number of palettes in the graphics data. </summary> */
	public int NumPalettes {
		get { return numPalettes; }
	}

	#endregion
	//========== MANAGEMENT ==========
	#region Management
	//--------------------------------
	#region General

	/** <summary> Removes the palette or palette image at the specified index. </summary> */
	public void RemoveAt(int index) {
		if (this.paletteImages[index] != null)
			this.numImages--;
		else
			this.numPalettes--;
		this.paletteImages.RemoveAt(index);
		this.palettes.RemoveAt(index);
		this.imageDirectory.entries.RemoveAt(index);
	}

	#endregion
	//--------------------------------
	#region Palette Images

	/** <summary> Gets the palette image at the specified index. </summary> */
	public PaletteImage GetPaletteImage(int index) {
		return this.paletteImages[index];
	}
	/** <summary> Returns true if the entry at the specified index is a palette image. </summary> */
	public bool IsPaletteImage(int index) {
		return (this.paletteImages[index] != null);
	}
	/** <summary> Adds the specified palette image. </summary> */
	public void Add(PaletteImage paletteImage) {
		this.paletteImages.Add(paletteImage);
		this.palettes.Add(null);
		this.imageDirectory.entries.Add(paletteImage.entry);
		if (paletteImage != null)
			this.numImages++;
	}
	/** <summary> Removes the specified palette image. </summary> */
	public void Remove(PaletteImage paletteImage) {
		if (paletteImage != null) {
			int index = this.paletteImages.IndexOf(paletteImage);
			this.paletteImages.RemoveAt(index);
			this.palettes.RemoveAt(index);
			this.imageDirectory.entries.RemoveAt(index);
			this.numImages--;
		}
	}
	/** <summary> Sets the specified palette image at the specified index. </summary> */
	public void Set(int index, PaletteImage paletteImage) {
		if (paletteImage != null) {
			if (this.paletteImages[index] == null) {
				this.numImages++;
				if (this.palettes[index] != null) {
					this.palettes[index] = null;
					this.numPalettes--;
				}
			}
			this.paletteImages[index] = paletteImage;
			this.imageDirectory.entries[index] = paletteImage.entry;
		}
	}
	/** <summary> Inserts the specified palette image at the specified index. </summary> */
	public void Insert(int index, PaletteImage paletteImage) {
		if (paletteImage != null) {
			this.paletteImages.Insert(index, paletteImage);
			this.palettes.Insert(index, null);
			this.imageDirectory.entries.Insert(index, paletteImage.entry);
			this.numImages++;
		}
	}

	#endregion
	//--------------------------------
	#region Palettes

	/** <summary> Gets the palette at the specified index. </summary> */
	public Palette GetPalette(int index) {
		return this.palettes[index];
	}
	/** <summary> Returns true if the entry at the specified index is a palette. </summary> */
	public bool IsPalette(int index) {
		return (this.palettes[index] != null);
	}
	/** <summary> Adds the specified palette. </summary> */
	public void Add(Palette palette) {
		this.palettes.Add(palette);
		this.paletteImages.Add(null);
		this.imageDirectory.entries.Add(palette.entry);
		if (palette != null)
			this.numPalettes++;
	}
	/** <summary> Removes the specified palette. </summary> */
	public void Remove(Palette palette) {
		if (palette != null) {
			int index = this.palettes.IndexOf(palette);
			this.paletteImages.RemoveAt(index);
			this.imageDirectory.entries.RemoveAt(index);
			this.numPalettes--;
		}
	}
	/** <summary> Sets the specified palette at the specified index. </summary> */
	public void Set(int index, Palette palette) {
		if (palette != null) {
			if (this.palettes[index] == null) {
				this.numPalettes++;
				if (this.paletteImages[index] != null) {
					this.paletteImages[index] = null;
					this.numImages--;
				}
			}
			this.palettes[index] = palette;
			this.imageDirectory.entries[index] = palette.entry;
		}
	}
	/** <summary> Inserts the specified palette at the specified index. </summary> */
	public void Insert(int index, Palette palette) {
		if (palette != null) {
			this.palettes.Insert(index, palette);
			this.imageDirectory.entries.Insert(index, palette.entry);
			this.numPalettes++;
		}
	}

	#endregion
	//--------------------------------
	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the graphics data. </summary> */
	public void Read(BinaryReader reader) {
		long startPosition = reader.BaseStream.Position;

		for (int i = 0; i < imageDirectory.NumEntries; i++) {
			ImageEntry entry = imageDirectory.entries[i];
			if (entry.Flags == ImageFlags.DirectBitmap) {
				PaletteImage paletteImage = new PaletteImage(entry);
				reader.BaseStream.Position = startPosition + entry.StartAddress;

				// Read each row
				for (int y = 0; y < entry.Height; y++) {
					for (int x = 0; x < entry.Width; x++) {
						byte b = reader.ReadByte();
						paletteImage.Pixels[x, y] = b;
					}
				}
				this.paletteImages.Add(paletteImage);
				this.palettes.Add(null);
				this.numImages++;
			}
			else if (entry.Flags == ImageFlags.CompactedBitmap) {
				PaletteImage paletteImage = new PaletteImage(entry);
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
				this.paletteImages.Add(paletteImage);
				this.palettes.Add(null);
				this.numImages++;
			}
			else if (entry.Flags == ImageFlags.PaletteEntries) {
				Palette palette = new Palette(entry);
				reader.BaseStream.Position = startPosition + entry.StartAddress;

				// Read each color
				for (int j = 0; j < entry.Width; j++) {
					// Yes, the colors are in the order blue, green, red
					byte blue = reader.ReadByte();
					byte green = reader.ReadByte();
					byte red = reader.ReadByte();

					palette.Colors[j] = Color.FromArgb(red, green, blue);
				}
				this.paletteImages.Add(null);
				this.palettes.Add(palette);
				this.numPalettes++;
			}
		}
	}
	/** <summary> Writes the graphics data. </summary> */
	public void Write(BinaryWriter writer) {
		long startPosition = writer.BaseStream.Position;

		for (int i = 0; i < imageDirectory.NumEntries; i++) {
			ImageEntry entry = imageDirectory.entries[i];
			entry.StartAddress = (uint)(writer.BaseStream.Position - startPosition);

			if (entry.Flags == ImageFlags.DirectBitmap) {
				PaletteImage paletteImage = this.paletteImages[i];

				// Write each row
				for (int y = 0; y < entry.Height; y++) {
					// Write each pixel in the row
					for (int x = 0; x < entry.Width; x++) {
						writer.Write(paletteImage.Pixels[x, y]);
					}
				}
			}
			else if (entry.Flags == ImageFlags.CompactedBitmap) {
				PaletteImage paletteImage = this.paletteImages[i];

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
						}
					}
				}
			}
			else if (entry.Flags == ImageFlags.PaletteEntries) {
				Palette palette = this.palettes[i];

				// Write each color
				for (int j = 0; j < entry.Width; j++) {
					// Yes, the colors are in the order blue, green, red
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
internal struct ScanLine {
	/** <summary> The row this scan line is on. </summary> */
	public short Row;
	/** <summary> The number of bytes in the scan line. </summary> */
	public byte Count;
	/** <summary> The offset of the scan line from the left side of the image. </summary> */
	public byte Offset;
}
}
