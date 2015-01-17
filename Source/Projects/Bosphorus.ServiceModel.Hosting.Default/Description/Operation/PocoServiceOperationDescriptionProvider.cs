using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Message;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation
{
    public class PocoServiceOperationDescriptionProvider : IOperationDescriptionProvider
    {
        private readonly IMessageDescriptionProvider messageDescriptionProvider;

        public PocoServiceOperationDescriptionProvider(IMessageDescriptionProvider messageDescriptionProvider)
        {
            this.messageDescriptionProvider = messageDescriptionProvider;
        }

        public OperationDescription Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration)
        {
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            OperationDescription operationDescription = new OperationDescription(methodInfo.Name, contractDescription);
            operationDescription.SyncMethod = methodInfo;

            IEnumerable<MessageDescription> messageDescriptions = this.messageDescriptionProvider.Get(contractDescription, operationConfiguration);
            foreach (MessageDescription messageDescription in messageDescriptions)
            {
                operationDescription.Messages.Add(messageDescription);
            }

            return operationDescription;
        }
    }
}