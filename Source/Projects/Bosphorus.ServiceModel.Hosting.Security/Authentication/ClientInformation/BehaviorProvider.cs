using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Default.Description.Endpoint.BehaviorProvider;
using Bosphorus.ServiceModel.Hosting.Model;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation
{
    public class BehaviorProvider : AbstractDispatchMessageInspector<IClientInformationAuthenticationMessageInspectorProvider>
    {
        public BehaviorProvider(IList<IClientInformationAuthenticationMessageInspectorProvider> dispatchMessageInspectorProviders) 
            : base(dispatchMessageInspectorProviders)
        {
        }

        protected override bool IsApplicableInternal(ContractDescription contractDescription, EndpointConfiguration endpointConfiguration, Uri baseAddress, ServiceEndpoint serviceEndpoint)
        {
            bool isApplicable = endpointConfiguration.BindingType == BindingType.WebHttp;

            return isApplicable;
        }
    }
}
