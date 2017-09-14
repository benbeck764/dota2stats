using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class WinRate
    {
        public WinRate()
        {
            this.Wins = 0;
            this.Losses = 0;
            this.Rate = 0;
        }

        [JsonProperty("wins")]
        public int Wins { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("rate")]
        public int Rate { get; set; }
    }
}
