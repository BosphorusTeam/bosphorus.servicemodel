using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Addressing;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Default.Description.Operation;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Contract
{
    public class PocoServiceContractDescriptionProvider : IContractDescriptionProvider
    {
        private readonly IServiceNamespaceBuilder serviceNamespaceBuilder;
        private readonly IOperationDescriptionProvider operationDescriptionProvider;

        public PocoServiceContractDescriptionProvider(IServiceNamespaceBuilder serviceNamespaceBuilder, IOperationDescriptionProvider operationDescriptionProvider)
        {
            this.serviceNamespaceBuilder = serviceNamespaceBuilder;
            this.operationDescriptionProvider = operationDescriptionProvider;
        }

        public ContractDescription Get(ServiceConfiguration serviceConfiguration)
        {
            Type serviceType = serviceConfiguration.ServiceType;
            string serviceNamespace = serviceNamespaceBuilder.Build(serviceType);
            string contractName = string.Format("{0}Contract", serviceType.Name);
            ContractDescription contractDescription = new ContractDescription(contractName, serviceNamespace);
            contractDescription.ContractType = serviceType;

            IEnumerable<MethodInfo> methodInfos = GetExposedMethodInfos(serviceConfiguration);
            IEnumerable<OperationConfiguration> operationConfigurations = methodInfos.Select(mi => new OperationConfiguration { ExposedMethod = mi });
            IEnumerable<OperationDescription> operationDescriptions = operationConfigurations.Select(opc => this.operationDescriptionProvider.Get(contractDescription, opc));
            foreach (OperationDescription operationDescription in operationDescriptions)
            {
                contractDescription.Operations.Add(operationDescription);
            }

            return contractDescription;
        }

        private static IEnumerable<MethodInfo> GetExposedMethodInfos(ServiceConfiguration serviceConfiguration)
        {
            Type serviceType = serviceConfiguration.ServiceType;
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
            IEnumerable<MethodInfo> methodInfos = serviceType.GetMethods(bindingFlags);

            return methodInfos;
        }
    }
}