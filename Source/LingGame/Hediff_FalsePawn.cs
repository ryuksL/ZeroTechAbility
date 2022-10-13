using Verse;

namespace LingGame;

public class Hediff_FalsePawn : HediffWithComps
{
    public override void Notify_PawnDied()
    {
        base.Notify_PawnDied();
        if (pawn.Corpse.Spawned)
        {
            pawn.Corpse.Destroy();
        }
    }
}