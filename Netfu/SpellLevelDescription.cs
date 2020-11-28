using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000053 RID: 83
	public class SpellLevelDescription
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x0000EC54 File Offset: 0x0000CE54
		public SpellLevelDescription(string otherdate)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.listEffectCC = new List<Effect>();
			this.listEffect = new List<Effect>();
			this.string_0 = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g"
			};
			int num = otherdate.LastIndexOf("]];");
			checked
			{
				string text;
				if (num != -1)
				{
					text = otherdate.Substring(num + 3);
				}
				else
				{
					text = otherdate.Substring(4);
				}
				text = text.Substring(0, text.Length - 1);
				string[] array = text.Split(new char[]
				{
					';'
				});
				int num2 = 0;
				if (Operators.CompareString(array[0], "null", false) == 0)
				{
					num2 = 1;
				}
				this.pa = Conversions.ToShort(array[0 + num2]);
				this.porteMin = Conversions.ToInteger(array[1 + num2]);
				this.porteMax = Conversions.ToInteger(array[2 + num2]);
				this.probaCC = Conversions.ToShort(array[3 + num2]);
				this.probaEC = Conversions.ToShort(array[4 + num2]);
				this.lancerligne = Conversions.ToBoolean(array[5 + num2]);
				this.lignedevue = Conversions.ToBoolean(array[6 + num2]);
				this.cellulevide = Conversions.ToBoolean(array[7 + num2]);
				this.porteModif = Conversions.ToBoolean(array[8 + num2]);
				this.type = Conversions.ToByte(array[9 + num2]);
				this.nbLancerTour = Conversions.ToShort(array[10 + num2]);
				this.nbLancerCible = Conversions.ToShort(array[11 + num2]);
				this.interval = Conversions.ToShort(array[12 + num2]);
				this.impactZone = array[13 + num2];
				this.level = Conversions.ToByte(array[array.Length - 2]);
				this.ecfindetour = Conversions.ToBoolean(array[array.Length - 1]);
				string text2 = otherdate.Substring(1);
				text2 = text2.Substring(0, num + 2);
				int num3 = text2.IndexOf("]];[[");
				string[] array2;
				string[] array3;
				if (num3 != -1)
				{
					array2 = text2.Substring(0, num3 + 2).Replace("[[", "").Replace("]]", "").Replace("];[", "|").Split(new char[]
					{
						'|'
					});
					array3 = text2.Substring(num3 + 3).Replace("[[", "").Replace("]]", "").Replace("];[", "|").Split(new char[]
					{
						'|'
					});
				}
				else if (text2.Length > 5)
				{
					array2 = text2.Replace("[[", "").Replace("]]", "").Replace("];[", "|").Split(new char[]
					{
						'|'
					});
					array3 = null;
				}
				if (!Information.IsNothing(array3))
				{
					foreach (string otherdate2 in array2)
					{
						this.listEffect.Add(new Effect(otherdate2, false));
					}
				}
				if (!Information.IsNothing(array3))
				{
					foreach (string otherdate3 in array3)
					{
						this.listEffectCC.Add(new Effect(otherdate3, false));
					}
				}
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000EFC8 File Offset: 0x0000D1C8
		public List<int> getCellsImpact(int originecell, int cellid, Maps m, int TargetCell)
		{
			List<int> list = new List<int>();
			list.Add(cellid);
			checked
			{
				if (this.impactZone.Length > 1)
				{
					int num = Array.IndexOf((Array)this.string_0, Conversions.ToString(this.impactZone[1]) ?? "");
					if (num > 0)
					{
						Cell cell = m.mapDataActuel[cellid];
						char c2 = this.impactZone[0];
						if (c2 <= 'C')
						{
							if (c2 != '-')
							{
								if (c2 == 'C')
								{
									list.AddRange(cell.GetCellsInDirections(new DirectionsEnum[]
									{
										DirectionsEnum.DIRECTION_SOUTH_EAST,
										DirectionsEnum.DIRECTION_SOUTH_WEST,
										DirectionsEnum.DIRECTION_NORTH_EAST,
										DirectionsEnum.DIRECTION_NORTH_WEST
									}, 1, (short)num).Select((SpellLevelDescription._Closure$__.$I21-0 == null) ? (SpellLevelDescription._Closure$__.$I21-0 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I21-0));
									list.AddRange(cell.GetCellsInDirections(new DirectionsEnum[]
									{
										DirectionsEnum.DIRECTION_SOUTH,
										DirectionsEnum.DIRECTION_NORTH,
										DirectionsEnum.DIRECTION_WEST,
										DirectionsEnum.DIRECTION_EAST
									}, 1, (short)(num - 1)).Select((SpellLevelDescription._Closure$__.$I21-1 == null) ? (SpellLevelDescription._Closure$__.$I21-1 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I21-1));
								}
							}
							else
							{
								IEnumerable<Cell> enumerable = from c in cell.GetAdjacentCells(true, true, 1)
								where c.Id != originecell
								select c;
								list.AddRange((IEnumerable<int>)enumerable);
							}
						}
						else if (c2 != 'L')
						{
							if (c2 != 'X')
							{
								if (c2 == '_')
								{
									List<Cell> list2 = (from c in cell.GetAdjacentCells(true, true, 1)
									where c.Id != originecell
									orderby c.distance(originecell)
									select c).ToList<Cell>();
									if (list2.Count > 2)
									{
										list2 = list2.Take(2).ToList<Cell>();
									}
									list.AddRange(list2.Select((SpellLevelDescription._Closure$__.$I21-6 == null) ? (SpellLevelDescription._Closure$__.$I21-6 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I21-6));
								}
							}
							else
							{
								list.AddRange(cell.GetCellsInDirections(new DirectionsEnum[]
								{
									DirectionsEnum.DIRECTION_SOUTH_EAST,
									DirectionsEnum.DIRECTION_SOUTH_WEST,
									DirectionsEnum.DIRECTION_NORTH_EAST,
									DirectionsEnum.DIRECTION_NORTH_WEST
								}, 1, (short)num).Select((SpellLevelDescription._Closure$__.$I21-2 == null) ? (SpellLevelDescription._Closure$__.$I21-2 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I21-2));
							}
						}
						else
						{
							Cell cell2 = m.mapDataActuel[originecell];
							int num2 = cell2.OrientationTo(cell, false);
							if (num2 > -1)
							{
								list.AddRange(cell.GetCellsInDirection((DirectionsEnum)num2, 1, (short)num).Select((SpellLevelDescription._Closure$__.$I21-3 == null) ? (SpellLevelDescription._Closure$__.$I21-3 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I21-3));
							}
						}
					}
				}
				return (from c in list
				orderby m.mapDataActuel[c].distance(TargetCell) descending
				select c).ToList<int>();
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
		public List<int> getCellsRangeTarget(int originecell, Maps m, int TargetCell)
		{
			List<int> list = new List<int>();
			list.Add(TargetCell);
			if (this.impactZone.Length > 1)
			{
				int num = Array.IndexOf((Array)this.string_0, Conversions.ToString(this.impactZone[1]) ?? "");
				if (num > 0)
				{
					char c2 = this.impactZone[0];
					if (c2 <= 'C')
					{
						if (c2 != '-')
						{
							if (c2 == 'C')
							{
								return this.getCellsImpact(originecell, TargetCell, m, TargetCell);
							}
						}
						else
						{
							Cell cell = m.mapDataActuel[TargetCell];
							list.AddRange(cell.GetAdjacentCells(true, false, 1).Select((SpellLevelDescription._Closure$__.$I22-2 == null) ? (SpellLevelDescription._Closure$__.$I22-2 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I22-2));
						}
					}
					else if (c2 != 'L')
					{
						if (c2 == 'X')
						{
							return this.getCellsImpact(originecell, TargetCell, m, TargetCell);
						}
						if (c2 == '_')
						{
							Cell cell2 = m.mapDataActuel[TargetCell];
							list.AddRange(cell2.GetAdjacentCells(true, false, 1).Select((SpellLevelDescription._Closure$__.$I22-1 == null) ? (SpellLevelDescription._Closure$__.$I22-1 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I22-1));
						}
					}
					else
					{
						Cell cell3 = m.mapDataActuel[TargetCell];
						Cell cell4 = m.mapDataActuel[originecell];
						int num2 = cell3.OrientationTo(cell4, false);
						if (num2 > -1)
						{
							list.AddRange(cell3.GetCellsInDirection((DirectionsEnum)num2, 0, checked((short)num)).Select((SpellLevelDescription._Closure$__.$I22-0 == null) ? (SpellLevelDescription._Closure$__.$I22-0 = ((Cell c) => c.Id)) : SpellLevelDescription._Closure$__.$I22-0));
						}
					}
				}
			}
			return (from c in list
			orderby m.mapDataActuel[c].distance(TargetCell) descending
			select c).ToList<int>();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		internal int method_0(ref turnIA turnIA_0, Fighter fighter_0, bool bool_0)
		{
			int num = 0;
			int num2 = bool_0 ? 1 : -2;
			checked
			{
				try
				{
					foreach (Effect effect in this.listEffect)
					{
						switch (effect.id)
						{
						case EffectIDEnum.DamageEau:
							num = Conversions.ToInteger(Operators.AddObject(num, Operators.MultiplyObject(this.calculDegat(Conversions.ToInteger(effect.min), (int)Math.Round((double)turnIA_0.eau / 2.0), 0, 0, (int)fighter_0.resistance[3]), num2)));
							break;
						case EffectIDEnum.DamageTerre:
							num = Conversions.ToInteger(Operators.AddObject(num, Operators.MultiplyObject(this.calculDegat(Conversions.ToInteger(effect.min), turnIA_0.terre, 0, 0, (int)fighter_0.resistance[1]), num2)));
							break;
						case EffectIDEnum.DamageAir:
							num = Conversions.ToInteger(Operators.AddObject(num, Operators.MultiplyObject(this.calculDegat(Conversions.ToInteger(effect.min), turnIA_0.air, 0, 0, (int)fighter_0.resistance[4]), num2)));
							break;
						case EffectIDEnum.DamageFeu:
							num = Conversions.ToInteger(Operators.AddObject(num, Operators.MultiplyObject(this.calculDegat(Conversions.ToInteger(effect.min), turnIA_0.feu, 0, 0, (int)fighter_0.resistance[2]), num2)));
							break;
						case EffectIDEnum.DamageNeutre:
							num = Conversions.ToInteger(Operators.AddObject(num, Operators.MultiplyObject(this.calculDegat(Conversions.ToInteger(effect.min), (int)Math.Round((double)turnIA_0.terre / 2.0), 0, 0, (int)fighter_0.resistance[0]), num2)));
							break;
						}
					}
				}
				finally
				{
					List<Effect>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				return num;
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000F6F0 File Offset: 0x0000D8F0
		public string getCible()
		{
			string result;
			if (this.porteMin == 0 && this.porteMax == 0)
			{
				result = "moi";
			}
			else
			{
				try
				{
					List<Effect>.Enumerator enumerator = this.listEffect.GetEnumerator();
					if (enumerator.MoveNext())
					{
						Effect effect = enumerator.Current;
						if (effect.id.ToString().Contains("Add") || effect.id == EffectIDEnum.Heal)
						{
							result = "moi";
						}
						else
						{
							result = "enemie";
						}
					}
				}
				finally
				{
					List<Effect>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			return result;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000F798 File Offset: 0x0000D998
		public object calculDegat(int Base, int caract, int puissance, int dmgFix, int resistance)
		{
			double num = ((double)(checked(Base * (100 + caract + puissance))) / 100.0 + (double)dmgFix) * ((double)(checked(100 + resistance * -1)) / 100.0);
			if (num < 0.0)
			{
				num = 0.0;
			}
			return num;
		}

		// Token: 0x04000160 RID: 352
		public bool porteModif;

		// Token: 0x04000161 RID: 353
		public bool cellulevide;

		// Token: 0x04000162 RID: 354
		public bool lancerligne;

		// Token: 0x04000163 RID: 355
		public bool lignedevue;

		// Token: 0x04000164 RID: 356
		public bool ecfindetour;

		// Token: 0x04000165 RID: 357
		public int porteMin;

		// Token: 0x04000166 RID: 358
		public int porteMax;

		// Token: 0x04000167 RID: 359
		public short pa;

		// Token: 0x04000168 RID: 360
		public short probaEC;

		// Token: 0x04000169 RID: 361
		public short probaCC;

		// Token: 0x0400016A RID: 362
		public short nbLancerTour;

		// Token: 0x0400016B RID: 363
		public short nbLancerCible;

		// Token: 0x0400016C RID: 364
		public short interval;

		// Token: 0x0400016D RID: 365
		public string impactZone;

		// Token: 0x0400016E RID: 366
		public byte level;

		// Token: 0x0400016F RID: 367
		public byte type;

		// Token: 0x04000170 RID: 368
		public List<Effect> listEffectCC;

		// Token: 0x04000171 RID: 369
		public List<Effect> listEffect;

		// Token: 0x04000172 RID: 370
		public int id;

		// Token: 0x04000173 RID: 371
		private string[] string_0;
	}
}
