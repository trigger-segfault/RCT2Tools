using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCT2ObjectData.DataObjects.Types.AttractionInfo;

namespace RCT2ObjectData.DataObjects {
/** <summary> A collection of settings for drawing objects. </summary> */
public struct DrawSettings {

	//=========== MEMBERS ============
	#region Members
	//--------------------------------
	#region General

	/** <summary> The first remap color. </summary> */
	public RemapColors Remap1 = RemapColors.None;
	/** <summary> The second remap color. </summary> */
	public RemapColors Remap2 = RemapColors.None;
	/** <summary> The third remap color. </summary> */
	public RemapColors Remap3 = RemapColors.None;
	/** <summary> The darkness level to draw at. </summary> */
	public int Darkness = 0;

	/** <summary> The rotation to draw at. </summary> */
	public int Rotation = 0;
	/** <summary> The slope to draw at. </summary> */
	public int Slope = -1;
	/** <summary> The elevation to draw at. </summary> */
	public int Elevation = 0;
	/** <summary> The frame index to draw. </summary> */
	public int Frame = 0;
	
	#endregion
	//--------------------------------
	#region Specific

	/** <summary> The current car type to draw. </summary> */
	public CarTypes CurrentCar = CarTypes.CarType0;
	/** <summary> True if riders should be drawn on the attraction. </summary> */
	public bool DrawRiders = false;
	/** <summary> The corner to draw the small scenery in. </summary> */
	public int Corner = 0;
	/** <summary> True if the path should be a queue. </summary> */
	public bool Queue = false;
	/** <summary> The connections in the path. </summary> */
	public byte PathConnections = 0x00;

	#endregion
	//--------------------------------
	#region Debug


	#endregion
	//--------------------------------
	#endregion
}
}
