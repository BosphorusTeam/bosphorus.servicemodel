using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Default.Description.Message.Action;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Message
{
    public class OutputMessageDescriptionProvider : IMessageDescriptionProvider
    {
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;
        private readonly IMessageActionProvider messageActionProvider;

        public OutputMessageDescriptionProvider(IServiceNamespaceBuilder serviceNamespaceBuilder, IMessageActionProvider messageActionProvider)
        {
            this.serviceNamespaceBuilder = serviceNamespaceBuilder;
            this.messageActionProvider = messageActionProvider;
        }

        public IEnumerable<MessageDescription> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration)
        {
            Type serviceType = contractDescription.ContractType;
            string serviceNamespace = serviceNamespaceBuilder.Build(serviceType);
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            string action = this.messageActionProvider.Get(contractDescription, operationConfiguration);

            MessageDescription outputMessage = new MessageDescription(action, MessageDirection.Output);
            outputMessage.Body.WrapperName = methodInfo.Name + "Response";
            outputMessage.Body.WrapperNamespace = serviceNamespace;
            //TODO: Abstraction
            outputMessage.Body.ReturnValue = new MessagePartDescription(methodInfo.Name + "Result", serviceNamespace);
            outputMessage.Body.ReturnValue.Type = methodInfo.ReturnType;

            return new [] {outputMessage};
        }
    }
}