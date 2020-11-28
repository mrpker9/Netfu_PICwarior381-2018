using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000050 RID: 80
	public class ObjetDescription
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x0000E378 File Offset: 0x0000C578
		public ObjetDescription(string v)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.usable = false;
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
					uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text);
					if (num2 <= 3909890315U)
					{
						if (num2 <= 1612899612U)
						{
							if (num2 != 1092940518U)
							{
								if (num2 == 1612899612U)
								{
									if (Operators.CompareString(text, "fm", false) == 0)
									{
										this.fm = Conversions.ToBoolean(text2);
									}
								}
							}
							else if (Operators.CompareString(text, "an", false) == 0)
							{
								this.an = Conversions.ToByte(text2);
							}
						}
						else if (num2 != 3758891744U)
						{
							if (num2 != 3775669363U)
							{
								if (num2 == 3909890315U)
								{
									if (Operators.CompareString(text, "l", false) == 0)
									{
										this.level = Conversions.ToInteger(text2);
									}
								}
							}
							else if (Operators.CompareString(text, "d", false) == 0)
							{
								this.description = text2;
							}
						}
						else if (Operators.CompareString(text, "e", false) == 0 && !text2.Contains("]"))
						{
							i++;
							string[] array2 = text2.Substring(1).Split(new char[]
							{
								';'
							});
							if (array2.Length > 3)
							{
								this.pa = Conversions.ToByte(array2[1]);
								this.porteMin = Conversions.ToByte(array2[2]);
								this.porteMax = Conversions.ToByte(array2[3]);
							}
							while (!array[i].Contains("]"))
							{
								i++;
							}
						}
					}
					else if (num2 <= 4027333648U)
					{
						if (num2 != 3943445553U)
						{
							if (num2 == 4027333648U)
							{
								if (Operators.CompareString(text, "u", false) == 0)
								{
									this.usable = Conversions.ToBoolean(text2);
								}
							}
						}
						else if (Operators.CompareString(text, "n", false) == 0)
						{
							this.nom = text2;
						}
					}
					else if (num2 != 4044111267U)
					{
						if (num2 != 4060888886U)
						{
							if (num2 == 4111221743U)
							{
								if (Operators.CompareString(text, "p", false) == 0)
								{
									this.prix = Conversions.ToInteger(text2);
								}
							}
						}
						else if (Operators.CompareString(text, "w", false) == 0)
						{
							this.poids = Conversions.ToShort(text2);
						}
					}
					else if (Operators.CompareString(text, "t", false) == 0)
					{
						this.type = Conversions.ToByte(text2);
					}
				}
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00003159 File Offset: 0x00001359
		public bool isPaysanItem()
		{
			return this.type == 22;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00003165 File Offset: 0x00001365
		public bool isBucheronItem()
		{
			return this.an == 17 && this.id != 577 && this.id != 8127 && this.id != 497;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000319E File Offset: 0x0000139E
		public bool isPecheurItem()
		{
			return this.an == 18;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000031AA File Offset: 0x000013AA
		public bool isAlchimisteItem()
		{
			return this.id == 8542 || this.id == 1473;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000031C9 File Offset: 0x000013C9
		public bool isMineurItem()
		{
			return this.type == 21;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000E688 File Offset: 0x0000C888
		public object isJobItem()
		{
			return this.isMineurItem() | this.isAlchimisteItem() | this.isPecheurItem() | this.isPecheurItem();
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000E6B8 File Offset: 0x0000C8B8
		public bool isEquipement
		{
			get
			{
				int[] source = new int[]
				{
					1,
					9,
					11,
					82,
					17,
					10,
					16,
					23,
					81,
					23,
					2,
					3,
					4,
					5,
					22,
					19,
					7,
					20,
					8,
					83,
					21,
					6,
					8,
					18
				};
				return source.Contains((int)this.type);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000E6E4 File Offset: 0x0000C8E4
		internal bool method_0()
		{
			int[] source = new int[]
			{
				17,
				81
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000E710 File Offset: 0x0000C910
		internal bool BylGuuBmZi()
		{
			int[] source = new int[]
			{
				9
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000E738 File Offset: 0x0000C938
		internal bool method_1()
		{
			int[] source = new int[]
			{
				16
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000E760 File Offset: 0x0000C960
		internal bool method_2()
		{
			int[] source = new int[]
			{
				11
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000E788 File Offset: 0x0000C988
		internal bool method_3()
		{
			int[] source = new int[]
			{
				10
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		internal bool method_4()
		{
			int[] source = new int[]
			{
				1
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000E7D4 File Offset: 0x0000C9D4
		internal bool method_5()
		{
			int[] source = new int[]
			{
				2,
				3,
				4,
				5,
				22,
				19,
				7,
				20,
				8,
				83,
				21,
				6,
				8,
				83
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000E800 File Offset: 0x0000CA00
		internal bool method_6()
		{
			int[] source = new int[]
			{
				18
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000E828 File Offset: 0x0000CA28
		internal bool method_7()
		{
			int[] source = new int[]
			{
				82
			};
			return source.Contains((int)this.type);
		}

		// Token: 0x0400014A RID: 330
		public int id;

		// Token: 0x0400014B RID: 331
		public string nom;

		// Token: 0x0400014C RID: 332
		public byte type;

		// Token: 0x0400014D RID: 333
		public int level;

		// Token: 0x0400014E RID: 334
		public string description;

		// Token: 0x0400014F RID: 335
		public short poids;

		// Token: 0x04000150 RID: 336
		public bool fm;

		// Token: 0x04000151 RID: 337
		public int prix;

		// Token: 0x04000152 RID: 338
		public bool usable;

		// Token: 0x04000153 RID: 339
		public byte an;

		// Token: 0x04000154 RID: 340
		public byte porteMin;

		// Token: 0x04000155 RID: 341
		public byte porteMax;

		// Token: 0x04000156 RID: 342
		public byte pa;
	}
}
