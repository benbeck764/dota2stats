using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.MatchHistory
{
    public class MatchHistoryPlayer
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }
        [JsonProperty("player_slot")]
        public int PlayerSlot { get; set; }
        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
    }
}
