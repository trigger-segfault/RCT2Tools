using RCT2ObjectData.DataObjects.Types;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {
/** <summary> A class storing information about a saved track design. </summary> */
public class TrackDesign {

	//========== CONSTANTS ===========
	#region Constants


	#endregion
	//=========== MEMBERS ============
	#region Members

	public TrackTypes TrackType;
	public byte Unknown0x01;
	public uint SpecialTrackFlags;
	public OperatingModes OperatingMode;

	public byte VehicleColorScheme;
	public RemapColors[] VehicleColorSpecifiers;

	public byte Unknown0x48;
	public EntranceTypes EntranceType;

	public byte AirTime;
	public DepartureControlFlags DepartureControlFlags;
	public byte NumberOfTrains;
	public byte CarsPerTrain;
	public byte MinimumWaitTime;
	public byte MaximumWaitTime;
	public byte PoweredSpeedLapsMaxPeople;
	public byte MaximumSpeed;
	public byte AverageSpeed;
	public ushort RideLength;
	public byte PositiveGForce;
	public byte NegativeGForce;
	public byte LateralGForce;
	public byte NumberOfInversions;
	public byte NumberOfDrops;
	public byte HighestDrop;
	public byte Excitement;
	public byte Intensity;
	public byte Nausea;

	public byte Unknown0x5E;
	public byte Unknown0x5F;

	public RemapColors[] TrackSpineColors;
	public RemapColors[] TrackRailColors;
	public RemapColors[] TrackSupportColors;

	public byte Unknown0x6C;
	public byte Unknown0x6D;
	public byte Unknown0x6E;
	public byte SixFlagsRide;

	public ObjectDataHeader ObjectHeader;

	public byte RideMapWidth;
	public byte RideMapHeight;

	public RemapColors[] VehicleAdditionalColors;

	public byte CircuitsChainLiftSpeed;

	public List<MazeTile> MazeTiles;
	public List<TrackPiece> TrackPieces;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default track design. </summary> */
	public TrackDesign() {
		this.TrackType = TrackTypes.None;
		this.Unknown0x01 = 0;
		this.SpecialTrackFlags = 0;
		this.OperatingMode = OperatingModes.NormalMode;
		this.VehicleColorScheme = 0;
		this.VehicleColorSpecifiers = new RemapColors[64];

		this.Unknown0x48 = 0;

		this.EntranceType = EntranceTypes.Normal;
		this.AirTime = 0;
		this.DepartureControlFlags = DepartureControlFlags.UseMaximumTime | DepartureControlFlags.FullLoad;
		this.NumberOfTrains = 0;
		this.CarsPerTrain = 0;
		this.MinimumWaitTime = 10;
		this.MaximumWaitTime = 60;
		this.PoweredSpeedLapsMaxPeople = 0;
		this.MaximumSpeed = 0;
		this.AverageSpeed = 0;
		this.RideLength = 0;
		this.PositiveGForce = 0;
		this.NegativeGForce = 0;
		this.LateralGForce = 0;
		this.NumberOfInversions = 0;
		this.NumberOfDrops = 0;
		this.HighestDrop = 0;
		this.Excitement = 0;
		this.Intensity = 0;
		this.Nausea = 0;

		this.Unknown0x5E = 0;
		this.Unknown0x5F = 0;

		this.TrackSpineColors = new RemapColors[4];
		this.TrackRailColors = new RemapColors[4];
		this.TrackSupportColors = new RemapColors[4];

		this.Unknown0x6C = 0;
		this.Unknown0x6D = 0;
		this.Unknown0x6E = 0;

		this.SixFlagsRide = 0;

		this.ObjectHeader = new ObjectDataHeader();

		this.RideMapWidth = 0;
		this.RideMapHeight = 0;

		this.VehicleAdditionalColors = new RemapColors[32];
		this.CircuitsChainLiftSpeed = 0;

		this.MazeTiles = new List<MazeTile>();
		this.TrackPieces = new List<TrackPiece>();
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets or sets the chain lift hill speed. </summary> */
	public int ChainLiftSpeed {
		get { return (CircuitsChainLiftSpeed & 0x1F); }
		set {
			CircuitsChainLiftSpeed &= 0xE0;
			CircuitsChainLiftSpeed |= (byte)(value & 0x1F);
		}
	}
	/** <summary> Gets or sets the number of circuits. </summary> */
	public int NumberOfCircuits {
		get { return ((CircuitsChainLiftSpeed & 0xE0) >> 5); }
		set {
			CircuitsChainLiftSpeed &= 0x1F;
			CircuitsChainLiftSpeed |= (byte)((value & 0x07) << 5);
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the track design. </summary> */
	public void Read(BinaryReader reader) {
		this.TrackType = (TrackTypes)reader.ReadByte();
		this.Unknown0x01 = reader.ReadByte();
		this.SpecialTrackFlags = reader.ReadUInt32();
		this.OperatingMode = (OperatingModes)reader.ReadByte();
		this.VehicleColorScheme = reader.ReadByte();
		for (int i = 0; i < this.VehicleColorSpecifiers.Length; i++)
			this.VehicleColorSpecifiers[i] = (RemapColors)reader.ReadByte();

		this.Unknown0x48 = reader.ReadByte();
		this.EntranceType = (EntranceTypes)reader.ReadByte();
		this.AirTime = reader.ReadByte();
		this.DepartureControlFlags = (DepartureControlFlags)reader.ReadByte();
		this.NumberOfTrains = reader.ReadByte();
		this.CarsPerTrain = reader.ReadByte();
		this.MinimumWaitTime = reader.ReadByte();
		this.MaximumWaitTime = reader.ReadByte();
		this.PoweredSpeedLapsMaxPeople = reader.ReadByte();
		this.MaximumSpeed = reader.ReadByte();
		this.AverageSpeed = reader.ReadByte();
		this.RideLength = reader.ReadUInt16();
		this.PositiveGForce = reader.ReadByte();
		this.NegativeGForce = reader.ReadByte();
		this.LateralGForce = reader.ReadByte();
		this.NumberOfInversions = reader.ReadByte();
		this.NumberOfDrops = reader.ReadByte();
		this.HighestDrop = reader.ReadByte();
		this.Excitement = reader.ReadByte();
		this.Intensity = reader.ReadByte();
		this.Nausea = reader.ReadByte();

		this.Unknown0x5E = reader.ReadByte();
		this.Unknown0x5F = reader.ReadByte();

		for (int i = 0; i < this.TrackSpineColors.Length; i++)
			this.TrackSpineColors[i] = (RemapColors)reader.ReadByte();
		for (int i = 0; i < this.TrackRailColors.Length; i++)
			this.TrackRailColors[i] = (RemapColors)reader.ReadByte();
		for (int i = 0; i < this.TrackSupportColors.Length; i++)
			this.TrackSupportColors[i] = (RemapColors)reader.ReadByte();

		this.Unknown0x6C = reader.ReadByte();
		this.Unknown0x6D = reader.ReadByte();
		this.Unknown0x6E = reader.ReadByte();

		this.SixFlagsRide = reader.ReadByte();

		this.ObjectHeader.Read(reader);

		this.RideMapWidth = reader.ReadByte();
		this.RideMapHeight = reader.ReadByte();

		for (int i = 0; i < this.VehicleAdditionalColors.Length; i++)
			this.VehicleAdditionalColors[i] = (RemapColors)reader.ReadByte();

		this.CircuitsChainLiftSpeed = reader.ReadByte();

		// Read the track data

		if (this.TrackType == TrackTypes.HedgeMaze) {
			MazeTile mazeTile = new MazeTile();
			mazeTile.Read(reader);
			// Read the maze tiles until an empty one is read.
			while (!mazeTile.IsEnd) {
				this.MazeTiles.Add(mazeTile);
				mazeTile = new MazeTile();
				mazeTile.Read(reader);
			}
		}
		else {
			byte b = reader.ReadByte();
			// Read the track pieces until byte 0xFF.
			while (b != 0xFF) {
				reader.BaseStream.Position--;
				TrackPiece trackPiece = new TrackPiece();
				trackPiece.Read(reader);
				this.TrackPieces.Add(trackPiece);

				b = reader.ReadByte();
			}
		}

		while (reader.BaseStream.Position < reader.BaseStream.Length) {
			reader.ReadByte();
		}
	}
	/** <summary> Writes the track design. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write((byte)this.TrackType);
		writer.Write(this.Unknown0x01);
		writer.Write(this.SpecialTrackFlags);
		writer.Write((byte)this.OperatingMode);
		writer.Write(this.VehicleColorScheme);
		for (int i = 0; i < this.VehicleColorSpecifiers.Length; i++)
			writer.Write((byte)this.VehicleColorSpecifiers[i]);

		writer.Write(this.Unknown0x48);
		writer.Write((byte)this.EntranceType);
		writer.Write(this.AirTime);
		writer.Write((byte)this.DepartureControlFlags);
		writer.Write(this.NumberOfTrains);
		writer.Write(this.CarsPerTrain);
		writer.Write(this.MinimumWaitTime);
		writer.Write(this.MaximumWaitTime);
		writer.Write(this.PoweredSpeedLapsMaxPeople);
		writer.Write(this.MaximumSpeed);
		writer.Write(this.AverageSpeed);
		writer.Write(this.RideLength);
		writer.Write(this.PositiveGForce);
		writer.Write(this.NegativeGForce);
		writer.Write(this.LateralGForce);
		writer.Write(this.NumberOfInversions);
		writer.Write(this.NumberOfDrops);
		writer.Write(this.HighestDrop);
		writer.Write(this.Excitement);
		writer.Write(this.Intensity);
		writer.Write(this.Nausea);

		writer.Write(this.Unknown0x5E);
		writer.Write(this.Unknown0x5F);

		for (int i = 0; i < this.TrackSpineColors.Length; i++)
			writer.Write((byte)this.TrackSpineColors[i]);
		for (int i = 0; i < this.TrackRailColors.Length; i++)
			writer.Write((byte)this.TrackRailColors[i]);
		for (int i = 0; i < this.TrackSupportColors.Length; i++)
			writer.Write((byte)this.TrackSupportColors[i]);

		writer.Write(this.Unknown0x6C);
		writer.Write(this.Unknown0x6D);
		writer.Write(this.Unknown0x6E);

		writer.Write(this.SixFlagsRide);

		this.ObjectHeader.Write(writer);

		writer.Write(this.RideMapWidth);
		writer.Write(this.RideMapHeight);

		for (int i = 0; i < this.VehicleAdditionalColors.Length; i++)
			writer.Write((byte)this.VehicleAdditionalColors[i]);

		writer.Write(this.CircuitsChainLiftSpeed);


		if (this.TrackType == TrackTypes.HedgeMaze) {
			for (int i = 0; i < this.MazeTiles.Count; i++) {
				this.MazeTiles[i].Write(writer);
			}
			//new MazeTile(0, 0, MazeWalls.None).Write(writer);
			// Write the entrances
			writer.Write((uint)0);
		}
		else {
			// Write track pieces
			for (int i = 0; i < this.TrackPieces.Count; i++) {
				this.TrackPieces[i].Write(writer);
			}
			writer.Write((byte)0xFF);

			// Write entrance/exits
		}

		// No scenery
		writer.Write((byte)0xFF);

		if (writer.BaseStream.Position < 19235) {
			while (writer.BaseStream.Position < 19235) {
				writer.Write((byte)0x00);
			}
		}
		else if (writer.BaseStream.Position < 24735) {
			while (writer.BaseStream.Position < 24735) {
				writer.Write((byte)0x00);
			}
		}
	}
	/** <summary> Returns an object loaded from the specified stream. </summary> */
	public static TrackDesign FromStream(Stream stream) {
		BinaryReader reader = new BinaryReader(stream, Encoding.Unicode);
		byte[] data = ReadChunk(reader);

		uint CheckSum = reader.ReadUInt32();
		Console.WriteLine(CheckSum);

		reader.Close();
		reader = new BinaryReader(new MemoryStream(data));
		TrackDesign trackDesign = new TrackDesign();
		trackDesign.Read(reader);
		reader.Close();

		return trackDesign;
	}
	/** <summary> Returns an object loaded from the specified buffer. </summary> */
	public static TrackDesign FromBuffer(byte[] buffer) {
		return FromStream(new MemoryStream(buffer));
	}
	/** <summary> Returns an object loaded from the specified file path. </summary> */
	public static TrackDesign FromFile(string path) {
		return FromStream(new FileStream(path, FileMode.Open, FileAccess.Read));
	}
	/** <summary> Saves the track design to the specified file path. </summary> */
	public void Save(string path) {
		try {
			MemoryStream stream = new MemoryStream();
			BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode);

			this.Write(writer);

			// Get the chunk size
			uint chunkSize = (uint)writer.BaseStream.Position;
			byte[] chunkData = new byte[chunkSize];
			Array.Copy(stream.GetBuffer(), chunkData, chunkSize);
			byte[] encodedChunkData = WriteChunk(chunkData);


			writer.Close();
			BinaryReader reader = new BinaryReader(new MemoryStream(encodedChunkData));
			reader.BaseStream.Position = 0;

			// Calculate the checksum
			uint checkSum = 0;
			for (int i = 0; i < (int)encodedChunkData.Length; i++)
				checkSum = RotateChecksum(checkSum, reader.ReadByte());
			checkSum -= 120001;
			Console.WriteLine(checkSum);

			reader.Close();

			writer = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

			//writer.Write(chunkData);
			writer.Write(encodedChunkData);
			writer.Write(checkSum);

			writer.Close();
		}
		catch (System.Exception) {
			Console.WriteLine("HELP");
		}
	}
	/** <summary> Reads and decodes the track design chunk. </summary> */
	public static byte[] ReadChunk(BinaryReader reader) {
		uint chunkPosition = 0;
		uint position = 0;
		long startPos = reader.BaseStream.Position;

		MemoryStream stream = new MemoryStream();
		BinaryWriter writer = new BinaryWriter(stream);

		//http://tid.rctspace.com/RLE.html

		// While the end of the uncompressed chunk has not been reached
		while ((long)chunkPosition + 4 < reader.BaseStream.Length) {
			// Read the next byte
			byte b = reader.ReadByte();

			// If the MSB is 0, copy the next (b + 1) bytes
			if ((b & 0x80) == 0) {
				uint length = (uint)(b + 1);
				chunkPosition += length + 1;
				position += length;
				//Console.WriteLine("Copy: " + b + " " + length + " Position: " + chunkPosition);
				writer.Write(reader.ReadBytes((int)length));
			}

			// Else the MSB is 1, repeat the following byte (-b + 1) times
			else {
				byte copyByte = reader.ReadByte();
				uint length = (uint)((byte)(-(sbyte)b) + 1);
				chunkPosition += 2;
				position += length;
				//Console.WriteLine("Repeat: " + b + " " + length + " " + copyByte + " Position: " + chunkPosition);
				for (var i = 0; i < length; i++)
					writer.Write(copyByte);
			}
		}

		byte[] data = new byte[position];
		Array.Copy(stream.GetBuffer(), data, position);
		return data;
	}
	/** <summary> Reads and decodes the chunk. </summary> */
	public static byte[] WriteChunk(byte[] data) {
		uint position = 0;
		uint chunkPosition = 0;

		MemoryStream stream = new MemoryStream();
		BinaryWriter writer = new BinaryWriter(stream);

		while (position < data.Length) {

			uint startLength = position;
			if (position + 1 == data.Length) {
				writer.Write((byte)0x00);
				writer.Write(data[position]);
				position++;
				chunkPosition += 2;
			}
			else {
				bool duplicate = false;
				byte startByte = data[position];
				byte b = data[position + 1];
				if (b == startByte)
					duplicate = true;
				int count = 2;
				for (; count < 125 && count + position < data.Length; count++) {
					if ((b == data[position + count]) != duplicate) {
						if (!duplicate)
							count--;
						break;
					}
					else {
						b = data[position + count];
					}
				}

				if (!duplicate) {
					writer.Write((byte)(count - 1));
					for (int i = 0; i < count; i++) {
						writer.Write(data[position + i]);
					}
					chunkPosition += (uint)(count + 1);
				}
				else {
					writer.Write((byte)(-(sbyte)((byte)count - 1)));
					writer.Write(startByte);
					chunkPosition += 2;
				}

				position += (uint)count;
			}
		}

		byte[] data2 = new byte[chunkPosition];
		Array.Copy(stream.GetBuffer(), data2, chunkPosition);
		return data2;
	}
	/** <summary> Rotates the checksum. </summary> */
	private static uint RotateChecksum(uint checksum, byte data) {
		checksum = (checksum & 0xFFFFFF00) | ((checksum + (uint)data) & 0x000000FF);
		checksum = (checksum << 3) | (checksum >> (32 - 3));
		return checksum;
	}


	#endregion
}
/** <summary> A single track piece in a track design. </summary> */
public class TrackPiece {
	
	//=========== MEMBERS ============
	#region Members

	/** <summary> The type of track piece. </summary> */
	public TrackSegments Segment;
	/** <summary> The qualifier for the track piece. </summary> */
	public TrackQualifiers Qualifier;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default track piece. </summary> */
	public TrackPiece() {
		this.Segment = TrackSegments.Flat;
		this.Qualifier = TrackQualifiers.None;
	}
	/** <summary> Constructs the default track piece. </summary> */
	public TrackPiece(TrackSegments segment, TrackQualifiers qualifier) {
		this.Segment = segment;
		this.Qualifier = qualifier;
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the track piece. </summary> */
	public void Read(BinaryReader reader) {
		this.Segment = (TrackSegments)reader.ReadSByte();
		this.Qualifier = (TrackQualifiers)reader.ReadSByte();
	}
	/** <summary> Writes the track piece. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write((byte)this.Segment);
		writer.Write((byte)this.Qualifier);
	}

	#endregion
}
/** <summary> A single tile in a maze. </summary> */
public class MazeTile {
	
	//=========== MEMBERS ============
	#region Members

	/** <summary> The x position of the maze tile. </summary> */
	public sbyte X;
	/** <summary> The y position of the maze tile. </summary> */
	public sbyte Y;
	/** <summary> The walls which are set on the maze tile. </summary> */
	public MazeWalls Walls;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default maze tile. </summary> */
	public MazeTile() {
		this.X = 0;
		this.Y = 0;
		this.Walls = MazeWalls.All;
	}
	/** <summary> Constructs the default maze tile. </summary> */
	public MazeTile(int x, int y, MazeWalls walls) {
		this.X = (sbyte)x;
		this.Y = (sbyte)y;
		this.Walls = walls;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> True if the entrance is on this tile. </summary> */
	public bool IsEntrance {
		get {
			return (Walls == MazeWalls.EntranceWest ||
					Walls == MazeWalls.EntranceNorth ||
					Walls == MazeWalls.EntranceEast ||
					Walls == MazeWalls.EntranceSouth);
		}
	}
	/** <summary> True if the exit is on this tile. </summary> */
	public bool IsExit {
		get {
			return (Walls == MazeWalls.ExitWest ||
					Walls == MazeWalls.ExitNorth ||
					Walls == MazeWalls.ExitEast ||
					Walls == MazeWalls.ExitSouth);
		}
	}
	/** <summary> True if the exit is on this tile. </summary> */
	public bool IsBuilding {
		get {
			return (IsEntrance || IsExit);
		}
	}
	/** <summary> Gets the direction the building on this tile is facing. </summary> */
	public MazeBuildingDirections BuildingDirection {
		get {
			if (!IsEntrance && !IsExit)
				return MazeBuildingDirections.None;
			return (MazeBuildingDirections)((uint)Walls & 0x000F);
		}
	}
	/** <summary> True if this is the end maze tile. </summary> */
	public bool IsEnd {
		get { return X == 0 && Y == 0 && Walls == MazeWalls.None; }
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Reads the maze tile. </summary> */
	public void Read(BinaryReader reader) {
		this.X = reader.ReadSByte();
		this.Y = reader.ReadSByte();
		this.Walls = (MazeWalls)reader.ReadUInt16();
	}
	/** <summary> Writes the maze tile. </summary> */
	public void Write(BinaryWriter writer) {
		writer.Write(this.X);
		writer.Write(this.Y);
		writer.Write((ushort)this.Walls);
	}

	#endregion

}
/** <summary> The flags for maze walls, a set flag means a wall exists there. </summary> */
[Flags]
public enum MazeWalls : ushort {
	None = 0x0000,
	All = 0xFFFF,

	EntranceSouth = 0x0803,
	EntranceWest = 0x0802,
	EntranceNorth = 0x0801,
	EntranceEast = 0x0800,

	ExitSouth = 0x8003,
	ExitWest = 0x8002,
	ExitNorth = 0x08001,
	ExitEast = 0x8000,

	Quadrant4All = 0x400F,
	Quadrant3All = 0x00F4,
	Quadrant2All = 0x0F40,
	Quadrant1All = 0xF400,

	NorthLeft = 0x0001,
	WestTop = 0x0002,
	WestMiddle = 0x0004,
	Quadrant4 = 0x0008,

	WestBottom = 0x0010,
	SouthLeft = 0x0020,
	SouthMiddle = 0x0040,
	Quadrant3 = 0x0080,

	SouthRight = 0x0100,
	EastBottom = 0x0200, 
	EastMiddle = 0x0400,
	Quadrant2 = 0x0800,

	EastTop = 0x1000,
	NorthRight = 0x2000,
	NorthMiddle = 0x4000,
	Quadrant1 = 0x8000,
	
	BuildingSouth = 0x0003,
	BuildingWest = 0x0002,
	BuildingNorth = 0x00001,
	BuildingEast = 0x0000,

	Entrance = 0x0800,
	Exit = 0x8000,
	Building = 0x8800
}
/** <summary> The directions an entrance/exit can face. </summary> */
public enum MazeBuildingDirections {
	None = -1,
	East = 0,
	North = 1,
	West = 2,
	South = 3
}
}
