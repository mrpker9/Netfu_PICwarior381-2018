using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace WindowsApplication2
{
	// Token: 0x020000FF RID: 255
	public class LuaBot
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public LuaBot(Perso _bot)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.perso_0 = _bot;
		}

		/// <summary>retourne vrai si c'est un chef de groupe</summary>
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public bool isChef
		{
			get
			{
				this.method_1();
				return this.perso_0.get_Slave(false).Count > 0;
			}
		}

		/// <summary>retourne vrai si c'est le bot est en groupe sinon faux</summary>
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00004AE4 File Offset: 0x00002CE4
		public bool inGroup
		{
			get
			{
				return this.perso_0.get_Slave(false).Count > 0 || (this.perso_0.nomChef != null && this.perso_0.nomChef.Length > 0);
			}
		}

		/// <summary>retourne vrai si le trajet est stoppé (Utile pour les boucles while)</summary>
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00004B20 File Offset: 0x00002D20
		public bool pathStopped
		{
			get
			{
				return this.perso_0.LuaTrajet == null;
			}
		}

		/// <summary>retourne l'id zone de la carte actuel</summary>
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x000289C4 File Offset: 0x00026BC4
		public int mapArea
		{
			get
			{
				return (int)this.perso_0.map.subarea();
			}
		}

		/// <summary>retourne le nombre de mule</summary>
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x000289E4 File Offset: 0x00026BE4
		public int slavesCount
		{
			get
			{
				this.method_1();
				return this.perso_0.get_Slave(false).Count;
			}
		}

		/// <summary>retourne une table contenant les bot (LUABOT) des mules</summary>
		/// <example>
		///
		///  for i = 0, bot.slaves.Count - 1 do
		///   bot.slaves[i].listItemToDelete:Add(311)
		///  End
		///  la documentation pour gérer les listes est ici https://docs.microsoft.com/fr-fr/dotnet/api/system.collections.generic.list-1?view=netframework-4.8#methods
		///
		///  </example>
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x00028A0C File Offset: 0x00026C0C
		public List<LuaBot> slaves
		{
			get
			{
				this.method_1();
				List<LuaBot> list = new List<LuaBot>();
				try
				{
					foreach (int id in this.perso_0.get_Slave(false))
					{
						Perso comtpesById = Declarations.getComtpesById(id);
						if (comtpesById != null)
						{
							list.Add(new LuaBot(comtpesById));
						}
					}
				}
				finally
				{
					List<int>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				return list;
			}
		}

		/// <summary>retourne le nombre de combat total effectué</summary>
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00028A88 File Offset: 0x00026C88
		public int nbFight
		{
			get
			{
				this.method_1();
				return this.perso_0.FightResult.Count;
			}
		}

		/// <summary>retourne le nombre de personnage sur la carte</summary>
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x00028AB0 File Offset: 0x00026CB0
		public int charactersCount
		{
			get
			{
				this.method_1();
				return this.perso_0.map.Characters.Count;
			}
		}

		/// <summary>Essaye de se mettre en mode marchant, retourn vraie si réussite sinon faux</summary>
		// Token: 0x06000502 RID: 1282 RVA: 0x00004B30 File Offset: 0x00002D30
		public bool goMerchant()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.ExchangeManager.checkMerchant();
		}

		/// <summary>Permet d'assigner une IA au bot</summary>
		/// <param name="ia">Le nom du fichier se trouvant dans le dossier IA</param>
		/// <param name="nomperso">Le nom du personnage sur lequel charger l'ia</param>
		// Token: 0x06000503 RID: 1283 RVA: 0x00028ADC File Offset: 0x00026CDC
		public void loadIa(string ia, string nomperso)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				ia,
				nomperso
			});
			if (File.Exists(Application.StartupPath + "\\ia\\" + ia))
			{
				Perso comtpesByName = Declarations.getComtpesByName(nomperso);
				if (comtpesByName != null)
				{
					this.perso_0.ia = IA.LoadIA(this.perso_0.monId, File.ReadAllText(Application.StartupPath + "\\ia\\" + ia));
				}
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x00004B59 File Offset: 0x00002D59
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x00004B6B File Offset: 0x00002D6B
		public bool videStorage
		{
			get
			{
				return this.perso_0.ExchangeManager.videBanque;
			}
			set
			{
				this.perso_0.ExchangeManager.videBanque = value;
			}
		}

		/// <summary>retourne les infos du personnage,caracteristique,kamas etc..</summary>
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x00028B5C File Offset: 0x00026D5C
		public InfoPerso infos
		{
			get
			{
				this.method_1();
				return this.perso_0.InfosPerso;
			}
		}

		/// <summary>retourne vraie si le bot est mort non sinon</summary>
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00028B7C File Offset: 0x00026D7C
		public bool death
		{
			get
			{
				this.method_1();
				Character myCharacter = this.perso_0.myCharacter;
				return myCharacter != null && myCharacter.dead;
			}
		}

		/// <summary>retourne  le niveau du personnage</summary>
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00028BB0 File Offset: 0x00026DB0
		public int level
		{
			get
			{
				this.method_1();
				Character myCharacter = this.perso_0.myCharacter;
				int result;
				if (myCharacter != null)
				{
					result = myCharacter.level;
				}
				else
				{
					result = -1;
				}
				return result;
			}
		}

		/// <summary>retourne la cellid actuel</summary>
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x00028BE4 File Offset: 0x00026DE4
		public int cell
		{
			get
			{
				this.method_1();
				return this.perso_0.myCharacter.Cell;
			}
		}

		/// <summary>retourne la mapid actuel</summary>
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x00028C0C File Offset: 0x00026E0C
		public int mapId
		{
			get
			{
				this.method_1();
				return this.perso_0.map.id;
			}
		}

		/// <summary>retourne la derniere mapID si aucune -1</summary>
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x00028C34 File Offset: 0x00026E34
		public int lastmapId
		{
			get
			{
				this.method_1();
				int result;
				if (this.perso_0.lastmap == null)
				{
					result = -1;
				}
				else
				{
					result = this.perso_0.lastmap.id;
				}
				return result;
			}
		}

		/// <summary>retourne les coordonées de la map actuel</summary>
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x00028C70 File Offset: 0x00026E70
		public object mapCoord
		{
			get
			{
				this.method_1();
				return this.perso_0.map.position;
			}
		}

		/// <summary>retourne le nombre de % de pods actuel</summary>
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x00028C9C File Offset: 0x00026E9C
		public int podsPercent
		{
			get
			{
				this.method_1();
				return this.perso_0.Inventaire.podsPercent;
			}
		}

		/// <summary>retourne le nombre de pods utilisé</summary>
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00028CC4 File Offset: 0x00026EC4
		public int podsActual
		{
			get
			{
				this.method_1();
				return this.perso_0.Inventaire.podsactual;
			}
		}

		/// <summary>retourne le nombre de pods total</summary>
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x00028CEC File Offset: 0x00026EEC
		public int podsMax
		{
			get
			{
				this.method_1();
				return this.perso_0.Inventaire.podsMax;
			}
		}

		/// <summary>retourne le nom du personnage</summary>
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00028D14 File Offset: 0x00026F14
		public string name
		{
			get
			{
				this.method_1();
				return this.perso_0.monNom;
			}
		}

		/// <summary>Permet d'obtenir la configuration du bot</summary>
		/// <seealso cref="T:WindowsApplication2.Config" />
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x00028D34 File Offset: 0x00026F34
		public Config config
		{
			get
			{
				this.method_1();
				return this.perso_0.config;
			}
		}

		/// <summary>Permet d'obtenir le nombre de combat effectué sur la carte</summary>
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x00028D54 File Offset: 0x00026F54
		public object fightCount
		{
			get
			{
				this.method_1();
				return this.perso_0.nbCombat;
			}
		}

		/// <summary>Permet d'obtenir l'etat du bot (En attente,En regénération,En échange,En déplacement,En recolte,En combat) </summary>
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x00028D7C File Offset: 0x00026F7C
		public string state
		{
			get
			{
				this.method_1();
				return this.perso_0.Etat;
			}
		}

		/// <summary>Permet de lancer un combat</summary>
		/// <returns>Vraie si combat lancé sinon faux</returns>
		// Token: 0x06000514 RID: 1300 RVA: 0x00028D9C File Offset: 0x00026F9C
		public object fight()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.CheckFight();
		}

		/// <summary>Permet de recolter</summary>
		/// <returns>Vraie si recolte lancé sinon faux</returns>
		// Token: 0x06000515 RID: 1301 RVA: 0x00004B7E File Offset: 0x00002D7E
		public bool gather()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.launcher.waitAction = 1000;
			return this.perso_0.interactiveManager.TryUse();
		}

		/// <summary>Permet de savoir combien d'objet utilisable sont sur la carte (selon la configuration du bot)</summary>
		/// <returns>Le nombre de ressources utilisable</returns>
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00028DD0 File Offset: 0x00026FD0
		public int resourceCount
		{
			get
			{
				return this.perso_0.interactiveManager.ToUsables().Count;
			}
		}

		/// <summary>Permet d'obtenir les infos d'un metier</summary>
		///  '''<param name="jobId">L'Id du job</param>
		/// <returns>Les infos du metier</returns>
		// Token: 0x06000517 RID: 1303 RVA: 0x00028DF4 File Offset: 0x00026FF4
		public Job getJobInfos(int jobId)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				jobId
			});
			return this.perso_0.Jobs.Jobs.FirstOrDefault((Job j) => j.id == jobId);
		}

		/// <summary>Permet de savoir si mon bot à un item ou non</summary>
		/// <param name="itemId">L'Id de l'item</param>
		/// <returns>Vrai si il la sinon faux</returns>
		// Token: 0x06000518 RID: 1304 RVA: 0x00004BBC File Offset: 0x00002DBC
		public bool hasItem(int itemID)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemID
			});
			return this.perso_0.Inventaire.getObjectById(itemID) != null;
		}

		/// <summary>Permet d'utiliser un item</summary>
		/// <param name="itemId">L'Id de l'item</param>
		/// <param name="qty">Nombre de fois à utiliser</param>
		/// <returns>Le nombre de fois que l'objet à été utilisé</returns>
		// Token: 0x06000519 RID: 1305 RVA: 0x00028E50 File Offset: 0x00027050
		public int useItem(int itemId, int qty)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemId,
				qty
			});
			this.perso_0.launcher.waitAction = 5000;
			checked
			{
				if (this.perso_0.LuaTrajet.waitGroup)
				{
					try
					{
						foreach (int id in this.perso_0.get_Slave(true))
						{
							Perso comtpesById = Declarations.getComtpesById(id);
							if (!Information.IsNothing(comtpesById))
							{
								Objets objectById = comtpesById.Inventaire.getObjectById(itemId);
								if (!Information.IsNothing(objectById))
								{
									comtpesById.useItem((int)objectById.idObjetInv, qty);
								}
							}
						}
					}
					finally
					{
						List<int>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				Objets objectById2 = this.perso_0.Inventaire.getObjectById(itemId);
				int result;
				if (objectById2 != null)
				{
					result = this.perso_0.useItem((int)objectById2.idObjetInv, qty);
				}
				return result;
			}
		}

		/// <summary>Permet d'équiper un item</summary>
		/// <param name="itemID">L'Id de l'item a équiper</param>
		// Token: 0x0600051A RID: 1306 RVA: 0x00028F60 File Offset: 0x00027160
		public void equipItem(int itemID)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemID
			});
			if (this.hasItem(itemID))
			{
				try
				{
					foreach (int id in this.perso_0.get_Slave(true))
					{
						Perso comtpesById = Declarations.getComtpesById(id);
						if (!Information.IsNothing(comtpesById))
						{
							comtpesById.Inventaire.EquipeItem(itemID, 0);
						}
					}
				}
				finally
				{
					List<int>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				this.perso_0.Inventaire.EquipeItem(itemID, 0);
			}
		}

		/// <summary>Supprimer un item</summary>
		/// <param name="itemID">L'Id de l'item a suprimer</param>
		/// <param name="qty">Le quantité à supprimer</param>
		// Token: 0x0600051B RID: 1307 RVA: 0x0002900C File Offset: 0x0002720C
		public void deleteItem(int itemID, int qty)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemID,
				qty
			});
			if (this.hasItem(itemID))
			{
				this.perso_0.Inventaire.DetruireItem((long)itemID, qty);
			}
		}

		/// <summary>Permet de se deplacer sur une cellule</summary>
		/// <param name="cellId">L'Id de la cellule</param>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x0600051C RID: 1308 RVA: 0x00004BEC File Offset: 0x00002DEC
		public bool move(int cellId)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				cellId
			});
			return this.perso_0.movement.SeDeplacer(cellId, -1);
		}

		/// <summary>Permet se deplacer sur la carte du dessus</summary>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x0600051D RID: 1309 RVA: 0x00029060 File Offset: 0x00027260
		public bool moveTop()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.movement.MoveMapDirection(MapNeighbour.Top, false, null).Key;
		}

		/// <summary>Permet se deplacer sur la carte du dessous</summary>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x0600051E RID: 1310 RVA: 0x000290A0 File Offset: 0x000272A0
		public bool moveBottom()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.movement.MoveMapDirection(MapNeighbour.Bottom, false, null).Key;
		}

		/// <summary>Permet se deplacer sur la carte de gauche</summary>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x0600051F RID: 1311 RVA: 0x000290E0 File Offset: 0x000272E0
		public bool moveLeft()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.movement.MoveMapDirection(MapNeighbour.Left, false, null).Key;
		}

		/// <summary>Permet se deplacer sur la carte de droite</summary>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x06000520 RID: 1312 RVA: 0x00029120 File Offset: 0x00027320
		public bool moveRight()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			return this.perso_0.movement.MoveMapDirection(MapNeighbour.Right, false, null).Key;
		}

		/// <summary>Permet de parler à un PNJ</summary>
		/// <param name="idNPC">L'Id du NPC</param>
		/// <param name="reponses">Liste des reponses (morceaux de phrase), si aucune réponse prend la premiere réponse</param>
		// Token: 0x06000521 RID: 1313 RVA: 0x00029160 File Offset: 0x00027360
		public void speakNPC(int idNPC, LuaTable reponses)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				idNPC,
				reponses
			});
			List<string> list = new List<string>();
			try
			{
				foreach (object obj in reponses.Values)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(obj);
					list.Add(Conversions.ToString(objectValue));
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
			this.perso_0.ExchangeManager.SpeekNpc(idNPC, list);
		}

		/// <summary>Affecte le code à utiliser pour utiliser un objet (maison)</summary>
		/// <param name="secureCode">Le code de sécurité</param>
		// Token: 0x06000522 RID: 1314 RVA: 0x00004C20 File Offset: 0x00002E20
		public void setSecureCode(string secureCode)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				secureCode
			});
			this.perso_0.ExchangeManager.SecureCode = secureCode;
		}

		/// <summary>Permet d'assigner un objet a prendre en banque</summary>
		/// <param name="itemID">l'ID de l'item a acheter</param>
		/// <param name="qty">La quantité de l'objet a prendre</param>
		// Token: 0x06000523 RID: 1315 RVA: 0x00029200 File Offset: 0x00027400
		public void addTakeItems(int itemID, int qty)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemID,
				qty
			});
			if (!this.perso_0.ExchangeManager.TakeItems.ContainsKey(itemID))
			{
				this.perso_0.ExchangeManager.TakeItems.Add(itemID, qty);
			}
			else
			{
				this.perso_0.ExchangeManager.TakeItems[itemID] = qty;
			}
		}

		/// <summary>Permet de supprimer les items a prendre en banque</summary>
		// Token: 0x06000524 RID: 1316 RVA: 0x00004C48 File Offset: 0x00002E48
		public void clearTakeItems()
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.ExchangeManager.TakeItems.Clear();
		}

		/// <summary>Permet d'assigner un objet a acheter en HDV</summary>
		/// <param name="itemID">l'ID de l'item a acheter</param>
		/// <param name="lotMax">Le lot max à acheter d'un coup (1,10,100)</param>
		/// <param name="kamasMax">Le prix unitaire maximum</param>
		// Token: 0x06000525 RID: 1317 RVA: 0x0002927C File Offset: 0x0002747C
		public void addBuyItems(int itemID, int lotMax, int kamasMax)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				itemID,
				lotMax,
				kamasMax
			});
			if (!this.perso_0.ExchangeManager.BuyItems.ContainsKey(itemID))
			{
				this.perso_0.ExchangeManager.BuyItems.Add(itemID, new int[]
				{
					lotMax,
					kamasMax
				});
			}
			else
			{
				this.perso_0.ExchangeManager.BuyItems[itemID] = new int[]
				{
					lotMax,
					kamasMax
				};
			}
		}

		/// <summary>Permet de supprimer les items a acheter en HDV</summary>
		// Token: 0x06000526 RID: 1318 RVA: 0x00004C70 File Offset: 0x00002E70
		public void clearBuyItems()
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.ExchangeManager.BuyItems.Clear();
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00004C98 File Offset: 0x00002E98
		public void method_0()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.ExchangeManager.launcHDV();
		}

		/// <summary>Permet d'utiliser un objet interactif</summary>
		/// <param name="cellID">La cellId de l'objet interactif</param>
		/// <param name="skillID">Optinel : le skillID a utiliser par défaut le premier</param>
		/// <returns>Vrai si réussite sinon faux</returns>
		// Token: 0x06000528 RID: 1320 RVA: 0x0002931C File Offset: 0x0002751C
		public bool use(int cellID, int skillID = 0)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				cellID,
				skillID
			});
			bool result;
			if (result = this.perso_0.interactiveManager.Use(cellID, skillID))
			{
				this.perso_0.launcher.waitAction = 2500;
				try
				{
					foreach (int id in this.perso_0.get_Slave(true))
					{
						Perso comtpesById = Declarations.getComtpesById(id);
						if (!Information.IsNothing(comtpesById))
						{
							comtpesById.interactiveManager.Use(cellID, skillID);
						}
					}
				}
				finally
				{
					List<int>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			return result;
		}

		/// <summary>Permet de definir la map de desination lors de l'utilisation d'un zaap</summary>
		/// <param name="destMapID">La mapid de destination</param>
		// Token: 0x06000529 RID: 1321 RVA: 0x00004CC1 File Offset: 0x00002EC1
		public void setZaapDest(int destMapID)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				destMapID
			});
			this.perso_0.ExchangeManager.destmapid = destMapID;
		}

		/// <summary>Permet d'attendre x millisecondes</summary>
		/// <param name="ms">Nombre de millisecondes</param>
		// Token: 0x0600052A RID: 1322 RVA: 0x00004CEE File Offset: 0x00002EEE
		public void wait(int ms)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				ms
			});
			this.perso_0.launcher.waitAction = ms;
		}

		/// <summary>Permet d'arreter le trajet</summary>
		// Token: 0x0600052B RID: 1323 RVA: 0x00004D21 File Offset: 0x00002F21
		public void Stop()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.LuaTrajet.Stop();
		}

		/// <summary>Permet de définir si le bot en groupe s'attende ou non</summary>
		/// <param name="wait">Si vrai s'attend entre eux sinon non</param>
		// Token: 0x0600052C RID: 1324 RVA: 0x00004D4A File Offset: 0x00002F4A
		public void group(bool wait)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				wait
			});
			this.perso_0.LuaTrajet.waitGroup = wait;
		}

		/// <summary>Permet d'inviter une mule au groupe</summary>
		/// <param name="nom">Le nom de la mule</param>
		// Token: 0x0600052D RID: 1325 RVA: 0x000293E4 File Offset: 0x000275E4
		public void addToGroup(string nom)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				nom
			});
			Perso comtpesByName = Declarations.getComtpesByName(nom);
			comtpesByName.setChef(Conversions.ToInteger(this.perso_0.monIdDofus));
			this.perso_0.launcher.waitAction = 3000;
			comtpesByName.LuaTrajet = new LuaTrajet(this.perso_0.LuaTrajet.script, comtpesByName.monId);
			comtpesByName.mode = 4;
		}

		/// <summary>Permet de monter/descendre de sa drago</summary>
		// Token: 0x0600052E RID: 1326 RVA: 0x00029468 File Offset: 0x00027668
		public void drago()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			this.perso_0.Send(new Message("Rr", 0, false, true, true));
			try
			{
				foreach (int num in this.perso_0.get_Slave(true))
				{
					this.perso_0.Send(new Message("Rr", 0, false, true, true));
				}
			}
			finally
			{
				List<int>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		/// <summary>Permet de recuper la mule selon le nom</summary>
		/// <param name="name">Le nom de la mule</param>
		/// <returns>Un objet LuaBot correspondant à la mule</returns>
		// Token: 0x0600052F RID: 1327 RVA: 0x00029504 File Offset: 0x00027704
		public LuaBot getBot(string name)
		{
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				name
			});
			Perso comtpesByName = Declarations.getComtpesByName(name);
			LuaBot result;
			if (comtpesByName != null)
			{
				result = new LuaBot(comtpesByName);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00029540 File Offset: 0x00027740
		public void echangeToMule(string nom, bool kamas = true)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				nom
			});
			this.perso_0.ExchangeManager.LaunchEchangeToMule(nom, kamas);
			this.perso_0.launcher.waitAction = 2000;
		}

		/// <summary>Permet de deconnecter le bot</summary>
		// Token: 0x06000531 RID: 1329 RVA: 0x00029590 File Offset: 0x00027790
		public void disconnect()
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[0]);
			if (this.perso_0.socket != null)
			{
				this.perso_0.socket.Connexion(false);
				this.perso_0.socket = null;
			}
			if (this.perso_0.sock != null)
			{
				this.perso_0.sock.Connexion(false);
				this.perso_0.sock = null;
			}
			if (this.perso_0.mitm != null)
			{
				this.perso_0.mitm.ProcessExited();
				if (this.perso_0.config.Client != null)
				{
					this.perso_0.config.Client.Kill();
				}
				this.perso_0.status.connexion = status.ConnexionStatus.const_0;
			}
		}

		/// <summary>Permet de connecter un compte</summary>
		/// <param name="accountName">Le nom de compte a connecter</param>
		// Token: 0x06000532 RID: 1330 RVA: 0x0002966C File Offset: 0x0002786C
		public void connect(string accountName)
		{
			this.method_1();
			this.method_2(MethodBase.GetCurrentMethod(), new object[]
			{
				accountName
			});
			Perso comtpesByAccountName = Declarations.getComtpesByAccountName(accountName);
			if (comtpesByAccountName != null && (comtpesByAccountName.status == null || comtpesByAccountName.status.connexion <= status.ConnexionStatus.const_0))
			{
				if (comtpesByAccountName.config.mitm)
				{
					comtpesByAccountName.CreateMitm();
				}
				else
				{
					comtpesByAccountName.Initialiser();
					comtpesByAccountName.CreateSocket(false);
				}
				this.perso_0.launcher.waitAction = checked(30000 + this.perso_0.config.globalSpeed);
			}
		}

		/// <summary>Permet d'envoyer une notification sur mobile via pushFleet</summary>
		/// <param name="msg">Le message à envoyer</param>
		// Token: 0x06000533 RID: 1331 RVA: 0x00004D7D File Offset: 0x00002F7D
		public void sendNotification(string msg)
		{
			Fonctions.sendNotif(msg);
		}

		/// <summary>Permet d'ecrire un message dans le chat du bot (debug)</summary>
		/// <param name="msg">Le message à tracer</param>
		// Token: 0x06000534 RID: 1332 RVA: 0x00004D85 File Offset: 0x00002F85
		public void trace(string msg)
		{
			this.perso_0.chatHandler.AddTextChat(msg, "debug");
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00029704 File Offset: 0x00027904
		private void method_1()
		{
			while (this.perso_0.MessagesToSend.Count > 0)
			{
				Thread.Sleep(20);
			}
			while (this.perso_0.launcher.waitAction > 0)
			{
				Thread.Sleep(20);
			}
			while (!this.perso_0.status.isIdle())
			{
				Thread.Sleep(20);
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0002976C File Offset: 0x0002796C
		private void method_2(MethodBase methodBase_0, object[] object_0)
		{
			string name = methodBase_0.Name;
			this.perso_0.chatHandler.AddTextChat(string.Concat(new string[]
			{
				"Executing ",
				name,
				"(",
				string.Join(",", object_0),
				")"
			}), "debug");
		}

		// Token: 0x04000558 RID: 1368
		private Perso perso_0;
	}
}
