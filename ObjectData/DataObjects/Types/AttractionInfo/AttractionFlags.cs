using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> All flags usable with attraction objects. </summary> */
[Flags]
public enum AttractionFlags : uint {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,

	/** <summary> Disallow first remap color on the track. Used mainly for trams and trains. </summary> */
	NoTrackRemap = 0x00000008,
	/** <summary> Set on magic carpet and swinging inverted ship. </summary> */
	MagicCarpetInvertedShip = 0x00000010,
	/** <summary> Set on twist and snow cups. </summary> */
	TwistSnowCups = 0x00000020,
	/** <summary> Set on enterprise. </summary> */
	Enterprise = 0x00000040,
	/** <summary> Riders will get wet if riding this ride. </summary> */
	RidersGetWet = 0x00000100,
	/** <summary> Only set on coaster boats. If unset, they do not slow down in water. </summary> */
	SlowInWater = 0x00000200,
	/** <summary> Ride is covered, guests won't care if it's raining. </summary> */
	Covered = 0x00000400,
	/** <summary> If set, this ride shows as a seperate ride instead of an alternate train type. If the track
	 * style doesn't support alternate train types, then this flag must be set or the ride won't show at all. </summary> */
	SeparateRide = 0x00001000,
	/** <summary> Set if SeparateRide is set. Not sure why. </summary> */
	SeparateRide2 = 0x00002000,
	/** <summary> Set on rowing boats, canoes and elevator. </summary> */
	RowingBoatsCanoesElevator = 0x00004000,
	/** <summary> Disables any shuttle type of mode on rides. </summary> */
	DisableShuttleMode = 0x00008000,
	/** <summary> Set on spinning wild mouse. </summary> */
	SpinningWildMouse = 0x00010000,
	/** <summary> Set on inverted shuttle and inverted vertical shuttle. </summary> */
	InvertedAndVerticalShuttle = 0x00020000,
	/** <summary> Set only on sunglasses stall. </summary> */
	SunglassesStall = 0x00080000,
	/** <summary> Set only on magic carpet. </summary> */
	MagicCarpet = 0x00100000,

	Unknown1_0 = 0x00000001,
	Unknown2_0 = 0x00000002,
	Unknown8_2 = 0x00000800,
	Unknown4_4 = 0x00040000,

	Unused4_0 = 0x00000004,
	Unused8_1 = 0x00000080,

	Unused2_5 = 0x00200000,
	Unused4_5 = 0x00400000,
	Unused8_5 = 0x00800000,

	Unused1_6 = 0x01000000,
	Unused2_6 = 0x02000000,
	Unused4_6 = 0x04000000,
	Unused8_6 = 0x08000000,

