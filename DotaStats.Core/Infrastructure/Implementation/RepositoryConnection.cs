namespace DotaStats.Core.Infrastructure.Implementation
{
    public class RepositoryConnection : IRepositoryConnection
    {
        public string EndPointUrl { get; set; }
        public string AuthorizationKey { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
        public string RepositorySize { get; set; }
    }
}
