using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
