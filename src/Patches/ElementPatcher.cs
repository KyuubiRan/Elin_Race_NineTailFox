using System;
using HarmonyLib;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Element))]
internal class ElementPatcher
{
    private static int CalcCost(int cost, int amount)
    {
        var factor = amount <= 1
            ? 2.0
            : amount >= 999
                ? 0.5
                : amount <= 500
                    ? 2.0 - (amount - 1) * (1.0 / 499.0) // 1..500: 2.0 -> 1.0
                    : 1.0 - (amount - 500) * (0.5 / 499.0); // 500..999: 1.0 -> 0.5

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