using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Configuration
{
    //TODO: Cache decoration
    public class DefaultServiceConfigurationRepository : IServiceConfigurationRepository
    {
        private readonly IEnumerable<ServiceConfiguration> serviceConfigurations;

        public DefaultServiceConfigurationRepository(HostingConfiguration hostingConfiguration, IServiceConfigurationProvider serviceConfigurationProvider)
        {
            this.serviceConfigurations = serviceConfigurationProvider.Get(hostingConfiguration.ServiceGroupAlias);
        }

        public ServiceConfiguration Get(Type serviceType)
        {
            ServiceConfiguration configuration = this.serviceConfigurations.FirstOrDefault(c => c.ServiceType == serviceType);

            if (configuration == null)
            {
                string message = string.Format("Configuration for service type {0} not found", serviceType.Name);
                throw new InvalidOperationException(message);
            }

            return configuration;
        }

        public IEnumerable<ServiceConfiguration> GetAll()
        {
            return serviceConfigurations;
        }
    }
}