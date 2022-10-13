using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_DamageGiver : CompAbilityEffect
{
    public new CompProperties_AbilityEffect Props => (CompProperties_AbilityEffect)props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        base.Apply(target, dest);
        if (OHasHediff(target.Pawn, DefDatabase<HediffDef>.GetNamed("LingAbiDamageTransfer"), out var ohediff) &&
            ((LingAliHediff_DamageTransfer)ohediff).ppawn == parent.pawn)
        {
            Messages.Message("ItHavrThisAbility".Translate(), MessageTypeDefOf.NeutralEvent);
            return;
        }

        if (OHasHediff(parent.pawn, DefDatabase<HediffDef>.GetNamed("LingAbiDamageTransfer"), out var ohediff2))
        {
            parent.pawn.health.RemoveHediff(ohediff2);
        }

        var lingAliHediff_DamageTransfer =
            (LingAliHediff_DamageTransfer)HediffMaker.MakeHediff(
                DefDatabase<HediffDef>.GetNamed("LingAbiDamageTransfer"), parent.pawn);
        lingAliHediff_DamageTransfer.ppawn = target.Pawn;
        parent.pawn.health.AddHediff(lingAliHediff_DamageTransfer);
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