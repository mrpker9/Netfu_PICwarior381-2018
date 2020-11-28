using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200000E RID: 14
	public class ChatHandler
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00006564 File Offset: 0x00004764
		public ChatHandler(Perso _bot)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.openedCanal = new List<string>();
			this.histoMsgs = new List<MessageChatHisto>();
			this.perso_0 = _bot;
			this.openedCanal.Add("normal");
			this.openedCanal.Add("mp");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000065BC File Offset: 0x000047BC
		public void AddTextChat(string str, string canal)
		{
			MessageChatHisto messageChatHisto = new MessageChatHisto();
			messageChatHisto.msg = str;
			messageChatHisto.canal = canal;
			if (GlobalConfig.notifMp && Operators.CompareString(canal, "mp", false) == 0)
			{
				Fonctions.sendNotif(this.perso_0.monNom + " à recus un nouveau MP: " + str);
			}
			if (this.openedCanal.Contains(canal))
			{
				this.histoMsgs.Add(messageChatHisto);
				if (this.histoMsgs.Count > 200)
				{
					this.histoMsgs = this.histoMsgs.Skip(25).ToList<MessageChatHisto>();
				}
			}
		}

		// Token: 0x04000014 RID: 20
		public List<string> openedCanal;

		// Token: 0x04000015 RID: 21
		public List<MessageChatHisto> histoMsgs;

		// Token: 0x04000016 RID: 22
		private Perso perso_0;
	}
}
