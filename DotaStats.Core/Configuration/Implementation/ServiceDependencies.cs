using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Core.Configuration.Implementation
{
    public class ServiceDependencies : IServiceDependencies
    {
        public bool UseTestRepositories { get; set; }
        public bool UseIntegrationTestRepositories { get; set; }
        public RepositoriesConfig RepositoriesConfig { get; set; }
    }
}
