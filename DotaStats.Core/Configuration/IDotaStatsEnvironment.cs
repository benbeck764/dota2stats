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
