using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200005A RID: 90
	public class Cell : IComparer<Cell>, IIndexedObject
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x0000FC80 File Offset: 0x0000DE80
		static Cell()
		{
			Class15.XRATSHnz66atd();
			Cell.point_0 = new Point(1, 1);
			Cell.point_1 = new Point(1, 0);
			Cell.point_2 = new Point(1, -1);
			Cell.point_3 = new Point(0, -1);
			Cell.point_4 = new Point(-1, -1);
			Cell.point_5 = new Point(-1, 0);
			Cell.point_6 = new Point(-1, 1);
			Cell.point_7 = new Point(0, 1);
			Cell.Comparer = new Cell();
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		public Point coord2
		{
			get
			{
				int x = checked(this.Y + (int)this.maps_0.width);
				int x2 = this.X;
				Point result = new Point(x, x2);
				return result;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0000FD30 File Offset: 0x0000DF30
		public byte los
		{
			get
			{
				if (this.maps_0.patchedCells.ContainsKey(this.Id))
				{
					if (this.maps_0.patchedCells[this.Id] == 1)
					{
						return 0;
					}
					if (this.maps_0.patchedCells[this.Id] == 0)
					{
						return 1;
					}
				}
				byte result;
				if (this.movement == 0)
				{
					result = 0;
				}
				else if (this.object2Movement)
				{
					result = 0;
				}
				else if (this.layerObject2Interactive)
				{
					result = 0;
				}
				else
				{
					Ressources myUsable = this.myUsable;
					if (myUsable != null)
					{
						List<SkillDescription> skills = Loader.smethod_10(myUsable.id).Skills;
						if (skills != null && skills.FirstOrDefault((Cell._Closure$__.$I34-0 == null) ? (Cell._Closure$__.$I34-0 = ((SkillDescription s) => Operators.CompareString(s.nom, "Pêcher", false) == 0 || Operators.CompareString(s.nom, "Couper", false) == 0 || Operators.CompareString(s.nom, "Collecter", false) == 0)) : Cell._Closure$__.$I34-0) != null)
						{
							return 0;
						}
					}
					result = 1;
				}
				return result;
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000FE1C File Offset: 0x0000E01C
		public object isWalkable(Perso perso, bool FinalCell)
		{
			if (!Information.IsNothing(perso) && !Information.IsNothing(perso.map))
			{
				if (perso.map.patchedCells.ContainsKey(this.Id))
				{
					if (perso.map.patchedCells[this.Id] == 1)
					{
						return false;
					}
					if (perso.map.patchedCells[this.Id] == 0)
					{
						return true;
					}
				}
				if (this.movement == 0)
				{
					return false;
				}
				if (this.object2Movement)
				{
					return false;
				}
				if (this.layerObject2Interactive)
				{
					return false;
				}
				Ressources myUsable = this.myUsable;
				if (myUsable != null)
				{
					List<SkillDescription> skills = Loader.smethod_10(myUsable.id).Skills;
					if (skills != null && skills.FirstOrDefault((Cell._Closure$__.$I35-0 == null) ? (Cell._Closure$__.$I35-0 = ((SkillDescription s) => Operators.CompareString(s.nom, "Pêcher", false) == 0 || Operators.CompareString(s.nom, "Couper", false) == 0 || Operators.CompareString(s.nom, "Collecter", false) == 0)) : Cell._Closure$__.$I35-0) != null)
					{
						return false;
					}
				}
				if (!Information.IsNothing(perso.Fight))
				{
					return Information.IsNothing(perso.Fight.getFighterByCellId(this.Id));
				}
				if (!FinalCell)
				{
					return !this.IsChangeur;
				}
			}
			return true;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x0000FF98 File Offset: 0x0000E198
		public Ressources myUsable
		{
			get
			{
				Ressources result;
				if (this.maps_0 != null)
				{
					if (this.maps_0.patchedCells.ContainsKey(this.Id) && this.maps_0.patchedCells[this.Id] == 3)
					{
						result = null;
					}
					else
					{
						result = this.maps_0.getRessourceByCellId(this.Id);
					}
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00010000 File Offset: 0x0000E200
		public bool IsChangeur
		{
			get
			{
				bool result;
				if (this.maps_0.patchedCells.ContainsKey(this.Id))
				{
					result = (this.maps_0.patchedCells[this.Id] == 2);
				}
				else
				{
					result = (this.movement == 2 || this.int_5 == 1030 || this.int_5 == 1029 || this.layerObject2Num == 1030 || this.layerObject2Num == 1029);
				}
				return result;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000031F9 File Offset: 0x000013F9
		public Cell()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.X = -1;
			this.Y = -1;
			this.bool_5 = true;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00010084 File Offset: 0x0000E284
		public Cell(Cell cell)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.X = -1;
			this.Y = -1;
			this.bool_5 = true;
			this.Id = cell.Id;
			this.maps_0 = cell.maps_0;
			this.movement = cell.movement;
			this.object2Movement = cell.object2Movement;
			this.int_5 = cell.int_5;
			this.layerObject2Num = cell.layerObject2Num;
			this.X = cell.X;
			this.Y = cell.Y;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00010114 File Offset: 0x0000E314
		public Cell(int Id, Maps map, int Movement)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.X = -1;
			this.Y = -1;
			this.bool_5 = true;
			this.Id = Id;
			this.maps_0 = map;
			this.movement = Movement;
			this.X = this.method_0(Id).X;
			this.Y = this.method_0(Id).Y;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00010180 File Offset: 0x0000E380
		public double distance(int pos2)
		{
			int id = this.Id;
			decimal d = new decimal((double)id / (double)29f);
			decimal d2 = --Math.Ceiling(d);
			decimal d3 = decimal.Subtract(new decimal(id), decimal.Multiply(d2, 29m));
			decimal d4 = d3 % 15m;
			decimal d5 = decimal.Subtract(d2, d4);
			decimal d6 = decimal.Divide(decimal.Subtract(new decimal(id), decimal.Multiply(14m, d5)), 15m);
			decimal d7 = new decimal((double)pos2 / (double)29f);
			decimal d8 = --Math.Ceiling(d7);
			decimal d9 = decimal.Subtract(new decimal(pos2), decimal.Multiply(d8, 29m));
			decimal d10 = d9 % 15m;
			decimal num = decimal.Subtract(d8, d10);
			decimal d11 = decimal.Divide(decimal.Subtract(new decimal(pos2), decimal.Multiply(14m, num)), 15m);
			return Math.Sqrt(Math.Pow(Convert.ToDouble(decimal.Subtract(d11, d6)), 2.0) + Math.Pow(Convert.ToDouble(decimal.Subtract(num, d5)), 2.0));
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000102D0 File Offset: 0x0000E4D0
		private Point method_0(int int_7)
		{
			checked
			{
				Point result;
				if (this.X != -1 && this.Y != -1)
				{
					result = new Point(this.X, this.Y);
				}
				else
				{
					byte width = this.maps_0.width;
					double num = Math.Floor((double)int_7 / (double)(width * 2 - 1));
					double num2 = unchecked((double)int_7 - num * (double)(checked(width * 2 - 1)));
					double num3 = num2 % (double)width;
					Point point = default(Point);
					point.Y = (int)Math.Round(unchecked(num - num3));
					point.X = (int)Math.Round((double)(int_7 - (int)(width - 1) * point.Y) / (double)width);
					result = point;
				}
				return result;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00010374 File Offset: 0x0000E574
		public int ManhattanDistanceTo(Cell c)
		{
			checked
			{
				int num = Math.Abs(this.X - c.X);
				int num2 = Math.Abs(this.Y - c.Y);
				return num + num2;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000103AC File Offset: 0x0000E5AC
		public int ManhattanDistanceTo(int cellid)
		{
			Cell cell = this.maps_0.mapDataActuel.FirstOrDefault((Cell ce) => ce.Id == cellid);
			checked
			{
				int num = Math.Abs(this.X - cell.X);
				int num2 = Math.Abs(this.Y - cell.Y);
				return num + num2;
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00010410 File Offset: 0x0000E610
		public IEnumerable<Cell> GetAllCellsInRange(int minRange, int maxRange, bool ignoreThis, Func<Cell, bool> predicate)
		{
			List<Cell> list = new List<Cell>();
			Cell._Closure$__47-0 CS$<>8__locals1 = new Cell._Closure$__47-0(CS$<>8__locals1);
			Cell._Closure$__47-0 CS$<>8__locals2 = CS$<>8__locals1;
			checked
			{
				int $VB$Local_x = this.X - maxRange;
				int num = this.X + maxRange;
				CS$<>8__locals2.$VB$Local_x1 = $VB$Local_x;
				while (CS$<>8__locals1.$VB$Local_x1 <= num)
				{
					Cell._Closure$__47-1 CS$<>8__locals3 = new Cell._Closure$__47-1(CS$<>8__locals3);
					CS$<>8__locals3.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals1;
					Cell._Closure$__47-1 CS$<>8__locals4 = CS$<>8__locals3;
					int $VB$Local_y = this.Y - maxRange;
					int num2 = this.Y + maxRange;
					CS$<>8__locals4.$VB$Local_y1 = $VB$Local_y;
					while (CS$<>8__locals3.$VB$Local_y1 <= num2)
					{
						if (!ignoreThis || this.X != this.X || this.Y != this.Y)
						{
							int num3 = Math.Abs(CS$<>8__locals3.$VB$NonLocal_$VB$Closure_2.$VB$Local_x1 - this.X) + Math.Abs(CS$<>8__locals3.$VB$Local_y1 - this.Y);
							Cell cell = this.maps_0.mapDataActuel.FirstOrDefault((Cell c) => c.X == CS$<>8__locals3.$VB$NonLocal_$VB$Closure_2.$VB$Local_x1 && c.Y == CS$<>8__locals3.$VB$Local_y1);
							if (!Information.IsNothing(cell) && num3 <= maxRange && num3 >= minRange && (cell != null && (predicate == null || predicate(cell))))
							{
								list.Add(cell);
							}
						}
						CS$<>8__locals3.$VB$Local_y1++;
					}
					CS$<>8__locals1.$VB$Local_x1++;
				}
				return list;
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0001056C File Offset: 0x0000E76C
		public IEnumerable<Cell> GetCellsInLine(Cell destination)
		{
			Cell._Closure$__48-0 CS$<>8__locals1 = new Cell._Closure$__48-0(CS$<>8__locals1);
			List<Cell> list = new List<Cell>();
			checked
			{
				int num = Math.Abs(destination.X - this.X);
				int num2 = Math.Abs(destination.Y - this.Y);
				CS$<>8__locals1.$VB$Local_x__1 = this.X;
				CS$<>8__locals1.$VB$Local_y__2 = this.Y;
				int i = 1 + num + num2;
				int num3 = (destination.X > this.X) ? 1 : -1;
				int num4 = (destination.Y > this.Y) ? 1 : -1;
				int num5 = num - num2;
				num *= 2;
				num2 *= 2;
				while (i > 0)
				{
					Cell cell = this.maps_0.mapDataActuel.FirstOrDefault((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = ((Cell F) => F.X == CS$<>8__locals1.$VB$Local_x__1 && F.Y == CS$<>8__locals1.$VB$Local_y__2)) : CS$<>8__locals1.$I0);
					if (!Information.IsNothing(cell))
					{
						list.Add(cell);
					}
					if (num5 > 0)
					{
						CS$<>8__locals1.$VB$Local_x__1 += num3;
						num5 -= num2;
					}
					else if (num5 == 0)
					{
						CS$<>8__locals1.$VB$Local_x__1 += num3;
						CS$<>8__locals1.$VB$Local_y__2 += num4;
					}
					else
					{
						CS$<>8__locals1.$VB$Local_y__2 += num4;
						num5 += num;
					}
					i--;
				}
				return list;
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000106C4 File Offset: 0x0000E8C4
		public IEnumerable<Cell> GetCellsInDirection(DirectionsEnum direction, short minDistance, short maxDistance)
		{
			List<Cell> list = new List<Cell>();
			for (short num = minDistance; num <= maxDistance; num += 1)
			{
				Cell cellInDirection = this.GetCellInDirection(direction, num);
				if (cellInDirection != null)
				{
					list.Add(cellInDirection);
				}
			}
			return list;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00010708 File Offset: 0x0000E908
		public IEnumerable<Cell> GetCellsInDirections(IEnumerable<DirectionsEnum> directions, short minDistance, short maxDistance)
		{
			List<Cell> list = new List<Cell>();
			try
			{
				foreach (DirectionsEnum direction in directions)
				{
					try
					{
						foreach (Cell item in this.GetCellsInDirection(direction, minDistance, maxDistance))
						{
							list.Add(item);
						}
					}
					finally
					{
						IEnumerator<Cell> enumerator2;
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
				}
			}
			finally
			{
				IEnumerator<DirectionsEnum> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return list;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00010798 File Offset: 0x0000E998
		public Cell GetNearestCellInDirection(DirectionsEnum direction)
		{
			return this.GetCellInDirection(direction, 1);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000107B0 File Offset: 0x0000E9B0
		public IEnumerable<Cell> GetAdjacentCells(bool droit, bool diagonals, int distance = 1)
		{
			List<DirectionsEnum> list = new List<DirectionsEnum>();
			if (droit)
			{
				list.AddRange(new DirectionsEnum[]
				{
					DirectionsEnum.DIRECTION_SOUTH_EAST,
					DirectionsEnum.DIRECTION_SOUTH_WEST,
					DirectionsEnum.DIRECTION_NORTH_EAST,
					DirectionsEnum.DIRECTION_NORTH_WEST
				});
			}
			if (diagonals)
			{
				list.AddRange(new DirectionsEnum[]
				{
					DirectionsEnum.DIRECTION_SOUTH,
					DirectionsEnum.DIRECTION_NORTH,
					DirectionsEnum.DIRECTION_WEST,
					DirectionsEnum.DIRECTION_EAST
				}.ToList<DirectionsEnum>());
			}
			return this.GetCellsInDirections(list, 1, checked((short)distance));
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00010808 File Offset: 0x0000EA08
		public int OrientationTo(Cell cell, bool InclureDroiteDirection = true)
		{
			int num = 0;
			checked
			{
				do
				{
					if (InclureDroiteDirection || num % 2 == 1)
					{
						object cellsInDirection = this.GetCellsInDirection((DirectionsEnum)num, 0, 20);
						object[] array;
						bool[] array2;
						object value = NewLateBinding.LateGet(cellsInDirection, null, "Contains", array = new object[]
						{
							cell
						}, null, null, array2 = new bool[]
						{
							true
						});
						if (array2[0])
						{
							cell = (Cell)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Cell));
						}
						if (Conversions.ToBoolean(value))
						{
							goto IL_7E;
						}
					}
					num++;
				}
				while (num <= 7);
				return -1;
				IL_7E:
				return num;
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000108A0 File Offset: 0x0000EAA0
		public DirectionsEnum OrientationToAdjacent(Cell cell)
		{
			Point left = new Point
			{
				X = ((cell.X > this.X) ? 1 : ((cell.X < this.X) ? -1 : 0)),
				Y = ((cell.Y > this.Y) ? 1 : ((cell.Y < this.Y) ? -1 : 0))
			};
			DirectionsEnum result;
			if (left == Cell.point_0)
			{
				result = DirectionsEnum.DIRECTION_EAST;
			}
			else if (left == Cell.point_1)
			{
				result = DirectionsEnum.DIRECTION_SOUTH_EAST;
			}
			else if (left == Cell.point_2)
			{
				result = DirectionsEnum.DIRECTION_SOUTH;
			}
			else if (left == Cell.point_3)
			{
				result = DirectionsEnum.DIRECTION_SOUTH_WEST;
			}
			else if (left == Cell.point_4)
			{
				result = DirectionsEnum.DIRECTION_WEST;
			}
			else if (left == Cell.point_5)
			{
				result = DirectionsEnum.DIRECTION_NORTH_WEST;
			}
			else if (left == Cell.point_6)
			{
				result = DirectionsEnum.DIRECTION_NORTH;
			}
			else if (left == Cell.point_7)
			{
				result = DirectionsEnum.DIRECTION_NORTH_EAST;
			}
			else
			{
				result = DirectionsEnum.DIRECTION_EAST;
			}
			return result;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00010998 File Offset: 0x0000EB98
		public Cell GetCellInDirection(DirectionsEnum direction, short distance)
		{
			int id = this.Id;
			checked
			{
				switch (direction)
				{
				case DirectionsEnum.DIRECTION_EAST:
					id += (int)distance;
					break;
				case DirectionsEnum.DIRECTION_SOUTH_EAST:
					id += (int)(unchecked(distance * (short)this.maps_0.width));
					break;
				case DirectionsEnum.DIRECTION_SOUTH:
					id += (int)(distance * (short)(unchecked(this.maps_0.width + this.maps_0.height) - 3));
					break;
				case DirectionsEnum.DIRECTION_SOUTH_WEST:
					id += (int)(distance * (short)(this.maps_0.width - 1));
					break;
				case DirectionsEnum.DIRECTION_WEST:
					id -= (int)distance;
					break;
				case DirectionsEnum.DIRECTION_NORTH_WEST:
					id -= (int)(unchecked(distance * (short)this.maps_0.width));
					break;
				case DirectionsEnum.DIRECTION_NORTH:
					id -= (int)(distance * (short)(unchecked(this.maps_0.width + this.maps_0.height) - 3));
					break;
				case DirectionsEnum.DIRECTION_NORTH_EAST:
					id -= (int)(distance * (short)(this.maps_0.width - 1));
					break;
				default:
					throw new Exception(Conversions.ToString(unchecked(Conversions.ToDouble("Unknown direction : ") + (double)direction)));
				}
				Cell cell = this.maps_0.mapDataActuel.FirstOrDefault((Cell n) => n.Id == id);
				Cell result;
				if (!Information.IsNothing(cell))
				{
					result = cell;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00010B1C File Offset: 0x0000ED1C
		public int height()
		{
			double num;
			if (this.int_4 != 0)
			{
				if (this.int_4 != 1)
				{
					num = 0.5;
					goto IL_27;
				}
			}
			num = 0.0;
			IL_27:
			double num2 = num;
			checked
			{
				int num3 = (this.int_2 != 0) ? (this.int_2 - 7) : 0;
				return (int)Math.Round(unchecked((double)num3 + num2));
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00010B74 File Offset: 0x0000ED74
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000321B File Offset: 0x0000141B
		public double G
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00010B8C File Offset: 0x0000ED8C
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00003224 File Offset: 0x00001424
		public double H
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00010BA4 File Offset: 0x0000EDA4
		// (set) Token: 0x060001EF RID: 495 RVA: 0x0000322D File Offset: 0x0000142D
		public double F
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00010BBC File Offset: 0x0000EDBC
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00003236 File Offset: 0x00001436
		int IIndexedObject.Index
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00010BD4 File Offset: 0x0000EDD4
		int IComparer<Cell>.IComparer_Compare(Cell c1, Cell c2)
		{
			int result;
			if (c1.F < c2.F)
			{
				result = -1;
			}
			else if (c1.F > c2.F)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x04000240 RID: 576
		public int movement;

		// Token: 0x04000241 RID: 577
		public bool layerObject2Interactive;

		// Token: 0x04000242 RID: 578
		public int layerObject2Num;

		// Token: 0x04000243 RID: 579
		public bool object2Movement;

		// Token: 0x04000244 RID: 580
		public int X;

		// Token: 0x04000245 RID: 581
		public int Y;

		// Token: 0x04000246 RID: 582
		public int Id;

		// Token: 0x04000247 RID: 583
		private Maps maps_0;

		// Token: 0x04000248 RID: 584
		private static readonly Point point_0;

		// Token: 0x04000249 RID: 585
		private static readonly Point point_1;

		// Token: 0x0400024A RID: 586
		private static readonly Point point_2;

		// Token: 0x0400024B RID: 587
		private static readonly Point point_3;

		// Token: 0x0400024C RID: 588
		private static readonly Point point_4;

		// Token: 0x0400024D RID: 589
		private static readonly Point point_5;

		// Token: 0x0400024E RID: 590
		private static readonly Point point_6;

		// Token: 0x0400024F RID: 591
		private static readonly Point point_7;

		// Token: 0x04000250 RID: 592
		private int int_0;

		// Token: 0x04000251 RID: 593
		internal bool bool_0;

		// Token: 0x04000252 RID: 594
		internal int int_1;

		// Token: 0x04000253 RID: 595
		internal int int_2;

		// Token: 0x04000254 RID: 596
		internal int int_3;

		// Token: 0x04000255 RID: 597
		internal int int_4;

		// Token: 0x04000256 RID: 598
		internal bool bool_1;

		// Token: 0x04000257 RID: 599
		internal int int_5;

		// Token: 0x04000258 RID: 600
		internal bool bool_2;

		// Token: 0x04000259 RID: 601
		internal int int_6;

		// Token: 0x0400025A RID: 602
		internal bool bool_3;

		// Token: 0x0400025B RID: 603
		internal string string_0;

		// Token: 0x0400025C RID: 604
		internal bool bool_4;

		// Token: 0x0400025D RID: 605
		internal bool bool_5;

		// Token: 0x0400025E RID: 606
		public static readonly Cell Comparer;

		// Token: 0x0400025F RID: 607
		private double double_0;

		// Token: 0x04000260 RID: 608
		private double double_1;

		// Token: 0x04000261 RID: 609
		private double double_2;
	}
}
