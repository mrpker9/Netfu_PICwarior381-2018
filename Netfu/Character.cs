using System;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000C8 RID: 200
	public class Character : Actors
	{
		// Token: 0x0600042F RID: 1071 RVA: 0x0001FF40 File Offset: 0x0001E140
		public Character(string[] playerData)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Cell = Conversions.ToInteger(playerData[0]);
			this.dir = Conversions.ToInteger(playerData[1]);
			this.Id = Conversions.ToInteger(playerData[3]);
			this.nom = playerData[4];
			this.guild = playerData[16];
			this.dead = (Operators.CompareString(playerData[18], "3j", false) == 0);
			this.classe = Conversions.ToByte(playerData[5]);
			this.sex = Conversions.ToByte(playerData[7]);
			if (Operators.CompareString(this.guild, "", false) == 0)
			{
				this.guild = "Aucune";
			}
			string[] array = playerData[8].Split(new char[]
			{
				','
			});
			int num = Conversions.ToInteger(array[0]);
			string text = "";
			if (array.Length > 1)
			{
				text = array[1];
			}
			switch (num)
			{
			case 0:
				this.Alignement = "Neutre";
				break;
			case 1:
				this.Alignement = "Bontarien";
				break;
			case 2:
				this.Alignement = "Brakmarien";
				break;
			}
			if (Operators.CompareString(this.Alignement, "", false) == 0)
			{
				string left = text;
				if (Operators.CompareString(left, Conversions.ToString(0), false) == 0)
				{
					this.Alignement = "Neutre";
				}
				else if (Operators.CompareString(left, Conversions.ToString(1), false) == 0)
				{
					this.Alignement = "Bontarien";
				}
				else if (Operators.CompareString(left, Conversions.ToString(2), false) == 0)
				{
					this.Alignement = "Brakmarien";
				}
			}
			int num2 = Conversions.ToInteger(array[3]);
			this.level = Conversions.ToInteger((checked(num2 - this.Id)).ToString());
		}

		// Token: 0x04000475 RID: 1141
		public string nom;

		// Token: 0x04000476 RID: 1142
		public string guild;

		// Token: 0x04000477 RID: 1143
		public string Alignement;

		// Token: 0x04000478 RID: 1144
		public int level;

		// Token: 0x04000479 RID: 1145
		public int dir;

		// Token: 0x0400047A RID: 1146
		public byte classe;

		// Token: 0x0400047B RID: 1147
		public bool dead;

		// Token: 0x0400047C RID: 1148
		public byte sex;
	}
}
