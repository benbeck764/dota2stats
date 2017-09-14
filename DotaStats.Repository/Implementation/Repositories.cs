using DotaStats.Core.Infrastructure;
using DotaStats.Model.Persistence;

namespace DotaStats.Repository.Implementation
{
    public class Repositories : BaseRepository, IRepositories
    {
        private IRepository<Match> _matches;
        private IRepository<Hero> _heroes;
        private IRepository<Item> _items;

        public IRepository<Match> Matches => _matches ?? new Repository<Match>(FindActiveConfig("Match"));
        public IRepository<Hero> Heroes => _heroes ?? new Repository<Hero>(FindActiveConfig("Hero"));
        public IRepository<Item> Items => _items ?? new Repository<Item>(FindActiveConfig("Item"));

        public Repositories(IRepositoriesConfig configuration) : base(configuration) { }

        public void Dispose()
        {
            Matches.Dispose();
            Heroes.Dispose();
            Items.Dispose();
        }
    }
}
