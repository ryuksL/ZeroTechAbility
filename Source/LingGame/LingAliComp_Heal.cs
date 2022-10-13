using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_Heal : CompAbilityEffect
{
    public new LingAliCompProperties_Heal Props => (LingAliCompProperties_Heal)props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        var num = 0;
        foreach (var hediff in target.Pawn.health.hediffSet.hediffs)
        {
            if (hediff is Hediff_Injury && hediff.TendableNow())
            {
                hediff.Tended(1f, 0);
                num++;
            }

            if (num >= Props.BindAmount)
            {
                break;
            }
        }
    }
}