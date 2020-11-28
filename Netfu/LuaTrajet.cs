using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace WindowsApplication2
{
	// Token: 0x020000FE RID: 254
	public class LuaTrajet
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x00004A5B File Offset: 0x00002C5B
		public void Update()
		{
			if (this.taskAction == null || this.taskAction.IsCompleted)
			{
				this.taskAction = new Task(delegate()
				{
					try
					{
						LuaBot luaBot = new LuaBot(this.bot);
						if (this.bot.map != null && this.bot.map.myActor() != null)
						{
							bool flag = this.bot.get_Slave(false).Count == 0 && Declarations.get_MyChef(this.targetId) != null;
							Maps map = this.bot.map;
							if (map != null)
							{
								if (this.waitGroup)
								{
									if (flag)
									{
										return;
									}
									if (!map.AllSlavesInMap())
									{
										return;
									}
								}
								NewLateBinding.LateIndexSet(this.lua_0, new object[]
								{
									"bot",
									luaBot
								}, null);
								LuaFunction luaFunction = (LuaFunction)NewLateBinding.LateIndexGet(this.lua_0, new object[]
								{
									"Update"
								}, null);
								LuaTable luaTable = (LuaTable)luaFunction.Call(new object[0])[0];
								try
								{
									foreach (object obj in luaTable.Values)
									{
										object objectValue = RuntimeHelpers.GetObjectValue(obj);
										LuaTable luaTable2 = (LuaTable)objectValue;
										string text = Conversions.ToString(luaTable2["map"]);
										LuaFunction luaFunction2 = (LuaFunction)luaTable2["action"];
										LuaFunction luaFunction3 = (LuaFunction)luaTable2["condition"];
										if (luaFunction2 != null)
										{
											if (text != null)
											{
												int num;
												if (int.TryParse(text, out num))
												{
													if (this.bot.map.id != num)
													{
														continue;
													}
												}
												else if (text.IndexOf(",") > 0)
												{
													string[] array = text.Split(new char[]
													{
														','
													});
													if ((double)this.bot.map.position.X != Conversions.ToDouble(array[0]) || (double)this.bot.map.position.Y != Conversions.ToDouble(array[1]))
													{
														continue;
													}
												}
											}
											if (luaFunction3 == null || Conversions.ToBoolean(luaFunction3.Call(new object[0])[0]))
											{
												luaFunction2.Call(new object[0]);
											}
										}
									}
								}
								finally
								{
									IEnumerator enumerator;
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						this.bot.mode = -1;
						this.bot.LuaTrajet = null;
						Interaction.MsgBox("Erreur trajet :" + ex.Message, MsgBoxStyle.OkOnly, null);
					}
				});
				this.taskAction.Start();
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00028548 File Offset: 0x00026748
		public Perso bot
		{
			get
			{
				return Declarations.getComtpesByIndex(this.targetId);
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00028564 File Offset: 0x00026764
		public LuaTrajet(string _script, int _trajetID)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.waitGroup = true;
			this.lua_0 = new Lua();
			try
			{
				this.targetId = _trajetID;
				this.script = _script;
				this.taskAction = new Task(delegate()
				{
					try
					{
						NewLateBinding.LateIndexSet(this.lua_0, new object[]
						{
							"bot",
							new LuaBot(this.bot)
						}, null);
						NewLateBinding.LateCall(this.lua_0, null, "LoadCLRPackage", new object[0], null, null, null, true);
						NewLateBinding.LateCall(this.lua_0, null, "DoString", new object[]
						{
							"import ('WindowsApplication2.LuaBot')\r\n" + this.script
						}, null, null, null, true);
						this.name = Conversions.ToString(NewLateBinding.LateIndexGet(this.lua_0, new object[]
						{
							"name"
						}, null));
					}
					catch (Exception ex2)
					{
						Interaction.MsgBox("Erreur trajet :" + ex2.Message, MsgBoxStyle.OkOnly, null);
					}
				});
				this.taskAction.Start();
			}
			catch (Exception ex)
			{
				this.bot.mode = -1;
				this.bot.LuaTrajet = null;
				Interaction.MsgBox("Erreur trajet :" + ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00004A9A File Offset: 0x00002C9A
		public void Stop()
		{
			this.bot.mode = -1;
			this.bot.LuaTrajet = null;
		}

		// Token: 0x04000551 RID: 1361
		public int targetId;

		// Token: 0x04000552 RID: 1362
		public string script;

		// Token: 0x04000553 RID: 1363
		public string name;

		// Token: 0x04000554 RID: 1364
		public bool waitGroup;

		// Token: 0x04000555 RID: 1365
		public Task taskAction;

		// Token: 0x04000556 RID: 1366
		public object threadId;

		// Token: 0x04000557 RID: 1367
		private Lua lua_0;
	}
}
