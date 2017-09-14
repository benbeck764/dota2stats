using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class LastHitsDenies
    {
        public LastHitsDenies()
        {
            LastHits = 0;
            Denies = 0;
        }

        [JsonProperty("lh")]
        public int LastHits { get; set; }
        [JsonProperty("deny")]
        public int Denies { get; set; }
    }
}
