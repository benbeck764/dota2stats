using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaStats.Model.Extensions
{
    public static class ModelExtensions
    {
        public static string ToJson(this object obj)
        {
            return obj == null ? "" : JsonConvert.SerializeObject(obj);
        }
    }
}
