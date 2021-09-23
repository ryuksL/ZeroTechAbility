using RimWorld;
using Verse;

namespace LingGame
{
    public class Hediff_SkipAndBack : HediffWithComps
    {
        public float backTime;
        public IntVec3 intVec;

        private Mote mote;

        public int ttick;

        public override string LabelInBrackets => backTime - (ttick / 60f) + "S";

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref intVec, "intVec");
            Scribe_Values.Look(ref backTime, "backTime");
            Scribe_Values.Look(ref ttick, "ttick");
        }

        public override void Tick()
        {
            base.Tick();
            ttick++;
            _ = intVec;
            if (pawn.Spawned && !pawn.Dead)
            {
                if (ttick % 3 == 0)
                {
                    var drawPos = pawn.DrawPos;
                    var intVec3 = intVec;
                    var num = ttick / (backTime * 60f);
                    var loc = intVec3.ToVector3() + ((drawPos - intVec3.ToVector3()) * num);
                    FleckMaker.Static(loc, pawn.Map, FleckDefOf.PsycastSkipFlashEntry);
                }

                if (mote == null)
                {
                    mote = MoteMaker.MakeInteractionOverlay(ThingDefOf.Mote_PsychicLinkLine, pawn,
                        new TargetInfo(intVec, pawn.Map));
                }

                mote.Maintain();
                if (!(ttick >= backTime * 60f))
                {
                    return;
                }

                pawn.Position = intVec;
                pawn.Notify_Teleported();
                pawn.health.RemoveHediff(this);
            }
            else
            {
                pawn.health.RemoveHediff(this);
            }
        }
    }
}