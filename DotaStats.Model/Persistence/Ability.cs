using Newtonsoft.Json;

namespace DotaStats.Model.Persistence
{
    public class Ability
    {
        [JsonProperty("ability_id")]
        public int AbilityId { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
