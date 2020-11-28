using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000103 RID: 259
	public class trajetManager
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x00004E1C File Offset: 0x0000301C
		static trajetManager()
		{
			Class15.XRATSHnz66atd();
			trajetManager.random_0 = new Random();
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000542 RID: 1346 RVA: 0x00029C38 File Offset: 0x00027E38
		// (remove) Token: 0x06000543 RID: 1347 RVA: 0x00029C70 File Offset: 0x00027E70
		public event trajetManager.IsMovingEventHandler IsMoving
		{
			[CompilerGenerated]
			add
			{
				trajetManager.IsMovingEventHandler isMovingEventHandler = this.isMovingEventHandler_0;
				trajetManager.IsMovingEventHandler isMovingEventHandler2;
				do
				{
					isMovingEventHandler2 = isMovingEventHandler;
					trajetManager.IsMovingEventHandler value2 = (trajetManager.IsMovingEventHandler)Delegate.Combine(isMovingEventHandler2, value);
					isMovingEventHandler = Interlocked.CompareExchange<trajetManager.IsMovingEventHandler>(ref this.isMovingEventHandler_0, value2, isMovingEventHandler2);
				}
				while (isMovingEventHandler != isMovingEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				trajetManager.IsMovingEventHandler isMovingEventHandler = this.isMovingEventHandler_0;
				trajetManager.IsMovingEventHandler isMovingEventHandler2;
				do
				{
					isMovingEventHandler2 = isMovingEventHandler;
					trajetManager.IsMovingEventHandler value2 = (trajetManager.IsMovingEventHandler)Delegate.Remove(isMovingEventHandler2, value);
					isMovingEventHandler = Interlocked.CompareExchange<trajetManager.IsMovingEventHandler>(ref this.isMovingEventHandler_0, value2, isMovingEventHandler2);
				}
				while (isMovingEventHandler != isMovingEventHandler2);
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00029CA8 File Offset: 0x00027EA8
		public trajetManager(string _trajetData, int targetId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Lines = new List<LineTrajet>();
			this.name = "";
			this.autor = "unknow";
			this.location = "unknow";
			this.type = "unknow";
			this.version = "";
			this.Dialog = new List<string>();
			this.hasBankLine = false;
			this.containsBank = false;
			this.autop = new Autopath();
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.targetId = targetId;
			this.ChangeTrajet(_trajetData);
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x00029D4C File Offset: 0x00027F4C
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00029D68 File Offset: 0x00027F68
		public bool ChangeTrajet(string _trajetData = "")
		{
			if (Operators.CompareString(_trajetData, "", false) == 0)
			{
				_trajetData = this.LasttrajetData;
			}
			this.LasttrajetData = _trajetData;
			string text = this.method_0(_trajetData.Split(new string[]
			{
				"\r\n",
				"\n",
				"\r"
			}, StringSplitOptions.None));
			bool result;
			if (!string.IsNullOrWhiteSpace(text))
			{
				Interaction.MsgBox(text, MsgBoxStyle.OkOnly, null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00029DDC File Offset: 0x00027FDC
		private string method_0(string[] string_0)
		{
			this.hasBankLine = false;
			checked
			{
				string result;
				if (string_0.Length == 0)
				{
					result = "Erreur, trajet vide";
				}
				else
				{
					bool flag = false;
					bool bank = false;
					bool flag2 = false;
					bool onlymove = false;
					bool ignoregroupe = false;
					int num = 0;
					this.type = "";
					this.name = "Unknow";
					this.location = "Unknow";
					this.Dialog.Clear();
					this.Lines.Clear();
					this.autop.destCoord = new Point(1000, 1000);
					try
					{
						List<Condition> list = new List<Condition>();
						foreach (string text in string_0)
						{
							num++;
							bool flag3 = (text.Contains("<") && text.Contains(">")) || text.Contains("#") || text.Contains("@") || text.Contains("Condition");
							if (Operators.CompareString(text.Replace("\r", "").Replace("\n", "").Replace(" ", ""), "", false) != 0)
							{
								if (text.Contains("<Move"))
								{
									onlymove = text.Contains("onlymove");
									ignoregroupe = text.Contains("ignoregroup");
									flag = false;
									bank = false;
									flag2 = false;
									list = new List<Condition>();
								}
								if (text.Contains("<Fight"))
								{
									onlymove = text.Contains("onlymove");
									ignoregroupe = text.Contains("ignoregroup");
									flag = true;
									bank = false;
									flag2 = false;
									list = new List<Condition>();
								}
								if (text.Contains("<Bank"))
								{
									onlymove = text.Contains("onlymove");
									ignoregroupe = text.Contains("ignoregroup");
									flag = false;
									bank = true;
									flag2 = false;
									list = new List<Condition>();
									if (Conversions.ToBoolean(Operators.NotObject(this.hasBankLine)))
									{
										this.hasBankLine = true;
									}
								}
								if (text.Contains("<Dialog"))
								{
									onlymove = text.Contains("onlymove");
									ignoregroupe = text.Contains("ignoregroup");
									flag = false;
									bank = false;
									flag2 = true;
									list = new List<Condition>();
								}
								if (text.Contains("NAME"))
								{
									this.name = text.Replace("@NAME ", "").Replace("\n", "").Replace("\r", "");
								}
								if (text.Contains("LOCATION"))
								{
									this.location = text.Replace("@LOCATION ", "").Replace("\n", "").Replace("\r", "");
								}
								if (text.Contains("AUTHOR"))
								{
									this.autor = text.Replace("@AUTHOR ", "").Replace("\n", "").Replace("\r", "");
								}
								if (text.Contains("VERSION"))
								{
									this.version = text.Replace("@VERSION ", "").Replace("\n", "").Replace("\r", "");
								}
								if (text.Contains("TYPE"))
								{
									this.type = text.Replace("@TYPE ", "").Replace("\n", "").Replace("\r", "");
								}
								if (text.Contains("Condition"))
								{
									int num2 = 0;
									string text2;
									if (text.Contains("> ou ="))
									{
										num2 = text.IndexOf(">");
										text2 = "> ou =";
									}
									else if (text.Contains("< ou ="))
									{
										num2 = text.IndexOf("<");
										text2 = "< ou =";
									}
									else if (text.Contains(">"))
									{
										num2 = text.IndexOf(">");
										text2 = ">";
									}
									else if (text.Contains("<"))
									{
										num2 = text.IndexOf("<");
										text2 = "<";
									}
									else if (text.Contains("="))
									{
										text2 = "=";
										num2 = text.IndexOf("=");
									}
									list.Add(new Condition(this.targetId, "", text.Substring(0, num2).Replace("Condition ", ""), text2 ?? "", int.Parse(text.Substring(num2 + text2.Length))));
								}
								object obj = null;
								int num3 = -1;
								if (!flag3)
								{
									if (flag2)
									{
										this.Dialog.AddRange(text.Split(new char[]
										{
											'|'
										}, StringSplitOptions.RemoveEmptyEntries).Select((trajetManager._Closure$__.$I23-0 == null) ? (trajetManager._Closure$__.$I23-0 = ((string d) => d.Replace("\r", ""))) : trajetManager._Closure$__.$I23-0));
									}
									else if (text.Contains("["))
									{
										string[] array = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1).Split(new char[]
										{
											','
										});
										obj = new Point(int.Parse(array[0]), int.Parse(array[1]));
									}
									else
									{
										int.TryParse(text.Substring(0, text.IndexOf(" ") + 1), out num3);
									}
									if (obj != null || num3 != -1)
									{
										bool flag4 = true;
										foreach (string text3 in text.Split(new string[]
										{
											"=>"
										}, StringSplitOptions.None))
										{
											LineTrajet lineTrajet = new LineTrajet();
											lineTrajet.Fight = (flag || text3.Contains("fight"));
											lineTrajet.Bank = bank;
											lineTrajet.Coords = ((obj == null) ? new Point(-1000, 1000) : ((Point)obj));
											lineTrajet.mapId = num3;
											if (lineTrajet.Coords.X == -1000 && lineTrajet.mapId != -1)
											{
												lineTrajet.Coords = Loader.getMapById(lineTrajet.mapId).point;
											}
											if (text3.Contains("code"))
											{
												lineTrajet.secureCode = text3.Substring(text3.IndexOf("code") + 4).Replace("\r", "").Replace("\n", "").Replace(" ", "");
											}
											if (text3.Contains("drago"))
											{
												lineTrajet.drago = true;
											}
											if (text3.Contains("loadia"))
											{
												string text4 = text3.Substring(text3.IndexOf("loadia") + 7);
												lineTrajet.IA = text4.Substring(0, text4.IndexOf(")")).Split(new char[]
												{
													','
												}).ToList<string>();
												if (!File.Exists(Application.StartupPath + "/ia/" + lineTrajet.IA.First<string>()) || lineTrajet.IA.Count == 0)
												{
													return string.Concat(new string[]
													{
														"Trajet invalide , ligne n°",
														Conversions.ToString(num),
														"\r\n synthaxe incorrect: ",
														string_0[num],
														"\r\nErreur technique : l'ia ",
														lineTrajet.IA.First<string>(),
														" n'est pas présente dans le repertoire ia du bot"
													});
												}
											}
											if (text3.Contains("useitem"))
											{
												lineTrajet.itemToUse = text3.Substring(text3.IndexOf("useitem") + 7).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).Select((trajetManager._Closure$__.$I23-1 == null) ? (trajetManager._Closure$__.$I23-1 = ((string s) => int.Parse(s))) : trajetManager._Closure$__.$I23-1).ToArray<int>();
											}
											if (text3.Contains("sellitems"))
											{
												lineTrajet.sellsItems = text3.Substring(text3.IndexOf("sellitems") + 9).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).Select((trajetManager._Closure$__.$I23-2 == null) ? (trajetManager._Closure$__.$I23-2 = ((string s) => s.Split(new char[]
												{
													':'
												}))) : trajetManager._Closure$__.$I23-2).ToDictionary((trajetManager._Closure$__.$I23-3 == null) ? (trajetManager._Closure$__.$I23-3 = ((string[] k) => int.Parse(k[0]))) : trajetManager._Closure$__.$I23-3, (trajetManager._Closure$__.$I23-4 == null) ? (trajetManager._Closure$__.$I23-4 = ((string[] k) => new int[]
												{
													(k.Length > 1) ? int.Parse(k[1]) : -1,
													(k.Length > 2) ? int.Parse(k[2]) : -1
												})) : trajetManager._Closure$__.$I23-4);
											}
											if (text3.Contains("buyitems"))
											{
												lineTrajet.buyItems = text3.Substring(text3.IndexOf("buyitems") + 8).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).Select((trajetManager._Closure$__.$I23-5 == null) ? (trajetManager._Closure$__.$I23-5 = ((string s) => s.Split(new char[]
												{
													':'
												}))) : trajetManager._Closure$__.$I23-5).ToDictionary((trajetManager._Closure$__.$I23-6 == null) ? (trajetManager._Closure$__.$I23-6 = ((string[] k) => int.Parse(k[0]))) : trajetManager._Closure$__.$I23-6, (trajetManager._Closure$__.$I23-7 == null) ? (trajetManager._Closure$__.$I23-7 = ((string[] k) => new int[]
												{
													int.Parse(k[1]),
													(k.Length > 2) ? int.Parse(k[2]) : -1
												})) : trajetManager._Closure$__.$I23-7);
											}
											if (text3.Contains("takeitems"))
											{
												List<int> list2 = text3.Substring(text3.IndexOf("takeitems") + 9).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).Select((trajetManager._Closure$__.$I23-8 == null) ? (trajetManager._Closure$__.$I23-8 = ((string d) => int.Parse(d))) : trajetManager._Closure$__.$I23-8).ToList<int>();
												lineTrajet.TakeItems = new Dictionary<int, int>();
												int num4 = list2.Count - 1;
												for (int l = 0; l <= num4; l += 2)
												{
													lineTrajet.TakeItems.Add(list2[l], list2[l + 1]);
												}
											}
											if (text3.Contains("zaap"))
											{
												lineTrajet.destMapId = int.Parse(text3.Substring(text3.IndexOf("zaap") + 4).Replace("(", "").Replace(")", ""));
											}
											if (text3.Contains("equipeitems"))
											{
												lineTrajet.equipeItems = text3.Substring(text3.IndexOf("equipeitems") + 11).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).Select((trajetManager._Closure$__.$I23-9 == null) ? (trajetManager._Closure$__.$I23-9 = ((string d) => int.Parse(d))) : trajetManager._Closure$__.$I23-9).ToList<int>();
											}
											if (text3.Contains("droite"))
											{
												lineTrajet.neighBours.Add(new KeyValuePair<MapNeighbour, int>(MapNeighbour.Right, text3.Contains("droite(") ? int.Parse(text3.Substring(text3.IndexOf("droite") + 6).Substring(0, text3.Substring(text3.IndexOf("droite") + 6).IndexOf(")")).Replace("(", "").Replace(")", "")) : -1));
											}
											if (text3.Contains("gauche"))
											{
												lineTrajet.neighBours.Add(new KeyValuePair<MapNeighbour, int>(MapNeighbour.Left, text3.Contains("gauche(") ? int.Parse(text3.Substring(text3.IndexOf("gauche") + 6).Substring(0, text3.Substring(text3.IndexOf("gauche") + 6).IndexOf(")")).Replace("(", "").Replace(")", "")) : -1));
											}
											if (text3.Contains("haut"))
											{
												lineTrajet.neighBours.Add(new KeyValuePair<MapNeighbour, int>(MapNeighbour.Top, text3.Contains("haut(") ? int.Parse(text3.Substring(text3.IndexOf("haut") + 4).Substring(0, text3.Substring(text3.IndexOf("haut") + 4).IndexOf(")")).Replace("(", "").Replace(")", "")) : -1));
											}
											if (text3.Contains("bas"))
											{
												lineTrajet.neighBours.Add(new KeyValuePair<MapNeighbour, int>(MapNeighbour.Bottom, text3.Contains("bas(") ? int.Parse(text3.Substring(text3.IndexOf("bas") + 3).Substring(0, text3.Substring(text3.IndexOf("bas") + 3).IndexOf(")")).Replace("(", "").Replace(")", "")) : -1));
											}
											else if (text3.Contains("npc"))
											{
												if (text3.IndexOf(")") != -1)
												{
													int.TryParse(text3.Substring(text3.IndexOf("npc") + 3, text3.IndexOf(")") - (text3.IndexOf("npc") + 3)).Replace("(", "").Replace(")", ""), out lineTrajet.npcToTalke);
												}
												if (lineTrajet.npcToTalke == 0 || lineTrajet.npcToTalke == -123456)
												{
													lineTrajet.npcToTalke = -84848;
												}
											}
											else if (text3.Contains("craft"))
											{
												lineTrajet.Craft = true;
											}
											else if (text3.Contains("use"))
											{
												string text5 = text3.Substring(text3.IndexOf("use") + 3);
												string[] array3 = text5.Substring(0, text5.IndexOf(")") + 1).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												});
												int.TryParse(array3[0], out lineTrajet.ioToUse);
												if (lineTrajet.ioToUse == 0)
												{
													lineTrajet.ioToUse = -123456;
												}
												if (array3.Length > 1)
												{
													int.TryParse(array3[1], out lineTrajet.skillToUse);
												}
											}
											else if (text3.Contains("autopath"))
											{
												string[] array4 = text3.Substring(text3.IndexOf("autopath") + 8).Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("[", "").Replace("]", "").Split(new char[]
												{
													','
												}).ToArray<string>();
												lineTrajet.autoPathCoords = new Point(int.Parse(array4[0]), int.Parse(array4[1]));
											}
											else if (text3.Contains("reconnect"))
											{
												string text6 = text3.Substring(text3.IndexOf("reconnect") + 9);
												int value = 1;
												int key = 0;
												string[] array5 = text6.Substring(0, text6.IndexOf(")") + 1).Replace("(", "").Replace(")", "").Split(new char[]
												{
													','
												}).ToArray<string>();
												int.TryParse(array5[0], out key);
												if (array5.Length > 1)
												{
													int.TryParse(array5[1], out value);
												}
												lineTrajet.reconnect = new KeyValuePair<int, int>(key, value);
											}
											else if (text3.Contains("end"))
											{
												lineTrajet.end = true;
											}
											else if (text3.Contains("wait"))
											{
												string s2 = text3.Substring(text3.IndexOf("wait") + 4);
												lineTrajet.wait = int.Parse(s2);
											}
											else
											{
												string[] array6 = text3.Split(new char[]
												{
													' '
												});
												if (array6.Count<string>() > 1)
												{
													int.TryParse(array6[1], out lineTrajet.destCell);
												}
												else
												{
													int.TryParse(array6[0], out lineTrajet.destCell);
												}
												if (lineTrajet.destCell == 0)
												{
													lineTrajet.destCell = -123456;
												}
											}
											lineTrajet.ignoregroupe = ignoregroupe;
											lineTrajet.onlymove = onlymove;
											lineTrajet.conditions = list;
											if (flag4)
											{
												this.Lines.Add(lineTrajet);
												flag4 = false;
											}
											else
											{
												this.Lines.Last<LineTrajet>().subSteps.Add(lineTrajet);
											}
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						return string.Concat(new string[]
						{
							"Trajet invalide , ligne n°",
							Conversions.ToString(num),
							"\r\n synthaxe incorrect: ",
							string_0[num - 1],
							"\r\n erreur technique  : ",
							ex.Message
						});
					}
					result = "";
				}
				return result;
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00004E2D File Offset: 0x0000302D
		public void Stop()
		{
			this.bot.mode = -1;
			this.bot.MovementTrajet = null;
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0002B008 File Offset: 0x00029208
		public KeyValuePair<LineTrajet, bool> currentLine
		{
			get
			{
				if (this.keyValuePair_0.Key == null)
				{
					this.method_1();
				}
				return this.keyValuePair_0;
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0002B034 File Offset: 0x00029234
		private void method_1()
		{
			Maps currentMap = this.bot.map;
			Point Coords = currentMap.position;
			int num = checked((int)Math.Round((double)(this.bot.Inventaire.podsactual + 1) / (double)(this.bot.Inventaire.podsMax + 1)));
			bool flag = Operators.CompareString(this.type.ToLower(), "artisanat", false) == 0;
			bool needbank = (double)this.bot.config.PodsReturnBank <= (double)this.bot.Inventaire.podsactual / (double)this.bot.Inventaire.podsMax * 100.0;
			if (flag)
			{
				needbank = ((from ResultId in this.bot.config.listItemToCrafts
				where this.bot.Inventaire.method_0(this.bot, Loader.Crafts[ResultId]) > 0
				select ResultId).Count<int>() == 0);
			}
			needbank = Conversions.ToBoolean(needbank && Conversions.ToBoolean(this.hasBankLine));
			LineTrajet lineTrajet = this.Lines.FirstOrDefault((LineTrajet c) => c != null && c.Bank == needbank && c.mapId == currentMap.id && c.conditions.FirstOrDefault((trajetManager._Closure$__.$I29-2 == null) ? (trajetManager._Closure$__.$I29-2 = ((Condition cond) => !cond.isOk(null))) : trajetManager._Closure$__.$I29-2) == null);
			if (lineTrajet == null)
			{
				lineTrajet = this.Lines.FirstOrDefault((LineTrajet c) => c != null && c.Bank == needbank && c.Coords.X == Coords.X && c.Coords.Y == Coords.Y && c.mapId == -1 && c.conditions.FirstOrDefault((trajetManager._Closure$__.$I29-4 == null) ? (trajetManager._Closure$__.$I29-4 = ((Condition cond) => !cond.isOk(null))) : trajetManager._Closure$__.$I29-4) == null);
			}
			this.keyValuePair_0 = new KeyValuePair<LineTrajet, bool>(lineTrajet, needbank);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0002B19C File Offset: 0x0002939C
		public void Update()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				lock (obj)
				{
					if (this.bot.map == null || this.bot.map.myActor() == null)
					{
						this.bot.chatHandler.AddTextChat("Cannot process action, is iddle or mapAcot is nothing", "debug");
					}
					else
					{
						Maps map = this.bot.map;
						if (map != null)
						{
							this.method_1();
							bool flag2 = this.bot.get_Slave(true).Count == 0 && Declarations.get_MyChef(this.targetId) != null;
							LineTrajet lineTrajet = this.currentLine.Key;
							bool value = this.currentLine.Value;
							if (!map.AllSlavesInMap())
							{
								this.bot.chatHandler.AddTextChat("Exit mules not on map", "debug");
							}
							else if (lineTrajet != null)
							{
								lineTrajet = lineTrajet.getCurrentStep();
								this.autop.Ending(this.bot);
								this.bot.ExchangeManager.SecureCode = lineTrajet.secureCode;
								this.bot.ExchangeManager.BuyItems = lineTrajet.buyItems;
								this.bot.ExchangeManager.SellItems = lineTrajet.sellsItems;
								this.bot.ExchangeManager.TakeItems = lineTrajet.TakeItems;
								this.bot.ExchangeManager.destmapid = lineTrajet.destMapId;
								if (lineTrajet.drago)
								{
									this.bot.Send(new Message("Rr", 0, false, true, true));
								}
								if (lineTrajet.IA.Count > 1)
								{
									string text = lineTrajet.IA.First<string>();
									try
									{
										foreach (string text2 in lineTrajet.IA.Skip(1))
										{
											Perso comtpesByName = Declarations.getComtpesByName(text2);
											if (comtpesByName != null && Operators.CompareString(comtpesByName.config.IaName, text, false) != 0)
											{
												comtpesByName.ia = IA.LoadIA(comtpesByName.monId, File.ReadAllText(Application.StartupPath + "\\ia\\" + text));
												comtpesByName.config.IaName = text;
											}
										}
									}
									finally
									{
										IEnumerator<string> enumerator;
										if (enumerator != null)
										{
											enumerator.Dispose();
										}
									}
								}
								if (lineTrajet.itemToUse != null)
								{
									Objets objectById = this.bot.Inventaire.getObjectById(lineTrajet.itemToUse[0]);
									if (objectById != null)
									{
										this.bot.useItem((int)objectById.idObjetInv, (lineTrajet.itemToUse.Length > 1) ? lineTrajet.itemToUse[1] : 1);
										this.bot.launcher.waitAction = 5000;
										try
										{
											foreach (int id in this.bot.get_Slave(true))
											{
												Perso comtpesById = Declarations.getComtpesById(id);
												if (!Information.IsNothing(comtpesById))
												{
													Objets objectById2 = comtpesById.Inventaire.getObjectById(lineTrajet.itemToUse[0]);
													if (!Information.IsNothing(objectById2))
													{
														comtpesById.useItem((int)objectById2.idObjetInv, (lineTrajet.itemToUse.Length > 1) ? lineTrajet.itemToUse[1] : 1);
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
								else if (lineTrajet.equipeItems.Count > 0)
								{
									int num = 10;
									try
									{
										foreach (int itemId in lineTrajet.equipeItems)
										{
											num += 400;
											this.bot.Inventaire.EquipeItem(itemId, num);
											try
											{
												foreach (int id2 in this.bot.get_Slave(true))
												{
													Perso comtpesById2 = Declarations.getComtpesById(id2);
													if (!Information.IsNothing(comtpesById2))
													{
														comtpesById2.Inventaire.EquipeItem(itemId, num);
													}
												}
											}
											finally
											{
												List<int>.Enumerator enumerator4;
												((IDisposable)enumerator4).Dispose();
											}
										}
									}
									finally
									{
										List<int>.Enumerator enumerator3;
										((IDisposable)enumerator3).Dispose();
									}
								}
								else if (!lineTrajet.Fight || !Conversions.ToBoolean(this.bot.CheckFight()))
								{
									this.bot.movement.destAction = "";
									if (!value && !lineTrajet.onlymove && this.bot.interactiveManager.Use(-1, 0))
									{
										this.bot.launcher.waitAction = 1000;
									}
									else
									{
										if (lineTrajet.neighBours.Count > 0)
										{
											int index = trajetManager.random_0.Next(lineTrajet.neighBours.Count);
											if (this.bot.movement.MoveMapDirection(lineTrajet.neighBours[index].Key, false, null).Key)
											{
												return;
											}
										}
										if (lineTrajet.ioToUse != -123456)
										{
											this.bot.interactiveManager.Use(lineTrajet.ioToUse, lineTrajet.skillToUse);
											this.bot.launcher.waitAction = 2500;
											try
											{
												foreach (int id3 in this.bot.get_Slave(true))
												{
													Perso comtpesById3 = Declarations.getComtpesById(id3);
													if (!Information.IsNothing(comtpesById3))
													{
														comtpesById3.interactiveManager.Use(lineTrajet.ioToUse, lineTrajet.skillToUse);
													}
												}
											}
											finally
											{
												List<int>.Enumerator enumerator5;
												((IDisposable)enumerator5).Dispose();
											}
										}
										else
										{
											if ((lineTrajet.buyItems != null && lineTrajet.buyItems.Count > 0) || (lineTrajet.sellsItems != null && lineTrajet.sellsItems.Count > 0))
											{
												this.bot.ExchangeManager.launcHDV();
											}
											if (lineTrajet.destCell > 0)
											{
												this.bot.movement.SeDeplacer(lineTrajet.destCell, -1);
											}
											if (lineTrajet.npcToTalke != -123456)
											{
												this.bot.ExchangeManager.SpeekNpc(lineTrajet.npcToTalke, this.Dialog);
											}
											else
											{
												if (lineTrajet.autoPathCoords.X != -12345)
												{
													this.autop.destCoord = lineTrajet.autoPathCoords;
													this.autop.fight = lineTrajet.Fight;
													this.autop.onlyMove = lineTrajet.onlymove;
													this.autop.update(this.bot);
												}
												if (lineTrajet.end)
												{
													this.bot.MovementTrajet.End();
												}
												if (lineTrajet.reconnect.Value != default(KeyValuePair<int, int>).Value)
												{
													if (this.bot.status.connexion == status.ConnexionStatus.const_3)
													{
														this.bot.sock.Connexion(false);
														this.bot.sock = null;
													}
													this.bot.socket.Connexion(false);
													this.bot.socket = null;
													Thread thread = new Thread(delegate()
													{
														Thread.Sleep(2500);
														this.bot.errorDeco = true;
														this.bot.CreateSocket(false);
													});
													thread.Start();
												}
												if (lineTrajet.wait > 0)
												{
													this.bot.launcher.waitAction = lineTrajet.wait;
												}
											}
										}
									}
								}
							}
							else if (!flag2)
							{
								this.autop.update(this.bot);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0002B9F4 File Offset: 0x00029BF4
		public void End()
		{
			this.bot.mode = -1;
			this.autop.Ending(this.bot);
			this.Lines.Clear();
			this.type = "";
			this.name = "";
			this.location = "";
		}

		// Token: 0x04000568 RID: 1384
		public int targetId;

		// Token: 0x04000569 RID: 1385
		public List<LineTrajet> Lines;

		// Token: 0x0400056A RID: 1386
		public string name;

		// Token: 0x0400056B RID: 1387
		public string autor;

		// Token: 0x0400056C RID: 1388
		public string location;

		// Token: 0x0400056D RID: 1389
		public string type;

		// Token: 0x0400056E RID: 1390
		public string version;

		// Token: 0x0400056F RID: 1391
		public List<string> Dialog;

		// Token: 0x04000570 RID: 1392
		public object hasBankLine;

		// Token: 0x04000571 RID: 1393
		public bool containsBank;

		// Token: 0x04000572 RID: 1394
		public Autopath autop;

		// Token: 0x04000573 RID: 1395
		public string LasttrajetData;

		// Token: 0x04000574 RID: 1396
		private static Random random_0;

		// Token: 0x04000575 RID: 1397
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private trajetManager.IsMovingEventHandler isMovingEventHandler_0;

		// Token: 0x04000576 RID: 1398
		private object object_0;

		// Token: 0x04000577 RID: 1399
		private KeyValuePair<LineTrajet, bool> keyValuePair_0;

		// Token: 0x02000104 RID: 260
		// (Invoke) Token: 0x06000552 RID: 1362
		public delegate void IsMovingEventHandler(int cell);
	}
}
