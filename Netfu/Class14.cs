using System;
using System.Reflection;

// Token: 0x02000116 RID: 278
internal class Class14
{
	// Token: 0x06000575 RID: 1397 RVA: 0x0002C1D4 File Offset: 0x0002A3D4
	internal static void SfwTSHnnVm2kQ(int typemdt)
	{
		Type type = Class14.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class14.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x00002744 File Offset: 0x00000944
	public Class14()
	{
		Class15.XRATSHnz66atd();
		base..ctor();
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x00004F39 File Offset: 0x00003139
	static Class14()
	{
		Class15.XRATSHnz66atd();
		Class14.module_0 = typeof(Class14).Assembly.ManifestModule;
	}

	// Token: 0x040005C5 RID: 1477
	internal static Module module_0;

	// Token: 0x02000117 RID: 279
	// (Invoke) Token: 0x06000579 RID: 1401
	internal delegate void Delegate2(object o);
}
