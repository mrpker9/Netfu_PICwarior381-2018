using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000036 RID: 54
	public class SpellHandler
	{
		// Token: 0x06000148 RID: 328 RVA: 0x0000CDDC File Offset: 0x0000AFDC
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.int_0);
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
		public List<string> SpellsName
		{
			get
			{
				return this.SpellsList.Select((SpellHandler._Closure$__.$I6-0 == null) ? (SpellHandler._Closure$__.$I6-0 = ((KeyValuePair<int, byte> s) => Loader.getSpellById(s.Key).nom)) : SpellHandler._Closure$__.$I6-0).ToList<string>();
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00002ED4 File Offset: 0x000010D4
		public SpellHandler()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.SpellsList = new List<KeyValuePair<int, byte>>();
			this.int_1 = new int[17];
			this.object_0 = 0;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000CE3C File Offset: 0x0000B03C
		public int hashCode
		{
			get
			{
				return checked(this.GetHashCode() + this.SpellsList.Select((SpellHandler._Closure$__.$I9-0 == null) ? (SpellHandler._Closure$__.$I9-0 = ((KeyValuePair<int, byte> s) => s.Key)) : SpellHandler._Closure$__.$I9-0).Sum());
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000CE88 File Offset: 0x0000B088
		public SpellHandler(string datas, int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.SpellsList = new List<KeyValuePair<int, byte>>();
			this.int_1 = new int[17];
			this.object_0 = 0;
			this.int_0 = index;
			datas = datas.Substring(2);
			string[] array = datas.Split(new char[]
			{
				';'
			});
			if (Operators.CompareString(array[0], "o+", false) != 0)
			{
				foreach (string text in array)
				{
					if (text.Length != 0)
					{
						string[] array2 = text.Split(new char[]
						{
							'~'
						});
						if (array2.Length > 1)
						{
							this.SpellsList.Add(new KeyValuePair<int, byte>(Conversions.ToInteger(array2[0]), Conversions.ToByte(array2[1])));
						}
					}
				}
				this.SpellsList.Add(new KeyValuePair<int, byte>(2510, 1));
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000CF68 File Offset: 0x0000B168
		public void OnResultUpgrade(string sExtraData, bool bSuccess)
		{
			if (bSuccess)
			{
				string[] _loc4_ = sExtraData.Split(new char[]
				{
					'~'
				});
				this.SpellsList.RemoveAll((KeyValuePair<int, byte> f) => (double)f.Key == Conversions.ToDouble(_loc4_[0]));
				this.SpellsList.Add(new KeyValuePair<int, byte>(Conversions.ToInteger(_loc4_[0]), Conversions.ToByte(_loc4_[1])));
			}
			else
			{
				this.bot().Debug("Impossible de booster le sort ");
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000CFEC File Offset: 0x0000B1EC
		public void boost(object nID)
		{
			if ((from f in this.SpellsList
			where Operators.ConditionalCompareObjectEqual(f.Key, nID, false)
			select f).Count<KeyValuePair<int, byte>>() > 0)
			{
				this.bot().Send(new Message(Conversions.ToString(Operators.AddObject("SB", nID)), 0, true, true, true));
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000D050 File Offset: 0x0000B250
		public void EquipeSort(int spellId, bool force = false)
		{
			if (!this.int_1.Contains(spellId) || force)
			{
				int num = Array.IndexOf<int>(this.int_1, spellId);
				if (force && num > 0)
				{
					this.bot().Send(new Message("SM" + Conversions.ToString(spellId) + "|" + Conversions.ToString(checked(num + 1)), 0, false, true, true));
				}
				else
				{
					ref object ptr = ref this.object_0;
					this.object_0 = Operators.AddObject(ptr, 1);
					this.object_0 = Operators.ModObject(this.object_0, 16);
					if (Operators.ConditionalCompareObjectEqual(this.object_0, 0, false))
					{
						ptr = ref this.object_0;
						this.object_0 = Operators.AddObject(ptr, 1);
					}
					this.bot().Send(new Message(Conversions.ToString(Operators.ConcatenateObject("SM" + Conversions.ToString(spellId) + "|", this.object_0)), 0, false, true, true));
					this.int_1[Conversions.ToInteger(this.object_0)] = spellId;
				}
			}
		}

		// Token: 0x04000103 RID: 259
		public List<KeyValuePair<int, byte>> SpellsList;

		// Token: 0x04000104 RID: 260
		private int int_0;

		// Token: 0x04000105 RID: 261
		private int[] int_1;

		// Token: 0x04000106 RID: 262
		private object object_0;
	}
}
