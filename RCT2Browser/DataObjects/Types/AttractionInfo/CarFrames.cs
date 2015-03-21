using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types.AttractionInfo {
class CarFrames {
}
/** <summary> A car frame with x swinging frames and y animation frames. </summary> */
public class CarFrame {
	//=========== MEMBERS ============
	#region Members

	/** <summary> The image entry info for each frames. </summary> */
	public ImageEntry[,] Infos;
	/** <summary> The image for each frames. </summary> */
	public PaletteImage[,] Images;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs a car frame with the specified frames. </summary> */
	public CarFrame(int swingingFrames, int animationFrames) {
		this.Infos		= new ImageEntry[swingingFrames, animationFrames];
		this.Images		= new PaletteImage[swingingFrames, animationFrames];
	}

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Gets or sets the single image entry. </summary> */
	public ImageEntry Info {
		get { return Infos[0, 0]; }
		set { Infos[0, 0] = value; }
	}
	/** <summary> Gets or sets the single image. </summary> */
	public PaletteImage Image {
		get { return Images[0, 0]; }
		set { Images[0, 0] = value; }
	}

	#endregion
}
}
