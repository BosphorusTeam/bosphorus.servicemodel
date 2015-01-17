using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Channels
{
    internal class ConditionalBindingProvider : IBindingProvider
    {
        private readonly IList<IBindingProvider> items;

        public ConditionalBindingProvider(IList<IBindingProvider> items)
        {
            this.items = items;
        }

        public bool IsApplicable(EndpointConfiguration endpointConfiguration)
        {
            return true;
        }

        public Binding Get(EndpointConfiguration endpointConfiguration)
        {
            foreach (IBindingProvider item in this.items)
            {
                if (!item.IsApplicable(endpointConfiguration))
                {
                    continue;
                }

                IBindingProvider bindingProvider = item;
                Binding binding = bindingProvider.Get(endpointConfiguration);

                return binding;
            }

            //TODO: Typed exception
            throw new Exception("None of the conditions satisfied for ConditionalBindingProvider");
        }
    }
}
