using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Core.Logging
{
    public interface ILoggerConfiguration
    {
        string AppInsightsInstrumentationKey { get; set; }
    }
}
