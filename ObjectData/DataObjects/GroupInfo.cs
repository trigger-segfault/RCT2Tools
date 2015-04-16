using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {
/** <summary> Information about an object's group. </summary> */
public class GroupInfo {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The flags of the group. </summary> */
	public GroupInfoFlags Flags;
	/** <summary> The file name of the scenery group. </summary> */
	public string FileName;
	/** <summary> The checksum of the group info. </summary> */
	public uint CheckSum;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default group info. </summary> */
	public GroupInfo() {
		this.Flags = GroupInfoFlags.None;
		this.FileName = "";
		this.CheckSum = 0;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the group info. </summary> */
	public void Read(BinaryReader reader) {
		this.Flags = (GroupInfoFlags)reader.ReadUInt32();
		this.FileName = "";
		for (int i = 0; i < 8; i++) {
			char c = (char)reader.ReadByte();
			if (c != ' ' && c != '\0')
				this.FileName += c;
		}
		this.CheckSum = reader.ReadUInt32();
	}
	/** <summary> Writes the group info. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write((uint)this.Flags);
		for (int i = 0; i < 8; i++) {
			if (i < this.FileName.Length)
				writer.Write((byte)this.FileName[i]);
			else
				writer.Write((byte)' ');
		}
		writer.Write(this.CheckSum);
	}

	#endregion
}
/** <summary> Information about an object's group. </summary> */
[Flags]
public enum GroupInfoFlags : uint {
	/** <summary> No flags are selected. </summary> */
	None = 0x00000000,
	/** <summary> This is a default item in the group. </summary> */
	DefaultItem = 0xFF000000,
	/** <summary> This is an official scenery group. </summary> */
	OfficialGroup = 0x00000087,
	/** <summary> This is a custom scenery group. </summary> */
	CustomGroup = 0x00000007
}
}
