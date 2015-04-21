using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A wall object. </summary> */
public class SceneryGroup : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x10E;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public SceneryGroupHeader Header;

	/** <summary> The contents of the scenery group. </summary> */
	public List<SceneryGroupItem> Items;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public SceneryGroup() : base() {
		this.Header	= new SceneryGroupHeader();
		this.Items	= new List<SceneryGroupItem>();
	}
	/** <summary> Constructs the default object. </summary> */
	internal SceneryGroup(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header	= new SceneryGroupHeader();
		this.Items	= new List<SceneryGroupItem>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Reading

	/** <summary> Gets the number of string table entries in the object. </summary> */
	protected override int NumStringTableEntries {
		get { return 1; }
	}
	/** <summary> Returns true if the object has a group info section. </summary> */
	protected override bool HasGroupInfo {
		get { return false; }
	}

	#endregion
	//--------------------------------
	#region Information

	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get { return ObjectSubtypes.Group; }
	}
	/** <summary> True if the object can be placed on a slope. </summary> */
	public override bool CanSlope {
		get { return false; }
	}
	/** <summary> Gets the number of color remaps. </summary> */
	public override int ColorRemaps {
		get { return 0; }
	}
	/** <summary> Gets if the dialog view has color remaps. </summary> */
	public override bool HasDialogColorRemaps {
		get { return false; }
	}
	/** <summary> Gets the number of frames in the animation. </summary> */
	public override int AnimationFrames {
		get { return 2; }
	}
	/** <summary> Gets the palette to draw the object with. </summary> */
	public override Palette GetPalette(DrawSettings drawSettings) {
		return Palette.SceneryGroupPalette;
	}

	#endregion
	//--------------------------------
	#endregion
	//=========== SCENERY ============
	#region Scenery

	/** <summary> Returns true if the object is a scenery object. </summary> */
	public bool IsSceneryObject(uint flags) {
		ObjectTypes type = (ObjectTypes)(flags % 0xF);
		return type == ObjectTypes.SmallScenery || type == ObjectTypes.LargeScenery || type == ObjectTypes.Wall || type == ObjectTypes.PathBanner || type == ObjectTypes.PathAddition;
	}
	/** <summary> Gets the scenery group item at the specified index. </summary> */
	public SceneryGroupItem Get(int index) {
		return this.Items[index];
	}
	/** <summary> Sets the specified scenery group item at the specified index. </summary> */
	public bool Set(int index, uint flags, string fileName, uint checksum) {
		if (IsSceneryObject(flags)) {
			this.Items[index] = new SceneryGroupItem(flags, fileName, checksum);
			return true;
		}
		return false;
	}
	/** <summary> Sets the specified scenery group item at the specified index. </summary> */
	public bool Set(int index, SceneryGroupItem item) {
		return Set(index, item.Flags, item.FileName, item.CheckSum);
	}
	/** <summary> Sets the specified scenery group item at the specified index. </summary> */
	public bool Set(int index, ObjectData obj) {
		return Set(index, obj.ObjectHeader.Flags, obj.ObjectHeader.FileName, obj.ObjectHeader.CheckSum);
	}
	/** <summary> Sets the specified scenery group item at the specified index. </summary> */
	public bool Set(int index, ObjectDataInfo objInfo) {
		return Set(index, objInfo.Flags, objInfo.FileName, objInfo.CheckSum);
	}
	/** <summary> Sets the specified scenery group item at the specified index. </summary> */
	public bool Set(int index, string path) {
		ObjectDataHeader obj = ObjectDataHeader.FromFile(path);
		return Set(index, obj.Flags, obj.FileName, obj.CheckSum);
	}
	/** <summary> Adds the specified scenery object to the scenery group. </summary> */
	public bool Add(uint flags, string fileName, uint checksum) {
		if (IsSceneryObject(flags)) {
			this.Items.Add(new SceneryGroupItem(flags, fileName, checksum));
			return true;
		}
		return false;
	}
	/** <summary> Adds the specified scenery object to the scenery group. </summary> */
	public bool Add(SceneryGroupItem item) {
		return Add(item.Flags, item.FileName, item.CheckSum);
	}
	/** <summary> Adds the specified scenery object to the scenery group. </summary> */
	public bool Add(ObjectData obj) {
		return Add(obj.ObjectHeader.Flags, obj.ObjectHeader.FileName, obj.ObjectHeader.CheckSum);
	}
	/** <summary> Adds the specified scenery object to the scenery group. </summary> */
	public bool Add(ObjectDataInfo objInfo) {
		return Add(objInfo.Flags, objInfo.FileName, objInfo.CheckSum);
	}
	/** <summary> Adds the specified scenery object to the scenery group. </summary> */
	public bool Add(string path) {
		ObjectDataHeader obj = ObjectDataHeader.FromFile(path);
		return Add(obj.Flags, obj.FileName, obj.CheckSum);
	}
	/** <summary> Inserts the specified scenery object to the scenery group at the specified index. </summary> */
	public bool Insert(int index, uint flags, string fileName, uint checksum) {
		if (IsSceneryObject(flags)) {
			this.Items.Insert(index, new SceneryGroupItem(flags, fileName, checksum));
			return true;
		}
		return false;
	}
	/** <summary> Inserts the specified scenery object to the scenery group at the specified index. </summary> */
	public bool Insert(int index, SceneryGroupItem item) {
		return Insert(index, item.Flags, item.FileName, item.CheckSum);
	}
	/** <summary> Inserts the specified scenery object to the scenery group at the specified index. </summary> */
	public bool Insert(int index, ObjectData obj) {
		return Insert(index, obj.ObjectHeader.Flags, obj.ObjectHeader.FileName, obj.ObjectHeader.CheckSum);
	}
	/** <summary> Inserts the specified scenery object to the scenery group at the specified index. </summary> */
	public bool Insert(int index, ObjectDataInfo objInfo) {
		return Insert(index, objInfo.Flags, objInfo.FileName, objInfo.CheckSum);
	}
	/** <summary> Inserts the specified scenery object to the scenery group at the specified index. </summary> */
	public bool Insert(int index, string path) {
		ObjectDataHeader obj = ObjectDataHeader.FromFile(path);
		return Insert(index, obj.Flags, obj.FileName, obj.CheckSum);
	}
	/** <summary> Removes the scenery group item at the specified index. </summary> */
	public void RemoveAt(int index) {
		this.Items.RemoveAt(index);
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	protected override void ReadHeader(BinaryReader reader) {
		Header.Read(reader);
	}
	/** <summary> Writes the object. </summary> */
	protected override void WriteHeader(BinaryWriter writer) {
		Header.Write(writer);
	}
	/** <summary> Reads the object data optional. </summary> */
	protected override void ReadOptional(BinaryReader reader) {
		// Read Contents
		byte b = reader.ReadByte();

		while (b != 0xFF) {
			reader.BaseStream.Position--;
			uint flags = reader.ReadUInt32();
			string fileName = "";
			for (int i = 0; i < 8; i++) {
				char c = (char)reader.ReadByte();
				if (c != ' ')
					fileName += c;
			}
			uint checkSum = reader.ReadUInt32();
			this.Items.Add(new SceneryGroupItem(flags, fileName, checkSum));

			b = reader.ReadByte();
		}
	}
	/** <summary> Writes the object data optional. </summary> */
	protected override void WriteOptional(BinaryWriter writer) {
		// Write Contents
		for (int i = 0; i < this.Items.Count; i++) {
			writer.Write(this.Items[i].Flags);
			for (int j = 0; j < 8; j++) {
				if (j < this.Items[i].FileName.Length)
					writer.Write(this.Items[i].FileName[j]);
				else
					writer.Write(' ');
			}
			writer.Write(this.Items[i].CheckSum);
		}
		writer.Write((byte)0xFF);
	}
	
	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Constructs the default object. </summary> */
	public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
		try {
			graphicsData.paletteImages[drawSettings.Frame].Draw(p, Point.Add(position, new Size(-16, -14)), 0, false, RemapColors.SeaGreen);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(PaletteImage p, Point position, Size dialogSize, DrawSettings drawSettings) {
		try {
			graphicsData.paletteImages[drawSettings.Frame].Draw(p, Point.Add(position, new Size(-16, -14)), 0, false, RemapColors.SeaGreen);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}

	#endregion
}
/** <summary> The header used for wall objects. </summary> */
public class SceneryGroupHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> 0x108 bytes of data that are always zero in dat files. </summary> */
	public byte[] Reserved0;
	/** <summary> An unknown byte that is never zero. </summary> */
	public byte Unknown0x108;
	/** <summary> Always zero in dat files. </summary> */
	public byte Reserved1;
	/** <summary> An unknown byte that is most often zero. </summary> */
	public byte Unknown0x10A;
	/** <summary> An unknown byte that is most often zero. </summary> */
	public byte Unknown0x10B;
	/** <summary> Always zero in dat files. </summary> */
	public ushort Reserved2;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public SceneryGroupHeader() {
		this.Reserved0		= new byte[0x108];
		this.Unknown0x108	= 0;
		this.Reserved1		= 0;
		this.Unknown0x10A	= 0;
		this.Unknown0x10B	= 0;
		this.Reserved2		= 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the size of the object type header. </summary> */
	internal override uint HeaderSize {
		get { return SceneryGroup.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	internal override ObjectSubtypes ObjectSubtype {
		get {
			return ObjectSubtypes.Group;
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	internal override void Read(BinaryReader reader) {
		reader.Read(this.Reserved0, 0, this.Reserved0.Length);
		this.Unknown0x108	= reader.ReadByte();
		this.Reserved1		= reader.ReadByte();
		this.Unknown0x10A	= reader.ReadByte();
		this.Unknown0x10B	= reader.ReadByte();
		this.Reserved2		= reader.ReadUInt16();
	}
	/** <summary> Writes the object header. </summary> */
	internal override void Write(BinaryWriter writer) {
		writer.Write(this.Reserved0);
		writer.Write(this.Unknown0x108);
		writer.Write(this.Reserved1);
		writer.Write(this.Unknown0x10A);
		writer.Write(this.Unknown0x10B);
		writer.Write(this.Reserved2);
	}

	#endregion
}
/** <summary> The header used for scenery group items. </summary> */
public class SceneryGroupItem {

	//=========== MEMBERS ============
	#region Members
	
	/** <summary> The flags of the scenery file. </summary> */
	public uint Flags;
	/** <summary> The name of the scenery file. </summary> */
	public string FileName;
	/** <summary> The checksum of the scenery file. </summary> */
	public uint CheckSum;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default scenery group item. </summary> */
	public SceneryGroupItem() {
		this.Flags = 0x0;
		this.FileName = "";
		this.CheckSum = 0x0;
	}
	/** <summary> Constructs the default scenery group item. </summary> */
	public SceneryGroupItem(uint flags, string fileName, uint checksum) {
		this.Flags = flags;
		this.FileName = fileName;
		this.CheckSum = checksum;
	}

	#endregion
}
}
