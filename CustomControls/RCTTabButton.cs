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
public class RCTTabButton : Control {

	//=========== MEMBERS ============
	#region Members

	/** <summary> Depressed background colors. </summary> */
	Color colorBackgroundDepressed = Color.FromArgb(79, 135, 95);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderLightDepressed = Color.FromArgb(123, 175, 139);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderMediumDepressed = Color.FromArgb(99, 155, 119);
	/** <summary> Depressed background colors. </summary> */
	Color colorBorderDarkDepressed = Color.FromArgb(47, 99, 59);

	/** <summary> Pressed background colors. </summary> */
	Color colorBackgroundPressed = Color.FromArgb(99, 155, 119);
	/** <summary> Pressed background colors. </summary> */
	Color colorBorderLightPressed = Color.FromArgb(147, 199, 167);
	/** <summary> Pressed background colors. </summary> */
	Color colorBorderMediumPressed = Color.FromArgb(123, 175, 139);
	/** <summary> Pressed background colors. </summary> */
	Color colorBorderDarkPressed = Color.FromArgb(59, 115, 75);

	/** <summary> The image to draw on the button. </summary> */
	Image image = null;

	/** <summary> The previous tab button. </summary> */
	RCTTabButton previousButton = null;
	/** <summary> The next tab button. </summary> */
	RCTTabButton nextButton = null;
	/** <summary> The page to activate with this tab. </summary> */
	Control tabPage = null;

	/** <summary> The index of the tab. </summary> */
	uint tabIndex = 0;
	/** <summary> The selected index of the tab control. </summary> */
	int selectedIndex = 0;

	/** <summary> True if the control is toggled. </summary> */
	bool toggled = false;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTTabButton()
		: base() {
		this.InitializeComponent();

		this.ForeColor = Color.FromArgb(23, 35, 35);
		this.Size = new Size(31, 27);
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
	[Browsable(true)]
	[Category("Button Colors")]
	[DisplayName("Depressed Border Color Medium")]
	[Description("")]
	public Color DepressedBorderColorMedium {
		get { return this.colorBorderMediumDepressed; }
		set {
			this.colorBorderMediumDepressed = value;
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
	[Browsable(true)]
	[Category("Button Colors")]
	[DisplayName("Pressed Border Medium Light")]
	[Description("")]
	public Color PressedBorderColorMedium {
		get { return this.colorBorderMediumPressed; }
		set {
			this.colorBorderMediumPressed = value;
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
	[DisplayName("Image")][Description("")]
	public Image Image {
		get { return this.image; }
		set {
			this.image = value;
			this.Invalidate();
		}
	}

	#endregion
	//--------------------------------
	#region Behavior
	
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Previous Tab Button")][Description("")]
	public RCTTabButton PreviousTabButton {
		get { return this.previousButton; }
		set { this.previousButton = value; }
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Next Tab Button")][Description("")]
	public RCTTabButton NextTabButton {
		get { return this.nextButton; }
		set { this.nextButton = value; }
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Tab Page")][Description("")]
	public Control TabPage {
		get { return this.tabPage; }
		set { this.tabPage = value; }
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("Toggled")][Description("")]
	public bool Toggled {
		get { return this.toggled; }
		set { 
			this.toggled = value;
			/*if (this.previousButton != null)
				this.previousButton.Toggled = false;
			if (this.nextButton != null)
				this.nextButton.Toggled = false;
			this.tabPage.Visible = this.toggled;*/
			this.Invalidate();
		}
	}
	[Browsable(true)][Category("Behavior")]
	[DisplayName("TabControl Index")][Description("")]
	public uint TabControlIndex {
		get { return this.tabIndex; }
		set { this.tabIndex = value; }
	}

	#endregion
	//--------------------------------
	#region Overrides

	/** <summary> Invalidate when the text is changed. </summary> */
	public override string Text {
		get { return base.Text; }
		set {
			base.Text = value;
			this.Size = new Size(31, 27);
			this.Invalidate();
		}
	}
	/** <summary> Prevents focus from being shown. </summary> */
	protected override bool ShowFocusCues {
		get { return false; }
	}
	/** <summary> Gets the index of the selected tab. </summary> */
	protected int SelectedIndex {
		get { return this.selectedIndex; }
	}

	#endregion
	//--------------------------------
	#endregion
	//============ EVENTS ============
	#region Events

	/** <summary> Called when the mouse button is down. </summary> */
	protected override void OnMouseDown(MouseEventArgs e) {
		if (!this.toggled) {
			this.ToggleTab();
			this.Invalidate();
		}
		base.OnMouseDown(e);
	}
	private void UntoggleTab(int index, bool left) {
		if (this.toggled) {
			this.toggled = false;
			this.Invalidate();
		}
		this.selectedIndex = index;
		if (this.tabPage != null)
			this.tabPage.Visible = false;
		if (this.previousButton != null && left)
			this.previousButton.UntoggleTab(index, true);
		if (this.nextButton != null && !left)
			this.nextButton.UntoggleTab(index, false);
	}
	public void ToggleTab() {
		if (!this.toggled) {
			this.toggled = true;
			this.selectedIndex = (int)this.tabIndex;
			this.Invalidate();
			if (this.tabPage != null)
				this.tabPage.Visible = true;
			if (this.previousButton != null)
				this.previousButton.UntoggleTab((int)this.tabIndex, true);
			if (this.nextButton != null)
				this.nextButton.UntoggleTab((int)this.tabIndex, false);
		}
	}

	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {

		if (toggled)
			e.Graphics.FillRectangle(new SolidBrush(colorBackgroundPressed), new Rectangle(1, 1, ClientSize.Width - 2, ClientSize.Height - 1));
		else
			e.Graphics.FillRectangle(new SolidBrush(colorBackgroundDepressed), new Rectangle(1, 1, ClientSize.Width - 2, ClientSize.Height - 1));

		if (image != null) {
			e.Graphics.DrawImage(image, 0, 0);
		}

		if (toggled) {
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(1, 1), new Point(1, 1));
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(2, 0), new Point(ClientSize.Width - 3, 0));
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(0, 2), new Point(0, ClientSize.Height - 1));

			e.Graphics.DrawLine(new Pen(colorBorderMediumPressed), new Point(ClientSize.Width - 2, 1), new Point(ClientSize.Width - 2, 1));

			e.Graphics.DrawLine(new Pen(colorBorderDarkPressed), new Point(ClientSize.Width - 1, 2), new Point(ClientSize.Width - 1, ClientSize.Height - 2));
		}
		else {
			e.Graphics.DrawLine(new Pen(colorBorderLightDepressed), new Point(1, 1), new Point(1, 1));
			e.Graphics.DrawLine(new Pen(colorBorderLightDepressed), new Point(2, 0), new Point(ClientSize.Width - 3, 0));
			e.Graphics.DrawLine(new Pen(colorBorderLightDepressed), new Point(0, 2), new Point(0, ClientSize.Height - 2));
			e.Graphics.DrawLine(new Pen(colorBorderLightPressed), new Point(0, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));

			e.Graphics.DrawLine(new Pen(colorBorderMediumDepressed), new Point(ClientSize.Width - 2, 1), new Point(ClientSize.Width - 2, 1));

			e.Graphics.DrawLine(new Pen(colorBorderDarkDepressed), new Point(ClientSize.Width - 1, 2), new Point(ClientSize.Width - 1, ClientSize.Height - 2));
		}
	}
	#endregion
}
}
