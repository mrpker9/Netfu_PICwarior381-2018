using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200003D RID: 61
	public class JobsDescription
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000D6E4 File Offset: 0x0000B8E4
		public JobsDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.id = Conversions.ToInteger(v.Substring(0, v.IndexOf("=")));
			v = v.Substring(v.IndexOf("{"));
			v = v.Substring(0, v.IndexOf("}"));
			this.nom = v.Split(new char[]
			{
				','
			})[0].Substring(3).Replace("\"", "");
		}

		// Token: 0x04000127 RID: 295
		public int id;

		// Token: 0x04000128 RID: 296
		public string nom;
	}
}
