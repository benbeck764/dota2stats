using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Core.SharedData;
using DotaStats.Model;
using DotaStats.Model.Dota2API.Item;
using DotaStats.Services.Interfaces;

namespace DotaStats.Services.Implementation
{
    public class ItemService : BaseService, IItemService
    {
        public ItemService(IServiceContext context) : base(context) { }

        public async Task Upsert(Item item)
        {
            var mappedItem = Mapper.MapItem(item);

            mappedItem.Id = Guid.NewGuid();
            mappedItem.LastModified = DateTime.UtcNow;

            await Context.Repositories.Items.Upsert(mappedItem);     
        }

        public async Task Delete(int itemId)
        {
            var item = Get(itemId);
            if (item != null)
            {
                await Context.Repositories.Items.Delete(item);
            }
        }

        public Model.Persistence.Item Get(int itemId)
        {
            //return Context.Repositories.Items.Query().Where(i => i.ItemId == itemId).AsEnumerable().FirstOrDefault();
            return Items.GetItems().FirstOrDefault(i => i.ItemId == itemId);
        }
    }
}
