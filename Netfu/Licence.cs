using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using WcfService1.Util;

namespace WindowsApplication2
{
	// Token: 0x0200006D RID: 109
	public class Licence
	{
		// Token: 0x0600023E RID: 574 RVA: 0x000034C4 File Offset: 0x000016C4
		static Licence()
		{
			Class15.XRATSHnz66atd();
			Licence.object_0 = 0;
			Licence.webClientAdvanced_0 = new WebClientAdvanced();
			Licence.object_1 = RuntimeHelpers.GetObjectValue(new object());
			Licence.int_0 = 60;
			Licence.string_0 = "";
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00002744 File Offset: 0x00000944
		public Licence()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000129D0 File Offset: 0x00010BD0
		public static void setLicence(string key)
		{
			StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "/data/key.txt");
			streamWriter.Write(key);
			streamWriter.Close();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00012A00 File Offset: 0x00010C00
		public static int checking(bool ban = false, int i = 0)
		{
			Licence.smethod_0();
			if (!File.Exists(Application.StartupPath + "/data/key.txt"))
			{
				FileStream fileStream = File.Create(Application.StartupPath + "/data/key.txt");
				fileStream.Close();
			}
			IPAddress[] hostAddresses = Dns.GetHostAddresses("netfu.net");
			string text = "?tx=";
			int result;
			try
			{
				text += Config.string_0;
				text = text + "&hash=" + Licence.getUniqueKey();
				if (ban)
				{
					string text2 = DateTime.Now.Minute.ToString();
					if (Conversions.ToDouble(text2) < 10.0)
					{
						text2 = "0" + text2;
					}
					string text3 = DateTime.Now.Hour.ToString();
					if (Conversions.ToDouble(text3) < 10.0)
					{
						text3 = "0" + text3;
					}
					text = text + "&ban0=" + Conversions.ToString(i) + Class8.smethod_0(text2 + Config.string_0.Substring(0, 2) + text3 + Config.string_0.Substring(2));
				}
				if (hostAddresses.FirstOrDefault((Licence._Closure$__.$I11-0 == null) ? (Licence._Closure$__.$I11-0 = ((IPAddress a) => a.ToString().Contains("213.186."))) : Licence._Closure$__.$I11-0) != null)
				{
					string value = Licence.webClientAdvanced_0.DownloadString("http://netfu.net/checking/check.php" + text);
					hostAddresses = Dns.GetHostAddresses("netfu.net");
					if (hostAddresses.FirstOrDefault((Licence._Closure$__.$I11-1 == null) ? (Licence._Closure$__.$I11-1 = ((IPAddress a) => a.ToString().Contains("213.186."))) : Licence._Closure$__.$I11-1) != null)
					{
						if (Conversions.ToDouble(value) == 1.0)
						{
							result = 1;
						}
						else if (Conversions.ToDouble(value) == 2.0)
						{
							result = 1;
						}
						else if (Conversions.ToDouble(value) == -1.0)
						{
							Licence.drag = true;
							result = 1;
						}
						else
						{
							result = -1;
						}
					}
					else
					{
						result = 0;
					}
				}
				else
				{
					result = 0;
				}
			}
			catch (Exception ex)
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00012C38 File Offset: 0x00010E38
		[DebuggerStepThrough]
		public static void checkModos()
		{
			Licence.VB$StateMachine_12_checkModos vb$StateMachine_12_checkModos = new Licence.VB$StateMachine_12_checkModos();
			vb$StateMachine_12_checkModos.$State = -1;
			vb$StateMachine_12_checkModos.$Builder = AsyncVoidMethodBuilder.Create();
			vb$StateMachine_12_checkModos.$Builder.Start<Licence.VB$StateMachine_12_checkModos>(ref vb$StateMachine_12_checkModos);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00012C6C File Offset: 0x00010E6C
		public static string getUniqueKey()
		{
			string str = string.Empty;
			ManagementClass managementClass = new ManagementClass("win32_processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			try
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator();
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					str = managementObject.Properties["processorID"].Value.ToString();
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator;
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			string str2 = "C";
			ManagementObject managementObject2 = new ManagementObject("win32_logicaldisk.deviceid=\"" + str2 + ":\"");
			managementObject2.Get();
			managementObject2["VolumeSerialNumber"].ToString();
			return Class8.smethod_1(str + str2, Environment.MachineName);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00012D34 File Offset: 0x00010F34
		private static void smethod_0()
		{
			Licence._Closure$__14-0 CS$<>8__locals1 = new Licence._Closure$__14-0(CS$<>8__locals1);
			string[] source = new string[]
			{
				"reflector",
				"ollydbg",
				"sae",
				"fiddler",
				"processhacker",
				"dump",
				"wpe",
				"ospy",
				"engine",
				"wamp"
			};
			foreach (Process process in Process.GetProcesses())
			{
				if (source.Contains(process.ProcessName.ToLower()))
				{
					try
					{
						process.Kill();
					}
					catch (Exception ex)
					{
						Process.GetCurrentProcess().Kill();
					}
				}
			}
			string path = Application.StartupPath + "/data/key.txt";
			if (!File.Exists(path))
			{
				FileStream fileStream = File.Create(path);
				fileStream.Close();
			}
			StreamReader streamReader = new StreamReader(path);
			Config.string_0 = streamReader.ReadToEnd().Replace("\r\n", "");
			streamReader.Close();
			string s = "";
			string path2 = Application.CommonAppDataPath + "\\" + Config.string_0;
			int id = Process.GetCurrentProcess().Id;
			try
			{
				if (File.Exists(path2))
				{
					StreamReader streamReader2 = new StreamReader(path2);
					s = streamReader2.ReadToEnd();
					streamReader2.Close();
				}
				else
				{
					StreamWriter streamWriter = File.CreateText(path2);
					streamWriter.Close();
				}
				if (!(-(int.TryParse(s, out CS$<>8__locals1.$VB$Local_pid) > false)))
				{
					CS$<>8__locals1.$VB$Local_pid = id;
				}
				StreamWriter streamWriter2 = new StreamWriter(path2, false);
				streamWriter2.Write(id);
				streamWriter2.Close();
				IOrderedEnumerable<Process> source2 = Process.GetProcesses().OrderBy((Licence._Closure$__.$I14-0 == null) ? (Licence._Closure$__.$I14-0 = ((Process p) => p.ProcessName)) : Licence._Closure$__.$I14-0);
				Process process2 = source2.FirstOrDefault((Process p) => p.Id == CS$<>8__locals1.$VB$Local_pid);
				if (id != CS$<>8__locals1.$VB$Local_pid && process2 != null)
				{
					MessageBox.Show("Double licence lancée, une seule utilisation est autorisée");
					Thread.Sleep(4500);
					Application.Exit();
				}
				try
				{
					foreach (Process process3 in source2.Where((Licence._Closure$__.$I14-2 == null) ? (Licence._Closure$__.$I14-2 = ((Process pro) => Operators.CompareString(pro.ProcessName, "Netfu", false) == 0)) : Licence._Closure$__.$I14-2))
					{
						process3.Kill();
					}
				}
				finally
				{
					IEnumerator<Process> enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			catch (Exception e)
			{
				Fonctions.traiterErreur(e);
			}
		}

		// Token: 0x040002D6 RID: 726
		private static object object_0;

		// Token: 0x040002D7 RID: 727
		private static WebClientAdvanced webClientAdvanced_0;

		// Token: 0x040002D8 RID: 728
		private static DateTime dateTime_0;

		// Token: 0x040002D9 RID: 729
		private static DateTime dateTime_1;

		// Token: 0x040002DA RID: 730
		private static object object_1;

		// Token: 0x040002DB RID: 731
		public static bool drag;

		// Token: 0x040002DC RID: 732
		private static int int_0;

		// Token: 0x040002DD RID: 733
		private static string string_0;
	}
}
