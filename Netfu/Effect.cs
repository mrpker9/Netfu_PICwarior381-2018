using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000057 RID: 87
	public class Effect
	{
		// Token: 0x060001CD RID: 461 RVA: 0x0000F87C File Offset: 0x0000DA7C
		public Effect(string otherdate, bool fromGame = false)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			if (!fromGame)
			{
				string[] array = otherdate.Split(new char[]
				{
					';'
				});
				if (Operators.CompareString(array[0], "null", false) == 0)
				{
					this.id = EffectIDEnum.None;
				}
				else
				{
					this.id = (EffectIDEnum)Conversions.ToInteger(array[0]);
				}
				if (Operators.CompareString(array[1], "null", false) == 0)
				{
					this.min = -1;
				}
				else
				{
					this.min = array[1];
				}
				if (Operators.CompareString(array[2], "null", false) == 0)
				{
					this.max = -1;
				}
				else
				{
					this.max = array[2];
				}
				if (Operators.CompareString(array[3], "null", false) == 0)
				{
					this.etat = -1;
				}
				else
				{
					this.etat = array[3];
				}
				if (Operators.CompareString(array[4], "null", false) == 0)
				{
					this.duree = 0;
				}
				else
				{
					this.duree = array[4];
				}
				if (Operators.CompareString(array[5], "null", false) == 0)
				{
					this.chance = 0;
				}
				else
				{
					this.chance = array[5];
				}
				if (array.Length > 6)
				{
					this.jet = array[6];
				}
			}
			else
			{
				string[] array2 = otherdate.Split(new char[]
				{
					'#'
				});
				try
				{
					if (array2.Length < 1)
					{
						this.id = EffectIDEnum.None;
					}
					else
					{
						this.id = (EffectIDEnum)Convert.ToInt32(array2[0], 16);
					}
					if (array2.Length < 2)
					{
						this.min = -1;
					}
					else
					{
						this.min = array2[1];
					}
					if (array2.Length < 3)
					{
						this.max = -1;
					}
					else
					{
						this.max = array2[2];
					}
					if (array2.Length < 4)
					{
						this.etat = -1;
					}
					else
					{
						this.etat = array2[3];
					}
					if (array2.Length < 5)
					{
						this.duree = 0;
					}
					else
					{
						this.duree = array2[4];
					}
					if (array2.Length < 6)
					{
						this.chance = 0;
					}
					else
					{
						this.chance = array2[5];
					}
					if (array2.Length > 6)
					{
						this.jet = array2[6];
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			}
		}

		// Token: 0x04000182 RID: 386
		public EffectIDEnum id;

		// Token: 0x04000183 RID: 387
		public object min;

		// Token: 0x04000184 RID: 388
		public object max;

		// Token: 0x04000185 RID: 389
		public object jet;

		// Token: 0x04000186 RID: 390
		public object duree;

		// Token: 0x04000187 RID: 391
		public object chance;

		// Token: 0x04000188 RID: 392
		public object etat;
	}
}
