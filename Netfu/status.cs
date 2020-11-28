using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x0200003A RID: 58
	public class status
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000158 RID: 344 RVA: 0x0000D1A0 File Offset: 0x0000B3A0
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00002F49 File Offset: 0x00001149
		public int Int32_0
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				Declarations.getComtpesByIndex(this.int_2);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002F5E File Offset: 0x0000115E
		public status()
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.connexionStatus_0 = status.ConnexionStatus.const_0;
			this.int_3 = -1;
			this.LastFauche = DateTime.Now;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00002F84 File Offset: 0x00001184
		public bool enDeplacement()
		{
			return (this.currentAction == 1 || this.currentAction == 4 || this.currentAction == 0) && this.Int32_0 != -1;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00002FAF File Offset: 0x000011AF
		public bool enFauche()
		{
			return this.currentAction == 501 && this.Int32_0 != -1;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
		public bool IsIgnoreGroup()
		{
			Perso comtpesByIndex = Declarations.getComtpesByIndex(this.int_2);
			bool result;
			if (comtpesByIndex.MovementTrajet != null)
			{
				result = (comtpesByIndex.MovementTrajet.currentLine.Key != null && comtpesByIndex.MovementTrajet.currentLine.Key.ignoregroupe);
			}
			else
			{
				result = (comtpesByIndex.LuaTrajet != null && !comtpesByIndex.LuaTrajet.waitGroup);
			}
			return result;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000D230 File Offset: 0x0000B430
		public object NeedRegen
		{
			get
			{
				object result;
				try
				{
					if (Information.IsNothing(Declarations.getComtpesByIndex(this.int_2).InfosPerso))
					{
						result = false;
					}
					else if (Information.IsNothing(Declarations.getComtpesByIndex(this.int_2).map))
					{
						result = false;
					}
					else if (Operators.ConditionalCompareObjectEqual(Declarations.getComtpesByIndex(this.int_2).map.ActorCount(), 0, false))
					{
						result = false;
					}
					else
					{
						result = (!Declarations.getComtpesByIndex(this.int_2).map.myActor().dead && (double)Declarations.getComtpesByIndex(this.int_2).InfosPerso.LP / (double)Declarations.getComtpesByIndex(this.int_2).InfosPerso.LPmax * 100.0 < Convert.ToDouble(Declarations.getComtpesByIndex(this.int_2).config.percentRegen) && !this.enCombat());
					}
				}
				catch (Exception ex)
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00002FCD File Offset: 0x000011CD
		// (set) Token: 0x06000160 RID: 352 RVA: 0x00002FD8 File Offset: 0x000011D8
		public bool enEchange
		{
			get
			{
				return this.int_0 != 0;
			}
			set
			{
				this.int_0 = ((-((value > false) ? 1 : 0)) ? 1 : 0);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00002FE5 File Offset: 0x000011E5
		public status(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.connexionStatus_0 = status.ConnexionStatus.const_0;
			this.int_3 = -1;
			this.LastFauche = DateTime.Now;
			this.int_2 = index;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0000D35C File Offset: 0x0000B55C
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00003012 File Offset: 0x00001212
		public status.ConnexionStatus connexion
		{
			get
			{
				return this.connexionStatus_0;
			}
			set
			{
				this.connexionStatus_0 = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000164 RID: 356 RVA: 0x0000D374 File Offset: 0x0000B574
		// (set) Token: 0x06000165 RID: 357 RVA: 0x0000301B File Offset: 0x0000121B
		public int currentAction
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00003024 File Offset: 0x00001224
		public bool enCombat()
		{
			return Declarations.getComtpesByIndex(this.int_2).Fight != null;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000D38C File Offset: 0x0000B58C
		public bool isIdle()
		{
			Perso comtpesByIndex = Declarations.getComtpesByIndex(this.int_2);
			return Conversions.ToBoolean(this.Int32_0 == -1 && !this.enCombat() && !(-(this.enEchange > false)) && Conversions.ToBoolean(Operators.CompareObjectEqual(this.NeedRegen, 0, false)) && this.connexion == status.ConnexionStatus.const_3 && !this.enFauche() && comtpesByIndex.map != null && comtpesByIndex.map.loaded && (!comtpesByIndex.config.idleSecurity || !comtpesByIndex.map.hasPresence) && (comtpesByIndex.lastTaskUpdateLaunch == null || comtpesByIndex.lastTaskUpdateLaunch.IsCompleted));
		}

		// Token: 0x0400010C RID: 268
		public bool autoReconnect;

		// Token: 0x0400010D RID: 269
		private status.ConnexionStatus connexionStatus_0;

		// Token: 0x0400010E RID: 270
		private int int_0;

		// Token: 0x0400010F RID: 271
		private int int_1;

		// Token: 0x04000110 RID: 272
		public int bloqueGA;

		// Token: 0x04000111 RID: 273
		private int int_2;

		// Token: 0x04000112 RID: 274
		private int int_3;

		// Token: 0x04000113 RID: 275
		public DateTime LastFauche;

		// Token: 0x04000114 RID: 276
		public int fileAttentePlace;

		// Token: 0x04000115 RID: 277
		public bool sit;

		// Token: 0x0200003B RID: 59
		public enum ConnexionStatus
		{
			// Token: 0x04000117 RID: 279
			const_0,
			// Token: 0x04000118 RID: 280
			Connexion_login,
			// Token: 0x04000119 RID: 281
			Connexion_en_jeu,
			// Token: 0x0400011A RID: 282
			const_3,
			// Token: 0x0400011B RID: 283
			Mauvais_Mot_de_passe,
			// Token: 0x0400011C RID: 284
			Compte_Bannie,
			// Token: 0x0400011D RID: 285
			Serveur_Plein,
			// Token: 0x0400011E RID: 286
			Serveur_en_Sauvegarde,
			// Token: 0x0400011F RID: 287
			File_Attente,
			// Token: 0x04000120 RID: 288
			Mauvaise_Configuration,
			// Token: 0x04000121 RID: 289
			Recherche_proxy
		}
	}
}
