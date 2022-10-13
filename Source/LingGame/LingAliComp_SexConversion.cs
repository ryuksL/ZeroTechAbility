using RimWorld;
using Verse;

namespace LingGame;

public class LingAliComp_SexConversion : CompAbilityEffect
{
    public new LingAliCompProperties_SexConversion Props => (LingAliCompProperties_SexConversion)props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        base.Apply(target, dest);
        switch (target.Pawn.gender)
        {
            case Gender.Male:
            {
                target.Pawn.gender = Gender.Female;
                if (target.Pawn.story.bodyType == BodyTypeDefOf.Male)
                {
                    target.Pawn.story.bodyType = BodyTypeDefOf.Female;
                }

                break;
            }
            case Gender.Female:
            {
                target.Pawn.gender = Gender.Male;
                if (target.Pawn.story.bodyType == BodyTypeDefOf.Female)
                {
                    target.Pawn.story.bodyType = BodyTypeDefOf.Male;
                }

                break;
            }
        }

        target.Pawn.Drawer.renderer.graphics.ResolveAllGraphics();
    }
}