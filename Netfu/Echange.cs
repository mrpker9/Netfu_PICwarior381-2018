using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000D1 RID: 209
	public class Echange
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x00004550 File Offset: 0x00002750
		static Echange()
		{
			Class15.XRATSHnz66atd();
			Echange.random_0 = new Random();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00021348 File Offset: 0x0001F548
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00021360 File Offset: 0x0001F560
		public string SecureCode
		{
			get
			{
				return this.string_0;
			}
			set
			{
				checked
				{
					if (value != null)
					{
						int length = value.Length;
						for (int i = length; i <= 7; i++)
						{
							value += "_";
						}
						this.string_0 = value;
					}
				}
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0002139C File Offset: 0x0001F59C
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.int_0);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000213B8 File Offset: 0x0001F5B8
		public Echange()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.objetsID = new string[257];
			this.objetsIdType = new string[257];
			this.objetsQuantite = new int[257];
			this.giveKamas = true;
			this.videBanque = false;
			this.TakeItems = new Dictionary<int, int>();
			this.hItClyguyH = 0;
			this.dictionary_0 = new Dictionary<int, int[]>();
			int num = 1;
			checked
			{
				do
				{
					this.objetsQuantite[num] = 0;
					this.objetsID[num] = null;
					this.objetsIdType[num] = null;
					num++;
				}
				while (num <= 250);
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0002145C File Offset: 0x0001F65C
		public void PacketEchange(int index, string packet)
		{
			this.int_0 = index;
			Declarations.getComtpesByIndex(index);
			checked
			{
				if (Operators.CompareString(Strings.Mid(packet, 1, 2), "DQ", false) == 0)
				{
					this.method_10(packet.Substring(2));
				}
				else if (Operators.CompareString(Strings.Mid(packet, 1, 3), "ERK", false) == 0)
				{
					this.method_12(packet);
				}
				else if (Operators.CompareString(Strings.Mid(packet, 1, 5), "EmKO+", false) == 0)
				{
					this.method_11(packet);
				}
				else if (Operators.CompareString(Strings.Mid(packet, 1, 5), "EmKO-", false) == 0)
				{
					this.onItemRemove(packet);
				}
				else if (Operators.CompareString(Strings.Mid(packet, 1, 3), "EHl", false) == 0)
				{
					this.onReceptionPrices(packet);
				}
				else if (Operators.CompareString(Strings.Mid(packet, 1, 2), "EK", false) == 0)
				{
					if (this.bot().config.Echange)
					{
						this.method_9(packet);
					}
				}
				else
				{
					if (Operators.CompareString(Strings.Mid(packet, 1, 2), "EL", false) == 0)
					{
						List<string> list = packet.Substring(2).Split(new char[]
						{
							';'
						}).ToList<string>();
						list.RemoveAt(list.Count - 1);
						this.list_0 = new List<Objets>();
						try
						{
							foreach (string text in list)
							{
								this.list_0.Add(new Objets(text.Substring(1)));
							}
							return;
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
					}
					if (Operators.CompareString(Strings.Mid(packet, 1, 3), "ECK", false) == 0)
					{
						string text2 = packet.Contains("|") ? packet.Substring(3, packet.IndexOf("|") - 3) : packet.Substring(3);
						string left = text2;
						if (Operators.CompareString(left, Conversions.ToString(1), false) == 0)
						{
							this.method_8(packet);
						}
						else if (Operators.CompareString(left, Conversions.ToString(5), false) == 0)
						{
							this.method_0(packet);
						}
						else if (Operators.CompareString(left, Conversions.ToString(3), false) == 0)
						{
							this.zwuCegJkYE(packet);
						}
						else if (Operators.CompareString(left, Conversions.ToString(11), false) == 0)
						{
							this.onCreateEchangeAchatHDV(packet);
						}
						else if (Operators.CompareString(left, Conversions.ToString(16), false) == 0 && this.bot().map.paddock != null)
						{
							this.bot().map.paddock.DoElevage(packet.Substring(7));
						}
					}
					else if (Operators.CompareString(Strings.Mid(packet, 1, 4), "KCK1", false) == 0 || Operators.CompareString(Strings.Mid(packet, 1, 4), "KCK0", false) == 0)
					{
						this.bot().Send(new Message("KK0|" + this.SecureCode, 50, true, true, true));
					}
				}
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00021774 File Offset: 0x0001F974
		public bool checkMerchant()
		{
			this.bot().map.method_0();
			bool result;
			if (this.bot().map != null && this.bot().map.method_0() < 6)
			{
				this.bot().Send(new Message("Eq", 10, true, true, true));
				this.bot().Send(new Message("EQ", 20, true, true, true));
				this.bot().config.Merchant = false;
				this.bot().status.connexion = status.ConnexionStatus.const_0;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00021814 File Offset: 0x0001FA14
		[DebuggerStepThrough]
		private void zwuCegJkYE(string string_1)
		{
			Echange.VB$StateMachine_25_onCreateEchangeAtelier vb$StateMachine_25_onCreateEchangeAtelier = new Echange.VB$StateMachine_25_onCreateEchangeAtelier();
			vb$StateMachine_25_onCreateEchangeAtelier.$VB$Me = this;
			vb$StateMachine_25_onCreateEchangeAtelier.$VB$Local_packet = string_1;
			vb$StateMachine_25_onCreateEchangeAtelier.$State = -1;
			vb$StateMachine_25_onCreateEchangeAtelier.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_25_onCreateEchangeAtelier.$Builder.Start<Echange.VB$StateMachine_25_onCreateEchangeAtelier>(ref vb$StateMachine_25_onCreateEchangeAtelier);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00004561 File Offset: 0x00002761
		private void method_0(string string_1)
		{
			this.bot().status.enEchange = true;
			string monNom = this.bot().monNom;
			this.method_2(false);
			Fonctions.sendNotif(this.bot().monNom + ": Viens d'effectuer un trajet en banque");
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00021854 File Offset: 0x0001FA54
		private async void method_1()
		{
			this.Close(1500, true);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00021890 File Offset: 0x0001FA90
		[DebuggerStepThrough]
		private void method_2(bool bool_0)
		{
			Echange.VB$StateMachine_28_ItemStorage vb$StateMachine_28_ItemStorage = new Echange.VB$StateMachine_28_ItemStorage();
			vb$StateMachine_28_ItemStorage.$VB$Me = this;
			vb$StateMachine_28_ItemStorage.$VB$Local_accept = bool_0;
			vb$StateMachine_28_ItemStorage.$State = -1;
			vb$StateMachine_28_ItemStorage.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_28_ItemStorage.$Builder.Start<Echange.VB$StateMachine_28_ItemStorage>(ref vb$StateMachine_28_ItemStorage);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000218D0 File Offset: 0x0001FAD0
		private int method_3(int int_1, int int_2, int int_3)
		{
			Objets objets = this.list_0.FirstOrDefault((Objets o) => Conversions.ToDouble(o.idObjet) == (double)int_1);
			int num = 0;
			if (objets != null)
			{
				num = checked((int)(unchecked(((long)int_2 > objets.numObjet) ? objets.numObjet : ((long)int_2))));
				this.bot().Send(new Message("EMO-" + Conversions.ToString(objets.idObjetInv) + "|" + Conversions.ToString(num), int_3, true, true, true));
			}
			return num;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00021958 File Offset: 0x0001FB58
		[DebuggerStepThrough]
		private Task method_4()
		{
			Echange.VB$StateMachine_30_TakeIgredients vb$StateMachine_30_TakeIgredients = new Echange.VB$StateMachine_30_TakeIgredients();
			vb$StateMachine_30_TakeIgredients.$VB$Me = this;
			vb$StateMachine_30_TakeIgredients.$State = -1;
			vb$StateMachine_30_TakeIgredients.$Builder = AsyncTaskMethodBuilder.Create();
			vb$StateMachine_30_TakeIgredients.$Builder.Start<Echange.VB$StateMachine_30_TakeIgredients>(ref vb$StateMachine_30_TakeIgredients);
			return vb$StateMachine_30_TakeIgredients.$Builder.Task;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0002199C File Offset: 0x0001FB9C
		internal void method_5(string string_1)
		{
			string str = string_1.Substring(0, string_1.IndexOf("|"));
			int vitesseInvit = this.bot().config.vitesseInvit;
			checked
			{
				int time = Fonctions.rand.Next(vitesseInvit, vitesseInvit + 500);
				this.bot().Send(new Message("gJE" + str, time, false, true, false));
				if (!this.bot().status.enEchange)
				{
					this.bot().status.enEchange = true;
					Task.Run(async delegate()
					{
						await Task.Delay((int)Math.Round(Math.Round(unchecked((double)time * 1.8))));
						this.bot().status.enEchange = false;
					});
				}
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00021A50 File Offset: 0x0001FC50
		public void onGroupInvite(string message)
		{
			string left = Strings.Mid(Fonctions.Gettok(message, "|", 1), 4);
			string left2 = Fonctions.Gettok(message, "|", 2);
			checked
			{
				if (Operators.CompareString(left2, this.bot().monNom, false) == 0)
				{
					if (Operators.CompareString(left, this.bot().nomChef, false) == 0)
					{
						this.bot().Send(new Message("PA", 0, true, true, true));
					}
					else
					{
						int vitesseInvit = this.bot().config.vitesseInvit;
						int time = Fonctions.rand.Next(vitesseInvit, vitesseInvit + 500);
						this.bot().Send(new Message("PR", time, false, true, true));
						if (!this.bot().status.enEchange)
						{
							this.bot().status.enEchange = true;
							Task.Run(async delegate()
							{
								await Task.Delay((int)Math.Round(Math.Round(unchecked((double)time * 1.8))));
								this.bot().status.enEchange = false;
							});
						}
					}
				}
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00021B58 File Offset: 0x0001FD58
		private async Task method_6()
		{
			checked
			{
				if (this.videBanque)
				{
					int podsrestant = this.bot().Inventaire.podsMax - this.bot().Inventaire.podsactual;
					while (podsrestant > 10 && this.list_0.Count > 0)
					{
						Objets item = this.list_0.FirstOrDefault<Objets>();
						ObjetDescription obj = Loader.getItemById(Conversions.ToInteger(item.idObjet));
						double qty = (item.numObjet * unchecked((long)obj.poids) > unchecked((long)podsrestant)) ? ((double)podsrestant / (double)obj.poids) : ((double)item.numObjet);
						TaskAwaiter taskAwaiter = Task.Delay(Echange.random_0.Next(200, 500)).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter);
						}
						taskAwaiter.GetResult();
						taskAwaiter = default(TaskAwaiter);
						podsrestant -= this.method_3(obj.id, (int)Math.Round(Math.Round(qty)), 0);
						if (qty >= (double)item.numObjet)
						{
							this.list_0.Remove(item);
						}
					}
					this.videBanque = false;
				}
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000045A1 File Offset: 0x000027A1
		private void method_7(int int_1, int int_2, int int_3)
		{
			this.bot().Send(new Message("EMO+" + Conversions.ToString(int_1) + "|" + Conversions.ToString(int_2), int_3, true, true, true));
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00021B9C File Offset: 0x0001FD9C
		private void method_8(string string_1)
		{
			this.bot().status.enEchange = true;
			if (!this.bot().config.Echange && this.bot().idChef != 0)
			{
				if (this.giveKamas)
				{
					this.bot().Send(new Message("EMG" + Conversions.ToString(this.bot().InfosPerso.Kamas), Echange.random_0.Next(1000, 1100), true, true, true));
				}
				Declarations.getComtpesById(this.bot().idChef);
				this.method_2(true);
				this.giveKamas = false;
			}
			int num = 1;
			checked
			{
				do
				{
					this.objetsQuantite[num] = 0;
					this.objetsID[num] = null;
					num++;
				}
				while (num <= 250);
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00021C6C File Offset: 0x0001FE6C
		public void LaunchEchangeToMule(string nom, bool kamas = true)
		{
			Perso comtpesByName = Declarations.getComtpesByName(nom);
			if ((double)comtpesByName.idChef == Conversions.ToDouble(this.bot().monIdDofus) && (comtpesByName != null && comtpesByName.status.connexion == status.ConnexionStatus.const_3 && comtpesByName.map != null && comtpesByName.map.id == this.bot().map.id))
			{
				comtpesByName.ExchangeManager.giveKamas = kamas;
				this.bot().Send(new Message("ER1|" + comtpesByName.monIdDofus, 0, true, true, true));
				this.bot().launcher.waitAction = 2000;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00021D20 File Offset: 0x0001FF20
		private void method_9(string string_1)
		{
			this.bot().Send(new Message("EK", Echange.random_0.Next(1000, 1100), true, true, true));
			this.hItClyguyH = Operators.AddObject(this.hItClyguyH, this.nombreE);
			this.Close(2000, false);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00021D84 File Offset: 0x0001FF84
		public void Onzaap(string packet)
		{
			if (this.bot().mode != -1)
			{
				this.bot().status.enEchange = true;
				if (this.bot().idChef != 0)
				{
					this.destmapid = Declarations.get_MyChef(this.int_0).ExchangeManager.destmapid;
				}
				if (this.destmapid > 0)
				{
					this.bot().Send(new Message("WU" + Conversions.ToString(this.destmapid), 200, true, true, true));
				}
				else
				{
					this.bot().Send(new Message("WV", 300, true, true, true));
					this.bot().Send(new Message("WV", 300, true, true, true));
				}
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00021E58 File Offset: 0x00020058
		private void method_10(string string_1)
		{
			checked
			{
				if (this.bot().idChef <= 0)
				{
					string[] array = string_1.Split(new char[]
					{
						'|'
					});
					int num = -1;
					if (array.Count<string>() == 1)
					{
						this.Close(10, false);
					}
					else
					{
						foreach (string text in array)
						{
							string[] array3 = text.Split(new char[]
							{
								';'
							});
							if (num == -1)
							{
								num = Conversions.ToInteger(array3[0]);
							}
							else
							{
								if (this.reponseNpc.Count == 0)
								{
									this.bot().Send(new Message("DR" + Conversions.ToString(num) + "|" + array3[0], 0, true, true, true));
									this.bot().sendToSlave("DR" + Conversions.ToString(num) + "|" + array3[0], 0);
									break;
								}
								string[] array4 = array3;
								for (int j = 0; j < array4.Length; j++)
								{
									Echange._Closure$__40-0 CS$<>8__locals1 = new Echange._Closure$__40-0(CS$<>8__locals1);
									CS$<>8__locals1.$VB$Local_d = array4[j];
									string expression = this.reponseNpc.FirstOrDefault((string s) => Loader.DialogsNpc[Conversions.ToInteger(CS$<>8__locals1.$VB$Local_d)].Contains(s));
									if (!Information.IsNothing(expression))
									{
										this.bot().Send(new Message("DR" + Conversions.ToString(num) + "|" + CS$<>8__locals1.$VB$Local_d, 0, true, true, true));
										this.bot().sendToSlave("DR" + Conversions.ToString(num) + "|" + CS$<>8__locals1.$VB$Local_d, 0);
										return;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00022000 File Offset: 0x00020200
		public void SpeekNpc(int id, List<string> reponseNpc)
		{
			Echange._Closure$__41-0 CS$<>8__locals1 = new Echange._Closure$__41-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_id = id;
			if (this.bot().idChef <= 0)
			{
				if (-(this.bot().status.enEchange > false))
				{
					this.Close(0, false);
				}
				NPC value;
				if (CS$<>8__locals1.$VB$Local_id == -84848)
				{
					value = this.bot().map.Npcs.FirstOrDefault<KeyValuePair<int, NPC>>().Value;
				}
				else
				{
					value = this.bot().map.Npcs.FirstOrDefault((KeyValuePair<int, NPC> n) => n.Value.Id == CS$<>8__locals1.$VB$Local_id).Value;
				}
				if (!Information.IsNothing(value))
				{
					this.reponseNpc = reponseNpc;
					this.bot().status.enEchange = true;
					try
					{
						foreach (int id2 in this.bot().get_Slave(true))
						{
							Perso comtpesById = Declarations.getComtpesById(id2);
							if (!Information.IsNothing(comtpesById))
							{
								comtpesById.status.enEchange = true;
							}
						}
					}
					finally
					{
						List<int>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					this.bot().Send(new Message("DC" + Conversions.ToString(value.Id), 0, true, true, true));
					this.bot().sendToSlave("DC" + Conversions.ToString(value.Id), 0);
				}
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00022180 File Offset: 0x00020380
		private void method_11(string string_1)
		{
			checked
			{
				if (this.bot().config.Echange)
				{
					string gettokText = Strings.Mid(string_1, 6);
					string text = Fonctions.Gettok(gettokText, "|", 1);
					int num = Conversions.ToInteger(Fonctions.Gettok(gettokText, "|", 2));
					string text2 = Fonctions.Gettok(gettokText, "|", 3);
					this.idEchange = text;
					int num2 = 1;
					while (Operators.CompareString(this.objetsID[num2], text, false) != 0)
					{
						num2++;
						if (num2 > 250)
						{
							IL_8D:
							if (this.objetsQuantite[num2] != num)
							{
								num2 = 1;
								while (Conversions.ToDouble(this.objetsID[num2]) != 0.0)
								{
									num2++;
									if (num2 > 250)
									{
										goto IL_EB;
									}
								}
								this.objetsID[num2] = text;
								this.objetsIdType[num2] = text2;
								this.objetsQuantite[num2] = num;
							}
							IL_EB:
							this.nombreE = 0;
							num2 = 1;
							int num4;
							do
							{
								if (this.bot().config.itemToExchange.ContainsKey(Conversions.ToInteger(this.objetsIdType[num2])))
								{
									int value = this.bot().config.itemToExchange[Conversions.ToInteger(this.objetsIdType[num2])].Value;
									int num3 = this.objetsQuantite[num2] * value;
									num4 += num3;
									ref int ptr = ref this.nombreE;
									this.nombreE = ptr + this.objetsQuantite[num2];
								}
								num2++;
							}
							while (num2 <= 250);
							this.bot().Send(new Message("EMG" + Conversions.ToString(num4), Echange.random_0.Next(2000, 3500), true, true, true));
							num4 = 0;
							return;
						}
					}
					this.objetsQuantite[num2] = num;
					this.objetsIdType[num2] = text2;
					goto IL_8D;
				}
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000045D2 File Offset: 0x000027D2
		public void onItemRemove(string packet)
		{
			if (this.bot().config.Echange)
			{
				this.Close(0, false);
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0002235C File Offset: 0x0002055C
		private async void method_12(string string_1)
		{
			checked
			{
				try
				{
					int Premz = string_1.IndexOf('|');
					int Dat = Premz - 3;
					string idMec = Strings.Mid(string_1, 4, Dat);
					if (Conversions.ToDouble(idMec) == (double)this.bot().idChef | Operators.CompareString(idMec, this.bot().idMaitre, false) == 0)
					{
						this.bot().Send(new Message("EA", Fonctions.rand.Next(300, 500), false, true, true));
					}
					else if (this.bot().config.Echange)
					{
						this.bot().Send(new Message("EA", Fonctions.rand.Next(300, 500), false, true, true));
						int i = 1;
						do
						{
							this.objetsQuantite[i] = 0;
							this.objetsID[i] = null;
							this.objetsIdType[i] = null;
							i++;
						}
						while (i <= 250);
					}
					else if (Operators.CompareString(idMec, this.bot().monIdDofus, false) != 0)
					{
						this.bot().status.enEchange = true;
						int conf = this.bot().config.vitesseInvit;
						int wait = Fonctions.rand.Next(conf, conf + 500);
						this.Close(wait, false);
					}
				}
				catch (Exception ex2)
				{
					Exception ex = ex2;
					Fonctions.traiterErreur(ex);
				}
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0002239C File Offset: 0x0002059C
		public async void Close(int time, bool acceptechange)
		{
			try
			{
				if (acceptechange)
				{
					this.bot().Send(new Message("EK", time, true, true, false));
				}
				else
				{
					this.bot().Send(new Message("EV", time, true, true, false));
					this.bot().Send(new Message("DV", time, true, true, false));
				}
				TaskAwaiter taskAwaiter = Task.Delay(checked((int)Math.Round(Math.Round((double)(unchecked((float)time * 1.8f)))))).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				taskAwaiter = default(TaskAwaiter);
				this.bot().status.enEchange = false;
			}
			catch (Exception ex)
			{
				Fonctions.traiterErreur(ex);
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000223E4 File Offset: 0x000205E4
		[DebuggerStepThrough]
		public void onCreateEchangeAchatHDV(string packet)
		{
			Echange.VB$StateMachine_47_onCreateEchangeAchatHDV vb$StateMachine_47_onCreateEchangeAchatHDV = new Echange.VB$StateMachine_47_onCreateEchangeAchatHDV();
			vb$StateMachine_47_onCreateEchangeAchatHDV.$VB$Me = this;
			vb$StateMachine_47_onCreateEchangeAchatHDV.$VB$Local_packet = packet;
			vb$StateMachine_47_onCreateEchangeAchatHDV.$State = -1;
			vb$StateMachine_47_onCreateEchangeAchatHDV.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_47_onCreateEchangeAchatHDV.$Builder.Start<Echange.VB$StateMachine_47_onCreateEchangeAchatHDV>(ref vb$StateMachine_47_onCreateEchangeAchatHDV);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00022424 File Offset: 0x00020624
		public void onReceptionPrices(string packet)
		{
			checked
			{
				if (this.bot().mode > 0)
				{
					bool flag = this.BuyItems != null && this.BuyItems.Count > 0;
					if (this.SellItems != null)
					{
						bool flag2 = this.SellItems.Count > 0;
					}
					string[] array = packet.Substring(3).Split(new char[]
					{
						'|'
					});
					string value = array[0];
					string[] array2 = array[1].Split(new char[]
					{
						';'
					});
					string text = array2[0];
					List<string> list = array2.ToList<string>();
					list.RemoveAt(0);
					list.RemoveAt(0);
					int[] array3 = list.Select((Echange._Closure$__.$I48-0 == null) ? (Echange._Closure$__.$I48-0 = ((string p) => string.IsNullOrWhiteSpace(p) ? 0 : int.Parse(p))) : Echange._Closure$__.$I48-0).ToArray<int>();
					if (!this.dictionary_0.ContainsKey(Conversions.ToInteger(value)))
					{
						this.dictionary_0.Add(Conversions.ToInteger(value), array3);
					}
					else
					{
						this.dictionary_0[Conversions.ToInteger(value)] = array3;
					}
					if (flag && this.BuyItems.ContainsKey(Conversions.ToInteger(value)))
					{
						int num = this.BuyItems[Conversions.ToInteger(value)][0];
						int num2 = this.BuyItems[Conversions.ToInteger(value)][1];
						int num3 = 100;
						int num4 = 3;
						try
						{
							foreach (int num5 in array3.Reverse<int>())
							{
								if (num5 > 0 && num3 <= num)
								{
									double num6 = (double)num5 / (double)num3;
									if (num6 <= (double)num2)
									{
										this.bot().Send(new Message(string.Concat(new string[]
										{
											"EHB",
											text,
											"|",
											Conversions.ToString(num4),
											"|",
											Conversions.ToString(num5)
										}), 500, true, true, true));
										break;
									}
								}
								num3 = (int)Math.Round((double)num3 / 10.0);
								num4--;
							}
						}
						finally
						{
							IEnumerator<int> enumerator;
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000045EE File Offset: 0x000027EE
		public void launcHDV()
		{
			this.bot().Send(new Message("ER11|-1", 0, true, true, true));
			this.bot().launcher.waitAction = 2000;
		}

		// Token: 0x04000486 RID: 1158
		private int int_0;

		// Token: 0x04000487 RID: 1159
		public string[] objetsID;

		// Token: 0x04000488 RID: 1160
		public string[] objetsIdType;

		// Token: 0x04000489 RID: 1161
		public string idEchange;

		// Token: 0x0400048A RID: 1162
		public int[] objetsQuantite;

		// Token: 0x0400048B RID: 1163
		public int nombreE;

		// Token: 0x0400048C RID: 1164
		public List<string> reponseNpc;

		// Token: 0x0400048D RID: 1165
		public bool giveKamas;

		// Token: 0x0400048E RID: 1166
		public bool videBanque;

		// Token: 0x0400048F RID: 1167
		private static Random random_0;

		// Token: 0x04000490 RID: 1168
		public int destmapid;

		// Token: 0x04000491 RID: 1169
		private string string_0;

		// Token: 0x04000492 RID: 1170
		public Dictionary<int, int[]> BuyItems;

		// Token: 0x04000493 RID: 1171
		public Dictionary<int, int[]> SellItems;

		// Token: 0x04000494 RID: 1172
		public Dictionary<int, int> TakeItems;

		// Token: 0x04000495 RID: 1173
		private List<Objets> list_0;

		// Token: 0x04000496 RID: 1174
		private object hItClyguyH;

		// Token: 0x04000497 RID: 1175
		private Dictionary<int, int[]> dictionary_0;

		// Token: 0x020000D2 RID: 210
		// (Invoke) Token: 0x0600046B RID: 1131
		public delegate void PacketDelegate(int index, string packet);
	}
}
