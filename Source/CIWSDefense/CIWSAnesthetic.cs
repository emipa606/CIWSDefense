using System;
using RimWorld;
using Verse;

namespace CIWSDefense
{
    public class CIWSAnesthetic : Verb_Shoot
    {
        protected override bool TryCastShot()
        {
            if (currentTarget.HasThing && currentTarget.Thing.Map != caster.Map)
            {
                return false;
            }

            if (!currentTarget.HasThing)
            {
                return false;
            }

            if (currentTarget.Thing is not Pawn pawn)
            {
                return true;
            }

            var random = new Random();
            var num = random.Next(1, 100);
            if (num >= 50)
            {
                HealthUtility.AdjustSeverity(pawn, HediffDefOf.Anesthetic, 0.8f);
            }

            return true;
        }
    }
}