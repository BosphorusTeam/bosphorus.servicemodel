using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint.BehaviorProvider
{
    public interface IEndpointBehaviorProvider
    {
        bool IsApplicable(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint);
        IEnumerable<IEndpointBehavior> Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint);
    }
}