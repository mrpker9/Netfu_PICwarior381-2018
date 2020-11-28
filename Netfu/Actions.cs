using System;
using System.Collections.Generic;

namespace WindowsApplication2
{
	// Token: 0x0200000C RID: 12
	public class Actions
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00005C58 File Offset: 0x00003E58
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.int_0);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002799 File Offset: 0x00000999
		public Actions(int targetId, string action, int actionParam__1, int priority)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.conditions = new List<Condition>();
			this.int_0 = targetId;
			this.Action = action;
			this.ActionParam = actionParam__1;
			this.priority = priority;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005C74 File Offset: 0x00003E74
		public bool conditionsOk(Fighter f = null)
		{
			try
			{
				foreach (Condition condition in this.conditions)
				{
					if (!condition.isOk(f))
					{
						return false;
					}
				}
			}
			finally
			{
				List<Condition>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return true;
		}

		// Token: 0x04000009 RID: 9
		public string Action;

		// Token: 0x0400000A RID: 10
		public int ActionParam;

		// Token: 0x0400000B RID: 11
		public List<Condition> conditions;

		// Token: 0x0400000C RID: 12
		public int priority;

		// Token: 0x0400000D RID: 13
		private int int_0;
	}
}
