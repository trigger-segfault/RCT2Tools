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
	public RemapColors Remap1;
	/** <summary> The second remap color. </summary> */
	public RemapColors Remap2;
	/** <summary> The third remap color. </summary> */
	public RemapColors Remap3;
	/** <summary> The darkness level to draw at. </summary> */
	public int Darkness;

	/** <summary> The rotation to draw at. </summary> */
	public int Rotation;
	/** <summary> The slope to draw at. </summary> */
	public int Slope;
	/** <summary> The elevation to draw at. </summary> */
	public int Elevation;
	/** <summary> The frame index to draw. </summary> */
	public int Frame;
	
	#endregion
	//--------------------------------
	#region Specific

	/** <summary> The current car type to draw. </summary> */
	public CarTypes CurrentCar;
	/** <summary> True if riders should be drawn on the attraction. </summary> */
	public bool DrawRiders;
	/** <summary> The corner to draw the small scenery in. </summary> */
	public int Corner;
	/** <summary> True if the path should be a queue. </summary> */
	public bool Queue;
	/** <summary> The connections in the path. </summary> */
	public byte PathConnections;

	#endregion
	//--------------------------------
	#region Debug


	#endregion
	//--------------------------------
	#endregion
}
}
