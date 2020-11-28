using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200004F RID: 79
	public class GradeMonster
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x0000E264 File Offset: 0x0000C464
		public GradeMonster(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.resistance = new short[8];
			try
			{
				v = v.Replace("r", "").Replace("l", "").Replace(":", "").Replace("[", "").Replace("]", "");
				string[] array = v.Split(new char[]
				{
					';'
				});
				this.level = Conversions.ToShort(array[0]);
				this.resistance = new short[]
				{
					Conversions.ToShort(array[1]),
					Conversions.ToShort(array[2]),
					Conversions.ToShort(array[3]),
					Conversions.ToShort(array[4]),
					Conversions.ToShort(array[5]),
					Conversions.ToShort(array[6]),
					Conversions.ToShort(array[7])
				};
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x04000148 RID: 328
		public short level;

		// Token: 0x04000149 RID: 329
		public short[] resistance;
	}
}
