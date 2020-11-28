using System;
using System.Collections.Generic;

namespace WindowsApplication2
{
	// Token: 0x020000BD RID: 189
	public class PriorityQueue<T> where T : IIndexedObject
	{
		// Token: 0x060003F6 RID: 1014 RVA: 0x00004382 File Offset: 0x00002582
		public PriorityQueue()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.InnerList = new List<T>();
			this.mComparer = Comparer<T>.Default;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000043A5 File Offset: 0x000025A5
		public PriorityQueue(IComparer<T> comparer)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.InnerList = new List<T>();
			this.mComparer = comparer;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000043C4 File Offset: 0x000025C4
		public PriorityQueue(IComparer<T> comparer, int capacity)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.InnerList = new List<T>();
			this.mComparer = comparer;
			this.InnerList.Capacity = capacity;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001E494 File Offset: 0x0001C694
		protected void SwitchElements(int i, int j)
		{
			T value = this.InnerList[i];
			this.InnerList[i] = this.InnerList[j];
			this.InnerList[j] = value;
			T t = this.InnerList[i];
			t.Index = i;
			t = this.InnerList[j];
			t.Index = j;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001E50C File Offset: 0x0001C70C
		protected virtual int OnCompare(int i, int j)
		{
			return this.mComparer.Compare(this.InnerList[i], this.InnerList[j]);
		}

		/// <summary>
		/// Push an object onto the PQ
		/// </summary>
		/// <param name="O">The new object</param>
		/// <returns>The index in the list where the object is _now_. me will change when objects are taken from or put onto the PQ.</returns>
		// Token: 0x060003FB RID: 1019 RVA: 0x0001E540 File Offset: 0x0001C740
		public int Push(T item)
		{
			int num = this.InnerList.Count;
			item.Index = this.InnerList.Count;
			this.InnerList.Add(item);
			while (num != 0)
			{
				int num2 = checked((int)Math.Round((double)(num - 1) / 2.0));
				if (this.OnCompare(num, num2) >= 0)
				{
					break;
				}
				this.SwitchElements(num, num2);
				num = num2;
			}
			return num;
		}

		/// <summary>
		/// Get the smallest object and remove it.
		/// </summary>
		/// <returns>The smallest object</returns>
		// Token: 0x060003FC RID: 1020 RVA: 0x0001E5B4 File Offset: 0x0001C7B4
		public T Pop()
		{
			T result = this.InnerList[0];
			int num = 0;
			checked
			{
				this.InnerList[0] = this.InnerList[this.InnerList.Count - 1];
				T t = this.InnerList[0];
				t.Index = 0;
				this.InnerList.RemoveAt(this.InnerList.Count - 1);
				result.Index = -1;
				for (;;)
				{
					int num2 = num;
					int num3 = 2 * num + 1;
					int num4 = 2 * num + 2;
					if (this.InnerList.Count > num3 && this.OnCompare(num, num3) > 0)
					{
						num = num3;
					}
					if (this.InnerList.Count > num4 && this.OnCompare(num, num4) > 0)
					{
						num = num4;
					}
					if (num == num2)
					{
						break;
					}
					this.SwitchElements(num, num2);
				}
				return result;
			}
		}

		/// <summary>
		/// Notify the PQ that the object at position i has changed
		/// and the PQ needs to restore order.
		/// </summary>
		// Token: 0x060003FD RID: 1021 RVA: 0x0001E6A4 File Offset: 0x0001C8A4
		public void Update(T item)
		{
			int count = this.InnerList.Count;
			checked
			{
				while (item.Index - 1 >= 0 && this.OnCompare(item.Index - 1, item.Index) > 0)
				{
					this.SwitchElements(item.Index - 1, item.Index);
				}
				while (item.Index + 1 < count && this.OnCompare(item.Index + 1, item.Index) < 0)
				{
					this.SwitchElements(item.Index + 1, item.Index);
				}
			}
		}

		/// <summary>
		/// Get the smallest object without removing it.
		/// </summary>
		/// <returns>The smallest object</returns>
		// Token: 0x060003FE RID: 1022 RVA: 0x0001E788 File Offset: 0x0001C988
		public T Peek()
		{
			T result;
			if (this.InnerList.Count > 0)
			{
				result = this.InnerList[0];
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000043EF File Offset: 0x000025EF
		public void Clear()
		{
			this.InnerList.Clear();
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x0001E7C0 File Offset: 0x0001C9C0
		public int Count
		{
			get
			{
				return this.InnerList.Count;
			}
		}

		// Token: 0x04000437 RID: 1079
		protected List<T> InnerList;

		// Token: 0x04000438 RID: 1080
		protected IComparer<T> mComparer;
	}
}
