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
