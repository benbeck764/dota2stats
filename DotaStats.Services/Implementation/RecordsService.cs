using System;
using System.Collections.Generic;
using System.Linq;
using DotaStats.Core.SharedData;
using DotaStats.Model.API;
using DotaStats.Model.Persistence;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class RecordsService : BaseService, IRecordsService
    {
        public RecordsService(IServiceContext context) : base(context) { }

        public IEnumerable<HeroRecord> GetAll(long accountId)
        {
            var retList = new List<HeroRecord>();
            var matches = GetMatchesByAccount(accountId).ToList();
            var allHeroes = Heroes.GetHeroes();

            // TODO -- Change 114 to # of heroes constant
            for (var i = 1; i < 114; i++)
            {
                var heroRecord = new HeroRecord();
                var i1 = i;
                heroRecord.Hero = allHeroes.FirstOrDefault(h => h.HeroId == i1);

                var matchesByHero = matches.Where(m => m.Players.Any(p => p.AccountId == accountId && p.HeroId == i1)).OrderByDescending(m => m.StartTime).ToList();
                if (!matchesByHero.Any())  { continue; }

                var players = matchesByHero.Select(m => m.Players.FirstOrDefault(p => p.HeroId == i1)).ToList();
                if (!players.Any()) { continue; }

                heroRecord.TotalGames = matchesByHero.Count;

              
                var kills = new List<int>();
                var deaths = new List<int>();
                var assists = new List<int>();
                var gpms = new List<int>();
                var xpms = new List<int>();
                foreach (var player in players)
                {
                    var match = matchesByHero.Find(m => m.Players.Contains(player));
                    if (match == null)  { continue; }
                    if ((player.PlayerSlot < 5 && match.RadiantWin) ||
                        (player.PlayerSlot > 5 && !match.RadiantWin))
                    {
                        heroRecord.Wins++;
                    }
                    else if ((player.PlayerSlot < 5 && !match.RadiantWin) ||
                             (player.PlayerSlot > 5 && match.RadiantWin == false))
                    {
                        heroRecord.Losses++;
                    }

                    kills.Add(player.Kills);
                    deaths.Add(player.Deaths);
                    assists.Add(player.Assists);
                    gpms.Add(player.GoldPerMin);
                    xpms.Add(player.XpPerMin);
                   
                }

                if (heroRecord.Wins > 0 || heroRecord.Losses > 0) { heroRecord.WinRate = (int)Math.Round((double)heroRecord.Wins / ((double)heroRecord.Wins + (double)heroRecord.Losses) * 100); }
                if (kills.Any())  {  heroRecord.AverageKills = kills.Sum() / matchesByHero.Count; heroRecord.BestKills = kills.Max(); }
                if (deaths.Any())  {  heroRecord.AverageDeaths = deaths.Sum() / matchesByHero.Count;  }
                if (assists.Any())  {  heroRecord.AverageAssists = assists.Sum() / matchesByHero.Count; heroRecord.BestAssists = assists.Max(); }
                if (gpms.Any())  {  heroRecord.AverageGoldPerMinute = gpms.Sum() / matchesByHero.Count; heroRecord.BestGoldPerMinute = gpms.Max(); }
                if (xpms.Any())  {  heroRecord.AverageXpPerMinute = xpms.Sum() / matchesByHero.Count; heroRecord.BestXpPerMinute = xpms.Max(); }

                retList.Add(heroRecord);
            }

            return retList;
        }

        private IEnumerable<Match> GetMatchesByAccount(long accountId)
        {
            var name = typeof(Match).Name;
            var query = "SELECT c.Document FROM c";
            query += " JOIN Player IN c.Document.players ";

            query += $" WHERE c.Type = '{name}'";
            query += $" AND Player.account_id = {accountId}";

            return Context.Repositories.Matches.Query(query).AsEnumerable();
        }
    }
}
