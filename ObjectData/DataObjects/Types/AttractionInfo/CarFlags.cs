using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> All flags usable with attraction cars. </summary> */
[Flags]
public enum CarFlags : ulong {
	/** <summary> No flags are set. </summary> */
	None = 0x0000000000,

	/** <summary> Car is animated. </summary> */
	Animation = 0x0000000001,
	/** <summary> Car has no upstops -i.e negative g force will cause it to leave the track. This is set for the side friction coaster, bobsled coaster, dingy slide, and most car style rides. </summary> */
	NoUpstops = 0x0000000400,
	/** <summary> Only set on panel car for the reverser. </summary> */
	ReverserPanel = 0x0000001000,
	/** <summary> Only set on the forward and backwards cars of the reverser. </summary> */
	ReverserCar = 0x0000002000,
	/** <summary> Set if and only if Invertable is set. This seems to facilitate sprite cleanup.
	 * Leaving this unset will not prevent coasters from using inverted track. </summary> */
	InvertableSpriteCleanup = 0x0000004000,
	/** <summary> Only set on dodgems rides. This is not set for flying saucers. The game will crash if this is not set. </summary> */
	Dodgems = 0x0000008000,
	/** <summary> Used on the reverser coaster and all flat rides with no cars. This prevents fragmens of sprites from being left visible on the ride. </summary> */
	CleanupSprites = 0x0000040000,
	/** <summary> Set on Water Tricycles, Rowing Boats, Canoes and Swans (i.e. self powered rides). Not sure what it does. This may affect rider's energy levels. </summary> */
	SelfPowered = 0x0000080000,
	/** <summary> This is only set for rides that have "special frames". This is set with Animation when there are more or less than 4 animation frames. </summary> */
	SpecialFrames = 0x0000100000,
	/** <summary> Car may run inverted for extended periods. Such coasters must provide an inverted version of each car type.
	 * This is set on flying, lay down, and 4th dimension coasters. Leaving this unset will not prevent coasters from using inverted track. </summary> */
	Invertable = 0x0000200000,
	/** <summary> This specifies that for each rotation frame, each spinning car has R rotation frames of the car spinning while the wheels stay in place. </summary> */
	SpinningIndependantWheels = 0x0000400000,
	/** <summary> Disables remap color 3. </summary> */
	NoRemap3 = 0x0000800000,
	/** <summary> Enables remap color 2. </summary> */
	Remap2 = 0x0001000000,
	/** <summary> This car is swinging. The default number of swinging frames is 2 pairs (5 total frames). </summary> */
	Swinging = 0x0002000000,
	/** <summary> This car is spinning. </summary> */
	Spinning = 0x0004000000,
	/** <summary> This car is powered. </summary> */
	Powered = 0x0008000000,
	/** <summary> Adds an extra pair of swinging frames. Another unknown effect may be present. </summary> */
	SwingingMoreFrames = 0x0020000000,
	/** <summary> Ride may not start unless car has all passengers. </summary> */
	FullLoad = 0x0040000000,
	/** <summary> Used for boat hires on the only car type. This allows rider sprites to be used as animations. </summary> */
	RiderSpriteAnimation = 0x0100000000,
	/** <summary> Used for wooden wild rides on the 1st car type. This specifies how the cars tilt and removes a pair of swinging frames. </summary> */
	SwingingTilting = 0x0200000000,
	/** <summary> Used for flat rides excluding dodgems and flying saucers, and all tower rides on the only car type. This gives guests a proper loading animation based on the ride type. </summary> */
	FlatRideAndTower = 0x0400000000,
	/** <summary> This prevents swinging while going slow and adds an extra pair of swinging frames. </summary> */
	SwingingSlide = 0x0800000000,
	/** <summary> Used for chair lifts on the only car type. This is required for chair lifts to function and display properly. </summary> */
	ChairLift = 0x1000000000,
	/** <summary> Used for log flume, river rapids, and river rafts on the only car type, and for splash boats on both of the 2 car types. The effect of this flag is unknown. </summary> */
	WaterRides = 0x2000000000,
	/** <summary> Used for go karts on the only car type. This gives go karts 2 usable lanes instead of 1. </summary> */
	GoKarts2Lanes = 0x4000000000,
	/** <summary> Used for dodgems and flying saucers on the only car type. This causes the bumper cars to visually function and specifies how guests load onto the ride. </summary> */
	BumperCars = 0x8000000000,

