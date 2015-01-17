using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bosphorus.ServiceModel.Hosting.Activation;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

[assembly: PreApplicationStartMethod(typeof(Startup), "Init")]

namespace Bosphorus.ServiceModel.Hosting.Activation
{
    public static class Startup
    {
        private static readonly Type ServiceHostFactoryType = typeof(PocoServiceHostFactory);

        public static void Init()
        {
            IServiceConfigurationRepository serviceConfigurationRepository = IoC.Resolve<IServiceConfigurationRepository>();
            IEnumerable<ServiceConfiguration> serviceConfigurations = serviceConfigurationRepository.GetAll();
            foreach (ServiceConfiguration serviceConfiguration in serviceConfigurations)
            {
                Type serviceType = serviceConfiguration.ServiceType;
                string address = string.Format("~/{0}.svc", serviceType.Name);
                DynamicServiceHelper.RegisterService(address, ServiceHostFactoryType, serviceType);
            }
        }
    }
}