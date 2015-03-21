using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTDataEditor.DataObjects.Types.AttractionInfo {
/** <summary> The different types of items. </summary> */
public enum ItemTypes : byte {

	//=========== GENERAL ============
	#region General

	/** <summary> No item type is set. </summary> */
	None = 0xFF,

	#endregion
	//============= FOOD =============
	#region Food

	Burger = 0x06,
	Fries = 0x07,
	IceCream = 0x08,
	CottonCandy = 0x09,
	Pizza = 0x0D,
	Popcorn = 0x0F,
	Hotdog = 0x10,
	Seafood = 0x11,
	CandyApple = 0x13,
	Donut = 0x15,
	Chicken = 0x18,
	Pretzel = 0x23,
	FunnelCake = 0x26,
	BeefNoodles = 0x28,
	FriedNoodles = 0x29,
	WontonSoup = 0x2A,
	MeatballSoup = 0x2B,
	SubSandwich = 0x2F,
	Cookies = 0x30,
	RoastSausage = 0x34,

	#endregion
	//============ DRINKS ============
	#region Drinks

	Cola = 0x05,
	Coffee = 0x16,
	Lemonade = 0x19,
	HotChocolate = 0x24,
	IcedTea = 0x25,
	FruitJuice = 0x2C,
	SoybeanMilk = 0x2D,
	Sujongkwa = 0x2E,

	#endregion
	//========== SOUVENIRS ===========
	#region Souvenirs

	Balloon = 0x00,
	PlushToy = 0x01,
	Map = 0x02,
	OnRidePhoto = 0x03,
	Umbrella = 0x04,
	Voucher = 0x0E,
	Hat = 0x12,
	TShirt = 0x14,
	Sunglasses = 0x27,

	#endregion
	//============ TRASH =============
	#region Trash

	EmptyCan = 0x0A,
	Rubbish = 0x0B,
	EmptyBurgerBox = 0x0C,
	EmptyCup = 0x17,
	EmptyBox = 0x1A,
	EmptyBottle = 0x1B,
	EmptyBowl = 0x31,
	EmptyDrinkCarton = 0x32,
	EmptyJuiceCup = 0x33,
	EmptyBowl2 = 0x35

	#endregion
}
/** <summary> The different types of food items. </summary> */
public enum FoodItemTypes : byte {
	/** <summary> No item type is set. </summary> */
	None = 0xFF,

	Burger = 0x06,
	Fries = 0x07,
	IceCream = 0x08,
	CottonCandy = 0x09,
	Pizza = 0x0D,
	Popcorn = 0x0F,
	Hotdog = 0x10,
	Seafood = 0x11,
	CandyApple = 0x13,
	Donut = 0x15,
	Chicken = 0x18,
	Pretzel = 0x23,
	FunnelCake = 0x26,
	BeefNoodles = 0x28,
	FriedNoodles = 0x29,
	WontonSoup = 0x2A,
	MeatballSoup = 0x2B,
	SubSandwich = 0x2F,
	Cookies = 0x30,
	RoastSausage = 0x34
}
/** <summary> The different types of drink items. </summary> */
public enum DrinkItemTypes : byte {
	/** <summary> No item type is set. </summary> */
	None = 0xFF,

	Cola = 0x05,
	Coffee = 0x16,
	Lemonade = 0x19,
	IcedTea = 0x25,
	FruitJuice = 0x2C,
	SoybeanMilk = 0x2D,
	Sujongkwa = 0x2E
}
/** <summary> The different types of souvenir items. </summary> */
public enum SouvenirItemTypes : byte {
	/** <summary> No item type is set. </summary> */
	None = 0xFF,

	Balloon = 0x00,
	PlushToy = 0x01,
	Map = 0x02,
	OnRidePhoto = 0x03,
	Umbrella = 0x04,
	Voucher = 0x0E,
	Hat = 0x12,
	TShirt = 0x14,
	Sunglasses = 0x27
}
/** <summary> The different types of garbage items. </summary> */
public enum GarbageItemTypes : byte {
	/** <summary> No item type is set. </summary> */
	None = 0xFF,

	EmptyCan = 0x0A,
	Rubbish = 0x0B,
	EmptyBurgerBox = 0x0C,
	EmptyCup = 0x17,
	EmptyBox = 0x1A,
	EmptyBottle = 0x1B,
	EmptyBowl = 0x31,
	EmptyDrinkCarton = 0x32,
	EmptyJuiceCup = 0x33,
	EmptyBowl2 = 0x35
}
}
