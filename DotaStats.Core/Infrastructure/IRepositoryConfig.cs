using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Infrastructure.Implementation;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepositoryConfig
    {
        string Name { get; set; }
        RepositoryConnection Connection { get; set; }
    }
}
