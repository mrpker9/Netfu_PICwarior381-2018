using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000CA RID: 202
	public class MonsterGroupe : Actors
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x00004503 File Offset: 0x00002703
		static MonsterGroupe()
		{
			Class15.XRATSHnz66atd();
			MonsterGroupe.int_0 = new int[]
			{
				44,
				54,
				65,
				68,
				72,
				74,
				75,
				76,
				82,
				87,
				88,
				89,
				90,
				91,
				93,
				94,
				95,
				96,
				97,
				99,
				108,
				110,
				118,
				119,
				124,
				127,
				153,
				155,
				170,
				179,
				182,
				211,
				212,
				213,
				214,
				216,
				232,
				233,
				253,
				261,
				263,
				289,
				290,
				291,
				292,
				378,
				379,
				380,
				396,
				447,
				450,
				449,
				465,
				466,
				475,
				537,
				583,
				584,
				585,
				586,
				587,
				588,
				589,
				590,
				594,
				595,
				596,
				597,
				598,
				603,
				601,
				651,
				744,
				745,
				746,
				747,
				748,
				749,
				751,
				752,
				753,
				754,
				755,
				756,
				758,
				759,
				760,
				761,
				763,
				783,
				784,
				785,
				786,
				795,
				798,
				879,
				848,
				858,
				855,
				893,
				853,
				876,
				862,
				878,
				884,
				885,
				886,
				892,
				894,
				895,
				905,
				902,
				903,
				904,
				932,
				991,
				992,
				996,
				1041,
				1073,
				1074,
				1075,
				1076,
				1029,
				1077,
				1052,
				1053,
				1054,
				1055,
				1056,
				1057,
				1058,
				1059,
				1096,
				1098,
				1099,
				1100,
				1101,
				1102,
				1103,
				1104,
				1105,
				1106,
				1107,
				1153,
				1154,
				1155,
				1156,
				1157,
				1158,
				1178,
				2416,
				2432,
				2685,
				2300,
				2795
			};
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x000200EC File Offset: 0x0001E2EC
		public string[] names
		{
			get
			{
				return this.ids.Select((MonsterGroupe._Closure$__.$I4-0 == null) ? (MonsterGroupe._Closure$__.$I4-0 = ((int m) => Loader.getMonsterById(m).nom)) : MonsterGroupe._Closure$__.$I4-0).ToArray<string>();
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00020130 File Offset: 0x0001E330
		public bool Aggro
		{
			get
			{
				foreach (int value in this.ids)
				{
					if (MonsterGroupe.int_0.Contains(value))
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0002016C File Offset: 0x0001E36C
		public int level
		{
			get
			{
				return this.levels.Sum();
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00020188 File Offset: 0x0001E388
		public MonsterGroupe(string[] datas)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.levels = datas[7].Split(new char[]
			{
				','
			}).Select((MonsterGroupe._Closure$__.$I10-0 == null) ? (MonsterGroupe._Closure$__.$I10-0 = ((string l) => Conversions.ToInteger(l))) : MonsterGroupe._Closure$__.$I10-0).ToArray<int>();
			this.ids = datas[4].Split(new char[]
			{
				','
			}).Select((MonsterGroupe._Closure$__.$I10-1 == null) ? (MonsterGroupe._Closure$__.$I10-1 = ((string j) => Conversions.ToInteger(j))) : MonsterGroupe._Closure$__.$I10-1).ToArray<int>();
			this.Id = Conversions.ToInteger(datas[3]);
			this.Cell = Conversions.ToInteger(datas[0]);
		}

		// Token: 0x0400047D RID: 1149
		private static int[] int_0;

		// Token: 0x0400047E RID: 1150
		public int[] levels;

		// Token: 0x0400047F RID: 1151
		public int[] ids;
	}
}
