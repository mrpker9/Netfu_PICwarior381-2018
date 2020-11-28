using System;

namespace WindowsApplication2
{
	// Token: 0x0200002C RID: 44
	public class Message
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00002CBE File Offset: 0x00000EBE
		public Message(string data, int time, bool waitData = true, bool allowMitm = true, bool speedGlobal = true)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.allowMitm = true;
			this.speedGlobal = true;
			this.data = data;
			this.time = time;
			this.waitData = waitData;
			this.allowMitm = allowMitm;
			this.speedGlobal = speedGlobal;
		}

		// Token: 0x0400009F RID: 159
		public string data;

		// Token: 0x040000A0 RID: 160
		public int time;

		// Token: 0x040000A1 RID: 161
		public bool waitData;

		// Token: 0x040000A2 RID: 162
		public bool allowMitm;

		// Token: 0x040000A3 RID: 163
		public bool speedGlobal;
	}
}
