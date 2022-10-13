using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_DamageToDown : CompAbilityEffect
{
    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        base.Apply(target, dest);
        if (target.Pawn.NonHumanlikeOrWildMan())
        {
            return;
        }

        for (var i = 0; i < 20; i++)
        {
            target.Pawn.health.DropBloodFilth();
            HealthUtility.DamageLegsUntilIncapableOfMoving(target.Pawn, false);
        }
    }
}