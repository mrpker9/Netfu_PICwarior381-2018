using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000E6 RID: 230
	public class InfoPerso
	{
		// Token: 0x0600049C RID: 1180 RVA: 0x0002479C File Offset: 0x0002299C
		private Perso method_0()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00004744 File Offset: 0x00002944
		public InfoPerso()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Statistique = new Dictionary<string, InfoPerso.Stats>();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x000247B8 File Offset: 0x000229B8
		public InfoPerso(int index, string packet)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Statistique = new Dictionary<string, InfoPerso.Stats>();
			this.index = index;
			this.method_0().Send(new Message("BD", 0, false, false, true));
			string[] array = packet.Split(new char[]
			{
				'|'
			});
			string[] array2 = array[0].Split(new char[]
			{
				','
			});
			this.XP = Conversions.ToDouble(array2[0]);
			this.XPlow = Conversions.ToDouble(array2[1]);
			this.XPhigh = Conversions.ToDouble(array2[2]);
			this.Kamas = Conversions.ToInteger(array[1]);
			this.BonusPoints = Conversions.ToShort(array[2]);
			this.BonusPointsSpell = Conversions.ToShort(array[3]);
			array2 = array[4].Split(new char[]
			{
				','
			});
			if (array2[0].IndexOf("~") != 0)
			{
				string[] array3 = array2[0].Split(new char[]
				{
					'~'
				});
				this.haveFakeAlignment = (Operators.CompareString(array3[0], array3[1], false) != 0);
				array2[0] = array3[0];
				Conversions.ToInteger(array3[1]);
			}
			this.alignment = array2[0] + " " + array2[1];
			if (Operators.CompareString(array2[5], "1", false) == 0)
			{
			}
			array2 = array[5].Split(new char[]
			{
				','
			});
			this.LP = Conversions.ToInteger(array2[0]);
			this.LPmax = Conversions.ToInteger(array2[1]);
			array2 = array[6].Split(new char[]
			{
				','
			});
			this.Energy = array2[0];
			this.EnergyMax = array2[1];
			this.Initiative = array[7];
			this.Discernment = array[8];
			List<int>[] array4 = new List<int>[5];
			checked
			{
				for (int i = 3; i > -1; i--)
				{
					array4[i] = new List<int>();
				}
				for (int j = 9; j < 51; j++)
				{
					array2 = array[j].Split(new char[]
					{
						','
					});
					switch (j)
					{
					case 9:
						this.Statistique.Add("pa", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), Conversions.ToInteger(array2[4])));
						break;
					case 10:
						this.Statistique.Add("pm", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), Conversions.ToInteger(array2[4])));
						break;
					case 11:
						this.Statistique.Add("terre", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 12:
						this.Statistique.Add("vie", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 13:
						this.Statistique.Add("sagesse", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 14:
						this.Statistique.Add("eau", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 15:
						this.Statistique.Add("air", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 16:
						this.Statistique.Add("feu", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 17:
						this.Statistique.Add("porte", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					case 18:
						this.Statistique.Add("invoc", new InfoPerso.Stats(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), 0));
						break;
					}
				}
			}
		}

		// Token: 0x04000509 RID: 1289
		public int Kamas;

		// Token: 0x0400050A RID: 1290
		public int index;

		// Token: 0x0400050B RID: 1291
		public double XP;

		// Token: 0x0400050C RID: 1292
		public double XPlow;

		// Token: 0x0400050D RID: 1293
		public double XPhigh;

		// Token: 0x0400050E RID: 1294
		public short BonusPoints;

		// Token: 0x0400050F RID: 1295
		public short BonusPointsSpell;

		// Token: 0x04000510 RID: 1296
		public bool haveFakeAlignment;

		// Token: 0x04000511 RID: 1297
		public int LPmax;

		// Token: 0x04000512 RID: 1298
		public int LP;

		// Token: 0x04000513 RID: 1299
		public string Discernment;

		// Token: 0x04000514 RID: 1300
		public string Initiative;

		// Token: 0x04000515 RID: 1301
		public string EnergyMax;

		// Token: 0x04000516 RID: 1302
		public string Energy;

		// Token: 0x04000517 RID: 1303
		public string alignment;

		// Token: 0x04000518 RID: 1304
		public Dictionary<string, InfoPerso.Stats> Statistique;

		// Token: 0x020000E7 RID: 231
		public class Stats
		{
			// Token: 0x0600049F RID: 1183 RVA: 0x0000475C File Offset: 0x0000295C
			public Stats(int @base, int equip, int dons, int boost, int total)
			{
				Class15.XRATSHnz66atd();
				base..ctor();
				this.@base = @base;
				this.equipe = equip;
				this.dons = dons;
				this.boost = boost;
				this.total = total;
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00024C40 File Offset: 0x00022E40
			public int current
			{
				get
				{
					return checked(this.@base + this.equipe + this.boost + this.dons);
				}
			}

			// Token: 0x04000519 RID: 1305
			public int @base;

			// Token: 0x0400051A RID: 1306
			public int boost;

			// Token: 0x0400051B RID: 1307
			public int total;

			// Token: 0x0400051C RID: 1308
			public int equipe;

			// Token: 0x0400051D RID: 1309
			public int dons;
		}
	}
}
