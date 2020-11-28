using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using WindowsApplication2;

// Token: 0x020000D0 RID: 208
[StandardModule]
internal sealed class Class12
{
	// Token: 0x06000448 RID: 1096 RVA: 0x00020B90 File Offset: 0x0001ED90
	public static void smethod_0(int int_0, string string_0)
	{
		Perso comtpesByIndex = Declarations.getComtpesByIndex(int_0);
		checked
		{
			if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "HC", false) == 0)
			{
				Declarations.getComtpesByIndex(int_0).Fight = null;
				comtpesByIndex.Send(new Message(comtpesByIndex.MyServer().version, 0, true, false, false));
				string data = comtpesByIndex.config.nomDuCompte + "\n" + Fonctions.PassEnc(comtpesByIndex.config.passDuCompte, Strings.Mid(string_0, 3));
				comtpesByIndex.Send(new Message(data, 0, true, false, false));
				comtpesByIndex.Send(new Message("Af", 0, true, false, false));
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AlEf", false) == 0)
			{
				comtpesByIndex.status.connexion = status.ConnexionStatus.Mauvais_Mot_de_passe;
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AlEb", false) == 0)
			{
				comtpesByIndex.status.connexion = status.ConnexionStatus.Compte_Bannie;
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AlEk", false) == 0)
			{
				string[] array = string_0.Substring(4).Split(new char[]
				{
					'|'
				});
				comtpesByIndex.status.connexion = status.ConnexionStatus.Compte_Bannie;
				if (array.Length > 2 && (Conversions.ToDouble(array[0]) > 0.0 && Conversions.ToDouble(array[1]) > 22.0))
				{
					Declarations.disconnectAllComptes(comtpesByIndex.MyServer().idServer);
				}
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AlEv", false) == 0)
			{
				Strings.Mid(string_0, 5);
				comtpesByIndex.MyServer().version = Strings.Mid(string_0, 5);
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "ATK", false) == 0 && string_0.Length > 4)
			{
				comtpesByIndex.keyProtocol = string_0.Substring(3);
				comtpesByIndex.nkey = int.Parse(Conversions.ToString(comtpesByIndex.keyProtocol[0]), NumberStyles.AllowParentheses);
				comtpesByIndex.keyProtocol = Conversions.ToString(Fonctions.prepareKey(comtpesByIndex.keyProtocol.Substring(1)));
			}
			else if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "Ax", false) != 0)
			{
				if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "AH", false) == 0)
				{
					string[] array2 = string_0.Substring(2).Split(new char[]
					{
						'|'
					});
					foreach (string text in array2)
					{
						string[] array4 = text.Split(new char[]
						{
							';'
						});
						if (Conversions.ToDouble(array4[0]) == (double)Declarations.getComtpesByIndex(int_0).MyServer().idServer && (Conversions.ToDouble(array4[1]) != 1.0 || Conversions.ToDouble(array4[3]) > 1.0))
						{
							comtpesByIndex.status.connexion = status.ConnexionStatus.Serveur_en_Sauvegarde;
						}
					}
					if (comtpesByIndex.status.connexion != status.ConnexionStatus.Serveur_en_Sauvegarde)
					{
						comtpesByIndex.MessagesToSend.Clear();
						Class12.smethod_1(Declarations.getComtpesByIndex(int_0));
					}
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AXEf", false) == 0)
				{
					comtpesByIndex.MessagesToSend.Clear();
					comtpesByIndex.Send(new Message("AX" + Conversions.ToString(comtpesByIndex.MyServer().idServer), 10500, true, true, false));
					comtpesByIndex.status.connexion = status.ConnexionStatus.Serveur_Plein;
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "AXEd", false) == 0)
				{
					comtpesByIndex.status.connexion = status.ConnexionStatus.Serveur_en_Sauvegarde;
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "AXK", false) == 0)
				{
					comtpesByIndex.idConnexion = Strings.Mid(string_0, 15);
					if (!comtpesByIndex.config.mitm)
					{
						comtpesByIndex.CreateSock();
					}
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "AYK", false) == 0)
				{
					string ipServeurJeu = Fonctions.Gettok(Strings.Mid(string_0, 4), ";", 1);
					comtpesByIndex.MyServer().portGame = 443;
					comtpesByIndex.ipServeurJeu = ipServeurJeu;
					comtpesByIndex.idConnexion = Fonctions.Gettok(string_0, ";", 2);
					if (!comtpesByIndex.config.mitm)
					{
						comtpesByIndex.CreateSock();
					}
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "HG", false) == 0)
				{
					comtpesByIndex.Send(new Message("AT" + comtpesByIndex.idConnexion, 0, true, false, false));
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "ATK", false) == 0)
				{
					comtpesByIndex.Send(new Message("Ak0", 0, false, false, false));
					comtpesByIndex.Send(new Message("AV", -1, false, false, false));
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "AQ", false) == 0)
				{
					comtpesByIndex.Send(new Message("Ax", 0, true, false, false));
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "AV", false) == 0)
				{
					if (comtpesByIndex.MyServer().idServer == 6002)
					{
						comtpesByIndex.Send(new Message("Agen", 0, true, false, false));
					}
					else
					{
						comtpesByIndex.Send(new Message("Agfr", 0, true, false, false));
					}
					comtpesByIndex.Send(new Message("AL", -1, false, false, false));
					comtpesByIndex.Send(new Message("Af", 0, false, false, false));
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "ALK", false) == 0)
				{
					int num = 1 + comtpesByIndex.config.numeroPerso;
					if (string_0.Split(new char[]
					{
						'|'
					}).Count<string>() <= num)
					{
						comtpesByIndex.status.connexion = status.ConnexionStatus.Mauvaise_Configuration;
					}
					else
					{
						string gettokText = Fonctions.Gettok(string_0, "|", 2 + comtpesByIndex.config.numeroPerso);
						string text2 = Fonctions.Gettok(gettokText, ";", 1);
						comtpesByIndex.monIdDofus = text2;
						comtpesByIndex.Send(new Message("AS" + text2, 0, true, true, false));
					}
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 3), "ASK", false) == 0)
				{
					comtpesByIndex.status.connexion = status.ConnexionStatus.const_3;
					comtpesByIndex.Send(new Message("GC1", 0, true, false, false));
					comtpesByIndex.Send(new Message("FL", new Random().Next(500, 600), true, false, false));
					comtpesByIndex.Send(new Message("Rr", 1000, false, true, false));
				}
				else if (Operators.CompareString(Strings.Mid(string_0, 1, 2), "Af", false) == 0)
				{
					comtpesByIndex.status.fileAttentePlace = Conversions.ToInteger(string_0.Substring(2).Split(new char[]
					{
						'|'
					})[0]);
					comtpesByIndex.status.connexion = status.ConnexionStatus.File_Attente;
					Declarations.getComtpesByIndex(int_0).Send(new Message("Af", 3000, false, false, false));
				}
			}
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x000212D0 File Offset: 0x0001F4D0
	private static void smethod_1(Perso perso_0)
	{
		perso_0.MessagesToSend.Clear();
		perso_0.identity = Conversions.ToString(Fonctions.getRandomNetworkKey());
		perso_0.Send(new Message("Ai" + perso_0.identity, 200, false, false, true));
		perso_0.Send(new Message("AX" + Conversions.ToString(perso_0.MyServer().idServer), 800, true, true, false));
	}
}
