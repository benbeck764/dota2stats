using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class KDA
    {
        public KDA()
        {
            Kills = 0;
            Deaths = 0;
            Assists = 0;
        }

        [JsonProperty("kills")]
        public int Kills { get; set; }
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        [JsonProperty("assists")]
        public int Assists { get; set; }
    }
}
