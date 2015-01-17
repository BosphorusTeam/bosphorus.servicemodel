using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration
{
    internal class CompositeServiceConfigurationProvider : IServiceConfigurationProvider
    {
        private readonly IList<IServiceConfigurationProvider> items;

        public CompositeServiceConfigurationProvider(IList<IServiceConfigurationProvider> items)
        {
            this.items = items;
        }

        public IEnumerable<ServiceConfiguration> Get(string serviceGroupAlias)
        {
            IEnumerable<ServiceConfiguration> configurations = items.SelectMany(item => item.Get(serviceGroupAlias));

            return configurations;
        }
    }
}