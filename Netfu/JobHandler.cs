using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000028 RID: 40
	public class JobHandler
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00002C40 File Offset: 0x00000E40
		public JobHandler()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Jobs = new List<Job>();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00009E68 File Offset: 0x00008068
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.index);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00009E84 File Offset: 0x00008084
		public JobHandler(string Data, int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Jobs = new List<Job>();
			this.index = index;
			List<string> list = Data.Split(new char[]
			{
				'|'
			}).ToList<string>();
			list.RemoveAt(0);
			checked
			{
				for (int i = 0; i < list.Count; i++)
				{
					JobHandler._Closure$__4-0 CS$<>8__locals1 = new JobHandler._Closure$__4-0(CS$<>8__locals1);
					string[] array = list[i].Split(new char[]
					{
						';'
					});
					CS$<>8__locals1.$VB$Local__loc7_ = array[0];
					List<Skill> list2 = new List<Skill>();
					string[] array2 = array[1].Split(new char[]
					{
						','
					});
					int num = array2.Length;
					while (Math.Max(Interlocked.Decrement(ref num), num + 1) > 0)
					{
						string[] array3 = array2[num].Split(new char[]
						{
							'~'
						});
						list2.Add(new Skill(Conversions.ToInteger(array3[0]), array3[1], array3[2], array3[3], array3[4]));
					}
					Job item = new Job(Conversions.ToInteger(CS$<>8__locals1.$VB$Local__loc7_), list2);
					Job job = this.Jobs.FirstOrDefault((Job j) => (double)j.id == Conversions.ToDouble(CS$<>8__locals1.$VB$Local__loc7_));
					if (!Information.IsNothing(job))
					{
						this.Jobs.Remove(job);
					}
					this.Jobs.Add(item);
				}
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00009FD8 File Offset: 0x000081D8
		public List<Skill> mySkills()
		{
			List<Skill> list = new List<Skill>();
			try
			{
				foreach (Job job in this.Jobs)
				{
					list.AddRange(job.Skills);
				}
			}
			finally
			{
				List<Job>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000A03C File Offset: 0x0000823C
		public void setExp(string sData)
		{
			string[] array = sData.Substring(3).Split(new char[]
			{
				'|'
			});
			foreach (string text in array)
			{
				JobHandler._Closure$__6-0 CS$<>8__locals1 = new JobHandler._Closure$__6-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Local_datasplit = text.Split(new char[]
				{
					';'
				});
				Job job = this.Jobs.FirstOrDefault((Job j) => (double)j.id == Conversion.Val(CS$<>8__locals1.$VB$Local_datasplit[0]));
				job.level = Conversions.ToInteger(CS$<>8__locals1.$VB$Local_datasplit[1]);
				job.expInf = CS$<>8__locals1.$VB$Local_datasplit[2];
				job.expCurrent = CS$<>8__locals1.$VB$Local_datasplit[3];
				job.expSup = CS$<>8__locals1.$VB$Local_datasplit[4];
			}
		}

		// Token: 0x04000096 RID: 150
		public List<Job> Jobs;

		// Token: 0x04000097 RID: 151
		public int index;
	}
}
