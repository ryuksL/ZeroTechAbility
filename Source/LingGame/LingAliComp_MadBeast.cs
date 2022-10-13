using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_MadBeast : CompAbilityEffect
{
    public new LingAliCompProperties_MadBeast Props => (LingAliCompProperties_MadBeast)props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        Pawn pawn;
        for (var i = 0; i < Props.Amount.RandomInRange; i += (int)pawn.kindDef.combatPower)
        {
            pawn = PawnGenerator.GeneratePawn(Props.Animals.RandomElement());
            GenSpawn.Spawn(pawn, target.Cell, parent.pawn.Map);
            pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("LingAbiHediffFalse"));
            pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Manhunter, null, true);
        }
    }
}