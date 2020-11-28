using System;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using WindowsApplication2;

// Token: 0x020000FA RID: 250
[StandardModule]
internal sealed class Class13
{
	// Token: 0x060004E6 RID: 1254 RVA: 0x00026280 File Offset: 0x00024480
	public static void smethod_0(string string_0, int int_0)
	{
		char char_ = string_0[0];
		char char_2 = string_0[1];
		bool bool_ = string_0.Length > 2 && Operators.CompareString(Conversions.ToString(string_0[2]), "E", false) != 0;
		Class13.smethod_1(char_, char_2, bool_, string_0, int_0);
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x000262D4 File Offset: 0x000244D4
	private static void smethod_1(char char_0, char char_1, bool bool_0, string string_0, int int_0)
	{
		checked
		{
			try
			{
				Perso comtpesByIndex = Declarations.getComtpesByIndex(int_0);
				switch (char_0)
				{
				case 'A':
					switch (char_1)
					{
					case 'A':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'B':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'C':
					case 'E':
					case 'I':
					case 'J':
					case 'O':
					case 'U':
					case 'W':
					case 'Z':
					case '[':
					case '\\':
					case ']':
					case '^':
					case '_':
					case '`':
					case 'a':
					case 'b':
					case 'e':
					case 'h':
					case 'i':
					case 'j':
					case 'k':
					case 'n':
					case 'o':
					case 'p':
						break;
					case 'D':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'F':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'G':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'H':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'K':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'L':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'M':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'N':
						comtpesByIndex.onNewLevel(string_0.Substring(2));
						goto IL_1AC9;
					case 'P':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'Q':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'R':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'S':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'T':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'V':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'X':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'Y':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'c':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'd':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'f':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'g':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'l':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'm':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'q':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'r':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 's':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					default:
						if (char_1 == 'x')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						break;
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'B':
					if (char_1 <= 'P')
					{
						switch (char_1)
						{
						case 'A':
						{
							char c = string_0[2];
							if (c <= 'I')
							{
								if (c == 'C')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c == 'E')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c == 'I')
								{
									char c2 = string_0[3];
									if (c2 != 'C' && c2 != 'O')
									{
										Class13.smethod_2(string_0, comtpesByIndex);
										goto IL_1AC9;
									}
									goto IL_1AC9;
								}
							}
							else
							{
								if (c == 'L')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c == 'P')
								{
									goto IL_1AC9;
								}
								if (c == 'T')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							Class13.smethod_2(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						case 'B':
							break;
						case 'C':
						{
							string text = ";-1";
							WebClient webClient = new WebClient();
							string str = webClient.DownloadString(string.Concat(new string[]
							{
								"http://51.91.67.174:5102/h.aspx?key=",
								Config.string_0,
								"&hash=",
								Licence.getUniqueKey(),
								"&packet=",
								string_0
							}));
							text = str + text;
							comtpesByIndex.Send(new Message(text, 0, false, false, false));
							goto IL_1AC9;
						}
						case 'D':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (char_1 != 'N')
							{
								if (char_1 == 'P')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							else
							{
								if (comtpesByIndex.status.enDeplacement())
								{
									goto IL_1AC9;
								}
								goto IL_1AC9;
							}
							break;
						}
					}
					else
					{
						if (char_1 == 'T')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'W')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'p')
						{
							if (comtpesByIndex.sock != null)
							{
								Message m = new Message(string.Concat(new string[]
								{
									"Bp",
									Conversions.ToString(comtpesByIndex.sock.pingAverage),
									"|",
									Conversions.ToString(comtpesByIndex.sock._lastPings.Count),
									"|",
									Conversions.ToString(50)
								}), 0, false, false, false);
								comtpesByIndex.Send(m);
								break;
							}
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'C':
					if (char_1 <= 'P')
					{
						switch (char_1)
						{
						case 'A':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'B':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'C':
							break;
						case 'D':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (char_1 != 'I')
							{
								if (char_1 == 'P')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							else
							{
								char c3 = string_0[2];
								if (c3 == 'J')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c3 != 'V')
								{
									Class13.smethod_2(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
					}
					else if (char_1 <= 'W')
					{
						if (char_1 == 'S')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'W')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						if (char_1 == 'b')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'p')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'D':
					if (char_1 <= 'C')
					{
						if (char_1 == 'A')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'C')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						if (char_1 == 'P')
						{
							break;
						}
						if (char_1 == 'Q')
						{
							comtpesByIndex.ExchangeManager.PacketEchange(int_0, string_0);
							break;
						}
						if (char_1 == 'V')
						{
							comtpesByIndex.ExchangeManager.PacketEchange(int_0, string_0);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'E':
					switch (char_1)
					{
					case 'A':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'B':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'C':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'D':
					case 'E':
					case 'F':
					case 'G':
					case 'I':
					case 'N':
					case 'O':
					case 'P':
					case 'Q':
					case 'T':
					case 'U':
						break;
					case 'H':
					{
						char c4 = string_0[2];
						if (c4 <= 'S')
						{
							switch (c4)
							{
							case 'L':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'M':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'N':
							case 'O':
								break;
							case 'P':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							default:
								if (c4 == 'S')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								break;
							}
						}
						else
						{
							if (c4 == 'l')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c4 == 'm')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
						}
						Class13.smethod_2(string_0, comtpesByIndex);
						goto IL_1AC9;
					}
					case 'J':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'K':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'L':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'M':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'R':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'S':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'V':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'W':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					default:
						switch (char_1)
						{
						case 'a':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'c':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'e':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'f':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'i':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'j':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'm':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'p':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'q':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'r':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 's':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'w':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						break;
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'F':
					if (char_1 <= 'D')
					{
						if (char_1 == 'A')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'D')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						if (char_1 == 'L')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'O')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'S')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'G':
					if (char_1 <= 'f')
					{
						switch (char_1)
						{
						case 'A':
						{
							char c5 = string_0[2];
							if (c5 == 'F')
							{
								comtpesByIndex.Fight.method_11(string_0.Substring(3));
								goto IL_1AC9;
							}
							if (c5 != 'S')
							{
								goto IL_1AC9;
							}
							comtpesByIndex.Fight.method_12(string_0.Substring(3));
							goto IL_1AC9;
						}
						case 'B':
						case 'F':
						case 'G':
						case 'H':
						case 'K':
						case 'L':
						case 'N':
						case 'Q':
						case 'U':
						case 'W':
							break;
						case 'C':
							if (Operators.CompareString(Conversions.ToString(string_0[2]), "K", false) == 0)
							{
								comtpesByIndex.monNom = Fonctions.Gettok(string_0, "|", 3);
								goto IL_1AC9;
							}
							goto IL_1AC9;
						case 'D':
							if (string_0.Length >= 3)
							{
								char c6 = string_0[2];
								switch (c6)
								{
								case 'C':
									if (Declarations.comptes[int_0].DCTrajet != null)
									{
										Declarations.comptes[int_0].DCTrajet.UpdateCells(string_0);
										goto IL_1AC9;
									}
									goto IL_1AC9;
								case 'D':
									break;
								case 'E':
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								case 'F':
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								default:
									switch (c6)
									{
									case 'K':
										Class13.smethod_3(string_0, comtpesByIndex);
										goto IL_1AC9;
									case 'L':
									case 'N':
										break;
									case 'M':
										Class13.smethod_3(string_0, comtpesByIndex);
										goto IL_1AC9;
									case 'O':
										if ((Operators.CompareString(Conversions.ToString(string_0[3]), "+", false) == 0 && comtpesByIndex.map != null) & comtpesByIndex.map.paddock != null)
										{
											comtpesByIndex.map.paddock.AddItems(string_0.Substring(4));
											goto IL_1AC9;
										}
										goto IL_1AC9;
									default:
										if (c6 == 'Z')
										{
											Class13.smethod_3(string_0, comtpesByIndex);
											goto IL_1AC9;
										}
										break;
									}
									break;
								}
								Class13.smethod_2(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							goto IL_1AC9;
						case 'E':
							comtpesByIndex.Fight.method_8(string_0.Substring(2));
							goto IL_1AC9;
						case 'I':
						{
							char c7 = string_0[2];
							if (c7 <= 'E')
							{
								if (c7 == 'C')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c7 == 'E')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							else
							{
								if (c7 == 'P')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c7 == 'e')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							Class13.smethod_2(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						case 'J':
						{
							char c8 = string_0[2];
							if (c8 == 'K')
							{
								if (Information.IsNothing(comtpesByIndex.Fight))
								{
									comtpesByIndex.Fight = new Combat(int_0);
								}
								comtpesByIndex.Fight.method_10(string_0.Substring(3));
								goto IL_1AC9;
							}
							if (c8 != 'r')
							{
								goto IL_1AC9;
							}
							comtpesByIndex.ExchangeManager.method_5(string_0.Substring(3));
							goto IL_1AC9;
						}
						case 'M':
							goto IL_1AC9;
						case 'O':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'P':
							comtpesByIndex.Fight.onPositionStart(string_0.Substring(2));
							goto IL_1AC9;
						case 'R':
							comtpesByIndex.Fight.method_9(string_0.Substring(2));
							goto IL_1AC9;
						case 'S':
							comtpesByIndex.Fight.onStartToPlay();
							goto IL_1AC9;
						case 'T':
						{
							if (Information.IsNothing(comtpesByIndex.Fight))
							{
								comtpesByIndex.Fight = new Combat(int_0)
								{
									Start = true
								};
							}
							char c9 = string_0[2];
							if (c9 <= 'L')
							{
								if (c9 == 'C')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c9 == 'F')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c9 == 'L')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
							}
							else
							{
								if (c9 == 'M')
								{
									comtpesByIndex.Fight.OnTourMiddle(string_0.Substring(4));
									goto IL_1AC9;
								}
								if (c9 == 'R')
								{
									comtpesByIndex.Fight.OnTurnReady(string_0.Substring(2));
									goto IL_1AC9;
								}
								if (c9 == 'S')
								{
									comtpesByIndex.Fight.OnTurnStart(string_0.Substring(3));
									goto IL_1AC9;
								}
							}
							Class13.smethod_2(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						case 'V':
							comtpesByIndex.Fight.method_7(string_0.Substring(2));
							goto IL_1AC9;
						case 'X':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							switch (char_1)
							{
							case 'c':
								goto IL_1AC9;
							case 'd':
							{
								char c10 = string_0[3];
								if (c10 == 'K')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c10 != 'O')
								{
									goto IL_1AC9;
								}
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							case 'f':
								comtpesByIndex.Fight.method_6(string_0.Substring(2));
								goto IL_1AC9;
							}
							break;
						}
					}
					else
					{
						if (char_1 == 'o')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 't')
						{
							string[] array = string_0.Split(new char[]
							{
								'|'
							});
							if (array.Length <= 1)
							{
								break;
							}
							Perso comtpesById = Declarations.getComtpesById(comtpesByIndex.idChef);
							if (comtpesById == null)
							{
								break;
							}
							string text2 = array[1].Split(new char[]
							{
								';'
							})[0];
							string value = text2.Substring(1);
							string idcombat = array[0].Substring(2);
							if (comtpesByIndex.idChef > 0 && (double)comtpesByIndex.idChef == Conversions.ToDouble(value) && !comtpesByIndex.status.IsIgnoreGroup())
							{
								comtpesByIndex.JoinCombat(idcombat, new Random().Next(comtpesByIndex.config.globalSpeed, comtpesByIndex.config.globalSpeed + 200));
								break;
							}
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'H':
					if (char_1 != 'C')
					{
						if (char_1 != 'G')
						{
							Class13.smethod_2(string_0, comtpesByIndex);
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						comtpesByIndex.status.connexion = status.ConnexionStatus.Connexion_login;
					}
					break;
				case 'I':
					if (char_1 <= 'H')
					{
						if (char_1 == 'C')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'H')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						switch (char_1)
						{
						case 'L':
						{
							char c11 = string_0[2];
							if (c11 == 'F')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c11 != 'S')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
						case 'M':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'N':
						case 'P':
							break;
						case 'O':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'Q':
							if (comtpesByIndex.map.paddock != null)
							{
								comtpesByIndex.map.paddock.abortEmote();
								goto IL_1AC9;
							}
							goto IL_1AC9;
						default:
							if (char_1 == 'm')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'J':
					switch (char_1)
					{
					case 'N':
					case 'O':
					case 'R':
						goto IL_1AC9;
					case 'P':
					case 'Q':
						break;
					case 'S':
						comtpesByIndex.Jobs = new JobHandler(string_0, int_0);
						goto IL_1AC9;
					default:
						if (char_1 == 'X')
						{
							comtpesByIndex.Jobs.setExp(string_0);
							goto IL_1AC9;
						}
						break;
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'K':
					if (char_1 != 'C')
					{
						if (char_1 != 'K')
						{
							if (char_1 != 'V')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
							}
							else
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'M':
					Class13.smethod_3(string_0, comtpesByIndex);
					break;
				case 'O':
					if (char_1 <= 'T')
					{
						switch (char_1)
						{
						case 'A':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'B':
						case 'E':
							break;
						case 'C':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'D':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'F':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							switch (char_1)
							{
							case 'K':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'M':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'Q':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'R':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'S':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							case 'T':
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
					}
					else
					{
						if (char_1 == 'a')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'd')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'w')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'P':
					if (char_1 <= 'F')
					{
						if (char_1 == 'A')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'C')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'F')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						switch (char_1)
						{
						case 'I':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'J':
						case 'K':
							break;
						case 'L':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'M':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (char_1 == 'R')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (char_1 == 'V')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'Q':
					if (char_1 != 'L')
					{
						if (char_1 != 'S')
						{
							Class13.smethod_2(string_0, comtpesByIndex);
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'R':
					if (char_1 <= 'e')
					{
						if (char_1 == 'D')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 != 'd')
						{
							if (char_1 == 'e')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								break;
							}
						}
						else
						{
							if (comtpesByIndex.map.paddock.dragos.Count > 0)
							{
								comtpesByIndex.map.paddock.dragos.Last<Drago>().Update(string_0.Substring(2), int_0);
								break;
							}
							break;
						}
					}
					else
					{
						switch (char_1)
						{
						case 'n':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'o':
						case 'q':
							break;
						case 'p':
							comtpesByIndex.map.setEnclo(string_0.Substring(2));
							goto IL_1AC9;
						case 'r':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (char_1 == 'v')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (char_1 == 'x')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'S':
					if (char_1 <= 'F')
					{
						if (char_1 == 'B')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'F')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						if (char_1 == 'L')
						{
							comtpesByIndex.spellHandler = new SpellHandler(string_0, int_0);
							break;
						}
						if (char_1 == 'U')
						{
							comtpesByIndex.spellHandler.OnResultUpgrade(string_0.Substring(3), true);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'T':
					if (char_1 != 'B')
					{
						if (char_1 != 'C')
						{
							if (char_1 != 'T')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
							}
							else
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'W':
					if (char_1 <= 'V')
					{
						if (char_1 == 'C')
						{
							comtpesByIndex.ExchangeManager.Onzaap(string_0);
							break;
						}
						if (char_1 == 'U')
						{
							break;
						}
						if (char_1 == 'V')
						{
							comtpesByIndex.status.enEchange = false;
							break;
						}
					}
					else
					{
						if (char_1 == 'c')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'p')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						switch (char_1)
						{
						case 'u':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'v':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'w':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'Z':
					if (char_1 != 'C')
					{
						if (char_1 != 'S')
						{
							Class13.smethod_2(string_0, comtpesByIndex);
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'a':
					if (char_1 != 'M')
					{
						if (char_1 != 'l')
						{
							if (char_1 != 'm')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
							}
							else
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'c':
					if (char_1 <= 'M')
					{
						if (char_1 != 'C')
						{
							if (char_1 == 'M')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
					}
					else if (char_1 != 'S')
					{
						if (char_1 == 's')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else if (comtpesByIndex.map.paddock != null)
					{
						comtpesByIndex.map.paddock.abortEmote();
					}
					break;
				case 'd':
					if (char_1 != 'C')
					{
						if (char_1 != 'V')
						{
							Class13.smethod_2(string_0, comtpesByIndex);
						}
					}
					else
					{
						comtpesByIndex.Send(new Message("dV", 0, true, true, true));
					}
					break;
				case 'e':
					if (char_1 <= 'D')
					{
						if (char_1 != 'A')
						{
							if (char_1 == 'D')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else if (char_1 != 'L')
					{
						if (char_1 != 'R')
						{
							if (char_1 == 'U')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'f':
					if (char_1 != 'C')
					{
						if (char_1 != 'D')
						{
							if (char_1 != 'L')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
							}
							else
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'g':
					switch (char_1)
					{
					case 'A':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'B':
					case 'D':
					case 'E':
					case 'F':
					case 'G':
						break;
					case 'C':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'H':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					case 'I':
					{
						char c12 = string_0[2];
						switch (c12)
						{
						case 'B':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'C':
						case 'D':
						case 'E':
							break;
						case 'F':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'G':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'H':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (c12 == 'M')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c12 == 'T')
							{
								char c13 = string_0[3];
								if (c13 == 'M')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c13 == 'P')
								{
									Class13.smethod_3(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								if (c13 != 'p')
								{
									Class13.smethod_2(string_0, comtpesByIndex);
									goto IL_1AC9;
								}
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
						Class13.smethod_2(string_0, comtpesByIndex);
						goto IL_1AC9;
					}
					case 'J':
					{
						char c14 = string_0[2];
						if (c14 <= 'E')
						{
							if (c14 == 'C')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c14 == 'E')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
						}
						else
						{
							if (c14 == 'K')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c14 == 'R')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							if (c14 == 'r')
							{
								comtpesByIndex.Send(new Message("gJE" + string_0.Substring(3, string_0.IndexOf("|") - 3), new Random().Next(10, 50), false, true, true));
								goto IL_1AC9;
							}
						}
						Class13.smethod_2(string_0, comtpesByIndex);
						goto IL_1AC9;
					}
					case 'K':
						Class13.smethod_3(string_0, comtpesByIndex);
						goto IL_1AC9;
					default:
						switch (char_1)
						{
						case 'S':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'T':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'U':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						case 'V':
							Class13.smethod_3(string_0, comtpesByIndex);
							goto IL_1AC9;
						default:
							if (char_1 == 'n')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								goto IL_1AC9;
							}
							break;
						}
						break;
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'h':
					if (char_1 <= 'L')
					{
						if (char_1 <= 'C')
						{
							if (char_1 == 'B')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								break;
							}
							if (char_1 == 'C')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								break;
							}
						}
						else
						{
							if (char_1 == 'G')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								break;
							}
							if (char_1 == 'L')
							{
								Class13.smethod_3(string_0, comtpesByIndex);
								break;
							}
						}
					}
					else if (char_1 <= 'S')
					{
						if (char_1 == 'P')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'S')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					else
					{
						if (char_1 == 'V')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
						if (char_1 == 'X')
						{
							Class13.smethod_3(string_0, comtpesByIndex);
							break;
						}
					}
					Class13.smethod_2(string_0, comtpesByIndex);
					break;
				case 'i':
					if (char_1 != 'A')
					{
						if (char_1 != 'D')
						{
							if (char_1 != 'L')
							{
								Class13.smethod_2(string_0, comtpesByIndex);
							}
							else
							{
								Class13.smethod_3(string_0, comtpesByIndex);
							}
						}
						else
						{
							Class13.smethod_3(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				case 'k':
					Class13.smethod_3(string_0, comtpesByIndex);
					break;
				case 'p':
					Class13.smethod_3(string_0, comtpesByIndex);
					break;
				case 'q':
					Class13.smethod_3(string_0, comtpesByIndex);
					break;
				case 'r':
					Class13.smethod_3(string_0, comtpesByIndex);
					break;
				case 's':
					if (char_1 != 'L')
					{
						if (char_1 != 'X')
						{
							Class13.smethod_2(string_0, comtpesByIndex);
						}
					}
					else
					{
						Class13.smethod_3(string_0, comtpesByIndex);
					}
					break;
				}
				IL_1AC9:;
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00027DE0 File Offset: 0x00025FE0
	private static void smethod_2(string string_0, Perso perso_0)
	{
		bool flag = Operators.CompareString(Conversions.ToString(string_0[2]), "E", false) == 0;
		char c = string_0[0];
		char c2 = string_0[1];
		int num = 0;
		checked
		{
			foreach (char @string in string_0)
			{
				num += Strings.Asc(@string);
			}
			int num2 = 0;
			switch (num % 13)
			{
			case 0:
				num2 = Conversions.ToInteger(perso_0.monIdDofus);
				break;
			case 1:
				num2 = perso_0.myCharacter.level;
				break;
			case 2:
				num2 = 0;
				break;
			case 3:
				num2 = int.Parse(perso_0.monIdDofus) + string_0.Length;
				break;
			case 4:
				num2 = perso_0.InfosPerso.Kamas;
				break;
			case 5:
				num2 = (int)Math.Round(perso_0.InfosPerso.XP);
				break;
			case 6:
				num2 = string_0.Length;
				break;
			case 7:
				num2 = perso_0.InfosPerso.Statistique["terre"].@base;
				break;
			case 8:
				num2 = perso_0.InfosPerso.Statistique["sagesse"].@base;
				break;
			case 9:
				num2 = perso_0.InfosPerso.Statistique["eau"].@base;
				break;
			case 10:
				num2 = perso_0.InfosPerso.Statistique["air"].@base;
				break;
			case 11:
				num2 = perso_0.InfosPerso.Statistique["feu"].@base;
				break;
			case 12:
				num2 = perso_0.Inventaire.podsactual;
				break;
			}
			num2 += int.Parse(perso_0.monIdDofus);
			string data = string_0.Substring(0, 2) + num2.ToString();
			perso_0.Send(new Message(data, 0, false, false, false));
		}
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00002B9E File Offset: 0x00000D9E
	private static void smethod_3(string string_0, Perso perso_0)
	{
	}
}
