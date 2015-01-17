using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint
{
    public interface IEndpointAddressBuilder
    {
        EndpointAddress Build(EndpointConfiguration endpointConfiguration, Uri baseAddress);
    }
}