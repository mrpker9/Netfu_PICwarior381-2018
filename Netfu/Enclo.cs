using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200001A RID: 26
	public class Enclo
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00007344 File Offset: 0x00005544
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.int_0);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007360 File Offset: 0x00005560
		public Drago waitedDragoIdInv()
		{
			return this.dragos.First((Enclo._Closure$__.$I11-0 == null) ? (Enclo._Closure$__.$I11-0 = ((Drago d) => d.objet == null)) : Enclo._Closure$__.$I11-0);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000073A0 File Offset: 0x000055A0
		public Enclo(int index, int cellid)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<Enclo.Class7>();
			this.dragos = new List<Drago>();
			this.int_2 = 4;
			this.activeElevage = false;
			this.etat = "En attente";
			this.useMangeoir = false;
			this.emotes = true;
			this.int_0 = index;
			this.int_1 = cellid;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007404 File Offset: 0x00005604
		public void AddItems(string s)
		{
			string[] array = s.Split(new char[]
			{
				'|'
			});
			foreach (string string_ in array)
			{
				Enclo._Closure$__13-0 CS$<>8__locals1 = new Enclo._Closure$__13-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Local_newpaddock = new Enclo.Class7(string_);
				Enclo.Class7 @class = this.list_0.FirstOrDefault((Enclo.Class7 p) => p.int_1 == CS$<>8__locals1.$VB$Local_newpaddock.int_1);
				if (@class != null)
				{
					@class.int_1 = CS$<>8__locals1.$VB$Local_newpaddock.int_1;
					@class.int_2 = CS$<>8__locals1.$VB$Local_newpaddock.int_2;
					@class.int_0 = CS$<>8__locals1.$VB$Local_newpaddock.int_0;
					@class.int_3 = CS$<>8__locals1.$VB$Local_newpaddock.int_3;
				}
				else
				{
					this.list_0.Add(CS$<>8__locals1.$VB$Local_newpaddock);
				}
			}
			this.int_2 = this.list_0.Count;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000074E8 File Offset: 0x000056E8
		public void ScanInventaire(ProgressBarX sender)
		{
			Enclo._Closure$__14-0 CS$<>8__locals1 = new Enclo._Closure$__14-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			CS$<>8__locals1.$VB$Local_sender = sender;
			CS$<>8__locals1.$VB$Local_sender.Invoke(new VB$AnonymousDelegate_0(delegate()
			{
				CS$<>8__locals1.$VB$Local_sender.Maximum = CS$<>8__locals1.$VB$Me.bot().Inventaire.getDragosCertif().Count;
			}));
			Thread thread = new Thread(checked(delegate()
			{
				try
				{
					foreach (Objets objet in CS$<>8__locals1.$VB$Me.bot().Inventaire.getDragosCertif())
					{
						Drago drago = new Drago(CS$<>8__locals1.$VB$Me.bot());
						drago.objet = objet;
						int num;
						drago.scan(num);
						num += 350;
						CS$<>8__locals1.$VB$Me.dragos.Add(drago);
						while (drago.id == 0L)
						{
							Thread.Sleep(10);
						}
						CS$<>8__locals1.$VB$Local_sender.Invoke((CS$<>8__locals1.$I2 == null) ? (CS$<>8__locals1.$I2 = delegate()
						{
							ProgressBarX $VB$Local_sender;
							($VB$Local_sender = CS$<>8__locals1.$VB$Local_sender).Value = $VB$Local_sender.Value + 1;
							CS$<>8__locals1.$VB$Local_sender.Text = Conversions.ToString(CS$<>8__locals1.$VB$Local_sender.Value) + "/" + Conversions.ToString(CS$<>8__locals1.$VB$Local_sender.Maximum);
						}) : CS$<>8__locals1.$I2);
					}
				}
				finally
				{
					List<Objets>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}));
			thread.Start();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002945 File Offset: 0x00000B45
		public void Elevage()
		{
			this.activeElevage = Licence.drag;
			if (!this.bot().status.enEchange)
			{
				this.method_1();
			}
			this.bot().status.enEchange = true;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000753C File Offset: 0x0000573C
		[DebuggerStepThrough]
		public void DoElevage(string packet)
		{
			Enclo.VB$StateMachine_16_DoElevage vb$StateMachine_16_DoElevage = new Enclo.VB$StateMachine_16_DoElevage();
			vb$StateMachine_16_DoElevage.$VB$Me = this;
			vb$StateMachine_16_DoElevage.$VB$Local_packet = packet;
			vb$StateMachine_16_DoElevage.$State = -1;
			vb$StateMachine_16_DoElevage.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_16_DoElevage.$Builder.Start<Enclo.VB$StateMachine_16_DoElevage>(ref vb$StateMachine_16_DoElevage);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000297E File Offset: 0x00000B7E
		public void setEtat(string str)
		{
			this.etat = str;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000757C File Offset: 0x0000577C
		public int closeEnclo(int time)
		{
			this.bot().Send(new Message("EV", time, true, true, true));
			this.bot().status.enEchange = false;
			return checked(time + 500);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000075BC File Offset: 0x000057BC
		public void playEmotes()
		{
			if (this.threadEmotes != null)
			{
				this.threadEmotes.Abort();
				this.threadEmotes = null;
			}
			if (this.emotes)
			{
				this.setEtat("Joue les emotes, " + this.CurrentPaddokTypeItem().ToString());
				this.threadEmotes = new Thread(delegate()
				{
					while (this.activeElevage)
					{
						this.bot().Send(new Message("eU8", 0, true, true, true));
						Thread.Sleep(4900);
						this.bot().Send(new Message("eU10", 0, true, true, true));
						Thread.Sleep(4900);
					}
				});
				this.threadEmotes.Start();
			}
			else
			{
				this.setEtat(this.CurrentPaddokTypeItem().ToString());
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002987 File Offset: 0x00000B87
		public void abortEmote()
		{
			if (this.threadEmotes != null)
			{
				this.threadEmotes.Abort();
				this.threadEmotes = null;
				this.Elevage();
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00007650 File Offset: 0x00005850
		private int method_0(Drago[] drago_0)
		{
			int num = 150;
			checked
			{
				foreach (Drago drago in drago_0)
				{
					drago.Transfert(Drago.TypeStatsDrago.Enclos, num, this.int_0);
					num += 150;
				}
				return num;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00007698 File Offset: 0x00005898
		public void updatesDragos(string packet)
		{
			if (packet.Length > 0)
			{
				string[] array = packet.Split(new char[]
				{
					';'
				});
				foreach (string text in array)
				{
					string value = text.Substring(0, text.IndexOf(":"));
					this.getDragoById(Conversions.ToInteger(value)).Update(text, this.int_0);
				}
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007708 File Offset: 0x00005908
		public Drago getDragoById(int id)
		{
			Drago drago = this.dragos.FirstOrDefault((Drago d) => d.id == (long)id);
			if (!Information.IsNothing(drago))
			{
			}
			return drago;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000029AC File Offset: 0x00000BAC
		private void method_1()
		{
			this.bot().interactiveManager.Use(this.int_1, 0);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00007748 File Offset: 0x00005948
		private List<Drago> method_2()
		{
			return this.dragos.Where((Enclo._Closure$__.$I25-0 == null) ? (Enclo._Closure$__.$I25-0 = ((Drago d) => d.currentStats == Drago.TypeStatsDrago.Enclos)) : Enclo._Closure$__.$I25-0).ToList<Drago>();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000778C File Offset: 0x0000598C
		private List<Drago> method_3()
		{
			return this.dragos.Where((Enclo._Closure$__.$I26-0 == null) ? (Enclo._Closure$__.$I26-0 = ((Drago d) => d.currentStats == Drago.TypeStatsDrago.Certificat)) : Enclo._Closure$__.$I26-0).ToList<Drago>();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000077D0 File Offset: 0x000059D0
		private Drago method_4()
		{
			return this.dragos.FirstOrDefault((Enclo._Closure$__.$I27-0 == null) ? (Enclo._Closure$__.$I27-0 = ((Drago d) => d.currentStats == Drago.TypeStatsDrago.Equiper)) : Enclo._Closure$__.$I27-0);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00007810 File Offset: 0x00005A10
		private List<Drago> method_5()
		{
			return this.dragos.Where((Enclo._Closure$__.$I28-0 == null) ? (Enclo._Closure$__.$I28-0 = ((Drago d) => d.currentStats == Drago.TypeStatsDrago.Etable)) : Enclo._Closure$__.$I28-0).ToList<Drago>();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00007854 File Offset: 0x00005A54
		public typeItemsPaddock MountNeededObjet(Drago mount)
		{
			checked
			{
				typeItemsPaddock result;
				if (mount.fatigue >= mount.fatigueM)
				{
					result = typeItemsPaddock.Fatigue;
				}
				else
				{
					int num = mount.generation;
					num = (int)Math.Round((double)num / 2.0);
					if (num < 1)
					{
						num = 1;
					}
					if (mount.energie == mount.energieM && mount.maturite == mount.maturiteM && mount.amour == mount.amourM && mount.endu == mount.enduM)
					{
						result = typeItemsPaddock.Unknow;
					}
					else
					{
						if (mount.femelle)
						{
							decimal d = decimal.Divide(new decimal(mount.endu), new decimal(mount.enduM));
							int num2 = (int)Math.Round(unchecked(1150.0 / (double)num * Convert.ToDouble(decimal.Subtract(1m, d)))) * -1;
							if (mount.endu < mount.enduM && mount.serenite > num2)
							{
								return typeItemsPaddock.Baffeur;
							}
							if (mount.serenite <= 0 && mount.endu < mount.enduM)
							{
								return typeItemsPaddock.Foudroyeur;
							}
							if (mount.maturite < mount.maturiteM && mount.serenite > -2000 && mount.serenite < 2000)
							{
								return typeItemsPaddock.Abreuvoir;
							}
							if (mount.amour < mount.amourM && mount.serenite <= 0)
							{
								return typeItemsPaddock.Caresseur;
							}
							if (mount.serenite >= 0 && mount.amour < mount.amourM)
							{
								return typeItemsPaddock.Dragofesse;
							}
						}
						else
						{
							decimal d2 = decimal.Divide(new decimal(mount.amour), new decimal(mount.amourM));
							int num3 = (int)Math.Round(unchecked(1150.0 / (double)num * Convert.ToDouble(decimal.Subtract(1m, d2))));
							if (mount.amour < mount.amourM && mount.serenite < num3)
							{
								return typeItemsPaddock.Caresseur;
							}
							if (mount.serenite >= 0 && mount.amour < mount.amourM)
							{
								return typeItemsPaddock.Dragofesse;
							}
							if (mount.maturite < mount.maturiteM && mount.serenite > -2000 && mount.serenite < 2000)
							{
								return typeItemsPaddock.Abreuvoir;
							}
							if (mount.endu < mount.enduM && mount.serenite > 0)
							{
								return typeItemsPaddock.Baffeur;
							}
							if (mount.serenite < 0 && mount.endu < mount.enduM)
							{
								return typeItemsPaddock.Foudroyeur;
							}
						}
						if (mount.maturite < mount.maturiteM)
						{
							result = ((mount.serenite <= -2000) ? typeItemsPaddock.Caresseur : typeItemsPaddock.Baffeur);
						}
						else if (mount.energie < mount.energieM)
						{
							result = typeItemsPaddock.Mangeoir;
						}
						else
						{
							result = typeItemsPaddock.Unknow;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00007B2C File Offset: 0x00005D2C
		public int replaceItems(typeItemsPaddock typeItems)
		{
			checked
			{
				int result;
				if (this.list_0.Count == 0)
				{
					MessageBox.Show("Aucun objet à placer, arret du bot");
					this.activeElevage = false;
					result = 0;
				}
				else
				{
					int num = 0;
					int num2;
					try
					{
						foreach (Enclo.Class7 @class in this.list_0)
						{
							num2 += 300;
							this.AskDelItem(@class.int_1, num2);
						}
					}
					finally
					{
						List<Enclo.Class7>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					List<Objets> list = this.bot().Inventaire.getObjectsPaddock(typeItems).Where((Enclo._Closure$__.$I30-0 == null) ? (Enclo._Closure$__.$I30-0 = ((Objets o) => Operators.ConditionalCompareObjectNotEqual(o.effects.Last<Effect>().min, "0", false))) : Enclo._Closure$__.$I30-0).ToList<Objets>();
					if (list.Sum((Enclo._Closure$__.$I30-1 == null) ? (Enclo._Closure$__.$I30-1 = ((Objets c) => c.numObjet)) : Enclo._Closure$__.$I30-1) < unchecked((long)this.list_0.Count))
					{
						MessageBox.Show("Vous n'avez pas assez d'objets d'elevage " + typeItems.ToString());
						this.activeElevage = false;
						result = num2;
					}
					else
					{
						int num3 = 0;
						try
						{
							foreach (Objets objets in list)
							{
								while (unchecked((long)num) < objets.numObjet)
								{
									num2 += 300;
									this.AskAddItem(objets, this.list_0[num3].int_1, num2);
									num++;
									num3++;
									if (num3 >= this.list_0.Count)
									{
										goto IL_18F;
									}
								}
								num = 0;
							}
							IL_18F:;
						}
						finally
						{
							List<Objets>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						result = num2 + 5000;
					}
				}
				return result;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000029C6 File Offset: 0x00000BC6
		public void AskDelItem(int cellid, int time)
		{
			this.bot().Send(new Message("Ro" + Conversions.ToString(cellid), time, true, true, true));
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000029EC File Offset: 0x00000BEC
		public void AskAddItem(Objets i, int cellid, int time)
		{
			this.bot().Send(new Message("OU" + Conversions.ToString(i.idObjetInv) + "||" + Conversions.ToString(cellid), time, true, true, true));
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00007D00 File Offset: 0x00005F00
		public typeItemsPaddock CurrentPaddokTypeItem()
		{
			typeItemsPaddock result;
			if ((from p in this.list_0.ToList<Enclo.Class7>()
			where p != null && this.PaddockItemType(this.list_0.ToList<Enclo.Class7>().First<Enclo.Class7>().int_0) == this.PaddockItemType(p.int_0) && p.int_2 > 0
			select p).Count<Enclo.Class7>() == this.list_0.Count)
			{
				result = ((this.list_0.FirstOrDefault<Enclo.Class7>() != null) ? this.PaddockItemType(this.list_0.First<Enclo.Class7>().int_0) : typeItemsPaddock.Unknow);
			}
			else
			{
				result = typeItemsPaddock.Unknow;
			}
			return result;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00007D6C File Offset: 0x00005F6C
		public typeItemsPaddock PaddockItemType(int ItemGid)
		{
			string nom = Loader.getItemById(ItemGid).nom;
			typeItemsPaddock result;
			if (nom.ToLower().Contains("caresseur"))
			{
				result = typeItemsPaddock.Caresseur;
			}
			else if (nom.ToLower().Contains("baffeur"))
			{
				result = typeItemsPaddock.Baffeur;
			}
			else if (nom.ToLower().Contains("mangeoire"))
			{
				result = typeItemsPaddock.Mangeoir;
			}
			else if (nom.ToLower().Contains("dragofesse"))
			{
				result = typeItemsPaddock.Dragofesse;
			}
			else if (nom.ToLower().Contains("foudroyeur"))
			{
				result = typeItemsPaddock.Foudroyeur;
			}
			else if (nom.ToLower().Contains("abreuvoir"))
			{
				result = typeItemsPaddock.Abreuvoir;
			}
			else
			{
				result = typeItemsPaddock.Unknow;
			}
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007E0C File Offset: 0x0000600C
		public List<Objets> getDragosItemsWhere(int nb, bool maturitymax, bool maturityzero, bool level1, bool reproductrice, bool notReproductrice, bool maxEnergie, bool sterile, bool male, bool femelle)
		{
			List<Objets> list = new List<Objets>();
			try
			{
				foreach (Drago drago in this.dragos)
				{
					bool flag = true;
					if (maturitymax)
					{
						flag &= (drago.maturite == drago.maturiteM);
					}
					if (maturityzero)
					{
						flag &= (drago.maturite == 0);
					}
					if (level1)
					{
						flag &= (drago.niveau == 1);
					}
					if (!reproductrice)
					{
					}
					if (!sterile)
					{
					}
					if (!notReproductrice)
					{
					}
					if (maxEnergie)
					{
						flag &= (drago.energie == ((-((maxEnergie > false) ? 1 : 0)) ? 1 : 0));
					}
					if (male)
					{
						flag &= !drago.femelle;
					}
					if (femelle)
					{
						flag &= drago.femelle;
					}
					if (flag)
					{
						list.Add(drago.objet);
					}
				}
			}
			finally
			{
				List<Drago>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x04000046 RID: 70
		private List<Enclo.Class7> list_0;

		// Token: 0x04000047 RID: 71
		private int int_0;

		// Token: 0x04000048 RID: 72
		private int int_1;

		// Token: 0x04000049 RID: 73
		public List<Drago> dragos;

		// Token: 0x0400004A RID: 74
		private int int_2;

		// Token: 0x0400004B RID: 75
		public bool activeElevage;

		// Token: 0x0400004C RID: 76
		public Thread threadEmotes;

		// Token: 0x0400004D RID: 77
		public string etat;

		// Token: 0x0400004E RID: 78
		public bool useMangeoir;

		// Token: 0x0400004F RID: 79
		public bool emotes;

		// Token: 0x0200001B RID: 27
		private class Class7
		{
			// Token: 0x060000C4 RID: 196 RVA: 0x00007F4C File Offset: 0x0000614C
			public Class7(string string_0)
			{
				Class15.XRATSHnz66atd();
				base..ctor();
				string[] array = string_0.Split(new char[]
				{
					';'
				});
				this.int_0 = Conversions.ToInteger(array[1]);
				this.int_1 = Conversions.ToInteger(array[0]);
				this.int_2 = Conversions.ToInteger(array[3]);
				this.int_3 = Conversions.ToInteger(array[4]);
			}

			// Token: 0x04000050 RID: 80
			public int int_0;

			// Token: 0x04000051 RID: 81
			public int int_1;

			// Token: 0x04000052 RID: 82
			public int int_2;

			// Token: 0x04000053 RID: 83
			public int int_3;
		}
	}
}
