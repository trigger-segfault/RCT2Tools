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
[ToolboxBitmap(typeof(Button))]
public class RCTButton : Control {

	//=========== MEMBERS ============
	#region Members

	/** <summary> True if the borders should only be drawn when hovering. </summary> */
	bool drawBorderOnlyOnHover = false;

	/** <summary> Depressed background colors. </summary> */
	Color colorBackgroundDepressed = Color.FromArgb(99, 155, 119);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderLightDepressed = Color.FromArgb(147, 199, 167);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderDarkDepressed = Color.FromArgb(59, 115, 75);

	/** <summary> Pressed background colors. </summary> */
	Color colorBackgroundPressed = Color.FromArgb(123, 175, 139);
	/** <summary> Pressed background colors. </summary> */
	Color colorBorderLightPressed = Color.FromArgb(147, 199, 167);
	/** <summary> Pressed background colors. </summary> */
	Color colorBorderDarkPressed = Color.FromArgb(59, 115, 75);

	/** <summary> The image to draw on the button. </summary> */
	Image image = null;
	/** <summary> The alignment for the image. </summary> */
	ContentAlignment imageAlign = ContentAlignment.MiddleCenter;
	/** <summary> The alignment for the text. </summary> */
	ContentAlignment textAlign = ContentAlignment.MiddleCenter;
	/** <summary> The outline color of the text. </summary> */
	Color outlineColor = Color.Transparent;
	/** <summary> The font used for the the text. </summary> */
	FontType fontType = FontType.Bold;

	/** <summary> True if the control is pressed. </summary> */
	bool pressed = false;
	/** <summary> True if the control is hovering. </summary> */
	bool hovering = false;
	/** <summary> True if the control is toggled. </summary> */
	bool toggled = false;
	/** <summary> True if the control is toggleable. </summary> */
	bool toggleable = false;

