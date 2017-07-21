using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Configuration;
using DotaStats.Repository;

namespace DotaStats.Services.Implementation
{
    public class ServiceContext : IServiceContext
    {
        public ServiceContext(IServiceDependencies dependencies, IRepositories repositories)
        {
            Dependencies = dependencies;
            Repositories = repositories;
        }
        public IServiceDependencies Dependencies { get; }
        public IRepositories Repositories { get; }
    }
}
