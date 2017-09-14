namespace DotaStats.Core.Configuration.Implementation
{
    public class ServiceDependencies : IServiceDependencies
    {
        public bool UseTestRepositories { get; set; }
        public bool UseIntegrationTestRepositories { get; set; }
        public RepositoriesConfig RepositoriesConfig { get; set; }
    }
}
