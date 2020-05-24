using RimWorld;
using System;
using Verse;

namespace Mincho_Infection
{
	// Token: 0x02000003 RID: 3
	public class MinchoInfectionHediffComp : HediffComp
	{
		private bool finalStage;

		// Token: 0x06000004 RID: 4 RVA: 0x00002414 File Offset: 0x00000614
		public override void CompPostTick(ref float severityAdjustment)
		{
			base.CompPostTick(ref severityAdjustment);

	
		//if (this.parent.Severity >= 0.75f & !this.finalStage)
		//{
		//this.parent.comps.RemoveAll((HediffComp x) => x is HediffComp_TendDuration);
		//this.finalStage = true;
		//}
			if (base.parent.Severity >= 1.00f)
			{
				MinchoGenerator.GenerateMincho(base.Pawn, this.parent);
			}
		}
	}
}
