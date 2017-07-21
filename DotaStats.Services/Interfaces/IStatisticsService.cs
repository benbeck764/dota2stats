using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Model.API;
using DotaStats.Model.Persistence;

namespace DotaStats.Services.Interfaces
{
    public interface IStatisticsService
    {
        KDA GetKDA(long accountId, int heroId);
        WinRate GetWinRate(long accountId, int heroId);
        IEnumerable<MostUsedItem> GetMostUsedItems(long accountId, int heroId);
        IEnumerable<MatchDetail> GetMatchDetails(long accountId, int heroId);
        PerMin GetPerMin(long accountId, int heroId);
        LastHitsDenies GetLastHitsAndDenies(long accountId, int heroId);
        IEnumerable<BestVersus> GetBestVersus(long accountId, int heroId);
        IEnumerable<WorstVersus> GetWorstVersus(long accountId, int heroId);
    }
}
