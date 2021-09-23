using RimWorld;
using Verse;

namespace LingGame
{
    public class LingAliComp_Charge : CompAbilityEffect
    {
        public new LingAliCompProperties_Charge Props => (LingAliCompProperties_Charge)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            var comp = ((Building)target.Thing).GetComp<CompPowerBattery>();
            comp.SetStoredEnergyPct((comp.StoredEnergy + Props.Power) / comp.Props.storedEnergyMax);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (target.Thing is Building building && building.GetComp<CompPowerBattery>() != null)
            {
                return true;
            }

            return false;
        }
    }
}