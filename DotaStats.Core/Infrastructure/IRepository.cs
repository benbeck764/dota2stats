using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaStats.Core.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();
        IEnumerable<T> Query(string query);
        IQueryable<TObjType> QueryAllByType<TObjType>();
        Task Upsert(T item);
        Task Delete(T item);
        void Dispose();
    }
}
