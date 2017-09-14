using System;
using System.Linq;

namespace DotaStats.Core.Infrastructure
{
    public abstract class BaseRepository
    {
        protected readonly IRepositoriesConfig Configuration;

        protected BaseRepository(IRepositoriesConfig configuration)
        {
            this.Configuration = configuration;
        }

        protected IRepositoryConnection FindActiveConfig(string name)
        {
            var config = Configuration.RepositoryConfigs.FirstOrDefault(c => c.Name == name);
            if (config != null)
            {
                return config.Connection;
            }
            throw new InvalidOperationException($"Unable to locate a Repository Connection with name '{name}'");
        }
    }
}