	Unknown2_0 = 0x0000000002,
	Unknown4_0 = 0x0000000004,
	Unknown8_0 = 0x0000000008,

	Unknown1_2 = 0x0000000100,
	Unknown2_2 = 0x0000000200,
	Unknown8_2 = 0x0000000800,

	Unknown1_4 = 0x0000010000,
	Unknown2_4 = 0x0000020000,

	Unknown1_7 = 0x0010000000,
	Unknown8_7 = 0x0080000000,
	
	/** <summary> This value is never used. </summary> */
	Unused1_1 = 0x0000000010,
	/** <summary> This value is never used. </summary> */
	Unused2_1 = 0x0000000020,
	/** <summary> This value is never used. </summary> */
	Unused4_1 = 0x0000000040,
	/** <summary> This value is never used. </summary> */
	Unused8_1 = 0x0000000080
}
/** <summary> The different display visuals a car can have. </summary> */
public enum CarVisuals : byte {
	/** <summary> No car visuals. </summary> */
	Default = 0x00,
	/** <summary> Used for flat rides on the only car type and car rides on the 2nd car type. </summary> */
	FlatRideAndCarRide = 0x01,
	/** <summary> Used for launched freefalls on the only car type. </summary> */
	LaunchedFreefall = 0x02,
	/** <summary> Used for observation towers on the only car type. </summary> */
	ObservationTower = 0x03,
	/** <summary> Used for river rapids on the only car type. </summary> */
	RiverRapids = 0x04,
	/** <summary> Used for mini golf on the 2nd car type. </summary> */
	MiniGolfPlayer = 0x05,
	/** <summary> Used for mini golf on the 1st car type. </summary> */
	MiniGolfBall = 0x06,
	/** <summary> Used for reverser on the 1st and 2nd car types. </summary> */
	Reverser = 0x07,
	/** <summary> Used for splash boats and water coasters on the 2nd car type. </summary> */
	SplashBoatsAndWaterCoaster = 0x08,
	/** <summary> Used for roto-drop on the only car type. </summary> */
	RotoDrop = 0x09,
	/** <summary> Used for virginia reel on the only car type. </summary> */
	VirginiaReel = 0x0F,
	/** <summary> Used for submarines on the only car type. </summary> */
	Submarine = 0x10
}
/** <summary> The different unknown settings a car can have. </summary> */
public enum CarUnknownSettings : byte {
	/** <summary> No car setting. The default is always 1. </summary> */
	Default = 0x01,
	/** <summary> Used for wooden coasters on the only car type and heartline twisters on the only car type. </summary> */
	WoodenCoasterAndHeartlineTwister = 0x0A,
	/** <summary> Used for river rapids on the only car type. </summary> */
	RiverRapids = 0x0B,
	/** <summary> Used for log flumes on the only car type. </summary> */
	LogFlumes = 0x0C,
	/** <summary> Used for splash boats on both of the 2 car types. </summary> */
	SplashBoats = 0x0D,
	/** <summary> Used for water coasters on the 1st car type. </summary> */
	WaterCoaster = 0x0E
}
/** <summary> All flags usable with attraction car sprites.
 * <para>R = LastRotationFrame + 1.</para>
 * <para>Anim = number of animation frames.</para>
 * <para>Each rotation frame has Anim frames of animation.</para>
 * </summary> */
