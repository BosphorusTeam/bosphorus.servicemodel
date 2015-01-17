using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;
using Bosphorus.ServiceModel.Hosting.Model.Configuration.Fluent;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class DemoServiceConfigurationProvider : AbstractServiceConfigurationProvider
    {
        public DemoServiceConfigurationProvider() 
            : base("Default")
        {
        }

        protected override IEnumerable<ServiceConfiguration> GetInternal()
        {
            ServiceConfiguration serviceConfiguration = ConfigureService.ProvidedBy<DemoService>().Exposed.Through(BindingType.WebHttp, BindingType.BasicHttp).Build();
            return new[] {serviceConfiguration};
        }
    }
}
