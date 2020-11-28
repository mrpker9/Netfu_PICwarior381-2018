using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000BB RID: 187
	public class Path
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00002744 File Offset: 0x00000944
		public Path()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0001E1B4 File Offset: 0x0001C3B4
		public static string getPath(List<Cell> pathCell, int pm, Maps map)
		{
			string text = "";
			int num = 0;
			checked
			{
				int num2 = pathCell.Count - 2;
				for (int i = 0; i <= num2; i++)
				{
					num++;
					if (num > pm)
					{
						return text;
					}
					int id = pathCell[i].Id;
					int id2 = pathCell[i + 1].Id;
					text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(Path.getOrientation(id, id2, map), Declarations.cases[id2])));
				}
				return Path.smethod_0(text);
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0001E238 File Offset: 0x0001C438
		private static string smethod_0(string string_0)
		{
			string text = "";
			checked
			{
				if (string_0.Length > 3)
				{
					int length = string_0.Length;
					for (int i = 1; i <= length; i += 3)
					{
						if (Operators.CompareString(Strings.Mid(string_0, i, 1), Strings.Mid(string_0, i + 3, 1), false) != 0)
						{
							text += Strings.Mid(string_0, i, 3);
						}
					}
				}
				else
				{
					text = string_0;
				}
				return text;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001E29C File Offset: 0x0001C49C
		public static object getOrientation(int cell1, int cell2, Maps map)
		{
			checked
			{
				int num = cell2 - cell1;
				object result;
				if (num == (int)(0 - (map.width * 2 - 1)))
				{
					result = "g";
				}
				else if (num == (int)(map.width * 2 - 1))
				{
					result = "c";
				}
				else if (num == -1)
				{
					result = "e";
				}
				else if (num == 1)
				{
					result = "a";
				}
				else if (num == (int)((short)unchecked(-(short)map.width)))
				{
					result = "f";
				}
				else if (num == (int)map.width)
				{
					result = "b";
				}
				else if (num == (int)(0 - (map.width - 1)))
				{
					result = "h";
				}
				else if (num == (int)(map.width - 1))
				{
					result = "d";
				}
				else
				{
					result = "a";
				}
				return result;
			}
		}
	}
}
