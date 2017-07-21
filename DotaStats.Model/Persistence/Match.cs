using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaStats.Model.Persistence
{
    public class Match : BaseModel
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }
        [JsonProperty("match_seq_num")]
        public long MatchSeqNum { get; set; }
        [JsonProperty("radiant_team_id")]
        public int RadiantTeamId { get; set; }
        [JsonProperty("dire_team_id")]
        public int DireTeamId { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("pre_game_duration")]
        public int PreGameDuration { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }
        [JsonProperty("tower_status_dire")]
        public int TowerStatusDire { get; set; }
        [JsonProperty("barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }
        [JsonProperty("barracks_status_dire")]
        public int BarracksStatusDire { get; set; }
        [JsonProperty("cluster")]
        public int Cluster { get; set; }
        [JsonProperty("first_blood_time")]
        public int FirstBloodTime { get; set; }
        [JsonProperty("lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("human_players")]
        public int HumanPlayers { get; set; }
        [JsonProperty("leagueid")]
        public int LeagueId { get; set; }
        [JsonProperty("positive_votes")]
        public int PositiveVotes { get; set; }
        [JsonProperty("negative_votes")]
        public int NegativeVotes { get; set; }
        [JsonProperty("game_mode")]
        public int GameMode { get; set; }
        [JsonProperty("flags")]
        public int Flags { get; set; }
        [JsonProperty("engine")]
        public int Engine { get; set; }
        [JsonProperty("radiant_score")]
        public int RadiantScore { get; set; }
        [JsonProperty("dire_score")]
        public int DireScore { get; set; }
    }
}
