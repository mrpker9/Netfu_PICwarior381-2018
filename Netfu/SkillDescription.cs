using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000051 RID: 81
	public class SkillDescription
	{
		// Token: 0x060001B4 RID: 436 RVA: 0x0000E850 File Offset: 0x0000CA50
		public SkillDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
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
				for (int i = 0; i <= num; i++)
				{
					string text = array[i].Substring(0, array[i].IndexOf(":"));
					string text2 = array[i].Replace(text + ":", "").Replace("\"", "");
					if (Operators.CompareString(text, "io", false) != 0)
					{
						if (Operators.CompareString(text, "i", false) != 0)
						{
							if (Operators.CompareString(text, "j", false) != 0)
							{
								if (Operators.CompareString(text, "cl", false) != 0)
								{
									if (Operators.CompareString(text, "d", false) == 0)
									{
										this.nom = text2;
									}
								}
								else
								{
									this.craftsList = new List<ObjetDescription>();
									this.craftsList.Add(Loader.getItemById(Conversions.ToInteger(text2.Replace("[", "").Replace("]", ""))));
									if (!text2.Contains("]"))
									{
										i++;
										while (!array[i].Contains("]"))
										{
											this.craftsList.Add(Loader.getItemById(Conversions.ToInteger(array[i])));
											i++;
										}
										this.craftsList.Add(Loader.getItemById(Conversions.ToInteger(array[i].Substring(0, array[i].Length - 1))));
									}
								}
							}
							else
							{
								this.job = Loader.getJobById(Conversions.ToInteger(text2));
							}
						}
						else
						{
							this.item = Loader.getItemById(Conversions.ToInteger(text2));
						}
					}
					else
					{
						this.io = Conversions.ToInteger(text2);
					}
				}
			}
		}

		// Token: 0x04000157 RID: 343
		public int id;

		// Token: 0x04000158 RID: 344
		public JobsDescription job;

		// Token: 0x04000159 RID: 345
		public string nom;

		// Token: 0x0400015A RID: 346
		public int io;

		// Token: 0x0400015B RID: 347
		public ObjetDescription item;

		// Token: 0x0400015C RID: 348
		public List<ObjetDescription> craftsList;
	}
}
