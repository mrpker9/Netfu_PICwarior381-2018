using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Org.Mentalis.Network.ProxySocket;

namespace WindowsApplication2
{
	/// <summary>
	/// Class permettant la gestion des connexions vers le serveur
	/// </summary>
	/// <auteur>LEVEUGLE Damien</auteur>
	/// <copyright>Elguevel Software 2008</copyright>
	/// <version>1.0</version>
	/// <remarks>Module client</remarks>
	// Token: 0x02000013 RID: 19
	public class ElgSocketClient : IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000075 RID: 117 RVA: 0x00006918 File Offset: 0x00004B18
		// (remove) Token: 0x06000076 RID: 118 RVA: 0x00006950 File Offset: 0x00004B50
		public event ElgSocketClient.OnReceptionEventHandler OnReception
		{
			[CompilerGenerated]
			add
			{
				ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler = this.onReceptionEventHandler_0;
				ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler2;
				do
				{
					onReceptionEventHandler2 = onReceptionEventHandler;
					ElgSocketClient.OnReceptionEventHandler value2 = (ElgSocketClient.OnReceptionEventHandler)Delegate.Combine(onReceptionEventHandler2, value);
					onReceptionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnReceptionEventHandler>(ref this.onReceptionEventHandler_0, value2, onReceptionEventHandler2);
				}
				while (onReceptionEventHandler != onReceptionEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler = this.onReceptionEventHandler_0;
				ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler2;
				do
				{
					onReceptionEventHandler2 = onReceptionEventHandler;
					ElgSocketClient.OnReceptionEventHandler value2 = (ElgSocketClient.OnReceptionEventHandler)Delegate.Remove(onReceptionEventHandler2, value);
					onReceptionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnReceptionEventHandler>(ref this.onReceptionEventHandler_0, value2, onReceptionEventHandler2);
				}
				while (onReceptionEventHandler != onReceptionEventHandler2);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000077 RID: 119 RVA: 0x00006988 File Offset: 0x00004B88
		// (remove) Token: 0x06000078 RID: 120 RVA: 0x000069C0 File Offset: 0x00004BC0
		public event ElgSocketClient.OnConnexionEventHandler OnConnexion
		{
			[CompilerGenerated]
			add
			{
				ElgSocketClient.OnConnexionEventHandler onConnexionEventHandler = this.onConnexionEventHandler_0;
				ElgSocketClient.OnConnexionEventHandler onConnexionEventHandler2;
				do
				{
					onConnexionEventHandler2 = onConnexionEventHandler;
					ElgSocketClient.OnConnexionEventHandler value2 = (ElgSocketClient.OnConnexionEventHandler)Delegate.Combine(onConnexionEventHandler2, value);
					onConnexionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnConnexionEventHandler>(ref this.onConnexionEventHandler_0, value2, onConnexionEventHandler2);
				}
				while (onConnexionEventHandler != onConnexionEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ElgSocketClient.OnConnexionEventHandler onConnexionEventHandler = this.onConnexionEventHandler_0;
				ElgSocketClient.OnConnexionEventHandler onConnexionEventHandler2;
				do
				{
					onConnexionEventHandler2 = onConnexionEventHandler;
					ElgSocketClient.OnConnexionEventHandler value2 = (ElgSocketClient.OnConnexionEventHandler)Delegate.Remove(onConnexionEventHandler2, value);
					onConnexionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnConnexionEventHandler>(ref this.onConnexionEventHandler_0, value2, onConnexionEventHandler2);
				}
				while (onConnexionEventHandler != onConnexionEventHandler2);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000079 RID: 121 RVA: 0x000069F8 File Offset: 0x00004BF8
		// (remove) Token: 0x0600007A RID: 122 RVA: 0x00006A30 File Offset: 0x00004C30
		public event ElgSocketClient.OnDeconnexionEventHandler OnDeconnexion
		{
			[CompilerGenerated]
			add
			{
				ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler = this.onDeconnexionEventHandler_0;
				ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler2;
				do
				{
					onDeconnexionEventHandler2 = onDeconnexionEventHandler;
					ElgSocketClient.OnDeconnexionEventHandler value2 = (ElgSocketClient.OnDeconnexionEventHandler)Delegate.Combine(onDeconnexionEventHandler2, value);
					onDeconnexionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnDeconnexionEventHandler>(ref this.onDeconnexionEventHandler_0, value2, onDeconnexionEventHandler2);
				}
				while (onDeconnexionEventHandler != onDeconnexionEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler = this.onDeconnexionEventHandler_0;
				ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler2;
				do
				{
					onDeconnexionEventHandler2 = onDeconnexionEventHandler;
					ElgSocketClient.OnDeconnexionEventHandler value2 = (ElgSocketClient.OnDeconnexionEventHandler)Delegate.Remove(onDeconnexionEventHandler2, value);
					onDeconnexionEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnDeconnexionEventHandler>(ref this.onDeconnexionEventHandler_0, value2, onDeconnexionEventHandler2);
				}
				while (onDeconnexionEventHandler != onDeconnexionEventHandler2);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600007B RID: 123 RVA: 0x00006A68 File Offset: 0x00004C68
		// (remove) Token: 0x0600007C RID: 124 RVA: 0x00006AA0 File Offset: 0x00004CA0
		public event ElgSocketClient.OnEnvoieEventHandler OnEnvoie
		{
			[CompilerGenerated]
			add
			{
				ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler = this.onEnvoieEventHandler_0;
				ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler2;
				do
				{
					onEnvoieEventHandler2 = onEnvoieEventHandler;
					ElgSocketClient.OnEnvoieEventHandler value2 = (ElgSocketClient.OnEnvoieEventHandler)Delegate.Combine(onEnvoieEventHandler2, value);
					onEnvoieEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnEnvoieEventHandler>(ref this.onEnvoieEventHandler_0, value2, onEnvoieEventHandler2);
				}
				while (onEnvoieEventHandler != onEnvoieEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler = this.onEnvoieEventHandler_0;
				ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler2;
				do
				{
					onEnvoieEventHandler2 = onEnvoieEventHandler;
					ElgSocketClient.OnEnvoieEventHandler value2 = (ElgSocketClient.OnEnvoieEventHandler)Delegate.Remove(onEnvoieEventHandler2, value);
					onEnvoieEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnEnvoieEventHandler>(ref this.onEnvoieEventHandler_0, value2, onEnvoieEventHandler2);
				}
				while (onEnvoieEventHandler != onEnvoieEventHandler2);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600007D RID: 125 RVA: 0x00006AD8 File Offset: 0x00004CD8
		// (remove) Token: 0x0600007E RID: 126 RVA: 0x00006B10 File Offset: 0x00004D10
		public event ElgSocketClient.OnErreurEventHandler OnErreur
		{
			[CompilerGenerated]
			add
			{
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler2;
				do
				{
					onErreurEventHandler2 = onErreurEventHandler;
					ElgSocketClient.OnErreurEventHandler value2 = (ElgSocketClient.OnErreurEventHandler)Delegate.Combine(onErreurEventHandler2, value);
					onErreurEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnErreurEventHandler>(ref this.onErreurEventHandler_0, value2, onErreurEventHandler2);
				}
				while (onErreurEventHandler != onErreurEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler2;
				do
				{
					onErreurEventHandler2 = onErreurEventHandler;
					ElgSocketClient.OnErreurEventHandler value2 = (ElgSocketClient.OnErreurEventHandler)Delegate.Remove(onErreurEventHandler2, value);
					onErreurEventHandler = Interlocked.CompareExchange<ElgSocketClient.OnErreurEventHandler>(ref this.onErreurEventHandler_0, value2, onErreurEventHandler2);
				}
				while (onErreurEventHandler != onErreurEventHandler2);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00006B48 File Offset: 0x00004D48
		public int pingAverage
		{
			get
			{
				int result;
				if (this._lastPings.Count > 0)
				{
					result = checked((int)Math.Round((double)this._lastPings.Sum() / (double)this._lastPings.Count));
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00006B8C File Offset: 0x00004D8C
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000028DF File Offset: 0x00000ADF
		public string Hote
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00006BA4 File Offset: 0x00004DA4
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000028E8 File Offset: 0x00000AE8
		public int Port
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		/// <summary>
		/// Accesseur à la socket d'ecoute
		/// </summary>
		/// <value>Socket d'ecoute</value>    
		/// <remarks>Cette socket ne devrait normalement jamais être utilisé en dehors de la classe</remarks>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00006BBC File Offset: 0x00004DBC
		public ProxySocket LaSocket
		{
			get
			{
				return this.proxySocket_0;
			}
		}

		/// <summary>
		/// Connecté ou pas ?
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000028F1 File Offset: 0x00000AF1
		public bool Connecter
		{
			get
			{
				return this.proxySocket_0.Connected;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006BD4 File Offset: 0x00004DD4
		public void Envoyer(Message m)
		{
			string text = m.data + "\n\0";
			try
			{
				if (this.proxySocket_0.Connected)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					this.proxySocket_0.Send(bytes, 0, bytes.Length, SocketFlags.None);
					ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler = this.onEnvoieEventHandler_0;
					if (onEnvoieEventHandler != null)
					{
						onEnvoieEventHandler(this, new ElgSocketEventArgs(text, this.proxySocket_0));
					}
				}
				if (m.waitData)
				{
					this.bool_0 = true;
					this.dateTime_0 = DateTime.Now;
				}
			}
			catch (Exception ex)
			{
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
				if (onErreurEventHandler != null)
				{
					onErreurEventHandler(this, new ElgSocketEventArgs(ex.Message));
				}
			}
		}

		/// <summary>
		/// Se connecte / Se deconnecte
		/// </summary>
		/// <param name="Active">Active ou desactive la socket</param>
		/// <remarks>METHODE A REVOIR</remarks>
		// Token: 0x06000087 RID: 135 RVA: 0x00006C94 File Offset: 0x00004E94
		public void Connexion(bool Active)
		{
			if (Active)
			{
				this.LaSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(this.string_0), this.int_0), new AsyncCallback(this.method_0), this.proxySocket_0);
			}
			else
			{
				try
				{
					this._lastPings = new List<int>();
					this.proxySocket_0.Shutdown(SocketShutdown.Both);
					this.LaSocket.Close();
					ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler = this.onDeconnexionEventHandler_0;
					if (onDeconnexionEventHandler != null)
					{
						onDeconnexionEventHandler(this, new ElgSocketEventArgs("Deconnexion", this.LaSocket));
					}
				}
				catch (Exception ex)
				{
					ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler2 = this.onDeconnexionEventHandler_0;
					if (onDeconnexionEventHandler2 != null)
					{
						onDeconnexionEventHandler2(this, new ElgSocketEventArgs("Deconnexion", this.LaSocket));
					}
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006D60 File Offset: 0x00004F60
		private void method_0(IAsyncResult iasyncResult_0)
		{
			if (this.proxySocket_0.Connected)
			{
				try
				{
					if (this.proxySocket_0.ProxyType == ProxyTypes.None)
					{
						((Socket)iasyncResult_0.AsyncState).EndConnect(iasyncResult_0);
					}
					else
					{
						this.LaSocket.EndConnect(iasyncResult_0);
					}
					this.LaSocket.BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.method_2), this.LaSocket);
					return;
				}
				catch (Exception ex)
				{
					ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
					if (onErreurEventHandler != null)
					{
						onErreurEventHandler(this, new ElgSocketEventArgs("Erreur de connexion au serveur"));
					}
					return;
				}
			}
			ElgSocketClient.OnErreurEventHandler onErreurEventHandler2 = this.onErreurEventHandler_0;
			if (onErreurEventHandler2 != null)
			{
				onErreurEventHandler2(this, new ElgSocketEventArgs("Erreur de connexion au serveur"));
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006E30 File Offset: 0x00005030
		private void method_1(IAsyncResult iasyncResult_0)
		{
			try
			{
				ProxySocket proxySocket = (ProxySocket)((Socket)iasyncResult_0.AsyncState);
				proxySocket.EndDisconnect(iasyncResult_0);
				this.LaSocket.Close();
				this.proxySocket_0 = null;
				ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler = this.onDeconnexionEventHandler_0;
				if (onDeconnexionEventHandler != null)
				{
					onDeconnexionEventHandler(this, new ElgSocketEventArgs("Deconnexion", proxySocket));
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006EA4 File Offset: 0x000050A4
		private void method_2(IAsyncResult iasyncResult_0)
		{
			checked
			{
				try
				{
					ProxySocket proxySocket = (ProxySocket)iasyncResult_0.AsyncState;
					if (this.bool_0)
					{
						double totalMilliseconds = (DateTime.Now - this.dateTime_0).TotalMilliseconds;
						this.bool_0 = false;
						this._lastPings.Add((int)Math.Round(totalMilliseconds));
					}
					int num;
					try
					{
						num = proxySocket.EndReceive(iasyncResult_0);
					}
					catch (Exception ex)
					{
						num = -1;
						return;
					}
					if (num > 0)
					{
						int num2 = num - 1;
						int i;
						for (i = 0; i <= num2; i++)
						{
							if (this.byte_0[i] == 0)
							{
								Perso comtpesByIndex = Declarations.getComtpesByIndex(this.int_1);
								this.string_1 = Conversions.ToString(Fonctions.unprepareData(comtpesByIndex.keyProtocol, this.string_1));
								comtpesByIndex.lastRecepetion = new KeyValuePair<string, DateTime>(this.string_1, DateTime.Now);
								if (this.string_1.Length > 0)
								{
									ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler = this.onReceptionEventHandler_0;
									if (onReceptionEventHandler != null)
									{
										onReceptionEventHandler(this, new ElgSocketEventArgs(comtpesByIndex.lastRecepetion.Key, proxySocket));
									}
								}
								this.string_1 = "";
							}
							else
							{
								ref string ptr = ref this.string_1;
								this.string_1 = ptr + Conversions.ToString(Strings.Chr((int)this.byte_0[i]));
							}
						}
						this.resetBuffer(i);
						try
						{
							proxySocket.BeginReceive(this.byte_0, 0, this.byte_0.Length, SocketFlags.None, new AsyncCallback(this.method_2), proxySocket);
						}
						catch (Exception ex2)
						{
							ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
							if (onErreurEventHandler != null)
							{
								onErreurEventHandler(this, new ElgSocketEventArgs(ex2.Message));
							}
						}
					}
				}
				catch (Exception ex3)
				{
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000070B4 File Offset: 0x000052B4
		public void resetBuffer(int r)
		{
			checked
			{
				for (int i = 0; i <= r; i++)
				{
					this.byte_0[i] = 250;
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000070DC File Offset: 0x000052DC
		private void method_3(IAsyncResult iasyncResult_0)
		{
			try
			{
				ProxySocket proxySocket = (ProxySocket)((Socket)iasyncResult_0.AsyncState);
				proxySocket.EndSend(iasyncResult_0);
			}
			catch (Exception ex)
			{
				ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
				if (onErreurEventHandler != null)
				{
					onErreurEventHandler(this, new ElgSocketEventArgs(ex.Message));
				}
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007140 File Offset: 0x00005340
		public ElgSocketClient(string Hote, int Port, int index, string proxyHost = "", int proxyPort = 0, string Login = "", string Pass = "", bool isloginServer = false, bool sock5 = false)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this._lastPings = new List<int>();
			this.bool_0 = false;
			this.byte_0 = new byte[30001];
			this.string_1 = "";
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.bool_1 = false;
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			checked
			{
				lock (obj)
				{
					this.string_0 = Hote;
					this.int_0 = Port;
					this.int_1 = index;
					int num = this.byte_0.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						this.byte_0[i] = 1;
					}
					this.proxySocket_0 = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					if (Operators.CompareString(proxyHost, "", false) != 0 && proxyPort != 0)
					{
						this.proxySocket_0.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxyHost), proxyPort);
						if (sock5)
						{
							this.proxySocket_0.ProxyType = ProxyTypes.Socks5;
						}
						else
						{
							this.proxySocket_0.ProxyType = ProxyTypes.Socks4;
						}
						if (Operators.CompareString(Login, "", false) != 0 && Operators.CompareString(Pass, "", false) != 0)
						{
							this.proxySocket_0.ProxyUser = Login;
							this.proxySocket_0.ProxyPass = Pass;
						}
					}
					else
					{
						this.proxySocket_0.ProxyType = ProxyTypes.None;
					}
					try
					{
						this.proxySocket_0.BeginConnect(new IPEndPoint(IPAddress.Parse(Hote), Port), new AsyncCallback(this.method_0), this.proxySocket_0);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						ElgSocketClient.OnErreurEventHandler onErreurEventHandler = this.onErreurEventHandler_0;
						if (onErreurEventHandler != null)
						{
							onErreurEventHandler(this, new ElgSocketEventArgs(ex.Message));
						}
					}
				}
			}
		}

		/// <summary>
		/// IDisposable
		/// </summary>
		/// <param name="disposing"></param>
		/// <remarks></remarks>
		// Token: 0x0600008E RID: 142 RVA: 0x000028FE File Offset: 0x00000AFE
		protected virtual void Dispose(bool disposing)
		{
			if (this.bool_1)
			{
			}
			if (this.proxySocket_0.Connected)
			{
				this.proxySocket_0.Shutdown(SocketShutdown.Both);
			}
			this.proxySocket_0.Close();
			this.bool_1 = true;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002936 File Offset: 0x00000B36
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000036 RID: 54
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ElgSocketClient.OnReceptionEventHandler onReceptionEventHandler_0;

		// Token: 0x04000037 RID: 55
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ElgSocketClient.OnConnexionEventHandler onConnexionEventHandler_0;

		// Token: 0x04000038 RID: 56
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ElgSocketClient.OnDeconnexionEventHandler onDeconnexionEventHandler_0;

		// Token: 0x04000039 RID: 57
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ElgSocketClient.OnEnvoieEventHandler onEnvoieEventHandler_0;

		// Token: 0x0400003A RID: 58
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private ElgSocketClient.OnErreurEventHandler onErreurEventHandler_0;

		// Token: 0x0400003B RID: 59
		public List<int> _lastPings;

		// Token: 0x0400003C RID: 60
		private bool bool_0;

		// Token: 0x0400003D RID: 61
		private DateTime dateTime_0;

		// Token: 0x0400003E RID: 62
		private ProxySocket proxySocket_0;

		// Token: 0x0400003F RID: 63
		private byte[] byte_0;

		// Token: 0x04000040 RID: 64
		private string string_0;

		// Token: 0x04000041 RID: 65
		private int int_0;

		// Token: 0x04000042 RID: 66
		private int int_1;

		// Token: 0x04000043 RID: 67
		private string string_1;

		// Token: 0x04000044 RID: 68
		private object object_0;

		// Token: 0x04000045 RID: 69
		private bool bool_1;

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x06000093 RID: 147
		public delegate void ElgSocketDelegate(object sender, ElgSocketEventArgs e);

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x06000097 RID: 151
		public delegate void OnReceptionEventHandler(object sender, ElgSocketEventArgs e);

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x0600009B RID: 155
		public delegate void OnConnexionEventHandler(object sender, ElgSocketEventArgs e);

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x0600009F RID: 159
		public delegate void OnDeconnexionEventHandler(object sender, ElgSocketEventArgs e);

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x060000A3 RID: 163
		public delegate void OnEnvoieEventHandler(object sender, ElgSocketEventArgs e);

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x060000A7 RID: 167
		public delegate void OnErreurEventHandler(object sender, ElgSocketEventArgs e);
	}
}
