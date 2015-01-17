using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration
{
    public class ServiceConfiguration
    {
        public ServiceConfiguration()
        {
            this.EndpointConfigurations = new List<EndpointConfiguration>();
        }

        public virtual Type ServiceType { get; set; }

        public virtual List<EndpointConfiguration> EndpointConfigurations { get; set; }
    }
}