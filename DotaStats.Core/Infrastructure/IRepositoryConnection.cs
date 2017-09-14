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
