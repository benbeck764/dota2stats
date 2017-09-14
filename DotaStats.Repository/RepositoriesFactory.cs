using DotaStats.Core.Infrastructure;
using DotaStats.Repository.Implementation;

namespace DotaStats.Repository
{
    public class RepositoriesFactory
    {
        public static IRepositories Create(IRepositoriesConfig config)
        {
            return new Repositories(config);
        }
    }
}
