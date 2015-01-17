using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Operation.BehaviorProvider;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation
{
    public class BehaviorEnrichmentDecorator : IOperationDescriptionProvider
    {
        private readonly IOperationDescriptionProvider decorated;
        private readonly IList<IOperationBehaviorProvider> operationBehaviorProviders;

        public BehaviorEnrichmentDecorator(IOperationDescriptionProvider decorated, IList<IOperationBehaviorProvider> operationBehaviorProviders)
        {
            this.decorated = decorated;
            this.operationBehaviorProviders = operationBehaviorProviders;
        }

        public OperationDescription Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration)
        {
            OperationDescription operationDescription = this.decorated.Get(contractDescription, operationConfiguration);

            foreach (IOperationBehaviorProvider operationBehaviorProvider in this.operationBehaviorProviders)
            {
                if (!operationBehaviorProvider.IsApplicable(contractDescription, operationConfiguration, operationDescription))
                {
                    continue;
                }

                IEnumerable<IOperationBehavior> behaviors = operationBehaviorProvider.Get(contractDescription, operationConfiguration, operationDescription);
                foreach (IOperationBehavior behavior in behaviors)
                {
                    operationDescription.Behaviors.Add(behavior);
                }
            }

            return operationDescription;
        }
    }
}
