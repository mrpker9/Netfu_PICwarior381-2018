using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200006A RID: 106
	public class Input
	{
		// Token: 0x0600022C RID: 556 RVA: 0x00003479 File Offset: 0x00001679
		static Input()
		{
			Class15.XRATSHnz66atd();
			Input.list_0 = new List<Thread>();
			Input.int_0 = 0;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00002744 File Offset: 0x00000944
		public Input()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x0600022E RID: 558
		[DllImport("USER32.DLL")]
		private static extern IntPtr FindWindow(string string_0, string string_1);

		// Token: 0x0600022F RID: 559
		[DllImport("USER32.DLL", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, int int_1, int int_2);

		// Token: 0x06000230 RID: 560
		[DllImport("USER32.DLL", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		private static extern IntPtr SendMessage_1(IntPtr intptr_0, uint uint_0, string string_0, int int_1);

		// Token: 0x06000231 RID: 561
		[DllImport("USER32.DLL")]
		private static extern byte VkKeyScan(char char_0);

		// Token: 0x06000232 RID: 562
		[DllImport("USER32.DLL", SetLastError = true)]
		private static extern IntPtr FindWindowEx(IntPtr intptr_0, IntPtr intptr_1, string string_0, string string_1);

		// Token: 0x06000233 RID: 563 RVA: 0x0001267C File Offset: 0x0001087C
		public static void SendKey(int Key, Process p, int waitTime, Action callBack = null)
		{
			Thread thread = new Thread(delegate()
			{
				try
				{
					Thread.Sleep(waitTime);
					IntPtr mainWindowHandle = p.MainWindowHandle;
					Input.SendMessage(mainWindowHandle, 256U, Key, 0);
					Thread.Sleep(20);
					Input.SendMessage(mainWindowHandle, 257U, Key, 0);
					if (!Information.IsNothing(callBack))
					{
						callBack();
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			});
			thread.Start();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000126C4 File Offset: 0x000108C4
		public static void Text(string TXT, Process P, int waitTime)
		{
			Input._Closure$__10-0 CS$<>8__locals1 = new Input._Closure$__10-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_TXT = TXT;
			CS$<>8__locals1.$VB$Local_P = P;
			CS$<>8__locals1.$VB$Local_waitTime = waitTime;
			Thread thread = new Thread(delegate()
			{
				try
				{
					Thread.Sleep(CS$<>8__locals1.$VB$Local_waitTime);
					foreach (char value in CS$<>8__locals1.$VB$Local_TXT)
					{
						Input.SendMessage(CS$<>8__locals1.$VB$Local_P.MainWindowHandle, 258U, Convert.ToInt32(value), 0);
					}
				}
				catch (Exception e)
				{
					Fonctions.traiterErreur(e);
				}
			});
			thread.Start();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00012708 File Offset: 0x00010908
		public static void Click(int xpos, int ypos, string button, Perso p)
		{
			Process processById = Process.GetProcessById(p.config.dllId);
			IntPtr mainWindowHandle = processById.MainWindowHandle;
			int int_ = Input.smethod_0(xpos, ypos);
			if (Operators.CompareString(button, "left", false) != 0)
			{
				if (Operators.CompareString(button, "right", false) == 0)
				{
					Input.SendMessage(mainWindowHandle, 512U, 0, int_);
					Input.SendMessage(mainWindowHandle, 516U, 2, int_);
					Input.SendMessage(mainWindowHandle, 517U, 2, int_);
				}
			}
			else
			{
				Input.SendMessage(mainWindowHandle, 512U, 0, int_);
				Input.SendMessage(mainWindowHandle, 513U, 1, int_);
				Input.SendMessage(mainWindowHandle, 514U, 1, int_);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000127AC File Offset: 0x000109AC
		public static void Move(int xpos, int ypos, Perso p)
		{
			Process processById = Process.GetProcessById(p.config.dllId);
			IntPtr mainWindowHandle = processById.MainWindowHandle;
			int int_ = Input.smethod_0(xpos, ypos);
			Input.SendMessage(mainWindowHandle, 512U, 0, int_);
			Input.SendMessage(mainWindowHandle, 673U, 1, int_);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000127F8 File Offset: 0x000109F8
		public static void SurvolDown(int xpos, int ypos, Perso p)
		{
			Process processById = Process.GetProcessById(p.config.dllId);
			IntPtr mainWindowHandle = processById.MainWindowHandle;
			int int_ = Input.smethod_0(xpos, ypos);
			Input.SendMessage(mainWindowHandle, 512U, 0, int_);
			Input.SendMessage(mainWindowHandle, 673U, 1, int_);
			Input.SendMessage(mainWindowHandle, 513U, 1, int_);
			Input.SendMessage(mainWindowHandle, 513U, 1, int_);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00012860 File Offset: 0x00010A60
		public static void SurvolUp(Perso p)
		{
			Process processById = Process.GetProcessById(p.config.dllId);
			IntPtr mainWindowHandle = processById.MainWindowHandle;
			int int_ = Input.smethod_0(10, 10);
			Input.SendMessage(mainWindowHandle, 514U, 1, int_);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000128A0 File Offset: 0x00010AA0
		private static int smethod_0(int int_1, int int_2)
		{
			return int_2 << 16 | (int_1 & 65535);
		}

		// Token: 0x040002CD RID: 717
		private static List<Thread> list_0;

		// Token: 0x040002CE RID: 718
		private static int int_0;
	}
}
