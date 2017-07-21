using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.MatchHistory
{
    public class MatchHistoryResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("num_results")]
        public int NumResults { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("results_remaining")]
        public int ResultsRemaining { get; set; }
        [JsonProperty("matches")]
        public List<MatchHistoryMatch> Matches { get; set; }
    }
}
