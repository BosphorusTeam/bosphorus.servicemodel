using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;
using Environment = Bosphorus.BootStapper.Common.Environment;
namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public class ServiceMetadata : IServiceBehaviorProvider
    {
        private readonly Environment environment;

        public ServiceMetadata(Environment environment)
        {
            this.environment = environment;
        }

        public bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            bool isApplicable = environment != Environment.Production;

            return isApplicable;
        }

        public IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            List<BindingScheme> distinctSchemes = serviceConfiguration.EndpointConfigurations.Select(endpointConfiguration => endpointConfiguration.BindingType.GetScheme()).Distinct().ToList();

            ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            bool hasHttp = distinctSchemes.Contains(BindingScheme.Http);
            if(hasHttp)
            { 
                serviceMetadataBehavior.HttpGetEnabled = true;
                serviceMetadataBehavior.HttpGetUrl = new Uri("", UriKind.Relative);
            }

            bool hasHttps = distinctSchemes.Contains(BindingScheme.Https);
            if (hasHttps)
            {
                serviceMetadataBehavior.HttpsGetEnabled = true;
                serviceMetadataBehavior.HttpsGetUrl = new Uri("", UriKind.Relative);
            }

            return new IServiceBehavior[] {serviceMetadataBehavior};
        }
    }
}
