using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects {

/** <summary> A palette used for storing colors. </summary> */
public class Palette {

	//========== CONSTANTS ===========
	#region Constants

	/** <summary> The default color palette for the game </summary> */
	public static Palette DefaultPalette2 = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

		Color.FromArgb(23, 35, 35), Color.FromArgb(35, 51, 51), Color.FromArgb(47, 67, 67), Color.FromArgb(63, 83, 83),
		Color.FromArgb(75, 99, 99), Color.FromArgb(91, 115, 115), Color.FromArgb(111, 131, 131), Color.FromArgb(131, 151, 151),
		Color.FromArgb(159, 175, 175), Color.FromArgb(183, 195, 195), Color.FromArgb(211, 219, 219), Color.FromArgb(239, 243, 243),

		Color.FromArgb(51, 47, 0), Color.FromArgb(63, 59, 0), Color.FromArgb(79, 75, 11), Color.FromArgb(91, 91, 19),
		Color.FromArgb(107, 107, 31), Color.FromArgb(119, 123, 47), Color.FromArgb(135, 139, 59), Color.FromArgb(151, 155, 79),
		Color.FromArgb(167, 175, 95), Color.FromArgb(187, 191, 115), Color.FromArgb(203, 207, 139), Color.FromArgb(223, 227, 163),

		Color.FromArgb(67, 43, 7), Color.FromArgb(87, 59, 11), Color.FromArgb(111, 75, 23), Color.FromArgb(127, 87, 31),
		Color.FromArgb(143, 99, 39), Color.FromArgb(159, 115, 51), Color.FromArgb(179, 131, 67), Color.FromArgb(191, 151, 87),
		Color.FromArgb(203, 175, 111), Color.FromArgb(219, 199, 135), Color.FromArgb(231, 219, 163), Color.FromArgb(247, 239, 195),

		Color.FromArgb(71, 27, 0), Color.FromArgb(95, 43, 0), Color.FromArgb(119, 63, 0), Color.FromArgb(143, 83, 7),
		Color.FromArgb(167, 111, 7), Color.FromArgb(191, 139, 15), Color.FromArgb(215, 167, 19), Color.FromArgb(243, 203, 27),
		Color.FromArgb(255, 231, 47), Color.FromArgb(255, 243, 95), Color.FromArgb(255, 251, 143), Color.FromArgb(255, 255, 195),

		Color.FromArgb(35, 0, 0), Color.FromArgb(79, 0, 0), Color.FromArgb(95, 7, 7), Color.FromArgb(111, 15, 15),
		Color.FromArgb(127, 27, 27), Color.FromArgb(143, 39, 39), Color.FromArgb(163, 59, 59), Color.FromArgb(179, 79, 79),
		Color.FromArgb(199, 103, 103), Color.FromArgb(215, 127, 127), Color.FromArgb(235, 159, 159), Color.FromArgb(255, 191, 191),

		Color.FromArgb(27, 51, 19), Color.FromArgb(35, 63, 23), Color.FromArgb(47, 79, 31), Color.FromArgb(59, 95, 39),
		Color.FromArgb(71, 111, 43), Color.FromArgb(87, 127, 51), Color.FromArgb(99, 143, 59), Color.FromArgb(115, 155, 67),
		Color.FromArgb(131, 171, 75), Color.FromArgb(147, 187, 83), Color.FromArgb(163, 203, 95), Color.FromArgb(183, 219, 103),

		Color.FromArgb(31, 55, 27), Color.FromArgb(47, 71, 35), Color.FromArgb(59, 83, 43), Color.FromArgb(75, 99, 55),
		Color.FromArgb(91, 111, 67), Color.FromArgb(111, 135, 79), Color.FromArgb(135, 159, 95), Color.FromArgb(159, 183, 111),
		Color.FromArgb(183, 207, 127), Color.FromArgb(195, 219, 147), Color.FromArgb(207, 231, 167), Color.FromArgb(223, 247, 191),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

		Color.FromArgb(79, 43, 19), Color.FromArgb(99, 55, 27), Color.FromArgb(119, 71, 43), Color.FromArgb(139, 87, 59),
		Color.FromArgb(167, 99, 67), Color.FromArgb(187, 115, 83), Color.FromArgb(207, 131, 99), Color.FromArgb(215, 151, 115),
		Color.FromArgb(227, 171, 131), Color.FromArgb(239, 191, 151), Color.FromArgb(247, 207, 171), Color.FromArgb(255, 227, 195),

		Color.FromArgb(15, 19, 55), Color.FromArgb(39, 43, 87), Color.FromArgb(51, 55, 103), Color.FromArgb(63, 67, 119),
		Color.FromArgb(83, 83, 139), Color.FromArgb(99, 99, 155), Color.FromArgb(119, 119, 175), Color.FromArgb(139, 139, 191),
		Color.FromArgb(159, 159, 207), Color.FromArgb(183, 183, 223), Color.FromArgb(211, 211, 239), Color.FromArgb(239, 239, 255),

		Color.FromArgb(0, 27, 111), Color.FromArgb(0, 39, 151), Color.FromArgb(7, 51, 167), Color.FromArgb(15, 67, 187),
		Color.FromArgb(27, 83, 203), Color.FromArgb(43, 103, 223), Color.FromArgb(67, 135, 227), Color.FromArgb(91, 163, 231),
		Color.FromArgb(119, 187, 239), Color.FromArgb(143, 211, 243), Color.FromArgb(175, 231, 251), Color.FromArgb(215, 247, 255),

		Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
		Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
		Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

		Color.FromArgb(63, 0, 95), Color.FromArgb(75, 7, 115), Color.FromArgb(83, 15, 127), Color.FromArgb(95, 31, 143),
		Color.FromArgb(107, 43, 155), Color.FromArgb(123, 63, 171), Color.FromArgb(135, 83, 187), Color.FromArgb(155, 103, 199),
		Color.FromArgb(171, 127, 215), Color.FromArgb(191, 155, 231), Color.FromArgb(215, 195, 243), Color.FromArgb(243, 235, 255),

		Color.FromArgb(63, 0, 0), Color.FromArgb(87, 0, 0), Color.FromArgb(115, 0, 0), Color.FromArgb(143, 0, 0),
		Color.FromArgb(171, 0, 0), Color.FromArgb(199, 0, 0), Color.FromArgb(227, 7, 0), Color.FromArgb(255, 7, 0),
		Color.FromArgb(255, 79, 67), Color.FromArgb(255, 123, 115), Color.FromArgb(255, 171, 163), Color.FromArgb(255, 219, 215),

		Color.FromArgb(79, 39, 0), Color.FromArgb(111, 51, 0), Color.FromArgb(147, 63, 0), Color.FromArgb(183, 71, 0),
		Color.FromArgb(219, 79, 0), Color.FromArgb(255, 83, 0), Color.FromArgb(255, 111, 23), Color.FromArgb(255, 139, 51),
		Color.FromArgb(255, 163, 79), Color.FromArgb(255, 183, 107), Color.FromArgb(255, 203, 135), Color.FromArgb(255, 219, 163),

		Color.FromArgb(0, 51, 47), Color.FromArgb(0, 63, 55), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 87, 79),
		Color.FromArgb(7, 107, 99), Color.FromArgb(23, 127, 119), Color.FromArgb(43, 147, 143), Color.FromArgb(71, 167, 163),
		Color.FromArgb(99, 187, 187), Color.FromArgb(131, 207, 207), Color.FromArgb(171, 231, 231), Color.FromArgb(207, 255, 255),

		Color.FromArgb(63, 0, 27), Color.FromArgb(91, 0, 39), Color.FromArgb(119, 0, 59), Color.FromArgb(147, 7, 75),
		Color.FromArgb(179, 11, 99), Color.FromArgb(199, 31, 119), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
		Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

		Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
		Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black,
		//Color.FromArgb(255, 0, 128), Color.FromArgb(0, 128, 255), Color.FromArgb(255, 128, 0), Color.FromArgb(128, 0, 255), Color.FromArgb(128, 255, 0), Color.FromArgb(128, 0, 128), Color.FromArgb(0, 0, 128), Color.FromArgb(0, 128, 128), Color.FromArgb(0, 128, 0), Color.FromArgb(128, 128, 0),
		//Color.FromArgb(128, 0, 0), Color.FromArgb(255, 0, 255), Color.FromArgb(0, 0, 255), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 255, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(255, 0, 0),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),
		Color.Black
		//Color.FromArgb(0, 255, 128)
	});
	/** <summary> The default color palette for the game </summary> */
	public static Palette SceneryGroupPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

		Color.FromArgb(23, 35, 35), Color.FromArgb(35, 51, 51), Color.FromArgb(47, 67, 67), Color.FromArgb(63, 83, 83),
		Color.FromArgb(75, 99, 99), Color.FromArgb(91, 115, 115), Color.FromArgb(111, 131, 131), Color.FromArgb(131, 151, 151),
		Color.FromArgb(159, 175, 175), Color.FromArgb(183, 195, 195), Color.FromArgb(211, 219, 219), Color.FromArgb(239, 243, 243),

		Color.FromArgb(51, 47, 0), Color.FromArgb(63, 59, 0), Color.FromArgb(79, 75, 11), Color.FromArgb(91, 91, 19),
		Color.FromArgb(107, 107, 31), Color.FromArgb(119, 123, 47), Color.FromArgb(135, 139, 59), Color.FromArgb(151, 155, 79),
		Color.FromArgb(167, 175, 95), Color.FromArgb(187, 191, 115), Color.FromArgb(203, 207, 139), Color.FromArgb(223, 227, 163),

		Color.FromArgb(67, 43, 7), Color.FromArgb(87, 59, 11), Color.FromArgb(111, 75, 23), Color.FromArgb(127, 87, 31),
		Color.FromArgb(143, 99, 39), Color.FromArgb(159, 115, 51), Color.FromArgb(179, 131, 67), Color.FromArgb(191, 151, 87),
		Color.FromArgb(203, 175, 111), Color.FromArgb(219, 199, 135), Color.FromArgb(231, 219, 163), Color.FromArgb(247, 239, 195),

		Color.FromArgb(71, 27, 0), Color.FromArgb(95, 43, 0), Color.FromArgb(119, 63, 0), Color.FromArgb(143, 83, 7),
		Color.FromArgb(167, 111, 7), Color.FromArgb(191, 139, 15), Color.FromArgb(215, 167, 19), Color.FromArgb(243, 203, 27),
		Color.FromArgb(255, 231, 47), Color.FromArgb(255, 243, 95), Color.FromArgb(255, 251, 143), Color.FromArgb(255, 255, 195),

		Color.FromArgb(35, 0, 0), Color.FromArgb(79, 0, 0), Color.FromArgb(95, 7, 7), Color.FromArgb(111, 15, 15),
		Color.FromArgb(127, 27, 27), Color.FromArgb(143, 39, 39), Color.FromArgb(163, 59, 59), Color.FromArgb(179, 79, 79),
		Color.FromArgb(199, 103, 103), Color.FromArgb(215, 127, 127), Color.FromArgb(235, 159, 159), Color.FromArgb(255, 191, 191),

		Color.FromArgb(27, 51, 19), Color.FromArgb(35, 63, 23), Color.FromArgb(47, 79, 31), Color.FromArgb(59, 95, 39),
		Color.FromArgb(71, 111, 43), Color.FromArgb(87, 127, 51), Color.FromArgb(99, 143, 59), Color.FromArgb(115, 155, 67),
		Color.FromArgb(131, 171, 75), Color.FromArgb(147, 187, 83), Color.FromArgb(163, 203, 95), Color.FromArgb(183, 219, 103),

		Color.FromArgb(31, 55, 27), Color.FromArgb(47, 71, 35), Color.FromArgb(59, 83, 43), Color.FromArgb(75, 99, 55),
		Color.FromArgb(91, 111, 67), Color.FromArgb(111, 135, 79), Color.FromArgb(135, 159, 95), Color.FromArgb(159, 183, 111),
		Color.FromArgb(183, 207, 127), Color.FromArgb(195, 219, 147), Color.FromArgb(207, 231, 167), Color.FromArgb(223, 247, 191),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

		Color.FromArgb(79, 43, 19), Color.FromArgb(99, 55, 27), Color.FromArgb(119, 71, 43), Color.FromArgb(139, 87, 59),
		Color.FromArgb(167, 99, 67), Color.FromArgb(187, 115, 83), Color.FromArgb(207, 131, 99), Color.FromArgb(215, 151, 115),
		Color.FromArgb(227, 171, 131), Color.FromArgb(239, 191, 151), Color.FromArgb(247, 207, 171), Color.FromArgb(255, 227, 195),

		Color.FromArgb(15, 19, 55), Color.FromArgb(39, 43, 87), Color.FromArgb(51, 55, 103), Color.FromArgb(63, 67, 119),
		Color.FromArgb(83, 83, 139), Color.FromArgb(99, 99, 155), Color.FromArgb(119, 119, 175), Color.FromArgb(139, 139, 191),
		Color.FromArgb(159, 159, 207), Color.FromArgb(183, 183, 223), Color.FromArgb(211, 211, 239), Color.FromArgb(239, 239, 255),

		Color.FromArgb(0, 27, 111), Color.FromArgb(0, 39, 151), Color.FromArgb(7, 51, 167), Color.FromArgb(15, 67, 187),
		Color.FromArgb(27, 83, 203), Color.FromArgb(43, 103, 223), Color.FromArgb(67, 135, 227), Color.FromArgb(91, 163, 231),
		Color.FromArgb(119, 187, 239), Color.FromArgb(143, 211, 243), Color.FromArgb(175, 231, 251), Color.FromArgb(215, 247, 255),

		Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
		Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
		Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

		Color.FromArgb(63, 0, 95), Color.FromArgb(75, 7, 115), Color.FromArgb(83, 15, 127), Color.FromArgb(95, 31, 143),
		Color.FromArgb(107, 43, 155), Color.FromArgb(123, 63, 171), Color.FromArgb(135, 83, 187), Color.FromArgb(155, 103, 199),
		Color.FromArgb(171, 127, 215), Color.FromArgb(191, 155, 231), Color.FromArgb(215, 195, 243), Color.FromArgb(243, 235, 255),

		Color.FromArgb(63, 0, 0), Color.FromArgb(87, 0, 0), Color.FromArgb(115, 0, 0), Color.FromArgb(143, 0, 0),
		Color.FromArgb(171, 0, 0), Color.FromArgb(199, 0, 0), Color.FromArgb(227, 7, 0), Color.FromArgb(255, 7, 0),
		Color.FromArgb(255, 79, 67), Color.FromArgb(255, 123, 115), Color.FromArgb(255, 171, 163), Color.FromArgb(255, 219, 215),

		Color.FromArgb(79, 39, 0), Color.FromArgb(111, 51, 0), Color.FromArgb(147, 63, 0), Color.FromArgb(183, 71, 0),
		Color.FromArgb(219, 79, 0), Color.FromArgb(255, 83, 0), Color.FromArgb(255, 111, 23), Color.FromArgb(255, 139, 51),
		Color.FromArgb(255, 163, 79), Color.FromArgb(255, 183, 107), Color.FromArgb(255, 203, 135), Color.FromArgb(255, 219, 163),

		Color.FromArgb(0, 51, 47), Color.FromArgb(0, 63, 55), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 87, 79),
		Color.FromArgb(7, 107, 99), Color.FromArgb(23, 127, 119), Color.FromArgb(43, 147, 143), Color.FromArgb(71, 167, 163),
		Color.FromArgb(99, 187, 187), Color.FromArgb(131, 207, 207), Color.FromArgb(171, 231, 231), Color.FromArgb(207, 255, 255),

		Color.FromArgb(63, 0, 27), Color.FromArgb(103, 0, 51), Color.FromArgb(123, 11, 63), Color.FromArgb(143, 23, 79),
		Color.FromArgb(163, 31, 95), Color.FromArgb(183, 39, 111), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
		Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

		Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
		Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.FromArgb(55, 75, 75), Color.FromArgb(255, 183, 0), Color.FromArgb(255, 219, 0), Color.FromArgb(255, 255, 0),
		Color.FromArgb(7, 107, 99), Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135),
		Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203),

		Color.FromArgb(155, 227, 227), Color.FromArgb(199, 255, 255), Color.FromArgb(67, 91, 91), Color.FromArgb(83, 107, 107),
		Color.FromArgb(99, 123, 123), //Color.FromArgb(0, 0, 95), Color.FromArgb(27, 43, 139), Color.FromArgb(39, 59, 151),

		Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
		Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
		Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

		Color.White
	});
	/** <summary> The default color palette for the game </summary> */
	public static Palette DefaultPalette = new Palette(new Color[]{
		
		Color.Transparent, Color.Black, Color.Black, Color.Black, Color.Black,
		Color.Black, Color.Black, Color.Black, Color.Black, Color.Black,

		Color.FromArgb(23, 35, 35), Color.FromArgb(35, 51, 51), Color.FromArgb(47, 67, 67), Color.FromArgb(63, 83, 83),
		Color.FromArgb(75, 99, 99), Color.FromArgb(91, 115, 115), Color.FromArgb(111, 131, 131), Color.FromArgb(131, 151, 151),
		Color.FromArgb(159, 175, 175), Color.FromArgb(183, 195, 195), Color.FromArgb(211, 219, 219), Color.FromArgb(239, 243, 243),

		Color.FromArgb(51, 47, 0), Color.FromArgb(63, 59, 0), Color.FromArgb(79, 75, 11), Color.FromArgb(91, 91, 19),
		Color.FromArgb(107, 107, 31), Color.FromArgb(119, 123, 47), Color.FromArgb(135, 139, 59), Color.FromArgb(151, 155, 79),
		Color.FromArgb(167, 175, 95), Color.FromArgb(187, 191, 115), Color.FromArgb(203, 207, 139), Color.FromArgb(223, 227, 163),

		Color.FromArgb(67, 43, 7), Color.FromArgb(87, 59, 11), Color.FromArgb(111, 75, 23), Color.FromArgb(127, 87, 31),
		Color.FromArgb(143, 99, 39), Color.FromArgb(159, 115, 51), Color.FromArgb(179, 131, 67), Color.FromArgb(191, 151, 87),
		Color.FromArgb(203, 175, 111), Color.FromArgb(219, 199, 135), Color.FromArgb(231, 219, 163), Color.FromArgb(247, 239, 195),

		Color.FromArgb(71, 27, 0), Color.FromArgb(95, 43, 0), Color.FromArgb(119, 63, 0), Color.FromArgb(143, 83, 7),
		Color.FromArgb(167, 111, 7), Color.FromArgb(191, 139, 15), Color.FromArgb(215, 167, 19), Color.FromArgb(243, 203, 27),
		Color.FromArgb(255, 231, 47), Color.FromArgb(255, 243, 95), Color.FromArgb(255, 251, 143), Color.FromArgb(255, 255, 195),

		Color.FromArgb(35, 0, 0), Color.FromArgb(79, 0, 0), Color.FromArgb(95, 7, 7), Color.FromArgb(111, 15, 15),
		Color.FromArgb(127, 27, 27), Color.FromArgb(143, 39, 39), Color.FromArgb(163, 59, 59), Color.FromArgb(179, 79, 79),
		Color.FromArgb(199, 103, 103), Color.FromArgb(215, 127, 127), Color.FromArgb(235, 159, 159), Color.FromArgb(255, 191, 191),

		Color.FromArgb(27, 51, 19), Color.FromArgb(35, 63, 23), Color.FromArgb(47, 79, 31), Color.FromArgb(59, 95, 39),
		Color.FromArgb(71, 111, 43), Color.FromArgb(87, 127, 51), Color.FromArgb(99, 143, 59), Color.FromArgb(115, 155, 67),
		Color.FromArgb(131, 171, 75), Color.FromArgb(147, 187, 83), Color.FromArgb(163, 203, 95), Color.FromArgb(183, 219, 103),

		Color.FromArgb(31, 55, 27), Color.FromArgb(47, 71, 35), Color.FromArgb(59, 83, 43), Color.FromArgb(75, 99, 55),
		Color.FromArgb(91, 111, 67), Color.FromArgb(111, 135, 79), Color.FromArgb(135, 159, 95), Color.FromArgb(159, 183, 111),
		Color.FromArgb(183, 207, 127), Color.FromArgb(195, 219, 147), Color.FromArgb(207, 231, 167), Color.FromArgb(223, 247, 191),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

		Color.FromArgb(79, 43, 19), Color.FromArgb(99, 55, 27), Color.FromArgb(119, 71, 43), Color.FromArgb(139, 87, 59),
		Color.FromArgb(167, 99, 67), Color.FromArgb(187, 115, 83), Color.FromArgb(207, 131, 99), Color.FromArgb(215, 151, 115),
		Color.FromArgb(227, 171, 131), Color.FromArgb(239, 191, 151), Color.FromArgb(247, 207, 171), Color.FromArgb(255, 227, 195),

		Color.FromArgb(15, 19, 55), Color.FromArgb(39, 43, 87), Color.FromArgb(51, 55, 103), Color.FromArgb(63, 67, 119),
		Color.FromArgb(83, 83, 139), Color.FromArgb(99, 99, 155), Color.FromArgb(119, 119, 175), Color.FromArgb(139, 139, 191),
		Color.FromArgb(159, 159, 207), Color.FromArgb(183, 183, 223), Color.FromArgb(211, 211, 239), Color.FromArgb(239, 239, 255),

		Color.FromArgb(0, 27, 111), Color.FromArgb(0, 39, 151), Color.FromArgb(7, 51, 167), Color.FromArgb(15, 67, 187),
		Color.FromArgb(27, 83, 203), Color.FromArgb(43, 103, 223), Color.FromArgb(67, 135, 227), Color.FromArgb(91, 163, 231),
		Color.FromArgb(119, 187, 239), Color.FromArgb(143, 211, 243), Color.FromArgb(175, 231, 251), Color.FromArgb(215, 247, 255),

		Color.FromArgb(11, 43, 15), Color.FromArgb(15, 55, 23), Color.FromArgb(23, 71, 31), Color.FromArgb(35, 83, 43),
		Color.FromArgb(47, 99, 59), Color.FromArgb(59, 115, 75), Color.FromArgb(79, 135, 95), Color.FromArgb(99, 155, 119),
		Color.FromArgb(123, 175, 139), Color.FromArgb(147, 199, 167), Color.FromArgb(175, 219, 195), Color.FromArgb(207, 243, 223),

		Color.FromArgb(63, 0, 95), Color.FromArgb(75, 7, 115), Color.FromArgb(83, 15, 127), Color.FromArgb(95, 31, 143),
		Color.FromArgb(107, 43, 155), Color.FromArgb(123, 63, 171), Color.FromArgb(135, 83, 187), Color.FromArgb(155, 103, 199),
		Color.FromArgb(171, 127, 215), Color.FromArgb(191, 155, 231), Color.FromArgb(215, 195, 243), Color.FromArgb(243, 235, 255),

		Color.FromArgb(63, 0, 0), Color.FromArgb(87, 0, 0), Color.FromArgb(115, 0, 0), Color.FromArgb(143, 0, 0),
		Color.FromArgb(171, 0, 0), Color.FromArgb(199, 0, 0), Color.FromArgb(227, 7, 0), Color.FromArgb(255, 7, 0),
		Color.FromArgb(255, 79, 67), Color.FromArgb(255, 123, 115), Color.FromArgb(255, 171, 163), Color.FromArgb(255, 219, 215),

		Color.FromArgb(79, 39, 0), Color.FromArgb(111, 51, 0), Color.FromArgb(147, 63, 0), Color.FromArgb(183, 71, 0),
		Color.FromArgb(219, 79, 0), Color.FromArgb(255, 83, 0), Color.FromArgb(255, 111, 23), Color.FromArgb(255, 139, 51),
		Color.FromArgb(255, 163, 79), Color.FromArgb(255, 183, 107), Color.FromArgb(255, 203, 135), Color.FromArgb(255, 219, 163),

		Color.FromArgb(0, 51, 47), Color.FromArgb(0, 63, 55), Color.FromArgb(0, 75, 67), Color.FromArgb(0, 87, 79),
		Color.FromArgb(7, 107, 99), Color.FromArgb(23, 127, 119), Color.FromArgb(43, 147, 143), Color.FromArgb(71, 167, 163),
		Color.FromArgb(99, 187, 187), Color.FromArgb(131, 207, 207), Color.FromArgb(171, 231, 231), Color.FromArgb(207, 255, 255),

		Color.FromArgb(63, 0, 27), Color.FromArgb(103, 0, 51), Color.FromArgb(123, 11, 63), Color.FromArgb(143, 23, 79),
		Color.FromArgb(163, 31, 95), Color.FromArgb(183, 39, 111), Color.FromArgb(219, 59, 143), Color.FromArgb(239, 91, 171),
		Color.FromArgb(243, 119, 187), Color.FromArgb(247, 151, 203), Color.FromArgb(251, 183, 223), Color.FromArgb(255, 215, 239),

		Color.FromArgb(39, 19, 0), Color.FromArgb(55, 31, 7), Color.FromArgb(71, 47, 15), Color.FromArgb(91, 63, 31),
		Color.FromArgb(107, 83, 51), Color.FromArgb(123, 103, 75), Color.FromArgb(143, 127, 107), Color.FromArgb(163, 147, 127),
		Color.FromArgb(187, 171, 147), Color.FromArgb(207, 195, 171), Color.FromArgb(231, 219, 195), Color.FromArgb(255, 243, 223),

		Color.FromArgb(55, 75, 75), Color.FromArgb(255, 183, 0), Color.FromArgb(255, 219, 0), Color.FromArgb(255, 255, 0),
		Color.FromArgb(7, 107, 99), Color.FromArgb(15, 119, 111), Color.FromArgb(27, 131, 123), Color.FromArgb(39, 143, 135),
		Color.FromArgb(55, 155, 151), Color.FromArgb(55, 155, 151), Color.FromArgb(83, 179, 175), Color.FromArgb(115, 203, 203),

		Color.FromArgb(155, 227, 227), Color.FromArgb(199, 255, 255), Color.FromArgb(67, 91, 91), Color.FromArgb(83, 107, 107),
		Color.FromArgb(99, 123, 123), //Color.FromArgb(0, 0, 95), Color.FromArgb(27, 43, 139), Color.FromArgb(39, 59, 151),

		Color.FromArgb(15, 63, 0), Color.FromArgb(19, 83, 0), Color.FromArgb(23, 103, 0), Color.FromArgb(31, 123, 0),
		Color.FromArgb(39, 143, 7), Color.FromArgb(55, 159, 23), Color.FromArgb(71, 175, 39), Color.FromArgb(91, 191, 63),
		Color.FromArgb(111, 207, 87), Color.FromArgb(139, 223, 115), Color.FromArgb(163, 239, 143), Color.FromArgb(195, 255, 179),

		Color.White
	});

	#endregion
	//=========== MEMBERS ============
	#region Members

	/** <summary> The image entry of the palette. </summary> */
	internal ImageEntry entry;
	/** <summary> The list of colors in the palette. </summary> */
	internal Color[] colors;

	#endregion
	//========= CONSTRUCTORS =========
	#region Constructors

	/** <summary> Constructs the default palette. </summary> */
	public Palette() {
		this.colors			= new Color[1];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.PaletteEntries;
		this.entry.Width	= 1;
		this.entry.Height	= 0;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette with the specified number of colors. </summary> */
	public Palette(int numColors) {
		this.colors			= new Color[numColors];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.PaletteEntries;
		this.entry.Width	= (short)numColors;
		this.entry.Height	= 0;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette with the specified number of colors and offset. </summary> */
	public Palette(int numColors, int offset) {
		this.colors			= new Color[numColors];
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.PaletteEntries;
		this.entry.Width	= (short)numColors;
		this.entry.Height	= 0;
		this.entry.XOffset	= (short)offset;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette with the specified colors. </summary> */
	public Palette(Color[] colors) {
		this.colors			= colors;
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.PaletteEntries;
		this.entry.Width	= (short)colors.Length;
		this.entry.Height	= 0;
		this.entry.XOffset	= 0;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette with the specified colors and offset. </summary> */
	public Palette(Color[] colors, int offset) {
		this.colors			= colors;
		this.entry			= new ImageEntry();
		this.entry.Flags	= ImageFlags.PaletteEntries;
		this.entry.Width	= (short)colors.Length;
		this.entry.Height	= 0;
		this.entry.XOffset	= (short)offset;
		this.entry.YOffset	= 0;
	}
	/** <summary> Constructs a palette with the specified image entry. </summary> */
	internal Palette(ImageEntry entry) {
		this.colors			= new Color[entry.Width];
		this.entry			= entry;
	}

	#endregion
	//========== PROPERTIES ==========
	#region Properties

	/** <summary> Gets the list of colors in the palette. </summary> */
	public Color[] Colors {
		get { return this.colors; }
	}
	/** <summary> Gets the number of colors in the palette. </summary> */
	public int NumColors {
		get { return this.colors.Length; }
	}
	/** <summary> Gets or sets the offset of the palette. </summary> */
	public int Offset {
		get { return this.entry.XOffset; }
		set { this.entry.XOffset = (short)value; }
	}

	#endregion
	//=========== DRAWING ============
	#region Drawing

	/** <summary> Draws the palette into the specified graphics. </summary> */
	public void Draw(Graphics g, int x, int y, int colorWidth, int colorHeight) {
		for (int i = 0; i < colors.Length; i++) {
			Brush brush = new SolidBrush(colors[i]);
			g.FillRectangle(brush, new Rectangle(
				x + ((i + entry.XOffset) % 16) * colorWidth,
				y + ((i + entry.XOffset) / 16) * colorHeight,
				colorWidth, colorHeight));
			brush.Dispose();
		}
	}
	/** <summary> Draws the palette into the specified graphics. </summary> */
	public void Draw(Graphics g, Point point, Size colorSize) {
		for (int i = 0; i < colors.Length; i++) {
			Brush brush = new SolidBrush(colors[i]);
			g.FillRectangle(brush, new Rectangle(
				point.X + ((i + entry.XOffset) % 16) * colorSize.Width,
				point.Y + ((i + entry.XOffset) / 16) * colorSize.Height,
				colorSize.Width, colorSize.Height));
			brush.Dispose();
		}
	}
	/** <summary> Creates a bitmap from the specified palette. </summary> */
	public Bitmap CreateImage(Size colorSize) {
		Bitmap image = new Bitmap(colorSize.Width * 16, colorSize.Height * 16);
		Graphics g = Graphics.FromImage(image);
		g.Clear(Color.Transparent);
		for (int i = 0; i < colors.Length; i++) {
			Brush brush = new SolidBrush(colors[i]);
			g.FillRectangle(brush, new Rectangle(
				((i + entry.XOffset) % 16) * colorSize.Width,
				((i + entry.XOffset) / 16) * colorSize.Height,
				colorSize.Width, colorSize.Height));
			brush.Dispose();
		}
		return image;
	}

	/** <summary> Draws the palette into the specified palette image. </summary> */
	public void Draw(PaletteImage p, int x, int y, int colorWidth, int colorHeight) {
		for (int i = 0; i < colors.Length; i++) {
			int x2 = ((i + entry.XOffset) % 16) * colorWidth;
			int y2 = ((i + entry.XOffset) / 16) * colorHeight;
			for (int x1 = 0; x1 < colorWidth; x1++) {
				for (int y1 = 0; y1 < colorHeight; y1++) {
					if (x + x1 + x2 >= 0 && y + y1 + y2 >= 0 && x + x1 + x2 < p.Width && y + y1 + y2 < p.Height) {
						p.pixels[x + x1 + x2, y + y1 + y2] = (byte)(i + entry.XOffset);
					}
				}
			}
		}
	}
	/** <summary> Draws the palette into the specified palette image. </summary> */
	public void Draw(PaletteImage p, Point point, Size colorSize) {
		for (int i = 0; i < colors.Length; i++) {
			int x2 = ((i + entry.XOffset) % 16) * colorSize.Width;
			int y2 = ((i + entry.XOffset) / 16) * colorSize.Height;
			for (int x1 = 0; x1 < colorSize.Width; x1++) {
				for (int y1 = 0; y1 < colorSize.Height; y1++) {
					if (point.X + x1 + x2 >= 0 && point.Y + y1 + y2 >= 0 && point.X + x1 + x2 < p.Width && point.Y + y1 + y2 < p.Height) {
						p.pixels[point.X + x1 + x2, point.Y + y1 + y2] = (byte)(i + entry.XOffset);
					}
				}
			}
		}
	}

	#endregion
	//=========== READING ============
	#region Reading

	/** <summary> Saves the palette to the specified file path. </summary> */
	public void Save(string path) {
		BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);
		graphicsData.Add(this);

		long imageDirectoryPosition = writer.BaseStream.Position;
		imageDirectory.Write(writer);
		graphicsData.Write(writer);
		writer.BaseStream.Position = imageDirectoryPosition;
		imageDirectory.Write(writer);

		writer.Close();
	}

	/** <summary> Returns a palette loaded from the specified stream. </summary> */
	public static Palette FromStream(Stream stream) {
		BinaryReader reader = new BinaryReader(stream);
		ImageDirectory imageDirectory = new ImageDirectory();
		GraphicsData graphicsData = new GraphicsData(imageDirectory);
		imageDirectory.Read(reader);
		graphicsData.Read(reader);
		reader.Close();
		return graphicsData.GetPalette(0);
	}
	/** <summary> Returns a palette loaded from the specified buffer. </summary> */
	public static Palette FromBuffer(byte[] buffer) {
		return FromStream(new MemoryStream(buffer));
	}
	/** <summary> Returns a palette loaded from the specified file. </summary> */
	public static Palette FromFile(string path) {
		return FromStream(new FileStream(path, FileMode.Open, FileAccess.Read));
	}

	#endregion
}
}
