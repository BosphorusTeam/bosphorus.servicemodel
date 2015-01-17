using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration
{
    public abstract class AbstractServiceConfigurationProvider : IServiceConfigurationProvider
    {
        private readonly string alias;

        protected AbstractServiceConfigurationProvider(string alias)
        {
            this.alias = alias;
        }

        public IEnumerable<ServiceConfiguration> Get(string serviceGroupAlias)
        {
            if (this.alias != serviceGroupAlias)
            {
                return Enumerable.Empty<ServiceConfiguration>();
            }

            IEnumerable<ServiceConfiguration> serviceConfigurations = this.GetInternal();
            
            return serviceConfigurations;
        }

        protected abstract IEnumerable<ServiceConfiguration> GetInternal();
    }
}