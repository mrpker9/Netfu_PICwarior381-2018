using System;

namespace WindowsApplication2
{
	// Token: 0x020000A6 RID: 166
	public class ActionTurnIA
	{
		// Token: 0x0600037A RID: 890 RVA: 0x00002744 File Offset: 0x00000944
		public ActionTurnIA()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0001BC2C File Offset: 0x00019E2C
		public ActionTurnIA copy()
		{
			return new ActionTurnIA
			{
				Spell = this.Spell,
				targetCellID = this.targetCellID,
				cellTOGo = this.cellTOGo
			};
		}

		// Token: 0x040003F6 RID: 1014
		public SpellLevelDescription Spell;

		// Token: 0x040003F7 RID: 1015
		public int targetCellID;

		// Token: 0x040003F8 RID: 1016
		public Cell cellTOGo;
	}
}
