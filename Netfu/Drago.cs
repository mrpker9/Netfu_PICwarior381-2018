using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000010 RID: 16
	public class Drago
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00002800 File Offset: 0x00000A00
		public Drago(Perso p)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.generation = 10;
			this.perso_0 = p;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000665C File Offset: 0x0000485C
		public int Transfert(Drago.TypeStatsDrago t, int time, int ind)
		{
			checked
			{
				if (t != this.currentStats)
				{
					if (this.currentStats == Drago.TypeStatsDrago.Certificat)
					{
						this.perso_0.Send(new Message("ErC" + Conversions.ToString(this.objet.idObjetInv), time, true, true, true));
						this.currentStats = Drago.TypeStatsDrago.Etable;
					}
					if (this.currentStats == Drago.TypeStatsDrago.Enclos)
					{
						this.perso_0.Send(new Message("Efg" + Conversions.ToString(this.id), time, true, true, true));
						this.currentStats = Drago.TypeStatsDrago.Etable;
					}
					if (this.currentStats == Drago.TypeStatsDrago.Equiper)
					{
						this.perso_0.Send(new Message("Erp" + Conversions.ToString(this.id), time, true, true, true));
						this.currentStats = Drago.TypeStatsDrago.Etable;
					}
					if (t == Drago.TypeStatsDrago.Etable)
					{
						return time;
					}
					if (this.currentStats == Drago.TypeStatsDrago.Etable)
					{
						switch (t)
						{
						case Drago.TypeStatsDrago.Certificat:
							this.perso_0.Send(new Message("Erc" + Conversions.ToString(this.id), time + 250, true, true, true));
							this.currentStats = Drago.TypeStatsDrago.Certificat;
							this.objet = null;
							return time + 1000;
						case Drago.TypeStatsDrago.Equiper:
							this.perso_0.Send(new Message("Erg" + Conversions.ToString(this.id), time + 250, true, true, true));
							this.currentStats = Drago.TypeStatsDrago.Equiper;
							return time + 1000;
						case Drago.TypeStatsDrago.Enclos:
							this.perso_0.Send(new Message("Efp" + Conversions.ToString(this.id), time + 250, true, true, true));
							this.currentStats = Drago.TypeStatsDrago.Enclos;
							return time + 1000;
						}
					}
				}
				return time + 1000;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000683C File Offset: 0x00004A3C
		public void scan(int time)
		{
			if (this.currentStats == Drago.TypeStatsDrago.Certificat)
			{
				Effect effect = this.objet.effects.First<Effect>();
				this.perso_0.Send(new Message("Rd" + Conversions.ToString(Convert.ToInt32(Conversions.ToString(effect.min), 16)) + "|" + Conversions.ToString(Convert.ToInt64(Conversions.ToString(effect.max), 16)), time, true, true, true));
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000281C File Offset: 0x00000A1C
		public bool needAmour()
		{
			return this.amour < this.amourM;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000282C File Offset: 0x00000A2C
		public bool needEndu()
		{
			return this.endu < this.enduM;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000283C File Offset: 0x00000A3C
		public bool needMatu()
		{
			return this.maturite < this.maturiteM;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000284C File Offset: 0x00000A4C
		public bool needEnergie()
		{
			return this.energie < this.energieM;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000285C File Offset: 0x00000A5C
		public bool Fatiguer()
		{
			return this.fatigue == this.fatigueM;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000286C File Offset: 0x00000A6C
		public bool Elever()
		{
			return this.amour == this.amour && this.endu == this.enduM && this.maturite == this.maturiteM;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000068B8 File Offset: 0x00004AB8
		public void Update(string str, int ind)
		{
			try
			{
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x04000019 RID: 25
		public string nom;

		// Token: 0x0400001A RID: 26
		public Drago.TypeStatsDrago currentStats;

		// Token: 0x0400001B RID: 27
		public long id;

		// Token: 0x0400001C RID: 28
		public Objets objet;

		// Token: 0x0400001D RID: 29
		private Perso perso_0;

		// Token: 0x0400001E RID: 30
		public int amour;

		// Token: 0x0400001F RID: 31
		public int amourM;

		// Token: 0x04000020 RID: 32
		public int endu;

		// Token: 0x04000021 RID: 33
		public int enduM;

		// Token: 0x04000022 RID: 34
		public int serenite;

		// Token: 0x04000023 RID: 35
		public int niveau;

		// Token: 0x04000024 RID: 36
		public int fatigue;

		// Token: 0x04000025 RID: 37
		public int fatigueM;

		// Token: 0x04000026 RID: 38
		public int energie;

		// Token: 0x04000027 RID: 39
		public int energieM;

		// Token: 0x04000028 RID: 40
		public int reproduction;

		// Token: 0x04000029 RID: 41
		public int reproductionM;

		// Token: 0x0400002A RID: 42
		public int maturite;

		// Token: 0x0400002B RID: 43
		public int maturiteM;

		// Token: 0x0400002C RID: 44
		public bool femelle;

		// Token: 0x0400002D RID: 45
		public int generation;

		// Token: 0x02000011 RID: 17
		public enum TypeStatsDrago
		{
			// Token: 0x0400002F RID: 47
			Certificat,
			// Token: 0x04000030 RID: 48
			Equiper,
			// Token: 0x04000031 RID: 49
			Etable,
			// Token: 0x04000032 RID: 50
			Enclos
		}
	}
}
