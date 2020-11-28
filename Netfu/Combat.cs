using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000080 RID: 128
	public class Combat
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x000037A6 File Offset: 0x000019A6
		static Combat()
		{
			Class15.XRATSHnz66atd();
			Combat.random_0 = new Random();
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00016098 File Offset: 0x00014298
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000160B4 File Offset: 0x000142B4
		public Combat()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<Fighter>();
			this.position = new List<int>[3];
			this.nbTour = 0;
			this.Start = true;
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00016104 File Offset: 0x00014304
		public Combat(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<Fighter>();
			this.position = new List<int>[3];
			this.nbTour = 0;
			this.Start = true;
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.index = index;
			this.bot().map.loaded = false;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0001616C File Offset: 0x0001436C
		public Fighter getFighterByid(int id)
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Fighter result;
			lock (obj)
			{
				result = this.list_0.FirstOrDefault((Fighter f) => f.id == id);
			}
			return result;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000161DC File Offset: 0x000143DC
		public void AddFighter(Fighter f)
		{
			if (!(f.dead | f.cellId == -1))
			{
				object obj = this.bot().Fight.object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					this.list_0.Add(f);
				}
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00016244 File Offset: 0x00014444
		public void delFighter(int index)
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_0.RemoveAt(index);
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0001629C File Offset: 0x0001449C
		public void delFighterById(int id)
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_0.RemoveAll((Fighter f) => f.id == id);
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0001630C File Offset: 0x0001450C
		public void delFighter(Fighter Fighter)
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_0.Remove(Fighter);
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00016364 File Offset: 0x00014564
		public int FighterCount()
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			int count;
			lock (obj)
			{
				count = this.list_0.Count;
			}
			return count;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000163BC File Offset: 0x000145BC
		public int FighterCountAlive()
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			int result;
			lock (obj)
			{
				result = this.list_0.Where((Combat._Closure$__.$I22-0 == null) ? (Combat._Closure$__.$I22-0 = ((Fighter f) => !f.dead)) : Combat._Closure$__.$I22-0).Count<Fighter>();
			}
			return result;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0001643C File Offset: 0x0001463C
		public int FighterEnemieAlive()
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			int result;
			lock (obj)
			{
				if (this.myFighter() != null)
				{
					result = (from f in this.list_0
					where f.team != this.myFighter().team && !f.dead
					select f).Count<Fighter>();
				}
				else
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000164B4 File Offset: 0x000146B4
		public double getEnemieLifePercent()
		{
			object obj = this.bot().Fight.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			double result;
			lock (obj)
			{
				if (this.myFighter() != null)
				{
					double num = 0.0;
					bool flag2 = true;
					try
					{
						foreach (Fighter fighter in from f in this.list_0
						where f.team != this.myFighter().team && !f.dead
						select f)
						{
							num += 1.0 - (double)fighter.LP / (double)fighter.LPmax;
							flag2 = false;
						}
					}
					finally
					{
						IEnumerator<Fighter> enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					if (flag2)
					{
						result = 1.0;
					}
					else
					{
						result = num / this.double_0;
					}
				}
				else
				{
					result = 1.0;
				}
			}
			return result;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000165B0 File Offset: 0x000147B0
		internal IEnumerable<Fighter> method_0()
		{
			Fighter myfih = this.myFighter();
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			IEnumerable<Fighter> result;
			lock (obj)
			{
				List<Fighter> list = (from fi in this.list_0.OrderBy((Combat._Closure$__.$I25-0 == null) ? (Combat._Closure$__.$I25-0 = ((Fighter f) => f.LP)) : Combat._Closure$__.$I25-0)
				orderby this.bot().map.mapDataActuel[myfih.cellId].ManhattanDistanceTo(this.bot().map.mapDataActuel[fi.cellId])
				select fi).Where((Combat._Closure$__.$I25-2 == null) ? (Combat._Closure$__.$I25-2 = ((Fighter fi) => !fi.dead && !fi.invisible)) : Combat._Closure$__.$I25-2).ToList<Fighter>();
				list = list.OrderBy((Combat._Closure$__.$I25-3 == null) ? (Combat._Closure$__.$I25-3 = ((Fighter f) => f.isInvoc)) : Combat._Closure$__.$I25-3).ToList<Fighter>();
				result = list;
			}
			return result;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000037B7 File Offset: 0x000019B7
		private void method_1()
		{
			this.double_0 = (double)this.FighterEnemieAlive();
			if (this.bot().get_Slave(true).Count == 0)
			{
				this.ready(true);
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000037E3 File Offset: 0x000019E3
		private void method_2()
		{
			new Random();
			if (this.bot().config.BloqueGroupe)
			{
				this.closeGroup(0);
			}
			if (this.bot().config.BloqueSpectateur)
			{
				this.closeSpect(0);
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000381D File Offset: 0x00001A1D
		public void turnEnd()
		{
			if (this.myturn)
			{
				this.myturn = false;
				this.bot().Send(new Message("Gt", 300, false, true, true));
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000166B0 File Offset: 0x000148B0
		internal List<Fighter> method_3()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			List<Fighter> result;
			lock (obj)
			{
				result = this.list_0.ToList<Fighter>();
			}
			return result;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00016700 File Offset: 0x00014900
		public void closeGroup(int time)
		{
			if (this.bot().get_Slave(true).Count > 0)
			{
				this.bot().Send(new Message("fP", time, true, true, true));
			}
			else if (this.bot().idChef == 0)
			{
				this.bot().Send(new Message("fN", time, true, true, true));
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000384B File Offset: 0x00001A4B
		public void closeSpect(int time)
		{
			if (this.bot().idChef == 0)
			{
				this.bot().Send(new Message("fS", time, true, true, true));
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00016768 File Offset: 0x00014968
		public void ready(bool bReady)
		{
			int num = 210;
			this.bot().Send(new Message("GR" + (bReady ? "1" : "0"), new Random().Next(num, checked(50 + num)), true, true, true));
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000167B8 File Offset: 0x000149B8
		public void AddInvocation(int senderId, string sdata)
		{
			string[] array = sdata.Substring(1).Split(new char[]
			{
				';'
			});
			this.AddFighter(new Fighter
			{
				id = Conversions.ToInteger(array[3]),
				cellId = Conversions.ToInteger(array[0]),
				team = this.getFighterByid(senderId).team,
				PowerLevel = Conversions.ToInteger(array[7]),
				LP = Conversions.ToInteger(array[12]),
				AP = Conversions.ToInteger(array[13]),
				MP = Conversions.ToInteger(array[14]),
				gfxId = Conversions.ToInteger(array[4]),
				ownerId = senderId
			});
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00016868 File Offset: 0x00014A68
		public void OnFighterMove(string data)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			string[] array = data.Substring(3).Split(new char[]
			{
				'|'
			});
			foreach (string text in array)
			{
				try
				{
					if (Operators.CompareString(Conversions.ToString(text[0]), "+", false) == 0)
					{
						string[] array3 = text.Substring(1).Split(new char[]
						{
							';'
						});
						string left = array3[5].Split(new char[]
						{
							','
						})[0];
						Fighter fighter = this.getFighterByid(Conversions.ToInteger(array3[3]));
						if (fighter == null)
						{
							fighter = new Fighter();
						}
						fighter.id = Conversions.ToInteger(array3[3]);
						fighter.cellId = Conversions.ToInteger(array3[0]);
						if (Versioned.IsNumeric(array3[4]))
						{
							fighter.gfxId = Conversions.ToInteger(array3[4]);
						}
						if (Operators.CompareString(left, "-1", false) != 0)
						{
							if (Operators.CompareString(left, "-2", false) != 0)
							{
								if (Operators.CompareString(left, "-6", false) != 0)
								{
									if (Operators.CompareString(left, "-8", false) != 0)
									{
										fighter.PowerLevel = Conversions.ToInteger(array3[8]);
										fighter.LP = Conversions.ToInteger(array3[14]);
										fighter.AP = Conversions.ToInteger(array3[15]);
										fighter.MP = Conversions.ToInteger(array3[16]);
										fighter.resistance = new short[]
										{
											Conversions.ToShort(array3[17]),
											Conversions.ToShort(array3[18]),
											Conversions.ToShort(array3[19]),
											Conversions.ToShort(array3[20]),
											Conversions.ToShort(array3[21]),
											Conversions.ToShort(array3[22]),
											Conversions.ToShort(array3[23])
										};
										fighter.team = Conversions.ToByte(array3[24]);
									}
									else
									{
										fighter.PowerLevel = Conversions.ToInteger(array3[8]);
										fighter.LP = Conversions.ToInteger(array3[10]);
										fighter.AP = Conversions.ToInteger(array3[11]);
										fighter.MP = Conversions.ToInteger(array3[12]);
										fighter.resistance = new short[]
										{
											Conversions.ToShort(array3[11]),
											Conversions.ToShort(array3[12]),
											Conversions.ToShort(array3[13]),
											Conversions.ToShort(array3[14]),
											Conversions.ToShort(array3[15]),
											Conversions.ToShort(array3[16]),
											Conversions.ToShort(array3[17])
										};
										fighter.team = Conversions.ToByte(array3[20]);
									}
								}
								else
								{
									fighter.PowerLevel = Conversions.ToInteger(array3[7]);
									fighter.LP = Conversions.ToInteger(array3[8]);
									fighter.AP = Conversions.ToInteger(array3[9]);
									fighter.MP = Conversions.ToInteger(array3[10]);
									fighter.resistance = new short[]
									{
										Conversions.ToShort(array3[11]),
										Conversions.ToShort(array3[12]),
										Conversions.ToShort(array3[13]),
										Conversions.ToShort(array3[14]),
										Conversions.ToShort(array3[15]),
										Conversions.ToShort(array3[16]),
										Conversions.ToShort(array3[17])
									};
									fighter.team = Conversions.ToByte(array3[18]);
								}
							}
							else
							{
								fighter.PowerLevel = Conversions.ToInteger(array3[7]);
								fighter.LP = Conversions.ToInteger(array3[12]);
								fighter.AP = Conversions.ToInteger(array3[13]);
								fighter.MP = Conversions.ToInteger(array3[14]);
								fighter.resistance = fighter.monster().grades[checked(fighter.PowerLevel - 1)].resistance;
								if (array3.Length > 16)
								{
									fighter.team = Conversions.ToByte(array3[22]);
								}
								else
								{
									fighter.team = Conversions.ToByte(array3[15]);
								}
							}
						}
						this.delFighterById(fighter.id);
						this.AddFighter(fighter);
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00016CCC File Offset: 0x00014ECC
		public void OnTourMiddle(string sdata)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			string[] array = sdata.Split(new char[]
			{
				'|'
			});
			RuntimeHelpers.GetObjectValue(new object());
			checked
			{
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						';'
					});
					if (array2.Length != 0)
					{
						string value = array2[0];
						bool flag = Operators.CompareString(array2[1], "1", false) == 0;
						Fighter fighter = this.bot().Fight.getFighterByid(Conversions.ToInteger(value));
						if (Information.IsNothing(fighter))
						{
							fighter = new Fighter();
						}
						fighter.dead = flag;
						fighter.id = Conversions.ToInteger(value);
						if (!flag)
						{
							string value2 = array2[2];
							string value3 = array2[3];
							string value4 = array2[4];
							string value5 = array2[5];
							string value6 = array2[7];
							fighter.LP = Conversions.ToInteger(value2);
							fighter.LPmax = Conversions.ToInteger(value6);
							fighter.AP = Conversions.ToInteger(value3);
							fighter.cellId = Conversions.ToInteger(value5);
							fighter.MP = Conversions.ToInteger(value4);
							fighter.fight = this;
						}
						this.delFighterById(fighter.id);
						this.AddFighter(fighter);
					}
				}
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00016E18 File Offset: 0x00015018
		internal Fighter method_4(int int_1)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				this.list_0.FirstOrDefault((Fighter g) => g.gfxId == int_1);
			}
			Fighter result;
			return result;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00016E80 File Offset: 0x00015080
		internal Fighter method_5()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Fighter result;
			lock (obj)
			{
				result = this.list_0[Combat.random_0.Next(this.list_0.Count)];
			}
			return result;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00016EE4 File Offset: 0x000150E4
		public void LaunchSpell(int id, int cell, int waitTime)
		{
			int speedCombat = this.bot().config.speedCombat;
			checked
			{
				if (id == 2510)
				{
					this.bot().Send(new Message("GA303" + Conversions.ToString(cell), speedCombat + waitTime, true, true, true));
					this.bot().Send(new Message("GKK0", speedCombat + waitTime + 40, false, false, true));
				}
				else
				{
					this.bot().Send(new Message("GA300" + Conversions.ToString(id) + ";" + Conversions.ToString(cell), speedCombat + waitTime, true, true, true));
					this.bot().Send(new Message("GKK0", speedCombat + waitTime + 40, false, false, true));
				}
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00016FA4 File Offset: 0x000151A4
		internal void method_6(string string_0)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			Cell c = this.bot().map.mapDataActuel[Conversions.ToInteger(string_0.Substring(checked(string_0.IndexOf("|") + 1)))];
			Cell cell = this.bot().map.mapDataActuel[this.myFighter().cellId];
			cell.ManhattanDistanceTo(c);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00017018 File Offset: 0x00015218
		internal void method_7(string string_0)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			this.bot().Send(new Message("GC1", 0, true, false, true));
			Perso perso = this.bot();
			ref int ptr = ref perso.nbCombat;
			perso.nbCombat = checked(ptr + 1);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00003876 File Offset: 0x00001A76
		public void giveUp()
		{
			this.bot().Send(new Message("GQ", 0, true, true, true));
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00017060 File Offset: 0x00015260
		internal void method_8(string string_0)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			if (this.bot().get_Slave(true).Count > 0)
			{
				this.bot().launcher.waitAction = 5000;
			}
			Perso perso = this.bot();
			ref int ptr = ref perso.nbCombat;
			perso.nbCombat = checked(ptr + 1);
			this.bot().MessagesToSend.Clear();
			this.bot().FightResult.Add(new FightStatsEntry(string_0, this.bot()));
			if (this.bot().ia != null)
			{
				this.bot().ia.Reset();
			}
			this.bot().Send(new Message("GC1", 0, true, false, true));
			if (this.bot().config.Client != null)
			{
				this.ClosePopup();
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00003891 File Offset: 0x00001A91
		public void ClosePopup()
		{
			Input.SendKey(27, this.bot().config.Client, 3800, null);
			Input.SendKey(27, this.bot().config.Client, 4000, null);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000038CD File Offset: 0x00001ACD
		public void onStartToPlay()
		{
			this.Start = true;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001713C File Offset: 0x0001533C
		internal void method_9(object object_1)
		{
			bool flag = Conversion.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(object_1, new object[]
			{
				0
			}, null))) == 1.0;
			int id = Conversions.ToInteger(NewLateBinding.LateGet(object_1, null, "Substring", new object[]
			{
				1
			}, null, null, null));
			checked
			{
				if ((from b in this.bot().get_Slave(true)
				where b == id
				select b).Count<int>() > 0)
				{
					if (flag)
					{
						ref byte ptr = ref this.byte_0;
						this.byte_0 = ptr + 1;
					}
					else
					{
						ref byte ptr = ref this.byte_0;
						this.byte_0 = ptr - 1;
					}
				}
				if (this.bot().get_Slave(true).Count > 0 && this.bot().get_Slave(true).Count == (int)this.byte_0)
				{
					this.ready(true);
					this.Start = true;
				}
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001722C File Offset: 0x0001542C
		public async void onPositionStart(string p)
		{
			checked
			{
				try
				{
					this.bot().lastRecepetionFight = DateTime.Now;
					this.position[0] = new List<int>();
					this.position[1] = new List<int>();
					string[] _loc3_ = p.Split(new char[]
					{
						'|'
					});
					string _loc4_ = _loc3_[0];
					string _loc5_ = _loc3_[1];
					string _loc6_ = _loc3_[2];
					this.int_0 = Conversions.ToInteger(_loc6_);
					int _loc7_ = 0;
					while (_loc7_ < _loc4_.Length)
					{
						int _loc8_ = Class9.smethod_1(_loc4_[_loc7_]) << 6;
						_loc8_ += Class9.smethod_1(_loc4_[_loc7_ + 1]);
						_loc7_ += 2;
						this.position[0].Add(_loc8_);
					}
					int _loc9_ = 0;
					while (_loc9_ < _loc5_.Length)
					{
						int _loc10_ = Class9.smethod_1(_loc5_[_loc9_]) << 6;
						_loc10_ += Class9.smethod_1(_loc5_[_loc9_ + 1]);
						_loc9_ += 2;
						this.position[1].Add(_loc10_);
					}
					this.method_2();
					if (this.bot().ia != null && !this.Start)
					{
						while (this.myFighter() == null)
						{
							TaskAwaiter taskAwaiter = Task.Delay(300).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								TaskAwaiter taskAwaiter2;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
							taskAwaiter = default(TaskAwaiter);
						}
						if (this.myFighter() != null)
						{
							this.bot().ia.goToPlacement();
							this.NbLifePoint = (double)this.myFighter().LP;
						}
						this.method_1();
					}
				}
				catch (Exception ex)
				{
					Fonctions.traiterErreur(ex);
				}
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000038D6 File Offset: 0x00001AD6
		public void setPlayerPosition(int nCellNum)
		{
			if (!this.Start)
			{
				this.bot().Send(new Message("Gp" + Conversions.ToString(nCellNum), 110, true, true, true));
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0001726C File Offset: 0x0001546C
		internal void method_10(string string_0)
		{
			string[] array = string_0.Split(new char[]
			{
				'|'
			});
			if (array.Length == 6)
			{
				this.Start = (Conversions.ToDouble(array[4]) == 0.0);
			}
			else
			{
				this.Start = (Conversions.ToDouble(array[3]) == 0.0);
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000172C8 File Offset: 0x000154C8
		public void OnTurnStart(string v)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			string left = v.Substring(0, v.IndexOf("|"));
			checked
			{
				v.Substring(v.IndexOf("|") + 1);
				this.myturn = (Operators.CompareString(left, this.bot().monIdDofus, false) == 0);
				if (this.myturn)
				{
					ref int ptr = ref this.nbTour;
					this.nbTour = ptr + 1;
					if (!Information.IsNothing(this.bot().ia))
					{
						this.bot().ia.method_0();
					}
				}
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00017364 File Offset: 0x00015564
		public Fighter myFighter()
		{
			return this.getFighterByid(Conversions.ToInteger(this.bot().monIdDofus));
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00003908 File Offset: 0x00001B08
		public void OnTurnReady(string v)
		{
			this.bot().Send(new Message("GT", 500, false, false, true));
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0001738C File Offset: 0x0001558C
		internal async void method_11(string string_0)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
			string[] datas = string_0.Split(new char[]
			{
				'|'
			});
			if (Operators.CompareString(datas[1], this.bot().monIdDofus, false) == 0)
			{
				this.bot().Send(new Message("GKK" + datas[0], 0, false, false, true));
				await Task.Delay(checked(this.bot().config.speedCombat + 100));
				this.bot().ia.method_0();
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000173CC File Offset: 0x000155CC
		public Fighter getFighterByCellId(int v)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			Fighter result;
			lock (obj)
			{
				result = this.list_0.FirstOrDefault((Fighter f) => f.cellId == v && !f.invisible && !f.dead);
			}
			return result;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00017434 File Offset: 0x00015634
		public void removeInvocation(object ownerId)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				try
				{
					foreach (Fighter fighter in this.list_0)
					{
						if (Operators.ConditionalCompareObjectEqual(fighter.ownerId, ownerId, false))
						{
							fighter.dead = true;
						}
					}
				}
				finally
				{
					List<Fighter>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000174CC File Offset: 0x000156CC
		public IEnumerable<Fighter> getFightersByTeam(int t)
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			IEnumerable<Fighter> result;
			lock (obj)
			{
				result = from f in this.list_0
				where (int)f.team == t
				select f;
			}
			return result;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00017534 File Offset: 0x00015734
		public List<Fighter> fighters
		{
			get
			{
				return this.list_0;
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00003927 File Offset: 0x00001B27
		internal void method_12(string string_0)
		{
			this.bot().lastRecepetionFight = DateTime.Now;
		}

		// Token: 0x04000362 RID: 866
		private List<Fighter> list_0;

		// Token: 0x04000363 RID: 867
		private static Random random_0;

		// Token: 0x04000364 RID: 868
		public int index;

		// Token: 0x04000365 RID: 869
		public List<int>[] position;

		// Token: 0x04000366 RID: 870
		public int id;

		// Token: 0x04000367 RID: 871
		private int int_0;

		// Token: 0x04000368 RID: 872
		public int nbTour;

		// Token: 0x04000369 RID: 873
		public bool myturn;

		// Token: 0x0400036A RID: 874
		public bool Start;

		// Token: 0x0400036B RID: 875
		public double double_0;

		// Token: 0x0400036C RID: 876
		public double NbLifePoint;

		// Token: 0x0400036D RID: 877
		private object object_0;

		// Token: 0x0400036E RID: 878
		private byte byte_0;
	}
}
