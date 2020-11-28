using System;
using System.Linq;

namespace WindowsApplication2
{
	// Token: 0x0200008B RID: 139
	public class Fighter
	{
		// Token: 0x06000301 RID: 769 RVA: 0x00003A03 File Offset: 0x00001C03
		public Fighter()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.invisible = false;
			this.resistance = new short[8];
			this.ownerId = int.MinValue;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00017AAC File Offset: 0x00015CAC
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00003A2E File Offset: 0x00001C2E
		public int cellId
		{
			get
			{
				return (int)this.short_0;
			}
			set
			{
				if (value > -1)
				{
					this.short_0 = checked((short)value);
				}
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00017AC4 File Offset: 0x00015CC4
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00003A3E File Offset: 0x00001C3E
		public int LP
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (this.int_0 <= 0)
				{
					this.dead = true;
					if (this.fight != null)
					{
						this.fight.removeInvocation(this.id);
					}
				}
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00017ADC File Offset: 0x00015CDC
		public MonsterDescription monster()
		{
			MonsterDescription monsterById = Loader.getMonsterById(this.gfxId);
			return (monsterById == null) ? Loader.getMonsterById(1213) : monsterById;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00003A7D File Offset: 0x00001C7D
		public bool isInvoc
		{
			get
			{
				return this.ownerId > int.MinValue;
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00017B08 File Offset: 0x00015D08
		internal Fighter method_0()
		{
			return new Fighter
			{
				AP = this.AP,
				cellId = this.cellId,
				dead = this.dead,
				gfxId = this.gfxId,
				fight = this.fight,
				id = this.id,
				invisible = this.invisible,
				LP = this.LP,
				LPmax = this.LPmax,
				MP = this.MP,
				ownerId = this.ownerId,
				PowerLevel = this.PowerLevel,
				resistance = this.resistance,
				team = this.team,
				short_0 = this.short_0,
				int_0 = this.int_0,
				resistance = this.resistance.ToArray<short>()
			};
		}

		// Token: 0x04000390 RID: 912
		public int id;

		// Token: 0x04000391 RID: 913
		public bool dead;

		// Token: 0x04000392 RID: 914
		private short short_0;

		// Token: 0x04000393 RID: 915
		public bool invisible;

		// Token: 0x04000394 RID: 916
		public byte team;

		// Token: 0x04000395 RID: 917
		private int int_0;

		// Token: 0x04000396 RID: 918
		public int LPmax;

		// Token: 0x04000397 RID: 919
		public int AP;

		// Token: 0x04000398 RID: 920
		public int MP;

		// Token: 0x04000399 RID: 921
		public Combat fight;

		// Token: 0x0400039A RID: 922
		public int PowerLevel;

		// Token: 0x0400039B RID: 923
		public short[] resistance;

		// Token: 0x0400039C RID: 924
		public int ownerId;

		// Token: 0x0400039D RID: 925
		public int gfxId;

		// Token: 0x0400039E RID: 926
		internal int int_1;
	}
}
