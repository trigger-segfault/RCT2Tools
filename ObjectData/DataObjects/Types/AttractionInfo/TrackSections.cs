using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> All flags usable for available track sections.
 * <para> Each of these pieces will only be enabled if the track type supports it. </para>
 * <para> Rides with roll banking or sloped turns should have the large turn enabled by default.
 * Otherwise, the editor will still select it as the default even if the user cannot select it. </para>
 * </summary> */
[Flags]
public enum TrackSections : ulong {
	/** <summary> No track sections are available. </summary> */
	None = 0x0000000000000000,
	/** <summary> All track sections are available. </summary> */
	All = 0xFFFFFFFFFFFFFFFF,

	/** <summary> Enables the straight track piece. </summary> */
	Straight = 0x0000000000000002,
	/** <summary> Enables the station platform track piece. </summary> */
	StationPlatform = 0x0000000000000004,
	/** <summary> Enables the chainlift hill for flat and gentle slope surfaces. Downwards steep slope chainlift seems to be available as well. </summary> */
	ChainLift = 0x0000000000000008,
	/** <summary> Enables the chainlift hill for steep slope surfaces. </summary> */
	SteepSlopeChainLift = 0x0000000000000010,
	/** <summary> Enables the chainlift hill for gentle slope turns. </summary> */
	GentleSlopeTurnChainLift = 0x0000000000000020,
	/** <summary> Enables flat roll banking. </summary> */
	FlatRollBanking = 0x0000000000000040,
	/** <summary> Enables the verticle small vertical loop pieces. </summary> */
	VerticalLoop = 0x0000000000000080,
	/** <summary> Enables the gentle slope track pieces. </summary> */
	GentleSlope = 0x0000000000000100,
	/** <summary> Enables the steep slope track pieces. </summary> */
	SteepSlope = 0x0000000000000200,
	/** <summary> Enables the short flat to steep slope transition track piece. </summary> */
	FlatToSteepSlopeShort = 0x0000000000000400,
	/** <summary> Enables the gentle slope turn track pieces. </summary> */
	GentleSlopeTurns = 0x0000000000000800,
	/** <summary> Enables the steep slope turn track pieces. </summary> */
	SteepSlopeTurns = 0x0000000000001000,
	/** <summary> Enables the s-bend track pieces. </summary> */
	SBend = 0x0000000000002000,
	/** <summary> Enables the 1x1 turn track pieces. Flat turns are enabled by default with this flag but other turn types require a separate flag as well. </summary> */
	TinyTurns = 0x0000000000004000,
	/** <summary> Enables the 2x2 turn track pieces. Flat turns are enabled by default with this flag but other turn types require a separate flag as well. </summary> */
	SmallTurns = 0x0000000000008000,
	/** <summary> Enables the 3x3 turn track pieces. Flat turns are enabled by default with this flag but other turn types require a separate flag as well. </summary> */
	LargeTurns = 0x0000000000010000,
	/** <summary> Enables the inline twist track pieces. These pieces do not support inversions. </summary> */
	InlineTwists = 0x0000000000020000,
	/** <summary> Enables the half loop track piece. This piece does not support inversions. </summary> */
	HalfLoop = 0x0000000000040000,
	/** <summary> Enables the half corkscrew track pieces. These pieces support inversions and no inversions. </summary> */
	HalfCorkscrew = 0x0000000000080000,
	/** <summary> Enables the verticle track piece. This is used for all tower rides. </summary> */
	VerticalTower = 0x0000000000100000,
	/** <summary> Enables the half helix track pieces. This is only available for right-side-up track pieces. </summary> */
	HalfHelixes = 0x0000000000200000,
	/** <summary> Enables the quarter helix track pieces. This is only available for hanging track pieces. </summary> */
	QuarterHelixes = 0x0000000000400000,
	/** <summary> Enables the no roll banking quarter helix track pieces. This is only available for hanging track pieces and is exlusive to the suspended swinging coaster. </summary> */
	QuarterHelixesNoBanking = 0x0000000000800000,
	/** <summary> Enables the brakes track piece. </summary> */
	Brakes = 0x0000000001000000,
	/** <summary> Enables the on-ride photo section track piece. </summary> */
	OnRidePhotoSection = 0x0000000004000000,
	/** <summary> Enables the water splash track piece. This piece is exclusive to the wooden coaster. </summary> */
	WaterSplash = 0x0000000008000000,
	/** <summary> Enables the vertical slope track pieces. </summary> */
	VerticalSlopes = 0x0000000010000000,
	/** <summary> Enables the barrel roll track pieces. These pieces do not support inversions. </summary> */
	BarrelRoll = 0x0000000020000000,
	/** <summary> Enables the launched lift hill track pieces. </summary> */
	LaunchedLiftHill = 0x0000000040000000,
	/** <summary> Enables the large half loop track pieces. These pieces do not support inversions. </summary> */
	LargeHalfLoop = 0x0000000080000000,
	/** <summary> Enables the flat banked to gentle slope turn track pieces.
	 * When using gentle slope down, click small turn and click flat.
	 * When using flat roll banking, click small turn and click gentle slope up.
	 * There seems to be a downward version of this but it doesn't work in game. This is also enabled by this flag.
	 * </summary> */
	FlatBankedToGentleSlopeTurn = 0x0000000100000000,
	/** <summary> Enables the reverser turntable track piece. This piece is exclusive to the log flume. </summary> */
	ReverserTurntable = 0x0000000200000000,
	/** <summary> Enables the heartline roll track pieces. These pieces are exclusive to the heartline twister coaster. </summary> */
	HeartlineRoll = 0x0000000400000000,
	/** <summary> Enables the reverser track pieces. These pieces are exclusive to the reverser coaster. </summary> */
	Reverser = 0x0000000800000000,
	/** <summary> Enables the slope to vertical and vertical track pieces. These pieces are exclusive to the air powered vertical coaster and reverse freefall coaster. </summary> */
	SlopeToVertical = 0x0000001000000000,
	/** <summary> Enables the slope to flat, top section, and vertical track pieces. These pieces are exclusive to the air powered vertical coaster. </summary> */
	SlopeToFlat = 0x0000002000000000,
	/** <summary> Enables the black brakes track piece. </summary> */
	BlockBrakes = 0x0000004000000000,
	/** <summary> Enables the gentle slope roll banking track pieces. This also enables all available turns. </summary> */
	GentleSlopeRollBanking = 0x0000008000000000,
	/** <summary> Enables the long flat to steep slope track pieces. </summary> */
	FlatToSteepSlopeLong = 0x0000010000000000,
	/** <summary> Enables the vertical slope turn track pieces. </summary> */
	VerticalSlopeTurns = 0x0000020000000000,
	/** <summary> Enables the cable lift hill track piece. This piece is exclusive to the giga coaster. </summary> */
	CableLiftHill = 0x0000080000000000,
	/** <summary> Enables the curved lift hill track pieces. These pieces are exclusive to the spiral coaster. </summary> */
	CurvedLiftHill = 0x0000100000000000,
	/** <summary> Enables the quarter loop track pieces. These pieces do not support inversions. </summary> */
	QuarterLoop = 0x0000200000000000,
	/** <summary> Enables the quarter loop track piece. This piece is exclusive to the car ride and ghost train. </summary> */
	SpinningTunnel = 0x0000400000000000,
	/** <summary> Enables the spinning toggle control track piece. This piece is exclusive to the spinning wild mouse. </summary> */
	SpinningToggleControl = 0x0000800000000000,
	/** <summary> Enables the uninverted in-line twist track pieces. These pieces support inversions to inverted track. </summary> */
	InlineTwistUninverted = 0x0001000000000000,
	/** <summary> Enables the inverted in-line twist track pieces. These pieces support inversions to uninverted track. </summary> */
	InlineTwistInverted = 0x0002000000000000,
	/** <summary> Enables the uninverted quarter loop track pieces. These pieces support inversions to inverted track. </summary> */
	QuarterLoopUninverted = 0x0004000000000000,
	/** <summary> Enables the inverted quarter loop track pieces. These pieces support inversions to uninverted track. </summary> */
	QuarterLoopInverted = 0x0008000000000000,
	/** <summary> Enables the rapids and log bump track pieces. These pieces are exclusive to the river rapids and car ride. </summary> */
	RapidsAndLogBumps = 0x0010000000000000,
	/** <summary> Enables the uninverted half loop track pieces. These pieces support inversions to inverted track. </summary> */
	HalfLoopUninverted = 0x0020000000000000,
	/** <summary> Enables the inverted half loop track pieces. These pieces support inversions to uninverted track. </summary> */
	HalfLoopInverted = 0x0040000000000000,

	Unknown1_0 = 0x0000000000000001,
	Unknown2_5 = 0x0000000002000000,
	Unknown4_10 = 0x0000040000000000,
	Unknown8_13 = 0x0080000000000000,

	Unused1_14 = 0x0100000000000000,
	Unused2_14 = 0x0200000000000000,
	Unused4_14 = 0x0400000000000000,
	Unused8_14 = 0x0800000000000000,
	Unused1_15 = 0x1000000000000000,
	Unused2_15 = 0x2000000000000000,
	Unused4_15 = 0x4000000000000000,
	Unused8_15 = 0x8000000000000000,
}
}
