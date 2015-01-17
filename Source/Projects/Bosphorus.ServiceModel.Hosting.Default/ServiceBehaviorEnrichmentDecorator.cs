using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default
{
    public class ServiceBehaviorEnrichmentDecorator : IServiceHostProvider
    {
        private readonly IServiceHostProvider decorated;
        private readonly IList<IServiceBehaviorProvider> serviceBehaviorProviders;

        public ServiceBehaviorEnrichmentDecorator(IServiceHostProvider decorated, IList<IServiceBehaviorProvider> serviceBehaviorProviders)
        {
            this.decorated = decorated;
            this.serviceBehaviorProviders = serviceBehaviorProviders;
        }

        public ServiceHost Get(ServiceConfiguration serviceConfiguration, params Uri[] baseAddresses)
        {
            ServiceHost serviceHost = decorated.Get(serviceConfiguration, baseAddresses);

            foreach (IServiceBehaviorProvider serviceBehaviorProvider in this.serviceBehaviorProviders)
            {
                if (!serviceBehaviorProvider.IsApplicable(serviceConfiguration, baseAddresses, serviceHost))
                {
                    continue;
                }

                IEnumerable<IServiceBehavior> behaviors = serviceBehaviorProvider.Get(serviceConfiguration, baseAddresses, serviceHost);
                foreach (IServiceBehavior behavior in behaviors)
                {
                    Type behaviorType = behavior.GetType();
                    serviceHost.Description.Behaviors.Remove(behaviorType);
                    serviceHost.Description.Behaviors.Add(behavior);
                }
            }

            return serviceHost;
        }
    }
}