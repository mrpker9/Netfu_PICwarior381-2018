using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x020000B4 RID: 180
	public class Fonctions
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x0001D168 File Offset: 0x0001B368
		static Fonctions()
		{
			Class15.XRATSHnz66atd();
			Fonctions.rand = new Random();
			Fonctions.HEX_CHARS = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F"
			};
			Fonctions.ZKARRAY = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
			Fonctions.wordsTranslate = new Dictionary<string, string>();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00002744 File Offset: 0x00000944
		public Fonctions()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x060003BA RID: 954
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int FreeConsole();

		// Token: 0x060003BB RID: 955 RVA: 0x0001D22C File Offset: 0x0001B42C
		private static string smethod_0(string string_0)
		{
			return HttpUtility.UrlDecode(string_0);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00002B9E File Offset: 0x00000D9E
		public static void traiterErreur(Exception e)
		{
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001D244 File Offset: 0x0001B444
		public static object prepareKey(string key)
		{
			if (key.IndexOf("BT1") > 0)
			{
				key = key.Substring(0, key.IndexOf("BT1"));
			}
			string text = "";
			int i = 0;
			checked
			{
				while (i < key.Length)
				{
					try
					{
						if (i + 2 <= key.Length)
						{
							text += Conversions.ToString(Strings.Chr((int)Convert.ToInt64(key.Substring(i, 2), 16)));
							i += 2;
						}
						else
						{
							text += Conversions.ToString(Strings.Chr((int)Convert.ToInt64(key.Substring(i, 1), 16)));
							i++;
						}
					}
					catch (Exception ex)
					{
						text = text.Substring(0, text.Length - 1);
						break;
					}
				}
				text = Fonctions.smethod_0(text);
				return text;
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0001D324 File Offset: 0x0001B524
		public static object getRandomNetworkKey()
		{
			double num = Math.Round(new Random().NextDouble() * 20.0) + 10.0;
			string text = "";
			while (0.0 < num)
			{
				text = Conversions.ToString(Operators.ConcatenateObject(text, Fonctions.getRandomChar()));
				num -= 1.0;
			}
			object obj = Operators.ConcatenateObject(Fonctions.checksum(text), text);
			return Operators.ConcatenateObject(obj, Fonctions.checksum(Conversions.ToString(obj)));
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0001D3A8 File Offset: 0x0001B5A8
		public static object getRandomChar()
		{
			object result;
			try
			{
				result = Fonctions.ZKARRAY[Fonctions.rand.Next(Fonctions.ZKARRAY.Count<char>())];
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
			return result;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0001D404 File Offset: 0x0001B604
		public static object unprepareData(string key, string data)
		{
			object result;
			if (string.IsNullOrWhiteSpace(key))
			{
				result = data;
			}
			else
			{
				object left;
				try
				{
					left = Convert.ToInt32(data.Substring(0, 1), 16);
				}
				catch (Exception ex)
				{
					left = -1;
				}
				if (Operators.ConditionalCompareObjectNotEqual(left, 1, false))
				{
					result = "";
				}
				else
				{
					string text = data.Substring(1, 1).ToUpper();
					object objectValue = RuntimeHelpers.GetObjectValue(Fonctions.decypherData(data.Substring(2), key, checked(Convert.ToInt32(text, 16) * 2)));
					if (Operators.ConditionalCompareObjectNotEqual(Fonctions.checksum(Conversions.ToString(objectValue)), text, false))
					{
						result = data;
					}
					else
					{
						result = objectValue;
					}
				}
			}
			return result;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0001D4BC File Offset: 0x0001B6BC
		public static object prepareData(int nKey, string key, string data)
		{
			object result;
			if (string.IsNullOrWhiteSpace(key))
			{
				result = data;
			}
			else
			{
				string text = Fonctions.HEX_CHARS[nKey];
				char value = Conversions.ToChar(Fonctions.checksum(data));
				text += Conversions.ToString(value);
				result = Operators.ConcatenateObject(text, Fonctions.smethod_1(data, key, checked(Convert.ToInt32(Conversions.ToString(value), 16) * 2)));
			}
			return result;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0001D514 File Offset: 0x0001B714
		public static object decypherData(string d, string k, int c)
		{
			string text = "";
			int length = k.Length;
			int num = 0;
			checked
			{
				for (int i = 0; i < d.Length; i += 2)
				{
					int num2 = Convert.ToInt32(d.Substring(i, 2), 16);
					int num3 = Strings.Asc(k.Substring((num + c) % length, 1));
					text += Conversions.ToString(Strings.Chr(num2 ^ num3));
					num++;
				}
				return Fonctions.smethod_0(text);
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001D590 File Offset: 0x0001B790
		private static object smethod_1(string string_0, string string_1, int int_0)
		{
			string text = "";
			int length = string_1.Length;
			string_0 = Conversions.ToString(Fonctions.smethod_3(string_0));
			checked
			{
				for (int i = 0; i < string_0.Length; i++)
				{
					int num = Convert.ToInt32(string_0[i]);
					int num2 = Convert.ToInt32(string_1[(i + int_0) % length]);
					text += Fonctions.smethod_2(num ^ num2);
				}
				return text;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001D600 File Offset: 0x0001B800
		private static string smethod_2(int int_0)
		{
			if (int_0 > 255)
			{
				int_0 = 189;
			}
			return Fonctions.HEX_CHARS[checked((int)Math.Round(Math.Floor((double)int_0 / 16.0)))] + Fonctions.HEX_CHARS[int_0 % 16];
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001D64C File Offset: 0x0001B84C
		private static object smethod_3(string string_0)
		{
			string text = "";
			checked
			{
				for (int i = 0; i < string_0.Length; i++)
				{
					char value = string_0[i];
					int num = Convert.ToInt32(string_0[i]);
					if (num < 32 || num > 127 || Operators.CompareString(Conversions.ToString(value), "%", false) == 0 || Operators.CompareString(Conversions.ToString(value), "+", false) == 0)
					{
						text += Conversions.ToString(value);
					}
					else
					{
						text += Conversions.ToString(value);
					}
				}
				return text;
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001D6E4 File Offset: 0x0001B8E4
		public static object checksum(string s)
		{
			string value = Conversions.ToString(0);
			string value2 = Conversions.ToString(0);
			while (Conversions.ToDouble(value2) < (double)s.Length)
			{
				value = Conversions.ToString(Conversions.ToDouble(value) + (double)(Strings.Asc(s.Substring(Conversions.ToInteger(value2), 1)) % 16));
				value2 = Conversions.ToString(Conversions.ToDouble(value2) + 1.0);
			}
			return Fonctions.HEX_CHARS[checked((int)Math.Round(Conversions.ToDouble(value) % 16.0))];
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001D76C File Offset: 0x0001B96C
		public static object hashCodes(string a)
		{
			return Fonctions.ZKARRAY.IndexOf(a);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004257 File Offset: 0x00002457
		public static bool IsMainThread()
		{
			return Thread.CurrentThread.ManagedThreadId == Fonctions.mainThreadId;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001D78C File Offset: 0x0001B98C
		public static void getProxy()
		{
			WebClient webClient = new WebClient();
			Declarations.proxys = webClient.DownloadString("https://api.proxyscrape.com/?request=getproxies&proxytype=socks4&timeout=1000&country=all").Split(new char[]
			{
				'\r'
			}).ToList<string>();
			Declarations.proxys5 = webClient.DownloadString("https://api.proxyscrape.com/?request=getproxies&proxytype=socks5&timeout=1500&country=all").Split(new char[]
			{
				'\r'
			}).ToList<string>();
			webClient.Dispose();
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0001D7F0 File Offset: 0x0001B9F0
		public static void sendNotif(string msg)
		{
			Task.Run(delegate()
			{
				if (!string.IsNullOrWhiteSpace(GlobalConfig.tokenNotif))
				{
					string requestUriString = string.Concat(new string[]
					{
						"https://pushfleet.com/api/v1/send?appid=AETMVKEH&userid=",
						GlobalConfig.tokenNotif,
						"&message='",
						msg,
						"'&url='about:blank'"
					});
					WebRequest webRequest = WebRequest.Create(requestUriString);
					webRequest.Timeout = 50000;
					WebResponse response = webRequest.GetResponse();
					response.Close();
				}
			});
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0001D81C File Offset: 0x0001BA1C
		public static List<Control> FindControlRecursive(List<Control> list, Control parent)
		{
			List<Control> result;
			if (parent == null)
			{
				result = list;
			}
			else
			{
				list.Add(parent);
				try
				{
					foreach (object obj in parent.Controls)
					{
						Control parent2 = (Control)obj;
						Fonctions.FindControlRecursive(list, parent2);
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				result = list;
			}
			return result;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0001D890 File Offset: 0x0001BA90
		public static string Smiley(Random r)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			StringBuilder stringBuilder = new StringBuilder();
			int num = r.Next(3, 15);
			int num2 = num;
			checked
			{
				for (int i = 1; i <= num2; i++)
				{
					int startIndex = r.Next(0, text.Length);
					stringBuilder.Append(text.Substring(startIndex, 1));
				}
				return " " + stringBuilder.ToString();
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		public static string RandomKey(bool Islettre, bool Ischiffre, bool Issymbol)
		{
			Random random = new Random();
			string text = "";
			if (Islettre)
			{
				text += Declarations.lettre;
			}
			if (Ischiffre)
			{
				text += Declarations.chiffre;
			}
			if (Issymbol)
			{
				text += Declarations.symbole;
			}
			string text2 = "";
			checked
			{
				if (text.Length > 1)
				{
					int num = random.Next(3, 4);
					for (int i = 1; i <= num; i++)
					{
						text2 += Conversions.ToString(text[random.Next(0, text.Length - 1)]);
					}
				}
				return text2;
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0001D990 File Offset: 0x0001BB90
		public static int Gettoks(string GettokText, string GettokStr)
		{
			return GettokText.Split(new char[]
			{
				Conversions.ToChar(GettokStr)
			}).Length;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001D9B8 File Offset: 0x0001BBB8
		public static string Gettok(string GettokText, string GettokStr, int GettokNum)
		{
			checked
			{
				GettokNum--;
				string[] array = GettokText.Split(new char[]
				{
					Conversions.ToChar(GettokStr)
				});
				return array[GettokNum];
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		public static string PassEnc(string pwd, string key)
		{
			string text = "#1";
			string[] array = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"I",
				"J",
				"K",
				"L",
				"M",
				"N",
				"O",
				"P",
				"Q",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z",
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"-",
				"_"
			};
			int num = Strings.Len(pwd);
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					int num2 = Strings.Asc(Strings.Mid(pwd, i, 1));
					int num3 = Strings.Asc(Strings.Mid(key, i, 1));
					int num4 = (int)Math.Round(Conversion.Fix((double)num2 / 16.0));
					int num5 = num2 % 16;
					string str = array[(num4 + num3) % (Information.UBound(array, 1) + 1) % (Information.UBound(array, 1) + 1)];
					string str2 = array[(num5 + num3) % (Information.UBound(array, 1) + 1) % (Information.UBound(array, 1) + 1)];
					text = text + str + str2;
				}
				return text;
			}
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
		public static string GetHash(string theInput)
		{
			checked
			{
				string result;
				using (MD5 md = MD5.Create())
				{
					byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(theInput));
					StringBuilder stringBuilder = new StringBuilder();
					int num = array.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						stringBuilder.Append(array[i].ToString("X2"));
					}
					result = stringBuilder.ToString();
				}
				return result;
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00011B04 File Offset: 0x0000FD04
		public static void InitializeCells()
		{
			int num = 0;
			string[] array = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"I",
				"J",
				"K",
				"L",
				"M",
				"N",
				"O",
				"P",
				"Q",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z",
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"-",
				"_"
			};
			string[] array2 = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z"
			};
			checked
			{
				int num2 = array2.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = array.Length - 1;
					for (int j = 0; j <= num3; j++)
					{
						Declarations.cases[num] = array2[i] + array[j];
						num++;
					}
				}
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001DD64 File Offset: 0x0001BF64
		public static string RemoveDiacritics(string text)
		{
			string result;
			if (string.IsNullOrWhiteSpace(text))
			{
				result = text;
			}
			else
			{
				text = text.Normalize(NormalizationForm.FormD);
				char[] value = text.Where((Fonctions._Closure$__.$I32-0 == null) ? (Fonctions._Closure$__.$I32-0 = ((char c) => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)) : Fonctions._Closure$__.$I32-0).ToArray<char>();
				result = new string(value).Normalize(NormalizationForm.FormC);
			}
			return result;
		}

		// Token: 0x04000425 RID: 1061
		public static int mainThreadId;

		// Token: 0x04000426 RID: 1062
		public static Random rand;

		// Token: 0x04000427 RID: 1063
		public static string[] HEX_CHARS;

		// Token: 0x04000428 RID: 1064
		public static string ZKARRAY;

		// Token: 0x04000429 RID: 1065
		public static Dictionary<string, string> wordsTranslate;
	}
}