	[Browsable(true)]
	[Category("Action")]
	[DisplayName("ButtonPressed")]
	[Description("")]
	public event EventHandler ButtonPressed;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTButton() : base() {
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
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties
	//--------------------------------
	#region Button Colors

	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Depressed Background Color")][Description("")]
	public Color DepressedBackgroundColor {
		get { return this.colorBackgroundDepressed; }
		set {
			this.colorBackgroundDepressed = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Depressed Border Color Light")][Description("")]
	public Color DepressedBorderColorLight {
		get { return this.colorBorderLightDepressed; }
		set {
			this.colorBorderLightDepressed = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Depressed Border Color Dark")][Description("")]
	public Color DepressedBorderColorDark {
		get { return this.colorBorderDarkDepressed; }
		set {
			this.colorBorderDarkDepressed = value;
			this.Invalidate();
		}
	}
	
	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Pressed Background Color")][Description("")]
	public Color PressedBackgroundColor {
		get { return this.colorBackgroundPressed; }
		set {
			this.colorBackgroundPressed = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Pressed Border Color Light")][Description("")]
	public Color PressedBorderColorLight {
		get { return this.colorBorderLightPressed; }
		set {
			this.colorBorderLightPressed = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Button Colors")]
	[DisplayName("Pressed Border Color Dark")][Description("")]
	public Color PressedBorderColorDark {
		get { return this.colorBorderDarkPressed; }
		set {
			this.colorBorderDarkPressed = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Appearance

	[Browsable(true)][Category("Appearance")]
	[DisplayName("Text Align")][Description("")]
	public ContentAlignment TextAlign {
		get { return this.textAlign; }
		set {
			this.textAlign = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Border on Hover")][Description("")]
	public bool BorderOnHover {
		get { return this.drawBorderOnlyOnHover; }
		set {
			this.drawBorderOnlyOnHover = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Image Align")][Description("")]
	public ContentAlignment ImageAlign {
		get { return this.imageAlign; }
		set {
			this.imageAlign = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Image")][Description("")]
	public Image Image {
		get { return this.image; }
		set {
			this.image = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Outline Color")][Description("")]
	public Color OutlineColor {
		get { return this.outlineColor; }
		set {
			this.outlineColor = value;
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Appearance")]
	[DisplayName("Font Type")][Description("")]
	public FontType FontType {
		get { return this.fontType; }
		set {
			this.fontType = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Behavior

	[Browsable(true)][Category("Behavior")]
	[DisplayName("Toggleable")][Description("")]
	public bool Toggleable {
		get { return this.toggleable; }
		set {this.toggleable = value; }
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Toggled")][Description("")]
	public bool Toggled {
		get { return this.toggled; }
		set { 
			this.toggled = value;
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

	/** <summary> Raises the ButtonPressed event. </summary> */
	protected void OnButtonPressed(EventArgs e) {
		if (this.ButtonPressed != null)
			this.ButtonPressed(this, e);
	}
	/** <summary> Called when the mouse button is down. </summary> */ 
	protected override void OnMouseDown(MouseEventArgs e) {
		this.pressed = true;
		this.Invalidate();
		base.OnMouseDown(e);
	}
	/** <summary> Called when the mouse button is up. </summary> */ 
	protected override void OnMouseUp(MouseEventArgs e) {
		this.pressed = false;
		if (this.hovering) {
			if (this.toggleable)
				this.toggled = !this.toggled;
			OnButtonPressed(new EventArgs());
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
		if (pressed || toggled) {
			e.Graphics.FillRectangle(new SolidBrush(colorBackgroundPressed), new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
			e.Graphics.DrawLine(new Pen(colorBorderDarkPressed), new Point(0, 0), new Point(ClientSize.Width - 1, 0));
			e.Graphics.DrawLine(new Pen(colorBorderDarkPressed), new Point(0, 0), new Point(0, ClientSize.Height - 1));
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(1, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(ClientSize.Width - 1, 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
		}
		else {

			e.Graphics.FillRectangle(new SolidBrush(colorBackgroundDepressed), new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));

			if (hovering || !drawBorderOnlyOnHover || DesignMode) {
				e.Graphics.DrawLine(new Pen(colorBorderLightDepressed), new Point(0, 0), new Point(ClientSize.Width - 2, 0));
				e.Graphics.DrawLine(new Pen(colorBorderLightDepressed), new Point(0, 0), new Point(0, ClientSize.Height - 2));
				e.Graphics.DrawLine(new Pen(colorBorderDarkDepressed), new Point(0, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
				e.Graphics.DrawLine(new Pen(colorBorderDarkDepressed), new Point(ClientSize.Width - 1, 0), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
			}
		}

		if (image != null) {
			Point point = Point.Empty;
			Size size = image.Size;
			Rectangle rect = new Rectangle(2, 2, ClientSize.Width - 4, ClientSize.Height - 4);
			if (imageAlign == ContentAlignment.TopLeft || imageAlign == ContentAlignment.MiddleLeft || imageAlign == ContentAlignment.BottomLeft)
				point.X = 0;
			else if (imageAlign == ContentAlignment.TopCenter || imageAlign == ContentAlignment.MiddleCenter || imageAlign == ContentAlignment.BottomCenter)
				point.X = (rect.Width - size.Width) / 2;
			else if (imageAlign == ContentAlignment.TopRight || imageAlign == ContentAlignment.MiddleRight || imageAlign == ContentAlignment.BottomRight)
				point.X = rect.Width - size.Width;

			if (imageAlign == ContentAlignment.TopLeft || imageAlign == ContentAlignment.TopCenter || imageAlign == ContentAlignment.TopRight)
				point.Y = 0;
			else if (imageAlign == ContentAlignment.MiddleLeft || imageAlign == ContentAlignment.MiddleCenter || imageAlign == ContentAlignment.MiddleRight)
				point.Y = (rect.Height - size.Height) / 2;
			else if (imageAlign == ContentAlignment.BottomLeft || imageAlign == ContentAlignment.BottomCenter || imageAlign == ContentAlignment.BottomRight)
				point.Y = rect.Height - size.Height;
			e.Graphics.DrawImage(image, rect.X + point.X, rect.Y + point.Y);
		}

		SpriteFont font = SpriteFont.FontBold;
		switch (this.fontType) {
		case FontType.Regular: font = SpriteFont.FontRegular; break;
		case FontType.Bold: font = SpriteFont.FontBold; break;
		case FontType.Small: font = SpriteFont.FontSmall; break;
		}
		font.DrawAligned(e.Graphics, new Rectangle(2, 3, ClientSize.Width - 4, ClientSize.Height - 4), textAlign, Text, ForeColor, outlineColor);
	}

	#endregion
}
}
