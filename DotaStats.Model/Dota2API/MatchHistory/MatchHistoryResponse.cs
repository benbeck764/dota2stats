using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.MatchHistory
{
    public class MatchHistoryResponse
    {
        [JsonProperty("result")]
        public MatchHistoryResult Result { get; set; }
    }
}
