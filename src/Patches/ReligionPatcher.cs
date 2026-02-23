using HarmonyLib;
using NineTailFox.I18n;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Religion))]
internal class ReligionPatcher
{
    private static TranslatedText _text = new("chat.NineTailFox.Religion.Punish");

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Religion.Punish))]
    static bool Punish_Prefix(Religion __instance, Chara c)
    {
        if (!c.IsPC)
            return true;

        if (c.race.id != RaceNineTailFox.Instance.id)
            return true;

        __instance.Talk("wrath");
        c.Say(_text.Value);

        return false;
    }
}