using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Configuration.Implementation;
using DotaStats.Core.Logging.Implementation;

namespace DotaStats.Core.Configuration
{
    public interface IDotaStatsEnvironment
    {
        //DotaStatsAuth Authentication { get; set; }
        ServiceDependencies ServiceDependencies { get; set; }

        string StorageConnectionString { get; set; }
        string BlobStorageConnectionString { get; set; }

        // Application Insights Configuration
        LoggerConfiguration LoggerConfiguration { get; set; }
    }
}
