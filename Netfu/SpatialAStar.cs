using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	/// <summary>
	/// Uses about 50 MB for a 1024x1024 grid.
	/// </summary>
	// Token: 0x020000C0 RID: 192
	public class SpatialAStar
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x000043FC File Offset: 0x000025FC
		static SpatialAStar()
		{
			Class15.XRATSHnz66atd();
			SpatialAStar.double_0 = Math.Sqrt(2.0);
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0001E7DC File Offset: 0x0001C9DC
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00004416 File Offset: 0x00002616
		public CellList SearchSpace
		{
			get
			{
				return this.cellList_1;
			}
			private set
			{
				this.cellList_1 = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0001E7F4 File Offset: 0x0001C9F4
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x0000441F File Offset: 0x0000261F
		public int Width
		{
			get
			{
				return this.int_0;
			}
			private set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0001E80C File Offset: 0x0001CA0C
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x00004428 File Offset: 0x00002628
		public int Height
		{
			get
			{
				return this.int_1;
			}
			private set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0001E824 File Offset: 0x0001CA24
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001E840 File Offset: 0x0001CA40
		public SpatialAStar(Maps map, CellList cellList, int targetId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.diagonals = true;
			checked
			{
				if (cellList == null)
				{
					cellList = new CellList();
					int count = map.mapDataActuel.Count;
					for (int i = 0; i <= count; i++)
					{
						cellList.Add(new Cell(i, map, 1));
					}
				}
				this.cellList_2 = cellList;
				this.targetId = targetId;
				this.SearchSpace = cellList;
			}
			this.Width = (int)(map.height + map.width);
			this.Height = (int)(map.height + map.width);
			this.class10_0 = new SpatialAStar.Class10(new CellList());
			this.class10_1 = new SpatialAStar.Class10(new CellList());
			this.cellList_0 = new CellList();
			this.class10_2 = new SpatialAStar.Class10(cellList);
			this.priorityQueue_0 = new PriorityQueue<Cell>(Cell.Comparer);
			this.cellList_1 = new CellList(cellList.ToList().Select((SpatialAStar._Closure$__.$I22-0 == null) ? (SpatialAStar._Closure$__.$I22-0 = ((Cell entry) => new Cell(entry))) : SpatialAStar._Closure$__.$I22-0).ToList<Cell>());
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0001E958 File Offset: 0x0001CB58
		protected virtual double Heuristic(Cell inStart, Cell inEnd)
		{
			return Math.Sqrt((double)(checked((inStart.X - inEnd.X) * (inStart.X - inEnd.X) + (inStart.Y - inEnd.Y) * (inStart.Y - inEnd.Y))));
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		protected virtual double NeighborDistance(Cell inStart, Cell inEnd)
		{
			checked
			{
				int num = Math.Abs(inStart.X - inEnd.X);
				int num2 = Math.Abs(inStart.Y - inEnd.Y);
				double result;
				switch (num + num2)
				{
				case 0:
					result = 0.0;
					break;
				case 1:
					result = 1.0;
					break;
				case 2:
					result = SpatialAStar.double_0;
					break;
				default:
					throw new ApplicationException();
				}
				return result;
			}
		}

		/// <summary>
		/// Returns null, if no path is found. Start- and End-Node are included in returned path. The user context
		/// is passed to IsWalkable().
		/// </summary>
		// Token: 0x0600040F RID: 1039 RVA: 0x0001EA14 File Offset: 0x0001CC14
		public List<Cell> Search(Cell c1, Cell c2, bool ignoreWalkable = false)
		{
			return this.Search(new Point(c1.X, c1.Y), new Point(c2.X, c2.Y), ignoreWalkable);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001EA4C File Offset: 0x0001CC4C
		public List<Cell> Search(Point inStartNode, Point inEndNode, bool ignoreWalkable = false)
		{
			Cell cell = this.cellList_1[inStartNode.X, inStartNode.Y];
			Cell cell2 = this.cellList_1[inEndNode.X, inEndNode.Y];
			int id = cell2.Id;
			checked
			{
				List<Cell> result;
				if (cell.Id == cell2.Id)
				{
					result = new List<Cell>();
				}
				else
				{
					Cell[] array = new Cell[8];
					this.class10_0.method_10();
					this.class10_1.method_10();
					this.class10_2.method_10();
					this.priorityQueue_0.Clear();
					this.cellList_0 = new CellList();
					cell.G = 0.0;
					cell.H = this.Heuristic(cell, cell2);
					cell.F = cell.H;
					this.class10_1.method_7(cell);
					this.priorityQueue_0.Push(cell);
					this.class10_2.method_7(cell);
					int num = 0;
					while (!this.class10_1.method_6())
					{
						Cell cell3 = this.priorityQueue_0.Pop();
						if (cell3.Id == cell2.Id)
						{
							List<Cell> list = this.method_0(this.cellList_0, this.cellList_0[cell2.X, cell2.Y]);
							list.Add(cell2);
							return list;
						}
						this.class10_1.method_9(cell3);
						this.class10_0.method_7(cell3);
						this.method_2(cell3, array);
						int num2 = array.Length - 1;
						for (int i = 0; i <= num2; i++)
						{
							Cell cell4 = array[i];
							if (cell4 != null && !Conversions.ToBoolean(Conversions.ToBoolean(Operators.NotObject(cell4.isWalkable(this.bot, cell4.Id == id))) && !ignoreWalkable) && !this.class10_0.method_8(cell4))
							{
								if (this.bot.Fight == null && Operators.CompareString(this.bot.movement.destAction, "fight", false) != 0 && this.bot.config.DistanceMobsAggro > 0 && this.bot.map.myActor() != null && !this.bot.map.myActor().dead)
								{
									bool flag = false;
									IEnumerable<Cell> allCellsInRange = cell4.GetAllCellsInRange(0, this.bot.config.DistanceMobsAggro, false, (SpatialAStar._Closure$__.$I28-0 == null) ? (SpatialAStar._Closure$__.$I28-0 = ((Cell c) => true)) : SpatialAStar._Closure$__.$I28-0);
									try
									{
										foreach (Cell cell5 in allCellsInRange)
										{
											Actors actorsCell = this.bot.map.getActorsCell(cell5.Id, true);
											if (actorsCell != null && actorsCell is MonsterGroupe && ((MonsterGroupe)actorsCell).Aggro)
											{
												flag = true;
												break;
											}
										}
									}
									finally
									{
										IEnumerator<Cell> enumerator;
										if (enumerator != null)
										{
											enumerator.Dispose();
										}
									}
									if (flag)
									{
										goto IL_3F6;
									}
								}
								num++;
								unchecked
								{
									double num3 = this.class10_2.method_5(cell3).G + this.NeighborDistance(cell3, cell4);
									bool flag2 = false;
									bool flag3;
									if (!this.class10_1.method_8(cell4))
									{
										this.class10_1.method_7(cell4);
										flag3 = true;
										flag2 = true;
									}
									else
									{
										flag3 = (num3 < this.class10_2.method_5(cell4).G);
									}
									if (flag3)
									{
										this.cellList_0.replace(cell4.X, cell4.Y, cell3);
										if (!this.class10_2.method_8(cell4))
										{
											this.class10_2.method_7(cell4);
										}
										this.class10_2.method_5(cell4).G = num3;
										this.class10_2.method_5(cell4).H = this.Heuristic(cell4, cell2);
										this.class10_2.method_5(cell4).F = this.class10_2.method_5(cell4).G + this.class10_2.method_5(cell4).H;
										if (flag2)
										{
											this.priorityQueue_0.Push(cell4);
										}
										else
										{
											this.priorityQueue_0.Update(cell4);
										}
									}
								}
							}
							IL_3F6:;
						}
					}
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001EEB8 File Offset: 0x0001D0B8
		private List<Cell> method_0(CellList cellList_3, Cell cell_0)
		{
			List<Cell> list = new List<Cell>();
			this.method_1(cellList_3, cell_0, list);
			return list;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001EED8 File Offset: 0x0001D0D8
		private void method_1(CellList cellList_3, Cell cell_0, List<Cell> list_0)
		{
			Cell cell = cellList_3[cell_0.X, cell_0.Y];
			if (cell != null)
			{
				this.method_1(cellList_3, cell, list_0);
				list_0.Add(cell_0);
			}
			else
			{
				list_0.Add(cell_0);
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001EF18 File Offset: 0x0001D118
		private void method_2(Cell cell_0, Cell[] cell_1)
		{
			int x = cell_0.X;
			int y = cell_0.Y;
			checked
			{
				if (x >= 0 && y > -20 && this.diagonals)
				{
					cell_1[0] = this.cellList_1[x - 1, y - 1];
				}
				else
				{
					cell_1[0] = null;
				}
				if (y > -20)
				{
					cell_1[1] = this.cellList_1[x, y - 1];
				}
				else
				{
					cell_1[1] = null;
				}
				if (x < this.Width - 1 && y > -20 && this.diagonals)
				{
					cell_1[2] = this.cellList_1[x + 1, y - 1];
				}
				else
				{
					cell_1[2] = null;
				}
				if (x >= 0)
				{
					cell_1[3] = this.cellList_1[x - 1, y];
				}
				else
				{
					cell_1[3] = null;
				}
				if (x < this.Width - 1)
				{
					cell_1[4] = this.cellList_1[x + 1, y];
				}
				else
				{
					cell_1[4] = null;
				}
				if (x >= 0 && y < this.Height - 1 && this.diagonals)
				{
					cell_1[5] = this.cellList_1[x - 1, y + 1];
				}
				else
				{
					cell_1[5] = null;
				}
				if (y < this.Height - 1)
				{
					cell_1[6] = this.cellList_1[x, y + 1];
				}
				else
				{
					cell_1[6] = null;
				}
				if (x < this.Width - 1 && y < this.Height - 1 && this.diagonals)
				{
					cell_1[7] = this.cellList_1[x + 1, y + 1];
				}
				else
				{
					cell_1[7] = null;
				}
			}
		}

		// Token: 0x04000439 RID: 1081
		private SpatialAStar.Class10 class10_0;

		// Token: 0x0400043A RID: 1082
		private SpatialAStar.Class10 class10_1;

		// Token: 0x0400043B RID: 1083
		private PriorityQueue<Cell> priorityQueue_0;

		// Token: 0x0400043C RID: 1084
		private CellList cellList_0;

		// Token: 0x0400043D RID: 1085
		private SpatialAStar.Class10 class10_2;

		// Token: 0x0400043E RID: 1086
		private CellList cellList_1;

		// Token: 0x0400043F RID: 1087
		public bool diagonals;

		// Token: 0x04000440 RID: 1088
		private int int_0;

		// Token: 0x04000441 RID: 1089
		private int int_1;

		// Token: 0x04000442 RID: 1090
		public int targetId;

		// Token: 0x04000443 RID: 1091
		private static readonly double double_0;

		// Token: 0x04000444 RID: 1092
		private CellList cellList_2;

		// Token: 0x020000C1 RID: 193
		[DefaultMember("Item")]
		private class Class10
		{
			// Token: 0x06000414 RID: 1044 RVA: 0x0001F090 File Offset: 0x0001D290
			public int method_0()
			{
				return this.int_0;
			}

			// Token: 0x06000415 RID: 1045 RVA: 0x00004431 File Offset: 0x00002631
			private void method_1(int int_2)
			{
				this.int_0 = int_2;
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x0001F0A8 File Offset: 0x0001D2A8
			public int method_2()
			{
				return this.int_1;
			}

			// Token: 0x06000417 RID: 1047 RVA: 0x0000443A File Offset: 0x0000263A
			private void method_3(int int_2)
			{
				this.int_1 = int_2;
			}

			// Token: 0x06000418 RID: 1048 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
			public Cell method_4(int int_2, int int_3)
			{
				return this.cellList_0[int_2, int_3];
			}

			// Token: 0x06000419 RID: 1049 RVA: 0x0001F0DC File Offset: 0x0001D2DC
			public Cell method_5(Cell cell_0)
			{
				return this.cellList_0[cell_0.X, cell_0.Y];
			}

			// Token: 0x0600041A RID: 1050 RVA: 0x00004443 File Offset: 0x00002643
			public bool method_6()
			{
				return this.cellList_0.Count == 0;
			}

			// Token: 0x0600041B RID: 1051 RVA: 0x0001F104 File Offset: 0x0001D304
			public Class10(CellList cellList_1)
			{
				Class15.XRATSHnz66atd();
				base..ctor();
				this.cellList_0 = new CellList(cellList_1.ToList().Select((SpatialAStar.Class10._Closure$__.$I15-0 == null) ? (SpatialAStar.Class10._Closure$__.$I15-0 = ((Cell entry) => new Cell(entry))) : SpatialAStar.Class10._Closure$__.$I15-0).ToList<Cell>());
			}

			// Token: 0x0600041C RID: 1052 RVA: 0x0001F15C File Offset: 0x0001D35C
			public void method_7(Cell cell_0)
			{
				Cell cell = this.cellList_0[cell_0.X, cell_0.Y];
				if (cell != null)
				{
					throw new ApplicationException();
				}
				this.cellList_0.Add(cell_0);
			}

			// Token: 0x0600041D RID: 1053 RVA: 0x0001F19C File Offset: 0x0001D39C
			public bool method_8(Cell cell_0)
			{
				Cell cell = this.cellList_0[cell_0.X, cell_0.Y];
				bool result;
				if (cell == null)
				{
					result = false;
				}
				else
				{
					if (!cell_0.Equals(cell))
					{
						throw new ApplicationException();
					}
					result = true;
				}
				return result;
			}

			// Token: 0x0600041E RID: 1054 RVA: 0x0001F1E0 File Offset: 0x0001D3E0
			public void method_9(Cell cell_0)
			{
				Cell cell = this.cellList_0[cell_0.X, cell_0.Y];
				if (!cell_0.Equals(cell))
				{
					throw new ApplicationException();
				}
				this.cellList_0.Remove(cell);
			}

			// Token: 0x0600041F RID: 1055 RVA: 0x00004453 File Offset: 0x00002653
			public void method_10()
			{
				this.cellList_0 = new CellList();
			}

			// Token: 0x04000445 RID: 1093
			private CellList cellList_0;

			// Token: 0x04000446 RID: 1094
			private int int_0;

			// Token: 0x04000447 RID: 1095
			private int int_1;
		}
	}
}
