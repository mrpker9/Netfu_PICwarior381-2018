using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200003C RID: 60
	public class IODescription
	{
		// Token: 0x06000168 RID: 360 RVA: 0x0000D444 File Offset: 0x0000B644
		public IODescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.LayersId = new List<int>();
			checked
			{
				try
				{
					if (v.Contains("{"))
					{
						this.Id = Conversions.ToInteger(v.Substring(0, v.IndexOf("=")));
						v = v.Substring(v.IndexOf("{") + 1);
						v = v.Substring(0, v.IndexOf("}"));
						string[] array = v.Split(new char[]
						{
							','
						});
						int num = array.Count<string>() - 1;
						for (int i = 0; i <= num; i++)
						{
							string text = array[i].Substring(0, array[i].IndexOf(":"));
							string text2 = array[i].Replace(text + ":", "").Replace("\"", "");
							if (Operators.CompareString(text, "t", false) != 0)
							{
								if (Operators.CompareString(text, "sk", false) != 0)
								{
									if (Operators.CompareString(text, "n", false) == 0)
									{
										this.nom = text2;
									}
								}
								else
								{
									this.Skills = new List<SkillDescription>();
									if (Operators.CompareString(text2.Replace("[", "").Replace("]", ""), "", false) != 0)
									{
										this.Skills.Add(Loader.getSkillById(Conversions.ToInteger(text2.Replace("[", "").Replace("]", ""))));
									}
									if (!text2.Contains("]"))
									{
										i++;
										while (!array[i].Contains("]"))
										{
											this.Skills.Add(Loader.getSkillById(Conversions.ToInteger(array[i])));
											i++;
										}
										this.Skills.Add(Loader.getSkillById(Conversions.ToInteger(array[i].Substring(0, array[i].Length - 1))));
									}
								}
							}
							else
							{
								this.type = Conversions.ToInteger(text2);
							}
						}
					}
					else
					{
						string value = v.Substring(0, v.IndexOf("="));
						string text3 = v.Substring(v.IndexOf("=") + 1);
						text3 = text3.Substring(0, text3.Length - 1);
						Loader.smethod_10(Conversions.ToInteger(text3)).LayersId.Add(Conversions.ToInteger(value));
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			}
		}

		// Token: 0x04000122 RID: 290
		public List<int> LayersId;

		// Token: 0x04000123 RID: 291
		public int Id;

		// Token: 0x04000124 RID: 292
		public string nom;

		// Token: 0x04000125 RID: 293
		public List<SkillDescription> Skills;

		// Token: 0x04000126 RID: 294
		public int type;
	}
}
