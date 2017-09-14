using DotaStats.Model.Persistence;
using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class HeroRecord
    {
        public HeroRecord()
        {
            TotalGames = 0;
            Wins = 0;
            Losses = 0;

            WinRate = 0;
            BestWinStreak = 0;
            CurrentWinStreak = 0;

            AverageKills = 0;
            AverageAssists = 0;
            AverageDeaths = 0;
            AverageGoldPerMinute = 0;
            AverageXpPerMinute = 0;

            BestKills = 0;
            BestAssists = 0;
            BestGoldPerMinute = 0;
            BestXpPerMinute = 0;
        }

        // HERO
        [JsonProperty("hero")]
        public Hero Hero { get; set; }

        // GAMES
        [JsonProperty("totalGames")]
        public int TotalGames { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }

        // WINS &  STREAKS
        [JsonProperty("winRate")]
        public int WinRate { get; set; }
        [JsonProperty("bestWinStreak")]
        public int BestWinStreak { get; set; }
        [JsonProperty("currentWinStreak")]
        public int CurrentWinStreak { get; set; }

        // AVERAGE STATS
        [JsonProperty("averageKills")]
        public int AverageKills { get; set; }
        [JsonProperty("averageDeaths")]
        public int AverageDeaths { get; set; }
        [JsonProperty("averageAssists")]
        public int AverageAssists { get; set; }
        [JsonProperty("averageGpm")]
        public int AverageGoldPerMinute { get; set; }
        [JsonProperty("averageXpm")]
        public int AverageXpPerMinute { get; set; }

        // BEST STATS
        [JsonProperty("bestKills")]
        public int BestKills { get; set; }
        [JsonProperty("bestAssists")]
        public int BestAssists { get; set; }
        [JsonProperty("bestGpm")]
        public int BestGoldPerMinute { get; set; }
        [JsonProperty("bestXpm")]
        public int BestXpPerMinute { get; set; }
    }
}
