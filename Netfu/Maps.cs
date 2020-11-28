using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000072 RID: 114
	public class Maps : IDisposable
	{
		// Token: 0x06000252 RID: 594 RVA: 0x000035A2 File Offset: 0x000017A2
		static Maps()
		{
			Class15.XRATSHnz66atd();
			Maps.random_0 = new Random();
			Maps.object_3 = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000133E0 File Offset: 0x000115E0
		public Dictionary<int, byte> los
		{
			get
			{
				return this.mapDataActuel.ToDictionary((Maps._Closure$__.$I9-0 == null) ? (Maps._Closure$__.$I9-0 = ((Cell c) => c.Id)) : Maps._Closure$__.$I9-0, (Maps._Closure$__.$I9-1 == null) ? (Maps._Closure$__.$I9-1 = ((Cell c) => c.los)) : Maps._Closure$__.$I9-1);
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00013444 File Offset: 0x00011644
		public void addActor(Actors a)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_5.Add(a);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00013490 File Offset: 0x00011690
		public object ActorCount()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			object result;
			lock (obj)
			{
				result = this.list_5.Count;
			}
			return result;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000134E4 File Offset: 0x000116E4
		public int hashCode
		{
			get
			{
				int result;
				try
				{
					result = checked(this.Characters.Sum((Maps._Closure$__.$I33-0 == null) ? (Maps._Closure$__.$I33-0 = ((KeyValuePair<int, Character> a) => a.Key)) : Maps._Closure$__.$I33-0) + this.MonstersGroups.Sum((Maps._Closure$__.$I33-1 == null) ? (Maps._Closure$__.$I33-1 = ((KeyValuePair<int, MonsterGroupe> a) => a.Key)) : Maps._Closure$__.$I33-1) + this.Npcs.Sum((Maps._Closure$__.$I33-2 == null) ? (Maps._Closure$__.$I33-2 = ((KeyValuePair<int, NPC> a) => a.Key)) : Maps._Closure$__.$I33-2) + this.id + this.patchedCells.Values.Sum());
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
				return result;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000257 RID: 599 RVA: 0x000135C4 File Offset: 0x000117C4
		public List<KeyValuePair<int, Character>> Characters
		{
			get
			{
				List<KeyValuePair<int, Character>> result;
				try
				{
					object obj = this.object_0;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						result = this.list_5.Where((Maps._Closure$__.$I35-0 == null) ? (Maps._Closure$__.$I35-0 = ((Actors a) => a is Character)) : Maps._Closure$__.$I35-0).Select((Maps._Closure$__.$I35-1 == null) ? (Maps._Closure$__.$I35-1 = delegate(Actors a)
						{
							KeyValuePair<int, Character> result2 = new KeyValuePair<int, Character>(a.Cell, (Character)a);
							return result2;
						}) : Maps._Closure$__.$I35-1).ToList<KeyValuePair<int, Character>>();
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
					result = new List<KeyValuePair<int, Character>>();
				}
				return result;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0001368C File Offset: 0x0001188C
		public bool hasPresence
		{
			get
			{
				bool result;
				try
				{
					List<KeyValuePair<int, Character>> characters = this.Characters;
					try
					{
						foreach (KeyValuePair<int, Character> keyValuePair in characters)
						{
							if ((double)keyValuePair.Value.Id != Conversions.ToDouble(this.bot().monIdDofus))
							{
								List<int> list = this.bot().get_Slave(false);
								if (!list.Contains(keyValuePair.Value.Id))
								{
									return true;
								}
							}
						}
					}
					finally
					{
						List<KeyValuePair<int, Character>>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = false;
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00013750 File Offset: 0x00011950
		public List<KeyValuePair<int, NPC>> Npcs
		{
			get
			{
				object obj = this.object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				List<KeyValuePair<int, NPC>> result;
				lock (obj)
				{
					try
					{
						object obj2 = this.object_0;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
						lock (obj2)
						{
							result = this.list_5.Where((Maps._Closure$__.$I39-0 == null) ? (Maps._Closure$__.$I39-0 = ((Actors a) => a is NPC)) : Maps._Closure$__.$I39-0).Select((Maps._Closure$__.$I39-1 == null) ? (Maps._Closure$__.$I39-1 = delegate(Actors a)
							{
								KeyValuePair<int, NPC> result2 = new KeyValuePair<int, NPC>(a.Cell, (NPC)a);
								return result2;
							}) : Maps._Closure$__.$I39-1).ToList<KeyValuePair<int, NPC>>();
						}
					}
					catch (Exception e)
					{
						Fonctions.traiterErreur(e);
						result = new List<KeyValuePair<int, NPC>>();
					}
				}
				return result;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00013848 File Offset: 0x00011A48
		public List<KeyValuePair<int, MonsterGroupe>> MonstersGroups
		{
			get
			{
				object obj = this.object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				List<KeyValuePair<int, MonsterGroupe>> result;
				lock (obj)
				{
					try
					{
						object obj2 = this.object_0;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
						lock (obj2)
						{
							result = this.list_5.Where((Maps._Closure$__.$I41-0 == null) ? (Maps._Closure$__.$I41-0 = ((Actors a) => a is MonsterGroupe)) : Maps._Closure$__.$I41-0).Select((Maps._Closure$__.$I41-1 == null) ? (Maps._Closure$__.$I41-1 = delegate(Actors a)
							{
								KeyValuePair<int, MonsterGroupe> result2 = new KeyValuePair<int, MonsterGroupe>(a.Cell, (MonsterGroupe)a);
								return result2;
							}) : Maps._Closure$__.$I41-1).ToList<KeyValuePair<int, MonsterGroupe>>();
						}
					}
					catch (Exception e)
					{
						Fonctions.traiterErreur(e);
						result = new List<KeyValuePair<int, MonsterGroupe>>();
					}
				}
				return result;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00013940 File Offset: 0x00011B40
		public List<KeyValuePair<int, Ressources>> Ressources
		{
			get
			{
				object obj = this.object_1;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				List<KeyValuePair<int, Ressources>> result;
				lock (obj)
				{
					try
					{
						result = this.list_4.Select((Maps._Closure$__.$I43-0 == null) ? (Maps._Closure$__.$I43-0 = delegate(Ressources a)
						{
							KeyValuePair<int, Ressources> result2 = new KeyValuePair<int, Ressources>(a.Cellid, a);
							return result2;
						}) : Maps._Closure$__.$I43-0).ToList<KeyValuePair<int, Ressources>>();
					}
					catch (Exception e)
					{
						Fonctions.traiterErreur(e);
						result = new List<KeyValuePair<int, Ressources>>();
					}
				}
				return result;
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000139DC File Offset: 0x00011BDC
		public void addRessource(Ressources r)
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				if (!this.patchedCells.ContainsKey(r.Cellid) || this.patchedCells[r.Cellid] != 3)
				{
					this.list_4.Add(r);
				}
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00013A58 File Offset: 0x00011C58
		public void delRessourceByCellid(int cellid)
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_4.RemoveAll((Ressources r) => r.Cellid == cellid);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00013AC0 File Offset: 0x00011CC0
		public IEnumerable<Ressources> GetUsableRessource(bool onlyRecolte = true)
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			IEnumerable<Ressources> result;
			lock (obj)
			{
				List<Ressources> list = this.list_4.Where((Maps._Closure$__.$I46-0 == null) ? (Maps._Closure$__.$I46-0 = ((Ressources io) => Operators.CompareString(io.stat, "Non coupé", false) == 0)) : Maps._Closure$__.$I46-0).ToList<Ressources>();
				List<Ressources> list2 = new List<Ressources>();
				if (!onlyRecolte)
				{
					result = list;
				}
				else
				{
					try
					{
						foreach (Ressources ressources in list)
						{
							try
							{
								foreach (SkillDescription skillDescription in Loader.smethod_10(ressources.id).Skills)
								{
									if (this.bot().config.listRessourcesRecolt.Contains(skillDescription.id))
									{
										list2.Add(ressources);
									}
								}
							}
							finally
							{
								List<SkillDescription>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					finally
					{
						List<Ressources>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = list2;
				}
			}
			return result;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00013BF8 File Offset: 0x00011DF8
		public Ressources getRessourceById(int id)
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Ressources result;
			lock (obj)
			{
				result = this.list_4.FirstOrDefault((Ressources r) => r.id == id);
			}
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00013C60 File Offset: 0x00011E60
		public Ressources getRessourceByCellId(int Cellid)
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Ressources result;
			lock (obj)
			{
				result = this.list_4.FirstOrDefault((Ressources r) => r.Cellid == Cellid);
			}
			return result;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00013CC8 File Offset: 0x00011EC8
		public void RemoveActorById(int id)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_5.RemoveAll((Actors a) => a.Id == id);
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00013D30 File Offset: 0x00011F30
		public void RemoveActor(Actors a)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_5.Remove(a);
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00013D80 File Offset: 0x00011F80
		public bool refresh()
		{
			bool result;
			if (this.int_0 > 5)
			{
				result = true;
			}
			else
			{
				Perso perso = this.bot();
				if (perso.status.currentAction == 0 && perso.status.Int32_0 == -1)
				{
					ref int ptr = ref this.int_0;
					this.int_0 = checked(ptr + 1);
					this.bot().Send(new Message("GI", 0, true, false, true));
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public Actors getActorsCell(int id, bool monsteronly)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Actors result;
			lock (obj)
			{
				Actors actors = this.list_5.FirstOrDefault((Actors a) => a.Cell == id && (!monsteronly || a is MonsterGroupe));
				result = actors;
			}
			return result;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00013E64 File Offset: 0x00012064
		internal int method_0()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			int result;
			lock (obj)
			{
				result = this.list_5.Where((Maps._Closure$__.$I53-0 == null) ? (Maps._Closure$__.$I53-0 = ((Actors a) => a is Merchant)) : Maps._Closure$__.$I53-0).Count<Actors>();
			}
			return result;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00013EDC File Offset: 0x000120DC
		public Actors getActorsById(int id)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Actors result;
			lock (obj)
			{
				result = this.list_5.FirstOrDefault((Actors a) => a.Id == id);
			}
			return result;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00013F44 File Offset: 0x00012144
		public int changeurBas()
		{
			int result;
			if (this.list_0.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = this.list_0[Maps.random_0.Next(0, this.list_0.Count)];
			}
			return result;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00013F88 File Offset: 0x00012188
		public int changeurHaut()
		{
			int result;
			if (this.list_1.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = this.list_1[Maps.random_0.Next(0, this.list_1.Count)];
			}
			return result;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00013FCC File Offset: 0x000121CC
		public int changeurGauche()
		{
			int result;
			if (this.list_3.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = this.list_3[Maps.random_0.Next(0, this.list_3.Count)];
			}
			return result;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00014010 File Offset: 0x00012210
		public int changeurDroite()
		{
			int result;
			if (this.list_2.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = this.list_2[Maps.random_0.Next(0, this.list_2.Count)];
			}
			return result;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00014054 File Offset: 0x00012254
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00014070 File Offset: 0x00012270
		public short subarea()
		{
			return Loader.getMapById(this.id).subarea;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00014090 File Offset: 0x00012290
		public void setEnclo(string d)
		{
			Ressources ressourceById = this.bot().map.getRessourceById(120);
			this.paddock = new Enclo(this.index, ressourceById.Cellid);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000140C8 File Offset: 0x000122C8
		public List<Actors> getActorsCopy()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Actors> result;
			lock (obj)
			{
				result = this.list_5.ToList<Actors>();
			}
			return result;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00014118 File Offset: 0x00012318
		public List<Ressources> getRessourceCopy()
		{
			object obj = this.object_1;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Ressources> result;
			lock (obj)
			{
				result = this.list_4.ToList<Ressources>();
			}
			return result;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00014168 File Offset: 0x00012368
		public Character myActor()
		{
			Actors actorsById = this.getActorsById(Conversions.ToInteger(this.bot().monIdDofus));
			return (Character)actorsById;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00014194 File Offset: 0x00012394
		public Point position
		{
			get
			{
				return Loader.getMapById(this.id).point;
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000141B4 File Offset: 0x000123B4
		internal void method_1(int int_1, int int_2)
		{
			try
			{
				if (this.bot().status.enCombat())
				{
					this.bot().Fight.getFighterByid(int_1).cellId = int_2;
				}
				else
				{
					Actors actorsById = this.getActorsById(int_1);
					if (!Information.IsNothing(actorsById))
					{
						actorsById.Cell = int_2;
						if ((double)actorsById.Id == Conversions.ToDouble(this.bot().monIdDofus))
						{
							this.bot().movement.lastActorCell = actorsById.Cell;
						}
						if (actorsById.Id == this.bot().idChef)
						{
							Perso perso = Declarations.get_MyChef(this.index);
							if (((!Information.IsNothing(perso) && Operators.CompareString(perso.movement.destAction, "", false) == 0) || Information.IsNothing(perso) || perso.status.connexion == status.ConnexionStatus.const_0) && perso != null)
							{
								this.bot().movement.SeDeplacer(actorsById.Cell, -1);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000142E4 File Offset: 0x000124E4
		public List<MonsterGroupe> monsters(Predicate<MonsterGroupe> cond, string Order = "aucun")
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<MonsterGroupe> result;
			lock (obj)
			{
				try
				{
					List<MonsterGroupe> list = this.list_5.Where((Maps._Closure$__.$I69-0 == null) ? (Maps._Closure$__.$I69-0 = ((Actors a) => a is MonsterGroupe)) : Maps._Closure$__.$I69-0).Select((Maps._Closure$__.$I69-1 == null) ? (Maps._Closure$__.$I69-1 = ((Actors b) => (MonsterGroupe)b)) : Maps._Closure$__.$I69-1).ToList<MonsterGroupe>();
					if (Operators.CompareString(Order, "aucun", false) != 0)
					{
						if (Operators.CompareString(Order, "haut", false) == 0)
						{
							list = list.OrderByDescending((Maps._Closure$__.$I69-2 == null) ? (Maps._Closure$__.$I69-2 = ((MonsterGroupe m) => m.levels.Sum())) : Maps._Closure$__.$I69-2).ToList<MonsterGroupe>();
						}
						else
						{
							list = list.OrderBy((Maps._Closure$__.$I69-3 == null) ? (Maps._Closure$__.$I69-3 = ((MonsterGroupe m) => m.levels.Sum())) : Maps._Closure$__.$I69-3).ToList<MonsterGroupe>();
						}
					}
					if (Information.IsNothing(cond))
					{
						result = list;
					}
					else
					{
						result = (from m in list
						where cond(m)
						select m).ToList<MonsterGroupe>();
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
					result = new List<MonsterGroupe>();
				}
			}
			return result;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00014484 File Offset: 0x00012684
		public void LoadRessources()
		{
			int num = 0;
			checked
			{
				int num2 = this.mapDataActuel.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					IODescription iobyLayerId = Loader.getIOByLayerId(this.mapDataActuel[i].layerObject2Num);
					if (iobyLayerId != null)
					{
						Ressources r = new Ressources(iobyLayerId.Id, Conversions.ToInteger(i.ToString()), "Non coupé", iobyLayerId.nom);
						if (!Information.IsNothing(iobyLayerId))
						{
							this.addRessource(r);
							this.mapDataActuel[i].object2Movement = (iobyLayerId.Skills.FirstOrDefault((Maps._Closure$__.$I70-0 == null) ? (Maps._Closure$__.$I70-0 = ((SkillDescription d) => d != null && (Operators.CompareString(d.nom, "Couper", false) == 0 || Operators.CompareString(d.nom, "Puiser", false) == 0))) : Maps._Closure$__.$I70-0) != null);
							this.mapDataActuel[i].object2Movement = (this.mapDataActuel[i].object2Movement || new string[]
							{
								"Zaapi",
								"Zaap",
								"Statue de classe",
								"Coffre",
								"Porte"
							}.Contains(iobyLayerId.nom));
							num++;
						}
					}
				}
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000145B4 File Offset: 0x000127B4
		public Maps(int index, string id, string indice, string clef)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<int>();
			this.list_1 = new List<int>();
			this.list_2 = new List<int>();
			this.list_3 = new List<int>();
			this.int_0 = 0;
			this.list_4 = new List<Ressources>();
			this.list_5 = new List<Actors>();
			this.width = 15;
			this.height = 17;
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.object_1 = RuntimeHelpers.GetObjectValue(new object());
			this.loaded = false;
			this.patchedCells = new Dictionary<int, int>();
			this.Changeurs = new List<int>();
			this.object_2 = 0;
			this.index = index;
			checked
			{
				try
				{
					this.id = Conversions.ToInteger(id);
					this.width = this.width;
					this.height = this.height;
					this.clef = clef;
					this.index = index;
					Declarations.getComtpesByIndex(index).Debug("Loading map " + id);
					string text = string.Concat(new string[]
					{
						Application.StartupPath,
						"/maps/",
						id,
						"_",
						indice,
						"X.txt"
					});
					this.fileName = id + "_" + indice + "X.txt";
					object obj = Maps.object_3;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					string text2;
					lock (obj)
					{
						if (!File.Exists(text))
						{
							this.fileName = id + "_" + indice + ".txt";
							text = string.Concat(new string[]
							{
								Application.StartupPath,
								"/maps/",
								id,
								"_",
								indice,
								".txt"
							});
						}
						StreamReader streamReader = new StreamReader(text);
						text2 = streamReader.ReadLine();
						streamReader.Close();
						text = text.Replace("maps", "patchedMaps");
						if (File.Exists(text))
						{
							streamReader = new StreamReader(text);
							string text3 = streamReader.ReadToEnd();
							streamReader.Close();
							foreach (string text4 in text3.Split(new char[]
							{
								'\r'
							}))
							{
								string[] array2 = text4.Split(new char[]
								{
									':'
								});
								if (array2.Length > 1)
								{
									this.patchedCells.Add(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]));
								}
							}
						}
					}
					string[] array3 = text2.Split(new char[]
					{
						'|'
					});
					if (array3.Count<string>() > 2)
					{
						this.width = Conversions.ToByte(array3[2]);
						this.height = Conversions.ToByte(array3[3]);
					}
					text2 = array3[1];
					string text5 = Conversions.ToString(Fonctions.prepareKey(clef));
					string sData = Conversions.ToString(Fonctions.decypherData(text2, text5, (int)(Convert.ToInt64(Conversions.ToString(Fonctions.checksum(text5)), 16) * 2L)));
					this.mapDataActuel = Maphandler.uncompressMap(sData, this);
					this.mapActuelle = id;
					int num = this.mapDataActuel.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						if (this.mapDataActuel[j].IsChangeur)
						{
							int x = this.mapDataActuel[j].X;
							int num2 = this.mapDataActuel[j].Y;
							if (x - 1 == num2 || x - 2 == num2)
							{
								this.list_3.Add(j);
							}
							else if (x - (int)(unchecked(this.width + this.height) - 5) == num2 || x - (int)(unchecked(this.width + this.height) - 5) == num2 - 1)
							{
								this.list_2.Add(j);
							}
							else if (num2 + x > (int)(unchecked(this.width + this.height) - 5))
							{
								this.list_0.Add(j);
							}
							else if (num2 < 0)
							{
								num2 = Math.Abs(num2);
								if (x - num2 < 5)
								{
									this.list_1.Add(j);
								}
							}
							if (this.mapDataActuel[j].IsChangeur)
							{
								this.Changeurs.Add(j);
							}
						}
					}
					this.LoadRessources();
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00014A58 File Offset: 0x00012C58
		public bool AllSlavesInMap()
		{
			bool flag = true;
			try
			{
				foreach (int num in this.bot().get_Slave(true))
				{
					Perso comtpesById = Declarations.getComtpesById(num);
					if (comtpesById == null)
					{
						return false;
					}
					if (!comtpesById.status.isIdle())
					{
						return false;
					}
					if ((comtpesById.map == null || comtpesById.map.id != this.bot().map.id) && !this.bot().status.IsIgnoreGroup())
					{
						if (!comtpesById.status.IsIgnoreGroup() && !this.bot().status.IsIgnoreGroup())
						{
							MapNeighbour direction = MapNeighbour.Top;
							Point position = this.bot().map.position;
							Maps map = comtpesById.map;
							if (position.X > map.position.X && map.changeurDroite() != -1)
							{
								direction = MapNeighbour.Right;
							}
							if (position.X < map.position.X && map.changeurGauche() != -1)
							{
								direction = MapNeighbour.Left;
							}
							if (position.Y > map.position.Y && map.changeurBas() != -1)
							{
								direction = MapNeighbour.Bottom;
							}
							if (position.Y < map.position.Y && map.changeurHaut() != -1)
							{
								direction = MapNeighbour.Top;
							}
							comtpesById.movement.MoveMapDirection(direction, false, null);
						}
						flag = false;
					}
				}
			}
			finally
			{
				List<int>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (!flag)
			{
				this.bot().launcher.waitAction = 1500;
			}
			return flag;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00014C60 File Offset: 0x00012E60
		protected virtual void Dispose(bool disposing)
		{
			if (!this.bool_0 && disposing)
			{
				this.list_0.Clear();
				this.list_2.Clear();
				this.list_3.Clear();
				this.list_1.Clear();
				this.list_4.Clear();
				this.mapDataActuel.Clear();
				this.list_5.Clear();
				this.list_0 = null;
				this.list_2 = null;
				this.list_3 = null;
				this.list_1 = null;
				this.list_4 = null;
				this.list_5 = null;
				this.mapDescription_2 = null;
				this.mapDescription_1 = null;
				this.mapDescription_3 = null;
				this.mapDescription_2 = null;
				this.mapDataActuel = null;
				this.mapActuelle = null;
				this.clef = null;
				this.width = 0;
				this.height = 0;
				this.object_0 = null;
				this.object_1 = null;
			}
			this.bool_0 = true;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000035C2 File Offset: 0x000017C2
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x040002FE RID: 766
		private List<int> list_0;

		// Token: 0x040002FF RID: 767
		private List<int> list_1;

		// Token: 0x04000300 RID: 768
		private List<int> list_2;

		// Token: 0x04000301 RID: 769
		private List<int> list_3;

		// Token: 0x04000302 RID: 770
		private int int_0;

		// Token: 0x04000303 RID: 771
		public string mapActuelle;

		// Token: 0x04000304 RID: 772
		public List<Cell> mapDataActuel;

		// Token: 0x04000305 RID: 773
		private List<Ressources> list_4;

		// Token: 0x04000306 RID: 774
		public int id;

		// Token: 0x04000307 RID: 775
		public int indice;

		// Token: 0x04000308 RID: 776
		public string clef;

		// Token: 0x04000309 RID: 777
		private List<Actors> list_5;

		// Token: 0x0400030A RID: 778
		public int index;

		// Token: 0x0400030B RID: 779
		public byte width;

		// Token: 0x0400030C RID: 780
		public byte height;

		// Token: 0x0400030D RID: 781
		private MapDescription mapDescription_0;

		// Token: 0x0400030E RID: 782
		private MapDescription mapDescription_1;

		// Token: 0x0400030F RID: 783
		private MapDescription mapDescription_2;

		// Token: 0x04000310 RID: 784
		private MapDescription mapDescription_3;

		// Token: 0x04000311 RID: 785
		private static Random random_0;

		// Token: 0x04000312 RID: 786
		private object object_0;

		// Token: 0x04000313 RID: 787
		private object object_1;

		// Token: 0x04000314 RID: 788
		public Enclo paddock;

		// Token: 0x04000315 RID: 789
		public bool loaded;

		// Token: 0x04000316 RID: 790
		public Dictionary<int, int> patchedCells;

		// Token: 0x04000317 RID: 791
		public string fileName;

		// Token: 0x04000318 RID: 792
		public List<int> Changeurs;

		// Token: 0x04000319 RID: 793
		private object object_2;

		// Token: 0x0400031A RID: 794
		private static object object_3;

		// Token: 0x0400031B RID: 795
		private bool bool_0;
	}
}
