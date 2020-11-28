using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using wpse;

namespace WindowsApplication2
{
	// Token: 0x0200002D RID: 45
	public class Perso
	{
		// Token: 0x060000FB RID: 251 RVA: 0x00002CFE File Offset: 0x00000EFE
		static Perso()
		{
			Class15.XRATSHnz66atd();
			Perso.LockComptes = RuntimeHelpers.GetObjectValue(new object());
			Perso.int_1 = 0;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000A1A8 File Offset: 0x000083A8
		public Perso()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.rand = new Random();
			this.lastInactivite = DateAndTime.Now;
			this.errorDeco = false;
			this.monNom = "";
			this.list_0 = new List<int>();
			this.TimerFlood = new System.Timers.Timer();
			this.mode = -1;
			this.TimerLaunch = new System.Timers.Timer();
			this.FightResult = new List<FightStatsEntry>();
			this.lastRecepetion = new KeyValuePair<string, DateTime>("", DateAndTime.Now.AddMinutes(1.0));
			this.actionParser = new Action();
			this.familiers = new List<Famillier>();
			this.lasteatFamilier = DateTime.Now;
			this.MessagesToSend = new List<Message>();
			this.ExchangeManager = new Echange();
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.string_0 = "";
			this.lastSendModo = default(DateTime);
			this.receptionRCV = false;
			this.lastSendId = 0;
			this.object_1 = 1000;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000A2C0 File Offset: 0x000084C0
		public GameServer MyServer()
		{
			return Config.listServeur.FirstOrDefault((GameServer s) => Operators.CompareString(s.name, this.config.serverName, false) == 0);
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000A2E8 File Offset: 0x000084E8
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00002D1A File Offset: 0x00000F1A
		public int idChef
		{
			get
			{
				int result;
				if (this.status == null)
				{
					result = 0;
				}
				else
				{
					result = this.int_0;
				}
				return result;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000100 RID: 256 RVA: 0x0000A30C File Offset: 0x0000850C
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00002D23 File Offset: 0x00000F23
		public List<int> Slave
		{
			get
			{
				return this.list_0;
			}
			set
			{
				value = this.list_0;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00002D2D File Offset: 0x00000F2D
		// (set) Token: 0x06000103 RID: 259 RVA: 0x0000A324 File Offset: 0x00008524
		public virtual System.Timers.Timer TimerFlood
		{
			[CompilerGenerated]
			get
			{
				return this.timer_0;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ElapsedEventHandler value2 = new ElapsedEventHandler(this.method_0);
				System.Timers.Timer timer = this.timer_0;
				if (timer != null)
				{
					timer.Elapsed -= value2;
				}
				this.timer_0 = value;
				timer = this.timer_0;
				if (timer != null)
				{
					timer.Elapsed += value2;
				}
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00002D35 File Offset: 0x00000F35
		// (set) Token: 0x06000105 RID: 261 RVA: 0x0000A368 File Offset: 0x00008568
		public virtual System.Timers.Timer TimerLaunch
		{
			[CompilerGenerated]
			get
			{
				return this.timer_1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ElapsedEventHandler value2 = new ElapsedEventHandler(this.method_1);
				System.Timers.Timer timer = this.timer_1;
				if (timer != null)
				{
					timer.Elapsed -= value2;
				}
				this.timer_1 = value;
				timer = this.timer_1;
				if (timer != null)
				{
					timer.Elapsed += value2;
				}
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000106 RID: 262 RVA: 0x0000A3AC File Offset: 0x000085AC
		// (remove) Token: 0x06000107 RID: 263 RVA: 0x0000A3E4 File Offset: 0x000085E4
		public event Perso.OnActionFinishEventHandler OnActionFinish
		{
			[CompilerGenerated]
			add
			{
				Perso.OnActionFinishEventHandler onActionFinishEventHandler = this.onActionFinishEventHandler_0;
				Perso.OnActionFinishEventHandler onActionFinishEventHandler2;
				do
				{
					onActionFinishEventHandler2 = onActionFinishEventHandler;
					Perso.OnActionFinishEventHandler value2 = (Perso.OnActionFinishEventHandler)Delegate.Combine(onActionFinishEventHandler2, value);
					onActionFinishEventHandler = Interlocked.CompareExchange<Perso.OnActionFinishEventHandler>(ref this.onActionFinishEventHandler_0, value2, onActionFinishEventHandler2);
				}
				while (onActionFinishEventHandler != onActionFinishEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				Perso.OnActionFinishEventHandler onActionFinishEventHandler = this.onActionFinishEventHandler_0;
				Perso.OnActionFinishEventHandler onActionFinishEventHandler2;
				do
				{
					onActionFinishEventHandler2 = onActionFinishEventHandler;
					Perso.OnActionFinishEventHandler value2 = (Perso.OnActionFinishEventHandler)Delegate.Remove(onActionFinishEventHandler2, value);
					onActionFinishEventHandler = Interlocked.CompareExchange<Perso.OnActionFinishEventHandler>(ref this.onActionFinishEventHandler_0, value2, onActionFinishEventHandler2);
				}
				while (onActionFinishEventHandler != onActionFinishEventHandler2);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000A41C File Offset: 0x0000861C
		public Character myCharacter
		{
			get
			{
				Character result;
				if (Information.IsNothing(this.map))
				{
					result = null;
				}
				else
				{
					result = (Character)this.map.getActorsById(Conversions.ToInteger(this.monIdDofus));
				}
				return result;
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000A458 File Offset: 0x00008658
		public void sendToSlave(string packet, int time)
		{
			try
			{
				foreach (int id in this.get_Slave(true))
				{
					Perso comtpesById = Declarations.getComtpesById(id);
					if (comtpesById.status.connexion == status.ConnexionStatus.const_3)
					{
						comtpesById.Send(new Message(packet, time, true, true, true));
					}
				}
			}
			finally
			{
				List<int>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000A4D0 File Offset: 0x000086D0
		public void Initialiser()
		{
			this.status = new status(this.monId);
			this.movement = new MovementHandler(this.monId);
			this.Inventaire = new Inventaire(this.monId);
			this.interactiveManager = new Interactive(this.monId);
			this.launcher = new AutoLaunch(this.monId);
			this.chatHandler = new ChatHandler(this);
			this.TimerLaunch.Stop();
			this.TimerLaunch.Interval = 20.0;
			this.TimerFlood.Interval = 2000.0;
			this.TimerLaunch.Start();
			this.status.autoReconnect = true;
			this.lastRecepetion = new KeyValuePair<string, DateTime>("", DateTime.Now);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000A5A0 File Offset: 0x000087A0
		public void CreateSocket(bool changeProxy)
		{
			this.MessagesToSend.Clear();
			this.mitm = null;
			if (!Information.IsNothing(this.socket))
			{
				this.socket.Connexion(false);
				this.socket = null;
				this.config.ConnexionOp = false;
			}
			if (!Information.IsNothing(this.sock))
			{
				this.sock.Connexion(false);
				this.sock = null;
			}
			checked
			{
				if (this.config.proxyRandom && (changeProxy || string.IsNullOrWhiteSpace(this.config.proxyHost)))
				{
					this.status.connexion = status.ConnexionStatus.Recherche_proxy;
					Perso.int_1++;
					if (Declarations.proxys.Count == 0 || Perso.int_1 > 30)
					{
						Perso.int_1 = 0;
						Fonctions.getProxy();
					}
					if (Declarations.proxys.Count > 0)
					{
						this.config.sock5 = (this.rand.Next(0, 2) != 0);
						string text = this.config.sock5 ? Declarations.proxys5[this.rand.Next(0, Declarations.proxys5.Count)] : Declarations.proxys[this.rand.Next(0, Declarations.proxys.Count)];
						string[] array = text.Replace("\n", "").Split(new char[]
						{
							':'
						});
						this.config.proxyHost = array[0];
						this.config.proxyPort = Conversions.ToInteger(array[1]);
						if (array.Length > 2)
						{
							this.config.proxyLogin = array[2];
							this.config.proxyPass = array[3];
						}
					}
				}
				else
				{
					this.status.connexion = status.ConnexionStatus.Connexion_login;
				}
				this.socket = new ElgSocketClient(this.MyServer().ip, this.MyServer().port, this.monId, this.config.proxyHost, this.config.proxyPort, this.config.proxyLogin, this.config.proxyPass, true, this.config.sock5);
				this.socket.OnConnexion += this.e_Connexion;
				this.socket.OnEnvoie += this.e_Envoi;
				this.socket.OnReception += this.e_Reception;
				this.socket.OnErreur += this.e_Erreur;
				this.socket.OnDeconnexion += this.e_Deconnexion;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000A840 File Offset: 0x00008A40
		public void CreateMitm()
		{
			try
			{
				this.MessagesToSend.Clear();
				Process client = this.config.Client;
				if (!Information.IsNothing(client) && client.HasExited)
				{
					this.mitm = null;
				}
			}
			catch (Exception ex)
			{
				this.mitm = null;
			}
			if (Information.IsNothing(this.mitm))
			{
				this.Initialiser();
				try
				{
					Process process = Process.Start(Config.pathDofus);
					this.config.Client = process;
					this.config.dllId = process.Id;
					this.mitm = new Injector(this.config.dllProcess);
					this.mitm.OnReception += this.e_ReceptionMimt;
					this.mitm.Onerror += this.e_ErrorMimt;
					this.mitm.OnEnvoie += this.e_EnvoieMimt;
					goto IL_154;
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Chemin d'acces Dofus invalide");
					return;
				}
			}
			if (this.lastRecepetion.Key.Where((Perso._Closure$__.$I79-0 == null) ? (Perso._Closure$__.$I79-0 = ((char c) => char.GetNumericValue(c) < 32.0)) : Perso._Closure$__.$I79-0).Count<char>() == 0 && this.map != null)
			{
				this.status.connexion = status.ConnexionStatus.const_3;
				return;
			}
			IL_154:
			Account.AutoLogin(this, this.config.Client);
			this.status.connexion = status.ConnexionStatus.Connexion_login;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000A9DC File Offset: 0x00008BDC
		public void CreateSock()
		{
			this.MessagesToSend.Clear();
			string hostNameOrAddress = this.ipServeurJeu.Replace(" ", "");
			this.status.connexion = status.ConnexionStatus.Connexion_en_jeu;
			if (!Information.IsNothing(this.sock))
			{
				this.sock.LaSocket.Close();
				this.sock.Dispose();
				this.sock = null;
			}
			IPAddress[] hostAddresses = Dns.GetHostAddresses(hostNameOrAddress);
			this.sock = new ElgSocketClient(hostAddresses[0].ToString(), this.MyServer().portGame, this.monId, this.config.proxyHost, this.config.proxyPort, this.config.proxyLogin, this.config.proxyPass, false, this.config.sock5);
			this.sock.OnConnexion += this.e_ConnexionJeu;
			this.sock.OnDeconnexion += this.e_Deconnexion;
			this.sock.OnEnvoie += this.e_Envoi;
			this.sock.OnReception += this.e_Reception;
			this.sock.OnErreur += this.e_Erreur;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00002B9E File Offset: 0x00000D9E
		public void e_Connexion(object sender, ElgSocketEventArgs e)
		{
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002B9E File Offset: 0x00000D9E
		public void e_ConnexionJeu(object sender, ElgSocketEventArgs e)
		{
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00002D3D File Offset: 0x00000F3D
		public void e_Deconnexion(object sender, ElgSocketEventArgs e)
		{
			this.status.connexion = status.ConnexionStatus.const_0;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000068B8 File Offset: 0x00004AB8
		public void e_Erreur(object sender, ElgSocketEventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000AB20 File Offset: 0x00008D20
		public void e_Envoi(object sender, ElgSocketEventArgs e)
		{
			try
			{
				this.chatHandler.AddTextChat(e.Message, "send");
				if (this.config.mitm && e.Message.Length > 3 && Operators.CompareString(e.Message.Substring(0, 3), "GKK", false) == 0)
				{
					int num = int.Parse(e.Message.Substring(3).Replace("\n", "").Replace("\0", ""));
					bool flag;
					if ((double)num != Conversions.ToDouble("0") && (double)num != Conversions.ToDouble("1"))
					{
						if ((double)num != Conversions.ToDouble("4"))
						{
							flag = false;
							goto IL_BF;
						}
					}
					flag = this.status.enDeplacement();
					IL_BF:
					if (flag)
					{
						this.movement.EndMove();
						this.status.Int32_0 = -1;
					}
				}
			}
			catch (Exception e2)
			{
				Fonctions.traiterErreur(e2);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000AC2C File Offset: 0x00008E2C
		public void e_ReceptionMimt(object Sender, byte[] e)
		{
			string text = new string(Encoding.ASCII.GetChars(e));
			List<string> list = text.Split(new char[1]).ToList<string>();
			list.RemoveAll((Perso._Closure$__.$I87-0 == null) ? (Perso._Closure$__.$I87-0 = ((string d) => Operators.CompareString(d, "", false) == 0)) : Perso._Closure$__.$I87-0);
			int num = 0;
			checked
			{
				try
				{
					foreach (string text2 in list)
					{
						num++;
						bool flag = Operators.CompareString(list.Last<string>(), text2, false) != 0 || Operators.CompareString(Conversions.ToString(text.Last<char>()), "\0", false) == 0;
						this.lastRecepetion = new KeyValuePair<string, DateTime>(this.lastRecepetion.Key + text2, DateTime.Now);
						if (flag)
						{
							text2 = Conversions.ToString(Fonctions.unprepareData(this.keyProtocol, this.lastRecepetion.Key));
							this.e_Reception(this, new ElgSocketEventArgs(text2));
							this.lastRecepetion = new KeyValuePair<string, DateTime>("", DateTime.Now);
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002B9E File Offset: 0x00000D9E
		public void e_ErrorMimt(object Sender, string e)
		{
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00002D4B File Offset: 0x00000F4B
		public void e_EnvoieMimt(object Sender, byte[] e)
		{
			this.e_Envoi(this, new ElgSocketEventArgs(new string(Encoding.UTF8.GetChars(e))));
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000AD64 File Offset: 0x00008F64
		public void e_Reception(object sender, ElgSocketEventArgs e)
		{
			checked
			{
				try
				{
					e.Message.Select((Perso._Closure$__.$I91-0 == null) ? (Perso._Closure$__.$I91-0 = ((char c) => char.GetUnicodeCategory(c))) : Perso._Closure$__.$I91-0).ToList<UnicodeCategory>();
					if (e.Message.Where((Perso._Closure$__.$I91-1 == null) ? (Perso._Closure$__.$I91-1 = ((char c) => char.GetUnicodeCategory(c) == UnicodeCategory.Control)) : Perso._Closure$__.$I91-1).Count<char>() == 0)
					{
						this.chatHandler.AddTextChat(e.Message, "rcv");
					}
					if (Operators.CompareString(e.Message, null, false) != 0)
					{
						if (this.status.connexion == status.ConnexionStatus.Recherche_proxy)
						{
							this.status.connexion = status.ConnexionStatus.Connexion_login;
						}
						if (Operators.CompareString(Strings.Mid(e.Message, 1, 4), "AXEf", false) != 0 && Operators.CompareString(Strings.Mid(e.Message, 1, 4), "AXEd", false) != 0 && Operators.CompareString(Strings.Mid(e.Message, 1, 2), "AX", false) == 0)
						{
							string str = Strings.Mid(e.Message, 4, 8);
							long num = 0L;
							long num2 = 0L;
							this.ipServeurJeu = "";
							while (num < 8L)
							{
								num += 1L;
								num2 += 1L;
								int num3 = Strings.Asc(Strings.Mid(str, (int)num, 1)) - 48;
								num += 1L;
								int num4 = Strings.Asc(Strings.Mid(str, (int)num, 1)) - 48;
								string text = Conversion.Str((num3 & 15) << 4 | (num4 & 15));
								if (num2 > 1L)
								{
									this.ipServeurJeu += Strings.Mid(text, 2);
								}
								else
								{
									this.ipServeurJeu += text;
								}
								if (num < 8L)
								{
									this.ipServeurJeu += ".";
								}
							}
						}
						if (Operators.CompareString(e.Message.Substring(0, 1), "M", false) == 0)
						{
							this.onServerMessage(e.Message.Substring(1));
						}
						if (this.status.connexion == status.ConnexionStatus.Connexion_login || this.status.connexion == status.ConnexionStatus.Connexion_en_jeu || this.status.connexion == status.ConnexionStatus.File_Attente)
						{
							Class12.smethod_0(this.monId, e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 2), "As", false) == 0)
						{
							this.InfosPerso = new InfoPerso(this.monId, e.Message.Substring(2));
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "cMK", false) == 0)
						{
							Class11.smethod_1(this.monId, e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 2), "GA", false) == 0 && Operators.CompareString(Strings.Mid(e.Message, 1, 3), "GAF", false) != 0)
						{
							this.actionParser.PacketGA(this.monId, e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 1), "E", false) == 0 || Operators.CompareString(Strings.Mid(e.Message, 1, 3), "ECK", false) == 0 || Operators.CompareString(Strings.Mid(e.Message, 1, 3), "KCK", false) == 0)
						{
							this.ExchangeManager.PacketEchange(this.monId, e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 1), "O", false) == 0)
						{
							this.Inventaire.PacketInventaire(e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "GDF", false) == 0)
						{
							Ressources.PacketRessources(this.monId, e.Message);
						}
						else if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "GCK", false) == 0)
						{
							this.monNom = Fonctions.Gettok(e.Message, "|", 3);
						}
						else
						{
							if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "GDM", false) == 0)
							{
								try
								{
									if (this.status.connexion > status.ConnexionStatus.const_0)
									{
										this.status.connexion = status.ConnexionStatus.const_3;
									}
									string text2 = Fonctions.Gettok(e.Message, "|", 2);
									string indice = Fonctions.Gettok(e.Message, "|", 3);
									string clef = Fonctions.Gettok(e.Message, "|", 4);
									if (this.lastmap == null || (double)this.map.id != Conversions.ToDouble(text2))
									{
										this.lastmap = this.map;
										this.nbCombat = 0;
									}
									this.map = new Maps(this.monId, text2, indice, clef);
									this.status.currentAction = 0;
									this.status.Int32_0 = -1;
									this.movement.destcell = -1;
									int num5 = 800;
									List<int> list = this.get_Slave(true);
									if (list.Count > 0)
									{
										num5 += ((this.Fight == null) ? list.Select((Perso._Closure$__.$I91-2 == null) ? (Perso._Closure$__.$I91-2 = ((int s) => Declarations.getComtpesById(s).config.globalSpeed)) : Perso._Closure$__.$I91-2).Max() : 800);
									}
									this.Fight = null;
									this.map.refresh();
									this.status.enEchange = false;
									this.map.loaded = true;
									num5 += (this.Inventaire.checkObjetTodelete() ? 1000 : 0);
									this.launcher.waitAction = num5;
									if (this.errorDeco)
									{
										this.errorDeco = false;
										Perso perso = Declarations.get_MyChef(this.monId);
										if (perso != null)
										{
											perso.Send(new Message("PI" + this.monNom, 1500, true, true, true));
										}
									}
									goto IL_6CC;
								}
								catch (Exception e2)
								{
									Fonctions.traiterErreur(e2);
									goto IL_6CC;
								}
							}
							if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "PIK", false) == 0)
							{
								this.ExchangeManager.onGroupInvite(e.Message);
							}
							else if (Operators.CompareString(Strings.Mid(e.Message, 1, 2), "PC", false) == 0 || Operators.CompareString(Strings.Mid(e.Message, 1, 2), "PV", false) != 0)
							{
							}
						}
						IL_6CC:
						if (Operators.CompareString(Strings.Mid(e.Message, 1, 2), "GM", false) == 0)
						{
							Actors.PacketMovement(this.monId, e.Message);
						}
						if (Operators.CompareString(Strings.Mid(e.Message, 1, 3), "ASK", false) == 0)
						{
							Objets.PacketObjets(this.monId, e.Message);
						}
						if (Operators.CompareString(Strings.Mid(e.Message, 1, 2), "Im", false) == 0)
						{
							string text3 = e.Message.Substring(2);
							text3 = Fonctions.Gettok(text3, ";", 1);
							if (Conversion.Val(text3) == 1170.0)
							{
								if (this.Fight != null)
								{
									string value = e.Message.Substring(7).Split(new char[]
									{
										'~'
									})[0];
									this.Fight.myFighter().AP = Conversions.ToInteger(value);
								}
							}
							else if (Conversion.Val(text3) == 1175.0)
							{
								this.ia.InvalidSpell();
							}
							else if ((Conversion.Val(text3) >= 1171.0 && Conversion.Val(text3) <= 1174.0) || Conversion.Val(text3) == 1193.0)
							{
								this.ia.InvalidCell();
							}
							double num6 = Conversion.Val(text3);
							if (num6 == 1169.0)
							{
								if (this.Fight != null && this.ia != null)
								{
									this.spellHandler.EquipeSort(this.ia.lastSpellLaunchId, true);
								}
							}
							else if (num6 == 34.0)
							{
								this.Send(new Message("GF", 500, false, true, true));
							}
							foreach (string value2 in Class6.smethod_38().ToLower().Split(new char[]
							{
								'|'
							}))
							{
								if (e.Message.ToLower().Contains(value2))
								{
									Licence.checking(true, this.MyServer().idServer);
									Declarations.disconnectAllComptes(this.MyServer().idServer);
								}
							}
						}
						Class13.smethod_0(e.Message, this.monId);
					}
				}
				catch (Exception e3)
				{
					Fonctions.traiterErreur(e3);
				}
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000B6D4 File Offset: 0x000098D4
		public async void SendGKK(int time)
		{
			try
			{
				TaskAwaiter taskAwaiter = Task.Delay(time).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				taskAwaiter = default(TaskAwaiter);
				if (this.status.Int32_0 >= 0)
				{
					this.Send(new Message("GKK" + Conversions.ToString(this.status.Int32_0), 200, false, false, true));
					this.status.Int32_0 = -1;
					this.launcher.waitAction = this.rand.Next(250, 400);
				}
				this.status.currentAction = 0;
			}
			catch (Exception ex)
			{
				Fonctions.traiterErreur(ex);
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000B714 File Offset: 0x00009914
		public void Send(Message m)
		{
			try
			{
				if ((m.allowMitm || Information.IsNothing(this.mitm)) && this.status.connexion != status.ConnexionStatus.const_0)
				{
					m.data = Conversions.ToString(Fonctions.prepareData(this.nkey, this.keyProtocol, m.data));
					object[] array = new object[3];
					array[0] = m.data;
					array[1] = m.time;
					if (m.time > 0)
					{
						if (this.Fight == null && m.speedGlobal)
						{
							object[] array2 = array;
							int num = 1;
							ref object ptr = ref array2[num];
							array2[num] = Operators.AddObject(ptr, this.config.globalSpeed);
						}
						this.MessagesToSend.Add(m);
					}
					else
					{
						if (!Information.IsNothing(this.sock) && (this.status.connexion == status.ConnexionStatus.Connexion_en_jeu || this.status.connexion == status.ConnexionStatus.const_3 || this.status.connexion == status.ConnexionStatus.File_Attente))
						{
							this.sock.Envoyer(m);
						}
						else if (!Information.IsNothing(this.socket))
						{
							this.socket.Envoyer(m);
						}
						if (!Information.IsNothing(this.mitm))
						{
							this.mitm.Send(m.data + "\n\0");
						}
					}
				}
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000B8A8 File Offset: 0x00009AA8
		private void method_0(object sender, EventArgs e)
		{
			ref int ptr = ref this.nombreSend;
			this.nombreSend = checked(ptr + 1);
			string text = this.config.floodPhrase;
			int num = this.rand.Next(0, 4);
			text += " [";
			text += Fonctions.RandomKey(num == 0, num == 1, num == 2);
			text += "]";
			if (num == 3)
			{
				text = text + " " + Fonctions.Smiley(this.rand);
			}
			this.Send(new Message("BM*|" + text + "|", 0, true, true, true));
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000B948 File Offset: 0x00009B48
		private void method_1(object sender, EventArgs e)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				lock (obj)
				{
					try
					{
						long num = 300L;
						switch (this.status.connexion)
						{
						case status.ConnexionStatus.const_0:
							if (!this.config.mitm && this.errorDeco)
							{
								num = unchecked((long)(checked(GlobalConfig.timeModo * 60 * 60)));
							}
							else
							{
								num = long.MaxValue;
							}
							break;
						case status.ConnexionStatus.Connexion_login:
							num = 15L;
							break;
						case status.ConnexionStatus.Connexion_en_jeu:
							num = 5L;
							break;
						case status.ConnexionStatus.Mauvais_Mot_de_passe:
							num = 60L;
							break;
						case status.ConnexionStatus.Compte_Bannie:
							num = long.MaxValue;
							break;
						case status.ConnexionStatus.File_Attente:
							num = (long)Math.Round(unchecked(5.0 + (Information.IsNothing(this.socket) ? 0.0 : ((double)this.socket.pingAverage / 1000.0))));
							break;
						case status.ConnexionStatus.Recherche_proxy:
							num = 1L;
							break;
						}
						if ((DateTime.Now - this.lastRecepetion.Value).TotalSeconds > (double)num)
						{
							this.lastRecepetion = new KeyValuePair<string, DateTime>(this.lastRecepetion.Key, DateTime.Now);
							if (!Information.IsNothing(this.mitm))
							{
								this.CreateMitm();
							}
							else
							{
								this.errorDeco = true;
								this.CreateSocket(true);
							}
						}
						int num2 = this.MessagesToSend.Count - 1;
						for (int i = 0; i <= num2; i++)
						{
							Message message = this.MessagesToSend[i];
							ref int ptr = ref message.time;
							message.time = (int)Math.Round(unchecked((double)ptr - this.TimerLaunch.Interval));
							if (this.MessagesToSend[i].time <= 0)
							{
								this.Send(this.MessagesToSend[i]);
								this.MessagesToSend.RemoveAt(i);
								return;
							}
						}
						if (this.status.connexion == status.ConnexionStatus.const_3)
						{
							Licence.checkModos();
							if (((DateTime.Now - this.lastInactivite).TotalSeconds > 60.0 && this.status.connexion == status.ConnexionStatus.const_3) & !this.status.enEchange)
							{
								if (!Information.IsNothing(this.config.Client))
								{
									Input.SendKey(13, this.config.Client, 0, null);
								}
								this.lastInactivite = DateTime.Now;
							}
							if (!this.method_2((int)Math.Round(this.TimerLaunch.Interval)))
							{
								if (this.mode > 0 && (DateTime.Now - this.lastActivity).TotalSeconds > unchecked((double)this.config.globalSpeed / 1000.0 + 30.0) && this.map.refresh())
								{
									this.lastActivity = DateTime.Now;
								}
								if (!Information.IsNothing(this.map))
								{
									if (this.launcher.waitAction <= 0 && this.launcher.waitAction != -1)
									{
										if (!this.config.mitm && this.status.enDeplacement())
										{
											this.SendGKK(0);
											this.movement.EndMove();
										}
										else
										{
											if ((DateTime.Now - this.lasteatFamilier).TotalMilliseconds > 500.0 && this.MessagesToSend.FirstOrDefault((Perso._Closure$__.$I99-0 == null) ? (Perso._Closure$__.$I99-0 = ((Message m) => Operators.CompareString(m.data.Substring(0, 2), "OM", false) == 0)) : Perso._Closure$__.$I99-0) == null)
											{
												this.lasteatFamilier = DateTime.Now;
												if (Conversions.ToBoolean(Famillier.EatToAll(this.familiers)))
												{
													return;
												}
											}
											if (this.status.isIdle())
											{
												this.lastTaskUpdateLaunch = new Task(delegate()
												{
													this.launcher.UpdateLaunch();
												});
												this.lastTaskUpdateLaunch.Start();
											}
										}
									}
									else
									{
										AutoLaunch autoLaunch = this.launcher;
										ref int ptr = ref autoLaunch.waitAction;
										autoLaunch.waitAction = (int)Math.Round(unchecked((double)ptr - this.TimerLaunch.Interval));
									}
								}
							}
						}
					}
					catch (Exception e2)
					{
						Fonctions.traiterErreur(e2);
					}
				}
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00002B9E File Offset: 0x00000D9E
		public void Debug(string Text)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002D69 File Offset: 0x00000F69
		public void sendMP(string nomDuMec, string msg)
		{
			this.Send(new Message("BM" + nomDuMec + "|" + msg, 0, true, true, true));
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000BE04 File Offset: 0x0000A004
		public void setChef(int chef)
		{
			Perso perso = Declarations.get_MyChef(this.monId);
			if (perso != null)
			{
				if (perso.idChef == chef)
				{
					return;
				}
				perso.get_Slave(false).Remove(int.Parse(this.monIdDofus));
				perso.Send(new Message("PV" + this.monIdDofus, 200, true, true, true));
			}
			this.nomChef = "";
			this.idChef = chef;
			if (this.idChef > 0)
			{
				Perso comtpesById = Declarations.getComtpesById(chef);
				this.nomChef = comtpesById.monNom;
				if (!comtpesById.get_Slave(false).Contains(Conversions.ToInteger(this.monIdDofus)))
				{
					comtpesById.get_Slave(false).Add(int.Parse(this.monIdDofus));
				}
				comtpesById.Send(new Message("PI" + this.monNom, 1500, true, true, true));
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		public int useItem(int itemId, int quantity)
		{
			Objets objectByIdInv = this.Inventaire.getObjectByIdInv((long)itemId);
			checked
			{
				int result;
				if (!Information.IsNothing(objectByIdInv))
				{
					int num = quantity - 1;
					for (int i = 0; i <= num; i++)
					{
						if (objectByIdInv.numObjet <= 0L)
						{
							return i;
						}
						this.Send(new Message("OU" + Conversions.ToString(objectByIdInv.idObjetInv), i * this.rand.Next(800, 1200), true, true, true));
					}
					result = quantity;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000BF84 File Offset: 0x0000A184
		public string Etat
		{
			get
			{
				string text = "";
				string result;
				if (this.status == null)
				{
					result = "Hors ligne";
				}
				else
				{
					switch (this.status.connexion)
					{
					case status.ConnexionStatus.const_0:
						text = "Hors ligne";
						break;
					case status.ConnexionStatus.Connexion_login:
						text = "Connexion login";
						break;
					case status.ConnexionStatus.Connexion_en_jeu:
						text = "Connexion en jeu";
						break;
					case status.ConnexionStatus.const_3:
						if (this.status.enCombat())
						{
							text = "En combat";
						}
						else if (this.status.enFauche())
						{
							text = "En recolte";
						}
						else if (this.status.enDeplacement())
						{
							text = "En déplacement";
						}
						else if (Conversions.ToBoolean(this.status.NeedRegen))
						{
							text = "En regénération";
						}
						else if (this.status.enEchange)
						{
							text = "En échange";
						}
						else
						{
							text = "En attente";
						}
						this.lastStatut = text;
						if (Operators.CompareString(text, this.lastStatut, false) != 0 || Operators.CompareString(text, "En attente", false) != 0)
						{
							this.lastActivity = DateTime.Now;
						}
						break;
					case status.ConnexionStatus.Mauvais_Mot_de_passe:
						text = "Mauvais mot de passe";
						break;
					case status.ConnexionStatus.Compte_Bannie:
						text = "Compte bannie";
						break;
					case status.ConnexionStatus.Serveur_Plein:
						text = "Serveur plein";
						break;
					case status.ConnexionStatus.Serveur_en_Sauvegarde:
						text = "Serveur";
						break;
					case status.ConnexionStatus.File_Attente:
						text = "File d'attente";
						break;
					case status.ConnexionStatus.Mauvaise_Configuration:
						text = "Mauvaise configuration";
						break;
					case status.ConnexionStatus.Recherche_proxy:
						text = "Recherche de proxy";
						break;
					}
					result = text;
				}
				return result;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
		private bool method_2(int int_2)
		{
			checked
			{
				bool result;
				if (this.InfosPerso == null)
				{
					result = false;
				}
				else
				{
					bool flag = false;
					if (this.InfosPerso.LP < this.InfosPerso.LPmax)
					{
						ref object ptr = ref this.object_1;
						this.object_1 = Operators.SubtractObject(ptr, int_2);
						if (Operators.ConditionalCompareObjectLessEqual(this.object_1, 0, false))
						{
							this.object_1 = 1200;
							if (flag = Conversions.ToBoolean(this.status.NeedRegen))
							{
								if (!this.status.sit)
								{
									this.Send(new Message("eU1", 1500, true, true, true));
									this.status.sit = true;
								}
								if (this.config.itemRegen > 0)
								{
									Objets objectById = this.Inventaire.getObjectById(this.config.itemRegen);
									if (!Information.IsNothing(objectById))
									{
										this.useItem((int)objectById.idObjetInv, 1);
									}
								}
							}
							else if (this.status.sit)
							{
								this.status.sit = false;
							}
							if (!this.status.enCombat())
							{
								InfoPerso infosPerso = this.InfosPerso;
								ref int ptr2 = ref infosPerso.LP;
								infosPerso.LP = ptr2 + (this.status.sit ? 2 : 1);
							}
						}
					}
					else if (this.status.sit)
					{
						this.status.sit = false;
					}
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000C26C File Offset: 0x0000A46C
		public object CheckFight()
		{
			object result;
			if (this.config.AuBoutDeCombats > 0 && this.nbCombat >= this.config.AuBoutDeCombats)
			{
				this.nbCombat = 0;
				this.chatHandler.AddTextChat("Reached fight count on map", "debug");
				result = false;
			}
			else if (Information.IsNothing(this.map) || this.status.connexion != status.ConnexionStatus.const_3)
			{
				result = false;
			}
			else
			{
				List<MonsterGroupe> list = this.map.monsters(null, this.config.AttakOrder);
				if (decimal.Compare(this.config.lvlmin, 0m) > 0)
				{
					list = (from m in list
					where decimal.Compare(new decimal(m.levels.Sum()), this.config.lvlmin) >= 0
					select m).ToList<MonsterGroupe>();
				}
				if (decimal.Compare(this.config.lvlmax, 0m) > 0)
				{
					list = (from m in list
					where decimal.Compare(new decimal(m.levels.Sum()), this.config.lvlmax) <= 0
					select m).ToList<MonsterGroupe>();
				}
				try
				{
					List<MonsterGroupe>.Enumerator enumerator = list.ToList<MonsterGroupe>().GetEnumerator();
					while (enumerator.MoveNext())
					{
						Perso._Closure$__112-0 CS$<>8__locals1 = new Perso._Closure$__112-0(CS$<>8__locals1);
						CS$<>8__locals1.$VB$Local_mon = enumerator.Current;
						if ((from s in this.config.monstersDennied
						where CS$<>8__locals1.$VB$Local_mon.names.Contains(s)
						select s).Count<string>() > 0)
						{
							list.Remove(CS$<>8__locals1.$VB$Local_mon);
						}
						else if (this.config.monstersAllow.Count > 0 && (from s in this.config.monstersAllow
						where CS$<>8__locals1.$VB$Local_mon.names.Contains(s)
						select s).Count<string>() == 0)
						{
							list.Remove(CS$<>8__locals1.$VB$Local_mon);
						}
					}
				}
				finally
				{
					List<MonsterGroupe>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				try
				{
					foreach (MonsterGroupe monsterGroupe in list)
					{
						if (monsterGroupe.Cell == -1)
						{
							this.chatHandler.AddTextChat("MonsterGroup removed must map refresh", "debug");
							this.map.refresh();
							return false;
						}
						this.movement.destAction = "fight";
						if (this.movement.SeDeplacer(monsterGroupe.Cell, -1))
						{
							return true;
						}
					}
				}
				finally
				{
					List<MonsterGroupe>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				result = (list.Count > 0);
			}
			return result;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000C4F8 File Offset: 0x0000A6F8
		public async void onNewLevel(string v)
		{
			checked
			{
				try
				{
					TaskAwaiter taskAwaiter = Task.Delay(3500).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					taskAwaiter = default(TaskAwaiter);
					KeyValuePair<int, byte> spellLevel = this.spellHandler.SpellsList.FirstOrDefault((KeyValuePair<int, byte> s) => s.Key == this.config.SpellToBoost);
					if (spellLevel.Key > 0 && (!Information.IsNothing(this.map.myActor()) && this.InfosPerso.BonusPointsSpell >= (short)spellLevel.Value && (int)Loader.getSpellById(this.config.SpellToBoost).Levels[(int)(spellLevel.Value - 1)].level <= this.map.myActor().level))
					{
						this.Send(new Message("SB" + Conversions.ToString(this.config.SpellToBoost), 0, true, true, true));
					}
					if (this.InfosPerso.BonusPoints >= 0 && !Information.IsNothing(this.config.autoboost) && this.config.autoboost.Length > 2)
					{
						int bonusPoints = (int)this.InfosPerso.BonusPoints;
						for (int i = 1; i <= bonusPoints; i++)
						{
							string autoboost = this.config.autoboost;
							string left = autoboost;
							if (Operators.CompareString(left, "Vitalité", false) != 0)
							{
								if (Operators.CompareString(left, "Sagesse", false) != 0)
								{
									if (Operators.CompareString(left, "Force", false) != 0)
									{
										if (Operators.CompareString(left, "Intelligence", false) != 0)
										{
											if (Operators.CompareString(left, "Chance", false) != 0)
											{
												if (Operators.CompareString(left, "Agilité", false) == 0)
												{
													this.Send(new Message("AB14", i * this.rand.Next(500, 1000), true, true, true));
												}
											}
											else
											{
												this.Send(new Message("AB13", i * this.rand.Next(500, 1000), true, true, true));
											}
										}
										else
										{
											this.Send(new Message("AB15", i * this.rand.Next(500, 1000), true, true, true));
										}
									}
									else
									{
										this.Send(new Message("AB10", i * this.rand.Next(500, 1000), true, true, true));
									}
								}
								else
								{
									this.Send(new Message("AB12", i * this.rand.Next(500, 1000), true, true, true));
								}
							}
							else
							{
								this.Send(new Message("AB11", i * this.rand.Next(500, 1000), true, true, true));
							}
						}
					}
					if (GlobalConfig.notifLevelUP && this.myCharacter != null)
					{
						Fonctions.sendNotif(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(this.monNom + ": Viens de passer au  niveau ", (this.myCharacter != null) ? this.myCharacter.level : "supérieur"))));
					}
				}
				catch (Exception ex)
				{
					Fonctions.traiterErreur(ex);
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002D8B File Offset: 0x00000F8B
		public void JoinCombat(string idcombat, int time)
		{
			this.MessagesToSend.Clear();
			this.Send(new Message("GA903" + idcombat + ";" + idcombat, time, true, true, true));
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000C538 File Offset: 0x0000A738
		public void onServerMessage(string data)
		{
			string[] array = data.Split(new char[]
			{
				'|'
			});
			if (Operators.CompareString(array[0], "112", false) == 0)
			{
				this.Send(new Message("GF", 3500, false, true, true));
			}
			else if (Operators.CompareString(array[0], "018", false) == 0)
			{
				Licence.checking(true, this.MyServer().idServer);
				Declarations.disconnectAllComptes(this.MyServer().idServer);
			}
			else if (Operators.CompareString(array[0], "118", false) == 0)
			{
				Licence.checking(true, this.MyServer().idServer);
				Declarations.disconnectAllComptes(this.MyServer().idServer);
			}
			else if (Operators.CompareString(array[0], "030", false) == 0 && !this.config.mitm)
			{
				this.lastRecepetion = new KeyValuePair<string, DateTime>("reco", DateTime.Now.AddSeconds(15.0));
				if (!this.config.mitm)
				{
					Thread.Sleep(1500);
					this.CreateSocket(false);
				}
			}
		}

		// Token: 0x040000A4 RID: 164
		public Config config;

		// Token: 0x040000A5 RID: 165
		public Random rand;

		// Token: 0x040000A6 RID: 166
		public int monId;

		// Token: 0x040000A7 RID: 167
		public string ipServeurJeu;

		// Token: 0x040000A8 RID: 168
		public string idConnexion;

		// Token: 0x040000A9 RID: 169
		public string identity;

		// Token: 0x040000AA RID: 170
		public DateTime lastInactivite;

		// Token: 0x040000AB RID: 171
		public string keyProtocol;

		// Token: 0x040000AC RID: 172
		public int nkey;

		// Token: 0x040000AD RID: 173
		public bool errorDeco;

		// Token: 0x040000AE RID: 174
		public string monNom;

		// Token: 0x040000AF RID: 175
		public string monIdDofus;

		// Token: 0x040000B0 RID: 176
		public string nomChef;

		// Token: 0x040000B1 RID: 177
		private int int_0;

		// Token: 0x040000B2 RID: 178
		private List<int> list_0;

		// Token: 0x040000B3 RID: 179
		[AccessedThroughProperty("TimerFlood")]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private System.Timers.Timer timer_0;

		// Token: 0x040000B4 RID: 180
		public int nombreSend;

		// Token: 0x040000B5 RID: 181
		public int mode;

		// Token: 0x040000B6 RID: 182
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("TimerLaunch")]
		private System.Timers.Timer timer_1;

		// Token: 0x040000B7 RID: 183
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Perso.OnActionFinishEventHandler onActionFinishEventHandler_0;

		// Token: 0x040000B8 RID: 184
		public Maps map;

		// Token: 0x040000B9 RID: 185
		public InfoPerso InfosPerso;

		// Token: 0x040000BA RID: 186
		public status status;

		// Token: 0x040000BB RID: 187
		public MovementHandler movement;

		// Token: 0x040000BC RID: 188
		public JobHandler Jobs;

		// Token: 0x040000BD RID: 189
		public SpellHandler spellHandler;

		// Token: 0x040000BE RID: 190
		public Combat Fight;

		// Token: 0x040000BF RID: 191
		public trajetManager MovementTrajet;

		// Token: 0x040000C0 RID: 192
		public LuaTrajet LuaTrajet;

		// Token: 0x040000C1 RID: 193
		public DCManager DCTrajet;

		// Token: 0x040000C2 RID: 194
		public RandomMoveManager movementRandom;

		// Token: 0x040000C3 RID: 195
		public IA ia;

		// Token: 0x040000C4 RID: 196
		public List<FightStatsEntry> FightResult;

		// Token: 0x040000C5 RID: 197
		public KeyValuePair<string, DateTime> lastRecepetion;

		// Token: 0x040000C6 RID: 198
		public ChatHandler chatHandler;

		// Token: 0x040000C7 RID: 199
		public DateTime lastRecepetionFight;

		// Token: 0x040000C8 RID: 200
		public ElgSocketClient socket;

		// Token: 0x040000C9 RID: 201
		public ElgSocketClient sock;

		// Token: 0x040000CA RID: 202
		public Injector mitm;

		// Token: 0x040000CB RID: 203
		public AutoLaunch launcher;

		// Token: 0x040000CC RID: 204
		public Action actionParser;

		// Token: 0x040000CD RID: 205
		public List<Famillier> familiers;

		// Token: 0x040000CE RID: 206
		public DateTime lasteatFamilier;

		// Token: 0x040000CF RID: 207
		public List<Message> MessagesToSend;

		// Token: 0x040000D0 RID: 208
		public DateTime lastActivity;

		// Token: 0x040000D1 RID: 209
		public string lastStatut;

		// Token: 0x040000D2 RID: 210
		public static object LockComptes;

		// Token: 0x040000D3 RID: 211
		public string nomRessource;

		// Token: 0x040000D4 RID: 212
		public int idRessource;

		// Token: 0x040000D5 RID: 213
		public string idMaitre;

		// Token: 0x040000D6 RID: 214
		public string nomMaitre;

		// Token: 0x040000D7 RID: 215
		public Inventaire Inventaire;

		// Token: 0x040000D8 RID: 216
		public Interactive interactiveManager;

		// Token: 0x040000D9 RID: 217
		public Echange ExchangeManager;

		// Token: 0x040000DA RID: 218
		private static int int_1;

		// Token: 0x040000DB RID: 219
		private object object_0;

		// Token: 0x040000DC RID: 220
		private string string_0;

		// Token: 0x040000DD RID: 221
		public Task lastTaskUpdateLaunch;

		// Token: 0x040000DE RID: 222
		public DateTime lastSendModo;

		// Token: 0x040000DF RID: 223
		public bool receptionRCV;

		// Token: 0x040000E0 RID: 224
		public int lastSendId;

		// Token: 0x040000E1 RID: 225
		private object object_1;

		// Token: 0x040000E2 RID: 226
		public Maps lastmap;

		// Token: 0x040000E3 RID: 227
		public int nbCombat;

		// Token: 0x0200002E RID: 46
		// (Invoke) Token: 0x0600012D RID: 301
		public delegate void OnActionFinishEventHandler(object sender);

		// Token: 0x0200002F RID: 47
		// (Invoke) Token: 0x06000131 RID: 305
		public delegate void DebugDelegate(string Text);

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x06000135 RID: 309
		public delegate void ThreadDelegate();
	}
}
