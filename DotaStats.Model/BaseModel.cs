using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime LastModified { get; set; }
    }
}
