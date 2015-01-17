using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core
{
    public interface IServiceHostProvider
    {
        ServiceHost Get(ServiceConfiguration serviceConfiguration, params Uri[] baseAddresses);
    }
}