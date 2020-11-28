using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SocketIOClient;

namespace WindowsApplication2
{
	// Token: 0x020000A8 RID: 168
	[StandardModule]
	public sealed class Declarations
	{
		// Token: 0x06000382 RID: 898 RVA: 0x0001BEC4 File Offset: 0x0001A0C4
		static Declarations()
		{
			Class15.XRATSHnz66atd();
			Declarations.comptes = new List<Perso>();
			Declarations.cases = new string[2501];
			Declarations.toDebug = false;
			Declarations.smileyList1 = new string[]
			{
				": ",
				";",
				";-",
				":-",
				"=",
				"='"
			};
			Declarations.smileyList2 = "dD)]pP";
			Declarations.lettre = "abcdefghijklmnopqrstuvwxyz";
			Declarations.chiffre = "0123456789";
			Declarations.symbole = "~#'-\\_^+,?./§!°%¨$*";
			Declarations.proxys = new List<string>();
			Declarations.proxys5 = new List<string>();
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001BF6C File Offset: 0x0001A16C
		public static Perso getComtpesByIndex(int index)
		{
			return Declarations.comptes[index];
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0001BF88 File Offset: 0x0001A188
		public static void delCompte(int index)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			lock (lockComptes)
			{
				Declarations.comptes[index] = null;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001BFD4 File Offset: 0x0001A1D4
		public static void disconnectAllComptes(int serverId)
		{
			Declarations._Closure$__7-0 CS$<>8__locals1 = new Declarations._Closure$__7-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_serverId = serverId;
			try
			{
				bool flag = false;
				try
				{
					foreach (Perso perso in Declarations.comptes.Where((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = ((Perso co) => co.status != null && co.MyServer().idServer == CS$<>8__locals1.$VB$Local_serverId)) : CS$<>8__locals1.$I0))
					{
						if (perso.Fight != null)
						{
							perso.Fight.giveUp();
							Thread.Sleep(500);
						}
						if (perso.socket != null)
						{
							perso.socket.Connexion(false);
							perso.socket = null;
						}
						if (perso.sock != null)
						{
							perso.sock.Connexion(false);
							perso.sock = null;
						}
						if (perso.mitm != null && perso.config.Client != null && !perso.config.Client.HasExited)
						{
							perso.config.Client.Kill();
						}
						perso.status.connexion = status.ConnexionStatus.const_0;
						flag = true;
						perso.errorDeco = true;
						perso.lastRecepetion = new KeyValuePair<string, DateTime>("", DateTime.Now);
					}
				}
				finally
				{
					IEnumerator<Perso> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				if (flag)
				{
					Task task = new Task((Declarations._Closure$__.$I7-1 == null) ? (Declarations._Closure$__.$I7-1 = delegate()
					{
						MessageBox.Show("Un utilisateur à été ban, les bots sont donc déconnéctés", "Alerte aux gogoles les enfants 2 !!!");
					}) : Declarations._Closure$__.$I7-1);
					task.Start();
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001C1A8 File Offset: 0x0001A3A8
		public static string ComptesNames()
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			string result;
			lock (lockComptes)
			{
				result = string.Join("|", Declarations.comptes.Where((Declarations._Closure$__.$I8-0 == null) ? (Declarations._Closure$__.$I8-0 = ((Perso c) => c != null)) : Declarations._Closure$__.$I8-0).Select((Declarations._Closure$__.$I8-1 == null) ? (Declarations._Closure$__.$I8-1 = ((Perso c) => c.config.nomDuCompte)) : Declarations._Closure$__.$I8-1).ToList<string>());
			}
			return result;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001C250 File Offset: 0x0001A450
		public static List<Perso> ComptesOnline()
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			List<Perso> result;
			lock (lockComptes)
			{
				result = Declarations.comptes.Where((Declarations._Closure$__.$I9-0 == null) ? (Declarations._Closure$__.$I9-0 = ((Perso c) => !Information.IsNothing(c) && !Information.IsNothing(c.status) && c.status.connexion == status.ConnexionStatus.const_3)) : Declarations._Closure$__.$I9-0).ToList<Perso>();
			}
			return result;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
		public static void AddCompte(Perso p)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			lock (lockComptes)
			{
				if (Declarations.comptes.Where((Declarations._Closure$__.$I10-0 == null) ? (Declarations._Closure$__.$I10-0 = ((Perso c) => c != null)) : Declarations._Closure$__.$I10-0).Count<Perso>() < 8)
				{
					Declarations.comptes.Add(p);
				}
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001C348 File Offset: 0x0001A548
		public static Perso getComtpesById(int id)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			Perso result;
			lock (lockComptes)
			{
				result = Declarations.comptes.FirstOrDefault((Perso p) => Conversions.ToDouble(p.monIdDofus) == (double)id);
			}
			return result;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0001C3AC File Offset: 0x0001A5AC
		public static Perso getComtpesByName(string name)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			Perso result;
			lock (lockComptes)
			{
				result = Declarations.comptes.FirstOrDefault((Perso p) => Operators.CompareString(p.monNom.ToLower(), name.ToLower(), false) == 0);
			}
			return result;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0001C410 File Offset: 0x0001A610
		public static int nbCompte()
		{
			return Declarations.comptes.Count;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0001C42C File Offset: 0x0001A62C
		public static Perso getCompteByDllId(int DllId)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			Perso result;
			lock (lockComptes)
			{
				result = Declarations.comptes.FirstOrDefault((Perso c) => c.config.dllId == DllId);
			}
			return result;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001C490 File Offset: 0x0001A690
		public static Perso getComtpesByAccountName(string name)
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			Perso result;
			lock (lockComptes)
			{
				result = Declarations.comptes.FirstOrDefault((Perso c) => c != null && Operators.CompareString(c.config.nomDuCompte.ToLower(), name.ToLower(), false) == 0);
			}
			return result;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		public static List<Perso> getUniqueCompteFromServeur()
		{
			object lockComptes = Perso.LockComptes;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
			List<Perso> result;
			lock (lockComptes)
			{
				List<Perso> source = Declarations.comptes.Where((Declarations._Closure$__.$I16-0 == null) ? (Declarations._Closure$__.$I16-0 = ((Perso p) => p.status != null && p.status.connexion == status.ConnexionStatus.const_3)) : Declarations._Closure$__.$I16-0).ToList<Perso>();
				List<Perso> list = new List<Perso>();
				List<int> list2 = new List<int>();
				try
				{
					foreach (Perso perso in source.ToList<Perso>())
					{
						int idServer = perso.MyServer().idServer;
						if (!list2.Contains(idServer))
						{
							list2.Add(idServer);
							list.Add(perso);
						}
					}
				}
				finally
				{
					List<Perso>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				result = list;
			}
			return result;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600038F RID: 911 RVA: 0x0001C5E4 File Offset: 0x0001A7E4
		public static int mySlaveIndex
		{
			get
			{
				Perso comtpesByIndex = Declarations.getComtpesByIndex(index);
				object lockComptes = Perso.LockComptes;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
				checked
				{
					lock (lockComptes)
					{
						int num = 0;
						if (comtpesByIndex.idChef != 0)
						{
							try
							{
								foreach (Perso perso in Declarations.comptes)
								{
									if (Operators.CompareString(perso.monIdDofus, comtpesByIndex.monIdDofus, false) == 0)
									{
										return num;
									}
									if (perso.idChef == comtpesByIndex.idChef)
									{
										num++;
									}
								}
							}
							finally
							{
								List<Perso>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					return -1;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0001C6AC File Offset: 0x0001A8AC
		public static Perso MyChef
		{
			get
			{
				Perso bot = Declarations.getComtpesByIndex(index);
				object lockComptes = Perso.LockComptes;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
				Perso result;
				lock (lockComptes)
				{
					result = Declarations.comptes.FirstOrDefault((Perso c) => c != null && c.monIdDofus != null && Conversions.ToDouble(c.monIdDofus) == (double)bot.idChef);
				}
				return result;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0001C718 File Offset: 0x0001A918
		public static bool InMyGroup
		{
			get
			{
				Declarations.getComtpesByIndex(index);
				object lockComptes = Perso.LockComptes;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockComptes);
				bool result;
				lock (lockComptes)
				{
					result = (idDofus == Declarations.comptes[index].idChef || Declarations.comptes.FirstOrDefault((Perso c) => Conversions.ToDouble(c.monIdDofus) == (double)idDofus && c.idChef == Declarations.comptes[index].idChef) != null);
				}
				return result;
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0001C7B4 File Offset: 0x0001A9B4
		public static void CreateDiscordSock()
		{
			try
			{
				Task.Run((Declarations._Closure$__.$I23-0 == null) ? (Declarations._Closure$__.$I23-0 = delegate()
				{
					Declarations.clientDiscord = new SocketIO("http://51.91.67.174:5100/");
					Declarations.clientDiscord.On("cmd", (Declarations._Closure$__.$I23-1 == null) ? (Declarations._Closure$__.$I23-1 = delegate(SocketIOResponse res)
					{
						string[] array = res.GetValue<string>(0).Split(new char[]
						{
							' '
						});
						if (array.Length > 2)
						{
							int startIndex = checked(array[0].Length + array[1].Length + 2);
							string[] array2 = res.GetValue<string>(0).Substring(startIndex).Split(new char[]
							{
								'|'
							});
							Perso comtpesByName = Declarations.getComtpesByName(array2[0]);
							if (comtpesByName != null)
							{
								string left = array[1];
								if (Operators.CompareString(left, "chatMP", false) == 0)
								{
									comtpesByName.sendMP(array2[1], array2[2]);
								}
							}
						}
					}) : Declarations._Closure$__.$I23-1);
					Declarations.clientDiscord.OnConnected += Declarations.smethod_0;
					Declarations.clientDiscord.ConnectAsync();
				}) : Declarations._Closure$__.$I23-0);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000040CD File Offset: 0x000022CD
		private static void smethod_0(object sender, EventArgs e)
		{
			Declarations.sendToDiscord("register", "");
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0001C80C File Offset: 0x0001AA0C
		public static async void sendToDiscord(string cmd, string args)
		{
			try
			{
				TaskAwaiter taskAwaiter = Declarations.clientDiscord.EmitAsync("cmd", new object[]
				{
					string.Concat(new string[]
					{
						cmd,
						"|",
						Config.string_0,
						"|",
						args
					})
				}).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				taskAwaiter = default(TaskAwaiter);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0001C84C File Offset: 0x0001AA4C
		public static async void sendTextToDiscord(string txt)
		{
			try
			{
				TaskAwaiter taskAwaiter = Declarations.clientDiscord.EmitAsync("cmd", new object[]
				{
					"replyText|" + Config.string_0 + "|" + txt
				}).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				taskAwaiter = default(TaskAwaiter);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x040003F9 RID: 1017
		public static List<Perso> comptes;

		// Token: 0x040003FA RID: 1018
		public static string[] cases;

		// Token: 0x040003FB RID: 1019
		public static SocketIO clientDiscord;

		// Token: 0x040003FC RID: 1020
		public static bool toDebug;

		// Token: 0x040003FD RID: 1021
		public static string[] smileyList1;

		// Token: 0x040003FE RID: 1022
		public static string smileyList2;

		// Token: 0x040003FF RID: 1023
		public static string lettre;

		// Token: 0x04000400 RID: 1024
		public static string chiffre;

		// Token: 0x04000401 RID: 1025
		public static string symbole;

		// Token: 0x04000402 RID: 1026
		public static List<string> proxys;

		// Token: 0x04000403 RID: 1027
		public static List<string> proxys5;
	}
}
