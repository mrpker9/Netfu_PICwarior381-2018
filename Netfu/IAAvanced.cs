using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000098 RID: 152
	public class IAAvanced
	{
		// Token: 0x06000343 RID: 835 RVA: 0x0001A52C File Offset: 0x0001872C
		private object method_0()
		{
			object obj = this.object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			object result;
			lock (obj)
			{
				result = this.list_0;
			}
			return result;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0001A574 File Offset: 0x00018774
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00003DCA File Offset: 0x00001FCA
		public IAAvanced(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.list_0 = new List<turnIA>();
			this.list_1 = new List<Thread>();
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.index = index;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001A590 File Offset: 0x00018790
		public void PrepareTurn()
		{
			try
			{
				IAAvanced._Closure$__10-0 CS$<>8__locals1 = new IAAvanced._Closure$__10-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Me = this;
				this.list_1.Clear();
				NewLateBinding.LateCall(this.method_0(), null, "Clear", new object[0], null, null, null, true);
				CS$<>8__locals1.$VB$Local_fighters = this.bot().Fight.method_0();
				List<KeyValuePair<int, byte>> list = this.bot().spellHandler.SpellsList.OrderByDescending((IAAvanced._Closure$__.$I10-0 == null) ? (IAAvanced._Closure$__.$I10-0 = ((KeyValuePair<int, byte> s) => s.Value)) : IAAvanced._Closure$__.$I10-0).ToList<KeyValuePair<int, byte>>();
				try
				{
					IEnumerator<Fighter> enumerator = CS$<>8__locals1.$VB$Local_fighters.GetEnumerator();
					while (enumerator.MoveNext())
					{
						IAAvanced._Closure$__10-2 CS$<>8__locals2 = new IAAvanced._Closure$__10-2(CS$<>8__locals2);
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
						CS$<>8__locals2.$VB$Local_f = enumerator.Current;
						try
						{
							List<KeyValuePair<int, byte>>.Enumerator enumerator2 = list.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								IAAvanced._Closure$__10-1 CS$<>8__locals3 = new IAAvanced._Closure$__10-1(CS$<>8__locals3);
								CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3 = CS$<>8__locals2;
								CS$<>8__locals3.$VB$Local_spell = enumerator2.Current;
								Thread thread = new Thread(delegate()
								{
									turnIA turn = new turnIA((List<Fighter>)CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_fighters, CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.bot(), CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.currentTurn);
									CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.evaluate(turn, Loader.getSpellById(CS$<>8__locals3.$VB$Local_spell.Key).Levels[(int)(checked(CS$<>8__locals3.$VB$Local_spell.Value - 1))], CS$<>8__locals3.$VB$NonLocal_$VB$Closure_3.$VB$Local_f);
								});
								this.list_1.Add(thread);
								thread.Start();
							}
						}
						finally
						{
							List<KeyValuePair<int, byte>>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
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
				Thread.Sleep(10000);
				try
				{
					foreach (Thread thread2 in this.list_1)
					{
						thread2.Abort();
					}
				}
				finally
				{
					List<Thread>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
				this.currentTurn = this.list_0.OrderByDescending((IAAvanced._Closure$__.$I10-2 == null) ? (IAAvanced._Closure$__.$I10-2 = ((turnIA t) => t.score)) : IAAvanced._Closure$__.$I10-2).FirstOrDefault<turnIA>();
				this.runActionTurn();
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0001A7D4 File Offset: 0x000189D4
		public void runActionTurn()
		{
			Fighter fighter = this.bot().Fight.myFighter();
			if (this.currentTurn != null)
			{
				ActionTurnIA actionTurnIA = this.currentTurn.actions.FirstOrDefault<ActionTurnIA>();
				if (actionTurnIA != null)
				{
					if (actionTurnIA.cellTOGo != null && actionTurnIA.cellTOGo.Id != fighter.cellId)
					{
						this.bot().movement.SeDeplacer(actionTurnIA.cellTOGo.Id, -1);
					}
					else
					{
						this.bot().spellHandler.EquipeSort(actionTurnIA.Spell.id, false);
						this.bot().Fight.LaunchSpell(actionTurnIA.Spell.id, actionTurnIA.targetCellID, 100);
						this.currentTurn.actions.RemoveAt(0);
					}
				}
				else if (this.currentTurn.endMoveCell != null && fighter.cellId != this.currentTurn.endMoveCell.Id)
				{
					this.bot().movement.SeDeplacer(this.currentTurn.endMoveCell.Id, -1);
				}
				else
				{
					this.bot().Fight.turnEnd();
				}
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001A914 File Offset: 0x00018B14
		public void evaluate(turnIA turn, SpellLevelDescription spell, Fighter target)
		{
			string text = "";
			target = turn.getFighterByid(target.id);
			if (turn.LaunchSpell(target.cellId, spell, ref text))
			{
				turn.applyEffect(spell, target);
				try
				{
					foreach (KeyValuePair<int, byte> keyValuePair in this.bot().spellHandler.SpellsList)
					{
						turnIA turnIA = turn.copy();
						try
						{
							foreach (Fighter target2 in turnIA.fighters)
							{
								this.evaluate(turnIA, Loader.getSpellById(keyValuePair.Key).Levels[(int)(checked(keyValuePair.Value - 1))], target2);
							}
						}
						finally
						{
							List<Fighter>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
					return;
				}
				finally
				{
					List<KeyValuePair<int, byte>>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			turn.calculEndMove();
			object[] array;
			bool[] array2;
			NewLateBinding.LateCall(this.method_0(), null, "Add", array = new object[]
			{
				turn
			}, null, null, array2 = new bool[]
			{
				true
			}, true);
			if (array2[0])
			{
				turn = (turnIA)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(turnIA));
			}
		}

		// Token: 0x040003CF RID: 975
		public int index;

		// Token: 0x040003D0 RID: 976
		public string StartPlacement;

		// Token: 0x040003D1 RID: 977
		public turnIA currentTurn;

		// Token: 0x040003D2 RID: 978
		private List<turnIA> list_0;

		// Token: 0x040003D3 RID: 979
		private List<Thread> list_1;

		// Token: 0x040003D4 RID: 980
		private object object_0;
	}
}
