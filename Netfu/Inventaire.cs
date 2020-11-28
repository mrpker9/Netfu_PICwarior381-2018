using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000E8 RID: 232
	public class Inventaire
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00024C6C File Offset: 0x00022E6C
		public int podsPercent
		{
			get
			{
				Perso comtpesByIndex = Declarations.getComtpesByIndex(this.Index);
				int result;
				if (comtpesByIndex.Inventaire.podsMax > 0)
				{
					result = checked((int)Math.Round(unchecked((double)comtpesByIndex.Inventaire.podsactual / (double)comtpesByIndex.Inventaire.podsMax * 100.0)));
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00024CC4 File Offset: 0x00022EC4
		public List<Objets> getObjectsPaddock(typeItemsPaddock type)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool flag = false;
			List<Objets> result;
			try
			{
				Monitor.Enter(obj, ref flag);
				string str = type.ToString().ToLower();
				result = (from o in this._LObjets
				where o.nomObjet.ToLower().Contains(str)
				select o).ToList<Objets>();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(obj);
				}
			}
			return result;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00024D40 File Offset: 0x00022F40
		public void addObjet(Objets Obj)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this._LObjets.Add(Obj);
				if (Obj.isFami)
				{
					Perso comtpesByIndex = Declarations.getComtpesByIndex(this.Index);
					Famillier famillier = comtpesByIndex.familiers.FirstOrDefault((Famillier f) => f.Fami.idObjetInv == Obj.idObjetInv);
					if (famillier == null)
					{
						comtpesByIndex.familiers.Add(new Famillier(Obj, comtpesByIndex));
					}
				}
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00024DF0 File Offset: 0x00022FF0
		public void removeObjet(Objets obj)
		{
			object obj2 = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
			lock (obj2)
			{
				this._LObjets.RemoveAll((Objets o) => o.idObjetInv == obj.idObjetInv);
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00024E58 File Offset: 0x00023058
		public Objets getObjectById(int idObjet)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Objets result;
			lock (obj)
			{
				result = this._LObjets.FirstOrDefault((Objets o) => Conversions.ToDouble(o.idObjet) == (double)idObjet);
			}
			return result;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00024EC0 File Offset: 0x000230C0
		public Objets getObjectByIdInv(long idObjetInv)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Objets result;
			lock (obj)
			{
				result = this._LObjets.FirstOrDefault((Objets o) => o.idObjetInv == idObjetInv);
			}
			return result;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00024F28 File Offset: 0x00023128
		public List<Objets> getObjectByType(int type)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Objets> result;
			lock (obj)
			{
				List<Objets> list = (from o in this._LObjets
				where o.type == type
				select o).ToList<Objets>();
				result = list;
			}
			return result;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00024F98 File Offset: 0x00023198
		public List<Objets> getObjects()
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Objets> result;
			lock (obj)
			{
				result = this._LObjets.ToList<Objets>();
			}
			return result;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00024FE8 File Offset: 0x000231E8
		public List<Objets> getDragosCertif()
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Objets> result;
			lock (obj)
			{
				result = this._LObjets.Where((Inventaire._Closure$__.$I15-0 == null) ? (Inventaire._Closure$__.$I15-0 = ((Objets d) => Loader.getItemById(Conversions.ToInteger(d.idObjet)).type == 97)) : Inventaire._Closure$__.$I15-0).ToList<Objets>();
			}
			return result;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00025060 File Offset: 0x00023260
		public void ClearObjets()
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				Declarations.getComtpesByIndex(this.Index).familiers.Clear();
				this._LObjets.Clear();
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000250C0 File Offset: 0x000232C0
		public Inventaire(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this._LObjets = new List<Objets>();
			this.bool_0 = true;
			this.lockObject = RuntimeHelpers.GetObjectValue(new object());
			this.dateTime_0 = DateTime.Now;
			this.Index = index;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0002510C File Offset: 0x0002330C
		public void OnItemSet(string sExtraData)
		{
			string[] array = sExtraData.Substring(2).Split(new char[]
			{
				'|'
			});
			string value = array[0];
			Objets objectByIdInv = this.getObjectByIdInv(Conversions.ToLong(value));
			if (array[1].Length > 0)
			{
				objectByIdInv.position = Conversions.ToInteger(array[1]);
			}
			else
			{
				objectByIdInv.position = -1;
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00025168 File Offset: 0x00023368
		public void PacketInventaire(string packet)
		{
			Inventaire._Closure$__19-2 CS$<>8__locals1 = new Inventaire._Closure$__19-2(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			CS$<>8__locals1.$VB$Local_packet = packet;
			Perso comtpesByIndex = Declarations.getComtpesByIndex(this.Index);
			checked
			{
				if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 2), "Ow", false) == 0)
				{
					string[] array = Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 3).Split(new char[]
					{
						'|'
					});
					this.podsactual = Conversions.ToInteger(array[0]);
					this.podsMax = Conversions.ToInteger(array[1].Replace("FO", "").Replace("-", ""));
					if (this.podsactual >= this.podsMax)
					{
						this.podsactual = this.podsMax;
					}
				}
				else if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 4), "OAKO", false) == 0)
				{
					Objets.PacketObjets2(this.Index, CS$<>8__locals1.$VB$Local_packet);
				}
				else if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 2), "OC", false) == 0)
				{
					foreach (string text in CS$<>8__locals1.$VB$Local_packet.Substring(3).Split(new char[]
					{
						'*'
					}))
					{
						string[] array3 = text.Split(new char[]
						{
							';'
						});
						for (int k = 0; k < array3.Length; k++)
						{
							Objets objets = new Objets(array3[k]);
							if (objets != null)
							{
								this.removeObjet(objets);
								this.addObjet(objets);
							}
						}
					}
				}
				else
				{
					if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 2), "OQ", false) == 0)
					{
						object obj = this.lockObject;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							Inventaire._Closure$__19-0 CS$<>8__locals2 = new Inventaire._Closure$__19-0(CS$<>8__locals2);
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
							Inventaire._Closure$__19-0 CS$<>8__locals3 = CS$<>8__locals2;
							int num = this._LObjets.Count - 1;
							CS$<>8__locals3.$VB$Local_i = 0;
							while (CS$<>8__locals2.$VB$Local_i <= num)
							{
								if (this._LObjets[CS$<>8__locals2.$VB$Local_i].idObjetInv == Conversions.ToLong(Fonctions.Gettok(Strings.Mid(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_packet, 3), "|", 1)))
								{
									long numObjet = this._LObjets[CS$<>8__locals2.$VB$Local_i].numObjet;
									this._LObjets[CS$<>8__locals2.$VB$Local_i].numObjet = Conversions.ToLong(Fonctions.Gettok(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_packet, "|", 2));
									if (this._LObjets[CS$<>8__locals2.$VB$Local_i].numObjet > 1L)
									{
										this._LObjets[CS$<>8__locals2.$VB$Local_i].position = -1;
									}
									if (!Information.IsNothing(comtpesByIndex.Jobs))
									{
										Inventaire._Closure$__19-1 CS$<>8__locals4 = new Inventaire._Closure$__19-1(CS$<>8__locals4);
										List<SkillDescription> source = comtpesByIndex.Jobs.mySkills().Select((Inventaire._Closure$__.$I19-0 == null) ? (Inventaire._Closure$__.$I19-0 = ((Skill s) => Loader.getSkillById(s._nID))) : Inventaire._Closure$__.$I19-0).ToList<SkillDescription>();
										CS$<>8__locals4.$VB$Local_skill = source.FirstOrDefault((SkillDescription s) => !Information.IsNothing(s) && !Information.IsNothing(s.item) && (double)s.item.id == Conversions.ToDouble(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Me._LObjets[CS$<>8__locals2.$VB$Local_i].idObjet) && !Information.IsNothing(s.job));
										if (!Information.IsNothing(CS$<>8__locals4.$VB$Local_skill))
										{
											Job job = comtpesByIndex.Jobs.Jobs.FirstOrDefault((Job j) => j.id == Loader.getSkillById(CS$<>8__locals4.$VB$Local_skill.id).job.id);
											if (!job.recolteds.ContainsKey(this._LObjets[CS$<>8__locals2.$VB$Local_i].nomObjet))
											{
												job.recolteds.Add(this._LObjets[CS$<>8__locals2.$VB$Local_i].nomObjet, 0);
											}
											Dictionary<string, int> recolteds;
											string nomObjet;
											(recolteds = job.recolteds)[nomObjet = this._LObjets[CS$<>8__locals2.$VB$Local_i].nomObjet] = (int)(unchecked((long)recolteds[nomObjet]) + this._LObjets[CS$<>8__locals2.$VB$Local_i].numObjet);
										}
									}
								}
								CS$<>8__locals2.$VB$Local_i++;
							}
							return;
						}
					}
					if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 2), "OR", false) == 0)
					{
						Inventaire._Closure$__19-3 CS$<>8__locals5 = new Inventaire._Closure$__19-3(CS$<>8__locals5);
						CS$<>8__locals5.$VB$Local_obj = this._LObjets.FirstOrDefault((Objets o) => (double)o.idObjetInv == Conversions.ToDouble(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 3)));
						if (CS$<>8__locals5.$VB$Local_obj.isFami)
						{
							Famillier famillier = comtpesByIndex.familiers.FirstOrDefault((Famillier f) => f.Fami.idObjetInv == CS$<>8__locals5.$VB$Local_obj.idObjetInv);
							if (famillier != null)
							{
								comtpesByIndex.familiers.Remove(famillier);
							}
						}
						this._LObjets.Remove(CS$<>8__locals5.$VB$Local_obj);
					}
					else if (Operators.CompareString(Strings.Mid(CS$<>8__locals1.$VB$Local_packet, 1, 2), "OM", false) == 0)
					{
						this.OnItemSet(CS$<>8__locals1.$VB$Local_packet);
					}
				}
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00025684 File Offset: 0x00023884
		public void EquipeItem(int ItemId, int time)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				IEnumerable<Objets> source = from o in this._LObjets
				where Conversions.ToDouble(o.idObjet) == (double)ItemId
				select o;
				if (source.FirstOrDefault((Inventaire._Closure$__.$I20-1 == null) ? (Inventaire._Closure$__.$I20-1 = ((Objets o) => o.position != -1)) : Inventaire._Closure$__.$I20-1) == null)
				{
					Objets objets = source.FirstOrDefault<Objets>();
					if (objets != null)
					{
						ObjetDescription itemById = Loader.getItemById(Conversions.ToInteger(objets.idObjet));
						if (itemById.BylGuuBmZi())
						{
							this.MoveItem(objets, 2, time);
						}
						if (itemById.method_4())
						{
							this.MoveItem(objets, 0, time);
						}
						if (itemById.method_5())
						{
							this.MoveItem(objets, 1, time);
						}
						if (itemById.method_2())
						{
							this.MoveItem(objets, 5, time);
						}
						if (!itemById.method_7())
						{
						}
						if (itemById.method_0())
						{
							this.MoveItem(objets, 7, time);
						}
						if (itemById.method_1())
						{
							this.MoveItem(objets, 6, time);
						}
						if (itemById.method_6())
						{
							this.MoveItem(objets, 8, time);
						}
						if (itemById.method_3())
						{
							this.MoveItem(objets, 3, time);
						}
						AutoLaunch launcher = Declarations.getComtpesByIndex(this.Index).launcher;
						ref int ptr = ref launcher.waitAction;
						launcher.waitAction = checked(ptr + (time + 20));
					}
				}
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00025810 File Offset: 0x00023A10
		public bool checkObjetTodelete()
		{
			bool result = false;
			checked
			{
				if ((DateTime.Now - this.dateTime_0).TotalSeconds > 10.0)
				{
					this.dateTime_0 = DateTime.Now;
					try
					{
						foreach (Objets objets in this.getObjects())
						{
							if (Declarations.getComtpesByIndex(this.Index).config.listItemToDelete.Contains(Conversions.ToInteger(objets.idObjet)))
							{
								this.DetruireItem(objets.idObjetInv, (int)objets.numObjet);
								result = true;
							}
							if (objets.nomObjet.ToLower().Contains("sac ") && Loader.getItemById(Conversions.ToInteger(objets.idObjet)).usable)
							{
								Declarations.getComtpesByIndex(this.Index).useItem((int)objets.idObjetInv, (int)objets.numObjet);
								result = true;
							}
						}
					}
					finally
					{
						List<Objets>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				return result;
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00025928 File Offset: 0x00023B28
		public void DetruireItem(long itemUI, int qty)
		{
			Declarations.getComtpesByIndex(this.Index).Send(new Message("Od" + Conversions.ToString(itemUI) + "|" + Conversions.ToString(qty), 0, false, true, true));
			Declarations.getComtpesByIndex(this.Index).Send(new Message("BD", 0, false, true, true));
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00025988 File Offset: 0x00023B88
		public bool EquipeJobItem(int JobId)
		{
			object obj = this.lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Objets objets;
			lock (obj)
			{
				if (JobId <= 28)
				{
					if (JobId == 2)
					{
						objets = this._LObjets.FirstOrDefault((Inventaire._Closure$__.$I24-3 == null) ? (Inventaire._Closure$__.$I24-3 = ((Objets i) => Loader.getItemById(Conversions.ToInteger(i.idObjet)).isBucheronItem())) : Inventaire._Closure$__.$I24-3);
						goto IL_15F;
					}
					switch (JobId)
					{
					case 24:
						objets = this._LObjets.FirstOrDefault((Inventaire._Closure$__.$I24-2 == null) ? (Inventaire._Closure$__.$I24-2 = ((Objets i) => Loader.getItemById(Conversions.ToInteger(i.idObjet)).isMineurItem())) : Inventaire._Closure$__.$I24-2);
						goto IL_15F;
					case 26:
						objets = this._LObjets.FirstOrDefault((Inventaire._Closure$__.$I24-4 == null) ? (Inventaire._Closure$__.$I24-4 = ((Objets i) => Loader.getItemById(Conversions.ToInteger(i.idObjet)).isAlchimisteItem())) : Inventaire._Closure$__.$I24-4);
						goto IL_15F;
					case 28:
						goto IL_FD;
					}
				}
				else
				{
					if (JobId == 36)
					{
						objets = this._LObjets.FirstOrDefault((Inventaire._Closure$__.$I24-1 == null) ? (Inventaire._Closure$__.$I24-1 = ((Objets i) => Loader.getItemById(Conversions.ToInteger(i.idObjet)).isPecheurItem())) : Inventaire._Closure$__.$I24-1);
						goto IL_15F;
					}
					if (JobId == 70 || JobId == 71)
					{
						goto IL_FD;
					}
				}
				return true;
				IL_FD:
				objets = this._LObjets.FirstOrDefault((Inventaire._Closure$__.$I24-0 == null) ? (Inventaire._Closure$__.$I24-0 = ((Objets i) => Loader.getItemById(Conversions.ToInteger(i.idObjet)).isPaysanItem())) : Inventaire._Closure$__.$I24-0);
				IL_15F:;
			}
			bool result;
			if (objets == null)
			{
				result = false;
			}
			else if (objets.position == 1)
			{
				result = true;
			}
			else
			{
				this.MoveItem(objets, 1, 0);
				result = true;
			}
			return result;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00025B48 File Offset: 0x00023D48
		public void MoveItem(Objets item, int pos, int Time = 0)
		{
			Objets objets = this._LObjets.FirstOrDefault((Objets i) => i.position == pos);
			if (objets != null)
			{
				Declarations.getComtpesByIndex(this.Index).Send(new Message("OM" + Conversions.ToString(objets.idObjetInv) + "|-1", Time, true, true, true));
				objets.position = -1;
			}
			Declarations.getComtpesByIndex(this.Index).Send(new Message("OM" + Conversions.ToString(item.idObjetInv) + "|" + Conversions.ToString(pos), Time, true, true, true));
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00025BF8 File Offset: 0x00023DF8
		internal int method_0(Perso perso_0, KeyValuePair<List<ObjetDescription>, List<int>> keyValuePair_0)
		{
			int result;
			if (keyValuePair_0.Key == null)
			{
				result = 0;
			}
			else
			{
				int num = 1000;
				int index = 0;
				try
				{
					foreach (ObjetDescription objetDescription in keyValuePair_0.Key)
					{
						Objets objectById = this.getObjectById(objetDescription.id);
						if (objectById == null)
						{
							return 0;
						}
						int num2 = checked((int)Math.Round(Math.Floor((double)objectById.numObjet / (double)keyValuePair_0.Value.ElementAt(index))));
						if (num > num2)
						{
							num = num2;
						}
					}
				}
				finally
				{
					List<ObjetDescription>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				result = num;
			}
			return result;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x00025CAC File Offset: 0x00023EAC
		public long hashCode
		{
			get
			{
				double a = this._LObjets.Sum((Inventaire._Closure$__.$I28-0 == null) ? (Inventaire._Closure$__.$I28-0 = ((Objets o) => Conversions.ToDouble(o.idObjet) + (double)o.numObjet + (double)o.effects.Count)) : Inventaire._Closure$__.$I28-0);
				return checked((long)Math.Round(a));
			}
		}

		// Token: 0x0400051E RID: 1310
		public List<Objets> _LObjets;

		// Token: 0x0400051F RID: 1311
		public int podsactual;

		// Token: 0x04000520 RID: 1312
		public int podsMax;

		// Token: 0x04000521 RID: 1313
		public int Index;

		// Token: 0x04000522 RID: 1314
		private bool bool_0;

		// Token: 0x04000523 RID: 1315
		public object lockObject;

		// Token: 0x04000524 RID: 1316
		private DateTime dateTime_0;
	}
}
