using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service
{
    public class ServiceRegistryInstanceProviderBehavior : IServiceBehavior
    {
        private readonly IServiceRegistry serviceRegistry;

        public ServiceRegistryInstanceProviderBehavior(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public virtual void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.InstanceProvider = new ServiceRegistryInstanceProvider(this.serviceRegistry, serviceDescription.ServiceType);
                }
            }
        }

        public virtual void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
