using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200007B RID: 123
	public class MovementHandler
	{
		// Token: 0x0600029C RID: 668 RVA: 0x000036D5 File Offset: 0x000018D5
		static MovementHandler()
		{
			Class15.XRATSHnz66atd();
			MovementHandler.random_0 = new Random();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00014E68 File Offset: 0x00013068
		public int currentCell()
		{
			int result;
			try
			{
				result = (this.bot().status.enCombat() ? this.bot().Fight.myFighter().cellId : this.bot().map.myActor().Cell);
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
				result = new Random().Next(20, 255);
			}
			return result;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00014EF0 File Offset: 0x000130F0
		public MovementHandler()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.destcell = -1;
			this.retest = 0;
			this.destAction = "";
			this.lastcell = -1;
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00014F40 File Offset: 0x00013140
		public Perso bot()
		{
			return Declarations.comptes[this.index];
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00014F60 File Offset: 0x00013160
		public MovementHandler(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.destcell = -1;
			this.retest = 0;
			this.destAction = "";
			this.lastcell = -1;
			this.object_0 = RuntimeHelpers.GetObjectValue(new object());
			this.index = index;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00014FB4 File Offset: 0x000131B4
		public KeyValuePair<bool, MapNeighbour> MoveMapDirection(MapNeighbour direction, bool inzone, MapNeighbour[] deniedsMap = null)
		{
			MovementHandler._Closure$__12-0 CS$<>8__locals1 = new MovementHandler._Closure$__12-0(CS$<>8__locals1);
			int[] array = new int[]
			{
				this.bot().map.changeurDroite(),
				this.bot().map.changeurHaut(),
				this.bot().map.changeurGauche(),
				this.bot().map.changeurBas()
			};
			CS$<>8__locals1.$VB$Local_tocell = -1;
			if (direction < (MapNeighbour)array.Length)
			{
				CS$<>8__locals1.$VB$Local_tocell = checked((short)array[(int)direction]);
			}
			else
			{
				while (CS$<>8__locals1.$VB$Local_tocell == -1 & array.Where((MovementHandler._Closure$__.$I12-0 != null) ? MovementHandler._Closure$__.$I12-0 : (MovementHandler._Closure$__.$I12-0 = ((int c) => c == -1))).Count<int>() < array.Count<int>())
				{
					direction = (MapNeighbour)MovementHandler.random_0.Next(0, 4);
					if (!Information.IsNothing(deniedsMap) && deniedsMap.Contains(direction))
					{
						array[(int)direction] = -1;
					}
					else
					{
						CS$<>8__locals1.$VB$Local_tocell = checked((short)array[(int)direction]);
					}
				}
			}
			KeyValuePair<bool, MapNeighbour> result;
			if (CS$<>8__locals1.$VB$Local_tocell != -1 && (int)CS$<>8__locals1.$VB$Local_tocell != -123456 && Information.IsNothing(this.bot().map.monsters((MonsterGroupe m) => m.Cell == (int)CS$<>8__locals1.$VB$Local_tocell, "aucun").FirstOrDefault<MonsterGroupe>()))
			{
				this.destAction = "";
				result = new KeyValuePair<bool, MapNeighbour>(this.SeDeplacer((int)CS$<>8__locals1.$VB$Local_tocell, -1), direction);
			}
			else
			{
				this.bot().launcher.waitAction = 1500;
				result = new KeyValuePair<bool, MapNeighbour>(false, direction);
			}
			return result;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00015134 File Offset: 0x00013334
		public bool SeDeplacer(int caseFin, int nbPm = -1)
		{
			this.bot().chatHandler.AddTextChat("Try to move to " + Conversions.ToString(caseFin), "debug");
			Character character = this.bot().map.myActor();
			if (!Information.IsNothing(character))
			{
				this.lastActorCell = character.Cell;
				if (caseFin == character.Cell && this.bot().Fight == null)
				{
					if (Operators.CompareString(this.destAction, "fight", false) != 0)
					{
						this.EndMove();
						return true;
					}
					caseFin = this.bot().map.mapDataActuel[caseFin].GetAdjacentCells(true, true, 1).FirstOrDefault((Cell c) => Conversions.ToBoolean(c.isWalkable(this.bot(), true))).Id;
				}
				if (caseFin > 0 && caseFin < this.bot().map.mapDataActuel.Count)
				{
					if (Operators.CompareString(this.destAction, "fight", false) == 0 && this.bot().map.mapDataActuel[caseFin].IsChangeur)
					{
						return false;
					}
					if (Operators.CompareString(this.destAction, "fight", false) != 0 && this.bot().map.getActorsCell(caseFin, true) != null)
					{
						return false;
					}
				}
			}
			else if (Information.IsNothing(character))
			{
				this.bot().chatHandler.AddTextChat("Actor is null", "debug");
			}
			this.destcell = caseFin;
			bool result;
			if (this.method_0(nbPm))
			{
				this.lastcell = caseFin;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000036E6 File Offset: 0x000018E6
		public void CancelMove()
		{
			if (!this.bot().status.enDeplacement())
			{
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000152D4 File Offset: 0x000134D4
		private bool method_0(int int_0 = -1)
		{
			Perso perso = this.bot();
			this.bot().chatHandler.AddTextChat("Wait speed config", "debug");
			int num = this.bot().status.enCombat() ? this.bot().config.speedCombat : this.bot().config.globalSpeed;
			bool result;
			if (this.destcell < 0)
			{
				this.bot().chatHandler.AddTextChat("cell invalid", "debug");
				result = false;
			}
			else
			{
				PathFinding pathFinding = new PathFinding(this.bot().map, this.bot().Fight, this.index);
				List<Cell> list = pathFinding.FindPath(this.currentCell(), this.destcell);
				if (Information.IsNothing(list) || list.Count == 0)
				{
					perso.status.bloqueGA = 0;
					if (Operators.CompareString(this.destAction, "fight", false) == 0)
					{
						MonsterGroupe monsterGroupe = this.bot().map.monsters((MonsterGroupe m) => m.Cell == this.destcell, "aucun").FirstOrDefault<MonsterGroupe>();
						if (!Information.IsNothing(monsterGroupe))
						{
							this.bot().map.RemoveActor(monsterGroupe);
						}
					}
					this.bot().launcher.waitAction = 2000;
					this.bot().chatHandler.AddTextChat("cannot find path", "debug");
					result = false;
				}
				else
				{
					int num2 = (Information.IsNothing(this.bot().Fight) || Information.IsNothing(this.bot().Fight.myFighter())) ? 9999 : this.bot().Fight.myFighter().MP;
					if (int_0 > -1)
					{
						num2 = ((int_0 > num2) ? num2 : int_0);
					}
					string path = Path.getPath(list, num2, this.bot().map);
					if (Operators.CompareString(path, "", false) != 0)
					{
						this.bot().Send(new Message("GA001" + path, num, true, true, true));
						double num3 = (double)this.bot().config.speedCombat / 10.0;
						if (Information.IsNothing(this.bot().Fight))
						{
							if (this.bot().map.myActor().dead)
							{
								num3 = 1000.0;
							}
							else
							{
								num3 = (double)((list.Count <= 3) ? 325 : 155);
							}
						}
						this.bot().launcher.waitAction = checked((int)Math.Round(unchecked((double)num + num3 * (double)list.Count)));
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00015594 File Offset: 0x00013794
		[DebuggerStepThrough]
		public void EndMove()
		{
			MovementHandler.VB$StateMachine_17_EndMove vb$StateMachine_17_EndMove = new MovementHandler.VB$StateMachine_17_EndMove();
			vb$StateMachine_17_EndMove.$VB$Me = this;
			vb$StateMachine_17_EndMove.$State = -1;
			vb$StateMachine_17_EndMove.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_17_EndMove.$Builder.Start<MovementHandler.VB$StateMachine_17_EndMove>(ref vb$StateMachine_17_EndMove);
		}

		// Token: 0x04000338 RID: 824
		public int index;

		// Token: 0x04000339 RID: 825
		public int destcell;

		// Token: 0x0400033A RID: 826
		public object retest;

		// Token: 0x0400033B RID: 827
		public string destAction;

		// Token: 0x0400033C RID: 828
		private static Random random_0;

		// Token: 0x0400033D RID: 829
		public int lastcell;

		// Token: 0x0400033E RID: 830
		public int lastActorCell;

		// Token: 0x0400033F RID: 831
		private object object_0;
	}
}
