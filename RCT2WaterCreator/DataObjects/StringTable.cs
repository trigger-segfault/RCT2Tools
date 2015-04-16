using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects {
/** <summary> A string entry used in string tables. </summary> */
public class StringEntry {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The list of different languages for the string. </summary> */
	public string[] Languages;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default string entry. </summary> */
	public StringEntry() {
		this.Languages = new string[16];
		for (int i = 0; i < this.Languages.Length; i++) {
			this.Languages[i] = "";
		}
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets or sets a language for the string. </summary> */
	public string this[int index] {
		get { return Languages[index]; }
		set { Languages[index] = value; }
	}
	/** <summary> Gets or sets a language for the string. </summary> */
	public string this[Languages index] {
		get { return Languages[(int)index]; }
		set { Languages[(int)index] = value; }
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the string languages. </summary> */
	public void Read(BinaryReader reader) {
		// Specifies the index of the language, or 0xFF to end the string table
		byte b = reader.ReadByte();

		// If the language index is 0xFF, end the string table
		while (b != 0xFF) {
			// Read the null-terminated string
			string str = "";
			char c = (char)reader.ReadByte();
			while (c != 0x00) {
				str += c;
				c = (char)reader.ReadByte();
			}
			if (b < this.Languages.Length)
				this.Languages[b] = str;

			// Read the byte for the next language
			b = reader.ReadByte();
		}
	}
	/** <summary> Writes the string languages. </summary> */
	public void Write(BinaryWriter writer) {

		// Write the string in each language
		for (int i = 0; i < this.Languages.Length; i++) {
			if (this.Languages[i].Length == 0)
				continue;
			// Write the language id of the string
			writer.Write((byte)i);

			// Write the string
			for (int j = 0; j < this.Languages[i].Length; j++) {
				writer.Write((byte)this.Languages[i][j]);
			}

			// Write the null-termination
			writer.Write((byte)0x00);
		}
		// End the string table with 0xFF
		writer.Write((byte)0xFF);
	}

	#endregion
}
/** <summary> A collection of string entries. </summary> */
public class StringTable {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The list of string entries. </summary> */
	public List<StringEntry> Entries;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default string table. </summary> */
	public StringTable() {
		this.Entries = new List<StringEntry>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the number of string entries. </summary> */
	public int Count {
		get { return Entries.Count; }
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the specified number of string entries. </summary> */
	public void Read(BinaryReader reader, int numEntries = 1) {
		for (int i = 0; i < numEntries; i++) {
			StringEntry entry = new StringEntry();
			entry.Read(reader);
			this.Entries.Add(entry);
		}
	}
	/** <summary> Writes the string table entries. </summary> */
	public void Write(BinaryWriter writer) {
		for (int i = 0; i < this.Entries.Count; i++) {
			this.Entries[i].Write(writer);
		}
	}
	
	#endregion
}
/** <summary> The list of different lanuages. </summary> */
public enum Languages : byte {
	British = 0,
	American = 1,
	French = 2,
	German = 3,
	Spanish = 4,
	Italian = 5,
	Dutch = 6,
	Swedish = 7,
	Korean = 9,
	Chinese = 10,
	Chinese2 = 11,
	Portugese = 13,

	Unused1 = 8,
	Unused2 = 11,
	Unused3 = 12,
	Unused4 = 14,
	Unused5 = 15
}
}
