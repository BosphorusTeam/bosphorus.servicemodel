using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming
{
    public class DefaultServiceNamespaceBuilder : IServiceNamespaceBuilder
    {
        private readonly IApplicationNameExtractor applicationNameExtractor;
        private const string RootNamespace = "http://service.bosphorus.com/"; //TODO: Must be parameterized

        public DefaultServiceNamespaceBuilder(IApplicationNameExtractor applicationNameExtractor)
        {
            this.applicationNameExtractor = applicationNameExtractor;
        }

        public string Build(Type serviceType)
        {
            string applicationName = this.applicationNameExtractor.Extract(serviceType);

            UriBuilder uriBuilder = new UriBuilder(RootNamespace);
            uriBuilder.Port = -1;
            uriBuilder.Path = applicationName;

            return uriBuilder.ToString();
        }
    }
}