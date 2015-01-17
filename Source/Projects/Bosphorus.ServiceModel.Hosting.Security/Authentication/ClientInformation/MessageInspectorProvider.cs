using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Extraction;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.Provider;
using Bosphorus.Serialization.Core;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation
{
    public class MessageInspectorProvider : IClientInformationAuthenticationMessageInspectorProvider
    {
        private readonly IContextStorage contextStorage;
        private readonly JsonSerializer jsonSerializer;
        private readonly IAuthenticationProvider<Model.Messaging.Request.ClientInformation> authenticationProvider;

        public MessageInspectorProvider(IContextStorage contextStorage, JsonSerializer jsonSerializer, IAuthenticationProvider<Model.Messaging.Request.ClientInformation> authenticationProvider)
        {
            this.contextStorage = contextStorage;
            this.jsonSerializer = jsonSerializer;
            this.authenticationProvider = authenticationProvider;
        }

        public IDispatchMessageInspector Get(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            return new MessageInspector(this.contextStorage, this.jsonSerializer, this.authenticationProvider);
        }
    }
}
