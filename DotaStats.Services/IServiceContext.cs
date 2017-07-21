using DotaStats.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Repository;

namespace DotaStats.Services
{
    public interface IServiceContext
    {
        IServiceDependencies Dependencies { get; }
        IRepositories Repositories { get; }
    }
}
