using HarmonyLib;
using NineTailFox.SourceDef.Abilities;
using NineTailFox.SourceDef.Feats;
using NineTailFox.SourceDef.Jobs;
using NineTailFox.SourceDef.Races;
using NineTailFox.SourceDef.Stats;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(SourceManager))]
public class SourceManagerPatcher
{
    private static void RegisterAll()
    {
        #region Element

        NineTailFoxLoader.Add(AbilityMagicShield.Instance);
        NineTailFoxLoader.Add(FeatNineTailFox.Instance);

        Plugin.Log.LogInfo("Element Registered");

        #endregion

        #region Stat

        NineTailFoxLoader.Add(StatMagicShield.Instance);

        Plugin.Log.LogInfo("Stat Registered");

        #endregion

        #region Job

        NineTailFoxLoader.Add(JobNineTailFox.Instance);

        #endregion

        #region Race

        NineTailFoxLoader.Add(RaceNineTailFox.Instance);

        Plugin.Log.LogInfo("Race Registered");

        #endregion
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(SourceManager.Init))]
    static void Init_Prefix()
    {
        RegisterAll();
    }
}