using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Configuration.Implementation;

namespace DotaStats.Core.Configuration
{
    public interface IServiceDependencies
    {
        bool UseTestRepositories { get; set; }

        bool UseIntegrationTestRepositories { get; set; }

        RepositoriesConfig RepositoriesConfig { get; set; }
    }
}
