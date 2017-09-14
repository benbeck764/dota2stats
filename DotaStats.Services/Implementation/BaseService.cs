namespace DotaStats.Services.Implementation
{
    public class BaseService
    {
        protected readonly IServiceContext Context;

        protected BaseService(IServiceContext context)
        {
            this.Context = context;
        }
    }
}
