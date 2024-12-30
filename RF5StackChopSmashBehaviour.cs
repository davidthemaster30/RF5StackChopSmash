using HarmonyLib;

namespace RF5StackChopSmash;

[HarmonyPatch]
public static class RF5StackChopSmashBehaviour
{
    private static bool LastHit { get; set; } = false;

    [HarmonyPatch(typeof(OnGroundItem), nameof(OnGroundItem.DoBreak))]
    [HarmonyPostfix]
    public static void BreakRocks(HumanController? humanController, OnGroundItem __instance)
    {
        try
        {
            if (__instance is null || __instance.ItemData is null)
            {
                return;
            }

            if (__instance.ItemData.Amount == 1 && !LastHit)
            {
                LastHit = true;
                __instance.DoBreak(humanController);
            }

            if (__instance.ItemData.Amount > 1)
            {
                __instance.DoBreak(humanController);
            }

            LastHit = false;
        }
        catch (Exception error)
        {
            RF5StackChopSmashPlugin.Log.LogError($"{error}");
        }
    }

    [HarmonyPatch(typeof(OnGroundItem), nameof(OnGroundItem.DoChop))]
    [HarmonyPostfix]
    public static void ChopBranches(HumanController? humanController, OnGroundItem __instance)
    {
        try
        {
            if (__instance is null || __instance.ItemData is null)
            {
                return;
            }

            if (__instance.ItemData.Amount == 1 && !LastHit)
            {
                LastHit = true;
                __instance.DoChop(humanController);
            }

            if (__instance.ItemData.Amount > 1)
            {
                __instance.DoChop(humanController);
            }

            LastHit = false;
        }
        catch (Exception error)
        {
            RF5StackChopSmashPlugin.Log.LogError($"{error}");
        }
    }
}
