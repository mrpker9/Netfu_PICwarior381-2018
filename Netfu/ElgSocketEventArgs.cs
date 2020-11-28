using System;
using Org.Mentalis.Network.ProxySocket;

namespace WindowsApplication2
{
	/// <summary>
	/// Classe de gestion des evenements
	/// </summary>
	/// <auteur>LEVEUGLE Damien [Elguevel]</auteur>
	/// <remarks></remarks>
	// Token: 0x02000012 RID: 18
	public class ElgSocketEventArgs : EventArgs
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000068E8 File Offset: 0x00004AE8
		public string Message
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00006900 File Offset: 0x00004B00
		public ProxySocket LaSocket
		{
			get
			{
				return this.proxySocket_0;
			}
		}

		/// <summary>
		/// Constructeur par defaut
		/// </summary>
		/// <param name="Message">Message transmis</param>
		/// <param name="LaSocket">Socket cliente</param>
		/// <remarks></remarks>
		// Token: 0x06000072 RID: 114 RVA: 0x0000289B File Offset: 0x00000A9B
		public ElgSocketEventArgs(string Message, ProxySocket LaSocket)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.MessageEnd = true;
			this.string_0 = Message;
			this.proxySocket_0 = LaSocket;
		}

		/// <summary>
		/// Constructeur surchargé
		/// </summary>
		/// <param name="LaSocket">Socket cliente</param>
		/// <remarks>Fait appel au constructeur <c>Sub New(ByVal Message As String, ByVal LaSocket As Socket)</c></remarks>
		// Token: 0x06000073 RID: 115 RVA: 0x000028BD File Offset: 0x00000ABD
		public ElgSocketEventArgs(ProxySocket LaSocket)
		{
			Class15.XRATSHnz66atd();
			this..ctor("", LaSocket);
		}

		/// <summary>
		/// Constructeur surchargé
		/// </summary>
		/// <param name="Message">Message transmis</param>
		/// <remarks>Fait appel au constructeur <c>Sub New(ByVal Message As String, ByVal LaSocket As Socket)</c></remarks>
		// Token: 0x06000074 RID: 116 RVA: 0x000028D0 File Offset: 0x00000AD0
		public ElgSocketEventArgs(string Message)
		{
			Class15.XRATSHnz66atd();
			this..ctor(Message, null);
		}

		// Token: 0x04000033 RID: 51
		private string string_0;

		// Token: 0x04000034 RID: 52
		private ProxySocket proxySocket_0;

		// Token: 0x04000035 RID: 53
		public bool MessageEnd;
	}
}
