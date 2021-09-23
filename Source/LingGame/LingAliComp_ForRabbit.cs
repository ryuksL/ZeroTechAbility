using RimWorld;
using Verse;

namespace LingGame
{
    public class LingAliComp_ForRabbit : CompAbilityEffect
    {
        public new CompProperties_AbilityEffect Props => (CompProperties_AbilityEffect)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            var faction = target.Pawn.Faction;
            target.Pawn.Destroy(DestroyMode.KillFinalize);
            var newThing = PawnGenerator.GeneratePawn(DefDatabase<PawnKindDef>.GetNamed("Snowhare"), faction);
            GenSpawn.Spawn(newThing, target.Cell, parent.pawn.Map);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (target.Pawn.kindDef == DefDatabase<PawnKindDef>.GetNamed("Snowhare"))
            {
                return false;
            }

            return base.Valid(target, throwMessages);
        }
    }
}