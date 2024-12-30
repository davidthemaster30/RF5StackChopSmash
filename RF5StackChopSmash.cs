using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace RF5StackChopSmash;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess(GameProcessName)]
public class RF5StackChopSmashPlugin : BasePlugin
{
    internal static new readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource("RF5StackChopSmashBehaviour");
    private const string GameProcessName = "Rune Factory 5.exe";

    public override void Load()
    {
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} {MyPluginInfo.PLUGIN_VERSION} is loading!");

        Harmony.CreateAndPatchAll(typeof(RF5StackChopSmashBehaviour));

        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} {MyPluginInfo.PLUGIN_VERSION} is loaded!");
    }
}