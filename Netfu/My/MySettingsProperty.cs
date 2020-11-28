using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2.My
{
	// Token: 0x0200000B RID: 11
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[StandardModule]
	[HideModuleName]
	internal sealed class MySettingsProperty
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00005C44 File Offset: 0x00003E44
		[HelpKeyword("My.Settings")]
		internal static MySettings Settings
		{
			get
			{
				return MySettings.Default;
			}
		}
	}
}
