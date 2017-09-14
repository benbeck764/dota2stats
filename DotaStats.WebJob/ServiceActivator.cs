using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Practices.Unity;

namespace DotaStats.WebJob
{
    public class ServiceActivator : IJobActivator
    {
        private readonly IUnityContainer _container;

        public ServiceActivator(IUnityContainer container)
        {
            _container = container;
        }

        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
