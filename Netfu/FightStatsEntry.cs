using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200008C RID: 140
	public class FightStatsEntry
	{
		// Token: 0x06000309 RID: 777 RVA: 0x00017BF0 File Offset: 0x00015DF0
		public FightStatsEntry(string data, Perso p)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<string>();
			this.win = false;
			this.end = DateTime.Now;
			string[] array = data.Split(new char[]
			{
				'|'
			});
			checked
			{
				try
				{
					if (Conversions.ToDouble(array[2]) == 0.0)
					{
						this.duration = Conversions.ToInteger(array[0]);
						int num = array.Count<string>() - 1;
						for (int i = 3; i <= num; i++)
						{
							string[] array2 = array[i].Split(new char[]
							{
								';'
							});
							if (!this.win)
							{
								this.win = (Conversions.ToDouble(array2[4]) == 0.0 && Conversions.ToDouble(array2[1]) > 0.0);
							}
							if (Operators.CompareString(p.monIdDofus, array2[1], false) == 0)
							{
								this.expWin = Conversions.ToULong(array2[8]);
								this.kamas = ((array2.Length > 12) ? (Versioned.IsNumeric(array2[12]) ? int.Parse(array2[12]) : 0) : 0);
								if (array2[11].Length > 2)
								{
									string[] array3 = array2[11].Split(new char[]
									{
										','
									});
									foreach (string text in array3)
									{
										ref string ptr = ref this.string_0;
										this.string_0 = string.Concat(new string[]
										{
											ptr,
											Loader.getItemById(Conversions.ToInteger(text.Split(new char[]
											{
												'~'
											})[0])).nom,
											" x ",
											text.Split(new char[]
											{
												'~'
											})[1],
											"  "
										});
									}
								}
							}
							if (Conversions.ToDouble(array2[1]) < 0.0)
							{
								if (Information.IsNothing(this.list_0))
								{
									this.list_0 = new List<string>();
								}
								this.list_0.Add(Loader.getMonsterById(Conversions.ToInteger(array2[2])).nom);
							}
						}
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			}
		}

		// Token: 0x0400039F RID: 927
		public int duration;

		// Token: 0x040003A0 RID: 928
		private List<string> list_0;

		// Token: 0x040003A1 RID: 929
		private string string_0;

		// Token: 0x040003A2 RID: 930
		public int kamas;

		// Token: 0x040003A3 RID: 931
		public ulong expWin;

		// Token: 0x040003A4 RID: 932
		public bool win;

		// Token: 0x040003A5 RID: 933
		public DateTime end;
	}
}
