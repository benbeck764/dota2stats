using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaStats.Model.Dota2API.MatchHistory
{
    public class MatchHistoryMatch
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }
        [JsonProperty("match_seq_num")]
        public long MatchSeqNum { get; set; }
        [JsonProperty("lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("radiant_team_id")]
        public int RadiantTeamId { get; set; }
        [JsonProperty("dire_team_id")]
        public int DireTeamId { get; set; }
        [JsonProperty("players")]
        public List<MatchHistoryPlayer> Players { get; set; }

    }
}
