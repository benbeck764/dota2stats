using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaStats.Services.Implementation
{
    public class BaseService
    {
        protected readonly IServiceContext Context;

        protected BaseService(IServiceContext context)
        {
            this.Context = context;
        }
    }
}
