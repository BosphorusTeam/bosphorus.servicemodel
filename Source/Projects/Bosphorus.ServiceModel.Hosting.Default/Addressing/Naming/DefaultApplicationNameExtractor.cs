using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming
{
    public class DefaultApplicationNameExtractor : IApplicationNameExtractor
    {
        public string Extract(Type serviceType)
        {
            string serviceNamespace = serviceType.Namespace;
            string[] serviceNamespaceParts = serviceNamespace.Split('.');
            string applicationName = serviceNamespaceParts[2];

            return applicationName;
        }
    }
}
