using System;

namespace WindowsApplication2
{
	// Token: 0x02000096 RID: 150
	public class LaunchedSpells
	{
		// Token: 0x06000341 RID: 833 RVA: 0x00003D90 File Offset: 0x00001F90
		public LaunchedSpells(int Tour, int spellId, Fighter target = null)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Tour = Tour;
			this.spell = spellId;
			this.target = target;
		}

		// Token: 0x040003C7 RID: 967
		public int Tour;

		// Token: 0x040003C8 RID: 968
		public int spell;

		// Token: 0x040003C9 RID: 969
		public Fighter target;
	}
}
