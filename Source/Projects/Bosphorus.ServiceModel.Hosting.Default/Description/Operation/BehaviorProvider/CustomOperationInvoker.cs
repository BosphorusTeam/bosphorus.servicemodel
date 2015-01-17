using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Default.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation.BehaviorProvider
{
    public class CustomOperationInvoker : IOperationBehaviorProvider
    {
        public bool IsApplicable(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            return true;
        }

        public IEnumerable<IOperationBehavior> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            IOperationInvoker operationInvoker = new PocoServiceOperationInvoker(methodInfo);
            CustomOperationInvokerBehavior behavior = new CustomOperationInvokerBehavior(operationInvoker);

            return new[] {behavior};
        }
    }
}
