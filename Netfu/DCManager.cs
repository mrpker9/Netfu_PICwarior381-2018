using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000FC RID: 252
	public class DCManager
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0002811C File Offset: 0x0002631C
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00028138 File Offset: 0x00026338
		public void UpdateCells(string datas)
		{
			foreach (string text in datas.Split(new char[]
			{
				'|'
			}))
			{
				string[] array2 = text.Split(new char[]
				{
					';'
				});
				string value = array2[0].Replace("GDC", "");
				int value2 = (Conversions.ToDouble(array2[2]) == 1.0) ? 0 : 1;
				this.bot.map.patchedCells.Add(Conversions.ToInteger(value), value2);
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000281C8 File Offset: 0x000263C8
		public DCManager(int targetId)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.mapValue = new Dictionary<int, byte>();
			this.dirValue = new Dictionary<MapNeighbour, short>();
			this.targetId = targetId;
			this.mapValue.Add(9371, 1);
			this.mapValue.Add(9372, 2);
			this.mapValue.Add(9373, 3);
			this.mapValue.Add(9374, 4);
			this.mapValue.Add(9386, 6);
			this.mapValue.Add(9390, 7);
			this.mapValue.Add(9375, 8);
			this.mapValue.Add(9380, 9);
			this.mapValue.Add(9391, 10);
			this.mapValue.Add(9376, 11);
			this.mapValue.Add(9381, 12);
			this.mapValue.Add(9395, 13);
			this.mapValue.Add(9387, 14);
			this.mapValue.Add(9382, 15);
			this.mapValue.Add(9392, 17);
			this.mapValue.Add(9377, 18);
			this.mapValue.Add(9383, 19);
			this.mapValue.Add(9378, 20);
			this.mapValue.Add(9393, 21);
			this.mapValue.Add(9379, 22);
			this.mapValue.Add(9389, 23);
			this.mapValue.Add(9394, 24);
			this.dirValue.Add(MapNeighbour.Bottom, 5);
			this.dirValue.Add(MapNeighbour.Top, -5);
			this.dirValue.Add(MapNeighbour.Right, 1);
			this.dirValue.Add(MapNeighbour.Left, -1);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000283B8 File Offset: 0x000265B8
		public void Update()
		{
			if (this.mapValue.ContainsKey(this.bot.map.id))
			{
				DCManager._Closure$__7-0 CS$<>8__locals1 = new DCManager._Closure$__7-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Me = this;
				CS$<>8__locals1.$VB$Local_value = this.mapValue[this.bot.map.id];
				if (CS$<>8__locals1.$VB$Local_value == 13)
				{
					return;
				}
				IOrderedEnumerable<MapNeighbour> orderedEnumerable = from n in this.dirValue.Keys.ToList<MapNeighbour>()
				orderby Math.Abs((int)(checked(13 - ((unchecked(CS$<>8__locals1.$VB$Me.dirValue[n] + (short)CS$<>8__locals1.$VB$Local_value) < 0) ? (25 + CS$<>8__locals1.$VB$Me.dirValue[n]) : ((unchecked(CS$<>8__locals1.$VB$Me.dirValue[n] + (short)CS$<>8__locals1.$VB$Local_value) > 25) ? (unchecked(CS$<>8__locals1.$VB$Me.dirValue[n] + (short)CS$<>8__locals1.$VB$Local_value) - 25) : unchecked(CS$<>8__locals1.$VB$Me.dirValue[n] + (short)CS$<>8__locals1.$VB$Local_value))))))
				select n;
				try
				{
					foreach (MapNeighbour direction in orderedEnumerable)
					{
						if (this.bot.movement.MoveMapDirection(direction, false, null).Key)
						{
							break;
						}
					}
					return;
				}
				finally
				{
					IEnumerator<MapNeighbour> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			object left = Operators.AddObject(left, 1);
		}

		// Token: 0x0400054C RID: 1356
		public int targetId;

		// Token: 0x0400054D RID: 1357
		public Dictionary<int, byte> mapValue;

		// Token: 0x0400054E RID: 1358
		public Dictionary<MapNeighbour, short> dirValue;
	}
}
