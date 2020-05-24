using System;
using RimWorld;
using Verse;
using UnityEngine;

namespace Mincho_Infection
{
	public class ThoughtWorker_MintchocoInfection : ThoughtWorker
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000024BC File Offset: 0x000006BC
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			Hediff firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(this.def.hediff, false);
			bool flag = firstHediffOfDef == null || firstHediffOfDef.def.stages == null;
			ThoughtState result;
			if (flag)
			{
				result = ThoughtState.Inactive;
			}
			else
			{
				float severity = firstHediffOfDef.Severity;
				bool flag2 = severity <= 0.25f;
				if (flag2)
				{
					result = ThoughtState.ActiveAtStage(0);
				}
				else
				{
					bool flag3 = severity <= 0.5f;
					if (flag3)
					{
						result = ThoughtState.ActiveAtStage(1);
					}
					else
					{
						bool flag4 = severity <= 0.75f;
						if (flag4)
						{
							result = ThoughtState.ActiveAtStage(2);
						}
						else
						{
							result = ThoughtState.ActiveAtStage(3);
						}
					}
				}
			}
			return result;
		}
	}
}