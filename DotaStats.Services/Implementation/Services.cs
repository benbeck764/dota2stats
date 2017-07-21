using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class Services : IServices
    {
        private readonly IServiceContext _context;

        private IMatchService _matches;
        private IHeroService _heroes;
        private IItemService _items;
        private IStatisticsService _stats;
        private IRecordsService _records;

        public IMatchService Matches => _matches ?? new MatchService(_context);
        public IHeroService Heroes => _heroes ?? new HeroService(_context);
        public IItemService Items => _items ?? new ItemService(_context);

        public IStatisticsService Statistics => _stats ?? new StatisticsService(_context);
        public IRecordsService Records => _records ?? new RecordsService(_context);

        public Services(IServiceContext context)
        {
            this._context = context;
        }

        
    }
}