	Unused1_7 = 0x10000000,
	Unused2_7 = 0x20000000,
	Unused4_7 = 0x40000000,
	Unused8_7 = 0x80000000
}
/** <summary> The different types of rides. </summary> */
public enum RideTypes : byte {
	/** <summary> No ride type is set. </summary> */
	None = 0xFF,
	/** <summary> The attraction is a transport ride. </summary> */
	Transport = 0x00,
	/** <summary> The attraction is a gentle ride. </summary> */
	Gentle = 0x01,
	/** <summary> The attraction is a rollercoaster. </summary> */
	Rollercoaster = 0x02,
	/** <summary> The attraction is a thrill ride. </summary> */
	Thrill = 0x03,
	/** <summary> The attraction is a water ride. </summary> */
	Water = 0x04,
	/** <summary> The attraction is a stall. </summary> */
	Stall = 0x05,
}
/** <summary> The different types of stalls. </summary> */
public enum StallTypes : byte {
	/** <summary> No stall type is set. </summary> */
	None = 0xFF,
	/** <summary> The stall is a food stall. </summary> */
	Food = 0x1C,
	/** <summary> The stall is a drinks stall. </summary> */
	Drinks = 0x1E,
	/** <summary> The stall is a souvenir stall. </summary> */
	Souvenir = 0x20,
	/** <summary> The stall is an information kiosk. </summary> */
	InfoKiosk = 0x23,
	/** <summary> The stall is a restroom. </summary> */
	Restroom = 0x24,
	/** <summary> The stall is a cash machine. </summary> */
	CashMachine = 0x2D,
	/** <summary> The stall is a first aid room. </summary> */
	FirstAid = 0x30,
}
/** <summary> The different types of tracks. </summary> */
public enum TrackTypes : byte {
	/** <summary> No track type is set. </summary> */
	None = 0xFF,
	/** <summary> The track type is for sprial rollercoasters. </summary> */
	SpiralRollerCoaster = 0x00,
	/** <summary> The track type is for stand-up rollercoasters. </summary> */
	StandUpRollerCoaster = 0x01,
	/** <summary> The track type is for suspended swinging rollercoasters. </summary> */
	SuspendedSwingingCoaster = 0x02,
	/** <summary> The track type is for inverted rollercoasters. </summary> */
	InvertedRollerCoaster = 0x03,
	/** <summary> The track type is for junior rollercoasters. </summary> */
	JuniorRollerCoaster = 0x04,
	/** <summary> The track type is for railroads. </summary> */
	Railroad = 0x05,
	/** <summary> The track type is for monorails. </summary> */
	Monorail = 0x06,
	/** <summary> The track type is for mini suspended rollercoasters. </summary> */
	MiniSuspendedCoaster = 0x7,
	/** <summary> The track type is for boar hires. </summary> */
	BoatHire = 0x08,
	/** <summary> The track type is for wooden wild rollercoasters. </summary> */
	WoodenWildRide = 0x09,
	/** <summary> The track type is for single rail rollercoasters. </summary> */
	SingleRailCoaster = 0x0A,
	/** <summary> The track type is for car rides. </summary> */
	CarRide = 0x0B,
	/** <summary> The track type is for launched freefalls. </summary> */
	LaunchedFreefall = 0x0C,
	/** <summary> The track type is for bobsled rollercoasters. </summary> */
	BobsledCoaster = 0x0D,
	/** <summary> The track type is for observation tower. </summary> */
	ObservationTower = 0x0E,
	/** <summary> The track type is for looping rollercoasters. </summary> */
	LoopingRollerCoaster = 0x0F,
	/** <summary> The track type is for water slides. </summary> */
	WaterSlide = 0x10,
	/** <summary> The track type is for mine train rollercoasters. </summary> */
	MineTrainCoaster = 0x11,
	/** <summary> The track type is for chair lifts. </summary> */
	ChairLift = 0x12,
	/** <summary> The track type is for corkscrew rollercoasters. </summary> */
	CorkscrewRollerCoaster = 0x13,
	/** <summary> The track type is for hedge mazes. </summary> */
	HedgeMaze = 0x14,
	/** <summary> The track type is for spiral slides. </summary> */
	SpiralSlide  = 0x15,
	/** <summary> The track type is for go karts. </summary> */
	GoKarts = 0x16,
	/** <summary> The track type is for log flumes. </summary> */
	LogFlume = 0x17,
	/** <summary> The track type is for river rapids. </summary> */
	RiverRapids = 0x18,
	/** <summary> The track type is for bumper cars. </summary> */
	BumperCars = 0x19,
	/** <summary> The track type is for swinging ships. </summary> */
	SwingingShip = 0x1A,
	/** <summary> The track type is for swinging inverted ships. </summary> */
	SwingingInvertedShip = 0x1B,
	/** <summary> The track type is a food stall. </summary> */
	FoodStall = 0x1C,

	Unknown0x1D = 0x1D,

