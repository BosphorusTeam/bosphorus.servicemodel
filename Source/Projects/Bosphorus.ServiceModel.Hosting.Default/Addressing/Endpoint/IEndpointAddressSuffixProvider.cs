using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint
{
    public interface IEndpointAddressSuffixProvider
    {
        string Get(BindingType bindingType);
    }
}