using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000025 RID: 37
	public class Famillier
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00002BB1 File Offset: 0x00000DB1
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00002BB9 File Offset: 0x00000DB9
		public long idInventaire { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00008908 File Offset: 0x00006B08
		public Objets Fami
		{
			get
			{
				return Declarations.getComtpesByIndex(this.int_0).Inventaire.getObjectByIdInv(this.idInventaire);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00008934 File Offset: 0x00006B34
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.int_0);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008950 File Offset: 0x00006B50
		public static object EatToAll(List<Famillier> familiers)
		{
			int num = 1;
			checked
			{
				try
				{
					foreach (Famillier famillier in familiers)
					{
						if (Conversions.ToBoolean(famillier.Eat(num)))
						{
							return true;
						}
						num++;
					}
				}
				finally
				{
					List<Famillier>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				return false;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000089BC File Offset: 0x00006BBC
		public Famillier(Objets I, Perso b)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Nourriture = new Dictionary<string, int[]>();
			this.NourritureType = new Dictionary<string, int[]>();
			this.StatsToAugmente = new List<string>();
			this.string_0 = "";
			this.int_1 = 0;
			this.int_0 = b.monId;
			if (Loader.getItemById(Conversions.ToInteger(I.idObjet)).type == 18)
			{
				string idObjet = I.idObjet;
				if (Operators.CompareString(idObjet, Conversions.ToString(6978), false) == 0)
				{
					this.intervalTime = 3;
					this.Nourriture.Add("Vitalité", new int[]
					{
						7018,
						7059,
						7262,
						7263,
						7264,
						7265,
						7266,
						7267,
						7268,
						7288,
						7287,
						7890,
						7891
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7714), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Soins", new int[]
					{
						41
					});
					this.NourritureType.Add("Dommages", new int[]
					{
						63
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(2074), false) == 0)
				{
					this.intervalTime = 11;
					this.Nourriture.Add("Intelligence", new int[]
					{
						287,
						422,
						427,
						288,
						300
					});
					this.Nourriture.Add("Vitalité", new int[]
					{
						381,
						393,
						394
					});
					this.Nourriture.Add("%Feu", new int[]
					{
						391,
						392
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7891), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Intelligence", new int[]
					{
						41
					});
					this.NourritureType.Add("Agilité", new int[]
					{
						58
					});
					this.Nourriture.Add("Chance", new int[]
					{
						60
					});
					this.Nourriture.Add("Force", new int[]
					{
						63
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7520), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("%Air", new int[]
					{
						745,
						747
					});
					this.Nourriture.Add("%Eau", new int[]
					{
						746,
						6457
					});
					this.Nourriture.Add("%Terre", new int[]
					{
						748,
						6458
					});
					this.Nourriture.Add("%Feu", new int[]
					{
						749,
						7035
					});
					this.Nourriture.Add("%Neutre", new int[]
					{
						750,
						736
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7708), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Chance", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7892), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						63
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(8561), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Puissance", new int[]
					{
						394,
						7018
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(8693), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(11783), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Sagesse", new int[]
					{
						11510
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(1748), false) == 0)
				{
					this.intervalTime = 24;
					this.Nourriture.Add("Sagesse", new int[]
					{
						361,
						1901,
						1902,
						1903,
						1905
					});
					this.Nourriture.Add("Chance", new int[]
					{
						373,
						374,
						380
					});
					this.Nourriture.Add("Intelligence", new int[]
					{
						395,
						2662
					});
					this.Nourriture.Add("Force", new int[]
					{
						398,
						501
					});
					this.Nourriture.Add("Agilité", new int[]
					{
						1772,
						1774,
						1776,
						1778
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(2075), false) == 0)
				{
					this.intervalTime = 11;
					this.Nourriture.Add("Vitalité", new int[]
					{
						381,
						393,
						394
					});
					this.Nourriture.Add("Chance", new int[]
					{
						287,
						288,
						300,
						422,
						427
					});
					this.Nourriture.Add("%Eau", new int[]
					{
						391,
						392
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7705), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						63
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7712), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Force", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(9617), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7706), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Dommages", new int[]
					{
						35
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7713), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Dommages", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(8211), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(8677), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Soins", new int[]
					{
						361
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7518), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Vitalité", new int[]
					{
						47
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7703), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Prospection", new int[]
					{
						47
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7710), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Soins", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(11771), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Soins", new int[]
					{
						11102
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7519), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Sagesse", new int[]
					{
						90
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7704), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7711), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Intelligence", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(8000), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Pods", new int[]
					{
						391,
						392,
						393,
						394
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(9623), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(11765), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Vitalité", new int[]
					{
						11109
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(12009), false) == 0)
				{
					this.intervalTime = 12;
					this.Nourriture.Add("Dommages", new int[]
					{
						993,
						994,
						995,
						996
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(2077), false) == 0)
				{
					this.intervalTime = 11;
					this.Nourriture.Add("Force", new int[]
					{
						287,
						288,
						300,
						422,
						427
					});
					this.Nourriture.Add("Vitalité", new int[]
					{
						381,
						393,
						394
					});
					this.Nourriture.Add("%Terre", new int[]
					{
						391,
						392
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7414), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Initiative", new int[]
					{
						63
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7522), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Puissance", new int[]
					{
						301,
						366,
						367,
						375,
						376
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(2076), false) == 0)
				{
					this.intervalTime = 11;
					this.Nourriture.Add("Agilité", new int[]
					{
						287,
						288,
						300,
						422,
						427
					});
					this.Nourriture.Add("Vitalité", new int[]
					{
						381,
						393,
						394
					});
					this.Nourriture.Add("%Air", new int[]
					{
						391,
						392
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7709), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Agilité", new int[]
					{
						58
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(11777), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Dommages", new int[]
					{
						11107
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(1728), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Agilité", new int[]
					{
						301,
						367,
						376
					});
					this.Nourriture.Add("Force", new int[]
					{
						360,
						419
					});
					this.Nourriture.Add("%Neutre", new int[]
					{
						368,
						369,
						757
					});
					this.Nourriture.Add("Intelligence", new int[]
					{
						414,
						415,
						416,
						198,
						1141,
						1781,
						1782,
						1783,
						598
					});
					this.Nourriture.Add("Vitalité", new int[]
					{
						477,
						752
					});
					this.Nourriture.Add("Chance", new int[]
					{
						1771,
						1844,
						1845
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(6716), false) == 0)
				{
					this.intervalTime = 24;
					this.Nourriture.Add("Prospection", new int[]
					{
						2253,
						2254,
						2602,
						2617
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(4524), false) == 0)
				{
					this.intervalTime = 5;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7911), false) == 0)
				{
					this.intervalTime = 5;
					this.Nourriture.Add("Sagesse", new int[]
					{
						8001,
						8056,
						8064,
						8075,
						8076,
						8077,
						8082
					});
				}
				else if (Operators.CompareString(idObjet, Conversions.ToString(7415), false) == 0)
				{
					this.intervalTime = 11;
					this.NourritureType.Add("Puissance", new int[]
					{
						41
					});
				}
				this.idInventaire = I.idObjetInv;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000097DC File Offset: 0x000079DC
		public EtatFamilier etat
		{
			get
			{
				EtatFamilier result;
				if (this.Fami == null)
				{
					result = EtatFamilier.obese;
				}
				else
				{
					Effect effect = this.Fami.effects.FirstOrDefault((Famillier._Closure$__.$I18-0 == null) ? (Famillier._Closure$__.$I18-0 = ((Effect e) => e.id == EffectIDEnum.EtatFami)) : Famillier._Closure$__.$I18-0);
					if (effect == null)
					{
						result = EtatFamilier.obese;
					}
					else
					{
						int num = Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.etat));
						if (num > 6)
						{
							result = EtatFamilier.maigrichon;
						}
						else if (Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.max)) > 6)
						{
							result = EtatFamilier.obese;
						}
						else
						{
							result = EtatFamilier.normal;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00009880 File Offset: 0x00007A80
		public DateTime lastEat
		{
			get
			{
				checked
				{
					DateTime dateTime;
					if (this.Fami == null)
					{
						dateTime = DateTime.Now;
					}
					else
					{
						Effect effect = this.Fami.effects.FirstOrDefault((Famillier._Closure$__.$I20-0 == null) ? (Famillier._Closure$__.$I20-0 = ((Effect e) => e.id == EffectIDEnum.LastEat)) : Famillier._Closure$__.$I20-0);
						if (effect == null)
						{
							dateTime = DateTime.Now;
						}
						else
						{
							string text = Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.etat)).ToString();
							string text2 = Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.max)).ToString();
							object value;
							object value2;
							if (text.Length > 3)
							{
								value = text.Substring(0, 2);
								value2 = text.Substring(2);
							}
							else if (text.Length > 2)
							{
								value = text.Substring(0, 1);
								value2 = text.Substring(1);
							}
							else if (text.Length == 2)
							{
								value = 0;
								value2 = dateTime;
							}
							object value3;
							object value4;
							if (text2.Length > 3)
							{
								value3 = Conversions.ToInteger(text2.Substring(0, 2)) + 1;
								value4 = text2.Substring(2);
							}
							else if (text2.Length > 2)
							{
								value3 = Conversions.ToInteger(text2.Substring(0, 1)) + 1;
								value4 = text2.Substring(1);
							}
							else
							{
								value3 = 1;
								value4 = text2;
							}
							try
							{
								DateTime dateTime2 = new DateTime(DateAndTime.Now.Year, Conversions.ToInteger(value3), Conversions.ToInteger(value4), Conversions.ToInteger(value), Conversions.ToInteger(value2), 50);
								dateTime = dateTime2;
							}
							catch (Exception e)
							{
								Exception e2;
								Fonctions.traiterErreur(e2);
								dateTime = new DateTime(1900, 6, 6);
							}
						}
					}
					return dateTime;
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00009A5C File Offset: 0x00007C5C
		public string LastAlimentation
		{
			get
			{
				string result;
				if (this.Fami == null)
				{
					result = "";
				}
				else
				{
					Effect effect = this.Fami.effects.FirstOrDefault((Famillier._Closure$__.$I22-0 == null) ? (Famillier._Closure$__.$I22-0 = ((Effect e) => e.id == (EffectIDEnum)807)) : Famillier._Closure$__.$I22-0);
					if (effect == null)
					{
						result = "";
					}
					else
					{
						int id = Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.etat));
						ObjetDescription itemById = Loader.getItemById(id);
						if (Information.IsNothing(itemById))
						{
							result = "Aliment Inconnu";
						}
						else
						{
							result = itemById.nom;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00009AF4 File Offset: 0x00007CF4
		private object method_0(string string_1)
		{
			checked
			{
				byte[] array = new byte[(int)Math.Round(unchecked((double)string_1.Length / 2.0 - 1.0)) + 1];
				int num = array.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					array[i] = Convert.ToByte(string_1.Substring(i * 2, 2), 16);
				}
				return array;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00009B54 File Offset: 0x00007D54
		public int PDV
		{
			get
			{
				int result;
				if (this.Fami == null)
				{
					result = 0;
				}
				else
				{
					Effect effect = this.Fami.effects.FirstOrDefault((Famillier._Closure$__.$I25-0 == null) ? (Famillier._Closure$__.$I25-0 = ((Effect e) => e.id == EffectIDEnum.LifeFami)) : Famillier._Closure$__.$I25-0);
					result = Conversions.ToInteger(Operators.ConcatenateObject("&H", effect.etat));
				}
				return result;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00009BBC File Offset: 0x00007DBC
		public object Eat(int i)
		{
			double num = Math.Abs(DateTime.Now.Subtract(this.lastEat).TotalHours);
			int num2 = Math.Abs(DateTime.Now.Subtract(this.lastEat).Minutes);
			bool flag;
			if (num >= (double)this.intervalTime && num2 > 0)
			{
				if (this.etat == EtatFamilier.normal)
				{
					flag = true;
					goto IL_70;
				}
			}
			flag = (this.etat == EtatFamilier.maigrichon);
			IL_70:
			checked
			{
				object result;
				if (flag)
				{
					if (this.StatsToAugmente.Count == 0)
					{
						result = false;
					}
					else
					{
						int num3 = this.StatsToAugmente.IndexOf(this.string_0);
						if (num3 + 1 >= this.StatsToAugmente.Count)
						{
							num3 = 0;
						}
						else
						{
							num3++;
						}
						if (this.Nourriture.Count > num3)
						{
							foreach (int idObjet in this.Nourriture[this.StatsToAugmente[num3]])
							{
								Objets objectById = this.bot.Inventaire.getObjectById(idObjet);
								if (objectById != null)
								{
									this.bot.Send(new Message("OM" + Conversions.ToString(this.Fami.idObjetInv) + "|8", 0, true, true, true));
									this.bot.Send(new Message("OM" + Conversions.ToString(objectById.idObjetInv) + "|8", 20, true, true, true));
									this.string_0 = this.StatsToAugmente[num3];
									return true;
								}
							}
						}
						if (this.NourritureType.Count > num3)
						{
							foreach (int type in this.NourritureType[this.StatsToAugmente[num3]])
							{
								Objets objets = this.bot.Inventaire.getObjectByType(type).FirstOrDefault<Objets>();
								if (objets != null)
								{
									this.bot.Send(new Message("OM" + Conversions.ToString(this.Fami.idObjetInv) + "|8", 0, true, true, true));
									this.bot.Send(new Message("OM" + Conversions.ToString(objets.idObjetInv) + "|8", 20, true, true, true));
									this.string_0 = this.StatsToAugmente[num3];
									result = true;
									break;
								}
							}
						}
					}
				}
				return result;
			}
		}

		// Token: 0x04000081 RID: 129
		public Dictionary<string, int[]> Nourriture;

		// Token: 0x04000082 RID: 130
		public int intervalTime;

		// Token: 0x04000083 RID: 131
		public Dictionary<string, int[]> NourritureType;

		// Token: 0x04000084 RID: 132
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long long_0;

		// Token: 0x04000085 RID: 133
		public List<string> StatsToAugmente;

		// Token: 0x04000086 RID: 134
		private string string_0;

		// Token: 0x04000087 RID: 135
		private int int_0;

		// Token: 0x04000088 RID: 136
		private int int_1;
	}
}
