using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint
{
    public interface IServiceEndpointProvider
    {
        ServiceEndpoint Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress);
    }
}
