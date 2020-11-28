using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000063 RID: 99
	public class Config
	{
		// Token: 0x06000204 RID: 516 RVA: 0x0000338F File Offset: 0x0000158F
		static Config()
		{
			Class15.XRATSHnz66atd();
			Config.pathDofus = "";
			Config.listServeur = new List<GameServer>();
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00010D58 File Offset: 0x0000EF58
		public Process dllProcess
		{
			get
			{
				Process process = Process.GetProcessesByName("dofus.dll").FirstOrDefault((Process d) => Math.Abs((d.StartTime - this.Client.StartTime).TotalSeconds) < 1.0);
				return (process != null) ? process : this.Client;
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00010D90 File Offset: 0x0000EF90
		public static void LoadServer()
		{
			try
			{
				StreamReader streamReader = new StreamReader(Application.StartupPath + "/data/servers.txt");
				string text = "a";
				while (Operators.CompareString(text, null, false) != 0)
				{
					text = streamReader.ReadLine();
					if (Operators.CompareString(text, "", false) != 0)
					{
						Config.listServeur.Add(new GameServer(text.Split(new char[]
						{
							'|'
						})));
					}
				}
				streamReader.Close();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error : Config.vb --> LoadServer()");
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00010E3C File Offset: 0x0000F03C
		public static object LoadAllComptes()
		{
			try
			{
				StreamReader streamReader = new StreamReader(Application.StartupPath + "/data/accounts.txt");
				string text = streamReader.ReadLine();
				streamReader.Close();
				if (text != null && Operators.CompareString(text, "", false) != 0)
				{
					foreach (string text2 in text.Split(new char[]
					{
						'|'
					}))
					{
						if (Operators.CompareString(text2, "", false) != 0)
						{
							Perso perso = new Perso();
							perso.config = new Config(text2);
							if (!string.IsNullOrEmpty(perso.config.nomDuCompte))
							{
								Declarations.AddCompte(perso);
								perso.monId = checked(Declarations.nbCompte() - 1);
								string iaName = perso.config.IaName;
								if (File.Exists(Application.StartupPath + "/ia/" + iaName))
								{
									perso.ia = IA.LoadIA(perso.monId, File.ReadAllText(Application.StartupPath + "/ia/" + iaName));
								}
								if (Information.IsNothing(perso.ia))
								{
									perso.ia = IA.LoadIA(perso.monId, "");
									perso.config.IaName = "";
								}
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
			object result;
			return result;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00010FD0 File Offset: 0x0000F1D0
		public void Save()
		{
			try
			{
				string text = "";
				text = text + this.nomDuCompte + "\r";
				text = text + this.passDuCompte + "\r";
				text = text + this.serverName + "\r";
				text = text + Conversions.ToString(this.numeroPerso) + "\r";
				text = text + this.passBot + "\r";
				text = text + Conversions.ToString(this.onlyRessource) + "\r";
				text = text + Conversions.ToString(this.PodsReturnBank) + "\r";
				text = text + Conversions.ToString(this.itemRegen) + "\r";
				text = text + Conversions.ToString(this.SpellToBoost) + "\r";
				text = text + Conversions.ToString(this.lvlmin) + "\r";
				text = text + Conversions.ToString(this.lvlmax) + "\r";
				text = text + Conversions.ToString(this.percentRegen) + "\r";
				text = text + this.IaName + "\r";
				text = text + Conversions.ToString(this.BloqueSpectateur) + "\r";
				text = text + Conversions.ToString(this.BloqueGroupe) + "\r";
				text = text + Conversions.ToString(this.DisconnectWhenFull) + "\r";
				text = text + string.Join(",", this.monstersAllow) + "\r";
				text = text + string.Join(",", this.monstersDennied) + "\r";
				text = text + string.Join<KeyValuePair<int, int>>(";", this.listSpellLaunch) + "\r";
				text = text + string.Join<int>(",", this.listRessourcesRecolt) + "\r";
				text = text + Conversions.ToString(this.portecanne) + "\r";
				text = text + this.autoboost + "\r";
				text = text + string.Join<int>(",", this.listItemToDelete) + "\r";
				text = text + Conversions.ToString(this.AuBoutDeCombats) + "\r";
				text = text + Conversions.ToString(this.DistanceMobsAggro) + "\r";
				text = text + Conversions.ToString(this.NbCraftSeconde) + "\r";
				text = text + Conversions.ToString(this.speedCombat) + "\r";
				text = text + this.proxyHost + "\r";
				text = text + Conversions.ToString(this.proxyPort) + "\r";
				text = text + this.proxyLogin + "\r";
				text = text + this.proxyPass + "\r";
				text = text + Conversions.ToString(this.mitm) + "\r";
				text = text + Conversions.ToString(this.globalSpeed) + "\r";
				text = text + this.AttakOrder + "\r";
				text = text + this.iaType + "\r";
				text = text + this.startPlacement + "\r";
				text = text + Conversions.ToString(this.sock5) + "\r";
				text = text + Conversions.ToString(this.idleSecurity) + "\r";
				text = text + Conversions.ToString(this.vitesseInvit) + "\r";
				StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "/saves/" + this.nomDuCompte + ".bot");
				streamWriter.WriteLine(text);
				streamWriter.Close();
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
				StreamWriter streamWriter;
				if (!Information.IsNothing(streamWriter))
				{
					streamWriter.Close();
				}
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000113B4 File Offset: 0x0000F5B4
		public static void LoadPathDofus()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "/data/path.txt");
			Config.pathDofus = streamReader.ReadToEnd().Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
			streamReader.Close();
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00011414 File Offset: 0x0000F614
		public Config()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.monstersAllow = new List<string>();
			this.monstersDennied = new List<string>();
			this.listRessourcesRecolt = new List<int>();
			this.listSpellLaunch = new Dictionary<int, int>();
			this.startPlacement = "Proche";
			this.percentRegen = 90m;
			this.PodsReturnBank = 95;
			this.onlyRessource = true;
			this.itemToExchange = new Dictionary<int, KeyValuePair<string, int>>();
			this.portecanne = 1;
			this.autoboost = "";
			this.listItemToDelete = new List<int>();
			this.DistanceMobsAggro = 3;
			this.listItemToCrafts = new List<int>();
			this.NbCraftSeconde = 5;
			this.speedCombat = 2000;
			this.AttakOrder = "aucun";
			this.proxyHost = "";
			this.proxyPort = 0;
			this.proxyLogin = "";
			this.proxyPass = "";
			this.proxyRandom = false;
			this.ConnexionOp = false;
			this.notifEnable = false;
			this.mitm = false;
			this.globalSpeed = 0;
			this.vitesseInvit = 800;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00011534 File Offset: 0x0000F734
		public Config(string compte)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.monstersAllow = new List<string>();
			this.monstersDennied = new List<string>();
			this.listRessourcesRecolt = new List<int>();
			this.listSpellLaunch = new Dictionary<int, int>();
			this.startPlacement = "Proche";
			this.percentRegen = 90m;
			this.PodsReturnBank = 95;
			this.onlyRessource = true;
			this.itemToExchange = new Dictionary<int, KeyValuePair<string, int>>();
			this.portecanne = 1;
			this.autoboost = "";
			this.listItemToDelete = new List<int>();
			this.DistanceMobsAggro = 3;
			this.listItemToCrafts = new List<int>();
			this.NbCraftSeconde = 5;
			this.speedCombat = 2000;
			this.AttakOrder = "aucun";
			this.proxyHost = "";
			this.proxyPort = 0;
			this.proxyLogin = "";
			this.proxyPass = "";
			this.proxyRandom = false;
			this.ConnexionOp = false;
			this.notifEnable = false;
			this.mitm = false;
			this.globalSpeed = 0;
			this.vitesseInvit = 800;
			checked
			{
				if (File.Exists(Application.StartupPath + "/saves/" + compte + ".bot"))
				{
					int num = Declarations.nbCompte() - 1;
					for (int i = 0; i <= num; i++)
					{
						Perso comtpesByIndex = Declarations.getComtpesByIndex(i);
						if (!Information.IsNothing(comtpesByIndex.config) && Operators.CompareString(compte, comtpesByIndex.config.nomDuCompte, false) == 0)
						{
							return;
						}
					}
					StreamReader streamReader = new StreamReader(Application.StartupPath + "/saves/" + compte + ".bot");
					try
					{
						this.nomDuCompte = streamReader.ReadLine();
						this.passDuCompte = streamReader.ReadLine();
						this.serverName = streamReader.ReadLine();
						this.numeroPerso = Conversions.ToInteger(streamReader.ReadLine());
						this.passBot = streamReader.ReadLine();
						this.onlyRessource = Conversions.ToBoolean(streamReader.ReadLine());
						this.PodsReturnBank = Conversions.ToInteger(streamReader.ReadLine());
						this.itemRegen = Conversions.ToInteger(streamReader.ReadLine());
						this.SpellToBoost = Conversions.ToInteger(streamReader.ReadLine());
						this.lvlmin = Conversions.ToDecimal(streamReader.ReadLine());
						this.lvlmax = Conversions.ToDecimal(streamReader.ReadLine());
						this.percentRegen = Conversions.ToDecimal(streamReader.ReadLine());
						this.IaName = streamReader.ReadLine();
						this.BloqueSpectateur = Conversions.ToBoolean(streamReader.ReadLine());
						this.BloqueGroupe = Conversions.ToBoolean(streamReader.ReadLine());
						this.DisconnectWhenFull = Conversions.ToBoolean(streamReader.ReadLine());
						string text = streamReader.ReadLine();
						if (text.Length > 2)
						{
							this.monstersAllow.AddRange(text.Split(new char[]
							{
								','
							}));
						}
						text = streamReader.ReadLine();
						if (text.Length > 2)
						{
							this.monstersDennied.AddRange(text.Split(new char[]
							{
								','
							}));
						}
						text = streamReader.ReadLine();
						if (text.Length > 2)
						{
							string[] array = text.Split(new char[]
							{
								';'
							});
							foreach (string text2 in array)
							{
								string value = text2.Split(new char[]
								{
									','
								})[0].Replace("[", "");
								string value2 = text2.Split(new char[]
								{
									','
								})[1].Replace("]", "");
								this.listSpellLaunch.Add(Conversions.ToInteger(value), Conversions.ToInteger(value2));
							}
						}
						text = streamReader.ReadLine();
						if (text.Length > 2)
						{
							this.listRessourcesRecolt.AddRange(text.Split(new char[]
							{
								','
							}).Select((Config._Closure$__.$I63-0 == null) ? (Config._Closure$__.$I63-0 = ((string s) => Conversions.ToInteger(s))) : Config._Closure$__.$I63-0).ToList<int>());
						}
						this.portecanne = Conversions.ToInteger(streamReader.ReadLine());
						if (this.portecanne == 0)
						{
							this.portecanne = 1;
						}
						this.autoboost = streamReader.ReadLine();
						text = (streamReader.ReadLine() ?? "");
						if (text.Length > 2)
						{
							this.listItemToDelete.AddRange(text.Split(new char[]
							{
								','
							}).Select((Config._Closure$__.$I63-1 == null) ? (Config._Closure$__.$I63-1 = ((string s) => Conversions.ToInteger(s))) : Config._Closure$__.$I63-1).ToList<int>());
						}
						this.AuBoutDeCombats = Conversions.ToInteger(streamReader.ReadLine());
						this.DistanceMobsAggro = Conversions.ToInteger(streamReader.ReadLine());
						this.NbCraftSeconde = Conversions.ToInteger(streamReader.ReadLine());
						this.speedCombat = Conversions.ToInteger(streamReader.ReadLine());
						this.proxyHost = streamReader.ReadLine();
						this.proxyPort = Conversions.ToInteger(streamReader.ReadLine());
						this.proxyLogin = streamReader.ReadLine();
						this.proxyPass = streamReader.ReadLine();
						this.mitm = Conversions.ToBoolean(streamReader.ReadLine());
						this.globalSpeed = Conversions.ToInteger(streamReader.ReadLine());
						this.AttakOrder = streamReader.ReadLine();
						this.iaType = streamReader.ReadLine();
						this.startPlacement = streamReader.ReadLine();
						this.sock5 = Conversions.ToBoolean(streamReader.ReadLine());
						this.idleSecurity = Conversions.ToBoolean(streamReader.ReadLine());
						this.vitesseInvit = Conversions.ToInteger(streamReader.ReadLine());
						streamReader.Close();
					}
					catch (Exception e)
					{
						Fonctions.traiterErreur(e);
						streamReader.Close();
					}
				}
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00011B04 File Offset: 0x0000FD04
		public static void InitializeCells()
		{
			int num = 0;
			string[] array = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"I",
				"J",
				"K",
				"L",
				"M",
				"N",
				"O",
				"P",
				"Q",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z",
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"-",
				"_"
			};
			string[] array2 = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z"
			};
			checked
			{
				int num2 = array2.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = array.Length - 1;
					for (int j = 0; j <= num3; j++)
					{
						Declarations.cases[num] = array2[i] + array[j];
						num++;
					}
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00011E84 File Offset: 0x00010084
		public int hashCode
		{
			get
			{
				return checked(this.GetHashCode() + this.monstersAllow.Count + this.monstersDennied.Count + this.listRessourcesRecolt.Count + this.listItemToCrafts.Count);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600020E RID: 526 RVA: 0x000033AA File Offset: 0x000015AA
		// (set) Token: 0x0600020F RID: 527 RVA: 0x000033B2 File Offset: 0x000015B2
		public bool sock5 { get; set; }

		// Token: 0x06000210 RID: 528 RVA: 0x00011ECC File Offset: 0x000100CC
		public static void SavePathDofus()
		{
			StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "/data/path.txt");
			streamWriter.Write(Config.pathDofus.Replace("\r\n", "").Replace("\n", "").Replace("\r", ""));
			streamWriter.Close();
		}

		// Token: 0x04000280 RID: 640
		public string nomDuCompte;

		// Token: 0x04000281 RID: 641
		public string passDuCompte;

		// Token: 0x04000282 RID: 642
		public string serverName;

		// Token: 0x04000283 RID: 643
		public string passBot;

		// Token: 0x04000284 RID: 644
		public int numeroPerso;

		// Token: 0x04000285 RID: 645
		public static string pathDofus;

		// Token: 0x04000286 RID: 646
		public bool BloqueSpectateur;

		// Token: 0x04000287 RID: 647
		public bool BloqueGroupe;

		// Token: 0x04000288 RID: 648
		public bool DisconnectWhenFull;

		// Token: 0x04000289 RID: 649
		public int AuBoutDeCombats;

		// Token: 0x0400028A RID: 650
		public List<string> monstersAllow;

		// Token: 0x0400028B RID: 651
		public List<string> monstersDennied;

		// Token: 0x0400028C RID: 652
		public decimal lvlmax;

		// Token: 0x0400028D RID: 653
		public decimal lvlmin;

		// Token: 0x0400028E RID: 654
		public List<int> listRessourcesRecolt;

		// Token: 0x0400028F RID: 655
		public Dictionary<int, int> listSpellLaunch;

		// Token: 0x04000290 RID: 656
		public int SpellToBoost;

		// Token: 0x04000291 RID: 657
		public bool Echange;

		// Token: 0x04000292 RID: 658
		public string IaName;

		// Token: 0x04000293 RID: 659
		public string startPlacement;

		// Token: 0x04000294 RID: 660
		public decimal percentRegen;

		// Token: 0x04000295 RID: 661
		public int PodsReturnBank;

		// Token: 0x04000296 RID: 662
		public bool onlyRessource;

		// Token: 0x04000297 RID: 663
		public int itemRegen;

		// Token: 0x04000298 RID: 664
		public Dictionary<int, KeyValuePair<string, int>> itemToExchange;

		// Token: 0x04000299 RID: 665
		public static List<GameServer> listServeur;

		// Token: 0x0400029A RID: 666
		public string floodPhrase;

		// Token: 0x0400029B RID: 667
		public bool floodMp;

		// Token: 0x0400029C RID: 668
		public bool activeFlood;

		// Token: 0x0400029D RID: 669
		public int portecanne;

		// Token: 0x0400029E RID: 670
		public string autoboost;

		// Token: 0x0400029F RID: 671
		public bool randomSpeedCombat;

		// Token: 0x040002A0 RID: 672
		public bool randomSpeedTrajet;

		/// <summary>Les objets a supprimer</summary>
		/// <example>
		///   bot.config.listItemToDelete:Add(311)
		///   bot.config.listItemToDelete:Clear()
		///  la documentation pour gérer les listes est ici https://docs.microsoft.com/fr-fr/dotnet/api/system.collections.generic.list-1?view=netframework-4.8#methods
		///  </example>
		// Token: 0x040002A1 RID: 673
		public List<int> listItemToDelete;

		// Token: 0x040002A2 RID: 674
		public int DistanceMobsAggro;

		// Token: 0x040002A3 RID: 675
		public List<int> listItemToCrafts;

		// Token: 0x040002A4 RID: 676
		public int NbCraftSeconde;

		// Token: 0x040002A5 RID: 677
		public bool Merchant;

		// Token: 0x040002A6 RID: 678
		public int speedCombat;

		// Token: 0x040002A7 RID: 679
		public string AttakOrder;

		// Token: 0x040002A8 RID: 680
		public string proxyHost;

		// Token: 0x040002A9 RID: 681
		public int proxyPort;

		// Token: 0x040002AA RID: 682
		public string proxyLogin;

		// Token: 0x040002AB RID: 683
		public string proxyPass;

		// Token: 0x040002AC RID: 684
		public bool proxyRandom;

		// Token: 0x040002AD RID: 685
		public bool ConnexionOp;

		// Token: 0x040002AE RID: 686
		public bool notifEnable;

		// Token: 0x040002AF RID: 687
		public bool mitm;

		// Token: 0x040002B0 RID: 688
		public int dllId;

		// Token: 0x040002B1 RID: 689
		public int globalSpeed;

		// Token: 0x040002B2 RID: 690
		public bool idleSecurity;

		// Token: 0x040002B3 RID: 691
		public int vitesseInvit;

		// Token: 0x040002B4 RID: 692
		public Process Client;

		// Token: 0x040002B5 RID: 693
		public string iaType;

		// Token: 0x040002B6 RID: 694
		internal static string string_0;

		// Token: 0x040002B7 RID: 695
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_0;
	}
}
