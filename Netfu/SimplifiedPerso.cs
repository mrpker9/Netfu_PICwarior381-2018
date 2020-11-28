using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000035 RID: 53
	public class SimplifiedPerso
	{
		// Token: 0x06000147 RID: 327 RVA: 0x0000CD68 File Offset: 0x0000AF68
		public SimplifiedPerso(Perso p)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.monNom = p.monNom;
			this.monId = p.monId;
			this.monIdDofus = Conversions.ToInteger(p.monIdDofus);
			this.config = p.config;
			this.Etat = p.Etat;
			this.status = p.status;
			this.nomChef = p.nomChef;
		}

		// Token: 0x040000FC RID: 252
		public string monNom;

		// Token: 0x040000FD RID: 253
		public string nomChef;

		// Token: 0x040000FE RID: 254
		public int monId;

		// Token: 0x040000FF RID: 255
		public int monIdDofus;

		// Token: 0x04000100 RID: 256
		public Config config;

		// Token: 0x04000101 RID: 257
		public string Etat;

		// Token: 0x04000102 RID: 258
		public status status;
	}
}
