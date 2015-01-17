using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Channels
{
    public class BasicHttpsBindingProvider : AbstractBindingProvider
    {
        public BasicHttpsBindingProvider(IServiceNamespaceBuilder serviceNamespaceBuilder) 
            : base(BindingType.BasicHttps, serviceNamespaceBuilder)
        {
        }

        protected override Binding GetBindingInstance(EndpointConfiguration endpointConfiguration)
        {
            return new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
        }
    }
}
