using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration.Fluent
{
    public class EndpointConfigurator
    {
        private readonly ServiceConfiguration serviceConfiguration;

        internal EndpointConfigurator(ServiceConfiguration serviceConfiguration)
        {
            this.serviceConfiguration = serviceConfiguration;
        }

        public ServiceConfiguration Build()
        {
            return this.serviceConfiguration;
        }

        public EndpointConfigurator Through(params BindingType[] bindingTypes)
        {
            foreach (BindingType bindingType in bindingTypes)
            {
                EndpointConfiguration endpointConfiguration = new EndpointConfiguration(this.serviceConfiguration);
                endpointConfiguration.BindingType = bindingType;
                this.serviceConfiguration.EndpointConfigurations.Add(endpointConfiguration);
            }
            
            return this;
        }
    }
}