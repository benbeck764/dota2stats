using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Model.Dota2API.Hero;

namespace DotaStats.Services.Interfaces
{
    public interface IHeroService
    {
        Task Upsert(Hero hero);
        Task Delete(int heroId);
        IEnumerable<Model.Persistence.Hero> GetAll();
    }
}
