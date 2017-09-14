using Newtonsoft.Json;

namespace DotaStats.Model.Persistence
{
    public class Hero : BaseModel
    {
        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
