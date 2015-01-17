using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Addressing;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Default.Description.Contract;
using Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default
{
    public class PocoServiceHostProvider : IServiceHostProvider
    {
        private readonly IServiceEndpointProvider serviceEndpointProvider;
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;
        private readonly IContractDescriptionProvider contractDescriptionProvider;

        public PocoServiceHostProvider(IServiceEndpointProvider serviceEndpointProvider, IServiceNamespaceBuilder serviceNamespaceBuilder, IContractDescriptionProvider contractDescriptionProvider)
        {
            this.serviceEndpointProvider = serviceEndpointProvider;
            this.serviceNamespaceBuilder = serviceNamespaceBuilder;
            this.contractDescriptionProvider = contractDescriptionProvider;
        }

        public ServiceHost Get(ServiceConfiguration serviceConfiguration, params Uri[] baseAddresses)
        {
            Type serviceType = serviceConfiguration.ServiceType;
            string serviceNamespace = this.serviceNamespaceBuilder.Build(serviceType);
            ServiceHost serviceHost = new PocoServiceHost(serviceType, serviceNamespace, baseAddresses);
            ContractDescription contractDescription = this.contractDescriptionProvider.Get(serviceConfiguration);
            foreach (EndpointConfiguration endpointConfiguration in serviceConfiguration.EndpointConfigurations)
            {
                BindingScheme bindingScheme = endpointConfiguration.BindingType.GetScheme();
                Uri baseAddress = baseAddresses.FirstOrDefault(ba => ba.Scheme.Equals(bindingScheme.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (baseAddress == null)
                {
                    string message = string.Format("Base address for scheme {0} is not defined by configuration provider", bindingScheme);
                    throw new Exception(message); //TODO: Typed exception
                }

                ServiceEndpoint serviceEndpoint = this.serviceEndpointProvider.Get(contractDescription, endpointConfiguration, baseAddress);
                serviceHost.Description.Endpoints.Add(serviceEndpoint);
            }

            return serviceHost;
        }
    }
}
