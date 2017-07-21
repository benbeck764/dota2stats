using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.Hero
{
    public class HeroesResponse
    {
        [JsonProperty("result")]
        public HeroesResult Result { get; set; }
    }
}
