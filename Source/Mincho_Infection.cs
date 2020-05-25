using Garam_RaceAddon;
using System;
using System.Reflection;
using Verse;

namespace RW_Mincho
{
	[StaticConstructorOnStartup]
	public static class Mincho_Infection
	{
		static Mincho_Infection()
		{
			MinchoDefOf.Mincho_Infection.comps.Add(new HediffCompProperties()
			{
				compClass = typeof(MinchoInfectionHediffComp)
			});
		}
	}
}
