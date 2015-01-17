using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Port;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Addressing;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing
{
    public class DefaultUriBuilder : IUriBuilder
    {
        private const string UriFormat = "{0}://{1}{2}{3}:{4}/{5}/{6}.svc";
        private const string DomainName = "bosphorus.com"; //TODO: Domain name must be parameterized
        private readonly Environment environment;
        private readonly ServiceExposureMode serviceExposureMode;
        private readonly IBindingSchemePortProvider bindingSchemePortProvider;
        private readonly IApplicationNameExtractor applicationNameExtractor;
        private static readonly IDictionary<Environment, string> EnvironmentSpecifierMap;

        static DefaultUriBuilder()
        {
            EnvironmentSpecifierMap = new Dictionary<Environment, string>();
            EnvironmentSpecifierMap.Add(Environment.Development, "dev");
            EnvironmentSpecifierMap.Add(Environment.Test, "tst");
            EnvironmentSpecifierMap.Add(Environment.Production, string.Empty);
            EnvironmentSpecifierMap.Add(Environment.Local, string.Empty);
        }

        public DefaultUriBuilder(Environment environment, ServiceExposureMode serviceExposureMode, IBindingSchemePortProvider bindingSchemePortProvider, IApplicationNameExtractor applicationNameExtractor)
        {
            this.environment = environment;
            this.serviceExposureMode = serviceExposureMode;
            this.bindingSchemePortProvider = bindingSchemePortProvider;
            this.applicationNameExtractor = applicationNameExtractor;
        }

        public Uri Build(EndpointConfiguration endpointConfiguration)
        {
            BindingScheme bindingScheme = endpointConfiguration.BindingType.GetScheme();
            string environmentSpecifier = GetEnvironmentSpecifier(environment);
            int port = bindingSchemePortProvider.Get(bindingScheme);
            Type serviceType = endpointConfiguration.ServiceConfiguration.ServiceType;
            string applicationName = applicationNameExtractor.Extract(serviceType);
            string serviceTypeName = serviceType.Name;
            string baseUriString = string.Format(UriFormat, bindingScheme, serviceExposureMode, environmentSpecifier, DomainName, port, applicationName, serviceTypeName);
            Uri uri = new Uri(baseUriString);

            return uri;
        }

        private string GetEnvironmentSpecifier(Environment env)
        {
            if (!EnvironmentSpecifierMap.ContainsKey(env))
            {
                string message = string.Format("Environment {0} is not supported", env.Name);
                throw new InvalidOperationException(message);
            }

            string environmentSpecifier = EnvironmentSpecifierMap[env];

            return environmentSpecifier;
        }
    }
}
