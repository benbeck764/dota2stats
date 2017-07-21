using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepositoriesConfig
    {
        List<RepositoryConfig> RepositoryConfigs { get; set; }
    }
}
