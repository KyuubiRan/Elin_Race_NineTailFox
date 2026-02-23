using HarmonyLib;
using NineTailFox.I18n;
using NineTailFox.SourceDef.Feats;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Religion))]
internal class ReligionPatcher
{
    private static TranslatedText _text = new("chat.NineTailFox.Religion.ImmunePunish");

    private static bool PunishLogic(Religion __instance, Chara c)
    {
        if (!c.IsPC)
            return true;

        if (!c.HasElement(FeatNineTailFox.Instance.id))
            return true;

        Msg.SetColor(Msg.colors.TalkGod);
        Msg.SayRaw(_text.Value);
        Plugin.LogInfo($"ImmunePunish: {_text.Value}");

        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Religion.Punish))]
    static bool Punish_Prefix(Religion __instance, Chara c)
    {
        return PunishLogic(__instance, c);
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Religion.PunishTakeOver))]
    static bool PunishTakeOver_Prefix(Religion __instance, Chara c)
    {
        return PunishLogic(__instance, c);
    }
}