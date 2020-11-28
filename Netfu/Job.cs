using System;
using System.Collections.Generic;

namespace WindowsApplication2
{
	// Token: 0x02000027 RID: 39
	public class Job
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00002C0F File Offset: 0x00000E0F
		public Job(int id, List<Skill> Skills)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Skills = new List<Skill>();
			this.recolteds = new Dictionary<string, int>();
			this.id = id;
			this.Skills = Skills;
		}

		// Token: 0x0400008E RID: 142
		public int id;

		// Token: 0x0400008F RID: 143
		public int level;

		// Token: 0x04000090 RID: 144
		public int Exp;

		// Token: 0x04000091 RID: 145
		public List<Skill> Skills;

		// Token: 0x04000092 RID: 146
		public object expInf;

		// Token: 0x04000093 RID: 147
		public object expCurrent;

		// Token: 0x04000094 RID: 148
		public object expSup;

		// Token: 0x04000095 RID: 149
		public Dictionary<string, int> recolteds;
	}
}
