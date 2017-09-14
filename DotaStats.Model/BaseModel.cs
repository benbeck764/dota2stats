using System;

namespace DotaStats.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime LastModified { get; set; }
    }
}
