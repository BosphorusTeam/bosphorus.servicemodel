using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Endpoint;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Endpoint.DispatchMessageInspector;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint.BehaviorProvider
{
    public abstract class AbstractDispatchMessageInspector<TDispatchMessageInspectorProvider> : IEndpointBehaviorProvider
        where TDispatchMessageInspectorProvider : IDispatchMessageInspectorProvider
    {
        private readonly IList<TDispatchMessageInspectorProvider> dispatchMessageInspectorProviders;

        protected AbstractDispatchMessageInspector(IList<TDispatchMessageInspectorProvider> dispatchMessageInspectorProviders)
        {
            this.dispatchMessageInspectorProviders = dispatchMessageInspectorProviders;
        }

        protected IList<TDispatchMessageInspectorProvider> DispatchMessageInspectorProviders
        {
            get { return this.dispatchMessageInspectorProviders; }
        }

        public bool IsApplicable(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint)
        {
            bool isApplicable = this.IsApplicableInternal(contractDescription, endpointConfiguration, baseAddress, serviceEndpoint);

            return isApplicable;
        }

        protected abstract bool IsApplicableInternal(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint);

        public IEnumerable<IEndpointBehavior> Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint)
        {
            IEnumerable<GenericDispatchMessageInspectorBehavior<TDispatchMessageInspectorProvider>> behaviors = this.DispatchMessageInspectorProviders.Select(provider => new GenericDispatchMessageInspectorBehavior<TDispatchMessageInspectorProvider>(provider));

            return behaviors;
        }
    }
}
