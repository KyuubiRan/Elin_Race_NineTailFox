using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NineTailFox;

[BepInPlugin(Constants.ModId, Constants.ModName, Constants.ModVersion)]
internal class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;

        var harmony = new Harmony(Constants.ModId);
        harmony.PatchAll();
    }

    internal static void LogInfo(string msg)
    {
        Log.LogInfo(msg);
    }
    
    internal static void LogInfo(string msg, params object[] args)
    {
        Log.LogInfo(string.Format(msg, args));
    }
}