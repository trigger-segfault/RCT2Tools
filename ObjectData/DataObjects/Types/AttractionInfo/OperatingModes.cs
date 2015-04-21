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
}
