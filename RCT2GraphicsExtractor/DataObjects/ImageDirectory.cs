using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects {
/** <summary> An entry for an image. </summary> */
public class ImageEntry {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The start address of the image, 0 is the position after the image directory. </summary> */
	public uint StartAddress;
	/** <summary> The width of the image, or number of colors in the palette. </summary> */
	public short Width;
	/** <summary> The height of the image. </summary> */
	public short Height;
	/** <summary> The x offset of the image, or the starting index of the palette. </summary> */
	public short XOffset;
	/** <summary> The y offset of the image. </summary> */
	public short YOffset;
	/** <summary> The image type flags. </summary> */
	public ImageFlags Flags;
	/** <summary> Unused. </summary> */
	public ushort Unused;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default image entry. </summary> */
	public ImageEntry() {
		this.StartAddress	= 0;
		this.Width			= 0;
		this.Height			= 0;
		this.XOffset		= 0;
		this.YOffset		= 0;
		this.Flags			= ImageFlags.None;
		this.Unused			= 0;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the image entry. </summary> */
	public void Read(BinaryReader reader) {
		this.StartAddress	= reader.ReadUInt32();
		this.Width			= reader.ReadInt16();
		this.Height			= reader.ReadInt16();
		this.XOffset		= reader.ReadInt16();
		this.YOffset		= reader.ReadInt16();
		this.Flags			= (ImageFlags)reader.ReadUInt16();
		this.Unused			= reader.ReadUInt16();
	}
	/** <summary> Writes the image entry. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.StartAddress);
		writer.Write(this.Width);
		writer.Write(this.Height);
		writer.Write(this.XOffset);
		writer.Write(this.YOffset);
		writer.Write((ushort)this.Flags);
		writer.Write(this.Unused);
	}

	#endregion
}
/** <summary> A directory of image entries. </summary> */
public class ImageDirectory {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The number of images to read. </summary> */
	public int Count;
	/** <summary> The length of scan lines. </summary> */
	public int ScanLineLength;
	/** <summary> The list of image entries. </summary> */
	public List<ImageEntry> Entries;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default image directory. </summary> */
	public ImageDirectory() {
		this.Count			= 0;
		this.ScanLineLength	= 0;
		this.Entries		= new List<ImageEntry>();
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the image directory. </summary> */
	public void Read(BinaryReader reader) {
		this.Count = reader.ReadInt32();
		this.ScanLineLength = reader.ReadInt32();

		for (int i = 0; i < this.Count; i++) {
			ImageEntry entry = new ImageEntry();
			entry.Read(reader);
			this.Entries.Add(entry);
		}
	}
	/** <summary> Writes the image directory. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Count);
		writer.Write(this.ScanLineLength);

		for (int i = 0; i < this.Count; i++) {
			this.Entries[i].Write(writer);
		}
	}

	#endregion
}
/** <summary> The image type flags. </summary> */
[Flags]
public enum ImageFlags : ushort {
	/** <summary> No flag selected. </summary> */
	None = 0,
	/** <summary> The bitmap is read directly. </summary> */
	DirectBitmap = 1,
	/** <summary> The bitmap is compacted. </summary> */
	CompactedBitmap = 5,
	/** <summary> The image is a collection of palette entries. </summary> */
	PaletteEntries = 8
}
}
