using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration.Fluent
{
    public class ServiceConfigurator
    {
        private readonly ServiceConfiguration serviceConfiguration;

        internal ServiceConfigurator(ServiceConfiguration serviceConfiguration)
        {
            this.serviceConfiguration = serviceConfiguration;
        }

        public EndpointConfigurator Exposed 
        {
            get
            {
                return new EndpointConfigurator(this.serviceConfiguration);
            }
        }
    }
}