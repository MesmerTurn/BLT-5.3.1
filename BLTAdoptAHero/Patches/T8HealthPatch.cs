using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace BLTAdoptAHero.Patches
{
    // Doubles the health limit for heroes who have reached Tier 8 equipment.
    [HarmonyPatch(typeof(Agent), "BaseHealthLimit", MethodType.Getter), UsedImplicitly]
    public static class T8HealthPatch
    {
        [UsedImplicitly]
        public static void Postfix(Agent __instance, ref float __result)
        {
            var hero = __instance.Character?.HeroObject;
            if (hero == null) return;
            if (BLTAdoptAHeroCampaignBehavior.Current?.GetEquipmentTier(hero) >= 7)
                __result *= 2f;
        }
    }
}
