using System.Collections.Generic;
using RimWorld;
using Verse;

namespace LingGame
{
    public class LingAliCompProperties_MadBeast : CompProperties_AbilityEffect
    {
        public IntRange Amount;
        public List<PawnKindDef> Animals;

        public bool Weapon = false;
    }
}