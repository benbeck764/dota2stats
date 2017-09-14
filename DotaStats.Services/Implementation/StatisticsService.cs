using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.SharedData;
using DotaStats.Model;
using DotaStats.Model.API;
using DotaStats.Model.Enums;
using DotaStats.Model.Persistence;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class StatisticsService : BaseService, IStatisticsService
    {
        public StatisticsService(IServiceContext context) : base(context) { }
        public KDA GetKDA(long accountId, int heroId)
        {
            var kda = new KDA();
            var count = 0;
            var players = GetMatchesByAccountAndHero(accountId, heroId).Select(m => m.Players.Find(p => p.AccountId == accountId));
            foreach (var player in players)
            {
                kda.Kills += player.Kills;
                kda.Deaths += player.Deaths;
                kda.Assists += player.Assists;
                count += 1;
            }

            if (kda.Kills > 0) { kda.Kills = kda.Kills / count; }
            if (kda.Deaths > 0) { kda.Deaths = kda.Deaths / count; }
            if (kda.Assists > 0) { kda.Assists = kda.Assists / count; }

            return kda;
        }

        public WinRate GetWinRate(long accountId, int heroId)
        {
            var winRate = new WinRate();
            var matches = GetMatchesByAccountAndHero(accountId, heroId);
            foreach (var match in matches)
            {
                var player = match.Players.FirstOrDefault(p => p.AccountId == accountId);
                if(player == null) continue;
                if ((player.PlayerSlot < 5 && match.RadiantWin) || 
                    (player.PlayerSlot > 5 && !match.RadiantWin))
                {
                    winRate.Wins++;
                }
                else if ((player.PlayerSlot < 5 && !match.RadiantWin) ||
                           (player.PlayerSlot > 5 && match.RadiantWin == false))
                {
                    winRate.Losses++;
                }

                if (winRate.Wins > 0 || winRate.Losses > 0) { winRate.Rate = (int) Math.Round((double)winRate.Wins / ((double)winRate.Wins + (double)winRate.Losses) * 100); }
            }
            return winRate;
        }

        public IEnumerable<MostUsedItem> GetMostUsedItems(long accountId, int heroId)
        {
            var items = new List<int>();
            var players = GetMatchesByAccountAndHero(accountId, heroId).Select(m => m.Players.Find(p => p.AccountId == accountId));
            foreach (var player in players)
            {
                if(player.Item0 != 0) { items.Add(player.Item0); }
                if(player.Item1 != 0) { items.Add(player.Item1); }
                if(player.Item2 != 0) { items.Add(player.Item2); }
                if(player.Item3 != 0) { items.Add(player.Item3); }
                if(player.Item4 != 0) { items.Add(player.Item4); }
                if(player.Item5 != 0) { items.Add(player.Item5); }

                if (player.Backpack0 != 0) { items.Add(player.Backpack0); }
                if (player.Backpack1 != 0) { items.Add(player.Backpack1); }
                if (player.Backpack2 != 0) { items.Add(player.Backpack2); }
            }

            var mostUsedItems = items.GroupBy(n => n).Select(c => new { ItemId = c.Key, Count = c.Count() }).Take(6).OrderByDescending(i => i.Count).ToList();
            var queriedItems = Items.GetItems();

            return (from mostUsedItem in mostUsedItems
                let queriedItem = queriedItems.FirstOrDefault(i => i.ItemId == mostUsedItem.ItemId)
                where queriedItem != null
                select new MostUsedItem()
                {
                    Count = mostUsedItem.Count,
                    ItemId = queriedItem.ItemId,
                    Name = queriedItem.Name,
                    LocalizedName = queriedItem.LocalizedName
                }).ToList();
        }

        public IEnumerable<MatchDetail> GetMatchDetails(long accountId, int heroId)
        {
            var retList = new List<MatchDetail>();
            var matches = GetMatchesByAccountAndHero(accountId, heroId).OrderByDescending(m => m.StartTime);
            foreach (var match in matches)
            {
                var matchDetail = new MatchDetail();
                var player = match.Players.FirstOrDefault(p => p.AccountId == accountId);
                if (player == null) continue;

                // RESULTS
                if ((player.PlayerSlot < 5 && match.RadiantWin) ||
                    (player.PlayerSlot > 5 && !match.RadiantWin))
                {
                    matchDetail.Results = "Win";
                }
                else if ((player.PlayerSlot < 5 && !match.RadiantWin) ||
                         (player.PlayerSlot > 5 && match.RadiantWin))
                {
                    matchDetail.Results = "Loss";
                }

                // MODE
                matchDetail.Mode = Enum.GetName(typeof(GameTypes), match.GameMode) ?? "-";

                // KDA
                matchDetail.KDA = $"{player.Kills}/{player.Deaths}/{player.Assists}";

                // DURATION
                var duration = TimeSpan.FromSeconds(match.Duration);
                matchDetail.Duration = duration.ToString(@"hh\:mm\:ss");

                // ITEMS 
                var items = Items.GetItems();
                matchDetail.Items = new List<Item>();
                foreach (var item in items)
                {
                    if (player.Item0 == item.ItemId || player.Item1 == item.ItemId || player.Item2 == item.ItemId || player.Item3 == item.ItemId || player.Item4 == item.ItemId || player.Item5 == item.ItemId)
                    {
                        matchDetail.Items.Add(item);
                    }
                    if (player.Backpack0 == item.ItemId || player.Backpack1 == item.ItemId || player.Backpack2 == item.ItemId)
                    {
                        matchDetail.Items.Add(item);
                    }
                }

                // ABILITIES // TODO


                retList.Add(matchDetail);
            }
            return retList;
        }

        public PerMin GetPerMin(long accountId, int heroId)
        {
            var gpm = 0;
            var xpm = 0;
            var perMin = new PerMin();
            var matches = GetMatchesByAccountAndHero(accountId, heroId).ToList();
            foreach (var match in matches)
            {
                var player = match.Players.FirstOrDefault(p => p.AccountId == accountId);
                if (player == null) continue;

                gpm += player.GoldPerMin;
                xpm += player.XpPerMin;
            }
            perMin.GoldPerMinute = gpm / matches.Count;
            perMin.XpPerMinute = xpm / matches.Count;

            return perMin;
        }

        public LastHitsDenies GetLastHitsAndDenies(long accountId, int heroId)
        {
            var lh = 0;
            var deny = 0;
            var lhDenies = new LastHitsDenies();
            var matches = GetMatchesByAccountAndHero(accountId, heroId).ToList();
            foreach (var match in matches)
            {
                var player = match.Players.FirstOrDefault(p => p.AccountId == accountId);
                if (player == null) continue;

                lh += player.LastHits;
                deny += player.Denies;
            }

            lhDenies.LastHits = lh / matches.Count;
            lhDenies.Denies = deny / matches.Count;

            return lhDenies;
        }

        public IEnumerable<BestVersus> GetBestVersus(long accountId, int heroId)
        {
            var details = GetAllPlayersByHero(accountId, heroId);
            var enemyIds = new List<int>();
            foreach (var detail in details)
            {
                var isRadiance = true;
                var radiantWin = detail.MyPlayer.RadiantWin;
                var playerSlot = detail.MyPlayer.PlayerSlot;

                if (playerSlot > 5) { isRadiance = false; }

                foreach (var enemy in detail.EnemyPlayers)
                {
                    if (isRadiance && radiantWin)
                    {
                        if (enemy.PlayerSlot > 5)
                        {
                            enemyIds.Add(enemy.HeroId);
                        }
                    }
                    else if (!isRadiance && !radiantWin)
                    {
                        if (enemy.PlayerSlot < 5)
                        {
                            enemyIds.Add(enemy.HeroId);
                        }
                    }
                }
            }

            var ids = enemyIds.AsEnumerable().GroupBy(n => n).Select(c => new { HeroId = c.Key, Count = c.Count() }).Take(3).OrderByDescending(i => i.Count).ToList();

            var retList = new List<BestVersus>();
            var heroes = Heroes.GetHeroes();
            foreach (var id in ids)
            {
                var bestVersus = new BestVersus();
                foreach (var hero in heroes)
                {
                    if (hero.HeroId != id.HeroId) continue;
                    bestVersus.HeroId = hero.HeroId;
                    bestVersus.LocalizedName = hero.LocalizedName;
                    bestVersus.Name = hero.Name;
                    bestVersus.Count = id.Count;
                }
                retList.Add(bestVersus);
            }
            return retList;
        }

        public IEnumerable<WorstVersus> GetWorstVersus(long accountId, int heroId)
        {
            var details = GetAllPlayersByHero(accountId, heroId);
            var enemyIds = new List<int>();
            foreach (var detail in details)
            {
                var isRadiance = true;
                var radiantWin = detail.MyPlayer.RadiantWin;
                var playerSlot = detail.MyPlayer.PlayerSlot;

                if (playerSlot > 5)
                {
                    isRadiance = false;
                }

                foreach (var enemy in detail.EnemyPlayers)
                {
                    if (isRadiance && !radiantWin)
                    {
                        if (enemy.PlayerSlot > 5)
                        {
                            enemyIds.Add(enemy.HeroId);
                        }
                    }
                    else if (!isRadiance && radiantWin)
                    {
                        if (enemy.PlayerSlot < 5)
                        {
                            enemyIds.Add(enemy.HeroId);
                        }
                    }
                }
            }

            var ids = enemyIds.AsEnumerable().GroupBy(n => n).Select(c => new { HeroId = c.Key, Count = c.Count() }).Take(3).OrderByDescending(i => i.Count).ToList();

            var retList = new List<WorstVersus>();
            var heroes = Heroes.GetHeroes();
            foreach (var id in ids)
            {
                var worstVersus = new WorstVersus();
                foreach (var hero in heroes)
                {
                    if (hero.HeroId != id.HeroId) continue;
                    worstVersus.HeroId = hero.HeroId;
                    worstVersus.LocalizedName = hero.LocalizedName;
                    worstVersus.Name = hero.Name;
                    worstVersus.Count = id.Count;
                }
                retList.Add(worstVersus);
            }
            return retList;
        }

        private IEnumerable<Match> GetMatchesByAccountAndHero(long accountId, int heroId)
        {
            var name = typeof(Match).Name;
            var query = "SELECT c.Document FROM c";
            query += " JOIN Player IN c.Document.players ";

            query += $" WHERE c.Type = '{name}'";
            query += $" AND Player.account_id = {accountId}";
            query += $" AND Player.hero_id = {heroId}";

            return Context.Repositories.Matches.Query(query).Where(m => Enum.IsDefined(typeof(GameTypes), m.GameMode)).AsEnumerable();
        }

        private IEnumerable<MatchPlayerDetails> GetAllPlayersByHero(long accountId, int heroId)
        {
            var matches = GetMatchesByAccountAndHero(accountId, heroId);
            var retList = new List<MatchPlayerDetails>();

            foreach (var match in matches)
            {
               var details = new MatchPlayerDetails();
                var players = match.Players;
                var myPlayer = players.FirstOrDefault(p => p.AccountId == accountId && p.HeroId == heroId);
                details.MyPlayer = myPlayer;
                if (details.MyPlayer == null) continue;
                {
                    details.MyPlayer.RadiantWin = match.RadiantWin;
                    var slot = details.MyPlayer.PlayerSlot;
                    details.EnemyPlayers.AddRange(slot < 5
                        ? players.Where(p => p.PlayerSlot > 5)
                        : players.Where(p => p.PlayerSlot < 5));
                    retList.Add(details);
                }
            }
            return retList;
        }

        private IEnumerable<Item> GetItemsByIds(List<int> itemIds)
        {
            var name = typeof(Item).Name;
            var query = "SELECT * FROM c";
            query += $" WHERE c.Type = '{name}'";
            query += $" AND (";

            foreach (var itemId in itemIds)
            {
                query += $"c.Document.item_id = {itemId} ";

                if (itemId != itemIds.Last())
                {
                    query += $"OR ";
                }
            }

            query += ")";
            return Context.Repositories.Items.Query(query).AsEnumerable();
        }
    }
}
