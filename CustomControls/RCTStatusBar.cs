using CustomControls.Visuals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControls {
/** <summary> A button that uses images. </summary> */
[ToolboxBitmap(typeof(StatusBar))]
public class RCTStatusBar : Panel {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Depressed background colors. </summary> */
	Color colorBackground = Color.FromArgb(79, 135, 95);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderLight = Color.FromArgb(147, 199, 167);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderDark = Color.FromArgb(59, 115, 75);

	/** <summary> The list of separator locations. </summary> */
	[field: NonSerialized]
	BindingList<int> separators = new BindingList<int>();

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTStatusBar()
		: base() {
		this.InitializeComponent();

		this.separators.ListChanged += new ListChangedEventHandler(this.ListChanged);
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
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Separators")][Description("")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Collection<int> Separators {
		get { return this.separators; }
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



	protected void ListChanged(object sender, ListChangedEventArgs e) {
		this.Invalidate();
	}
	/** <summary> Paints the control. </summary> */
	protected override void OnMarginChanged(EventArgs e) {
		this.Invalidate();
	}

	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {
		Rectangle rect = new Rectangle(Margin.Left, Margin.Top, ClientSize.Width - Margin.Left - Margin.Right, ClientSize.Height - Margin.Top - Margin.Bottom);
		e.Graphics.FillRectangle(new SolidBrush(colorBackground), rect);
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(rect.X, rect.Y), new Point(rect.Right - 1, rect.Y));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(rect.X, rect.Y), new Point(rect.X, rect.Bottom - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(rect.X + 1, rect.Bottom - 1), new Point(rect.Right - 1, rect.Bottom - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(rect.Right - 1, rect.Y + 1), new Point(rect.Right - 1, rect.Bottom - 1));

		for (int i = 0; i < separators.Count; i++) {
			e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(rect.X + separators[i] + 2, rect.Y, 4, rect.Height));
			e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(rect.X + separators[i] + 6, rect.Y), new Point(rect.X + separators[i] + 6, rect.Bottom - 1));
			e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(rect.X + separators[i] + 1, rect.Y + 1), new Point(rect.X + separators[i] + 1, rect.Bottom - 1));
		}

		base.OnPaint(e);

		/*e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(ClientSize.Width - 1, 0));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(0, ClientSize.Height - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(1, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(ClientSize.Width - 1, 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));

		for (int i = 0; i < separators.Count; i++) {
			e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(separators[i] + 1, 0, 4, ClientSize.Height));
			e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(separators[i] + 5, 0), new Point(separators[i] + 5, ClientSize.Height - 1));
			e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(separators[i], 1), new Point(separators[i], ClientSize.Height - 1));
		}*/
	}

	#endregion
}
}
