using CustomControls.Visuals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControls {
/** <summary> A button that uses images. </summary> */
[ToolboxBitmap(typeof(Panel))]
public class RCTPanel : Panel {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Depressed background colors. </summary> */
	Color colorBackground = Color.FromArgb(99, 155, 119);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderLight = Color.FromArgb(147, 199, 167);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderDark = Color.FromArgb(59, 115, 75);

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTPanel()
		: base() {
		this.InitializeComponent();

		this.ForeColor = Color.FromArgb(23, 35, 35);
	}

	#endregion
	//======== INITIALIZATION ========
	#region Initialization

	/** <summary> Initializes the component. </summary> */
	public void InitializeComponent() {
		this.SetStyle(ControlStyles.Selectable, false);
		this.SetStyle(ControlStyles.UserPaint, true);
		this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		this.SetStyle(ControlStyles.DoubleBuffer, true);

		this.ResizeRedraw = true;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Button Colors

	[Browsable(true)][Category("Panel Colors")]
	[DisplayName("Panel Background Color")][Description("")]
	public Color PanelBackgroundColor {
		get { return this.colorBackground; }
		set {
			this.colorBackground = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Panel Colors")]
	[DisplayName("Panel Border Color Light")][Description("")]
	public Color PanelBorderColorLight {
		get { return this.colorBorderLight; }
		set {
			this.colorBorderLight = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Panel Colors")]
	[DisplayName("Panel Border Color Dark")][Description("")]
	public Color PanelBorderColorDark {
		get { return this.colorBorderDark; }
		set {
			this.colorBorderDark = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Overrides

	/** <summary> Prevents focus from being shown. </summary> */
	protected override bool ShowFocusCues {
		get { return false; }
	}

	#endregion
	//--------------------------------
	#endregion
	//============ EVENTS ============
	#region Events

	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.FillRectangle(new SolidBrush(colorBackground), new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(ClientSize.Width - 1, 0));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(0, ClientSize.Height - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(1, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(ClientSize.Width - 1, 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
	}

	#endregion
}
}
