﻿using Newtonsoft.Json;

namespace DotaStats.Model.Persistence
{
    public class Item : BaseModel
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cost")]
        public int Cost { get; set; }
        [JsonProperty("secret_shop")]
        public bool SecretShop { get; set; }
        [JsonProperty("side_shop")]
        public bool SideShop { get; set; }
        [JsonProperty("recipe")]
        public bool Recipe { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
