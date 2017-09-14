using DotaStats.Core.Configuration;
using DotaStats.Repository;
using DotaStats.Services.Implementation;

namespace DotaStats.Services
{
    public static class ServiceFactory
    {
        public static IServices Create(IServiceDependencies dependencies)
        {

            IRepositories repositories;
            IServiceContext context;

            if (!dependencies.UseTestRepositories)
            {
                repositories = RepositoriesFactory.Create(dependencies.RepositoriesConfig);
                context = new ServiceContext(dependencies, repositories);

                // TODO -- Implement Integration Test Repositories/Services
                //if (dependencies.UseIntegrationTestRepositories)
                //{
                //    return new TestServices(context);
                //}
                //else
                //{
                //    return new Implementation.Services(context);
                //}
                return new Implementation.Services(context);
            }
            else
            {
                // TODO -- Implement Test Repositories/Services
                //repositories = TestRepositoriesFactory.Create();
                //context = new ServiceContext(dependencies, repositories);
                //return new TestServices(context);

                repositories = RepositoriesFactory.Create(dependencies.RepositoriesConfig);
                context = new ServiceContext(dependencies, repositories);
                return new Implementation.Services(context);
            }
        }
    }
}
