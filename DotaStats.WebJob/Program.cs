using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using DotaStats.Core.Configuration;
using DotaStats.Services;
using Microsoft.Practices.Unity;

namespace DotaStats.WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            try
            {
                var container = new UnityContainer();
                container.RegisterType<IServices, IServices>();

                var services = ServiceFactory
                    .Create(DotaStatsApplication
                        .Environment.ServiceDependencies);

                container.RegisterInstance(services);

                var config = new JobHostConfiguration
                {
                    DashboardConnectionString = DotaStatsApplication.Environment.StorageConnectionString,
                    StorageConnectionString = DotaStatsApplication.Environment.StorageConnectionString,
                    JobActivator = new ServiceActivator(container)
                };

                // Use TriggeredTimers for continuously cleaning RO Drafts
                config.UseTimers();

                var host = new JobHost(config);

                // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
            catch (Exception ex)
            {
                DotaStatsApplication.Logger.LogException("", "Dota 2 API WebJob Startup", ex);
            }
        }
    }
}
