using System.Collections.Generic;
using DotaStats.Core.Infrastructure;
using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Configuration.Implementation
{
    public class RepositoriesConfig : IRepositoriesConfig
    {
        public List<RepositoryConfig> RepositoryConfigs { get; set; }
    }
}
