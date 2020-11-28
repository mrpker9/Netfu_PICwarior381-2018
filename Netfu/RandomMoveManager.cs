using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000101 RID: 257
	public class RandomMoveManager
	{
		// Token: 0x06000539 RID: 1337 RVA: 0x00004DAD File Offset: 0x00002FAD
		public RandomMoveManager()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.activeFight = false;
			this.inZone = false;
			this.inMap = false;
			this.lastArea = 0;
			this.list_0 = new List<MapNeighbour>();
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x000297CC File Offset: 0x000279CC
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00004DE1 File Offset: 0x00002FE1
		public RandomMoveManager(int targetId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.activeFight = false;
			this.inZone = false;
			this.inMap = false;
			this.lastArea = 0;
			this.list_0 = new List<MapNeighbour>();
			this.targetId = targetId;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x000297E8 File Offset: 0x000279E8
		public void Update()
		{
			checked
			{
				if (this.bot.map.AllSlavesInMap())
				{
					if (this.activeFight)
					{
						if (Conversions.ToBoolean(this.bot.CheckFight()))
						{
							return;
						}
					}
					else if (this.bot.interactiveManager.Use(-1, 0))
					{
						return;
					}
					if (this.inZone)
					{
						if (this.lastArea == 0)
						{
							this.lastArea = (int)this.bot.map.subarea();
						}
						else if ((int)this.bot.map.subarea() != this.lastArea)
						{
							MapNeighbour direction = (this.lastMove == MapNeighbour.Right) ? MapNeighbour.Left : ((this.lastMove == MapNeighbour.Left) ? MapNeighbour.Right : ((this.lastMove == MapNeighbour.Top) ? MapNeighbour.Bottom : ((this.lastMove == MapNeighbour.Bottom) ? MapNeighbour.Top : MapNeighbour.Top)));
							this.bot.movement.MoveMapDirection(direction, this.inZone, null);
							return;
						}
						MapDescription expression = Loader.Maps.FirstOrDefault((MapDescription m) => this.bot.map.subarea() == m.subarea && m.point.X == this.bot.map.position.X && m.point.Y == this.bot.map.position.Y - 1);
						MapDescription expression2 = Loader.Maps.FirstOrDefault((MapDescription m) => this.bot.map.subarea() == m.subarea && m.point.X == this.bot.map.position.X && m.point.Y == this.bot.map.position.Y + 1);
						MapDescription expression3 = Loader.Maps.FirstOrDefault((MapDescription m) => this.bot.map.subarea() == m.subarea && m.point.X == this.bot.map.position.X - 1 && m.point.Y == this.bot.map.position.Y);
						MapDescription expression4 = Loader.Maps.FirstOrDefault((MapDescription m) => this.bot.map.subarea() == m.subarea && m.point.X == this.bot.map.position.X + 1 && m.point.Y == this.bot.map.position.Y);
						if (Information.IsNothing(expression))
						{
							this.list_0.Add(MapNeighbour.Top);
						}
						if (Information.IsNothing(expression2))
						{
							this.list_0.Add(MapNeighbour.Bottom);
						}
						if (Information.IsNothing(expression3))
						{
							this.list_0.Add(MapNeighbour.Left);
						}
						if (Information.IsNothing(expression4))
						{
							this.list_0.Add(MapNeighbour.Right);
						}
					}
					if (!this.inMap)
					{
						Thread.Sleep(2000);
						KeyValuePair<bool, MapNeighbour> keyValuePair = this.bot.movement.MoveMapDirection(MapNeighbour.Any, this.inZone, this.list_0.ToArray());
						this.lastMove = keyValuePair.Value;
						MapNeighbour item = (this.lastMove == MapNeighbour.Right) ? MapNeighbour.Left : ((this.lastMove == MapNeighbour.Left) ? MapNeighbour.Right : ((this.lastMove == MapNeighbour.Top) ? MapNeighbour.Bottom : ((this.lastMove == MapNeighbour.Bottom) ? MapNeighbour.Top : MapNeighbour.Top)));
						if (keyValuePair.Key)
						{
							this.list_0.Add(item);
						}
						if (this.int_0 != this.bot.map.id || this.list_0.Count >= 4)
						{
							this.list_0.Clear();
							this.int_0 = this.bot.map.id;
						}
					}
				}
			}
		}

		// Token: 0x0400055A RID: 1370
		public int targetId;

		// Token: 0x0400055B RID: 1371
		public bool activeFight;

		// Token: 0x0400055C RID: 1372
		public bool inZone;

		// Token: 0x0400055D RID: 1373
		public bool inMap;

		// Token: 0x0400055E RID: 1374
		public int lastArea;

		// Token: 0x0400055F RID: 1375
		public MapNeighbour lastMove;

		// Token: 0x04000560 RID: 1376
		private List<MapNeighbour> list_0;

		// Token: 0x04000561 RID: 1377
		private int int_0;
	}
}
