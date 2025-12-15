using HarmonyLib;
using RimWorld;
using RimWorld.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using static HarmonyLib.Code;
using static RimWorld.PsychicRitualRoleDef_DeathRefusalTarget;

namespace VoidTouchedIsNotDisturbing
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("rimworld.uranv.voidtouchednotdisturbing");
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
                //Log.Error("[Modify Successed] Patched IsDisturbing for a Void-Touched pawn.");
            }
        }
    }
}