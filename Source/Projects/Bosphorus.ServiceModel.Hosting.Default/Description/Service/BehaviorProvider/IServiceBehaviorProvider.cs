using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public interface IServiceBehaviorProvider
    {
        bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost);
        IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost);
    }
}