	/** <summary> The track type is a drinks stall. </summary> */
	DrinksStall = 0x1E,
	Unknown0x1F = 0x1F,
	/** <summary> The track type is a souvenir stall. </summary> */
	SouvenirStall = 0x20,
	/** <summary> The track type is for merry-go-rounds. </summary> */
	MerryGoRound  = 0x21,
	Unknown0x22 = 0x22,
	/** <summary> The track type is an information kiosk. </summary> */
	InfoKiosk = 0x23,
	/** <summary> The track type is a restroom. </summary> */
	Restroom = 0x24,
	/** <summary> The track type is for ferris wheels. </summary> */
	FerrisWheel  = 0x25,
	/** <summary> The track type is for motion simulator. </summary> */
	MotionSimulator  = 0x26,
	/** <summary> The track type is for 3D cinemas. </summary> */
	Cinema3D  = 0x27,
	/** <summary> The track type is for top spins. </summary> */
	TopSpin  = 0x28,
	/** <summary> The track type is for space rings. </summary> */
	SpaceRings  = 0x29,
	/** <summary> The track type is for reverse freefall rollercoasters. </summary> */
	ReverseFreefallCoaster  = 0x2A,
	/** <summary> The track type is for elevators. </summary> */
	Elevator  = 0x2B,
	/** <summary> The track type is for vertical drop rollercoasters. </summary> */
	VerticalDropRollerCoaster  = 0x2C,
	/** <summary> The track type is a cash machine. </summary> */
	CashMachine = 0x2D,
	/** <summary> The track type is for twists. </summary> */
	Twist = 0x2E,
	/** <summary> The track type is for rhaunted houses. </summary> */
	HauntedHouse = 0x2F,
	/** <summary> The track type is a first aid room. </summary> */
	FirstAid = 0x30,
	/** <summary> The track type is for circuses. </summary> */
	Circus = 0x31,
	/** <summary> The track type is for haunted rides. </summary> */
	HauntedRide = 0x32,
	/** <summary> The track type is for twister rollercoasters. </summary> */
	TwisterRollerCoaster = 0x33,
	/** <summary> The track type is for wooden rollercoasters. </summary> */
	WoodenRollerCoaster = 0x34,
	/** <summary> The track type is for side friction rollercoasters. </summary> */
	SideFrictionRollerCoaster = 0x35,
	/** <summary> The track type is for wild mouse rollercoasters. </summary> */
	WildMouse = 0x36,
	/** <summary> The track type is for multi-dimension rollercoasters. </summary> */
	MultiDimensionRollerCoaster = 0x37,
	Unknown0x38 = 0x38,
	/** <summary> The track type is for flying rollercoasters. </summary> */
	FlyingRollerCoaster = 0x39,
	Unknown0x3A = 0x3A,
	/** <summary> The track type is for virginia reels. </summary> */
	VirginiaReel = 0x3B,
	/** <summary> The track type is for splash boats. </summary> */
	SplashBoats = 0x3C,
	/** <summary> The track type is for mini helicopters. </summary> */
	MiniHelicopters = 0x3D,
	/** <summary> The track type is for laydown rollercoasters. </summary> */
	LaydownRollerCoaster = 0x3E,
	/** <summary> The track type is for suspended monorails. </summary> */
	SuspendedMonorail = 0x3F,
	Unknown0x40 = 0x40,
	/** <summary> The track type is for reverser rollercoasters. </summary> */
	ReverserRollerCoaster = 0x41,
	/** <summary> The track type is for heartline twister rollercoasters. </summary> */
	HeartlineTwisterCoaster = 0x42,
	/** <summary> The track type is for mini golf. </summary> */
	MiniGolf = 0x43,
	/** <summary> The track type is for giga rollercoasters. </summary> */
	GigaCoaster = 0x44,
	/** <summary> The track type is for roto drops. </summary> */
	RotoDrop = 0x45,
	/** <summary> The track type is for flying saucers. </summary> */
	FlyingSaucers = 0x46,
	/** <summary> The track type is for crooked houses. </summary> */
	CrookedHouse = 0x47,
	/** <summary> The track type is for monorail cycles. </summary> */
	MonorailCycles = 0x48,
	/** <summary> The track type is for inverted shuttle rollercoasters. </summary> */
	InvertedShuttleCoaster = 0x49,
	/** <summary> The track type is for water rollercoasters. </summary> */
	WaterCoaster = 0x4A,
	/** <summary> The track type is for air powered vertical rollercoasters. </summary> */
	AirPoweredVerticalCoaster = 0x4B,
	/** <summary> The track type is for inverted hairpin rollercoasters. </summary> */
	InvertedHairpinCoaster = 0x4C,
	/** <summary> The track type is for magic carpets. </summary> */
	MagicCarpet = 0x4D,
	/** <summary> The track type is for submarine rides. </summary> */
	SubmarineRide = 0x4E,
	/** <summary> The track type is for river rafts. </summary> */
	RiverRafts = 0x4F,
	Unknown0x50 = 0x50,
	/** <summary> The track type is for enterprises. </summary> */
	Enterprise = 0x51,
	Unknown0x52 = 0x52,
	Unknown0x53 = 0x53,
	Unknown0x54 = 0x54,
	Unknown0x55 = 0x55,
	/** <summary> The track type is for inverted himpulse rollercoasters. </summary> */
	InvertedImpulseCoaster = 0x56,
	/** <summary> The track type is for mini rollercoasters. </summary> */
	MiniRollerCoaster = 0x57,
	/** <summary> The track type is for mine ride rollercoasters. </summary> */
	MineRide = 0x58,
	Unknown0x59 = 0x59,
	/** <summary> The track type is for LIM launched rollercoasters. </summary> */
	LIMLaunchedRollerCoaster = 0x5A
}
}
