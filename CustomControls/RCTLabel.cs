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
[ToolboxBitmap(typeof(Label))]
public class RCTLabel : Control {

	//=========== MEMBERS ============
	#region Members

	/** <summary> The alignment for the text. </summary> */
	ContentAlignment textAlign = ContentAlignment.TopLeft;
	/** <summary> The outline color of the text. </summary> */
	Color outlineColor = Color.Transparent;
	/** <summary> The font used for the the text. </summary> */
	FontType fontType = FontType.Bold;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default control. </summary> */
	public RCTLabel()
		: base() {
		this.InitializeComponent();

		this.ForeColor = Color.FromArgb(23, 35, 35);
		this.Size = new Size(this.Size.Width, 15);
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
	#region Overrides

	/** <summary> Invalidate when the text is changed. </summary> */
	public override string Text {
		get { return base.Text; }
		set {
			base.Text = value;
			this.Size = new Size(this.Size.Width, 14);
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

	/** <summary> Paints the control. </summary> */
	protected override void OnPaint(PaintEventArgs e) {
		SpriteFont font = SpriteFont.FontBold;
		switch (this.fontType) {
		case FontType.Regular: font = SpriteFont.FontRegular; break;
		case FontType.Bold: font = SpriteFont.FontBold; break;
		case FontType.Small: font = SpriteFont.FontSmall; break;
		}
		font.DrawAligned(e.Graphics, new Rectangle(1, 1, ClientSize.Width - 8, ClientSize.Height - 8), textAlign, Text, ForeColor, outlineColor);
	}
	#endregion
}
}
