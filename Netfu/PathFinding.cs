using System;
using System.Collections.Generic;

namespace WindowsApplication2
{
	// Token: 0x020000BC RID: 188
	public class PathFinding
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x00004339 File Offset: 0x00002539
		public PathFinding(Maps Map, Combat fight, int targetId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.bool_0 = (fight != null);
			this.maps_0 = Map;
			this.method_0(targetId);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000435E File Offset: 0x0000255E
		private void method_0(int int_0)
		{
			this.spatialAStar_0 = new SpatialAStar(this.maps_0, new CellList(this.maps_0.mapDataActuel), int_0);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0001E358 File Offset: 0x0001C558
		public List<Cell> FindPath(Cell c1, Cell c2)
		{
			this.spatialAStar_0.diagonals = !this.bool_0;
			this.list_0 = this.spatialAStar_0.Search(c1, c2, false);
			this.spatialAStar_0.diagonals = true;
			return this.list_0;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0001E3A4 File Offset: 0x0001C5A4
		public List<Cell> FindPathSimple(Cell c1, Cell c2)
		{
			this.spatialAStar_0.diagonals = !this.bool_0;
			this.list_0 = this.spatialAStar_0.Search(c1, c2, true);
			this.spatialAStar_0.diagonals = true;
			return this.list_0;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001E3F0 File Offset: 0x0001C5F0
		public List<Cell> FindPath(int c1, int c2)
		{
			List<Cell> result;
			if (c1 < 0 | c2 < 0 | c1 > this.maps_0.mapDataActuel.Count | c2 > this.maps_0.mapDataActuel.Count)
			{
				result = new List<Cell>();
			}
			else
			{
				this.spatialAStar_0.diagonals = !this.bool_0;
				this.list_0 = this.spatialAStar_0.Search(this.maps_0.mapDataActuel[c1], this.maps_0.mapDataActuel[c2], false);
				this.spatialAStar_0.diagonals = true;
				result = this.list_0;
			}
			return result;
		}

		// Token: 0x04000432 RID: 1074
		public static bool m_initialized;

		// Token: 0x04000433 RID: 1075
		private List<Cell> list_0;

		// Token: 0x04000434 RID: 1076
		private Maps maps_0;

		// Token: 0x04000435 RID: 1077
		private SpatialAStar spatialAStar_0;

		// Token: 0x04000436 RID: 1078
		private bool bool_0;
	}
}
