using System;
using RimWorld;
using Verse;
using Garam_RaceAddon;


namespace Mincho_Infection
{
	// Token: 0x02000007 RID: 7
	[DefOf]
	public static class MinchoDefOf
	{
		public static RaceAddonPawnKindDef Mincho_Colonist = new RaceAddonPawnKindDef();
		// Token: 0x04000006 RID: 6
		public static SoundDef Pawn_Mincho_Death = new SoundDef();

		// Token: 0x04000007 RID: 7
		public static RaceAddonThingDef Mincho_ThingDef = new RaceAddonThingDef();

		// Token: 0x04000008 RID: 8
		public static HediffDef Mincho_Infection = new HediffDef();

		public static ThingDef Mincho_Filth_BloodDef = new ThingDef();

		// Token: 0x0600000C RID: 12 RVA: 0x00002706 File Offset: 0x00000906
		static MinchoDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(MinchoDefOf));
		}
	}
}