using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace AbilitiesCooldown
{
    [HarmonyPatch(typeof(Ability), "AbilityTick")]
    public static class AC_NotificationPatch
    {
        private static FieldInfo cooldownTicks = AccessTools.Field(typeof(Ability), "cooldownTicks");

        [HarmonyPostfix]
        public static void NotificationPostfix(Ability __instance)
        {
            if (__instance.def.defName == "Convert" && (int)cooldownTicks.GetValue(__instance) == 0)
            {
                int cooldown = -1;
                cooldownTicks.SetValue(__instance, cooldown);
                Messages.Message("Your chaplain can cast abilities again.", __instance.pawn, MessageTypeDefOf.PositiveEvent, false);
            }
        }
    }
}