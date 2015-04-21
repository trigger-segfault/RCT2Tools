using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2ObjectData.DataObjects.Types.AttractionInfo {
/** <summary> The different types of entrance visuals available for rides. </summary> */
public enum EntranceTypes : byte {
	Normal = 0x00,
	Wooden = 0x01,
	Canvas = 0x02,
	CastleGray = 0x03,
	CastleBrown = 0x04,
	Jungle = 0x05,
	LogCabin = 0x06,
	Classical = 0x07,
	Abstract = 0x08,
	Snow = 0x09,
	Pagoda = 0x0A,
	Space = 0x0B
}
}
