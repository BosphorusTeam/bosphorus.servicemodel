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
    public class InputMessageDescriptionProvider : IMessageDescriptionProvider
    {
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;
        private readonly IMessageActionProvider messageActionProvider;

        public InputMessageDescriptionProvider(IServiceNamespaceBuilder serviceNamespaceBuilder, IMessageActionProvider messageActionProvider)
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

            MessageDescription inputMessage = new MessageDescription(action, MessageDirection.Input);
            inputMessage.Body.WrapperNamespace = serviceNamespace;
            inputMessage.Body.WrapperName = methodInfo.Name;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                MessagePartDescription part = new MessagePartDescription(parameter.Name, serviceNamespace);
                part.Type = parameter.ParameterType;
                part.Index = i;
                inputMessage.Body.Parts.Add(part);
            }

            return new [] {inputMessage};
        }
    }
}