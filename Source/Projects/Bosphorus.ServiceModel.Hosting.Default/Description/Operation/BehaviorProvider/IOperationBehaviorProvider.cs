using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation.BehaviorProvider
{
    public interface IOperationBehaviorProvider
    {
        bool IsApplicable(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription);
        IEnumerable<IOperationBehavior> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription);
    }
}