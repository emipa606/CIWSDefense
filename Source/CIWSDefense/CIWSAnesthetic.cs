using System;
using RimWorld;
using Verse;

namespace CIWSDefense;

public class CIWSAnesthetic : Verb_Shoot
{
    protected override bool TryCastShot()
    {
        switch (currentTarget.HasThing)
        {
            case true when currentTarget.Thing.Map != caster.Map:
            case false:
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