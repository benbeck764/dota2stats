using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Infrastructure;
using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Configuration.Implementation
{
    public class RepositoriesConfig : IRepositoriesConfig
    {
        public List<RepositoryConfig> RepositoryConfigs { get; set; }
    }
}
