using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> The different types of track segments. </summary> */
public enum TrackSegments : byte {

	//=========== GENERAL ============
	#region General

	Flat = 0x00,
	EndStation = 0x01,
	BeginStation = 0x02,
	MiddleStation = 0x03,

	#endregion
	//=========== SLOPE UP ===========
	#region Slope Up

	SlopeUp25 = 0x04,
	SlopeUp60 = 0x05,
	FlatToSlopeUp25 = 0x06,
	SlopeUp25ToSlopeUp60 = 0x07,
	SlopeUp60ToSlopeUp25 = 0x08,
	SlopeUp25ToFlat = 0x09,

	#endregion
	//========== SLOPE DOWN ==========
	#region Slope Down

	SlopeDown25 = 0x0A,
	SlopeDown60 = 0x0B,
	FlatToSlopeDown25 = 0x0C,
	SlopeDown25ToSlopeDown60 = 0x0D,
	SlopeDown60ToSlopeDown25 = 0x0E,
	SlopeDown25ToFlat = 0x0F,

	#endregion
	//=========== BANKING ============
	#region Banking

	LeftQuarterTurnD5 = 0x10,
	RightQuarterTurnD5 = 0x11,

	// I'll do this later...

	#endregion
}
/** <summary> The different types of track qualifiers. </summary> */
[Flags]
public enum TrackQualifiers : byte {

	//=========== STATIONS ===========
	#region Stations

	/** <summary> This is the first station on the ride. </summary> */
	Station1 = 0x00,
	/** <summary> This is the second station on the ride. </summary> */
	Station2 = 0x01,
	/** <summary> This is the third station on the ride. </summary> */
	Station3 = 0x02,
	/** <summary> This is the fourth station on the ride. </summary> */
	Station4 = 0x03,
	/** <summary> Departure control flags apply here. </summary> */
	TerminalStation = 0x08,

	#endregion
	//======== COLOR SCHEMES =========
	#region Color Schemes
	
	/** <summary> The main track color scheme is used. </summary> */
	ColorScheme0 = 0x00,
	/** <summary> The first alternate track color scheme is used. </summary> */
	ColorScheme1 = 0x10,
	/** <summary> The second alternate track color scheme is used. </summary> */
	ColorScheme2 = 0x20,
	/** <summary> The third alternate track color scheme is used. </summary> */
	ColorScheme3 = 0x30,

	#endregion
	//============ BRAKES ============
	#region Brakes

	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes0MPH = 0x00,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes4MPH = 0x01,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes9MPH = 0x02,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes13MPH = 0x03,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes18MPH = 0x04,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes22MPH = 0x05,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes27MPH = 0x06,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes31MPH = 0x07,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes36MPH = 0x08,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes40MPH = 0x09,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes45MPH = 0x0A,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes49MPH = 0x0B,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes54MPH = 0x0C,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes58MPH = 0x0D,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes63MPH = 0x0E,
	/** <summary> Sets magnitude for the breaks. </summary> */
	Brakes67MPH = 0x0F,

	#endregion
	//======= MULTI DIMENSION ========
	#region Multi-Dimension

	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationMinus180 = 0x00,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationMinus135 = 0x01,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationMinus90 = 0x02,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationMinus45 = 0x03,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationZero = 0x04,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus45 = 0x05,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus90 = 0x06,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus135 = 0x07,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus180 = 0x08,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus225 = 0x09,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus270 = 0x0A,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus315 = 0x0B,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus360 = 0x0C,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus405 = 0x0D,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus450 = 0x0E,
	/** <summary> Sets the seat rotation of the multi-dimension coaster. </summary> */
	SeatRotationPlus495 = 0x0F,

	#endregion
	//======== MISCELLANEOUS =========
	#region Miscellaneous

	/** <summary> There are no track qualifiers. </summary> */
	None = 0x00,
	/** <summary> This track piece is inverted. </summary> */
	InvertedTrack = 0x40,
	/** <summary> Chain lift is used on this track piece. </summary> */
	ChainLift = 0x80,

	#endregion
}
}
