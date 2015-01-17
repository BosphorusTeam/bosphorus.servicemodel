using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation.BehaviorProvider
{
    public class DataContractSerializer : IOperationBehaviorProvider
    {
        public bool IsApplicable(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            return true;
        }

        public IEnumerable<IOperationBehavior> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            DataContractSerializerOperationBehavior behavior = new DataContractSerializerOperationBehavior(operationDescription);

            return new[] {behavior};
        }
    }
}
