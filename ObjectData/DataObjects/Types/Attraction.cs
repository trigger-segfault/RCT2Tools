using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;

namespace RCT2ObjectData.DataObjects.Types {
/** <summary> A attraction object. </summary> */
public class Attraction : ObjectData {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The size of the header for this object type. </summary> */
	public const uint HeaderSize = 0x1C2;

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The object header. </summary> */
	public AttractionHeader Header;
	/** <summary> The list of 3 colors for each car. </summary> */
	public List<RemapColors[]> CarColors;
	/** <summary> The list of peep positions on the ride. </summary> */
	public List<byte[]> RiderPositions;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object. </summary> */
	public Attraction() : base() {
		this.Header			= new AttractionHeader();
		this.CarColors		= new List<RemapColors[]>();
		this.RiderPositions	= new List<byte[]>();
	}
	/** <summary> Constructs the default object. </summary> */
	internal Attraction(ObjectDataHeader objectHeader, ChunkHeader chunkHeader)
		: base(objectHeader, chunkHeader) {
		this.Header			= new AttractionHeader();
		this.CarColors		= new List<RemapColors[]>();
		this.RiderPositions	= new List<byte[]>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	
	/** <summary> Gets the subtype of the object. </summary> */
	public override ObjectSubtypes Subtype {
		get {
			if (Header.RideType == RideTypes.Stall)
				return ObjectSubtypes.Stall;
			else if (Header.RideType == RideTypes.Transport)
				return ObjectSubtypes.TransportRide;
			else if (Header.RideType == RideTypes.Gentle)
				return ObjectSubtypes.GentleRide;
			else if (Header.RideType == RideTypes.Rollercoaster)
				return ObjectSubtypes.Rollercoaster;
			else if (Header.RideType == RideTypes.Thrill)
				return ObjectSubtypes.ThrillRide;
			else if (Header.RideType == RideTypes.Water)
				return ObjectSubtypes.WaterRide;
			return ObjectSubtypes.Basic;
		}
	}

	#endregion
	//========== OVERRIDES ===========
	#region Overrides
	//--------------------------------
	#region Reading

	/** <summary> Reads the object. </summary> */
	public override void Read(BinaryReader reader) {
		// Read the attraction and car headers
		Header.Read(reader);

		// Read the 3 string table entries
		stringTable.Read(reader, 3);

		// Read the 3 byte car color structures
		byte b = reader.ReadByte();
		int numStructures = ((b == 0xFF) ? 32 : b);
		for (int i = 0; i < numStructures; i++) {
			this.CarColors.Add(new RemapColors[3]);
			for (int j = 0; j < 3; j++) {
				this.CarColors[this.CarColors.Count - 1][j] = (RemapColors)reader.ReadByte();
			}
		}

		// Read the 4 variable-length rider position structures for each car type
		for (int i = 0; i < 4; i++) {
			byte b2 = reader.ReadByte();
			int structureLength = (b2 == 0xFF ? reader.ReadUInt16() : b2);
			this.RiderPositions.Add(new byte[structureLength]);
			for (int j = 0; j < structureLength; j++) {
				this.RiderPositions[i][j] = reader.ReadByte();
			}
		}

		// Read the image directory and graphics data
		imageDirectory.Read(reader);
		graphicsData.Read(reader);
	}
	/** <summary> Writes the object. </summary> */
	public override void Write(BinaryWriter writer) {
		// Write the attraction and car headers
		Header.Write(writer);

		// Write the 3 string table entries
		stringTable.Write(writer);

		// Write the number of car color structures
		if (this.CarColors.Count == 32)
			writer.Write((byte)0xFF);
		else
			writer.Write((byte)(this.CarColors.Count));

		// Write each car color structure
		for (int i = 0; i < this.CarColors.Count; i++) {
			for (int j = 0; j < 3; j++) {
				writer.Write((byte)this.CarColors[i][j]);
			}
		}

		// Write the rider positions for each car type
		for (int i = 0; i < this.RiderPositions.Count; i++) {
			if ((this.RiderPositions[i].Length & 0x00FF) == this.RiderPositions[i].Length && (ushort)this.RiderPositions[i].Length != 0x00FF) {
				// If the rider positions structure length is less than 255, write it as a single byte
				writer.Write((byte)this.RiderPositions[i].Length);
			}
			else {
				// If the rider positions structure length is greater than or equal 255 write it as an unsigned short
				writer.Write((byte)0xFF);
				writer.Write((ushort)this.RiderPositions[i].Length);
			}
			// Write the rider positions structure
			writer.Write(this.RiderPositions[i]);
		}

		long imageDirectoryPosition = writer.BaseStream.Position;

		// Write the image directory and graphics data
		imageDirectory.Write(writer);
		graphicsData.Write(writer);

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
	public override bool Draw(PaletteImage p, Point position, DrawSettings drawSettings) {
		try {
			if (Header.RideType == RideTypes.Stall) {
				graphicsData.paletteImages[3 + drawSettings.Rotation].Draw(p, 0, 0, drawSettings.Darkness, false,
					drawSettings.Remap1, RemapColors.None, RemapColors.None
				);
				if ((drawSettings.Rotation == 0 || drawSettings.Rotation == 3) && (Header.TrackType == TrackTypes.Restroom || Header.TrackType == TrackTypes.FirstAid)) {
					graphicsData.paletteImages[3 + 4 + drawSettings.Rotation / 3].Draw(p, 0, 0, drawSettings.Darkness, false,
						drawSettings.Remap1,
						RemapColors.None,
						RemapColors.None
					);
				}
			}
			else {
				int nextCarOffset = 0;
				for (int i = 0; i <= (int)drawSettings.CurrentCar; i++) {
					CarHeader car = Header.CarTypeList[i];
					int C = 0; // Offset for this car
					int R = car.LastRotationFrame + 1; // number of rotation frames
					int F = 1; // Number of frames per rotation
					int P = car.RiderSprites; // number of rider sprites
					if (car.Flags.HasFlag(CarFlags.Spinning)) {
						if (car.Flags.HasFlag(CarFlags.SpinningIndependantWheels))
							F *= (car.LastRotationFrame + 1);
					}
					if (car.Flags.HasFlag(CarFlags.Swinging)) {
						int swingingFrames = 5;
						if (car.Flags.HasFlag(CarFlags.SwingingMoreFrames))
							swingingFrames += 2;
						if (car.Flags.HasFlag(CarFlags.SwingingSlide))
							swingingFrames += 2;
						if (car.Flags.HasFlag(CarFlags.SwingingTilting))
							swingingFrames -= 2;
						F *= swingingFrames;
					}
					if (car.SpecialFrames != 0) {
						F *= car.SpecialFrames;
					}

					if (i == (int)drawSettings.CurrentCar) {
						graphicsData.paletteImages[3 + nextCarOffset + drawSettings.Rotation * F + drawSettings.Frame].Draw(g, 0, 0,
							Palette.DefaultPalette,
							drawSettings.Remap1,
							(car.Flags.HasFlag(CarFlags.Remap2) ? drawSettings.Remap2 : RemapColors.None),
							(!car.Flags.HasFlag(CarFlags.NoRemap3) ? drawSettings.Remap3 : RemapColors.None)
						);
					}
					else {
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.Flat))
							C += (R * F);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.GentleSlopes))
							C += ((4 * F) * 2) + ((R * F) * 2);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.SteepSlopes))
							C += ((8 * F) * 2) + ((R * F) * 2);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.VerticalSlopes))
							C += ((4 * F) * 2) + ((R * F) * 2) + (((4 * F) * 2) * 5) + (4 * F);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.DiagonalSlopes))
							C += ((4 * F) * 2) + ((4 * F) * 2) + ((4 * F) * 2);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.FlatBanked))
							C += ((8 * F) * 2) + ((R * F) * 2);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.InlineTwists))
							C += ((4 * F) * 10);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.FlatToGentleSlopeBankedTransitions))
							C += ((R * F) * 4);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.DiagonalGentleSlopeBankedTransitions))
							C += ((4 * F) * 4);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.GentleSlopeBankedTransitions))
							C += ((4 * F) * 4);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.GentleSlopeBankedTurns))
							C += ((R * F) * 4);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.FlatToGentleSlopeWhileBankedTransitions))
							C += ((4 * F) * 4);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.Corkscrews))
							C += ((4 * F) * 20);
						if (car.SpriteFlags.HasFlag(CarSpriteFlags.RestraintAnimation))
							C += ((4 * F) * 3);

						C *= (P + 1);
						nextCarOffset += C;
					}
				}

			}
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws the object data in the dialog. </summary> */
	public override bool DrawDialog(Graphics g, Point position, int rotation = 0) {
		try {
			graphicsData.paletteImages[Header.PreviewIndex].Draw(g, 0, 0, Palette.DefaultPalette, RemapColors.None, RemapColors.None, RemapColors.None);
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	/** <summary> Draws a single frame of the object. </summary> */
	public override bool DrawSingleFrame(Graphics g, Point position, DrawSettings drawSettings) {
		try {
			if (Header.RideType == RideTypes.Stall) {
				graphicsData.paletteImages[drawSettings.Frame].Draw(g,
					position.X - graphicsData.paletteImages[drawSettings.Frame].Width / 2,
					position.Y - graphicsData.paletteImages[drawSettings.Frame].Height / 2,
					Palette.DefaultPalette,
						drawSettings.Remap1,
						RemapColors.None,
						RemapColors.None
				);
			}
			else {
				graphicsData.paletteImages[drawSettings.Frame].Draw(g,
					position.X - imageDirectory.entries[drawSettings.Frame].Width / 2,
					position.Y - imageDirectory.entries[drawSettings.Frame].Height / 2,
					Palette.DefaultPalette,
						drawSettings.Remap1,
						drawSettings.Remap2,
						drawSettings.Remap3
				);
			}
		}
		catch (IndexOutOfRangeException) { return false; }
		catch (ArgumentOutOfRangeException) { return false; }
		return true;
	}
	
	#endregion
	//--------------------------------
	#endregion
}
/** <summary> The header used for attraction objects. </summary> */
public class AttractionHeader : ObjectTypeHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> This value is always zero in dat files. </summary> */
	public ulong Reserved0x00;

	/** <summary> The flags used for the attraction. </summary> */
	public AttractionFlags Flags;
	/** <summary> The list of track types used by the ride. </summary> */
	public TrackTypes[] TrackTypeList;

	/** <summary> The minimum number of cars per train. </summary> */
	public byte MinCarsPerTrain;
	/** <summary> The maximum number of cars per train. </summary> */
	public byte MaxCarsPerTrain;
	/** <summary> The number of cars per flat ride. 0xFF if ride is tracked. </summary> */
	public byte CarsPerFlatRide;

	/** <summary> The number of zero cars in the train. This value is subtracted from the total number of cars. </summary> */
	public byte ZeroCars;
	/** <summary> The index of the car shown in the car tab menu. </summary> */
	public byte CarTabIndex;

	/** <summary> The index of the default car used when no specified type fits. </summary> */
	public CarTypes DefaultCarType;
	/** <summary> The index of the front car type. </summary> */
	public CarTypes FrontCarType;
	/** <summary> The index of the second car type. </summary> */
	public CarTypes SecondCarType;
	/** <summary> The index of the rear car type. </summary> */
	public CarTypes RearCarType;
	/** <summary> The index of the third car type. </summary> */
	public CarTypes ThirdCarType;

	/** <summary> The value is always zero in dat files. </summary> */
	public byte Padding0x19;

	/** <summary> The list of defined car types. </summary> */
	public CarHeader[] CarTypeList;

	/** <summary> The additional excitement percentage of the ride. </summary> */
	public byte Excitement;
	/** <summary> The additional intensity percentage of the ride. </summary> */
	public byte Intensity;
	/** <summary> The additional nausea percentage of the ride. </summary> */
	public byte Nausea;

	/** <summary> Increases the maximum height of the ride. Theres a base value determined by the track type, and this only adds to it. </summary> */
	public byte MaxHeight;

	/** <summary> The main category of the ride. </summary> */
	public RideTypes RideType;
	/** <summary> The alternate category of the ride. </summary> */
	public RideTypes RideTypeAlternate;

	/** <summary> The available track sections that this ride supports in the editor. </summary> */
	public TrackSections AvailableTrackSections;

	/** <summary> The first item being sold by the stall. This can be specified for rides as well. </summary> */
	public ItemTypes SoldItem1;
	/** <summary> The second item being sold by the stall. This can be specified for rides as well. </summary> */
	public ItemTypes SoldItem2;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default object header. </summary> */
	public AttractionHeader() {
		this.Reserved0x00		= 0;

		this.Flags				= AttractionFlags.None;
		this.TrackTypeList		= new TrackTypes[3];
		for (int i = 0; i < this.TrackTypeList.Length; i++)
			this.TrackTypeList[i] = TrackTypes.None;

		this.MinCarsPerTrain	= 0;
		this.MaxCarsPerTrain	= 0;
		this.CarsPerFlatRide	= 0;

		this.ZeroCars			= 0;
		this.CarTabIndex		= 0;

		this.DefaultCarType		= CarTypes.CarType0;
		this.FrontCarType		= CarTypes.None;
		this.SecondCarType		= CarTypes.None;
		this.RearCarType		= CarTypes.None;
		this.ThirdCarType		= CarTypes.None;

		this.Padding0x19		= 0;

		this.CarTypeList		= new CarHeader[4];
		for (int i = 0; i < this.CarTypeList.Length; i++)
			this.CarTypeList[i]	= new CarHeader();

		this.Excitement			= 0;
		this.Intensity			= 0;
		this.Nausea				= 0;
		this.MaxHeight			= 0;

		this.AvailableTrackSections	= TrackSections.None;

		this.RideType			= RideTypes.None;
		this.RideTypeAlternate	= RideTypes.None;
		this.SoldItem1			= ItemTypes.None;
		this.SoldItem2			= ItemTypes.None;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the number of car types used. </summary> */
	public int CarCount {
		get {
			int count = (int)DefaultCarType;
			count = Math.Max(count, (int)(FrontCarType != CarTypes.None ? FrontCarType : 0));
			count = Math.Max(count, (int)(SecondCarType != CarTypes.None ? SecondCarType : 0));
			count = Math.Max(count, (int)(RearCarType != CarTypes.None ? RearCarType : 0));
			count = Math.Max(count, (int)(ThirdCarType != CarTypes.None ? ThirdCarType : 0));
			return count + 1;
		}
	}
	/** <summary> Gets or sets the primary type of track used by the ride. </summary> */
	public TrackTypes TrackType {
		get { return TrackTypeList[PreviewIndex]; }
		set { TrackTypeList[PreviewIndex] = value; }
	}
	/** <summary> Gets or sets the index of the primary type of track used by the ride. Do not set this property if you are using more than one track type. </summary> */
	public int PreviewIndex {
		get {
			for (int i = 0; i < 3; i++) {
				if (TrackTypeList[i] != TrackTypes.None)
					return i;
			}
			return 0;
		}
		set {
			if (value >= 0 && value < 2) {
				int previewIndex = 0;
				TrackTypes trackType = TrackTypes.None;
				for (int i = 0; i < 3; i++) {
					if (TrackTypeList[i] != TrackTypes.None) {
						if (trackType == TrackTypes.None) {
							previewIndex = i;
							trackType = TrackTypeList[i];
						}
						TrackTypeList[i] = TrackTypes.None;
					}
				}
				TrackTypeList[value] = trackType;
			}
		}
	}

	/** <summary> Gets the size of the object type header. </summary> */
	public override uint HeaderSize {
		get { return Attraction.HeaderSize; }
	}
	/** <summary> Gets the basic subtype of the object. </summary> */
	public override ObjectSubtypes ObjectSubtype {
		get {
			if (RideType == RideTypes.Stall)
				return ObjectSubtypes.Stall;
			else if (RideType == RideTypes.Transport)
				return ObjectSubtypes.TransportRide;
			else if (RideType == RideTypes.Gentle)
				return ObjectSubtypes.GentleRide;
			else if (RideType == RideTypes.Rollercoaster)
				return ObjectSubtypes.Rollercoaster;
			else if (RideType == RideTypes.Thrill)
				return ObjectSubtypes.ThrillRide;
			else if (RideType == RideTypes.Water)
				return ObjectSubtypes.WaterRide;
			return ObjectSubtypes.Basic;
		}
	}

	/** <summary> Gets the subtype of the object. </summary> */
	public static ObjectSubtypes ReadSubtype(BinaryReader reader) {
		AttractionHeader header = new AttractionHeader();
		header.Read(reader);
		if (header.RideType == RideTypes.Stall)
			return ObjectSubtypes.Stall;
		else if (header.RideType == RideTypes.Transport)
			return ObjectSubtypes.TransportRide;
		else if (header.RideType == RideTypes.Gentle)
			return ObjectSubtypes.GentleRide;
		else if (header.RideType == RideTypes.Rollercoaster)
			return ObjectSubtypes.Rollercoaster;
		else if (header.RideType == RideTypes.Thrill)
			return ObjectSubtypes.ThrillRide;
		else if (header.RideType == RideTypes.Water)
			return ObjectSubtypes.WaterRide;
		return ObjectSubtypes.Basic;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public override void Read(BinaryReader reader) {
		long startPosition = reader.BaseStream.Position;

		this.Reserved0x00 = reader.ReadUInt64();
		this.Flags = (AttractionFlags)reader.ReadUInt32();

		for (int i = 0; i < 3; i++) {
			this.TrackTypeList[i] = (TrackTypes)reader.ReadByte();
		}

		this.MinCarsPerTrain = reader.ReadByte();
		this.MaxCarsPerTrain = reader.ReadByte();
		this.CarsPerFlatRide = reader.ReadByte();

		this.ZeroCars = reader.ReadByte();
		this.CarTabIndex = reader.ReadByte();

		this.DefaultCarType = (CarTypes)reader.ReadByte();
		this.FrontCarType = (CarTypes)reader.ReadByte();
		this.SecondCarType = (CarTypes)reader.ReadByte();
		this.RearCarType = (CarTypes)reader.ReadByte();
		this.ThirdCarType = (CarTypes)reader.ReadByte();

		this.Padding0x19 = reader.ReadByte();

		for (int i = 0; i < 4; i++) {
			this.CarTypeList[i].Read(reader);
		}

		reader.BaseStream.Position = startPosition + 0x1B2;

		this.Excitement = reader.ReadByte();
		this.Intensity = reader.ReadByte();
		this.Nausea = reader.ReadByte();
		this.MaxHeight = reader.ReadByte();

		this.AvailableTrackSections = (TrackSections)reader.ReadUInt64();

		this.RideType = (RideTypes)reader.ReadByte();
		this.RideTypeAlternate = (RideTypes)reader.ReadByte();
		this.SoldItem1 = (ItemTypes)reader.ReadByte();
		this.SoldItem2 = (ItemTypes)reader.ReadByte();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		long startPosition = writer.BaseStream.Position;

		writer.Write(this.Reserved0x00);
		writer.Write((uint)this.Flags);

		for (int i = 0; i < 3; i++) {
			writer.Write((byte)this.TrackTypeList[i]);
		}

		writer.Write(this.MinCarsPerTrain);
		writer.Write(this.MaxCarsPerTrain);
		writer.Write(this.CarsPerFlatRide);

		writer.Write(this.ZeroCars);
		writer.Write(this.CarTabIndex);

		writer.Write((byte)this.DefaultCarType);
		writer.Write((byte)this.FrontCarType);
		writer.Write((byte)this.SecondCarType);
		writer.Write((byte)this.RearCarType);
		writer.Write((byte)this.ThirdCarType);

		writer.Write(this.Padding0x19);

		for (int i = 0; i < 4; i++) {
			this.CarTypeList[i].Write(writer);
		}

		writer.BaseStream.Position = startPosition + 0x1B2;

		writer.Write(this.Excitement);
		writer.Write(this.Intensity);
		writer.Write(this.Nausea);
		writer.Write(this.MaxHeight);

		writer.Write((ulong)this.AvailableTrackSections);

		writer.Write((byte)this.RideType);
		writer.Write((byte)this.RideTypeAlternate);
		writer.Write((byte)this.SoldItem1);
		writer.Write((byte)this.SoldItem2);
	}

	#endregion
}
/** <summary> The header used for attraction car structures. </summary> */
public class CarHeader {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The index of the last frame used in full rotations. </summary> */
	public byte LastRotationFrame;
	/** <summary> These values are always zero in dat files. This has a length of 3 bytes. </summary> */
	public byte[] Reserved0x01;

	/** <summary> This value varies greatly between all rides. Rides that have the same car spacing seem to have the same value for this as well.
	 * Stalls always have a value of 192. </summary> */
	public byte Unknown0x04;

	/** <summary> Gives the spacing between the car and the next. This value is given as feet x 10. </summary> */
	public ushort CarSpacing;
	/** <summary> This value is always zero in dat files. </summary> */
	public byte Reserved0x07;
	/** <summary> The friction of the car, higher values equals less friction. This value must be above zero on non-flat rides. </summary> */
	public ushort CarFriction;
	/** <summary> The height of the car to display in the cars tab and in the train length preview. A higher value brings the car up. </summary> */
	public byte CarTabHeight;
	/** <summary> Specifies the amount of riders per car and if they ride in pairs. </summary> */
	public byte RiderSettings;
	/** <summary> The flags used to specify which car sprites are present in the images. </summary> */
	public CarSpriteFlags SpriteFlags;

	/** <summary> These 3 values effect how many flat and tower rides are drawn. Changing the values causes certain tiles to draw over each other or not cleanup.
	 * Setting all 3 bytes to 0xFF always seems to work for rides that normally have non-zero values. </summary> */
	public byte[] Unknown0x0E;

	/** <summary> The flags for the car type. </summary> */
	public CarFlags Flags;
	/** <summary> These values are always zero in dat files. This has a length of 59 bytes. </summary> */
	public byte[] Reserved0x16;
	/** <summary> The number of rider sprites for this car type. This is equal to the number of riders if riders do not ride in pairs, else it is half the number of riders.
	 * This is also used for certain rider animations, such as with canoes and rowing boats. </summary> */
	public byte RiderSprites;
	/** <summary> A higher value results in a smaller change in angular velocity for the same turn radius. </summary> */
	public byte SpinningInertia;
	/** <summary> A higher value will cause the spin to slow down faster. </summary> */
	public byte SpinningFriction;

	/** <summary> These 4 values have unknown effects. Bytes 0x57 and 0x59 are often the same value. Bytes 0x58 and 0x5A are only non-zero on a few rides,
	 * such as go karts and reverser. Stalls and many other rides have default values of FF 00 FF 00. 
	 * It's possible that this may be two 2-byte structures. </summary> */
	public byte[] Unknown0x57;

	/** <summary> The acceleration of a powered car. This value is relative to powered max speed. </summary> */
	public byte PoweredAcceleration;
	/** <summary> The maximum velocity that a powered car will reach on level track. This value is about equal to MPH x 2 when acceleration is 255.
	 * This value must be greater than 0 on powered cars. </summary> */
	public byte PoweredMaxSpeed;
	/** <summary> Affects how the car is drawn, and is set for specific ride and car types. </summary> */
	public CarVisuals CarVisual;
	/** <summary> Has an unknown effect but is set for specific ride and car types. </summary> */
	public CarUnknownSettings UnknownSetting;
	/** <summary> Higher values cause the track to be drawn first, while low values cause the car to be drawn first. 0-2 is typical for an inverted ride, while 6-8 is typical for an above-track coaster. </summary> */
	public byte DrawOrder;
	/** <summary> The number of "special" frames of each car type between rotations. The car flag SpecialFrames must be set in order to use this.
	 * This seems to be set when the default number of frames is not 4. It's also set for rides that don't have an animation but need more than one frame to draw. </summary> */
	public byte SpecialFrames;
	/** <summary> This value is always zero in dat files. </summary> */
	public uint Reserved0x61;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default attraction car header. </summary> */
	public CarHeader() {
		this.LastRotationFrame = 0;
		this.Reserved0x01 = new byte[3];

		this.Unknown0x04 = 0;

		this.CarSpacing = 0;
		this.Reserved0x07 = 0;
		this.CarFriction = 0;
		this.CarTabHeight = 0;
		this.RiderSettings = 0;
		this.SpriteFlags = CarSpriteFlags.None;

		this.Unknown0x0E = new byte[3];
		for (int i = 0; i < this.Unknown0x0E.Length; i++) this.Unknown0x0E[i] = 0;

		this.Flags = CarFlags.None;

		this.Reserved0x16 = new byte[59];
		for (int i = 0; i < this.Reserved0x16.Length; i++) this.Reserved0x16[i] = 0;

		this.RiderSprites = 0;
		this.SpinningInertia = 0;
		this.SpinningFriction = 0;

		this.Unknown0x57 = new byte[4];
		for (int i = 0; i < this.Unknown0x57.Length; i++) this.Unknown0x57[i] = 0;

		this.PoweredAcceleration = 0;
		this.PoweredMaxSpeed = 0;
		this.CarVisual = CarVisuals.Default;
		this.UnknownSetting = CarUnknownSettings.Default;
		this.DrawOrder = 0;
		this.SpecialFrames = 0;
		this.Reserved0x61 = 0;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the number of swinging frames for the car and rider. </summary> */
	public int SwingingFrames {
		get {
			int count = 1;
			if (Flags.HasFlag(CarFlags.Swinging)) {
				count += 4;
				if (Flags.HasFlag(CarFlags.SwingingMoreFrames))
					count += 2;
				if (Flags.HasFlag(CarFlags.SwingingSlide))
					count += 2;
				if (Flags.HasFlag(CarFlags.SwingingTilting))
					count -= 2;
			}
			return count;
		}
	}
	/** <summary> Gets the number of animation frames for the car. </summary> */
	public int CarAnimationFrames {
		get {
			int count = 1;
			return count;
		}
	}
	/** <summary> Gets the number of animation frames for the rider. </summary> */
	public int RiderAnimationFrames {
		get {
			int count = 1;
			if (Flags.HasFlag(CarFlags.SpecialFrames)) {
				count = SpecialFrames;
			}
			else if (Flags.HasFlag(CarFlags.Animation) && !Flags.HasFlag(CarFlags.RiderSpriteAnimation)) {
				count = 4;
			}
			return count;
		}
	}
	/** <summary> True if there is a single set of rider sprites for every 2 riders. </summary> */
	public bool RidersRideInPairs {
		get { return (RiderSettings & 0x80) != 0; }
	}
	/** <summary> Gets the total number of riders allowed in the car. </summary> */
	public int NumberOfRiders {
		get { return (RiderSettings & 0x7F); }
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the object header. </summary> */
	public void Read(BinaryReader reader) {
		this.LastRotationFrame = reader.ReadByte();

		reader.Read(this.Reserved0x01, 0, this.Reserved0x01.Length);

		this.Unknown0x04 = reader.ReadByte();

		this.CarSpacing = reader.ReadUInt16();
		this.Reserved0x07 = reader.ReadByte();
		this.CarFriction = reader.ReadUInt16();
		this.CarTabHeight = reader.ReadByte();
		this.RiderSettings = reader.ReadByte();
		this.SpriteFlags = (CarSpriteFlags)reader.ReadUInt16();

		reader.Read(this.Unknown0x0E, 0, this.Unknown0x0E.Length);

		this.Flags = (CarFlags)reader.ReadUInt64();

		reader.Read(this.Reserved0x16, 0, this.Reserved0x16.Length);

		this.RiderSprites = reader.ReadByte();
		this.SpinningInertia = reader.ReadByte();
		this.SpinningFriction = reader.ReadByte();

		reader.Read(this.Unknown0x57, 0, this.Unknown0x57.Length);

		this.PoweredAcceleration = reader.ReadByte();
		this.PoweredMaxSpeed = reader.ReadByte();
		this.CarVisual = (CarVisuals)reader.ReadByte();
		this.UnknownSetting = (CarUnknownSettings)reader.ReadByte();
		this.DrawOrder = reader.ReadByte();
		this.SpecialFrames = reader.ReadByte();

		this.Reserved0x61 = reader.ReadUInt32();
	}
	/** <summary> Writes the object header. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.LastRotationFrame);

		writer.Write(this.Reserved0x01);

		writer.Write(this.Unknown0x04);

		writer.Write(this.CarSpacing);
		writer.Write(this.Reserved0x07);
		writer.Write(this.CarFriction);
		writer.Write(this.CarTabHeight);
		writer.Write(this.RiderSettings);
		writer.Write((ushort)this.SpriteFlags);

		writer.Write(this.Unknown0x0E);

		writer.Write((ulong)this.Flags);

		writer.Write(this.Reserved0x16);

		writer.Write(this.RiderSprites);
		writer.Write(this.SpinningInertia);
		writer.Write(this.SpinningFriction);

		writer.Write(this.Unknown0x57);

		writer.Write(this.PoweredAcceleration);
		writer.Write(this.PoweredMaxSpeed);
		writer.Write((byte)this.CarVisual);
		writer.Write((byte)this.UnknownSetting);
		writer.Write(this.DrawOrder);
		writer.Write(this.SpecialFrames);

		writer.Write(this.Reserved0x61);
	}

	#endregion
}
}
