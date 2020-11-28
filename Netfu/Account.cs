using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000059 RID: 89
	[StandardModule]
	public sealed class Account
	{
		// Token: 0x060001CE RID: 462
		[DllImport("USER32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

		// Token: 0x060001CF RID: 463
		[DllImport("USER32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060001D0 RID: 464 RVA: 0x0000FACC File Offset: 0x0000DCCC
		public static void WriteAccounts()
		{
			StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "/data/accounts.txt");
			try
			{
				streamWriter.WriteLine(Declarations.ComptesNames());
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				streamWriter.Close();
				Interaction.MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Error : Account.vb --> WriteAccounts");
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public static void AutoLogin(Perso p, Process pro)
		{
			IntPtr mainWindowHandle = pro.MainWindowHandle;
			Account.SetForegroundWindow(mainWindowHandle);
			Input.Text(p.config.nomDuCompte, pro, 6500);
			Input.SendKey(9, pro, 7000, null);
			Input.Text(p.config.passDuCompte, pro, 7600);
			Input.SendKey(9, pro, 8000, null);
			Input.SendKey(13, pro, 8100, null);
			Input.SendKey(9, pro, 8200, null);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000FBC0 File Offset: 0x0000DDC0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static void DelAccount(string account, bool modify = false)
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "/data/accounts.txt");
				FileSystem.Kill(Application.StartupPath + "/saves/" + account + ".bot");
				if (!modify)
				{
					if (Declarations.nbCompte() == 0)
					{
						streamWriter.WriteLine("");
					}
					else
					{
						string value = Declarations.ComptesNames().Replace(account, "").Replace("||", "|");
						streamWriter.WriteLine(value);
					}
				}
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Error : Account.vb --> DelAccount()");
			}
		}
	}
}
