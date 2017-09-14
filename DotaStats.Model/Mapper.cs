using System.Collections.Generic;
using System.Linq;
using DotaStats.Model.Dota2API.MatchDetails;
using DotaStats.Model.Dota2API.MatchHistory;
using DotaStats.Model.Persistence;

namespace DotaStats.Model
{
    public static class Mapper
    {
        public static Item MapItem(Dota2API.Item.Item item)
        {
            return new Item()
            {
                ItemId = item.Id,
                Name = item.Name.Replace("item_", ""),
                Cost = item.Cost,
                SecretShop = item.SecretShop,
                SideShop = item.SideShop,
                Recipe = item.Recipe,
                LocalizedName = item.LocalizedName
            };
        }

        public static Hero MapHero(Dota2API.Hero.Hero hero)
        {
            return new Hero()
            {
                HeroId = hero.Id,
                Name = hero.Name.Replace("npc_dota_hero_", ""),
                LocalizedName = hero.LocalizedName
            };
        }

        public static Player MapPlayer(MatchDetailsPlayer matchDetailsPlayer)
        {
            return new Player()
            {
                AbilityUpgrades = MapAbilities(matchDetailsPlayer.AbilityUpgrades),
                AccountId = matchDetailsPlayer.AccountId,
                Assists = matchDetailsPlayer.Assists,
                Backpack0 = matchDetailsPlayer.Backpack0,
                Backpack1 = matchDetailsPlayer.Backpack1,
                Backpack2 = matchDetailsPlayer.Backpack2,
                Deaths = matchDetailsPlayer.Deaths,
                Denies = matchDetailsPlayer.Denies,
                Gold = matchDetailsPlayer.Gold,
                GoldPerMin = matchDetailsPlayer.GoldPerMin,
                GoldSpent = matchDetailsPlayer.GoldSpent,
                HeroDamage = matchDetailsPlayer.HeroDamage,
                HeroHealing = matchDetailsPlayer.HeroHealing,
                HeroId = matchDetailsPlayer.HeroId,
                Item0 = matchDetailsPlayer.Item0,
                Item1 = matchDetailsPlayer.Item1,
                Item2 = matchDetailsPlayer.Item2,
                Item3 = matchDetailsPlayer.Item3,
                Item4 = matchDetailsPlayer.Item4,
                Item5 = matchDetailsPlayer.Item5,
                Kills = matchDetailsPlayer.Kills,
                LastHits = matchDetailsPlayer.LastHits,
                LeaverStatus = matchDetailsPlayer.LeaverStatus,
                Level = matchDetailsPlayer.Level,
                PlayerSlot = matchDetailsPlayer.PlayerSlot,
                ScaledHeroDamage = matchDetailsPlayer.ScaledHeroDamage,
                ScaledHeroHealing = matchDetailsPlayer.ScaledHeroHealing,
                ScaledTowerDamage = matchDetailsPlayer.ScaledTowerDamage,
                TowerDamage = matchDetailsPlayer.TowerDamage,
                XpPerMin = matchDetailsPlayer.XpPerMin
            };
        }

        public static List<Player> MapPlayers(List<MatchDetailsPlayer> matchDetailsPlayers)
        {
            if (matchDetailsPlayers == null || !matchDetailsPlayers.Any()) { return new List<Player>(); }
            return matchDetailsPlayers.Select(MapPlayer).ToList();
        }

        public static Ability MapAbility(MatchDetailsAbility matchDetailsAbility)
        {
            return new Ability()
            {
                AbilityId = matchDetailsAbility.AbilityId,
                Level = matchDetailsAbility.Level,
                Time = matchDetailsAbility.Time
            };
        }

        public static List<Ability> MapAbilities(List<MatchDetailsAbility> matchDetailsAbilities)
        {
            if(matchDetailsAbilities == null || !matchDetailsAbilities.Any()) { return new List<Ability>(); }
            return matchDetailsAbilities.Select(MapAbility).ToList();
        }

        public static Match MapMatch(MatchHistoryMatch matchHistory, MatchDetailsResult matchDetails)
        {
            return new Match()
            {
                BarracksStatusDire = matchDetails.BarracksStatusDire,
                BarracksStatusRadiant = matchDetails.BarracksStatusRadiant,
                Cluster = matchDetails.Cluster,
                DireScore = matchDetails.DireScore,
                DireTeamId = matchHistory.DireTeamId,
                Duration = matchDetails.Duration,
                Engine = matchDetails.Engine,
                FirstBloodTime = matchDetails.FirstBloodTime,
                Flags = matchDetails.Flags,
                GameMode = matchDetails.GameMode,
                HumanPlayers = matchDetails.HumanPlayers,
                LeagueId = matchDetails.LeagueId,
                LobbyType = matchDetails.LobbyType,
                MatchId = matchDetails.MatchId,
                MatchSeqNum = matchDetails.MatchSeqNum,
                NegativeVotes = matchDetails.NegativeVotes,
                Players = MapPlayers(matchDetails.Players),
                PositiveVotes = matchDetails.PositiveVotes,
                PreGameDuration = matchDetails.PreGameDuration,
                RadiantScore = matchDetails.RadiantScore,
                RadiantTeamId = matchHistory.RadiantTeamId,
                RadiantWin = matchDetails.RadiantWin,
                StartTime = matchDetails.StartTime,
                TowerStatusDire = matchDetails.TowerStatusDire,
                TowerStatusRadiant = matchDetails.TowerStatusRadiant
            };
        }
    }
}
