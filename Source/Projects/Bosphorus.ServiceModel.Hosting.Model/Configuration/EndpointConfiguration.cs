using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration
{
    public class EndpointConfiguration
    {
        private readonly ServiceConfiguration serviceConfiguration;

        public EndpointConfiguration(ServiceConfiguration serviceConfiguration)
        {
            this.serviceConfiguration = serviceConfiguration;
        }

        public ServiceConfiguration ServiceConfiguration
        {
            get { return this.serviceConfiguration; }
        }

        public BindingType BindingType { get; set; }
    }
}