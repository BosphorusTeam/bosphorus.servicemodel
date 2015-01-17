using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Contract
{
    public class CompositeContractBehavior : IContractBehavior
    {
        private readonly IList<IContractBehavior> items;

        public CompositeContractBehavior(IList<IContractBehavior> items)
        {
            this.items = items;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            foreach (IContractBehavior contractBehavior in this.items)
            {
                contractBehavior.Validate(contractDescription, endpoint);
            }
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            foreach (IContractBehavior contractBehavior in this.items)
            {
                contractBehavior.ApplyDispatchBehavior(contractDescription, endpoint, dispatchRuntime);
            }
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (IContractBehavior contractBehavior in this.items)
            {
                contractBehavior.ApplyClientBehavior(contractDescription, endpoint, clientRuntime);
            }
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            foreach (IContractBehavior contractBehavior in this.items)
            {
                contractBehavior.AddBindingParameters(contractDescription, endpoint, bindingParameters);
            }
        }
    }
}
