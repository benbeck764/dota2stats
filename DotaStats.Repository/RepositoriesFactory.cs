using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Infrastructure;
using DotaStats.Repository.Implementation;

namespace DotaStats.Repository
{
    public class RepositoriesFactory
    {
        public static IRepositories Create(IRepositoriesConfig config)
        {
            return new Repositories(config);
        }
    }
}
