using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Port
{
    public abstract class AbstractBindingSchemePortProvider : IBindingSchemePortProvider
    {
        private readonly IDictionary<BindingScheme, int> bindingSchemePortMap;

        protected AbstractBindingSchemePortProvider()
        {
            this.bindingSchemePortMap = this.BuildBindingSchemePortMap();
        }

        public int Get(BindingScheme bindingScheme)
        {
            if(!this.bindingSchemePortMap.ContainsKey(bindingScheme))
            {
                string message = string.Format("Binding scheme {0} is not supported", bindingScheme);
                throw new InvalidOperationException(message);
            }

            int port = this.bindingSchemePortMap[bindingScheme];

            return port;
        }

        protected abstract IDictionary<BindingScheme, int> BuildBindingSchemePortMap();
    }
}