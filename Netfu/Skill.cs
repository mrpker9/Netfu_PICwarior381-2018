using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200002B RID: 43
	public class Skill
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x0000A100 File Offset: 0x00008300
		public Skill(int nID, string nParam1, string nParam2, string nParam3, string nParam4)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this._nID = nID;
			if (Conversions.ToDouble(nParam1) != 0.0)
			{
				this.min = Conversions.ToInteger(nParam1);
			}
			if (Conversions.ToDouble(nParam2) != 0.0)
			{
				this.max = Conversions.ToInteger(nParam2);
			}
			if (Conversions.ToDouble(nParam3) != 0.0)
			{
				this._nParam3 = nParam3;
			}
			if (Conversions.ToDouble(nParam4) != 0.0)
			{
				this.Temps = Conversions.ToInteger(nParam4);
			}
		}

		// Token: 0x0400009A RID: 154
		public int _nID;

		// Token: 0x0400009B RID: 155
		public int min;

		// Token: 0x0400009C RID: 156
		public int max;

		// Token: 0x0400009D RID: 157
		public string _nParam3;

		// Token: 0x0400009E RID: 158
		public int Temps;
	}
}
