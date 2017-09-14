using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Configuration.Implementation;
using DotaStats.Core.Infrastructure.Implementation;
using DotaStats.Core.Logging.Implementation;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace DotaStats.Core.Configuration
{
    public static class DotaStatsApplication
    {
        private static readonly string StorageConnectionString = ConfigurationManager.AppSettings["ds:StorageConnectionString"];
        private static readonly string BlobStorageConnectionString = ConfigurationManager.AppSettings["ds:BlobStorageConnectionString"];

        public static DotaStatsEnvironment Environment { get; private set; } = null;

        public static Logger Logger { get; private set; } = null;

        public static string Key { get; } = ConfigurationManager.AppSettings["ds:EnvironmentKey"];

        static DotaStatsApplication()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Environment = InitializeEnvironment();
            Logger = InitializeLogger();
            Logger.LogTrace(Guid.NewGuid().ToString(), "DS-Application-Initialize", JsonConvert.SerializeObject(Environment));
        }

        static DotaStatsEnvironment InitializeEnvironment()
        {
            return new DotaStatsEnvironment()
            {
                LoggerConfiguration = new LoggerConfiguration()
                {
                    AppInsightsInstrumentationKey = "0e79c56c-2853-4091-b8ac-371bb32ae80e"
                },
                ServiceDependencies = new ServiceDependencies()
                {
                    UseIntegrationTestRepositories = false,
                    UseTestRepositories = false,
                    RepositoriesConfig = new RepositoriesConfig()
                    {
                        RepositoryConfigs = new List<RepositoryConfig>()
                        {
                            new RepositoryConfig()
                            {
                                Name = "Match",
                                Connection = new RepositoryConnection()
                                {
                                    Collection = "HeroMatchData",
                                    Database = "DSData",
                                    EndPointUrl = "https://benstestcosmosdb.documents.azure.com:443/",
                                    AuthorizationKey = "kN9rkKCUWO7SPRyu5suHlrF6q644GfyXDyaTtVWTTmd3DH7TtDhsk2d3ICaQRp15tPllnoGpFAW0UhVoUy25BQ==",
                                    RepositorySize = "S2"
                                }
                            },
                            new RepositoryConfig()
                            {
                                Name = "Hero",
                                Connection = new RepositoryConnection()
                                {
                                    Collection = "HeroMatchData",
                                    Database = "DSData",
                                    EndPointUrl = "https://benstestcosmosdb.documents.azure.com:443/",
                                    AuthorizationKey = "kN9rkKCUWO7SPRyu5suHlrF6q644GfyXDyaTtVWTTmd3DH7TtDhsk2d3ICaQRp15tPllnoGpFAW0UhVoUy25BQ==",
                                    RepositorySize = "S2"
                                }
                            },
                            new RepositoryConfig()
                            {
                                Name = "Item",
                                Connection = new RepositoryConnection()
                                {
                                    Collection = "HeroMatchData",
                                    Database = "DSData",
                                    EndPointUrl = "https://benstestcosmosdb.documents.azure.com:443/",
                                    AuthorizationKey = "kN9rkKCUWO7SPRyu5suHlrF6q644GfyXDyaTtVWTTmd3DH7TtDhsk2d3ICaQRp15tPllnoGpFAW0UhVoUy25BQ==",
                                    RepositorySize = "S2"
                                }
                            }
                        }
                    }
                },
                BlobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=benstestblobstorage;AccountKey=r3W1xQk0qgqDHiIfslhT6NWONS0pi2kRwkCTNRRB+Yt+aqw5ZmTC5VgHBH6zjbhemUJsBjs9+d3HBaij7jZ09w==;EndpointSuffix=core.windows.net",
                StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=bensteststorage;AccountKey=jiKEKx56bBBt4bh1NHPcgjrv4Y++heckjVXNIj1uCx+KsJcm4vjh65fIwbAgLDJIoNHJ5yGsVYQD7jbL2vJJbw==;EndpointSuffix=core.windows.net"
            };
        }

        // TODO -- Implement configurable environment w/ blob storage JSON file
        //static DotaStatsEnvironment InitializeEnvironment()
        //{
        //    var container = GetBlobContainer();
        //    var blob = GetBlob(container);

        //    using (var ms = new MemoryStream())
        //    {
        //        blob.DownloadToStream(ms);
        //        var json = System.Text.Encoding.UTF8.GetString(ms.ToArray());

        //        if (string.IsNullOrWhiteSpace(json))
        //        {
        //            throw new ArgumentException($"The Configuration blob for {Key}.json was empty.");
        //        }

        //        return JsonConvert.DeserializeObject<DotaStatsEnvironment>(json);
        //    }
        //}

        static CloudBlobContainer GetBlobContainer()
        {
            if (string.IsNullOrWhiteSpace(BlobStorageConnectionString))
            {
                throw new ArgumentException("A ds:StorageConnectionString AppSetting must be set to initialize the configuration.");
            }

            if (string.IsNullOrWhiteSpace(Key))
            {
                throw new ArgumentException("A ds:EnvironmentKey AppSetting must be set to initialize the configuration.");
            }

            var storageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("dotastats-environmentconfiguration");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Off });

            return container;
        }

        static CloudBlockBlob GetBlob(CloudBlobContainer container)
        {
            // Retrieve the blob named for our enviornment
            var environmentConfig = container.GetBlockBlobReference($"{Key}.json");
            if (environmentConfig.Exists() == false)
            {
                throw new ArgumentException($"A configuration blob was not found for {Key}.json");
            }

            return environmentConfig;
        }

        static Logger InitializeLogger()
        {
            if (string.IsNullOrWhiteSpace(Environment.LoggerConfiguration.AppInsightsInstrumentationKey))
            {
                throw new ArgumentException("An Application Insights instrumentation key is required to initialize the Logger.");
            }

            return new Logger(Environment.LoggerConfiguration.AppInsightsInstrumentationKey);
        }
    }
}
