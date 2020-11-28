using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000062 RID: 98
	public class GlobalConfig
	{
		// Token: 0x06000200 RID: 512 RVA: 0x00003356 File Offset: 0x00001556
		static GlobalConfig()
		{
			Class15.XRATSHnz66atd();
			GlobalConfig.decoBan = true;
			GlobalConfig.timeModo = 5;
			GlobalConfig.notifBank = false;
			GlobalConfig.notifMp = false;
			GlobalConfig.notifLevelUP = false;
			GlobalConfig.licenceExpiration = DateTime.Now;
			GlobalConfig.serveurPath = "";
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00002744 File Offset: 0x00000944
		public GlobalConfig()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00010C0C File Offset: 0x0000EE0C
		public static void Load()
		{
			try
			{
				string path = Application.StartupPath + "/data/globalconf.txt";
				if (!File.Exists(path))
				{
					FileStream fileStream = File.Create(path);
					fileStream.Close();
				}
				else
				{
					StreamReader streamReader = new StreamReader(path);
					GlobalConfig.timeModo = Conversions.ToInteger(streamReader.ReadLine());
					GlobalConfig.tokenNotif = streamReader.ReadLine();
					GlobalConfig.notifBank = Conversions.ToBoolean(streamReader.ReadLine());
					GlobalConfig.notifMp = Conversions.ToBoolean(streamReader.ReadLine());
					GlobalConfig.notifLevelUP = Conversions.ToBoolean(streamReader.ReadLine());
					GlobalConfig.decoBan = Conversions.ToBoolean(streamReader.ReadLine());
					streamReader.Close();
				}
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00010CD4 File Offset: 0x0000EED4
		public static void Save()
		{
			string path = Application.StartupPath + "/data/globalconf.txt";
			if (!File.Exists(path))
			{
				FileStream fileStream = File.Create(path);
				fileStream.Close();
			}
			StreamWriter streamWriter = new StreamWriter(path);
			streamWriter.WriteLine(GlobalConfig.timeModo);
			streamWriter.WriteLine(GlobalConfig.tokenNotif);
			streamWriter.WriteLine(GlobalConfig.notifBank);
			streamWriter.WriteLine(GlobalConfig.notifMp);
			streamWriter.WriteLine(GlobalConfig.notifLevelUP);
			streamWriter.WriteLine(GlobalConfig.decoBan);
			streamWriter.Close();
		}

		// Token: 0x04000276 RID: 630
		public static bool decoBan;

		// Token: 0x04000277 RID: 631
		public static int timeModo;

		// Token: 0x04000278 RID: 632
		public static string tokenNotif;

		// Token: 0x04000279 RID: 633
		public static bool notifBank;

		// Token: 0x0400027A RID: 634
		public static bool notifMp;

		// Token: 0x0400027B RID: 635
		public static bool notifLevelUP;

		// Token: 0x0400027C RID: 636
		public static DateTime licenceExpiration;

		// Token: 0x0400027D RID: 637
		public static string serveurPath;

		// Token: 0x0400027E RID: 638
		public static string key;

		// Token: 0x0400027F RID: 639
		public static string code;
	}
}
