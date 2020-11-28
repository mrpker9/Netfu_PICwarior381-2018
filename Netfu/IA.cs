using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200008D RID: 141
	public class IA
	{
		// Token: 0x0600030A RID: 778 RVA: 0x00003A8C File Offset: 0x00001C8C
		static IA()
		{
			Class15.XRATSHnz66atd();
			IA.random_0 = new Random();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00017E40 File Offset: 0x00016040
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00017E5C File Offset: 0x0001605C
		public IA(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.ActionsFight = new List<Actions>();
			this.ConditionsFight = new List<Condition>();
			this.list_0 = new List<LaunchedSpells>();
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.list_1 = new List<int>();
			this.list_2 = new List<int>();
			this.object_1 = 0;
			this.index = index;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00017ED0 File Offset: 0x000160D0
		public IA()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.ActionsFight = new List<Actions>();
			this.ConditionsFight = new List<Condition>();
			this.list_0 = new List<LaunchedSpells>();
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.list_1 = new List<int>();
			this.list_2 = new List<int>();
			this.object_1 = 0;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00003A9D File Offset: 0x00001C9D
		public void Reset()
		{
			this.int_0 = -1;
			this.list_0 = new List<LaunchedSpells>();
			this.list_1.Clear();
			this.list_2.Clear();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00003AC7 File Offset: 0x00001CC7
		public void InvalidCell()
		{
			this.list_1.Add(this.lastDestCell);
			this.object_1 = 800;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00003AEA File Offset: 0x00001CEA
		public void InvalidSpell()
		{
			this.list_2.Add(this.lastSpellLaunchId);
			this.object_1 = 800;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00017F3C File Offset: 0x0001613C
		internal int method_0()
		{
			string text = "";
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				int result;
				lock (obj)
				{
					try
					{
						if (this.bot().Fight == null | this.bot().status.connexion != status.ConnexionStatus.const_3)
						{
							return -1;
						}
						if (!this.bot().Fight.myturn)
						{
							return 1000;
						}
						Fighter fighter = this.bot().Fight.myFighter();
						this.bot().MessagesToSend.RemoveAll((IA._Closure$__.$I20-0 == null) ? (IA._Closure$__.$I20-0 = ((Message m) => Operators.CompareString(m.data, "Gt", false) == 0)) : IA._Closure$__.$I20-0);
						if (this.bot().config.randomSpeedCombat)
						{
							this.bot().config.speedCombat = Fonctions.rand.Next(0, 2500);
						}
						this.bot().Send(new Message("Gt", this.bot().config.speedCombat + 6000, false, true, true));
						if (fighter == null || this.bot().map == null)
						{
							return -1;
						}
						if (this.bot().Fight != null)
						{
							try
							{
								List<Actions>.Enumerator enumerator = this.ActionsFight.GetEnumerator();
								while (enumerator.MoveNext())
								{
									IA._Closure$__20-0 CS$<>8__locals1 = new IA._Closure$__20-0(CS$<>8__locals1);
									CS$<>8__locals1.$VB$Local_a = enumerator.Current;
									try
									{
										foreach (Fighter f in this.bot().Fight.method_0())
										{
											if (this.ActionsFight.First<Actions>().conditions.FirstOrDefault<Condition>() != null)
											{
												this.ActionsFight.First<Actions>().conditions.First<Condition>().fighter = null;
											}
											if (CS$<>8__locals1.$VB$Local_a.conditionsOk(f))
											{
												string action = CS$<>8__locals1.$VB$Local_a.Action;
												if (Operators.CompareString(action, "Avancer", false) != 0)
												{
													if (Operators.CompareString(action, "Lancer un sort", false) != 0)
													{
														if (Operators.CompareString(action, "Fuir", false) == 0 && this.method_6(-1))
														{
															this.list_1.Clear();
															this.list_2.Clear();
															text += "\nFuite !";
															this.bot().chatHandler.AddTextChat(text, "fight");
															return -1;
														}
													}
													else
													{
														KeyValuePair<int, byte> keyValuePair = this.bot().spellHandler.SpellsList.FirstOrDefault((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = ((KeyValuePair<int, byte> s) => s.Key == CS$<>8__locals1.$VB$Local_a.ActionParam)) : CS$<>8__locals1.$I1);
														if (keyValuePair.Key > 0)
														{
															SpellDescription spellById = Loader.getSpellById(keyValuePair.Key);
															SpellLevelDescription spellLevelDescription = spellById.Levels[(int)(keyValuePair.Value - 1)];
															int num = spellLevelDescription.porteMax + (spellLevelDescription.porteModif ? this.bot().InfosPerso.Statistique["porte"].current : 0);
															fighter.int_1 = ((fighter.int_1 < num) ? num : fighter.int_1);
															if (spellById.id == 2510)
															{
																Objets objets = this.bot().Inventaire.getObjects().FirstOrDefault((IA._Closure$__.$I20-2 == null) ? (IA._Closure$__.$I20-2 = ((Objets o) => o.position == 1)) : IA._Closure$__.$I20-2);
																ObjetDescription itemById = Loader.getItemById(Conversions.ToInteger(objets.idObjet));
																if (objets == null)
																{
																	spellLevelDescription.pa = 4;
																	spellLevelDescription.porteMax = 1;
																	spellLevelDescription.porteMin = 1;
																}
																else
																{
																	spellLevelDescription.pa = (short)itemById.pa;
																	spellLevelDescription.porteMax = (int)itemById.porteMax;
																	spellLevelDescription.porteMin = (int)itemById.porteMin;
																	spellLevelDescription.lancerligne = (itemById.type != 3);
																	spellLevelDescription.impactZone = ((itemById.type == 4) ? "_c" : ((itemById.type == 7) ? "-c" : ""));
																}
																spellLevelDescription.porteModif = !spellLevelDescription.cellulevide;
																spellLevelDescription.nbLancerTour = (unchecked(-((!(-((spellLevelDescription.nbLancerCible == spellLevelDescription.interval) > false)) > false) ? 1 : 0)) ? 1 : 0);
															}
															if (spellById != null && !this.list_2.Contains(spellById.id))
															{
																text = string.Concat(new string[]
																{
																	text,
																	"\nAnalyse sort : ",
																	spellById.nom,
																	"  priority: ",
																	Conversions.ToString(CS$<>8__locals1.$VB$Local_a.priority),
																	" ====>"
																});
																if (CS$<>8__locals1.$VB$Local_a.conditions.FirstOrDefault<Condition>() == null || CS$<>8__locals1.$VB$Local_a.conditions.First<Condition>().fighter == null)
																{
																	if (spellLevelDescription.cellulevide && this.method_9(-200, spellLevelDescription, ref text))
																	{
																		this.lastSpellLaunchId = spellById.id;
																		this.bot().chatHandler.AddTextChat(text, "fight");
																		return -1;
																	}
																}
																else if (this.method_9(CS$<>8__locals1.$VB$Local_a.conditions.First<Condition>().fighter.cellId, spellLevelDescription, ref text))
																{
																	this.lastSpellLaunchId = spellById.id;
																	this.bot().chatHandler.AddTextChat(text, "fight");
																	return -1;
																}
															}
															else
															{
																text = text + spellById.nom + " sort non trouvé\n";
															}
														}
													}
												}
												else if (CS$<>8__locals1.$VB$Local_a.conditions.First<Condition>() == null || CS$<>8__locals1.$VB$Local_a.conditions.First<Condition>().fighter == null)
												{
													this.list_1.Clear();
													this.list_2.Clear();
												}
												else
												{
													int cellId = fighter.cellId;
													if (this.method_7(CS$<>8__locals1.$VB$Local_a.conditions.First<Condition>().fighter, 999))
													{
														this.int_0 = cellId;
														this.list_1.Clear();
														this.list_2.Clear();
														text += "\nAvance !";
														this.bot().chatHandler.AddTextChat(text, "fight");
														return -1;
													}
												}
											}
										}
									}
									finally
									{
										IEnumerator<Fighter> enumerator2;
										if (enumerator2 != null)
										{
											enumerator2.Dispose();
										}
									}
								}
							}
							finally
							{
								List<Actions>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
							if (Operators.CompareString(this.bot().config.iaType, "Reflechie", false) == 0 && this.goToRangeNextTour())
							{
								return -1;
							}
						}
						this.list_1.Clear();
						this.list_2.Clear();
						this.bot().Fight.turnEnd();
						text += "\r\nFin du tour\r";
					}
					catch (Exception ex)
					{
						Fonctions.traiterErreur(ex);
						text = text + "erreur : " + ex.StackTrace + "\r";
						this.list_1.Clear();
						this.list_2.Clear();
						this.bot().Fight.turnEnd();
					}
					finally
					{
						this.bot().chatHandler.AddTextChat(text, "fight");
					}
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00018744 File Offset: 0x00016944
		private bool method_1(string string_0)
		{
			if (Operators.CompareString(string_0, "", false) == 0)
			{
				this.ActionsFight.Clear();
				Condition item = new Condition(this.index, "enemie", "vie", ">", 0);
				Condition item2 = new Condition(this.index, "moi", "vie", ">", 0);
				try
				{
					foreach (KeyValuePair<int, int> keyValuePair in this.bot().config.listSpellLaunch.Where((IA._Closure$__.$I21-0 == null) ? (IA._Closure$__.$I21-0 = ((KeyValuePair<int, int> s) => s.Value > 0)) : IA._Closure$__.$I21-0))
					{
						Actions actions = new Actions(this.index, "Lancer un sort", keyValuePair.Key, keyValuePair.Value);
						SpellLevelDescription spellLevelDescription = Loader.getSpellById(keyValuePair.Key).Levels[2];
						if (Operators.CompareString(Loader.getSpellById(keyValuePair.Key).Levels.First<SpellLevelDescription>().getCible(), "moi", false) == 0)
						{
							actions.conditions.Add(item2);
						}
						else if (!spellLevelDescription.cellulevide)
						{
							actions.conditions.Add(item);
						}
						this.ActionsFight.Add(actions);
					}
				}
				finally
				{
					IEnumerator<KeyValuePair<int, int>> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				if (Operators.CompareString(this.bot().config.iaType, "Reflechie", false) != 0)
				{
					Actions actions2 = new Actions(this.index, "Avancer", -1, -2);
					actions2.conditions.Add(item);
					this.ActionsFight.Add(actions2);
				}
				Actions item3 = new Actions(this.index, "Passer", -1, -4);
				this.ActionsFight.Add(item3);
				this.StartPlacement = this.bot().config.startPlacement;
			}
			else
			{
				this.bot().config.iaType = "Bourrin";
				try
				{
					this.ActionsFight.Clear();
					this.ConditionsFight.Clear();
					string[] array = string_0.Split(new string[]
					{
						"|||"
					}, StringSplitOptions.None);
					string[] array2 = array[0].Split(new string[]
					{
						"\n"
					}, StringSplitOptions.None);
					string[] array3 = array[1].Split(new string[]
					{
						"\n"
					}, StringSplitOptions.None);
					this.StartPlacement = array[2].Replace("\n", "");
					foreach (string text in array2)
					{
						if (text.Contains(","))
						{
							string[] array5 = text.Split(new char[]
							{
								','
							});
							this.ConditionsFight.Add(new Condition(this.index, array5[1], array5[2], array5[3], int.Parse(array5[4])));
						}
					}
					foreach (string text2 in array3)
					{
						if (text2.Contains(","))
						{
							string[] array7 = text2.Split(new char[]
							{
								','
							});
							SpellDescription spellByName = Loader.getSpellByName(array7[2]);
							this.ActionsFight.Add(new Actions(this.index, array7[1], Information.IsNothing(spellByName) ? -1 : spellByName.id, int.Parse(array7[3])));
							string[] array8 = array7[0].Split(new char[]
							{
								'|'
							});
							foreach (string text3 in array8)
							{
								if (Operators.CompareString(text3.Replace(" ", ""), "", false) != 0)
								{
									this.ActionsFight.Last<Actions>().conditions.Add(this.ConditionsFight[checked(int.Parse(text3) - 1)]);
								}
							}
						}
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
					return false;
				}
			}
			this.ActionsFight.Sort((IA._Closure$__.$I21-1 == null) ? (IA._Closure$__.$I21-1 = ((Actions a1, Actions a2) => a2.priority.CompareTo(a1.priority))) : IA._Closure$__.$I21-1);
			return true;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00018BB8 File Offset: 0x00016DB8
		private void method_2()
		{
			try
			{
				Combat fight = this.bot().Fight;
				int num = 9999;
				byte team = this.bot().Fight.myFighter().team;
				int playerPosition;
				try
				{
					foreach (int num2 in fight.position[0])
					{
						if (fight.getFighterByCellId(num2) == null)
						{
							try
							{
								foreach (Fighter fighter in fight.getFightersByTeam((team == 0) ? 1 : 0))
								{
									int num3 = this.bot().map.mapDataActuel[num2].ManhattanDistanceTo(this.bot().map.mapDataActuel[fighter.cellId]);
									if (num3 < num)
									{
										num = num3;
										playerPosition = num2;
									}
								}
							}
							finally
							{
								IEnumerator<Fighter> enumerator2;
								if (enumerator2 != null)
								{
									enumerator2.Dispose();
								}
							}
						}
					}
				}
				finally
				{
					List<int>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				fight.setPlayerPosition(playerPosition);
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00018CFC File Offset: 0x00016EFC
		private void method_3()
		{
			Combat fight = this.bot().Fight;
			int num = 0;
			byte team = this.bot().Fight.myFighter().team;
			int playerPosition;
			try
			{
				foreach (int num2 in fight.position[0])
				{
					if (fight.getFighterByCellId(num2) == null)
					{
						try
						{
							foreach (Fighter fighter in fight.getFightersByTeam((team == 0) ? 1 : 0))
							{
								int num3 = this.bot().map.mapDataActuel[num2].ManhattanDistanceTo(this.bot().map.mapDataActuel[fighter.cellId]);
								if (num3 > num)
								{
									num = num3;
									playerPosition = num2;
								}
							}
						}
						finally
						{
							IEnumerator<Fighter> enumerator2;
							if (enumerator2 != null)
							{
								enumerator2.Dispose();
							}
						}
					}
				}
			}
			finally
			{
				List<int>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			fight.setPlayerPosition(playerPosition);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00018E14 File Offset: 0x00017014
		private void method_4()
		{
			Combat fight = this.bot().Fight;
			List<int> list = fight.position[0];
			fight.setPlayerPosition(list[IA.random_0.Next(0, list.Count)]);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00018E54 File Offset: 0x00017054
		private Fighter method_5()
		{
			byte team = this.bot().Fight.myFighter().team;
			Combat fight = this.bot().Fight;
			byte team2 = fight.myFighter().team;
			List<Fighter> list = fight.getFightersByTeam((int)team).ToList<Fighter>();
			Fighter result = null;
			if (list.Count > 1)
			{
				int num = 6666;
				try
				{
					foreach (Fighter fighter in list)
					{
						uint num2 = checked((uint)this.bot().map.mapDataActuel[this.bot().Fight.myFighter().cellId].ManhattanDistanceTo(this.bot().map.mapDataActuel[fighter.cellId]));
						if ((ulong)num2 < (ulong)((long)num))
						{
							num = checked((int)num2);
							result = fighter;
						}
					}
				}
				finally
				{
					List<Fighter>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00018F54 File Offset: 0x00017154
		public bool isTakle()
		{
			Cell cell = this.bot().map.mapDataActuel[this.bot().Fight.myFighter().cellId];
			return (from c in cell.GetAdjacentCells(true, false, 1)
			where this.bot().Fight.getFighterByCellId(c.Id) != null && !this.bot().Fight.getFighterByCellId(c.Id).dead && this.bot().Fight.getFighterByCellId(c.Id).team != this.bot().Fight.myFighter().team
			select c).Count<Cell>() > 0;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00018FB8 File Offset: 0x000171B8
		private bool method_6(int int_1 = -1)
		{
			IA._Closure$__27-0 CS$<>8__locals1 = new IA._Closure$__27-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			bool result;
			if (this.bot().Fight.myFighter() == null || this.bot().Fight.myFighter().MP == 0)
			{
				result = false;
			}
			else
			{
				CS$<>8__locals1.$VB$Local_currentcell = this.bot().map.mapDataActuel[this.bot().Fight.myFighter().cellId];
				if (this.isTakle())
				{
					result = false;
				}
				else
				{
					List<Cell> list = CS$<>8__locals1.$VB$Local_currentcell.GetAllCellsInRange(0, this.bot().Fight.myFighter().MP, false, (Cell c) => Conversions.ToBoolean(Conversions.ToBoolean(c.isWalkable(this.bot(), true)) && this.bot().Fight.getFighterByCellId(c.Id) == null)).ToList<Cell>();
					Fighter fighter = this.bot().Fight.myFighter();
					byte team = fighter.team;
					IEnumerable<Fighter> fightersByTeam = this.bot().Fight.getFightersByTeam((team == 1) ? 0 : 1);
					double num = (double)fightersByTeam.Sum((Fighter e) => CS$<>8__locals1.$VB$Me.bot().map.mapDataActuel[e.cellId].ManhattanDistanceTo(CS$<>8__locals1.$VB$Local_currentcell));
					Cell cell = null;
					try
					{
						List<Cell>.Enumerator enumerator = list.GetEnumerator();
						while (enumerator.MoveNext())
						{
							IA._Closure$__27-1 CS$<>8__locals2 = new IA._Closure$__27-1(CS$<>8__locals2);
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
							CS$<>8__locals2.$VB$Local_c = enumerator.Current;
							int num2 = CS$<>8__locals2.$VB$Local_c.ManhattanDistanceTo(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_currentcell);
							int num3 = fighter.MP;
							if (int_1 > -1)
							{
								num3 = ((int_1 > fighter.MP) ? fighter.MP : int_1);
							}
							if (num2 <= num3)
							{
								double num4 = (double)fightersByTeam.Sum((Fighter e) => CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Me.bot().map.mapDataActuel[e.cellId].ManhattanDistanceTo(CS$<>8__locals2.$VB$Local_c));
								IEnumerable<Cell> adjacentCells = CS$<>8__locals2.$VB$Local_c.GetAdjacentCells(true, true, 2);
								bool flag = adjacentCells.Count<Cell>() < 16 || adjacentCells.Where((IA._Closure$__.$I27-3 == null) ? (IA._Closure$__.$I27-3 = ((Cell cn) => cn.X < 0 || cn.Y < 0)) : IA._Closure$__.$I27-3).Count<Cell>() > 0;
								num4 -= (flag ? 0.3 : 0.0);
								if (num < num4)
								{
									num = num4;
									cell = CS$<>8__locals2.$VB$Local_c;
								}
							}
						}
					}
					finally
					{
						List<Cell>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = (cell != null && cell.Id != fighter.cellId && this.bot().movement.SeDeplacer(cell.Id, -1));
				}
			}
			return result;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00019248 File Offset: 0x00017448
		public static IA LoadIA(int index, string p)
		{
			IA ia = new IA(index);
			IA result;
			if (!ia.method_1(p))
			{
				result = null;
			}
			else
			{
				result = ia;
			}
			return result;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00019270 File Offset: 0x00017470
		private bool method_7(Fighter fighter_0, int int_1 = 999)
		{
			bool result;
			if (fighter_0 == null | this.bot().Fight.myFighter().MP <= 0)
			{
				result = false;
			}
			else
			{
				Cell cell = this.bot().map.mapDataActuel[fighter_0.cellId];
				if (this.isTakle())
				{
					result = false;
				}
				else
				{
					Cell cell2 = cell.GetAdjacentCells(true, true, 1).First((Cell c) => Conversions.ToBoolean(c.isWalkable(this.bot(), true)));
					if (!Information.IsNothing(cell2) && this.bot().movement.SeDeplacer(cell2.Id, int_1))
					{
						this.bot().Fight.myFighter().cellId = cell2.Id;
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00019330 File Offset: 0x00017530
		private Fighter method_8()
		{
			Combat fight = this.bot().Fight;
			byte team = fight.myFighter().team;
			byte team2 = this.bot().Fight.myFighter().team;
			List<Fighter> list = (List<Fighter>)this.bot().Fight.getFightersByTeam((team2 == 1) ? 0 : 1);
			Fighter result = null;
			if (list.Count > 1)
			{
				int num = 6666;
				try
				{
					foreach (Fighter fighter in list)
					{
						uint num2 = checked((uint)this.bot().map.mapDataActuel[this.bot().Fight.myFighter().cellId].ManhattanDistanceTo(this.bot().map.mapDataActuel[fighter.cellId]));
						if ((ulong)num2 < (ulong)((long)num))
						{
							num = checked((int)num2);
							result = fighter;
						}
					}
				}
				finally
				{
					List<Fighter>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			return result;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00019444 File Offset: 0x00017644
		private bool method_9(int int_1, SpellLevelDescription spellLevelDescription_0, ref string string_0)
		{
			IA._Closure$__31-1 CS$<>8__locals1 = new IA._Closure$__31-1(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_spell = spellLevelDescription_0;
			checked
			{
				bool result;
				if (int_1 == -1 || this.bot().Fight == null)
				{
					result = false;
				}
				else
				{
					Fighter fighter = this.bot().Fight.getFighterByCellId(int_1);
					Cell cell = this.bot().map.mapDataActuel[this.bot().Fight.myFighter().cellId];
					if (this.method_10(CS$<>8__locals1.$VB$Local_spell, fighter))
					{
						if ((int)CS$<>8__locals1.$VB$Local_spell.pa <= this.bot().Fight.myFighter().AP)
						{
							if (CS$<>8__locals1.$VB$Local_spell.cellulevide)
							{
								int num = (fighter == null) ? cell.Id : fighter.cellId;
								Cell cell2 = this.bot().map.mapDataActuel[num];
								int num2 = 9999;
								Cell cell3 = null;
								Cell[] array;
								if (CS$<>8__locals1.$VB$Local_spell.lancerligne)
								{
									array = (from c in cell.GetCellsInDirections(new DirectionsEnum[]
									{
										DirectionsEnum.DIRECTION_SOUTH_EAST,
										DirectionsEnum.DIRECTION_NORTH_EAST,
										DirectionsEnum.DIRECTION_SOUTH_WEST,
										DirectionsEnum.DIRECTION_NORTH_WEST
									}, (short)CS$<>8__locals1.$VB$Local_spell.porteMin, (short)CS$<>8__locals1.$VB$Local_spell.porteMax)
									where Conversions.ToBoolean(c.isWalkable(this.bot(), false))
									select c).ToArray<Cell>();
								}
								else
								{
									array = cell.GetAllCellsInRange(CS$<>8__locals1.$VB$Local_spell.porteMin, CS$<>8__locals1.$VB$Local_spell.porteMax, false, (Cell c) => Conversions.ToBoolean(Conversions.ToBoolean(c.isWalkable(this.bot(), false)) && this.bot().Fight.getFighterByCellId(c.Id) == null)).ToArray<Cell>();
								}
								foreach (Cell cell4 in array)
								{
									int num3 = (int)Math.Round(cell4.distance(cell2.Id));
									if (num3 < num2 && num3 > 0)
									{
										num2 = num3;
										cell3 = cell4;
									}
								}
								if (cell3 != null)
								{
									this.bot().spellHandler.EquipeSort(CS$<>8__locals1.$VB$Local_spell.id, false);
									this.bot().Fight.LaunchSpell(CS$<>8__locals1.$VB$Local_spell.id, cell3.Id, Conversions.ToInteger(this.object_1));
									this.lastDestCell = cell3.Id;
									this.object_1 = 0;
									return true;
								}
								fighter = null;
							}
							else
							{
								int num4 = 1;
								int id = cell.Id;
								int_1 = -1;
								if (fighter.id == this.bot().Fight.myFighter().id)
								{
									if (CS$<>8__locals1.$VB$Local_spell.porteMin <= 0)
									{
										int_1 = fighter.cellId;
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
									list.Add(cell);
									if (!this.isTakle() && Operators.CompareString(this.bot().config.iaType, "Reflechie", false) == 0)
									{
										list.AddRange(from c in cell.GetCellsInDirections(directions, 0, (short)(this.bot().Fight.myFighter().MP - 1))
										where Conversions.ToBoolean(c.isWalkable(this.bot(), true))
										select c);
									}
									try
									{
										foreach (Cell cell5 in list)
										{
											List<int> cellsRangeTarget = CS$<>8__locals1.$VB$Local_spell.getCellsRangeTarget(cell5.Id, this.bot().map, fighter.cellId);
											double num5 = cell5.distance(cell.Id);
											try
											{
												List<int>.Enumerator enumerator2 = cellsRangeTarget.GetEnumerator();
												while (enumerator2.MoveNext())
												{
													IA._Closure$__31-0 CS$<>8__locals2 = new IA._Closure$__31-0(CS$<>8__locals2);
													CS$<>8__locals2.$VB$Local_destCellId = enumerator2.Current;
													Cell cell6 = this.bot().map.mapDataActuel.FirstOrDefault((Cell c) => c.Id == CS$<>8__locals2.$VB$Local_destCellId);
													int num6 = cell6.ManhattanDistanceTo(cell5);
													int num7 = CS$<>8__locals1.$VB$Local_spell.porteMax + (CS$<>8__locals1.$VB$Local_spell.porteModif ? this.bot().InfosPerso.Statistique["porte"].current : 0);
													if (num7 >= num6 && CS$<>8__locals1.$VB$Local_spell.porteMin <= num6 && (!CS$<>8__locals1.$VB$Local_spell.lancerligne || cell5.GetCellsInDirections(new DirectionsEnum[]
													{
														DirectionsEnum.DIRECTION_SOUTH_EAST,
														DirectionsEnum.DIRECTION_NORTH_EAST,
														DirectionsEnum.DIRECTION_SOUTH_WEST,
														DirectionsEnum.DIRECTION_NORTH_WEST
													}, (short)CS$<>8__locals1.$VB$Local_spell.porteMin, (short)CS$<>8__locals1.$VB$Local_spell.porteMax).Contains(cell6)))
													{
														if (cell6.Id != cell5.Id && CS$<>8__locals1.$VB$Local_spell.lignedevue)
														{
															if (this.list_1.Contains(cell6.Id))
															{
																continue;
															}
															PathFinding pathFinding = new PathFinding(this.bot().map, this.bot().Fight, this.bot().monId);
															List<Cell> list2 = pathFinding.FindPathSimple(cell5, cell6);
															list2.RemoveAt(0);
															list2.RemoveAt(list2.Count - 1);
															if (!this.visibility(cell5, cell6))
															{
																string_0 += " pas assez de ligne de vue";
																continue;
															}
														}
														int num8 = 0;
														bool flag = false;
														List<int> cellsImpact = CS$<>8__locals1.$VB$Local_spell.getCellsImpact(cell5.Id, cell6.Id, this.bot().map, fighter.cellId);
														try
														{
															foreach (int v in cellsImpact)
															{
																Fighter fighterByCellId = this.bot().Fight.getFighterByCellId(v);
																if (fighterByCellId != null && !fighterByCellId.dead)
																{
																	if (fighterByCellId.team != fighter.team)
																	{
																		num8 = -10;
																		break;
																	}
																	num8 += 10;
																	num8 = (int)Math.Round(unchecked((double)num8 - num5));
																	flag = (fighterByCellId.id == fighter.id);
																}
															}
														}
														finally
														{
															List<int>.Enumerator enumerator3;
															((IDisposable)enumerator3).Dispose();
														}
														if (flag && num8 >= num4)
														{
															num4 = num8;
															int_1 = cell6.Id;
															id = cell5.Id;
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
								if (id != cell.Id)
								{
									this.bot().movement.SeDeplacer(id, -1);
									return true;
								}
								if (int_1 > 0)
								{
									this.bot().spellHandler.EquipeSort(CS$<>8__locals1.$VB$Local_spell.id, false);
									this.bot().Fight.LaunchSpell(CS$<>8__locals1.$VB$Local_spell.id, int_1, Conversions.ToInteger(this.object_1));
									this.object_1 = 0;
									this.lastDestCell = int_1;
									string_0 += " lancer !";
									return true;
								}
								return false;
							}
						}
						else
						{
							string_0 += " pas assez de pa";
						}
						result = false;
					}
					else
					{
						string_0 = string_0 + "  cooldown non achevé  tours restants :" + Conversions.ToString((int)CS$<>8__locals1.$VB$Local_spell.interval - (this.bot().Fight.nbTour - this.list_0.Last((LaunchedSpells s) => s.spell == CS$<>8__locals1.$VB$Local_spell.id).Tour));
						result = false;
					}
				}
				return result;
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00003B0D File Offset: 0x00001D0D
		public void AddSpellLaunch(int spell, int cellId)
		{
			this.list_0.Add(new LaunchedSpells(this.bot().Fight.nbTour, spell, this.bot().Fight.getFighterByCellId(cellId)));
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00019BC4 File Offset: 0x00017DC4
		private bool method_10(SpellLevelDescription spellLevelDescription_0, Fighter fighter_0)
		{
			bool result;
			if ((from i in this.list_0
			where i.spell == spellLevelDescription_0.id && i.Tour == this.bot().Fight.nbTour
			select i).Count<LaunchedSpells>() < (int)((spellLevelDescription_0.nbLancerTour <= 0) ? 1000 : spellLevelDescription_0.nbLancerTour) && (this.list_0.FirstOrDefault((LaunchedSpells s) => s.spell == spellLevelDescription_0.id) == null || checked(this.bot().Fight.nbTour - this.list_0.Last((LaunchedSpells s) => s.spell == spellLevelDescription_0.id).Tour) >= (int)spellLevelDescription_0.interval))
			{
				if (spellLevelDescription_0.nbLancerCible > 0 && fighter_0 != null)
				{
					int num = (from i in this.list_0
					where i.spell == spellLevelDescription_0.id && i.Tour == this.bot().Fight.nbTour && i.target.id == fighter_0.id
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

		// Token: 0x0600031F RID: 799 RVA: 0x00019CDC File Offset: 0x00017EDC
		public void goToPlacement()
		{
			this.list_0 = new List<LaunchedSpells>();
			if (this.StartPlacement != null)
			{
				if (this.StartPlacement.Contains("Eloignée"))
				{
					this.method_3();
				}
				else if (this.StartPlacement.Contains("Proche"))
				{
					this.method_2();
				}
				else if (this.StartPlacement.Contains("Hasardeux"))
				{
					this.method_4();
				}
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00019D4C File Offset: 0x00017F4C
		public List<NextTourPosition> LoadNextTourEnnemiesPosition()
		{
			checked
			{
				List<NextTourPosition> result;
				try
				{
					Fighter fighter = this.bot().Fight.myFighter();
					byte team = fighter.team;
					List<NextTourPosition> list = new List<NextTourPosition>();
					List<Cell> mapDataActuel = this.bot().map.mapDataActuel;
					try
					{
						foreach (Fighter fighter2 in this.bot().Fight.getFightersByTeam((team == 0) ? 1 : 0))
						{
							NextTourPosition nextTourPosition = new NextTourPosition();
							nextTourPosition.enemie = fighter2;
							if (!fighter2.dead)
							{
								try
								{
									foreach (Fighter fighter3 in this.bot().Fight.getFightersByTeam((int)team).ToList<Fighter>())
									{
										if (!fighter3.dead)
										{
											uint num = (uint)mapDataActuel[fighter3.cellId].ManhattanDistanceTo(mapDataActuel[fighter2.cellId]);
											if (unchecked((ulong)num < (ulong)((long)nextTourPosition.distance)))
											{
												nextTourPosition.distance = (int)num;
												nextTourPosition.allie = fighter3;
											}
										}
									}
								}
								finally
								{
									List<Fighter>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
							}
							if (nextTourPosition.allie != null)
							{
								PathFinding pathFinding = new PathFinding(this.bot().map, this.bot().Fight, this.bot().monId);
								Cell cell = mapDataActuel[nextTourPosition.allie.cellId];
								IEnumerable<Cell> adjacentCells = cell.GetAdjacentCells(true, false, 1);
								Cell cell2 = null;
								int num2 = 999;
								try
								{
									foreach (Cell cell3 in adjacentCells)
									{
										int num3 = cell3.ManhattanDistanceTo(mapDataActuel[fighter2.cellId]);
										if (num3 < num2)
										{
											num2 = num3;
											cell2 = cell3;
										}
									}
								}
								finally
								{
									IEnumerator<Cell> enumerator3;
									if (enumerator3 != null)
									{
										enumerator3.Dispose();
									}
								}
								List<Cell> list2 = pathFinding.FindPath(nextTourPosition.enemie.cellId, cell2.Id);
								if (list2 != null && list2.Count > 0)
								{
									nextTourPosition.distanceFinal = list2.Count - nextTourPosition.enemie.MP;
									if (nextTourPosition.distance < 1)
									{
										nextTourPosition.distance = 1;
									}
									if (list2.Count > nextTourPosition.enemie.MP)
									{
										list2 = list2.Take(nextTourPosition.enemie.MP).ToList<Cell>();
									}
									nextTourPosition.finalCell = list2.LastOrDefault<Cell>();
								}
								else
								{
									nextTourPosition.finalCell = mapDataActuel[nextTourPosition.enemie.cellId];
								}
								list.Add(nextTourPosition);
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
					result = list;
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
				return result;
			}
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0001A074 File Offset: 0x00018274
		public bool goToRangeNextTour()
		{
			Fighter fighter = this.bot().Fight.myFighter();
			checked
			{
				bool result;
				if (fighter.MP == 0)
				{
					result = false;
				}
				else
				{
					List<NextTourPosition> list = this.LoadNextTourEnnemiesPosition();
					Cell cell = this.bot().map.mapDataActuel[fighter.cellId];
					int num = 999;
					Fighter enemie;
					try
					{
						foreach (NextTourPosition nextTourPosition in list)
						{
							if (nextTourPosition.distance == 1)
							{
								return false;
							}
							int num2 = nextTourPosition.distanceFinal - fighter.int_1;
							if (num > num2)
							{
								num = num2;
								enemie = nextTourPosition.enemie;
							}
						}
					}
					finally
					{
						List<NextTourPosition>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					if (num > 1)
					{
						result = this.method_7(enemie, num - 1);
					}
					else
					{
						result = (num < 0 && this.method_6(Math.Abs(num)));
					}
				}
				return result;
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0001A168 File Offset: 0x00018368
		public bool visibility(Cell cell1, Cell cell2)
		{
			checked
			{
				bool result;
				try
				{
					IA._Closure$__37-0 CS$<>8__locals1 = new IA._Closure$__37-0(CS$<>8__locals1);
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
						Cell cell3 = this.bot().map.mapDataActuel.FirstOrDefault((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = ((Cell c) => c.X == CS$<>8__locals1.$VB$Local_x && c.Y == CS$<>8__locals1.$VB$Local_y)) : CS$<>8__locals1.$I0);
						Fighter fighterByCellId = this.bot().Fight.getFighterByCellId(cell3.Id);
						if (cell3 == null || !cell3.bool_5 || (fighterByCellId != null && !fighterByCellId.dead))
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
				catch (Exception ex)
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x040003A6 RID: 934
		public int index;

		// Token: 0x040003A7 RID: 935
		private static Random random_0;

		// Token: 0x040003A8 RID: 936
		public List<Actions> ActionsFight;

		// Token: 0x040003A9 RID: 937
		public List<Condition> ConditionsFight;

		// Token: 0x040003AA RID: 938
		public string StartPlacement;

		// Token: 0x040003AB RID: 939
		private List<LaunchedSpells> list_0;

		// Token: 0x040003AC RID: 940
		private object object_0;

		// Token: 0x040003AD RID: 941
		private int int_0;

		// Token: 0x040003AE RID: 942
		private List<int> list_1;

		// Token: 0x040003AF RID: 943
		private List<int> list_2;

		// Token: 0x040003B0 RID: 944
		private object object_1;

		// Token: 0x040003B1 RID: 945
		public int lastSpellLaunchId;

		// Token: 0x040003B2 RID: 946
		public int lastDestCell;
	}
}
