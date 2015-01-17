using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint
{
    public class DefaultEndpointAddressBuilder : IEndpointAddressBuilder
    {
        private readonly IEndpointAddressSuffixProvider endpointAddressSuffixProvider;
        
        public DefaultEndpointAddressBuilder(IEndpointAddressSuffixProvider endpointAddressSuffixProvider)
        {
            this.endpointAddressSuffixProvider = endpointAddressSuffixProvider;
        }

        public EndpointAddress Build(EndpointConfiguration endpointConfiguration, Uri baseAddress)
        {
            string protocolSpecifier = this.endpointAddressSuffixProvider.Get(endpointConfiguration.BindingType);
            UriBuilder builder = new UriBuilder(baseAddress);
            builder.Path = string.Format("{0}/{1}", builder.Path, protocolSpecifier);
            Uri endpointUri = builder.Uri;
            EndpointAddress endpointAddress = new EndpointAddress(endpointUri);
            
            return endpointAddress;
        }
    }
}
