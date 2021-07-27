using HarmonyLib;
using System.Reflection;
using Verse;

namespace AbilitiesCooldown
{
    [StaticConstructorOnStartup]
    internal static class GN_HarmonyInitialise
    {
        static GN_HarmonyInitialise()
        {
            var harmony = new Harmony("com.company.QarsoonMeel.AbilitiesCooldownRimWorld");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}