using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation
{
    public class CustomOperationInvokerBehavior : IOperationBehavior
    {
        private readonly IOperationInvoker operationInvoker;

        public CustomOperationInvokerBehavior(IOperationInvoker operationInvoker)
        {
            this.operationInvoker = operationInvoker;
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = this.operationInvoker;
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
