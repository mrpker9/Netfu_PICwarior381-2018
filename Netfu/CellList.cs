using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsApplication2
{
	// Token: 0x020000B8 RID: 184
	public class CellList : IEnumerable
	{
		// Token: 0x060003DB RID: 987 RVA: 0x0001E030 File Offset: 0x0001C230
		public CellList(List<Cell> cells)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.dictionary_0 = new Dictionary<Point, Cell>();
			this.list_0 = cells;
			this.dictionary_0 = cells.ToDictionary((CellList._Closure$__.$I2-0 == null) ? (CellList._Closure$__.$I2-0 = delegate(Cell entry)
			{
				Point result = new Point(entry.X, entry.Y);
				return result;
			}) : CellList._Closure$__.$I2-0);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00004289 File Offset: 0x00002489
		public CellList()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.dictionary_0 = new Dictionary<Point, Cell>();
			this.list_0 = new List<Cell>();
		}

		/// <summary>
		/// Returns null if not found
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		// Token: 0x17000048 RID: 72
		public Cell this[int id]
		{
			get
			{
				return this.list_0.FirstOrDefault((Cell c) => c.Id == id);
			}
		}

		/// <summary>
		/// Returns null if not found
		/// </summary>
		/// <returns></returns>
		// Token: 0x17000049 RID: 73
		public Cell this[Point point]
		{
			get
			{
				Cell cell;
				Cell result;
				if (!this.dictionary_0.TryGetValue(point, out cell))
				{
					result = null;
				}
				else
				{
					result = cell;
				}
				return result;
			}
		}

		/// <summary>
		/// Returns null if not found
		/// </summary>
		/// <returns></returns>
		// Token: 0x1700004A RID: 74
		public Cell this[int x, int y]
		{
			get
			{
				return this[new Point(x, y)];
			}
		}

		/// <summary>
		/// Returns the number of cells
		/// </summary>
		/// <returns></returns>
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0001E104 File Offset: 0x0001C304
		public int Count
		{
			get
			{
				return this.list_0.Count;
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001E120 File Offset: 0x0001C320
		public IEnumerator<Cell> GetEnumerator()
		{
			return this.list_0.AsEnumerable<Cell>().GetEnumerator();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001E140 File Offset: 0x0001C340
		IEnumerator IEnumerable.IEnumerable_GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001E158 File Offset: 0x0001C358
		public Cell[] ToArray()
		{
			return this.list_0.ToArray();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0001E174 File Offset: 0x0001C374
		public List<Cell> ToList()
		{
			return this.list_0.ToList<Cell>();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000042AC File Offset: 0x000024AC
		public void Remove(Cell c)
		{
			this.list_0.Remove(c);
			this.dictionary_0.Remove(new Point(c.X, c.Y));
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000042D8 File Offset: 0x000024D8
		public void Add(Cell c)
		{
			this.list_0.Add(c);
			this.dictionary_0.Add(new Point(c.X, c.Y), c);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00004303 File Offset: 0x00002503
		public void replace(int x, int y, Cell c)
		{
			this.dictionary_0[new Point(x, y)] = c;
		}

		// Token: 0x0400042D RID: 1069
		private readonly List<Cell> list_0;

		// Token: 0x0400042E RID: 1070
		private readonly Dictionary<Point, Cell> dictionary_0;
	}
}
