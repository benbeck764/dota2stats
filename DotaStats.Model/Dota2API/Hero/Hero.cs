using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.Hero
{
    public class Hero
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
