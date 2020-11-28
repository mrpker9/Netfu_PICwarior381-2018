using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000052 RID: 82
	public class SpellDescription
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000EA64 File Offset: 0x0000CC64
		public SpellDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Levels = new SpellLevelDescription[6];
			this.id = Conversions.ToInteger(v.Substring(0, v.IndexOf("=")));
			checked
			{
				v = v.Substring(v.IndexOf("{") + 1);
				v = v.Substring(0, v.IndexOf("}"));
				string[] array = v.Split(new char[]
				{
					','
				});
				int num = array.Count<string>() - 1;
				int i = 0;
				while (i <= num)
				{
					string text = array[i].Substring(0, array[i].IndexOf(":"));
					string otherdate = array[i].Replace(text + ":", "").Replace("\"", "");
					uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text);
					if (num2 <= 405896782U)
					{
						if (num2 != 372341544U)
						{
							if (num2 != 389119163U)
							{
								if (num2 == 405896782U)
								{
									if (Operators.CompareString(text, "l1", false) == 0)
									{
										goto IL_1A9;
									}
								}
							}
							else if (Operators.CompareString(text, "l2", false) == 0)
							{
								goto IL_1A9;
							}
						}
						else if (Operators.CompareString(text, "l3", false) == 0)
						{
							goto IL_1A9;
						}
					}
					else if (num2 <= 473007258U)
					{
						if (num2 != 456229639U)
						{
							if (num2 == 473007258U)
							{
								if (Operators.CompareString(text, "l5", false) == 0)
								{
									goto IL_1A9;
								}
							}
						}
						else if (Operators.CompareString(text, "l6", false) == 0)
						{
							goto IL_1A9;
						}
					}
					else if (num2 != 489784877U)
					{
						if (num2 == 3943445553U)
						{
							if (Operators.CompareString(text, "n", false) == 0)
							{
								this.nom = otherdate;
							}
						}
					}
					else if (Operators.CompareString(text, "l4", false) == 0)
					{
						goto IL_1A9;
					}
					IL_1D6:
					i++;
					continue;
					IL_1A9:
					SpellLevelDescription spellLevelDescription = new SpellLevelDescription(otherdate);
					spellLevelDescription.id = this.id;
					this.Levels[Conversion.Val(text[1]) - 1] = spellLevelDescription;
					goto IL_1D6;
				}
			}
		}

		// Token: 0x0400015D RID: 349
		public int id;

		// Token: 0x0400015E RID: 350
		public string nom;

		// Token: 0x0400015F RID: 351
		public SpellLevelDescription[] Levels;
	}
}
