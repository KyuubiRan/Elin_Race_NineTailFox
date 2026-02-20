using System.Collections.Generic;
using HarmonyLib;
using NineTailFox.Impl.Base;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Feat))]
internal class FeatPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Feat.Apply))]
    static void Apply_Prefix(Feat __instance, int a, ElementContainer owner, bool hint)
    {
        if (__instance is not BaseNTFFeat feat)
            return;

        feat.ApplyPre(a, owner, hint);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Feat.Apply))]
    static void Apply_Postfix(Feat __instance, int a, ElementContainer owner, bool hint, List<string> __result)
    {
        if (__instance is not BaseNTFFeat feat)
            return;

        feat.ApplyPost(a, owner, hint);
    }
}