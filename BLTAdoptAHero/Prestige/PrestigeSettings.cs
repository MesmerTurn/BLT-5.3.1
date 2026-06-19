using System.Collections.Generic;
using BannerlordTwitch.Localization;
using BannerlordTwitch.UI;
using JetBrains.Annotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BLTAdoptAHero.Prestige
{
    public class PrestigeSettings
    {
        [LocDisplayName("Require Kills"),
         LocDescription("Battle kills required before !prestige can be used. 0 = no kill requirement."),
         PropertyOrder(0), UsedImplicitly]
        public int RequireKills { get; set; } = 500;

        [LocDisplayName("Require Channel Points"),
         LocDescription("If enabled, !prestige only works when triggered as a Channel Point Reward (not a free command)."),
         PropertyOrder(1), UsedImplicitly]
        public bool RequireChannelPoints { get; set; } = true;

        [LocDisplayName("Channel Points Cost"),
         LocDescription("Channel points cost shown to viewers. Set the same value on the Twitch reward in BLT Configure."),
         PropertyOrder(2), UsedImplicitly]
        public int ChannelPointsCost { get; set; } = 25000;

        [LocDisplayName("Max Prestige Level"),
         LocDescription("Maximum prestige level. Must not exceed the number of entries in Prestige Levels list."),
         PropertyOrder(3), UsedImplicitly]
        public int MaxPrestigeLevel { get; set; } = 5;

        [LocDisplayName("Prestige Levels"),
         LocDescription("Bonus definitions for P1 through P5. Bonuses are cumulative (P3 includes P1+P2 bonuses)."),
         PropertyOrder(4), ExpandableObject, UsedImplicitly]
        public List<PrestigeLevelDef> Levels { get; set; } = new()
        {
            new PrestigeLevelDef { GoldPerKillBonusPercent = 15, XPMultiplierBonus = 0f,  ChatTitle = "[P1]", StartBattleInvincibleSeconds = 0 },
            new PrestigeLevelDef { GoldPerKillBonusPercent = 15, XPMultiplierBonus = 0f,  ChatTitle = "[P2]", StartBattleInvincibleSeconds = 0 },
            new PrestigeLevelDef { GoldPerKillBonusPercent = 15, XPMultiplierBonus = 1f,  ChatTitle = "[P3]", StartBattleInvincibleSeconds = 0 },
            new PrestigeLevelDef { GoldPerKillBonusPercent = 0,  XPMultiplierBonus = 1f,  ChatTitle = "[P4]", StartBattleInvincibleSeconds = 0 },
            new PrestigeLevelDef { GoldPerKillBonusPercent = 0,  XPMultiplierBonus = 0f,  ChatTitle = "[P5]", StartBattleInvincibleSeconds = 10 },
        };

        // Total gold bonus % for a hero at given prestige level (1-based, cumulative)
        public int GetCumulativeGoldBonusPercent(int prestigeLevel)
        {
            int total = 0;
            for (int i = 0; i < prestigeLevel && i < Levels.Count; i++)
                total += Levels[i].GoldPerKillBonusPercent;
            return total;
        }

        // Total XP multiplier for a hero at given prestige level (1.0 = no bonus)
        public float GetCumulativeXPMultiplier(int prestigeLevel)
        {
            float total = 1.0f;
            for (int i = 0; i < prestigeLevel && i < Levels.Count; i++)
                total += Levels[i].XPMultiplierBonus;
            return total;
        }

        // Max invincible seconds across all earned prestige levels
        public int GetInvincibleSeconds(int prestigeLevel)
        {
            int max = 0;
            for (int i = 0; i < prestigeLevel && i < Levels.Count; i++)
                if (Levels[i].StartBattleInvincibleSeconds > max)
                    max = Levels[i].StartBattleInvincibleSeconds;
            return max;
        }

        // Chat title from the highest prestige level that defines one
        public string GetChatTitle(int prestigeLevel)
        {
            string title = "";
            for (int i = 0; i < prestigeLevel && i < Levels.Count; i++)
                if (!string.IsNullOrEmpty(Levels[i].ChatTitle))
                    title = Levels[i].ChatTitle;
            return title;
        }
    }
}
