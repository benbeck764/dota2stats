using DotaStats.Core.Configuration;
using DotaStats.Repository;

namespace DotaStats.Services
{
    public interface IServiceContext
    {
        IServiceDependencies Dependencies { get; }
        IRepositories Repositories { get; }
    }
}
