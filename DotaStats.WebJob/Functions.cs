using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DotaStats.ConsoleApp;
using DotaStats.Model.Dota2API.MatchDetails;
using DotaStats.Model.Dota2API.MatchHistory;
using DotaStats.Model.Extensions;
using DotaStats.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace DotaStats.WebJob
{
    public class Functions
    {
        private string DevKey { get; } = "F99837D4DF07828F1C85C71700B0F9BD";
        private string AccountId { get; } = "111871881";
        private int NumHeroes { get; } = 112;
        private string Format { get; } = "JSON";
        private string Language { get; } = "en";

        private string MatchHistoryUri { get; } = "https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v001/";
        private string MatchDetailsUri { get; } = "https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v001/";
        private string HeroesInfoUri { get; } = "https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v1/";
        private string ItemsInfoUri { get; } = "http://api.steampowered.com/IEconDOTA2_570/GetGameItems/v1";

        private string HeroImagesUri { get; } = "http://cdn.dota2.com/apps/dota2/images/heroes/";
        private string ItemImagesUri { get; } = "http://cdn.dota2.com/apps/dota2/images/items/";
#if DEBUG
        /// <summary>
        /// Runs every minute
        /// </summary>
        private const string PullApiDataSchedule = "0 0 0 * * */1";
#else
        /// <summary>
        /// Runs every day (at midnight)
        /// </summary>
         private const string PullApiDataSchedule = "0 0 0 */1 * *";
#endif


        private const bool RunOnStartup = true;

        private readonly IServices _services;

        public Functions(IServices services)
        {
            _services = services;
        }

        public void UpdateMatchData(
            [TimerTrigger(PullApiDataSchedule, RunOnStartup = RunOnStartup)] TimerInfo timer,
            TraceWriter log)
        {
            GetMatchHistory().ConfigureAwait(true);
        }

        private async Task GetMatchHistory()
        {
            for (var heroId = 1; heroId <= NumHeroes; heroId++)
            {
                var apiUrlMatchHistory = MatchHistoryUri + $"?key={DevKey}" + $"&account_id={AccountId}" + $"&format={Format}" + $"&hero_id={heroId}";
                var requestMatchHistory = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlMatchHistory);

                var responseMatchHistory = HttpManager.SendRequest(requestMatchHistory).Result;
                var jsonResultMatchHistory = HttpManager.GetResult(responseMatchHistory).Result;

                var matchHistoryResult = JsonConvert.DeserializeObject<MatchHistoryResponse>(jsonResultMatchHistory);

                foreach (var match in matchHistoryResult.Result.Matches)
                {
                    Console.WriteLine("Searching match data...");
                    var apiUriMatchDetails = MatchDetailsUri + $"?key={DevKey}" + $"&match_id={match.MatchId}" + $"&format={Format}";
                    var requestMatchDetails = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUriMatchDetails);

                    var responseMatchDetails = HttpManager.SendRequest(requestMatchDetails).Result;
                    var jsonResultMatchDetails = HttpManager.GetResult(responseMatchDetails).Result;

                    var matchDetailsResult = JsonConvert.DeserializeObject<MatchDetailsResponse>(jsonResultMatchDetails);

                    var startTime = DateTimeOffset.FromUnixTimeSeconds(matchDetailsResult.Result.StartTime).DateTime;
                    var today = DateTime.Today;
                    if ((today - startTime).Days <= 7)
                    {
                        Console.WriteLine("Found a new match!");
                        Console.WriteLine(matchDetailsResult.ToJson());
                        await _services.Matches.Upsert(match, matchDetailsResult.Result);
                    }
                }
            }
        }
    }
}
