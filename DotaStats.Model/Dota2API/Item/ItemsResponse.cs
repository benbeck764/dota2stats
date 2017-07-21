using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.Item
{
    public class ItemsResponse
    {
        [JsonProperty("result")]
        public ItemsResult Result { get; set; }
    }
}
