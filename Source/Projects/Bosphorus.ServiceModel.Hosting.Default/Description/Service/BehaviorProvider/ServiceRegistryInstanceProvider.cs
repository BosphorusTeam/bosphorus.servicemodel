using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public class ServiceRegistryInstanceProvider : IServiceBehaviorProvider
    {
        private readonly IServiceRegistry serviceRegistry;

        public ServiceRegistryInstanceProvider(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            return true;
        }

        public IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            ServiceRegistryInstanceProviderBehavior behavior = new ServiceRegistryInstanceProviderBehavior(this.serviceRegistry);

            return new[] {behavior};
        }
    }
}