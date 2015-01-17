using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint.BehaviorProvider;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint
{
    public class BehaviorEnrichmentDecorator : IServiceEndpointProvider
    {
        private readonly IServiceEndpointProvider decorated;
        private readonly IList<IEndpointBehaviorProvider> endpointBehaviorProviders;

        public BehaviorEnrichmentDecorator(IServiceEndpointProvider decorated, IList<IEndpointBehaviorProvider> endpointBehaviorProviders)
        {
            this.decorated = decorated;
            this.endpointBehaviorProviders = endpointBehaviorProviders;
        }

        public ServiceEndpoint Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress)
        {
            ServiceEndpoint serviceEndpoint = decorated.Get(contractDescription, endpointConfiguration, baseAddress);

            foreach (IEndpointBehaviorProvider endpointBehaviorProvider in endpointBehaviorProviders)
            {
                if (!endpointBehaviorProvider.IsApplicable(contractDescription, endpointConfiguration, baseAddress, serviceEndpoint))
                {
                    continue;
                }

                IEnumerable<IEndpointBehavior> behaviors = endpointBehaviorProvider.Get(contractDescription, endpointConfiguration, baseAddress, serviceEndpoint);
                foreach (IEndpointBehavior behavior in behaviors)
                {
                    serviceEndpoint.Behaviors.Add(behavior);
                }
            }

            return serviceEndpoint;
        }
    }
}
