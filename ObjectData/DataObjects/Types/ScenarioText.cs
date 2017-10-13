using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types {
	/** <summary> A scenario text object. </summary> */
	public class ScenarioText : ObjectData {

		//========== CONSTANTS ===========
		#region Constants

		/** <summary> The size of the header for this object type. </summary> */
		public const uint HeaderSize = 0x8;

		#endregion
		//=========== MEMBERS ============
		#region Members

		/** <summary> The object header. </summary> */
		public ScenarioTextHeader Header;

		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the default object. </summary> */
		public ScenarioText() : base() {
			this.Header = new ScenarioTextHeader();
		}
		/** <summary> Constructs the default object. </summary> */
		internal ScenarioText(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
			: base(objectHeader, chunkHeader) {
			this.Header = new ScenarioTextHeader();
		}

		#endregion
		//========== PROPERTIES ==========
		#region Properties
		//--------------------------------
		#region Reading

		/** <summary> Gets the number of string table entries in the object. </summary> */
		public override int NumStringTableEntries {
			get { return 3; }
		}
		/** <summary> Returns true if the object has a group info section. </summary> */
		public override bool HasGroupInfo {
			get { return false; }
		}
		/** <summary> Returns true if the object has an image directory and graphics data section. </summary> */
		public override bool HasGraphics {
			get { return false; }
		}

		#endregion
		//--------------------------------
		#region Information

		/** <summary> Gets the subtype of the object. </summary> */
		public override ObjectSubtypes Subtype {
			get { return ObjectSubtypes.Text; }
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
			get { return 1; }
		}
		/** <summary> Gets the palette to draw the object with. </summary> */
		public override Palette GetPalette(DrawSettings drawSettings) {
			return Palette.SceneryGroupPalette;
		}

		#endregion
		//--------------------------------
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

		#endregion
		//=========== DRAWING ============
		#region Drawing

		/** <summary> Constructs the default object. </summary> */
		public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
			return true;
		}
		/** <summary> Draws the object data in the dialog. </summary> */
		public override bool DrawDialog(PaletteImage p, Point position, Size dialogSize, DrawSettings drawSettings) {
			return true;
		}

		#endregion
	}
	/** <summary> The header used for scenario text objects. </summary> */
	public class ScenarioTextHeader : ObjectTypeHeader {

		//=========== MEMBERS ============
		#region Members

		/** <summary> Six bytes of data that are always zero in dat files. </summary> */
		public byte[] Reserved0;
		/** <summary> Flags for this scenario text. A value of 0x1 means it's a six flags scenario. </summary> */
		public byte IsSixFlags;
		/** <summary> A byte of data that are always zero in dat files. </summary> */
		public byte Reserved1;

		#endregion
		//========= CONSTRUCTORS =========
		#region Constructors

		/** <summary> Constructs the default object header. </summary> */
		public ScenarioTextHeader() {
			this.Reserved0   = new byte[0x6];
			this.IsSixFlags  = 0;
			this.Reserved1   = 0;
		}

		#endregion
		//========== PROPERTIES ==========
		#region Properties

		/** <summary> Gets the size of the object type header. </summary> */
		internal override uint HeaderSize {
			get { return ScenarioText.HeaderSize; }
		}
		/** <summary> Gets the basic subtype of the object. </summary> */
		internal override ObjectSubtypes ObjectSubtype {
			get {
				return ObjectSubtypes.Text;
			}
		}

		#endregion
		//=========== READING ============
		#region Reading

		/** <summary> Reads the object header. </summary> */
		internal override void Read(BinaryReader reader) {
			reader.Read(this.Reserved0, 0, this.Reserved0.Length);
			this.IsSixFlags = reader.ReadByte();
			this.Reserved1 = reader.ReadByte();
		}
		/** <summary> Writes the object header. </summary> */
		internal override void Write(BinaryWriter writer) {
			writer.Write(this.Reserved0);
			writer.Write(this.IsSixFlags);
			writer.Write(this.Reserved1);
		}

		#endregion
	}
}
