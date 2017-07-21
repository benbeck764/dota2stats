using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.Infrastructure;
using DotaStats.Model.Persistence;

namespace DotaStats.Repository
{
    public interface IRepositories : IDisposable
    {
        IRepository<Match> Matches { get; }
        IRepository<Hero> Heroes { get; }
        IRepository<Item> Items { get; }    }
}
