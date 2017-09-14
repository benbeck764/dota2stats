using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Logging.Implementation;

namespace DotaStats.Core.Configuration.Implementation
{
    public class DotaStatsEnvironment : IDotaStatsEnvironment
    {
        public ServiceDependencies ServiceDependencies { get; set; }
        public string StorageConnectionString { get; set; }
        public string BlobStorageConnectionString { get; set; }
        public LoggerConfiguration LoggerConfiguration { get; set; }
    }
}
