using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Endpoint
{
    public class CompositeEndpointBehavior : IEndpointBehavior
    {
        private readonly IList<IEndpointBehavior> items;

        public CompositeEndpointBehavior(IList<IEndpointBehavior> items)
        {
            this.items = items;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            foreach (IEndpointBehavior endpointBehavior in this.items)
            {
                endpointBehavior.Validate(endpoint);
            }
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            foreach (IEndpointBehavior endpointBehavior in this.items)
            {
                endpointBehavior.AddBindingParameters(endpoint, bindingParameters);
            }
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (IEndpointBehavior endpointBehavior in this.items)
            {
                endpointBehavior.ApplyDispatchBehavior(endpoint, endpointDispatcher);
            }
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (IEndpointBehavior endpointBehavior in this.items)
            {
                endpointBehavior.ApplyClientBehavior(endpoint, clientRuntime);
            }
        }
    }
}
