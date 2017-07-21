using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class WorstVersus
    {
        [JsonProperty("id")]
        public int HeroId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
