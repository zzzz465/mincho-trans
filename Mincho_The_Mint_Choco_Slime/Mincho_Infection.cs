using Garam_RaceAddon;
using System;
using System.Reflection;
//using HarmonyLib;
using Verse;

namespace Mincho_Infection
{
	// Token: 0x02000008 RID: 8
	[StaticConstructorOnStartup]
	public static class Mincho_Infection
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000271C File Offset: 0x0000091C
		static Mincho_Infection()
		{
			//Harmony harmonyInstance = new Harmony("com.rimworld.Dalrae.Mincho_Infection");
			//harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
			//MinchoDefOf.Mincho_ThingDef = new RaceAddonThingDef();
			MinchoDefOf.Mincho_Infection.comps.Add(new HediffCompProperties()
			{
				compClass = typeof(MinchoInfectionHediffComp)
			});
		}
	}
}
