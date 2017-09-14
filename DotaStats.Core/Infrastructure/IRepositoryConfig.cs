using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepositoryConfig
    {
        string Name { get; set; }
        RepositoryConnection Connection { get; set; }
    }
}
