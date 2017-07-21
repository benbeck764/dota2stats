using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.MatchDetails
{
    public class MatchDetailsResponse
    {
        [JsonProperty("result")]
        public MatchDetailsResult Result { get; set; }
    }
}
