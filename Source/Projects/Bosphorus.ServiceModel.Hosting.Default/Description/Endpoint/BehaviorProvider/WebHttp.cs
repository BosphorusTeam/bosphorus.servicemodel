using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint.BehaviorProvider
{
    public class WebHttp : IEndpointBehaviorProvider
    {
        public bool IsApplicable(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint)
        {
            bool isWebHttp = endpointConfiguration.BindingType == BindingType.WebHttp;
            bool isWebHttps = endpointConfiguration.BindingType == BindingType.WebHttps;
            bool isApplicable = isWebHttp || isWebHttps;

            return isApplicable;
        }

        public IEnumerable<IEndpointBehavior> Get(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint)
        {
            WebHttpBehavior behavior = new WebHttpBehavior();
            behavior.DefaultOutgoingRequestFormat = WebMessageFormat.Json;
            behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
            behavior.HelpEnabled = true;

            return new[] {behavior};
        }
    }
}