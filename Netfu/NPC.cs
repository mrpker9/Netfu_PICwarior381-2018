using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000C9 RID: 201
	public class NPC : Actors
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x000044DA File Offset: 0x000026DA
		public NPC(string[] datas)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Id = Conversions.ToInteger(datas[3]);
			this.Cell = Conversions.ToInteger(datas[0]);
		}
	}
}
