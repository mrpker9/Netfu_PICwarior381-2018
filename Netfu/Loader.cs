using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200003E RID: 62
	public class Loader
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000D770 File Offset: 0x0000B970
		static Loader()
		{
			Class15.XRATSHnz66atd();
			Loader.Monsters = new List<MonsterDescription>();
			Loader.Spells = new List<SpellDescription>();
			Loader.Ios = new List<IODescription>();
			Loader.Objets = new List<ObjetDescription>();
			Loader.Skill = new List<SkillDescription>();
			Loader.Jobs = new List<JobsDescription>();
			Loader.Maps = new List<MapDescription>();
			Loader.DialogsNpc = new Dictionary<int, string>();
			Loader.Crafts = new Dictionary<int, KeyValuePair<List<ObjetDescription>, List<int>>>();
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00002744 File Offset: 0x00000944
		public Loader()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000D7DC File Offset: 0x0000B9DC
		public static int LoadAll()
		{
			int num = Licence.checking(false, 0);
			if (num == 1)
			{
				Loader.smethod_1();
				Loader.smethod_7();
				Loader.smethod_8();
				Loader.smethod_5();
				Loader.smethod_6();
				Loader.smethod_4();
				Loader.smethod_3();
				Loader.smethod_2();
				Loader.smethod_0();
			}
			return num;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000D828 File Offset: 0x0000BA28
		private static void smethod_0()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\crafts.txt");
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				int key = Conversions.ToInteger(text.Substring(0, text.IndexOf("=")));
				List<string> list = text.Substring(checked(text.IndexOf("=") + 1)).Split(new char[]
				{
					';'
				}).ToList<string>();
				try
				{
					foreach (string text2 in list)
					{
						string[] array = text2.Split(new char[]
						{
							','
						});
						if (!Loader.Crafts.ContainsKey(key))
						{
							KeyValuePair<List<ObjetDescription>, List<int>> value = new KeyValuePair<List<ObjetDescription>, List<int>>(new List<ObjetDescription>(), new List<int>());
							Loader.Crafts.Add(key, value);
						}
						Loader.Crafts[key].Key.Add(Loader.getItemById(Conversions.ToInteger(array[0])));
						Loader.Crafts[key].Value.Add(Conversions.ToInteger(array[1]));
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			streamReader.Close();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000D978 File Offset: 0x0000BB78
		private static void smethod_1()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\reponseNPC.txt");
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				int key = Conversions.ToInteger(text.Substring(0, text.IndexOf("=")));
				string text2 = text.Substring(checked(text.IndexOf("=") + 2));
				text2 = text2.Replace("\"", "").Replace(";", "");
				Loader.DialogsNpc.Add(key, text2);
			}
			streamReader.Close();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000DA0C File Offset: 0x0000BC0C
		private static void smethod_2()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\maps.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Maps.Add(new MapDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000DA58 File Offset: 0x0000BC58
		private static void smethod_3()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\spells.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Spells.Add(new SpellDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000DAA4 File Offset: 0x0000BCA4
		private static void smethod_4()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\monsters.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Monsters.Add(new MonsterDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		private static void smethod_5()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\skills.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Skill.Add(new SkillDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000DB3C File Offset: 0x0000BD3C
		private static void smethod_6()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\ios.txt");
			while (!streamReader.EndOfStream)
			{
				IODescription iodescription = new IODescription(streamReader.ReadLine());
				if (iodescription.Id != -1)
				{
					Loader.Ios.Add(iodescription);
				}
			}
			streamReader.Close();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000DB98 File Offset: 0x0000BD98
		private static void smethod_7()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\objets.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Objets.Add(new ObjetDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000DBE4 File Offset: 0x0000BDE4
		private static void smethod_8()
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + "\\data\\jobs.txt");
			while (!streamReader.EndOfStream)
			{
				Loader.Jobs.Add(new JobsDescription(streamReader.ReadLine()));
			}
			streamReader.Close();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000DC30 File Offset: 0x0000BE30
		public static SkillDescription getSkillById(int id)
		{
			return Loader.Skill.FirstOrDefault((SkillDescription f) => f.id == id);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000DC64 File Offset: 0x0000BE64
		public static SkillDescription getSkillByName(string name)
		{
			return Loader.Skill.FirstOrDefault((SkillDescription f) => Operators.CompareString(f.nom, name, false) == 0);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000DC98 File Offset: 0x0000BE98
		public static JobsDescription getJobById(int id)
		{
			return Loader.Jobs.FirstOrDefault((JobsDescription f) => f.id == id);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000DCCC File Offset: 0x0000BECC
		public static MapDescription getMapById(int id)
		{
			return Loader.Maps.FirstOrDefault((MapDescription f) => f.id == id);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000DD00 File Offset: 0x0000BF00
		public static MonsterDescription getMonsterByName(string name)
		{
			return Loader.Monsters.FirstOrDefault((MonsterDescription f) => !Information.IsNothing(f.nom) && Operators.CompareString(f.nom.ToLower(), name.ToLower(), false) == 0);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000DD34 File Offset: 0x0000BF34
		public static MonsterDescription getMonsterById(int id)
		{
			return Loader.Monsters.FirstOrDefault((MonsterDescription f) => f.id == id);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000DD68 File Offset: 0x0000BF68
		public static MonsterDescription getMonsterByGFXId(int id)
		{
			return Loader.Monsters.FirstOrDefault((MonsterDescription f) => f.GfxID == id);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000DD9C File Offset: 0x0000BF9C
		public static IODescription smethod_9(string name)
		{
			return Loader.Ios.FirstOrDefault((IODescription f) => Operators.CompareString(f.nom, name, false) == 0);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
		public static IODescription smethod_10(int id)
		{
			return Loader.Ios.FirstOrDefault((IODescription f) => f.Id == id);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000DE04 File Offset: 0x0000C004
		public static IODescription getIOByLayerId(int Layerid)
		{
			return Loader.Ios.FirstOrDefault((IODescription f) => f.LayersId.Contains(Layerid));
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000DE38 File Offset: 0x0000C038
		public static SpellDescription getSpellByName(string name)
		{
			return Loader.Spells.FirstOrDefault((SpellDescription f) => Operators.CompareString(f.nom, name, false) == 0);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000DE6C File Offset: 0x0000C06C
		public static SpellDescription getSpellById(int id)
		{
			return Loader.Spells.FirstOrDefault((SpellDescription f) => f.id == id);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		public static ObjetDescription getItemByName(string name)
		{
			return Loader.Objets.FirstOrDefault((ObjetDescription f) => Operators.CompareString(f.nom, name, false) == 0);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000DED4 File Offset: 0x0000C0D4
		public static ObjetDescription getItemById(int id)
		{
			return Loader.Objets.FirstOrDefault((ObjetDescription f) => f.id == id);
		}

		// Token: 0x04000129 RID: 297
		public static List<MonsterDescription> Monsters;

		// Token: 0x0400012A RID: 298
		public static List<SpellDescription> Spells;

		// Token: 0x0400012B RID: 299
		public static List<IODescription> Ios;

		// Token: 0x0400012C RID: 300
		public static List<ObjetDescription> Objets;

		// Token: 0x0400012D RID: 301
		public static List<SkillDescription> Skill;

		// Token: 0x0400012E RID: 302
		public static List<JobsDescription> Jobs;

		// Token: 0x0400012F RID: 303
		public static List<MapDescription> Maps;

		// Token: 0x04000130 RID: 304
		public static Dictionary<int, string> DialogsNpc;

		// Token: 0x04000131 RID: 305
		public static Dictionary<int, KeyValuePair<List<ObjetDescription>, List<int>>> Crafts;
	}
}
