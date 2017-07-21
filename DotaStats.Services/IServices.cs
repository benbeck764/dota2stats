using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services
{
    public interface IServices
    {
        IMatchService Matches { get; }
        IHeroService Heroes { get; }
        IItemService Items { get; }
        IStatisticsService Statistics { get; }
        IRecordsService Records { get; }
    }
}
