using HarmonyLib;
using NineTailFox.I18n;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Lang))]
internal class LangPatcher
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Lang.Init), typeof(string))]
    static void Init_Postfix(string lang)
    {
        LocalizationManager.NotifyChanged(lang);
    }
}