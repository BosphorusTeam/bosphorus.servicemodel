using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Channels
{
    public abstract class AbstractBindingProvider : IBindingProvider
    {
        private readonly BindingType bindingType;
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;

        protected AbstractBindingProvider(BindingType bindingType, IServiceNamespaceBuilder serviceNamespaceBuilder)
        {
            this.bindingType = bindingType;
            this.serviceNamespaceBuilder = serviceNamespaceBuilder;
        }

        public bool IsApplicable(EndpointConfiguration endpointConfiguration)
        {
            bool isApplicable = endpointConfiguration.BindingType == bindingType;

            return isApplicable;
        }

        public Binding Get(EndpointConfiguration endpointConfiguration)
        {
            Binding binding = GetBindingInstance(endpointConfiguration);

            Type serviceType = endpointConfiguration.ServiceConfiguration.ServiceType;
            string bindingNamespace = serviceNamespaceBuilder.Build(serviceType);
            binding.Namespace = bindingNamespace;

            return binding;
        }

        protected abstract Binding GetBindingInstance(EndpointConfiguration endpointConfiguration);
    }
}
