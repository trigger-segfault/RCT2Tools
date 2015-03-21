using CustomControls.Properties;
using CustomControls.Visuals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControls {
/** <summary> A button that uses images. </summary> */
[ToolboxBitmap(typeof(CheckBox))]
public class RCTCheckBox : Control {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Depressed background colors. </summary> */
	Color colorBackground = Color.FromArgb(99, 155, 119);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderLight = Color.FromArgb(147, 199, 167);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderDark = Color.FromArgb(59, 115, 75);
	/** <summary> The color of the check. </summary> */
	Color colorCheck = Color.FromArgb(207, 243, 223);

	/** <summary> True if the control is hovering. </summary> */
	bool hovering = false;

	/** <summary> The image for the check. </summary> */
	Image checkImage = Resource.Check;

	/** <summary> The check state of the checkbox. </summary> */
	CheckState checkState = CheckState.Unchecked;
	
	[Browsable(true)][Category("Action")]
	[DisplayName("CheckStateChanged")][Description("")]
	public event EventHandler CheckStateChanged;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTCheckBox()
		: base() {
		this.InitializeComponent();

		this.ForeColor = Color.FromArgb(23, 35, 35);
		this.Size = new Size(this.Size.Width, 11);
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
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Button Colors

	[Browsable(true)]
	[Category("Checkbox Colors")]
	[DisplayName("Check Background Color")]
	[Description("")]
	public Color CheckBackgroundColor {
		get { return this.colorBackground; }
		set {
			this.colorBackground = value;
			this.Invalidate();
		}
	}
	[Browsable(true)]
	[Category("Checkbox Colors")]
	[DisplayName("Check Border Color Light")]
	[Description("")]
	public Color CheckBorderColorLight {
		get { return this.colorBorderLight; }
		set {
			this.colorBorderLight = value;
			this.Invalidate();
		}
	}
	[Browsable(true)]
	[Category("Checkbox Colors")]
	[DisplayName("Check Border Color Dark")]
	[Description("")]
	public Color CheckBorderColorDark {
		get { return this.colorBorderDark; }
		set {
			this.colorBorderDark = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Appearance

	[Browsable(true)]
	[Category("Appearance")]
	[DisplayName("Check Color")]
	[Description("")]
	public Color CheckColor {
		get { return this.colorCheck; }
		set {
			this.colorCheck = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Behavior

	[Browsable(true)]
	[Category("Behavior")]
	[DisplayName("Check State")]
	[Description("")]
	public CheckState CheckState {
		get { return this.checkState; }
		set {
			this.checkState = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Overrides

	/** <summary> Invalidate when the text is changed. </summary> */
	public override string Text {
		get { return base.Text; }
		set {
			base.Text = value;
			this.Size = new Size(this.Size.Width, 11);
			this.Invalidate();
		}
	}
	/** <summary> Invalidate when the forecolor is changed. </summary> */
	public override Color ForeColor {
		get { return base.ForeColor; }
		set {
			base.ForeColor = value;
			this.Invalidate();
		}
	}
	/** <summary> Prevents focus from being shown. </summary> */
	protected override bool ShowFocusCues {
		get { return false; }
	}

	#endregion
	//--------------------------------
	#endregion
	//============ EVENTS ============
	#region Events

	/** <summary> Raises the CheckStateChanged event. </summary> */
	protected void OnCheckStateChanged(EventArgs e) {
		if (this.CheckStateChanged != null)
			this.CheckStateChanged(this, e);
		//else
		//	Console.WriteLine("null");
	}

	/** <summary> Called when the mouse button is down. </summary> */
	protected override void OnMouseDown(MouseEventArgs e) {
		this.Invalidate();
		this.hovering = true;
		base.OnMouseDown(e);
	}
	/** <summary> Called when the mouse button is up. </summary> */
	protected override void OnMouseUp(MouseEventArgs e) {
		if (this.hovering) {
			this.checkState = (checkState == CheckState.Unchecked ? CheckState.Checked : CheckState.Unchecked);
			//this.hovering = false;
			this.OnCheckStateChanged(new EventArgs());
		}
		this.Invalidate();
		base.OnMouseUp(e);
	}
	/** <summary> Called when the mouse is hovering. </summary> */
	protected override void OnMouseMove(MouseEventArgs e) {
		if (!this.hovering) {
			this.hovering = true;
			this.Invalidate();
		}
		base.OnMouseMove(e);
	}
	/** <summary> Called when the mouse leaves the control. </summary> */
	protected override void OnMouseLeave(EventArgs e) {
		this.hovering = false;
		this.Invalidate();
		base.OnMouseLeave(e);
	}

	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.FillRectangle(new SolidBrush(colorBackground), new Rectangle(0, 0, 10, 11));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(9, 0));
		e.Graphics.DrawLine(new Pen(colorBorderDark), new Point(0, 0), new Point(0, 10));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(1, 10), new Point(9, 10));
		e.Graphics.DrawLine(new Pen(colorBorderLight), new Point(9, 1), new Point(9, 10));

		if (checkImage != null && checkState != CheckState.Unchecked) {
			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = Color.Black;
			colorMap.NewColor = colorCheck;
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[] { colorMap });

			Point point = Point.Empty;
			Size size = checkImage.Size;
			Rectangle rect = new Rectangle(0, 0, 10, 11);
			point.X = (rect.Width - size.Width) / 2;
			point.Y = (rect.Height - size.Height) / 2;
			e.Graphics.DrawImage(checkImage, 
				new Rectangle(point, size),
				0, 0, 8, 8, GraphicsUnit.Pixel,
				imageAttributes
			);
		}
		SpriteFont.FontBold.Draw(e.Graphics, new Point(10 + 5, 1), Text, ForeColor);
	}

	#endregion
}
}
