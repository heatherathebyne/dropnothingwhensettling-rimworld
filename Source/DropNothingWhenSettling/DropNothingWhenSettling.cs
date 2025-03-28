using System;
using HarmonyLib;
using RimWorld.Planet;
using Verse;

namespace DropNothingWhenSettling
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            //Harmony.DEBUG = true;
            var harmony = new Harmony("heatherathebyne.dropnothingwhensettling");
            harmony.PatchAll();
        }
    }
    
    [HarmonyPatch(typeof (CaravanEnterMapUtility), "Enter", new System.Type[] {typeof (Caravan), typeof (Map), typeof (Func<Pawn, IntVec3>), typeof (CaravanDropInventoryMode), typeof (bool)})]
    public class Patch_Enter
    {
        private static void Prefix(ref CaravanDropInventoryMode dropInventoryMode)
        {
            if (dropInventoryMode != CaravanDropInventoryMode.DropInstantly)
                return;
            dropInventoryMode = CaravanDropInventoryMode.DoNotDrop;
        }
    }
}