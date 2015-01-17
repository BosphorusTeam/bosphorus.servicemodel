using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Operation
{
    public class CompositeOperationBehavior : IOperationBehavior
    {
        private readonly IList<IOperationBehavior> items;

        public CompositeOperationBehavior(IList<IOperationBehavior> items)
        {
            this.items = items;
        }

        public void Validate(OperationDescription operationDescription)
        {
            foreach (IOperationBehavior operationBehavior in this.items)
            {
                operationBehavior.Validate(operationDescription);
            }
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            foreach (IOperationBehavior operationBehavior in this.items)
            {
                operationBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
            }
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            foreach (IOperationBehavior operationBehavior in this.items)
            {
                operationBehavior.ApplyClientBehavior(operationDescription, clientOperation);
            }
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            foreach (IOperationBehavior operationBehavior in this.items)
            {
                operationBehavior.AddBindingParameters(operationDescription, bindingParameters);
            }
        }
    }
}
