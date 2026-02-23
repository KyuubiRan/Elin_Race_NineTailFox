using System;
using HarmonyLib;
using NineTailFox.SourceDef.Feats;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Element))]
internal class ElementPatcher
{
    private static int CalcCost(int cost, int amount)
    {
        const int minAmount = 1;
        const int midAmount = 500;
        const int maxAmount = 999;

        const double maxFactor = 2.0;
        const double midFactor = 1.0;
        const double minFactor = 0.5;

        double factor;

        switch (amount)
        {
            case <= minAmount:
                factor = maxFactor;
                break;
            case >= maxAmount:
                factor = minFactor;
                break;
            case <= midAmount:
            {
                var t = (double)(amount - minAmount) / (midAmount - minAmount);
                factor = maxFactor + (midFactor - maxFactor) * t;
                break;
            }
            default:
            {
                var t = (double)(amount - midAmount) / (maxAmount - midAmount);
                factor = midFactor + (minFactor - midFactor) * t;
                break;
            }
        }

        const int costThreshold = 10;
        const int costStep = 10;
        const double shrinkPerStep = 0.05;
        const int maxShrinkSteps = 5;

        if (cost >= costThreshold)
        {
            var steps = Math.Min(cost / costStep, maxShrinkSteps);
            var shrinkRate = steps * shrinkPerStep;
            factor = midFactor + (factor - midFactor) * (1.0 - shrinkRate);
        }

        return Math.Max(1, (int)(cost * factor));
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Element.GetCost))]
    static void GetCost_Postfix(Element __instance, Chara c, ref Act.Cost __result)
    {
        if (!c.IsPC)
            return;

        if (c.race.id != RaceNineTailFox.Instance.id)
            return;

        if (__instance is not Spell spell)
            return;

        if (__result.type == Act.CostType.MP)
        {
            var after = CalcCost(__result.cost, spell.vPotential + spell.Value / 9);
            // Plugin.LogInfo("Original MP Cost: " + __result.cost + ", After MP Cost: " + after + " Amount = " + spell.vPotential);
            __result.cost = after;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Element.GetPower))]
    static void GetPower_Postfix(Element __instance, Card c, ref int __result)
    {
        if (!c.IsPC)
            return;

        if (c is not Chara chara)
            return;

        if (chara.race.id != RaceNineTailFox.Instance.id)
            return;

        if (__instance is not Spell)
            return;

        if (__result <= 0)
            return;

        var mod = Math.Max(1, chara.Evalue(FeatNineTailFox.Instance.id)) * 0.11;
        long r = __result;
        r += (long)(r * mod);

        __result = (int)Math.Min(r, int.MaxValue);
    }
}