using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000F6 RID: 246
	public class Objets
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00025DA8 File Offset: 0x00023FA8
		public string nomObjet
		{
			get
			{
				string result;
				if (this.objetDescription_0 != null)
				{
					result = this.objetDescription_0.nom;
				}
				else
				{
					result = "";
				}
				return result;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00025DD8 File Offset: 0x00023FD8
		public bool isFami
		{
			get
			{
				return this.objetDescription_0 != null && this.objetDescription_0.method_6();
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00025E04 File Offset: 0x00024004
		public int type
		{
			get
			{
				int result;
				if (this.objetDescription_0 != null)
				{
					result = (int)this.objetDescription_0.type;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00025E30 File Offset: 0x00024030
		public static void PacketObjets(int index, string packet)
		{
			new List<Objets>();
			Perso comtpesByIndex = Declarations.getComtpesByIndex(index);
			comtpesByIndex.Inventaire.ClearObjets();
			List<string> list = Fonctions.Gettok(packet, "|", 11).Split(new char[]
			{
				';'
			}).ToList<string>();
			try
			{
				foreach (string text in list)
				{
					if (Operators.CompareString(text, "", false) != 0)
					{
						Objets obj = new Objets(text);
						comtpesByIndex.Inventaire.addObjet(obj);
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00025EDC File Offset: 0x000240DC
		public Objets(string pate)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.position = -1;
			this.effects = new List<Effect>();
			this.objetDescription_0 = Loader.getItemById(Conversions.ToInteger(this.idObjet));
			this.idObjet = Conversions.ToString(Convert.ToInt64(Fonctions.Gettok(pate, "~", 2), 16));
			this.idObjetInv = Convert.ToInt64(Fonctions.Gettok(pate, "~", 1), 16);
			this.numObjet = Convert.ToInt64(Fonctions.Gettok(pate, "~", 3), 16);
			checked
			{
				this.position = (int)Math.Round((Operators.CompareString(Fonctions.Gettok(pate, "~", 4), "", false) == 0) ? -1.0 : Conversion.Val(Fonctions.Gettok(pate, "~", 4)));
				string text = pate.Substring(pate.LastIndexOf("~") + 1);
				if (text.Trim().Length > 0)
				{
					this.effects.AddRange(text.Split(new char[]
					{
						','
					}).Select((Objets._Closure$__.$I13-0 == null) ? (Objets._Closure$__.$I13-0 = ((string s) => new Effect(s, true))) : Objets._Closure$__.$I13-0).ToList<Effect>());
				}
				this.objetDescription_0 = Loader.getItemById(Conversions.ToInteger(this.idObjet));
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00026034 File Offset: 0x00024234
		public static void PacketObjets2(int index, string packet)
		{
			Perso comtpesByIndex = Declarations.getComtpesByIndex(index);
			string gettokText = Strings.Mid(packet, 5);
			checked
			{
				int num = Fonctions.Gettoks(gettokText, ";") - 1;
				for (int i = 1; i <= num; i++)
				{
					Objets._Closure$__14-0 CS$<>8__locals1 = new Objets._Closure$__14-0(CS$<>8__locals1);
					string pate = Fonctions.Gettok(gettokText, ";", i);
					CS$<>8__locals1.$VB$Local_Objet = new Objets(pate);
					string nomObjet = CS$<>8__locals1.$VB$Local_Objet.nomObjet;
					comtpesByIndex.Inventaire.addObjet(CS$<>8__locals1.$VB$Local_Objet);
					Enclo paddock = Declarations.getComtpesByIndex(index).map.paddock;
					if (paddock != null && Loader.getItemById(Conversions.ToInteger(CS$<>8__locals1.$VB$Local_Objet.idObjet)).type == 97)
					{
						paddock.waitedDragoIdInv().objet = CS$<>8__locals1.$VB$Local_Objet;
					}
					if (!Information.IsNothing(comtpesByIndex.Jobs))
					{
						Objets._Closure$__14-1 CS$<>8__locals2 = new Objets._Closure$__14-1(CS$<>8__locals2);
						List<SkillDescription> source = comtpesByIndex.Jobs.mySkills().Select((Objets._Closure$__.$I14-0 == null) ? (Objets._Closure$__.$I14-0 = ((Skill s) => Loader.getSkillById(s._nID))) : Objets._Closure$__.$I14-0).ToList<SkillDescription>();
						CS$<>8__locals2.$VB$Local_skill = source.FirstOrDefault((SkillDescription s) => !Information.IsNothing(s) && !Information.IsNothing(s.item) && (double)s.item.id == Conversions.ToDouble(CS$<>8__locals1.$VB$Local_Objet.idObjet) && !Information.IsNothing(s.job));
						if (!Information.IsNothing(CS$<>8__locals2.$VB$Local_skill))
						{
							Job job = comtpesByIndex.Jobs.Jobs.FirstOrDefault((Job j) => j.id == Loader.getSkillById(CS$<>8__locals2.$VB$Local_skill.id).job.id);
							if (!job.recolteds.ContainsKey(CS$<>8__locals1.$VB$Local_Objet.nomObjet))
							{
								job.recolteds.Add(CS$<>8__locals1.$VB$Local_Objet.nomObjet, 0);
							}
							Dictionary<string, int> recolteds;
							string nomObjet2;
							(recolteds = job.recolteds)[nomObjet2 = CS$<>8__locals1.$VB$Local_Objet.nomObjet] = (int)(unchecked((long)recolteds[nomObjet2]) + CS$<>8__locals1.$VB$Local_Objet.numObjet);
						}
					}
				}
			}
		}

		// Token: 0x0400053D RID: 1341
		public string idObjet;

		// Token: 0x0400053E RID: 1342
		public long idObjetInv;

		// Token: 0x0400053F RID: 1343
		public long numObjet;

		// Token: 0x04000540 RID: 1344
		public int position;

		// Token: 0x04000541 RID: 1345
		public List<Effect> effects;

		// Token: 0x04000542 RID: 1346
		private ObjetDescription objetDescription_0;
	}
}
