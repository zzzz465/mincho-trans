using System;
using System.Collections.Generic;
using System.Linq;
using Garam_RaceAddon;
using RimWorld;
using Verse;
using Verse.Sound;

namespace Mincho_Infection
{
	// Token: 0x02000002 RID: 2
	internal static class MinchoGenerator
	{
		/*
		public PawnGenerationRequest(
		PawnKindDef kind, 
		Faction faction = null, 
		PawnGenerationContext context = PawnGenerationContext.NonPlayer, 
		int tile = -1, 
		bool forceGenerateNewPawn = false, 
		bool newborn = false, 
		bool allowDead = false, 
		bool allowDowned = false, 
		bool canGeneratePawnRelations = true, 
		bool mustBeCapableOfViolence = false, 
		float colonistRelationChanceFactor = 1, 
		bool forceAddFreeWarmLayerIfNeeded = false, 
		bool allowGay = true, 
		bool allowFood = true, 
		bool allowAddictions = true, 
		bool inhabitant = false, 
		bool certainlyBeenInCryptosleep = false, 
		bool forceRedressWorldPawnIfFormerColonist = false, 
		bool worldPawnFactionDoesntMatter = false, 
		float biocodeWeaponChance = 0, 
		Pawn extraPawnForExtraRelationChance = null, 
		float relationWithExtraPawnChanceFactor = 1, 
		Predicate<Pawn> validatorPreGear = null, 
		Predicate<Pawn> validatorPostGear = null, 
		IEnumerable<TraitDef> forcedTraits = null, 
		IEnumerable<TraitDef> prohibitedTraits = null, 
		float? minChanceToRedressWorldPawn = null, 
		float? fixedBiologicalAge = null, 
		float? fixedChronologicalAge = null, 
		Gender? fixedGender = null, 
		float? fixedMelanin = null, 
		string fixedLastName = null, 
		string fixedBirthName = null, 
		RoyalTitleDef fixedTitle = null);

	*/

		public static Backstory C_01_The_first_Mincho = BackstoryDatabase.allBackstories.ToList<KeyValuePair<string, Backstory>>().Find((KeyValuePair<string, Backstory> x) => x.Value.untranslatedTitle == "C_01_The_first_Mincho").Value;