[Flags]
public enum CarSpriteFlags : ushort {
	/** <summary> No flags are set. </summary> */
	None = 0x00000000,
	/** <summary> All flat car sprites. Consists of:
	 * <para>R-frame rotations angled flat.</para>
	 * </summary> */
	Flat = 0x0001,
	/** <summary> All gentle car sprites. Consists of:
	 * <para>Two 4-frame rotations angled up then down at a flat to gentle slope transition.</para>
	 * <para>Two R-frame rotations angled up then down at a gentle slope.</para>
	 * </summary> */
	GentleSlopes = 0x0002,
	/** <summary> All steep slope car sprites. Consists of:
	 * <para>Two 8-frame rotations angled up then down at a gentle to steep slope transition.</para>
	 * <para>Two R-frame rotations angled up then down at a steep slope.</para>
	 * </summary> */
	SteepSlopes = 0x0004,
	/** <summary> All verticle slope and loop car sprites. Consists of:
	 * <para>Two 4-frame rotations angled up then down at a steep to vertical slope transition.</para>
	 * <para>Two R-frame rotations angled up then down at a vertical slope.</para>
	 * <para>Five sets of two 4-frame rotations angled up then down at a looping transition.</para>
	 * <para>4-frame rotations with the car inverted.</para>
	 * </summary> */
	VerticalSlopes = 0x0008,
	/** <summary> All diagonal slope car sprites. Consists of:
	 * <para>Two 4-frame rotations angled up then down at a flat to gentle slope transition.</para>
	 * <para>Two 4-frame rotations angled up then down at a gentle slope.</para>
	 * <para>Two 4-frame rotations angled up then down at a steep slope.</para>
	 * </summary> */
	DiagonalSlopes = 0x0010,
	/** <summary> All flat banked car sprites. Consists of:
	 * <para>Two 8-frame rotations angled left then right at a flat to bank transition.</para>
	 * <para>Two R-frame rotations angled left then right at a bank.</para>
	 * </summary> */
	FlatBanked = 0x0020,
	/** <summary> All inline twist car sprites. Consists of:
	 * <para>10 sets of 4-frame rotations. Angle information not available yet.</para>
	 * </summary> */
	InlineTwists = 0x0040,
	/** <summary> All flat to gentle slope bank transition car sprites. Consists of:
	 * <para>Four R-frame rotations angled up-left, up-right, down-left, then down-right at a flat to gentle slope bank transition.</para>
	 * </summary> */
	FlatToGentleSlopeBankedTransitions = 0x0080,
	/** <summary> All diagonal gentle slope bank transition car sprites. Consists of:
	 * <para>Four 4-frame rotations angled up-left, up-right, down-left, then down-right at a gentle slope to gentle slope bank transition.</para>
	 * </summary> */
	DiagonalGentleSlopeBankedTransitions = 0x0100,
	/** <summary> All gentle slope bank transition car sprites. Consists of:
	 * <para>Four 4-frame rotations angled up-left, up-right, down-left, then down-right at a gentle slope to gentle slope bank transition.</para>
	 * </summary> */
	GentleSlopeBankedTransitions = 0x0200,
	/** <summary> All gentle slope banked turn car sprites. Consists of:
	 * <para>Four R-frame rotations angled up-left, up-right, down-left, then down-right at a gentle slope to gentle slope bank transition.</para>
	 * </summary> */
	GentleSlopeBankedTurns = 0x0400,
	/** <summary> All flat to gentle slope while banked transition car sprites. Consists of:
	 * <para>Four 4-frame rotations angled up-left, up-right, down-left, then down-right at a flat bank to gentle slope bank transition.</para>
	 * </summary> */
	FlatToGentleSlopeWhileBankedTransitions = 0x0800,
	/** <summary> All corkscrew car sprites. Consists of:
	 * <para>20 sets of 4-frame rotations. Angle information not available yet.</para>
	 * </summary> */
	Corkscrews = 0x1000,
	/** <summary> All restraint animation car sprites. Consists of:
	 * <para>Three sets of 4 frame rotations with the restraints opening.</para>
	 * </summary> */
	RestraintAnimation = 0x2000,

	Unused4_3 = 0x4000,
	Unused8_3 = 0x8000,
}
/** <summary> The different kinds of car types. </summary> */
public enum CarTypes : byte {
	/** <summary> No car type is set. </summary> */
	None = 0xFF,

	/** <summary> The 1st car type is set. </summary> */
	CarType0 = 0x00,
	/** <summary> The second car type is set. </summary> */
	CarType1 = 0x01,
	/** <summary> The third car type is set. </summary> */
	CarType2 = 0x02,
	/** <summary> The fourth car type is set. </summary> */
	CarType3 = 0x03
}
}
