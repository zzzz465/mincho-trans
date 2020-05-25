using System;
using Verse;

namespace RW_Mincho
{
	public class MinchoInfectionHediffComp : HediffComp
	{
		private bool finalStage = false;

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
	}
}
