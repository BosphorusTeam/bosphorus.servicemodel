using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Channels
{
    public interface IBindingProvider
    {
        bool IsApplicable(EndpointConfiguration endpointConfiguration);
        Binding Get(EndpointConfiguration endpointConfiguration);
    }
}