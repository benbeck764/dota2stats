using System.Collections.Generic;
using DotaStats.Model.API;

namespace DotaStats.Services.Interfaces
{
    public interface IRecordsService
    {
        IEnumerable<HeroRecord> GetAll(long accountId);
    }
}
