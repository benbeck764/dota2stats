using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStats.Core.Logging.Implementation
{
    public class LoggerConfiguration : ILoggerConfiguration
    {
        public string AppInsightsInstrumentationKey { get; set; }
    }
}
