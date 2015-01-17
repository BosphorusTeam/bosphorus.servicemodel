using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using Bosphorus.ServiceModel.Hosting.Model;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default
{
    public class MetadataExchangeEndpointEnrichmentDecorator : IServiceHostProvider
    {
        private readonly IServiceHostProvider decorated;

        public MetadataExchangeEndpointEnrichmentDecorator(IServiceHostProvider decorated)
        {
            this.decorated = decorated;
        }

        public ServiceHost Get(ServiceConfiguration serviceConfiguration, params Uri[] baseAddresses)
        {
            ServiceHost serviceHost = decorated.Get(serviceConfiguration, baseAddresses);
            if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                return serviceHost;
            }

            IEnumerable<BindingScheme> distinctBindingSchemes = serviceConfiguration.EndpointConfigurations.Select(ec => ec.BindingType.GetScheme()).Distinct();
            foreach (BindingScheme bindingScheme in distinctBindingSchemes)
            {
                Binding mexBinding = this.BuildMetadataExchangeBinding(bindingScheme);
                serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");
            }

            return serviceHost;
        }

        private Binding BuildMetadataExchangeBinding(BindingScheme bindingScheme)
        {
            switch (bindingScheme.Id)
            {
                case "Http":
                    return MetadataExchangeBindings.CreateMexHttpBinding();
                case "Https":
                    return MetadataExchangeBindings.CreateMexHttpsBinding();
                case "NetTcp":
                    return MetadataExchangeBindings.CreateMexTcpBinding();
                default:
                    string message = string.Format("MetadataExchange Binding for binding scheme {0} is not supported", bindingScheme);
                    throw new InvalidOperationException(message);
            }
        }
    }
}
