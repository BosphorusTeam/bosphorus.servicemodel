using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Contract.BehaviorProvider
{
    public interface IContractBehaviorProvider
    {
        bool IsApplicable(ServiceConfiguration serviceConfiguration, ContractDescription contractDescription);
        IEnumerable<IContractBehavior> Get(ServiceConfiguration serviceConfiguration, ContractDescription contractDescription);
    }
}