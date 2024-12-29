using HarmonyLib;

namespace RF5StackChopSmash;

[HarmonyPatch]
internal static class RF5StackChopSmashBehaviour
{
    [HarmonyPatch(typeof(OnGroundItem), nameof(OnGroundItem.DoSmash))]
    [HarmonyPostfix]
    internal static void SmashRocks(HumanController humanController, OnGroundItem __instance)
    {
        if (__instance?.ItemData?.Amount > 0)
        {
            __instance.DoSmash(humanController);
        }
    }

    [HarmonyPatch(typeof(OnGroundItem), nameof(OnGroundItem.DoChop))]
    [HarmonyPostfix]
    internal static void ChopBranches(HumanController humanController, OnGroundItem __instance)
    {
        if (__instance?.ItemData?.Amount > 0)
        {
            __instance.DoChop(humanController);
        }
    }
}