using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> The different types of operating modes available for rides. </summary> */
public enum OperatingModes : byte {
	NormalMode = 0x00,
	ContinuousCircuitMode = 0x01,
	ReverseInclineLaunchedShuttleMode = 0x02,
	PoweredLaunchMode = 0x03,
	/** <summary> For monorails (requires powered vehicles). </summary> */
	ShuttleMode = 0x04,
	BoatHireMode = 0x05,
	UpwardLaunchMode = 0x06,
	RotatingLiftMode = 0x07,
	/** <summary> For chairlift (requires 2 end stations). </summary> */
	StationToStationMode = 0x08,
	/** <summary> For spiral slide. </summary> */
	SingleRidePerAdmission = 0x09,
	/** <summary> For spiral slide. </summary> */
	UnlimitedRidesPerAdmission = 0x0A,
	/** <summary> For mazes. </summary> */
	MazeMode = 0x0B,
	RaceMode = 0x0C,
	BumperCarMode = 0x0D,
	/** <summary> For pirate ships. </summary> */
	SwingMode = 0x0E,
	ShopStallMode = 0x0F,
	/** <summary> For carousel. </summary> */
	RotationMode = 0x10,
	/** <summary> For ferris wheel. </summary> */
	ForwardRotationMode = 0x11,
	/** <summary> For ferris wheel. </summary> */
	BackwardRotationMode = 0x12,
	FilmAvengingAviators = 0x13,
	Film3DMouseTails = 0x14,
	SpaceRingsMode = 0x15,
	/** <summary> For gravitron. </summary> */
	BeginnersMode = 0x16,
	LIMPoweredLaunchMode = 0x17,
	FilmThrillRiders = 0x18,
	Film3DStormChasers = 0x19,
	Film3DSpaceRaiders = 0x1A,
	/** <summary> For gravitron. </summary> */
	IntenseMode = 0x1B,
	/** <summary> For gravitron. </summary> */
	BerserkMode = 0x1C,
	HauntedHouseMode = 0x1D,
	CircusShowMode = 0x1E,
	DownwardLaunchMode = 0x1F,
	CrookedHouseMode = 0x20,
	FreefallDropMode = 0x21,
	ContinuousCircuitBlockSectionedMode = 0x22,
	PoweredLaunchMode2 = 0x23,
	PoweredLaunchBlockSectionedMode = 0x24
}
/** <summary> The departure control flags. </summary> */
[Flags]
public enum DepartureControlFlags : byte {

	//============ LOADS =============
	#region Loads

	/** <summary> The train will leave once at least 1/4 of a full load is aquired. </summary> */
	OneFourthLoad = 0x00,
	/** <summary> The train will leave once at least 1/2 of a full load is aquired. </summary> */
	OneHalfLoad = 0x01,
	/** <summary> The train will leave once at least 3/4 of a full load is aquired. </summary> */
	ThreeFourthsLoad = 0x02,
	/** <summary> The train will leave once a full load is aquired. </summary> */
	FullLoad = 0x03,
	/** <summary> The train will leave once any load is aquired. </summary> */
	AnyLoad = 0x04,

	#endregion
	//============ FLAGS =============
	#region Loads

	/** <summary> The train has to wait for the specified load. </summary> */
	WaitForLoad = 0x08,
	/** <summary> The train has to leave if another train arrives at the station. </summary> */
	LeaveIfAnotherTrainArrives = 0x10,
	/** <summary> The train will leave the station at the same time as trains at adjecent stations. </summary> */
	SyncWithAdjacent = 0x20,
	/** <summary> The minimum wait time is used. </summary> */
	UseMinimumTime = 0x40,
	/** <summary> The maximum wait time is used. </summary> */
	UseMaximumTime = 0x80

	#endregion
}
}
