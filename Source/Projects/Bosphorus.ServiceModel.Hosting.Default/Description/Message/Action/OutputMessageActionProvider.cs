using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Addressing;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Message.Action
{
    public class OutputMessageActionProvider : IMessageActionProvider
    {
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;

        public OutputMessageActionProvider(IServiceNamespaceBuilder serviceNamespaceBuilder)
        {
            this.serviceNamespaceBuilder = serviceNamespaceBuilder;
        }

        public string Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration)
        {
            Type serviceType = contractDescription.ContractType;
            string serviceNamespace = serviceNamespaceBuilder.Build(serviceType);
            UriBuilder uriBuilder = new UriBuilder(serviceNamespace);
            uriBuilder.Port = -1;
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            string path = string.Format("{0}/{1}Response", serviceType.Name, methodInfo.Name);
            uriBuilder.Path = path;
            string action = uriBuilder.ToString();

            return action;
        }
    }
}