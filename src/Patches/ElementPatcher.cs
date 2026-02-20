using System;
using HarmonyLib;
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
        const double shrinkPerStep = 0.05; // 每档收缩 5% 的偏离距离
        const int maxShrinkSteps = 5;      // 最多 5 档 → 最大收缩 25%

        if (cost >= costThreshold)
        {
            var steps = Math.Min(cost / costStep, maxShrinkSteps); // 10→1, 20→2, 30→3, 40→4, ≥50→5
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
            __result.cost = CalcCost(__result.cost, spell.Value);
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

        if (__result <= 0)
            return;

        long r = __result;
        r += (int)(r * 0.99f);

        __result = (int)Math.Min(r, int.MaxValue);
    }
}