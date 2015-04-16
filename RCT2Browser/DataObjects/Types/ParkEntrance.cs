using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types {
/** <summary> A small scenery object. </summary> */
public class ParkEntrance : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x08;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public ParkEntranceHeader Header;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public ParkEntrance() : base() {
		this.Header				= new ParkEntranceHeader();
	}
	/** <summary> Constructs the default object. </summary> */
	public ParkEntrance(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header				= new ParkEntranceHeader();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			return ObjectSubtypes.Entrance;
		}
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}

	#endregion
	//========== OVERRIDES ===========
	#region Overrides
	//--------------------------------
	#region Reading

	/** <summary> Reads the object. </summary> */
	public override void Read(BinaryReader reader) {
		Header.Read(reader);

		stringTable.Read(reader);

		imageDirectory.Read(reader);
		graphicsData.Read(reader, imageDirectory);
	}
	/** <summary> Writes the object. </summary> */
	public override void Write(BinaryWriter writer) {
		// Write the header
		Header.Write(writer);

		// Write the 1 string table entry
		stringTable.Write(writer);

		long imageDirectoryPosition = writer.BaseStream.Position;

		// Write the image directory and graphics data
		imageDirectory.Write(writer);
		graphicsData.Write(writer, imageDirectory);

		// Rewrite the image directory after the image addresses are known
		long finalPosition = writer.BaseStream.Position;
		writer.BaseStream.Position = imageDirectoryPosition;
		imageDirectory.Write(writer);

		// Set the position to the end of the file so the file size is known
		writer.BaseStream.Position = finalPosition;
	}

	#endregion
	//--------------------------------
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(Graphics g, Point position, int rotation = 0, int corner = 0, int slope = -1, int elevation = 0, int frame = 0) {
		try {
			int xoffset = ((rotation == 1 || rotation == 2) ? -32 : 32);
			int yoffset = ((rotation == 2 || rotation == 3) ? -16 : 16);
			if (rotation >= 2) { xoffset *= -1; yoffset *= -1; }
			int sideFrame = (rotation < 2 ? 0 : 1);

			g.DrawImage(graphicsData.Images[rotation * 3 + 1 + sideFrame], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 1 + sideFrame].XOffset - xoffset,
				position.Y + imageDirectory.Entries[rotation * 3 + 1 + sideFrame].YOffset - yoffset
			));
			g.DrawImage(graphicsData.Images[rotation * 3 + 0], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 0].XOffset,
				position.Y + imageDirectory.Entries[rotation * 3 + 0].YOffset
			));
			g.DrawImage(graphicsData.Images[rotation * 3 + 2 - sideFrame], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 2 - sideFrame].XOffset + xoffset,
				position.Y + imageDirectory.Entries[rotation * 3 + 2 - sideFrame].YOffset + yoffset
			));
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			int xoffset = ((rotation == 1 || rotation == 2) ? -32 : 32);
			int yoffset = ((rotation == 2 || rotation == 3) ? -16 : 16);
			if (rotation >= 2) { xoffset *= -1; yoffset *= -1; }
			int sideFrame = (rotation < 2 ? 0 : 1);

			g.DrawImage(graphicsData.Images[rotation * 3 + 1 + sideFrame], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 1 + sideFrame].XOffset - xoffset + 112 / 2,
				position.Y + imageDirectory.Entries[rotation * 3 + 1 + sideFrame].YOffset - yoffset + 112 / 2 + 20
			));
			g.DrawImage(graphicsData.Images[rotation * 3 + 0], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 0].XOffset + 112 / 2,
				position.Y + imageDirectory.Entries[rotation * 3 + 0].YOffset + 112 / 2 + 20
			));
			g.DrawImage(graphicsData.Images[rotation * 3 + 2 - sideFrame], new Point(
				position.X + imageDirectory.Entries[rotation * 3 + 2 - sideFrame].XOffset + xoffset + 112 / 2,
				position.Y + imageDirectory.Entries[rotation * 3 + 2 - sideFrame].YOffset + yoffset + 112 / 2 + 20
			));
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, int frame) {

		g.DrawImage(graphicsData.Images[frame], position.X - imageDirectory.Entries[frame].Width / 2, position.Y - imageDirectory.Entries[frame].Height / 2);
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for small scenery objects. </summary> */
public class ParkEntranceHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Six bytes of data that are always zero in dat files. </summary> */
	public byte[] Reserved;
	/** <summary> The x position of the sign text. </summary> */
	public byte SignX;
	/** <summary> The y position of the sign text. </summary> */
	public byte SignY;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public ParkEntranceHeader() {
		this.Reserved = new byte[6];
		this.SignX	= 0;
		this.SignY	= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return ParkEntrance.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Entrance;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		ParkEntranceHeader header = new ParkEntranceHeader();
		header.Read(reader);
		return ObjectSubtypes.Entrance;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		reader.Read(this.Reserved, 0, this.Reserved.Length);
		this.SignX	= reader.ReadByte();
		this.SignY	= reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.Reserved);
		writer.Write(this.SignX);
		writer.Write(this.SignY);
	}

	#endregion
}
}
