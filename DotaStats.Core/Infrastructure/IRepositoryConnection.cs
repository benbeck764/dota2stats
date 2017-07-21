using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepositoryConnection
    {
        string EndPointUrl { get; set; }
        string AuthorizationKey { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
        string RepositorySize { get; set; }
    }
}
