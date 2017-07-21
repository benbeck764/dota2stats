using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Core.Infrastructure.Implementation
{
    public class RepositoryConfig : IRepositoryConfig
    {
        public string Name { get; set; }
        public RepositoryConnection Connection { get; set; }
    }
}
