using System;
using Verse;

namespace Mincho_Infection
{
	// Token: 0x02000003 RID: 3
	public class MinchoInfectionHediffComp : HediffComp
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002414 File Offset: 0x00000614
		public override void CompPostTick(ref float severityAdjustment)
		{
			base.CompPostTick(ref severityAdjustment);
			float severity = this.parent.Severity;
			bool flag = severity >= 0.75f && !this.finalStage;
			if (flag)
			{
				this.parent.comps.RemoveAll((HediffComp x) => x is HediffComp_TendDuration);
				this.finalStage = true;
			}
			bool flag2 = severity >= 1f;
			if (flag2)
			{
				MinchoGenerator.GenerateMincho(base.Pawn, this.parent);
			}
		}

		// Token: 0x04000003 RID: 3
		private bool finalStage = false;
	}
}
