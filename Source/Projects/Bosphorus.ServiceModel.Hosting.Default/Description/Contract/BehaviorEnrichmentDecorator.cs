using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Contract.BehaviorProvider;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Contract
{
    public class BehaviorEnrichmentDecorator : IContractDescriptionProvider
    {
        private readonly IContractDescriptionProvider decorated;
        private readonly IList<IContractBehaviorProvider> contractBehaviorProviders;

        public BehaviorEnrichmentDecorator(IContractDescriptionProvider decorated, IList<IContractBehaviorProvider> contractBehaviorProviders)
        {
            this.decorated = decorated;
            this.contractBehaviorProviders = contractBehaviorProviders;
        }

        public ContractDescription Get(ServiceConfiguration serviceConfiguration)
        {
            ContractDescription contractDescription = this.decorated.Get(serviceConfiguration);

            foreach (IContractBehaviorProvider contractBehaviorProvider in this.contractBehaviorProviders)
            {
                if (!contractBehaviorProvider.IsApplicable(serviceConfiguration, contractDescription))
                {
                    continue;
                }

                IEnumerable<IContractBehavior> behaviors = contractBehaviorProvider.Get(serviceConfiguration, contractDescription);
                foreach (IContractBehavior behavior in behaviors)
                {
                    contractDescription.Behaviors.Add(behavior);
                }
            }

            return contractDescription;
        }
    }
}