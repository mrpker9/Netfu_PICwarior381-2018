using System;

namespace WindowsApplication2
{
	// Token: 0x020000CC RID: 204
	public class AutoLaunch
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x00004535 File Offset: 0x00002735
		public AutoLaunch(int monId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.waitAction = -1;
			this.int_0 = monId;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00020268 File Offset: 0x0001E468
		private Perso method_0()
		{
			return Declarations.getComtpesByIndex(this.int_0);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00020284 File Offset: 0x0001E484
		public void UpdateLaunch()
		{
			if (this.method_0().mode != 0)
			{
				if ((DateTime.Now - this.method_0().lastRecepetionFight).TotalMinutes > 2.0)
				{
					this.method_0().Fight = null;
					this.method_0().lastRecepetionFight = DateTime.Now;
				}
				if (this.method_0().config.randomSpeedTrajet)
				{
					this.method_0().config.globalSpeed = Fonctions.rand.Next(0, 6000);
				}
			}
			switch (this.method_0().mode)
			{
			case 0:
				this.waitAction = -1;
				break;
			case 1:
				this.method_0().movementRandom.Update();
				break;
			case 2:
				this.method_0().MovementTrajet.Update();
				break;
			case 3:
				this.method_0().DCTrajet.Update();
				break;
			case 4:
				this.method_0().LuaTrajet.Update();
				break;
			}
		}

		// Token: 0x04000484 RID: 1156
		private int int_0;

		// Token: 0x04000485 RID: 1157
		public int waitAction;

		// Token: 0x020000CD RID: 205
		// (Invoke) Token: 0x06000441 RID: 1089
		private delegate void Delegate0();

		// Token: 0x020000CE RID: 206
		// (Invoke) Token: 0x06000445 RID: 1093
		private delegate void Delegate1(int index, bool Fight, bool map, bool zone);
	}
}
