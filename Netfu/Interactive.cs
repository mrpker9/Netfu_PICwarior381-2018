using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication2
{
	// Token: 0x02000066 RID: 102
	public class Interactive
	{
		// Token: 0x06000217 RID: 535 RVA: 0x000033CC File Offset: 0x000015CC
		static Interactive()
		{
			Class15.XRATSHnz66atd();
			Interactive.hYtGzdtOvZ = new Random();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00011FF0 File Offset: 0x000101F0
		public Perso bot()
		{
			return Declarations.getComtpesByIndex(this.int_0);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000033DD File Offset: 0x000015DD
		public Interactive(int index)
		{
			Class15.XRATSHnz66atd();
			base..ctor();
			this.int_0 = index;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0001200C File Offset: 0x0001020C
		public List<Ressources> ToUsables()
		{
			List<Ressources> source = this.bot().map.GetUsableRessource(true).ToList<Ressources>();
			return (from c in source
			orderby this.bot().map.mapDataActuel[c.Cellid].ManhattanDistanceTo(this.bot().map.mapDataActuel[this.bot().map.myActor().Cell])
			select c).ToList<Ressources>();
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0001204C File Offset: 0x0001024C
		public bool TryUse()
		{
			Interactive._Closure$__9-0 CS$<>8__locals1 = new Interactive._Closure$__9-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Me = this;
			checked
			{
				bool result;
				if (Information.IsNothing(this.bot().Jobs))
				{
					result = false;
				}
				else
				{
					List<Ressources> list = this.ToUsables();
					CS$<>8__locals1.$VB$Local_skills = this.bot().Jobs.mySkills().Select((Interactive._Closure$__.$I9-0 == null) ? (Interactive._Closure$__.$I9-0 = ((Skill s) => s._nID)) : Interactive._Closure$__.$I9-0).ToList<int>();
					if (!Information.IsNothing(this.bot().map) && !Information.IsNothing(this.bot().map.myActor()))
					{
						if (list.Count <= 0)
						{
							return false;
						}
						int num = 0;
						this.bot().movement.destAction = "recolte";
						Cell cell = null;
						while (Information.IsNothing(cell))
						{
							if (this.bot().status.connexion != status.ConnexionStatus.const_3)
							{
								return true;
							}
							if (num >= list.Count)
							{
								return false;
							}
							if (this.Currentressource != null && this.Currentressource.Cellid == list[num].Cellid)
							{
								this.Currentressource = null;
								num++;
							}
							else
							{
								this.Currentressource = list[num];
								Cell cell2 = this.bot().map.mapDataActuel[this.Currentressource.Cellid];
								SkillDescription skillDescription = Loader.smethod_10(this.Currentressource.id).Skills.FirstOrDefault((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = ((SkillDescription s) => !Information.IsNothing(s.item) && CS$<>8__locals1.$VB$Local_skills.Contains(s.id) && CS$<>8__locals1.$VB$Me.bot().config.listRessourcesRecolt.Contains(s.id))) : CS$<>8__locals1.$I1);
								List<Cell> list2;
								if (Operators.CompareString(skillDescription.nom, "Pêcher", false) != 0)
								{
									bool diagonals = Operators.CompareString(skillDescription.nom, "Couper", false) != 0;
									list2 = (from c in cell2.GetAdjacentCells(true, diagonals, 1)
									where Conversions.ToBoolean(c.isWalkable(this.bot(), true))
									select c).ToList<Cell>();
								}
								else
								{
									list2 = (List<Cell>)cell2.GetAllCellsInRange(1, this.bot().config.portecanne, false, (Cell c) => Conversions.ToBoolean(c.isWalkable(this.bot(), true)));
								}
								if (list2.Count > 0)
								{
									Interactive._Closure$__9-1 CS$<>8__locals2 = new Interactive._Closure$__9-1(CS$<>8__locals2);
									CS$<>8__locals2.$VB$Local_mychar = this.bot().myCharacter;
									list2 = (from c in list2
									orderby c.distance(CS$<>8__locals2.$VB$Local_mychar.Cell)
									select c).ToList<Cell>();
									cell = list2.FirstOrDefault<Cell>();
									if ((Operators.CompareString(skillDescription.nom, "Faucher", false) == 0 || Operators.CompareString(skillDescription.nom, "Cueillir", false) == 0) && cell.Id != CS$<>8__locals2.$VB$Local_mychar.Cell)
									{
										cell = cell2;
									}
								}
								else
								{
									this.bot().map.delRessourceByCellid(this.Currentressource.Cellid);
									list.Remove(this.Currentressource);
								}
								if (!this.bot().Inventaire.EquipeJobItem(skillDescription.job.id))
								{
									this.bot().map.delRessourceByCellid(this.Currentressource.Cellid);
									return true;
								}
							}
						}
						if (this.bot().movement.SeDeplacer(cell.Id, -1))
						{
							return true;
						}
						this.bot().map.delRessourceByCellid(this.Currentressource.Cellid);
						Cell cell3 = this.bot().map.mapDataActuel.FirstOrDefault((Cell c) => c.Id == this.Currentressource.Cellid);
						cell3.movement = 0;
					}
					result = true;
				}
				return result;
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00012400 File Offset: 0x00010600
		public bool Use(int destcell = -1, int skillTouse = 0)
		{
			bool result;
			if (destcell == -1)
			{
				result = this.TryUse();
			}
			else
			{
				this.destcell = destcell;
				this.skillToUse = skillTouse;
				result = this.method_0();
			}
			return result;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00012434 File Offset: 0x00010634
		private bool method_0()
		{
			if (!Information.IsNothing(this.bot().map) && !Information.IsNothing(this.bot().map.myActor()))
			{
				Ressources ressources = this.bot().map.GetUsableRessource(false).FirstOrDefault((Ressources u) => u.Cellid == this.destcell);
				if (ressources != null)
				{
					this.bot().movement.destAction = "use";
					this.Currentressource = ressources;
					SkillDescription skillDescription = Loader.smethod_10(this.Currentressource.id).Skills.Where((Interactive._Closure$__.$I11-1 == null) ? (Interactive._Closure$__.$I11-1 = ((SkillDescription s) => s != null)) : Interactive._Closure$__.$I11-1).ElementAtOrDefault(this.bot().interactiveManager.skillToUse);
					if (skillDescription.job != null && !this.bot().Inventaire.EquipeJobItem(skillDescription.job.id))
					{
						return false;
					}
					Cell cell = (from c in this.bot().map.mapDataActuel[ressources.Cellid].GetAdjacentCells(true, true, 1)
					where Conversions.ToBoolean(c.isWalkable(this.bot(), true))
					select c).FirstOrDefault<Cell>();
					return this.bot().movement.SeDeplacer(cell.Id, -1);
				}
			}
			return false;
		}

		// Token: 0x040002C1 RID: 705
		private int int_0;

		// Token: 0x040002C2 RID: 706
		public Ressources Currentressource;

		// Token: 0x040002C3 RID: 707
		public int destcell;

		// Token: 0x040002C4 RID: 708
		public int skillToUse;

		// Token: 0x040002C5 RID: 709
		private static Random hYtGzdtOvZ;
	}
}
