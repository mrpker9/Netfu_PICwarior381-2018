using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;

// Token: 0x02000006 RID: 6
[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class Class3
{
	// Token: 0x06000007 RID: 7 RVA: 0x000026FE File Offset: 0x000008FE
	static Class3()
	{
		Class15.XRATSHnz66atd();
		Class3.class5_0 = new Class3.Class5<Class2>();
		Class3.class5_1 = new Class3.Class5<Class1>();
		Class3.class5_2 = new Class3.Class5<User>();
		Class3.class5_3 = new Class3.Class5<Class3.Class4>();
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000008 RID: 8 RVA: 0x00004F64 File Offset: 0x00003164
	[HelpKeyword("My.Computer")]
	internal static Class2 Class2_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_0.method_0();
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000009 RID: 9 RVA: 0x00004F80 File Offset: 0x00003180
	[HelpKeyword("My.Application")]
	internal static Class1 Class1_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_1.method_0();
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600000A RID: 10 RVA: 0x00004F9C File Offset: 0x0000319C
	[HelpKeyword("My.User")]
	internal static User User_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_2.method_0();
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600000B RID: 11 RVA: 0x00004FB8 File Offset: 0x000031B8
	[HelpKeyword("My.WebServices")]
	internal static Class3.Class4 Class4_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_3.method_0();
		}
	}

	// Token: 0x04000001 RID: 1
	private static readonly Class3.Class5<Class2> class5_0;

	// Token: 0x04000002 RID: 2
	private static readonly Class3.Class5<Class1> class5_1;

	// Token: 0x04000003 RID: 3
	private static readonly Class3.Class5<User> class5_2;

	// Token: 0x04000004 RID: 4
	private static readonly Class3.Class5<Class3.Class4> class5_3;

	// Token: 0x02000007 RID: 7
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class Class4
	{
		// Token: 0x0600000C RID: 12 RVA: 0x0000272D File Offset: 0x0000092D
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004FD4 File Offset: 0x000031D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00004FEC File Offset: 0x000031EC
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type method_0()
		{
			return typeof(Class3.Class4);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00005008 File Offset: 0x00003208
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00005020 File Offset: 0x00003220
		[DebuggerHidden]
		private static CFLlMXtYWNWWqfgig3 smethod_0<CFLlMXtYWNWWqfgig3>(CFLlMXtYWNWWqfgig3 dP9Inc3poLKRIkQONV) where CFLlMXtYWNWWqfgig3 : new()
		{
			CFLlMXtYWNWWqfgig3 result;
			if (dP9Inc3poLKRIkQONV == null)
			{
				result = Activator.CreateInstance<CFLlMXtYWNWWqfgig3>();
			}
			else
			{
				result = dP9Inc3poLKRIkQONV;
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000273B File Offset: 0x0000093B
		[DebuggerHidden]
		private void method_1<LPGjwjI5SBhxE6xWTw>(ref LPGjwjI5SBhxE6xWTw gparam_0)
		{
			gparam_0 = default(LPGjwjI5SBhxE6xWTw);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002744 File Offset: 0x00000944
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Class4()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
		}
	}

	// Token: 0x02000008 RID: 8
	[ComVisible(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class Class5<zX1jwpGmdjvCW0Kh3e> where zX1jwpGmdjvCW0Kh3e : new()
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00005044 File Offset: 0x00003244
		[DebuggerHidden]
		internal zX1jwpGmdjvCW0Kh3e method_0()
		{
			zX1jwpGmdjvCW0Kh3e zX1jwpGmdjvCW0Kh3e = this.contextValue_0.Value;
			if (zX1jwpGmdjvCW0Kh3e == null)
			{
				zX1jwpGmdjvCW0Kh3e = Activator.CreateInstance<zX1jwpGmdjvCW0Kh3e>();
				this.contextValue_0.Value = zX1jwpGmdjvCW0Kh3e;
			}
			return zX1jwpGmdjvCW0Kh3e;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002751 File Offset: 0x00000951
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public Class5()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.contextValue_0 = new ContextValue<zX1jwpGmdjvCW0Kh3e>();
		}

		// Token: 0x04000005 RID: 5
		private readonly ContextValue<zX1jwpGmdjvCW0Kh3e> contextValue_0;
	}
}
