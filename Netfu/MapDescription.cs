using System;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200004D RID: 77
	public class MapDescription
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x0000DF08 File Offset: 0x0000C108
		public MapDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.point = default(Point);
			this.id = Conversions.ToInteger(v.Substring(0, v.IndexOf("=")));
			checked
			{
				v = v.Substring(v.IndexOf("{") + 1);
				v = v.Substring(0, v.IndexOf("}"));
				string[] array = v.Split(new char[]
				{
					','
				});
				int num = array.Count<string>() - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = array[i].Substring(0, array[i].IndexOf(":"));
					string value = array[i].Replace(text + ":", "").Replace("\"", "");
					if (Operators.CompareString(text, "x", false) != 0)
					{
						if (Operators.CompareString(text, "y", false) != 0)
						{
							if (Operators.CompareString(text, "sa", false) != 0)
							{
								if (Operators.CompareString(text, "p", false) == 0)
								{
									break;
								}
							}
							else
							{
								this.subarea = Conversions.ToShort(value);
							}
						}
						else
						{
							this.point.Y = Conversions.ToInteger(value);
						}
					}
					else
					{
						this.point.X = Conversions.ToInteger(value);
					}
				}
			}
		}

		// Token: 0x04000140 RID: 320
		public Point point;

		// Token: 0x04000141 RID: 321
		public int id;

		// Token: 0x04000142 RID: 322
		public short subarea;
	}
}
