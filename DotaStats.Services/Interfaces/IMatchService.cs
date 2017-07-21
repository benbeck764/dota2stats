using System.Collections.Generic;
using System.Threading.Tasks;
using DotaStats.Model.Dota2API.MatchDetails;
using DotaStats.Model.Dota2API.MatchHistory;
using DotaStats.Model.Persistence;

namespace DotaStats.Services.Interfaces
{
    public interface IMatchService
    {
        Task Upsert(MatchHistoryMatch match, MatchDetailsResult matchDetails);
        Match Get(long matchId);
        IEnumerable<Match> GetByAccountAndHero(long accountId, int heroId);
    }
}
