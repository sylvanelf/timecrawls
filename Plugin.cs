using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace timeflies
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            Logger.LogInfo($"                  ##########                     v. {PluginInfo.PLUGIN_VERSION}");
            Logger.LogInfo($"=============  ##          ##");
            Logger.LogInfo($"=========   ##      ##      ##");
            Logger.LogInfo($"========  ##       ##         ##");
            Logger.LogInfo($"=======  ##       ##         ##");
            Logger.LogInfo($"======  ##       ##         ##");
            Logger.LogInfo($"=====  ##          ##      ##");
            Logger.LogInfo($"====  ##            ##    ##");
            Logger.LogInfo($"        ##              ##");
            Logger.LogInfo($"         ##          ##           Time Flies");
            Logger.LogInfo($"           ##########             When You're Having Fun!");
            new Harmony(PluginInfo.PLUGIN_GUID).PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(TimeOfDay), "Start")]
    internal class TimeOfDayPatch
    {
        public static void Prefix(ref TimeOfDay __instance)
        {
            Plugin.Log.LogInfo($"old globalTimeSpeedMultiplier was {__instance.globalTimeSpeedMultiplier}");
            __instance.globalTimeSpeedMultiplier = 15f;
        }
    }
}
