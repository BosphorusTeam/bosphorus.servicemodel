using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service
{
    public class CompositeServiceBehavior : IServiceBehavior
    {
        private readonly IList<IServiceBehavior> items;

        public CompositeServiceBehavior(IList<IServiceBehavior> items)
        {
            this.items = items;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (IServiceBehavior serviceBehavior in this.items)
            {
                serviceBehavior.Validate(serviceDescription, serviceHostBase);
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            foreach (IServiceBehavior serviceBehavior in this.items)
            {
                serviceBehavior.AddBindingParameters(serviceDescription, serviceHostBase, endpoints, bindingParameters);
            }
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (IServiceBehavior serviceBehavior in this.items)
            {
                serviceBehavior.ApplyDispatchBehavior(serviceDescription, serviceHostBase);
            }
        }
    }
}