		public static Backstory C_02_Mincho_poultice = BackstoryDatabase.allBackstories.ToList<KeyValuePair<string, Backstory>>().Find((KeyValuePair<string, Backstory> x) => x.Value.untranslatedTitle == "C_02_Mincho_poultice").Value;

		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		internal static void GenerateMincho(Pawn pawn, Hediff hediff)
		{
			PawnGenerationRequest pawnGenerationRequest = new PawnGenerationRequest(
				MinchoDefOf.Mincho_Colonist,
				Faction.OfPlayer,
				(PawnGenerationContext)2,
				-1,
				false,
				false,
				false,
				false,
				false,
				false,
				0f,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				false,
				0,
				null,
				0, null, null, null, null, null, pawn.ageTracker.AgeBiologicalYearsFloat, pawn.ageTracker.AgeChronologicalYearsFloat, null, 0, null, null, null);

			for (int i = 0; i < 9; i++)
			{
				IntVec3 intVec = pawn.Position + GenRadial.RadialPattern[i];
				bool flag = GenGrid.InBounds(intVec, pawn.Map) && GridsUtility.GetRoom(pawn.Position, pawn.Map, (RegionType)6) == GridsUtility.GetRoom(intVec, pawn.Map, (RegionType)6);
				if (flag)
				{
					FilthMaker.TryMakeFilth(pawn.Position, pawn.Map, MinchoDefOf.Mincho_Filth_BloodDef, GenText.LabelIndefinite(pawn), Rand.RangeInclusive(0, 4));
				}
			}
			Pawn pawn2 = PawnGenerator.GeneratePawn(pawnGenerationRequest);
			pawn2.Name = pawn.Name;



			if (pawn.IsColonist == true | pawn.IsColonistPlayerControlled == true)
			{
				foreach (KeyValuePair<string, Backstory> asd1 in BackstoryDatabase.allBackstories)
				{
					if (asd1.Value.untranslatedTitle == "The first Mincho")
					{
						pawn2.story.childhood = asd1.Value;
						break;
					}
					if (asd1.Value.untranslatedTitleFemale == "The first Mincho")
					{
						pawn2.story.childhood = asd1.Value;
						break;
					}
				}

				foreach (Pawn asd1 in pawn.relations.RelatedPawns)
				{
					foreach (DirectPawnRelation asd2 in asd1.relations.DirectRelations)
					{
						asd1.relations.RemoveDirectRelation(asd2);
					}
					foreach (DirectPawnRelation asd2 in pawn.relations.DirectRelations)
					{
						pawn2.relations.AddDirectRelation(asd2.def, asd1);
					}
				}


				//pawn2.story.childhood = BackstoryDatabase.allBackstories.ToList<KeyValuePair<string, Backstory>>().Find((KeyValuePair<string, Backstory> x) => x.Value.untranslatedTitle == "The first Mincho").Value;
				pawn2.skills.skills = pawn.skills.skills;
				foreach (Trait asd1 in pawn.story.traits.allTraits)
				{
					if (asd1.def.ToString() == "Nudist")
					{
						pawn.story.traits.allTraits.Remove(asd1);
					}
				}
				pawn2.story.traits.allTraits = pawn.story.traits.allTraits;
			}
			else
			{

				foreach (KeyValuePair<string, Backstory> asd1 in BackstoryDatabase.allBackstories)
				{
					if (asd1.Value.untranslatedTitle == "Mincho poultice")
					{
						pawn2.story.childhood = asd1.Value;
						break;
					}
					if (asd1.Value.untranslatedTitleFemale == "Mincho poultice")
					{
						pawn2.story.childhood = asd1.Value;
						break;
					}
				}
				//pawn2.story.childhood = BackstoryDatabase.allBackstories.ToList<KeyValuePair<string, Backstory>>().Find((KeyValuePair<string, Backstory> x) => x.Value.untranslatedTitle == "Mincho poultice").Value;
				pawn2.skills.skills = pawn.skills.skills;
				foreach (Trait asd1 in pawn.story.traits.allTraits)
				{
					if (asd1.def.ToString() == "Nudist")
					{
						pawn.story.traits.allTraits.Remove(asd1);
					}
					foreach (TraitDegreeData asd2 in asd1.def.degreeDatas)
					{
						if (asd2.untranslatedLabel == "Nudist")
						{
							pawn.story.traits.allTraits.Remove(asd1);
						}
					}
				}
				pawn2.story.traits.allTraits = pawn.story.traits.allTraits;
			}
				pawn2.story.adulthood = null;


				/*
				if (pawn.Faction != null)
				{
					pawn.Faction.TryAffectGoodwillWith(Faction.OfPlayer, -40, true, true, TranslatorFormattedStringExtensions.Translate("MinchoTransform", pawn.Name.ToStringShort), null);
				}
				*/

				//pawn.health.RemoveHediff(hediff);
				Map map = pawn.Map;
				pawn.Kill(null);

				CompRottable comp = pawn.Corpse.GetComp<CompRottable>();
				if (comp != null)
				{
					comp.RotProgress = (float)(comp.TicksUntilRotAtCurrentTemp * 2);
				}


				//Messages.Message(TranslatorFormattedStringExtensions.Translate("MinchoTransform", pawn.Name.ToStringShort), MessageTypeDefOf.NegativeHealthEvent, true);
				pawn2.apparel.DestroyAll(0);
				GenSpawn.Spawn(pawn2, pawn.Position, map, 0);
				//SoundStarter.PlayOneShot(MinchoDefOf.Pawn_Mincho_Death, SoundInfo.InMap(pawn, 0));
				MinchoGenerator.MakeWildMan(pawn2, pawn);
				Find.TickManager.Pause();
			}




			// Token: 0x06000002 RID: 2 RVA: 0x00002350 File Offset: 0x00000550
			private static void MakeWildMan(Pawn pawn, Pawn orgpawn)
			{
				if (orgpawn.IsColonist)
				{
					pawn.ChangeKind(PawnKindDefOf.Colonist);
					pawn.SetFaction(orgpawn.Faction, pawn);
				}
				else {
					pawn.ChangeKind(PawnKindDefOf.WildMan);
					bool flag = pawn.Faction != null;
					if (flag)
					{
						pawn.SetFaction(null, null);
					}
				}

				bool flag2 = pawn.Spawned && !pawn.Downed;
				if (flag2)
				{
					pawn.jobs.StopAll(false);
				}
			}

		}
	}

