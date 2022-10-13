using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_DamageTransfer : CompAbilityEffect
{
    public new CompProperties_AbilityEffect Props => (CompProperties_AbilityEffect)props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        base.Apply(target, dest);
        if (OHasHediff(parent.pawn, DefDatabase<HediffDef>.GetNamed("LingAbiDamageTransfer"), out var ohediff) &&
            ((LingAliHediff_DamageTransfer)ohediff).ppawn == target.Pawn)
        {
            Messages.Message("ItHavrThisAbility".Translate(), MessageTypeDefOf.NeutralEvent);
            return;
        }

        var lingAliHediff_DamageTransfer =
            (LingAliHediff_DamageTransfer)HediffMaker.MakeHediff(
                DefDatabase<HediffDef>.GetNamed("LingAbiDamageTransfer"), target.Pawn);
        lingAliHediff_DamageTransfer.ppawn = parent.pawn;
        target.Pawn.health.AddHediff(lingAliHediff_DamageTransfer);
    }

    private bool OHasHediff(Pawn pawn, HediffDef def, out Hediff ohediff)
    {
        ohediff = null;
        foreach (var hediff in pawn.health.hediffSet.hediffs)
        {
            if (hediff.def != def)
            {
                continue;
            }

            ohediff = hediff;
            return true;
        }

        return false;
    }
}