using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Contract
{
    public interface IContractDescriptionProvider
    {
        ContractDescription Get(ServiceConfiguration serviceConfiguration);
    }
}
