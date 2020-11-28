using System;

namespace WindowsApplication2
{
	// Token: 0x020000BE RID: 190
	public interface IPathNode<TUserContext>
	{
		// Token: 0x06000401 RID: 1025
		bool IsWalkable(TUserContext inContext);
	}
}
