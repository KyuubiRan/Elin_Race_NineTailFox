using HarmonyLib;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Chara))]
internal class CharaPatcher
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Chara.UseAbility), typeof(Act), typeof(Card), typeof(Point), typeof(bool))]
    static void UseAbility_Postfix(Chara __instance, Act a, Card tc, Point pos, bool pt, ref bool __result)
    {
        if (!__result)
            return;

        if (!__instance.IsPC)
            return;

        if (!RaceNineTailFox.PcRaceIsCurrent)
            return;

        if (a is not Spell spell)
            return;

        if (spell.vPotential <= 1)
        {
            spell.vPotential = 1;
            LayerAbility.SetDirty(a);
        }
    }
}