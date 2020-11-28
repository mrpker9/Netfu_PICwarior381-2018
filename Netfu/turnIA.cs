using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200009D RID: 157
	public class turnIA
	{
		// Token: 0x06000351 RID: 849 RVA: 0x0001AB28 File Offset: 0x00018D28
		public turnIA copy()
		{
			turnIA turnIA = new turnIA(this.fighters, this.perso_0, null);
			turnIA.po = this.po;
			turnIA.feu = this.feu;
			turnIA.eau = this.eau;
			turnIA.terre = this.terre;
			turnIA.air = this.air;
			turnIA.sagesse = this.sagesse;
			turnIA.score = this.score;
			turnIA.list_0 = new List<LaunchedSpells>();
			turnIA.actions = new List<ActionTurnIA>();
			turnIA.list_0 = this.list_0.ToList<LaunchedSpells>();
			try
			{
				foreach (ActionTurnIA actionTurnIA in this.actions)
				{
					turnIA.actions.Add(actionTurnIA.copy());
				}
			}
			finally
			{
				List<ActionTurnIA>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return turnIA;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000352 RID: 850 RVA: 0x0001AC18 File Offset: 0x00018E18
		// (set) Token: 0x06000353 RID: 851 RVA: 0x00003E69 File Offset: 0x00002069
		public Cell maPosition
		{
			get
			{
				return this.perso_0.map.mapDataActuel.FirstOrDefault((Cell c) => c.Id == this.myFighter.cellId);
			}
			set
			{
				this.myFighter.cellId = value.Id;
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0001AC48 File Offset: 0x00018E48
		public turnIA(List<Fighter> _fighters, Perso bot, turnIA lastTurn)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.actions = new List<ActionTurnIA>();
			this.fighters = new List<Fighter>();
			this.list_0 = new List<LaunchedSpells>();
			try
			{
				foreach (Fighter fighter in _fighters)
				{
					this.fighters.Add(fighter.method_0());
				}
			}
			finally
			{
				List<Fighter>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			this.po = bot.InfosPerso.Statistique["porte"].current;
			this.feu = bot.InfosPerso.Statistique["feu"].current;
			this.eau = bot.InfosPerso.Statistique["eau"].current;
			this.air = bot.InfosPerso.Statistique["air"].current;
			this.terre = bot.InfosPerso.Statistique["terre"].current;
			this.sagesse = bot.InfosPerso.Statistique["sagesse"].current;
			this.perso_0 = bot;
			if (lastTurn != null)
			{
				this.list_0 = lastTurn.list_0;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0001ADA8 File Offset: 0x00018FA8
		public Fighter myFighter
		{
			get
			{
				return this.getFighterByid(Conversions.ToInteger(this.perso_0.monIdDofus));
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0001ADD0 File Offset: 0x00018FD0
		public Fighter getFighterByid(int id)
		{
			return this.fighters.FirstOrDefault((Fighter f) => f.id == id);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00003E7C File Offset: 0x0000207C
		public void AddSpellLaunch(int spell, int cellId)
		{
			this.list_0.Add(new LaunchedSpells(this.perso_0.Fight.nbTour, spell, (Fighter)this.method_3(cellId)));
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0001AE04 File Offset: 0x00019004
		private bool method_0(SpellLevelDescription spellLevelDescription_0, Fighter fighter_0)
		{
			bool result;
			if ((from i in this.list_0
			where i.spell == spellLevelDescription_0.id && i.Tour == this.perso_0.Fight.nbTour
			select i).Count<LaunchedSpells>() < (int)((spellLevelDescription_0.nbLancerTour <= 0) ? 1000 : spellLevelDescription_0.nbLancerTour) && (this.list_0.FirstOrDefault((LaunchedSpells s) => s.spell == spellLevelDescription_0.id) == null || checked(this.perso_0.Fight.nbTour - this.list_0.Last((LaunchedSpells s) => s.spell == spellLevelDescription_0.id).Tour) >= (int)spellLevelDescription_0.interval))
			{
				if (spellLevelDescription_0.nbLancerCible > 0 && fighter_0 != null)
				{
					int num = (from i in this.list_0
					where i.spell == spellLevelDescription_0.id && i.Tour == this.perso_0.Fight.nbTour && i.target.id == fighter_0.id
					select i).Count<LaunchedSpells>();
					result = (num < (int)spellLevelDescription_0.nbLancerCible);
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0001AF1C File Offset: 0x0001911C
		public bool LaunchSpell(int CellId, SpellLevelDescription spell, ref string str)
		{
			turnIA._Closure$__22-1 CS$<>8__locals1 = new turnIA._Closure$__22-1(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_spell = spell;
			checked
			{
				bool result;
				if (CellId == -1 || this.perso_0.Fight == null)
				{
					result = false;
				}
				else
				{
					Fighter fighter = (Fighter)this.method_3(CellId);
					if (fighter == null)
					{
						result = false;
					}
					else if (this.method_0(CS$<>8__locals1.$VB$Local_spell, fighter))
					{
						if ((int)CS$<>8__locals1.$VB$Local_spell.pa <= this.myFighter.AP)
						{
							if (CS$<>8__locals1.$VB$Local_spell.cellulevide)
							{
								result = false;
							}
							else
							{
								int num = 1;
								Cell cell = null;
								CellId = -1;
								if (fighter.id == this.myFighter.id)
								{
									if (CS$<>8__locals1.$VB$Local_spell.porteMin <= 0)
									{
										CellId = this.maPosition.Id;
									}
								}
								else
								{
									DirectionsEnum[] directions = new DirectionsEnum[]
									{
										DirectionsEnum.DIRECTION_SOUTH_EAST,
										DirectionsEnum.DIRECTION_SOUTH_WEST,
										DirectionsEnum.DIRECTION_NORTH_EAST,
										DirectionsEnum.DIRECTION_NORTH_WEST
									};
									List<Cell> list = new List<Cell>();
									list.Add(this.maPosition);
									if (!this.method_2())
									{
										list.AddRange(from c in this.maPosition.GetCellsInDirections(directions, 0, (short)(this.myFighter.MP - 1))
										where Conversions.ToBoolean(Conversions.ToBoolean(c.isWalkable(this.perso_0, true)) && this.method_3(c.Id) == null)
										select c);
									}
									list = (from c in list
									orderby c.distance(this.maPosition.Id) descending
									select c).ToList<Cell>();
									try
									{
										foreach (Cell cell2 in list)
										{
											List<int> cellsRangeTarget = CS$<>8__locals1.$VB$Local_spell.getCellsRangeTarget(cell2.Id, this.perso_0.map, fighter.cellId);
											try
											{
												List<int>.Enumerator enumerator2 = cellsRangeTarget.GetEnumerator();
												while (enumerator2.MoveNext())
												{
													turnIA._Closure$__22-0 CS$<>8__locals2 = new turnIA._Closure$__22-0(CS$<>8__locals2);
													CS$<>8__locals2.$VB$Local_destCellId = enumerator2.Current;
													Cell cell3 = this.perso_0.map.mapDataActuel.FirstOrDefault((Cell c) => c.Id == CS$<>8__locals2.$VB$Local_destCellId);
													if (!Conversions.ToBoolean(Operators.NotObject(cell3.isWalkable(null, false))))
													{
														int num2 = cell3.ManhattanDistanceTo(cell2);
														int num3 = CS$<>8__locals1.$VB$Local_spell.porteMax + this.po;
														if (num3 >= num2 && CS$<>8__locals1.$VB$Local_spell.porteMin <= num2 && (!CS$<>8__locals1.$VB$Local_spell.lancerligne || cell2.GetCellsInDirections(new DirectionsEnum[]
														{
															DirectionsEnum.DIRECTION_SOUTH_EAST,
															DirectionsEnum.DIRECTION_NORTH_EAST,
															DirectionsEnum.DIRECTION_SOUTH_WEST,
															DirectionsEnum.DIRECTION_NORTH_WEST
														}, (short)CS$<>8__locals1.$VB$Local_spell.porteMin, (short)CS$<>8__locals1.$VB$Local_spell.porteMax).Contains(cell3)))
														{
															if (cell3.Id != cell2.Id && CS$<>8__locals1.$VB$Local_spell.lignedevue)
															{
																PathFinding pathFinding = new PathFinding(this.perso_0.map, this.perso_0.Fight, this.perso_0.monId);
																List<Cell> list2 = pathFinding.FindPathSimple(cell2, cell3);
																list2.RemoveAt(0);
																list2.RemoveAt(list2.Count - 1);
																if (!this.visibility(cell2, cell3))
																{
																	str += " pas assez de ligne de vue";
																	continue;
																}
															}
															int num4 = 0;
															List<int> cellsImpact = CS$<>8__locals1.$VB$Local_spell.getCellsImpact(cell2.Id, cell3.Id, this.perso_0.map, fighter.cellId);
															try
															{
																foreach (int int_ in cellsImpact)
																{
																	object objectValue = RuntimeHelpers.GetObjectValue(this.method_3(int_));
																	if (objectValue != null)
																	{
																		int num5 = num4;
																		SpellLevelDescription $VB$Local_spell = CS$<>8__locals1.$VB$Local_spell;
																		turnIA turnIA = this;
																		num4 = num5 + $VB$Local_spell.method_0(ref turnIA, (Fighter)objectValue, Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "team", new object[0], null, null, null), this.perso_0.Fight.myFighter().team, false));
																	}
																}
															}
															finally
															{
																List<int>.Enumerator enumerator3;
																((IDisposable)enumerator3).Dispose();
															}
															if (num4 >= num)
															{
																num = num4;
																CellId = cell3.Id;
																cell = cell2;
															}
														}
													}
												}
											}
											finally
											{
												List<int>.Enumerator enumerator2;
												((IDisposable)enumerator2).Dispose();
											}
										}
									}
									finally
									{
										List<Cell>.Enumerator enumerator;
										((IDisposable)enumerator).Dispose();
									}
								}
								if (CellId > 0)
								{
									str += " lancer !";
									ActionTurnIA actionTurnIA = new ActionTurnIA();
									actionTurnIA.Spell = CS$<>8__locals1.$VB$Local_spell;
									actionTurnIA.targetCellID = CellId;
									ref int ptr = ref this.score;
									this.score = ptr + num;
									this.myFighter.AP = this.myFighter.AP - (int)CS$<>8__locals1.$VB$Local_spell.pa;
									if (cell != null && this.maPosition.Id != cell.Id)
									{
										actionTurnIA.cellTOGo = cell;
										this.myFighter.MP = this.myFighter.MP - actionTurnIA.cellTOGo.ManhattanDistanceTo(this.maPosition);
										this.maPosition = cell;
									}
									this.AddSpellLaunch(CS$<>8__locals1.$VB$Local_spell.id, CellId);
									this.actions.Add(actionTurnIA);
									result = true;
								}
								else
								{
									result = false;
								}
							}
						}
						else
						{
							str += " pas assez de pa";
							result = false;
						}
					}
					else
					{
						str = str + "  cooldown non achevé  tours restants :" + Conversions.ToString((int)CS$<>8__locals1.$VB$Local_spell.interval - (this.perso_0.Fight.nbTour - this.list_0.Last((LaunchedSpells s) => s.spell == CS$<>8__locals1.$VB$Local_spell.id).Tour));
						result = false;
					}
				}
				return result;
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0001B4DC File Offset: 0x000196DC
		public void applyEffect(SpellLevelDescription spell, Fighter target)
		{
			turnIA._Closure$__23-0 CS$<>8__locals1 = new turnIA._Closure$__23-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_target = target;
			bool flag = CS$<>8__locals1.$VB$Local_target.id == this.myFighter.id;
			Cell cell = this.perso_0.map.mapDataActuel.FirstOrDefault((Cell c) => c.Id == CS$<>8__locals1.$VB$Local_target.cellId);
			try
			{
				foreach (Effect effect in spell.listEffect)
				{
					EffectIDEnum id = effect.id;
					if (id != EffectIDEnum.PushBack)
					{
						switch (id)
						{
						case EffectIDEnum.DamageEau:
						{
							Fighter $VB$Local_target;
							($VB$Local_target = CS$<>8__locals1.$VB$Local_target).LP = Conversions.ToInteger(Operators.SubtractObject($VB$Local_target.LP, this.calculDegat(Conversions.ToInteger(effect.min), this.eau, 0, 0, (int)CS$<>8__locals1.$VB$Local_target.resistance[3])));
							break;
						}
						case EffectIDEnum.DamageTerre:
						{
							Fighter $VB$Local_target;
							($VB$Local_target = CS$<>8__locals1.$VB$Local_target).LP = Conversions.ToInteger(Operators.SubtractObject($VB$Local_target.LP, this.calculDegat(Conversions.ToInteger(effect.min), this.terre, 0, 0, (int)CS$<>8__locals1.$VB$Local_target.resistance[1])));
							break;
						}
						case EffectIDEnum.DamageAir:
						{
							Fighter $VB$Local_target;
							($VB$Local_target = CS$<>8__locals1.$VB$Local_target).LP = Conversions.ToInteger(Operators.SubtractObject($VB$Local_target.LP, this.calculDegat(Conversions.ToInteger(effect.min), this.air, 0, 0, (int)CS$<>8__locals1.$VB$Local_target.resistance[4])));
							break;
						}
						case EffectIDEnum.DamageFeu:
						{
							Fighter $VB$Local_target;
							($VB$Local_target = CS$<>8__locals1.$VB$Local_target).LP = Conversions.ToInteger(Operators.SubtractObject($VB$Local_target.LP, this.calculDegat(Conversions.ToInteger(effect.min), this.feu, 0, 0, (int)CS$<>8__locals1.$VB$Local_target.resistance[2])));
							break;
						}
						case EffectIDEnum.DamageNeutre:
						{
							Fighter $VB$Local_target;
							($VB$Local_target = CS$<>8__locals1.$VB$Local_target).LP = Conversions.ToInteger(Operators.SubtractObject($VB$Local_target.LP, this.calculDegat(Conversions.ToInteger(effect.min), checked((int)Math.Round((double)this.terre / 2.0)), 0, 0, (int)CS$<>8__locals1.$VB$Local_target.resistance[0])));
							break;
						}
						default:
							if (id == EffectIDEnum.AddPO)
							{
								if (flag)
								{
									ref int ptr = ref this.po;
									this.po = Conversions.ToInteger(Operators.AddObject(ptr, effect.min));
								}
							}
							break;
						}
					}
					else
					{
						int direction = this.maPosition.OrientationTo(cell, true);
						Cell cell2 = cell.GetCellsInDirection((DirectionsEnum)direction, Conversions.ToShort(effect.min), Conversions.ToShort(effect.min)).FirstOrDefault<Cell>();
						CS$<>8__locals1.$VB$Local_target.cellId = cell2.Id;
					}
				}
			}
			finally
			{
				List<Effect>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000F798 File Offset: 0x0000D998
		public object calculDegat(int Base, int caract, int puissance, int dmgFix, int resistance)
		{
			double num = ((double)(checked(Base * (100 + caract + puissance))) / 100.0 + (double)dmgFix) * ((double)(checked(100 + resistance * -1)) / 100.0);
			if (num < 0.0)
			{
				num = 0.0;
			}
			return num;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00002B9E File Offset: 0x00000D9E
		public void calculEndMove()
		{
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001B7D4 File Offset: 0x000199D4
		private int method_1()
		{
			int num = 0;
			int num2 = 0;
			checked
			{
				try
				{
					foreach (KeyValuePair<int, byte> keyValuePair in this.perso_0.spellHandler.SpellsList)
					{
						SpellLevelDescription spellLevelDescription = Loader.getSpellById(keyValuePair.Key).Levels[(int)(keyValuePair.Value - 1)];
						num += spellLevelDescription.porteMax;
						num2++;
					}
				}
				finally
				{
					List<KeyValuePair<int, byte>>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				return (int)Math.Round((double)num / (double)num2);
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0001B868 File Offset: 0x00019A68
		private bool method_2()
		{
			return (from c in this.maPosition.GetAdjacentCells(true, false, 1)
			where Conversions.ToBoolean(this.method_3(c.Id) != null && Conversions.ToBoolean(Operators.CompareObjectNotEqual(NewLateBinding.LateGet(this.method_3(c.Id), null, "team", new object[0], null, null, null), this.myFighter.team, false)))
			select c).Count<Cell>() > 0;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0001B8A8 File Offset: 0x00019AA8
		private object method_3(int int_0)
		{
			return this.fighters.FirstOrDefault((Fighter f) => f.cellId == int_0 && !f.dead);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0001B8DC File Offset: 0x00019ADC
		public bool visibility(Cell cell1, Cell cell2)
		{
			checked
			{
				bool result;
				try
				{
					turnIA._Closure$__29-0 CS$<>8__locals1 = new turnIA._Closure$__29-0(CS$<>8__locals1);
					int x = cell1.X;
					int y = cell1.Y;
					int x2 = cell2.X;
					int y2 = cell2.Y;
					bool flag = true;
					int num = Math.Abs(x2 - x);
					int num2 = Math.Abs(y2 - y);
					CS$<>8__locals1.$VB$Local_x = x;
					CS$<>8__locals1.$VB$Local_y = y;
					int num3 = -1 + num + num2;
					int num4 = (x2 > x) ? 1 : -1;
					int num5 = (y2 > y) ? 1 : -1;
					int num6 = num - num2;
					num *= 2;
					num2 *= 2;
					int num7 = 0;
					do
					{
						if (num6 > 0)
						{
							CS$<>8__locals1.$VB$Local_x += num4;
							num6 -= num2;
						}
						else if (num6 < 0)
						{
							CS$<>8__locals1.$VB$Local_y += num5;
							num6 += num;
						}
						else
						{
							CS$<>8__locals1.$VB$Local_x += num4;
							num6 -= num2;
							CS$<>8__locals1.$VB$Local_y += num5;
							num6 += num;
							num3--;
						}
						num7++;
					}
					while (num7 <= 0);
					while (num3 > 0 && flag)
					{
						turnIA._Closure$__29-1 CS$<>8__locals2 = new turnIA._Closure$__29-1(CS$<>8__locals2);
						CS$<>8__locals2.$VB$Local_cell = this.perso_0.map.mapDataActuel.FirstOrDefault((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = ((Cell c) => c.X == CS$<>8__locals1.$VB$Local_x && c.Y == CS$<>8__locals1.$VB$Local_y)) : CS$<>8__locals1.$I0);
						Fighter fighter = this.fighters.FirstOrDefault((Fighter f) => f.cellId == CS$<>8__locals2.$VB$Local_cell.Id);
						if (CS$<>8__locals2.$VB$Local_cell == null || !CS$<>8__locals2.$VB$Local_cell.bool_5 || (fighter != null && !fighter.dead))
						{
							flag = false;
						}
						else
						{
							if (num6 > 0)
							{
								CS$<>8__locals1.$VB$Local_x += num4;
								num6 -= num2;
							}
							else if (num6 < 0)
							{
								CS$<>8__locals1.$VB$Local_y += num5;
								num6 += num;
							}
							else
							{
								CS$<>8__locals1.$VB$Local_x += num4;
								num6 -= num2;
								CS$<>8__locals1.$VB$Local_y += num5;
								num6 += num;
								num3--;
							}
							num3--;
						}
					}
					result = flag;
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
					result = false;
				}
				return result;
			}
		}

		// Token: 0x040003DE RID: 990
		public int score;

		// Token: 0x040003DF RID: 991
		public List<ActionTurnIA> actions;

		// Token: 0x040003E0 RID: 992
		public List<Fighter> fighters;

		// Token: 0x040003E1 RID: 993
		private List<LaunchedSpells> list_0;

		// Token: 0x040003E2 RID: 994
		private Perso perso_0;

		// Token: 0x040003E3 RID: 995
		public int po;

		// Token: 0x040003E4 RID: 996
		public int feu;

		// Token: 0x040003E5 RID: 997
		public int eau;

		// Token: 0x040003E6 RID: 998
		public int terre;

		// Token: 0x040003E7 RID: 999
		public int air;

		// Token: 0x040003E8 RID: 1000
		public int sagesse;

		// Token: 0x040003E9 RID: 1001
		public Cell endMoveCell;
	}
}
