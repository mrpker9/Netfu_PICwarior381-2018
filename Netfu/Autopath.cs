using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000108 RID: 264
	public class Autopath
	{
		// Token: 0x06000569 RID: 1385 RVA: 0x0002BD44 File Offset: 0x00029F44
		public Autopath()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.destCoord = new Point(1000, 1000);
			this.NeighboursClose = new List<MapNeighbour>();
			this.fight = false;
			this.onlyMove = false;
			this.cond = new List<Condition>();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0002BD98 File Offset: 0x00029F98
		public void Init(trajetManager t, Maps m, bool needBank)
		{
			Autopath._Closure$__6-0 CS$<>8__locals1 = new Autopath._Closure$__6-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_needBank = needBank;
			if (m != null)
			{
				int num = 999999999;
				try
				{
					foreach (LineTrajet lineTrajet in t.Lines.Where((CS$<>8__locals1.$I0 == null) ? (CS$<>8__locals1.$I0 = ((LineTrajet li) => li != null && li.Bank == CS$<>8__locals1.$VB$Local_needBank && li.conditions.Where((Autopath._Closure$__.$I6-1 == null) ? (Autopath._Closure$__.$I6-1 = ((Condition c) => !c.isOk(null))) : Autopath._Closure$__.$I6-1).Count<Condition>() == 0)) : CS$<>8__locals1.$I0))
					{
						int num2 = checked(Math.Abs(lineTrajet.Coords.X - m.position.X) + Math.Abs(lineTrajet.Coords.Y - m.position.Y));
						if (num2 < num)
						{
							this.destCoord = lineTrajet.Coords;
							this.onlyMove = lineTrajet.onlymove;
							num = num2;
							this.cond = lineTrajet.conditions;
						}
					}
				}
				finally
				{
					IEnumerator<LineTrajet> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0002BEA0 File Offset: 0x0002A0A0
		public void update(Perso b)
		{
			Maps map = b.map;
			if (!Information.IsNothing(map))
			{
				if ((this.destCoord.X == 1000 & this.destCoord.Y == 1000) || this.cond.Where((Autopath._Closure$__.$I7-0 == null) ? (Autopath._Closure$__.$I7-0 = ((Condition c) => !c.isOk(null))) : Autopath._Closure$__.$I7-0).Count<Condition>() > 0)
				{
					this.Init(b.MovementTrajet, b.map, (double)b.config.PodsReturnBank < (double)b.Inventaire.podsactual / (double)b.Inventaire.podsMax * 100.0 && b.MovementTrajet.Lines.Where((Autopath._Closure$__.$I7-1 == null) ? (Autopath._Closure$__.$I7-1 = ((LineTrajet c) => c.Bank)) : Autopath._Closure$__.$I7-1).Count<LineTrajet>() > 0);
					if ((this.destCoord.X != 1000 || this.destCoord.Y != 0) && (this.destCoord.X == 1000 & this.destCoord.Y == 1000))
					{
						b.MovementTrajet.End();
					}
				}
				bool flag = (double)b.config.PodsReturnBank <= (double)b.Inventaire.podsactual / (double)b.Inventaire.podsMax * 100.0;
				if ((!this.fight || !Conversions.ToBoolean(b.CheckFight())) && (this.onlyMove || flag || !b.interactiveManager.Use(-1, 0)))
				{
					MapNeighbour direction = MapNeighbour.Top;
					if (this.destCoord.X > map.position.X && map.changeurDroite() != -1)
					{
						direction = MapNeighbour.Right;
					}
					if (this.destCoord.X < map.position.X && map.changeurGauche() != -1)
					{
						direction = MapNeighbour.Left;
					}
					if (this.destCoord.Y > map.position.Y && map.changeurBas() != -1)
					{
						direction = MapNeighbour.Bottom;
					}
					if (this.destCoord.Y < map.position.Y && map.changeurHaut() != -1)
					{
						direction = MapNeighbour.Top;
					}
					if (!b.movement.MoveMapDirection(direction, false, null).Key)
					{
					}
				}
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00004ECF File Offset: 0x000030CF
		public void Ending(Perso b)
		{
			if (this.destCoord.X != 1000)
			{
				this.fight = false;
				this.destCoord = new Point(1000, 1000);
			}
		}

		// Token: 0x040005A4 RID: 1444
		public Point destCoord;

		// Token: 0x040005A5 RID: 1445
		public List<MapNeighbour> NeighboursClose;

		// Token: 0x040005A6 RID: 1446
		public bool fight;

		// Token: 0x040005A7 RID: 1447
		public bool onlyMove;

		// Token: 0x040005A8 RID: 1448
		public List<Condition> cond;
	}
}
