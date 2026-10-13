using HarmonyLib;
using RimWorld;
using Verse;

namespace VoidTouchedIsNotDisturbing
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("rimworld.uranv.voidtouchednotdisturbing");
            harmony.PatchAll();
        }
    }
    [HarmonyPatch(typeof(Pawn_StoryTracker), "IsDisturbing", MethodType.Getter)]
    class Pawn_StoryTracker_IsDisturbing_Patch
    {
        [HarmonyPostfix]
        public static void IsDisturbingPostfix(ref bool __result, Pawn_StoryTracker __instance)
        {
            if (__result && !__instance.traits.HasTrait(TraitDefOf.Disturbing))
            {
                __result = false;
                //Log.Error("[Modify Success] Patched IsDisturbing for a Void-Touched pawn.");
            }
        }
    }
}