using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStats.Model.API;

namespace DotaStats.Services.Interfaces
{
    public interface IRecordsService
    {
        IEnumerable<HeroRecord> GetAll(long accountId);
    }
}
