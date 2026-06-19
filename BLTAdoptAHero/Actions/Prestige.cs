using System;
using BannerlordTwitch;
using BannerlordTwitch.Localization;
using BannerlordTwitch.Rewards;
using BannerlordTwitch.Util;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace BLTAdoptAHero
{
    [LocDisplayName("Prestige Hero"),
     LocDescription("Resets the hero to Tier 1 and increases their Prestige level, granting cumulative kill gold/XP bonuses. "
                    + "Requires the hero to be at Tier 8 and have enough kills. "
                    + "Configure bonuses per level in Global Common Config > Prestige System."),
     UsedImplicitly]
    public class PrestigeHero : ActionHandlerBase
    {
        private class Settings : IDocumentable
        {
            [LocDisplayName("Allow Companion Prestige"),
             LocDescription("Allow player companions to prestige."),
             PropertyOrder(0), UsedImplicitly]
            public bool AllowCompanionPrestige { get; set; } = false;

            public void GenerateDocumentation(IDocumentationGenerator generator)
            {
                var cfg = BLTAdoptAHeroModule.CommonConfig.PrestigeConfig;
                generator.PropertyValuePair("Required Kills", $"{cfg.RequireKills}");
                generator.PropertyValuePair("Requires Channel Points", $"{cfg.RequireChannelPoints}");
                if (cfg.RequireChannelPoints)
                    generator.PropertyValuePair("Channel Points Cost", $"{cfg.ChannelPointsCost}");
                generator.PropertyValuePair("Max Prestige Level", $"{cfg.MaxPrestigeLevel}");
            }
        }

        protected override Type ConfigType => typeof(Settings);

        protected override void ExecuteInternal(ReplyContext context, object config,
            Action<string> onSuccess, Action<string> onFailure)
        {
            var settings = config as Settings ?? new Settings();

            var adoptedHero = BLTAdoptAHeroCampaignBehavior.Current.GetAdoptedHero(context.UserName);
            if (adoptedHero == null)
            {
                onFailure(AdoptAHero.NoHeroMessage);
                return;
            }

            if (!settings.AllowCompanionPrestige && adoptedHero.IsPlayerCompanion)
            {
                onFailure("You are a player companion and cannot prestige!");
                return;
            }

            if (Mission.Current != null)
            {
                onFailure("You cannot prestige during an active battle!");
                return;
            }

            var prestigeCfg = BLTAdoptAHeroModule.CommonConfig.PrestigeConfig;
            int currentTier = BLTAdoptAHeroCampaignBehavior.Current.GetEquipmentTier(adoptedHero);
            int currentPrestige = BLTAdoptAHeroCampaignBehavior.Current.GetPrestigeLevel(adoptedHero);
            int killCount = BLTAdoptAHeroCampaignBehavior.Current.GetPrestigeKillCount(adoptedHero);

            // Must be at T8 (tier index 7)
            if (currentTier < 7)
            {
                onFailure($"You must reach Tier 8 before prestiging! (Current: T{currentTier + 1})");
                return;
            }

            // Kill requirement
            if (prestigeCfg.RequireKills > 0 && killCount < prestigeCfg.RequireKills)
            {
                onFailure($"You need {prestigeCfg.RequireKills - killCount} more kills before you can prestige! ({killCount}/{prestigeCfg.RequireKills})");
                return;
            }

            // Channel points requirement — when used as a free command and channel points are required, block it
            if (prestigeCfg.RequireChannelPoints && !context.IsSubscriber && !context.IsModerator && !context.IsBroadcaster)
            {
                onFailure($"Prestige requires {prestigeCfg.ChannelPointsCost} Channel Points — redeem the reward on the channel point rewards list!");
                return;
            }

            // Max prestige check
            if (currentPrestige >= prestigeCfg.MaxPrestigeLevel)
            {
                onFailure($"You have already reached the maximum prestige level (P{prestigeCfg.MaxPrestigeLevel})!");
                return;
            }

            // Do the prestige
            bool success = BLTAdoptAHeroCampaignBehavior.Current.DoPrestige(adoptedHero);
            if (!success)
            {
                onFailure("Prestige failed — maximum prestige level already reached!");
                return;
            }

            int newPrestige = BLTAdoptAHeroCampaignBehavior.Current.GetPrestigeLevel(adoptedHero);
            string title = prestigeCfg.GetChatTitle(newPrestige);
            int goldBonus = prestigeCfg.GetCumulativeGoldBonusPercent(newPrestige);
            float xpMult  = prestigeCfg.GetCumulativeXPMultiplier(newPrestige);

            string bonusSummary = $"+{goldBonus}% gold per kill";
            if (xpMult > 1.0f)
                bonusSummary += $", {xpMult:F1}x XP per kill";
            int invSec = prestigeCfg.GetInvincibleSeconds(newPrestige);
            if (invSec > 0)
                bonusSummary += $", {invSec}s battle invincibility";

            onSuccess($"{title} {context.UserName} has prestiged to P{newPrestige}! Equipment reset to T1. Cumulative bonuses: {bonusSummary}");
        }
    }
}
