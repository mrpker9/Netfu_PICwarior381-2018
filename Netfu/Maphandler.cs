using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000B7 RID: 183
	[StandardModule]
	public sealed class Maphandler
	{
		// Token: 0x060003D9 RID: 985 RVA: 0x0001DE34 File Offset: 0x0001C034
		public static Cell uncompressCell(int id, string sData, Maps map, bool bforced = false)
		{
			Cell cell = new Cell(id, map, 0);
			cell.Id = id;
			checked
			{
				int i = sData.Length - 1;
				int[] array = new int[5001];
				while (i >= 0)
				{
					array[i] = Conversions.ToInteger(Fonctions.hashCodes(Conversions.ToString(sData[i])));
					i--;
				}
				cell.bool_0 = (~((array[0] & 32) >> 5) == 0);
				if (cell.bool_0 || bforced)
				{
					cell.bool_5 = ((array[0] & 1) != 0);
					cell.int_1 = (array[1] & 48) >> 4;
					cell.int_2 = (array[1] & 15);
					cell.movement = (array[2] & 56) >> 3;
					cell.int_3 = ((array[0] & 24) << 6) + ((array[2] & 7) << 6) + array[3];
					cell.int_4 = (array[4] & 60) >> 2;
					cell.bool_1 = (~((array[4] & 2) >> 1) == 0);
					cell.int_5 = ((array[0] & 4) << 11) + ((array[4] & 1) << 12) + (array[5] << 6) + array[6];
					cell.int_6 = (array[7] & 48) >> 4;
					cell.bool_2 = (~((array[7] & 8) >> 3) == 0);
					cell.bool_3 = (~((array[7] & 4) >> 2) == 0);
					cell.layerObject2Interactive = (~((array[7] & 2) >> 1) == 0);
					cell.layerObject2Num = ((array[0] & 2) << 12) + ((array[7] & 1) << 12) + (array[8] << 6) + array[9];
					cell.string_0 = "";
					cell.bool_4 = false;
				}
				return cell;
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001DFD8 File Offset: 0x0001C1D8
		public static List<Cell> uncompressMap(string sData, Maps map)
		{
			List<Cell> list = new List<Cell>();
			int length = sData.Length;
			int num = 0;
			int num2 = 0;
			checked
			{
				while (num2 + 10 <= length)
				{
					Cell item = Maphandler.uncompressCell(num, sData.Substring(num2, 10), map, true);
					num2 += 10;
					num++;
					list.Add(item);
				}
				return list;
			}
		}
	}
}
