using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000B3 RID: 179
[StandardModule]
internal sealed class Class9
{
	// Token: 0x060003B4 RID: 948 RVA: 0x0001CC24 File Offset: 0x0001AE24
	static Class9()
	{
		Class15.XRATSHnz66atd();
		Class9.dictionary_0 = new Dictionary<string, short>();
		Class9.bool_0 = false;
		Class9.string_0 = new string[]
		{
			"_a",
			"_b",
			"_c",
			"_d",
			"_e",
			"_f",
			"_g",
			"_h",
			"_i",
			"_j",
			"_k",
			"_l",
			"_m",
			"_n",
			"_o",
			"_p",
			"_q",
			"_r",
			"_s",
			"_t",
			"_u",
			"_v",
			"_w",
			"_x",
			"_y",
			"_z",
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
		Class9.string_1 = new string[]
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
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0001D0CC File Offset: 0x0001B2CC
	private static void smethod_0()
	{
		checked
		{
			for (int i = Class9.string_1.Length - 1; i >= 0; i--)
			{
				Class9.dictionary_0.Add(Class9.string_1[i], (short)i);
			}
			Class9.bool_0 = true;
		}
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0001D10C File Offset: 0x0001B30C
	public static int smethod_1(char char_0)
	{
		if (!Class9.bool_0)
		{
			Class9.smethod_0();
		}
		return (int)Class9.dictionary_0[Conversions.ToString(char_0)];
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0001D13C File Offset: 0x0001B33C
	public static char smethod_2(int int_0)
	{
		if (!Class9.bool_0)
		{
			Class9.smethod_0();
		}
		return Conversions.ToChar(Class9.string_1[int_0]);
	}

	// Token: 0x04000421 RID: 1057
	private static Dictionary<string, short> dictionary_0;

	// Token: 0x04000422 RID: 1058
	private static bool bool_0;

	// Token: 0x04000423 RID: 1059
	private static string[] string_0;

	// Token: 0x04000424 RID: 1060
	private static string[] string_1;
}
