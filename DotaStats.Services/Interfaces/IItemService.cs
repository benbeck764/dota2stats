using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Model.Dota2API.Item;

namespace DotaStats.Services.Interfaces
{
    public interface IItemService
    {
        Task Upsert(Item hero);
        Task Delete(int itemId);

        Model.Persistence.Item Get(int itemId);
    }
}
