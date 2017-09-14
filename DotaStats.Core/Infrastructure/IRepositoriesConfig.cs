using System.Collections.Generic;
using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepositoriesConfig
    {
        List<RepositoryConfig> RepositoryConfigs { get; set; }
    }
}
