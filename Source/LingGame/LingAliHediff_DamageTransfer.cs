using RimWorld;
using Verse;

namespace LingGame
{
    public class LingAliHediff_DamageTransfer : HediffWithComps
    {
        private MoteDualAttached mote;
        public Pawn ppawn;

        public override string LabelInBrackets => Severity.ToString("f2") + "D," + ppawn.Name.ToStringShort;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Deep.Look(ref ppawn, "ppawn");
        }

        public override void Tick()
        {
            base.Tick();
            if (ppawn is { Spawned: true, Dead: false })
            {
                // Hediff gets removed
                // ReSharper disable once ForCanBeConvertedToForeach
                for (var index = 0; index < pawn.health.hediffSet.hediffs.Count; index++)
                {
                    var hediff = pawn.health.hediffSet.hediffs[index];
                    if (hediff is not Hediff_Injury)
                    {
                        continue;
                    }

                    if (pawn.RaceProps != ppawn.RaceProps)
                    {
                        var severity = hediff.Severity;
                        ppawn.TakeDamage(new DamageInfo(DamageDefOf.SurgicalCut, severity, 2f));
                        pawn.health.RemoveHediff(hediff);
                        return;
                    }

                    if (ppawn.health.hediffSet.PartIsMissing(hediff.Part))
                    {
                        continue;
                    }

                    ppawn.health.AddHediff(hediff);
                    pawn.health.RemoveHediff(hediff);
                    return;
                }

                if (mote == null)
                {
                    mote = MoteMaker.MakeInteractionOverlay(ThingDefOf.Mote_PsychicLinkLine, pawn, ppawn);
                }

                mote.Maintain();
            }
            else
            {
                mote = null;
                pawn.health.RemoveHediff(this);
            }
        }

        public override void PostRemoved()
        {
            base.PostRemoved();
            mote = null;
        }
    }
}