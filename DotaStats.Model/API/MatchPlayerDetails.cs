using System.Collections.Generic;
using DotaStats.Model.Persistence;

namespace DotaStats.Model.API
{
    public class MatchPlayerDetails
    {
        public MatchPlayerDetails()
        {
            EnemyPlayers = new List<Player>();
        }
        public Player MyPlayer { get; set; }
        public List<Player> EnemyPlayers { get; set; }
    }
}
