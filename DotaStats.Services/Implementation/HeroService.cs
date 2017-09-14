using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaStats.Core.SharedData;
using DotaStats.Model;
using DotaStats.Model.Dota2API.Hero;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class HeroService : BaseService, IHeroService
    {
        public HeroService(IServiceContext context) : base(context) { }

        public async Task Upsert(Hero hero)
        {
            //var existingHero = Get(hero.Id);
            //if (existingHero == null)
            //{
                var mappedHero = Mapper.MapHero(hero);

                mappedHero.Id = Guid.NewGuid();
                mappedHero.LastModified = DateTime.UtcNow;

                await Context.Repositories.Heroes.Upsert(mappedHero);
            //}
            //else
            //{
            //    var mappedHero = Mapper.MapHero(hero);
            //    mappedHero.Id = existingHero.Id;
            //    mappedHero.LastModified = DateTime.UtcNow;
            //    await Context.Repositories.Heroes.Upsert(mappedHero);
            //}
        }

        public Model.Persistence.Hero Get(int heroId)
        {
            //return Context.Repositories.Heroes.Query().Where(h => h.HeroId == heroId).AsEnumerable().FirstOrDefault();
            return Heroes.GetHeroes().FirstOrDefault(h => h.HeroId == heroId);
        }

        public async Task Delete(int heroId)
        {
            var hero = Get(heroId);
            if (hero != null)
            {
                await Context.Repositories.Heroes.Delete(hero);
            }
        }

        public IEnumerable<Model.Persistence.Hero> GetAll()
        {
            //return Context.Repositories.Heroes.Query().AsEnumerable();
            return Heroes.GetHeroes().AsEnumerable();
        }
    }
}
