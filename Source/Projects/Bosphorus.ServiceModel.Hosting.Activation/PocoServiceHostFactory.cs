using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Activation
{
    public class PocoServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            IServiceHostProvider serviceHostProvider = IoC.Resolve<IServiceHostProvider>();
            IServiceConfigurationRepository serviceConfigurationRepository = IoC.Resolve<IServiceConfigurationRepository>();
            ServiceConfiguration serviceConfiguration = serviceConfigurationRepository.Get(serviceType);
            ServiceHost serviceHost = serviceHostProvider.Get(serviceConfiguration, baseAddresses);
            
            return serviceHost;
        }
    }
}
