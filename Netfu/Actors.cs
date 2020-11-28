using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000C6 RID: 198
	public class Actors
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x00002744 File Offset: 0x00000944
		public Actors()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0001FC40 File Offset: 0x0001DE40
		public static void PacketMovement(int index, string packet)
		{
			Perso comtpesByIndex = Declarations.getComtpesByIndex(index);
			checked
			{
				if (comtpesByIndex.Fight == null)
				{
					string text = Strings.Mid(packet, 4);
					string[] array = text.Split(new char[]
					{
						'|'
					});
					int num = array.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Operators.CompareString(Strings.Mid(array[i], 1, 1), "+", false) == 0)
						{
							string[] array2 = array[i].Split(new char[]
							{
								';'
							});
							string text2 = array2[5];
							int num2;
							if (text2.Contains(","))
							{
								num2 = Conversions.ToInteger(Strings.Split(text2, ",", -1, CompareMethod.Binary)[0]);
							}
							else
							{
								num2 = Conversions.ToInteger(text2);
							}
							if (num2 > 0)
							{
								Character character = new Character(array2);
								Character character2 = (Character)comtpesByIndex.map.getActorsById(character.Id);
								if (character2 != null && character2.dead && !character.dead)
								{
									comtpesByIndex.Send(new Message("Rr", 700, false, true, true));
								}
								comtpesByIndex.map.RemoveActorById(character.Id);
								comtpesByIndex.map.addActor(character);
								if (comtpesByIndex.config.activeFlood && comtpesByIndex.config.floodMp)
								{
									comtpesByIndex.Send(new Message(string.Concat(new string[]
									{
										"BM",
										character.nom,
										"|",
										comtpesByIndex.config.floodPhrase.Replace("%pseudo%", character.nom),
										Fonctions.Smiley(comtpesByIndex.rand),
										"|"
									}), comtpesByIndex.rand.Next(1500, 5000), true, true, true));
								}
							}
							else if ((double)num2 == Conversions.ToDouble("-3"))
							{
								MonsterGroupe monsterGroupe = new MonsterGroupe(array2);
								comtpesByIndex.map.RemoveActorById(monsterGroupe.Id);
								comtpesByIndex.map.addActor(monsterGroupe);
							}
							else if ((double)num2 == Conversions.ToDouble("-4"))
							{
								NPC npc = new NPC(array2);
								comtpesByIndex.map.RemoveActorById(npc.Id);
								comtpesByIndex.map.addActor(npc);
							}
							else if (num2 == -5)
							{
								Merchant merchant = new Merchant(array2);
								comtpesByIndex.map.RemoveActorById(merchant.Id);
								comtpesByIndex.map.addActor(merchant);
							}
						}
						else if (Operators.CompareString(Strings.Mid(array[i], 1, 1), "-", false) == 0)
						{
							string value = Strings.Mid(array[i], 2);
							comtpesByIndex.map.RemoveActorById(Conversions.ToInteger(value));
						}
					}
					if (Declarations.getComtpesByIndex(index).config.Merchant)
					{
						Declarations.getComtpesByIndex(index).ExchangeManager.checkMerchant();
					}
				}
				else
				{
					comtpesByIndex.Fight.OnFighterMove(packet);
				}
			}
		}

		// Token: 0x0400046F RID: 1135
		public int Id;

		// Token: 0x04000470 RID: 1136
		public int Cell;
	}
}
