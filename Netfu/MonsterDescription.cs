using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200004E RID: 78
	public class MonsterDescription
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000E050 File Offset: 0x0000C250
		public MonsterDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.grades = new GradeMonster[5];
			this.id = Conversions.ToInteger(v.Substring(0, v.IndexOf("=")));
			checked
			{
				v = v.Substring(v.IndexOf("=") + 1);
				string[] array = v.Split(new char[]
				{
					','
				});
				int num = array.Count<string>() - 1;
				int i = 0;
				while (i <= num)
				{
					string text = array[i].Substring(0, array[i].IndexOf(":"));
					string text2 = array[i].Replace(text + ":", "").Replace("\"", "");
					uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text);
					if (num2 <= 236987759U)
					{
						if (num2 <= 203432521U)
						{
							if (num2 != 186654902U)
							{
								if (num2 == 203432521U)
								{
									if (Operators.CompareString(text, "g5", false) == 0)
									{
										goto IL_196;
									}
								}
							}
							else if (Operators.CompareString(text, "g4", false) == 0)
							{
								goto IL_196;
							}
						}
						else if (num2 != 220210140U)
						{
							if (num2 == 236987759U)
							{
								if (Operators.CompareString(text, "g3", false) == 0)
								{
									goto IL_196;
								}
							}
						}
						else if (Operators.CompareString(text, "g2", false) == 0)
						{
							goto IL_196;
						}
					}
					else if (num2 <= 3792446982U)
					{
						if (num2 != 270542997U)
						{
							if (num2 == 3792446982U)
							{
								if (Operators.CompareString(text, "g", false) == 0)
								{
									this.GfxID = Conversions.ToInteger(text2);
								}
							}
						}
						else if (Operators.CompareString(text, "g1", false) == 0)
						{
							goto IL_196;
						}
					}
					else if (num2 != 3876335077U)
					{
						if (num2 == 3943445553U)
						{
							if (Operators.CompareString(text, "n", false) == 0)
							{
								this.nom = text2;
							}
						}
					}
					else if (Operators.CompareString(text, "b", false) == 0)
					{
						this.type = Conversions.ToInteger(text2);
					}
					IL_1FB:
					i++;
					continue;
					IL_196:
					this.grades[Conversion.Val(text[1]) - 1] = new GradeMonster(text2);
					goto IL_1FB;
				}
			}
		}

		// Token: 0x04000143 RID: 323
		public int id;

		// Token: 0x04000144 RID: 324
		public string nom;

		// Token: 0x04000145 RID: 325
		public GradeMonster[] grades;

		// Token: 0x04000146 RID: 326
		public int type;

		// Token: 0x04000147 RID: 327
		public int GfxID;
	}
}
