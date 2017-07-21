using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.Hero
{
    public class HeroesResult
    {
        [JsonProperty("heroes")]
        public List<Dota2API.Hero.Hero> Heroes { get; set; }
    }
}
