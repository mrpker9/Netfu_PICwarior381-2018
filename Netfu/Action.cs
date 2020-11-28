using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000C4 RID: 196
	public class Action
	{
		// Token: 0x06000427 RID: 1063 RVA: 0x00004482 File Offset: 0x00002682
		public Action()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.random_0 = new Random();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001F23C File Offset: 0x0001D43C
		public async void PacketGA(int index, string packet)
		{
			checked
			{
				try
				{
					Perso perso = Declarations.getComtpesByIndex(index);
					string[] datasActions = packet.Split(new char[]
					{
						';'
					});
					int numAction = -1;
					int senderId = -12598;
					int action = -1;
					if (datasActions.Count<string>() > 1 && datasActions[0].Length == 3)
					{
						numAction = Conversion.Val(datasActions[0][2]);
					}
					if (datasActions.Count<string>() > 1)
					{
						action = Conversions.ToInteger(datasActions[1]);
					}
					if (datasActions.Count<string>() > 2 && datasActions[2].Length > 0)
					{
						senderId = Conversions.ToInteger(datasActions[2]);
						if ((double)senderId == Conversions.ToDouble(Declarations.getComtpesByIndex(index).monIdDofus))
						{
							if (numAction != -1)
							{
								Declarations.getComtpesByIndex(index).status.Int32_0 = numAction;
							}
							Declarations.getComtpesByIndex(index).status.currentAction = action;
							if (action != 0)
							{
								this.int_0 = 0;
							}
						}
					}
					else
					{
						senderId = Conversions.ToInteger(Declarations.comptes[index].monIdDofus);
					}
					string[] datas;
					if (datasActions.Count<string>() > 3)
					{
						datas = datasActions[3].Split(new char[]
						{
							','
						});
					}
					int num = action;
					if (num <= 150)
					{
						if (num <= 102)
						{
							switch (num)
							{
							case 0:
								this.int_0++;
								if (this.int_0 > 1 && this.int_0 < 4)
								{
									Declarations.getComtpesByIndex(index).Send(new Message("GKK0", 0, false, true, true));
									goto IL_918;
								}
								if (this.int_0 > 3 && this.int_0 < 5)
								{
									Declarations.getComtpesByIndex(index).Send(new Message("GKK1", 0, false, true, true));
									goto IL_918;
								}
								if (this.int_0 > 5)
								{
									Declarations.getComtpesByIndex(index).Send(new Message("GKK2", 0, false, true, true));
									this.int_0 = 0;
									goto IL_918;
								}
								goto IL_918;
							case 1:
							{
								string cherche = datas[0];
								cherche = Strings.Mid(cherche, cherche.Length - 1);
								int trouve = -1;
								int i = 0;
								do
								{
									if (Operators.CompareString(Declarations.cases[i], cherche, false) == 0)
									{
										trouve = i;
										i = 1025;
									}
									i++;
								}
								while (i <= 1024);
								if (trouve != -1)
								{
									perso.map.method_1(senderId, trouve);
									goto IL_918;
								}
								goto IL_918;
							}
							case 2:
							case 3:
								goto IL_918;
							case 4:
								perso.map.method_1(Conversions.ToInteger(datas[0]), Conversions.ToInteger(datas[1]));
								goto IL_918;
							case 5:
								Declarations.getComtpesByIndex(index).map.method_1((int)Math.Round(Math.Round(Conversion.Val(datas[0]))), (int)Math.Round(Math.Round(Conversion.Val(datas[1]))));
								goto IL_918;
							default:
								if (num == 79)
								{
									goto IL_5D1;
								}
								switch (num)
								{
								case 100:
									break;
								case 101:
								case 102:
									goto IL_64D;
								default:
									goto IL_918;
								}
								break;
							}
						}
						else if (num <= 120)
						{
							switch (num)
							{
							case 108:
							case 110:
								break;
							case 109:
								goto IL_918;
							case 111:
								goto IL_64D;
							default:
								if (num != 120)
								{
									goto IL_918;
								}
								goto IL_64D;
							}
						}
						else
						{
							switch (num)
							{
							case 127:
							case 128:
							case 129:
								goto IL_5D1;
							default:
							{
								if (num != 150)
								{
									goto IL_918;
								}
								int id = Conversions.ToInteger(datas[0]);
								Fighter f = Declarations.getComtpesByIndex(index).Fight.getFighterByid(id);
								if (!Information.IsNothing(f))
								{
									f.invisible = (Conversions.ToDouble(datas[1]) > 0.0);
									goto IL_918;
								}
								goto IL_918;
							}
							}
						}
						int pv = Conversions.ToInteger(datas[1]);
						int id2 = Conversions.ToInteger(datas[0]);
						Fighter f2 = Declarations.getComtpesByIndex(index).Fight.getFighterByid(id2);
						if (!Information.IsNothing(f2))
						{
							Fighter fighter;
							(fighter = f2).LP = fighter.LP + pv;
						}
						if (Declarations.getComtpesByIndex(index).Fight.FighterEnemieAlive() == 0)
						{
							Declarations.getComtpesByIndex(index).MessagesToSend.Clear();
							goto IL_918;
						}
						goto IL_918;
					}
					else if (num <= 300)
					{
						if (num <= 169)
						{
							if (num == 168)
							{
								goto IL_64D;
							}
							if (num != 169)
							{
								goto IL_918;
							}
						}
						else
						{
							if (num == 181)
							{
								string sdata = packet.Substring(packet.IndexOf(Conversions.ToString(senderId) + ";") + (Conversions.ToString(senderId) + ";").Length);
								Declarations.getComtpesByIndex(index).Fight.AddInvocation(senderId, sdata);
								goto IL_918;
							}
							if (num != 300)
							{
								goto IL_918;
							}
							if ((double)senderId == Conversions.ToDouble(perso.monIdDofus))
							{
								perso.ia.AddSpellLaunch(Conversions.ToInteger(datas[0]), Conversions.ToInteger(datas[1]));
								goto IL_918;
							}
							goto IL_918;
						}
					}
					else if (num <= 501)
					{
						if (num != 302)
						{
							if (num != 501)
							{
								goto IL_918;
							}
							if ((double)senderId == Conversions.ToDouble(perso.monIdDofus))
							{
								int tempsDeFauche = Conversions.ToInteger(datas[1]);
								perso.launcher.waitAction = (int)Math.Round(Math.Round((double)(unchecked((float)tempsDeFauche * 0.75f))));
								Declarations.getComtpesByIndex(index).SendGKK((int)Math.Round(Math.Round((double)(unchecked((float)tempsDeFauche * 0.95f)))));
								goto IL_918;
							}
							goto IL_918;
						}
						else
						{
							if ((double)senderId == Conversions.ToDouble(perso.monIdDofus))
							{
								perso.ia.method_0();
								goto IL_918;
							}
							goto IL_918;
						}
					}
					else
					{
						if (num == 900)
						{
							int conf = perso.config.vitesseInvit;
							int time = Fonctions.rand.Next(conf, conf + 500);
							perso.status.enEchange = true;
							perso.Send(new Message("GA902" + datasActions[2], time, true, true, false));
							goto IL_918;
						}
						if (num != 902)
						{
							goto IL_918;
						}
						perso.status.enEchange = false;
						goto IL_918;
					}
					IL_5D1:
					int pm = Conversions.ToInteger(datas[1]);
					int id3 = Conversions.ToInteger(datas[0]);
					Fighter f3 = Declarations.getComtpesByIndex(index).Fight.getFighterByid(id3);
					if (!Information.IsNothing(f3))
					{
						f3.MP += pm;
						goto IL_918;
					}
					goto IL_918;
					IL_64D:
					int pa = Conversions.ToInteger(datas[1]);
					int id4 = Conversions.ToInteger(datas[0]);
					Fighter f4 = Declarations.getComtpesByIndex(index).Fight.getFighterByid(id4);
					if (!Information.IsNothing(f4))
					{
						f4.AP += pa;
					}
					IL_918:
					perso = null;
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					Fonctions.traiterErreur(ex);
				}
			}
		}

		// Token: 0x0400044D RID: 1101
		private Random random_0;

		// Token: 0x0400044E RID: 1102
		private int int_0;
	}
}
