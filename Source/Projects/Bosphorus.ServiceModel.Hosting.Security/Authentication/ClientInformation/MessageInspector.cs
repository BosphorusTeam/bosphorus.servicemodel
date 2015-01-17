using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Extraction;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.Provider;
using Bosphorus.Serialization.Core;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation
{
    //TODO: Implementation must be moved
    public class MessageInspector : IDispatchMessageInspector
    {
        private const string ClientInformationHttpHeaderName = "ClientInformation";
        private const string ContextStorageKey = "ClientInformation";
        private readonly IContextStorage contextStorage;
        private readonly JsonSerializer jsonSerializer;
        private readonly IAuthenticationProvider<Model.Messaging.Request.ClientInformation> authenticationProvider;

        public MessageInspector(IContextStorage contextStorage, JsonSerializer jsonSerializer, IAuthenticationProvider<Model.Messaging.Request.ClientInformation> authenticationProvider)
        {
            this.contextStorage = contextStorage;
            this.jsonSerializer = jsonSerializer;
            this.authenticationProvider = authenticationProvider;
            this.authenticationProvider = authenticationProvider;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HttpRequestMessageProperty httpRequestMessageProperty = this.contextStorage.Get<HttpRequestMessageProperty>(HttpRequestMessageProperty.Name);
            if (httpRequestMessageProperty == null)
            {
                //TODO:throw new Exception
                return null;
            }

            string headerValue = httpRequestMessageProperty.Headers.Get(ClientInformationHttpHeaderName);
            if (headerValue == null)
            {
                //TODO:throw new Exception
                return null;
            }

            Model.Messaging.Request.ClientInformation clientInformation = this.jsonSerializer.Deserialize<Model.Messaging.Request.ClientInformation>(headerValue);
            
            AuthenticationResult authenticationResult = this.authenticationProvider.Authenticate(clientInformation);
            bool authenticated = authenticationResult.Authenticated;
            if (!authenticated)
            {
                AuthenticationErrorModel errorModel = new AuthenticationErrorModel();
                errorModel.Code = 405;
                errorModel.Msg = authenticationResult.Message;
                throw new WebFaultException<AuthenticationErrorModel>(errorModel, HttpStatusCode.MethodNotAllowed);
            }

            this.contextStorage.Add(ContextStorageKey, clientInformation);

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}
