using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Configuration.Core;

namespace Bosphorus.ServiceModel.Hosting.Default.Configuration
{
    public class HostingConfiguration : AbstractConfiguration
    {
        public HostingConfiguration(IParameterProvider parameterProvider) 
            : base("ServiceModel.Hosting", parameterProvider)
        {
        }

        public string ServiceGroupAlias
        {
            get { return this.GetValue<string>("ServiceModel.Hosting.ServiceGroupAlias"); }
        }
    }
}