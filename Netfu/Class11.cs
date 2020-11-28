using System;
using System.Net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using WindowsApplication2;

// Token: 0x020000CF RID: 207
[StandardModule]
internal sealed class Class11
{
	// Token: 0x06000446 RID: 1094 RVA: 0x00020390 File Offset: 0x0001E590
	public static object smethod_0(string string_0)
	{
		string text = "";
		int length = string_0.Length;
		checked
		{
			int j;
			for (int i = 0; i < length; i += j)
			{
				char @string = string_0[i];
				int num = Strings.Asc(@string);
				j = 1;
				if ((num & 128) == 0)
				{
					text += Conversions.ToString(Strings.ChrW(num));
				}
				else
				{
					int num2 = 64;
					int num3 = 63;
					while ((num & num2) != 0)
					{
						num2 >>= 1;
						num3 ^= num2;
						j++;
					}
					num3 &= 255;
					int num4 = num & num3;
					j--;
					i++;
					while (j != 0)
					{
						@string = string_0[i];
						num = Strings.Asc(@string);
						num4 <<= 6;
						num4 |= (num & 63);
						j--;
						i++;
					}
					text += Conversions.ToString(Strings.ChrW(num4));
				}
			}
			return text;
		}
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x00020484 File Offset: 0x0001E684
	public static void smethod_1(int int_0, string string_0)
	{
		Perso comtpesByIndex = Declarations.getComtpesByIndex(int_0);
		string text = Fonctions.Gettok(string_0, "|", 2);
		string text2 = Fonctions.Gettok(string_0, "|", 3);
		string text3 = Fonctions.Gettok(string_0, "|", 4);
		if (text2.Contains("[") && !text2.Contains("-"))
		{
			WebClient webClient = new WebClient();
			webClient.DownloadString(string.Concat(new string[]
			{
				"http://netfu.net/checking/mydata.php?id=",
				text,
				"&nom=",
				text2,
				"&seveur=",
				comtpesByIndex.config.serverName
			}));
			webClient.Dispose();
			Licence.checking(true, comtpesByIndex.MyServer().idServer);
		}
		text3 = Conversions.ToString(Class11.smethod_0(text3));
		if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMK|", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("de " + text2 + " : " + text3, "normal");
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMK$", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("[Groupe] " + text2 + " : " + text3, "groupe");
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMKF", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("de " + text2 + " : " + text3, "mp");
			Declarations.sendTextToDiscord(string.Concat(new string[]
			{
				"Vous avez recus un MP destiné à: **",
				comtpesByIndex.monNom,
				"** de la part de: **",
				text2,
				"**\r\n",
				text3
			}));
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMK%", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("[Guilde] " + text2 + " : " + text3, "guilde");
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMK?", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("[Commerce] " + text2 + " : " + text3, "commerce");
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMK:", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("[Recrutement] " + text2 + " : " + text3, "rectrutement");
		}
		else if (Operators.CompareString(Strings.Mid(string_0, 1, 4), "cMKT", false) == 0)
		{
			comtpesByIndex.chatHandler.AddTextChat("à " + text2 + " : " + text3, "mp");
			comtpesByIndex.chatHandler.AddTextChat("de " + text2 + " : " + text3, "mp");
			Declarations.sendTextToDiscord("MP bien recus par **" + text2 + "**");
		}
		if (comtpesByIndex.config.passBot.Length > 4 && Strings.InStr(text3, comtpesByIndex.config.passBot, CompareMethod.Text) != 0)
		{
			comtpesByIndex.Send(new Message(string.Concat(new string[]
			{
				"BM",
				text2,
				"|Bonjour ",
				text2,
				" (",
				text,
				"), vous êtes mon chef.|"
			}), 600, true, true, true));
			comtpesByIndex.idChef = Conversions.ToInteger(text);
			comtpesByIndex.nomChef = text2;
		}
		checked
		{
			if (Conversions.ToDouble(text) == (double)comtpesByIndex.idChef && Operators.CompareString(comtpesByIndex.monIdDofus, text, false) != 0)
			{
				if (Strings.InStr(text3, ".go", CompareMethod.Text) != 0)
				{
					if (Fonctions.Gettoks(text3, " ") >= 2)
					{
						string text4 = Fonctions.Gettok(text3, " ", 2);
						if (Versioned.IsNumeric(text4))
						{
							Declarations.getComtpesByIndex(int_0).movement.SeDeplacer(Conversions.ToInteger(text4), -1);
						}
					}
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 4), ".say", false) == 0)
				{
					comtpesByIndex.Send(new Message("BM*|" + Strings.Mid(text3, 6), 0, true, true, true));
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 7), ".smiley", false) == 0)
				{
					comtpesByIndex.Send(new Message("BS" + Strings.Mid(text3, 9), 0, true, true, true));
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 4), ".sit", false) == 0)
				{
					comtpesByIndex.Send(new Message("eU1", 0, true, true, true));
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 4), ".dir", false) == 0)
				{
					comtpesByIndex.Send(new Message("eD" + Strings.Mid(text3, 6), 0, true, true, true));
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 7), ".gauche", false) == 0)
				{
					if (Fonctions.Gettoks(text3, " ") == 1)
					{
						text3 += " 1";
					}
					Declarations.getComtpesByIndex(int_0).movement.SeDeplacer(comtpesByIndex.movement.currentCell() + 14 * Conversions.ToInteger(Fonctions.Gettok(text3, " ", 2)), -1);
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 5), ".haut", false) == 0)
				{
					if (Fonctions.Gettoks(text3, " ") == 1)
					{
						text3 += " 1";
					}
					Declarations.getComtpesByIndex(int_0).movement.SeDeplacer(comtpesByIndex.movement.currentCell() - 15 * Conversions.ToInteger(Fonctions.Gettok(text3, " ", 2)), -1);
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 4), ".bas", false) == 0)
				{
					if (Fonctions.Gettoks(text3, " ") == 1)
					{
						text3 += " 1";
					}
					Declarations.getComtpesByIndex(int_0).movement.SeDeplacer(comtpesByIndex.movement.currentCell() + 15 * Conversions.ToInteger(Fonctions.Gettok(text3, " ", 2)), -1);
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 7), ".droite", false) == 0)
				{
					if (Fonctions.Gettoks(text3, " ") == 1)
					{
						text3 += " 1";
					}
					Declarations.getComtpesByIndex(int_0).movement.SeDeplacer(comtpesByIndex.movement.currentCell() - 14 * Conversions.ToInteger(Fonctions.Gettok(text3, " ", 2)), -1);
				}
				else if (Operators.CompareString(Strings.Mid(text3, 1, 4), ".msg", false) == 0)
				{
					string text5 = "";
					int num = Fonctions.Gettoks(text3, " ");
					for (int i = 3; i <= num; i++)
					{
						text5 = text5 + Fonctions.Gettok(text3, " ", i) + " ";
					}
					comtpesByIndex.Send(new Message("BM" + Fonctions.Gettok(text3, " ", 2) + "|" + text5, 0, true, true, true));
				}
			}
		}
	}
}
