using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration.Fluent
{
    public class ConfigureService
    {
        public static ServiceConfigurator ProvidedBy<TService>()
        {
            ServiceConfigurator serviceConfigurator = ProvidedBy(typeof (TService));
            return serviceConfigurator;
        }

        public static ServiceConfigurator ProvidedBy(Type serviceType)
        {
            ServiceConfiguration serviceConfiguration = new ServiceConfiguration();
            serviceConfiguration.ServiceType = serviceType;
            ServiceConfigurator serviceConfigurator = new ServiceConfigurator(serviceConfiguration);

            return serviceConfigurator;
        }
    }
}
 