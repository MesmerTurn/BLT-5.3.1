using BannerlordTwitch.Localization;
using BannerlordTwitch.UI;
using JetBrains.Annotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BLTAdoptAHero.Prestige
{
    public class PrestigeLevelDef
    {
        [LocDisplayName("Gold Per Kill Bonus %"),
         LocDescription("Added to cumulative gold bonus for each kill (stacks with lower prestige levels)."),
         PropertyOrder(0), UsedImplicitly]
        public int GoldPerKillBonusPercent { get; set; } = 15;

        [LocDisplayName("XP Multiplier Bonus"),
         LocDescription("Added to cumulative XP multiplier (0.0 = no change, 1.0 = double XP from this level alone)."),
         PropertyOrder(1), UsedImplicitly]
        public float XPMultiplierBonus { get; set; } = 0.0f;

        [LocDisplayName("Chat Title"),
         LocDescription("Tag shown next to hero name in chat messages at this prestige level."),
         PropertyOrder(2), UsedImplicitly]
        public string ChatTitle { get; set; } = "";

        [LocDisplayName("Start Battle Invincible Seconds"),
         LocDescription("Seconds of invincibility at the start of each battle. 0 = disabled."),
         PropertyOrder(3), UsedImplicitly]
        public int StartBattleInvincibleSeconds { get; set; } = 0;
    }
}
