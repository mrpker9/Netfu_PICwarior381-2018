using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000FB RID: 251
	public class Ressources
	{
		// Token: 0x060004EA RID: 1258 RVA: 0x00027FE4 File Offset: 0x000261E4
		public Ressources(string datas)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Cellid = Conversions.ToInteger(Fonctions.Gettok(datas, ";", 1));
			if (Operators.CompareString(Fonctions.Gettok(datas, ";", 3), "1", false) == 0)
			{
				this.stat = "Non coupé";
			}
			else
			{
				this.stat = "Coupé";
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00004A15 File Offset: 0x00002C15
		public Ressources(int Id, int cellid, string stat, string nom)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.Cellid = cellid;
			this.stat = stat;
			this.nom = nom;
			this.id = Id;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00028048 File Offset: 0x00026248
		public static void PacketRessources(int index, string packet)
		{
			Perso comtpesByIndex = Declarations.getComtpesByIndex(index);
			packet = Strings.Mid(packet, 4);
			int num = Fonctions.Gettoks(packet, "|");
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					string text = Fonctions.Gettok(packet, "|", i);
					if (Operators.CompareString(text, "", false) != 0)
					{
						Ressources ressources = new Ressources(text);
						Ressources myUsable = comtpesByIndex.map.mapDataActuel[ressources.Cellid].myUsable;
						if (Information.IsNothing(myUsable))
						{
							comtpesByIndex.map.addRessource(ressources);
						}
						else
						{
							ressources.nom = myUsable.nom;
							ressources.id = myUsable.id;
							comtpesByIndex.map.delRessourceByCellid(myUsable.Cellid);
							comtpesByIndex.map.addRessource(ressources);
						}
					}
				}
			}
		}

		// Token: 0x04000548 RID: 1352
		public int Cellid;

		// Token: 0x04000549 RID: 1353
		public string stat;

		// Token: 0x0400054A RID: 1354
		public string nom;

		// Token: 0x0400054B RID: 1355
		public int id;
	}
}
