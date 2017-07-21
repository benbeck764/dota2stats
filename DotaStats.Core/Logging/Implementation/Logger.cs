using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace DotaStats.Core.Logging.Implementation
{
    public class Logger
    {
        private readonly TelemetryClient _telemetry;

        public Logger(string instrumentationKey)
        {
            TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            _telemetry = new TelemetryClient { Context = { InstrumentationKey = instrumentationKey } };
        }

        public void LogTrace(string operationName, string message)
        {
            _telemetry.Context.Operation.Name = operationName;

            _telemetry.TrackTrace(operationName + " | " + message);

            if (Debugger.IsAttached)
            {
                Debug.WriteLine(operationName + " | " + message);
            }
        }

        public void LogTrace(string requestId, string operationName, string message)
        {
            _telemetry.Context.Operation.Id = requestId;
            _telemetry.Context.Operation.Name = operationName;

            _telemetry.TrackTrace(requestId + " | " + operationName + " | " + message);

            if (Debugger.IsAttached)
            {
                Debug.WriteLine(requestId + " | " + operationName + " | " + message);
            }
        }

        public void LogException(string operationName, Exception ex)
        {
            if (ex == null) return;

            _telemetry.Context.Operation.Name = operationName;

            _telemetry.TrackException(ex);

            if (Debugger.IsAttached)
            {
                Debug.WriteLine(operationName + " | " + ex);
            }
        }

        public void LogException(string requestId, string operationName, Exception ex)
        {
            if (ex == null) return;

            _telemetry.Context.Operation.Id = requestId;
            _telemetry.Context.Operation.Name = operationName;

            _telemetry.TrackException(ex);

            if (Debugger.IsAttached)
            {
                Debug.WriteLine(requestId + " | " + operationName + " | " + ex);
            }
        }
    }
}
