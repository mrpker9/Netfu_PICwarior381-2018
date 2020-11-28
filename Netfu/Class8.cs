using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using WindowsApplication2;

// Token: 0x020000A7 RID: 167
internal class Class8
{
	// Token: 0x0600037C RID: 892 RVA: 0x00002744 File Offset: 0x00000944
	public Class8()
	{
		Class15.XRATSHnz66atd();
		base..ctor();
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0001BC68 File Offset: 0x00019E68
	public static string smethod_0(string string_0)
	{
		MD5 md = MD5.Create();
		byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0001BCCC File Offset: 0x00019ECC
	public static string smethod_1(string string_0, string string_1)
	{
		string_1 = Fonctions.RemoveDiacritics(string_1);
		string_0 = Fonctions.RemoveDiacritics(string_0);
		byte[] bytes = Encoding.Default.GetBytes(string_0);
		byte[] bytes2 = Encoding.Default.GetBytes(string_1);
		string text = "";
		checked
		{
			int num = bytes.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2;
				int num3;
				unchecked
				{
					bytes[i] += bytes2[i % bytes2.Length];
					num2 = 0;
					num3 = i;
				}
				for (int j = 0; j <= num3; j++)
				{
					num2 += (int)(bytes[i] * bytes2[j % bytes2.Length]);
				}
				text = text + num2.ToString() + ((i < bytes.Length - 1) ? "." : "");
			}
			return text;
		}
	}

	// Token: 0x0600037F RID: 895 RVA: 0x0001BD84 File Offset: 0x00019F84
	public static string smethod_2(string string_0, string string_1, int int_0)
	{
		string text = string_0;
		checked
		{
			int num = int_0 - 1;
			for (int i = 0; i <= num; i++)
			{
				text = Class8.smethod_1(text, string_1 + i.ToString());
			}
			return text;
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0001BDBC File Offset: 0x00019FBC
	public static string smethod_3(string string_0, string string_1, int int_0)
	{
		string text = string_0;
		checked
		{
			int num = int_0 - 1;
			for (int i = num; i >= 0; i += -1)
			{
				text = Class8.smethod_4(text, string_1 + i.ToString());
			}
			return text;
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0001BDF4 File Offset: 0x00019FF4
	public static string smethod_4(string string_0, string string_1)
	{
		byte[] bytes = Encoding.Default.GetBytes(string_1);
		List<byte> list = new List<byte>();
		string[] array = string_0.Split(new char[]
		{
			'.'
		}, StringSplitOptions.RemoveEmptyEntries);
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = 0;
				int num3 = i;
				for (int j = 0; j <= num3; j++)
				{
					num2 += int.Parse(Conversions.ToString(bytes[j % bytes.Length]));
				}
				num2 = (int)Math.Round((double)int.Parse(array[i]) / (double)num2);
				list.Add((byte)(num2 - int.Parse(Conversions.ToString(bytes[i % bytes.Length]))));
			}
			return new string(Encoding.Default.GetChars(list.ToArray()));
		}
	}
}
