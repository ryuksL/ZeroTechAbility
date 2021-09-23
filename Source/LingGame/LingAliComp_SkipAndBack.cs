using RimWorld;
using Verse;

namespace LingGame
{
    public class LingAliComp_SkipAndBack : CompAbilityEffect_WithDest
    {
        public new CompProperties_TeleportSkipAndBack Props => (CompProperties_TeleportSkipAndBack)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            var hediff =
                HediffMaker.MakeHediff(DefDatabase<HediffDef>.GetNamed("LingAbiHediffSkipAndBack"), parent.pawn);
            if (hediff is Hediff_SkipAndBack hediff_SkipAndBack)
            {
                hediff_SkipAndBack.intVec = parent.pawn.Position;
                hediff_SkipAndBack.backTime = Props.backTime;
                parent.pawn.health.AddHediff(hediff_SkipAndBack);
            }

            parent.pawn.Position = target.Cell;
            parent.pawn.Notify_Teleported();
        }
    }
}