using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsApplication2
{
	// Token: 0x02000107 RID: 263
	public class LineTrajet
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x0002BC24 File Offset: 0x00029E24
		public LineTrajet()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.int_0 = 0;
			this.subSteps = new List<LineTrajet>();
			this.Coords = default(Point);
			this.neighBours = new List<KeyValuePair<MapNeighbour, int>>();
			this.ioToUse = -123456;
			this.npcToTalke = -123456;
			this.destCell = -123456;
			this.skillToUse = 0;
			this.conditions = new List<Condition>();
			this.mapId = -1;
			this.autoPathCoords = new Point(-12345, -12345);
			this.itemToUse = null;
			this.equipeItems = new List<int>();
			this.destMapId = -1;
			this.drago = false;
			this.IA = new List<string>();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00004EAE File Offset: 0x000030AE
		public bool hasNextStep()
		{
			return this.subSteps.Count > 0;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0002BCE0 File Offset: 0x00029EE0
		public LineTrajet getCurrentStep()
		{
			ref int ptr = ref this.int_0;
			checked
			{
				this.int_0 = ptr + 1;
				LineTrajet result;
				if (this.int_0 == 1)
				{
					result = this;
				}
				else
				{
					this.int_0 %= this.subSteps.Count + 2;
					if (this.int_0 > 1)
					{
						result = this.subSteps[this.int_0 - 2];
					}
				}
				return result;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x00004EBE File Offset: 0x000030BE
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x00004EC6 File Offset: 0x000030C6
		public bool end
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x04000588 RID: 1416
		private int int_0;

		// Token: 0x04000589 RID: 1417
		public List<LineTrajet> subSteps;

		// Token: 0x0400058A RID: 1418
		public bool Fight;

		// Token: 0x0400058B RID: 1419
		public bool onlymove;

		// Token: 0x0400058C RID: 1420
		public bool ignoregroupe;

		// Token: 0x0400058D RID: 1421
		public bool Bank;

		// Token: 0x0400058E RID: 1422
		public Point Coords;

		// Token: 0x0400058F RID: 1423
		public List<KeyValuePair<MapNeighbour, int>> neighBours;

		// Token: 0x04000590 RID: 1424
		public int ioToUse;

		// Token: 0x04000591 RID: 1425
		public int npcToTalke;

		// Token: 0x04000592 RID: 1426
		public int destCell;

		// Token: 0x04000593 RID: 1427
		public int skillToUse;

		// Token: 0x04000594 RID: 1428
		public List<Condition> conditions;

		// Token: 0x04000595 RID: 1429
		public bool Craft;

		// Token: 0x04000596 RID: 1430
		public int mapId;

		// Token: 0x04000597 RID: 1431
		public string secureCode;

		// Token: 0x04000598 RID: 1432
		public Point autoPathCoords;

		// Token: 0x04000599 RID: 1433
		public int[] itemToUse;

		// Token: 0x0400059A RID: 1434
		public Dictionary<int, int[]> buyItems;

		// Token: 0x0400059B RID: 1435
		public Dictionary<int, int[]> sellsItems;

		// Token: 0x0400059C RID: 1436
		public Dictionary<int, int> TakeItems;

		// Token: 0x0400059D RID: 1437
		public List<int> equipeItems;

		// Token: 0x0400059E RID: 1438
		public int destMapId;

		// Token: 0x0400059F RID: 1439
		public KeyValuePair<int, int> reconnect;

		// Token: 0x040005A0 RID: 1440
		public bool drago;

		// Token: 0x040005A1 RID: 1441
		public List<string> IA;

		// Token: 0x040005A2 RID: 1442
		private bool bool_0;

		// Token: 0x040005A3 RID: 1443
		public int wait;
	}
}
