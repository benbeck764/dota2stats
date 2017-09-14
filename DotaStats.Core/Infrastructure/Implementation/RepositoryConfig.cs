namespace DotaStats.Core.Infrastructure.Implementation
{
    public class RepositoryConfig : IRepositoryConfig
    {
        public string Name { get; set; }
        public RepositoryConnection Connection { get; set; }
    }
}
