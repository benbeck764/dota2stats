using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Model.Persistence;
using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class MatchDetail
    {
        [JsonProperty("results")]
        public string Results { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("kda")]
        public string KDA { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

    }
}
