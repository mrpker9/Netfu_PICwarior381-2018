using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200000D RID: 13
	public class Condition
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00005CD4 File Offset: 0x00003ED4
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000027CE File Offset: 0x000009CE
		public Condition(int targetId, string target, string value1, string operate, int result)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.targetId = targetId;
			this.value1 = value1;
			this.operate = operate;
			this.targetFighter = target;
			this.value2 = result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005CF0 File Offset: 0x00003EF0
		public bool isOk(Fighter f = null)
		{
			if (f != null)
			{
				Fighter fighter = this.bot.Fight.myFighter();
				if (fighter == null)
				{
					return false;
				}
				bool flag;
				if (Operators.CompareString(this.targetFighter, "enemie", false) == 0)
				{
					if (f.team == fighter.team)
					{
						flag = true;
						goto IL_9C;
					}
				}
				flag = (Operators.CompareString(this.targetFighter, "allie", false) == 0 && (f.team != this.bot.Fight.myFighter().team || (double)f.id == Conversions.ToDouble(this.bot.monIdDofus)));
				IL_9C:
				if (flag)
				{
					return false;
				}
				if (Operators.CompareString(this.targetFighter, "moi", false) == 0)
				{
					this.fighter = fighter;
				}
				else
				{
					this.fighter = f;
				}
				if (Operators.CompareString(this.targetFighter, "enemies", false) == 0)
				{
					try
					{
						foreach (Fighter fighter2 in fighter.fight.method_0())
						{
							if (fighter2.team != fighter.team && !this.evaluate(fighter2))
							{
								return false;
							}
						}
					}
					finally
					{
						IEnumerator<Fighter> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					return true;
				}
			}
			return this.evaluate(this.fighter);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005E54 File Offset: 0x00004054
		public bool evaluate(Fighter f = null)
		{
			int num = Convert.ToInt32(this.resultvalue1(f));
			int num2 = this.resultvalue2();
			string left = this.operate;
			bool result;
			if (Operators.CompareString(left, ">", false) != 0)
			{
				if (Operators.CompareString(left, "<", false) != 0)
				{
					if (Operators.CompareString(left, "< ou =", false) != 0)
					{
						if (Operators.CompareString(left, "> ou =", false) != 0)
						{
							result = (Operators.CompareString(left, "=", false) == 0 && num == num2);
						}
						else
						{
							result = (num >= num2);
						}
					}
					else
					{
						result = (num <= num2);
					}
				}
				else
				{
					result = (num < num2);
				}
			}
			else
			{
				result = (num > num2);
			}
			return result;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005EF0 File Offset: 0x000040F0
		public decimal resultvalue1(Fighter f = null)
		{
			decimal result;
			if (this.fighter == null)
			{
				if (Operators.CompareString(this.value1.ToLower(), "kamas", false) == 0)
				{
					result = new decimal(this.bot.InfosPerso.Kamas);
					return result;
				}
				if (Operators.CompareString(this.value1.ToLower(), "level", false) == 0)
				{
					result = new decimal(this.bot.myCharacter.level);
					return result;
				}
				if (Operators.CompareString(this.value1.ToLower(), "lastmapid", false) == 0)
				{
					result = new decimal(this.bot.lastmap.id);
					return result;
				}
				if (Operators.CompareString(this.value1.ToLower(), "pods", false) == 0)
				{
					result = new decimal((double)this.bot.Inventaire.podsactual / (double)this.bot.Inventaire.podsMax * 100.0);
					return result;
				}
				if (this.value1.ToLower().Contains("death"))
				{
					result = new decimal(this.bot.map.myActor().dead ? 1 : 0);
					return result;
				}
				if (this.value1.ToLower().Contains("hasitem"))
				{
					int idObjet = int.Parse(this.value1.Replace("hasitem", ""));
					Objets objectById = this.bot.Inventaire.getObjectById(idObjet);
					if (objectById != null)
					{
						result = new decimal(checked((int)objectById.numObjet));
						return result;
					}
					return 0m;
				}
				else
				{
					if (this.value1.ToLower().Contains("fightcount"))
					{
						result = new decimal(this.bot.nbCombat);
						return result;
					}
					if (this.value1.ToLower().Contains("lastnpc"))
					{
						return 0m;
					}
					if (this.value1.ToLower().Contains("lastinteractive"))
					{
						return 0m;
					}
					if (this.value1.ToLower().Contains("lastcellid"))
					{
						result = new decimal(this.bot.movement.lastcell);
						return result;
					}
					if (this.value1.ToLower().Contains("myid"))
					{
						return Conversions.ToDecimal(this.bot.monIdDofus);
					}
				}
			}
			else
			{
				if (f == null || f.fight == null)
				{
					return 1000m;
				}
				if (Operators.CompareString(this.value1, "%vie restante", false) == 0)
				{
					result = new decimal(checked((double)(f.LP + 1) / (double)(f.LPmax + 1)) * 100.0);
					return result;
				}
				if (Operators.CompareString(this.value1, "vie", false) == 0)
				{
					result = new decimal(f.LP);
					return result;
				}
				if (Operators.CompareString(this.value1, "gfxid", false) == 0)
				{
					result = new decimal(f.gfxId);
					return result;
				}
				if (Operators.CompareString(this.value1, "distance", false) == 0)
				{
					int cellId = f.cellId;
					int cellId2 = f.fight.myFighter().cellId;
					if (cellId == -1)
					{
						return 1m;
					}
					result = new decimal(this.bot.map.mapDataActuel[cellId].ManhattanDistanceTo(this.bot.map.mapDataActuel[cellId2]));
					return result;
				}
				else
				{
					if (Operators.CompareString(this.value1, "pm", false) == 0)
					{
						result = new decimal(f.MP);
						return result;
					}
					if (Operators.CompareString(this.value1, "pa", false) == 0)
					{
						result = new decimal(f.AP);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse terre", false) == 0)
					{
						result = new decimal((int)f.resistance[1]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse feu", false) == 0)
					{
						result = new decimal((int)f.resistance[2]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse air", false) == 0)
					{
						result = new decimal((int)f.resistance[4]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse eau", false) == 0)
					{
						result = new decimal((int)f.resistance[3]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse neutre", false) == 0)
					{
						result = new decimal((int)f.resistance[0]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse pa", false) == 0)
					{
						result = new decimal((int)f.resistance[5]);
						return result;
					}
					if (Operators.CompareString(this.value1, "faiblesse pm", false) == 0)
					{
						result = new decimal((int)f.resistance[6]);
						return result;
					}
					if (Operators.CompareString(this.value1, "level", false) == 0)
					{
						MonsterDescription monsterById = Loader.getMonsterById(f.gfxId);
						if (monsterById != null)
						{
							short level = monsterById.grades[checked(f.PowerLevel - 1)].level;
							result = new decimal((int)level);
							return result;
						}
						return 5m;
					}
					else
					{
						if (this.value1.Contains("Tour actuel"))
						{
							result = new decimal(f.fight.nbTour);
							return result;
						}
						if (this.value1.Contains("Ennemies vivant"))
						{
							result = new decimal(f.fight.FighterEnemieAlive());
							return result;
						}
					}
				}
			}
			result = -15478m;
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000064EC File Offset: 0x000046EC
		public int resultvalue2()
		{
			return this.value2;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006504 File Offset: 0x00004704
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Condition)
			{
				Condition condition = obj as Condition;
				result = (Operators.CompareString(condition.operate, this.operate, false) == 0 && Operators.CompareString(condition.value1, this.value1, false) == 0 && condition.value2 == this.value2);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0400000E RID: 14
		public string value1;

		// Token: 0x0400000F RID: 15
		public string operate;

		// Token: 0x04000010 RID: 16
		public int value2;

		// Token: 0x04000011 RID: 17
		public string targetFighter;

		// Token: 0x04000012 RID: 18
		public int targetId;

		// Token: 0x04000013 RID: 19
		public Fighter fighter;
	}
}
