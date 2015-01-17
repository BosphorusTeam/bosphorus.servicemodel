using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Addressing;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint;
using Bosphorus.ServiceModel.Hosting.Default.Channels;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint
{
    //TODO:Investigate IServiceContractGenerationExtension
    public class DefaultServiceEndpointProvider : IServiceEndpointProvider
    {
        private readonly IBindingProvider bindingProvider;
        private readonly IEndpointAddressBuilder endpointAddressBuilder;
        
        public DefaultServiceEndpointProvider(IBindingProvider bindingProvider, IEndpointAddressBuilder endpointAddressBuilder)
        {
            this.bindingProvider = bindingProvider;
            this.endpointAddressBuilder = endpointAddressBuilder;
        }

        public ServiceEndpoint Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress)
        {
            EndpointAddress endpointAddress = endpointAddressBuilder.Build(endpointConfiguration, baseAddress);
            Binding binding = this.bindingProvider.Get(endpointConfiguration);
            ServiceEndpoint endpoint = new ServiceEndpoint(contractDescription, binding, endpointAddress);

            return endpoint;
        }
    }
}