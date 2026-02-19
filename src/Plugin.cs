using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NineTailFox;

[BepInPlugin(Constants.ModId, Constants.ModName, Constants.ModVersion)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;

        var harmony = new Harmony(Constants.ModId);
        harmony.PatchAll();
    }
}