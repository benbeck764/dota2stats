using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaStats.Model;
using DotaStats.Model.Dota2API.MatchDetails;
using DotaStats.Model.Dota2API.MatchHistory;
using DotaStats.Model.Persistence;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class MatchService : BaseService, IMatchService
    {
        public MatchService(IServiceContext context) : base(context) { }

        public async Task Upsert(MatchHistoryMatch match, MatchDetailsResult matchDetails)
        {
            var existingMatch = Get(match.MatchId);
            if (existingMatch == null)
            {
                var mappedMatch = Mapper.MapMatch(match, matchDetails);

                mappedMatch.Id = Guid.NewGuid();
                mappedMatch.LastModified = DateTime.UtcNow;

                await Context.Repositories.Matches.Upsert(mappedMatch);
            }
        }

        public Match Get(long matchId)
        { 
            return Context.Repositories.Matches.Query().Where(m => m.MatchId == matchId).AsEnumerable().FirstOrDefault();
        }

        public IEnumerable<Match> GetByAccountAndHero(long accountId, int heroId)
        {
            var name = typeof(Match).Name;
            var query = "SELECT c.Document FROM c";
            query += " JOIN Player IN c.Document.players ";

            query += $" WHERE c.Type = '{name}'";
            query += $" AND Player.account_id = {accountId}";
            query += $" AND Player.hero_id = {heroId}";

            return Context.Repositories.Matches.Query(query).AsEnumerable();
        }
    }
}
