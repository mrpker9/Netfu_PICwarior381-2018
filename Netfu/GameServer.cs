using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000065 RID: 101
	public class GameServer
	{
		// Token: 0x06000216 RID: 534 RVA: 0x00011F80 File Offset: 0x00010180
		public GameServer(string[] str)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.portGame = 443;
			this.idServer = Conversions.ToInteger(str[0]);
			this.name = str[1];
			this.ip = str[2];
			this.version = str[3];
			this.port = Conversions.ToInteger(str[4]);
			if (str.Length > 5)
			{
				this.portGame = Conversions.ToInteger(str[5]);
			}
		}

		// Token: 0x040002BB RID: 699
		public string ip;

		// Token: 0x040002BC RID: 700
		public string version;

		// Token: 0x040002BD RID: 701
		public int port;

		// Token: 0x040002BE RID: 702
		public string name;

		// Token: 0x040002BF RID: 703
		public int idServer;

		// Token: 0x040002C0 RID: 704
		public int portGame;
	}
}
