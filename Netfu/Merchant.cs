using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000C7 RID: 199
	public class Merchant : Actors
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x0000449A File Offset: 0x0000269A
		public Merchant(string[] playerData)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Cell = Conversions.ToInteger(playerData[0]);
			this.dir = Conversions.ToInteger(playerData[1]);
			this.Id = Conversions.ToInteger(playerData[3]);
			this.nom = playerData[4];
		}

		// Token: 0x04000471 RID: 1137
		public string nom;

		// Token: 0x04000472 RID: 1138
		public string guild;

		// Token: 0x04000473 RID: 1139
		public int dir;

		// Token: 0x04000474 RID: 1140
		public byte classe;
	}
}
