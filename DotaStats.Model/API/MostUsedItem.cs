using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class MostUsedItem
    {
        public MostUsedItem()
        {
            
        }

        [JsonProperty("id")]
        public int ItemId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
