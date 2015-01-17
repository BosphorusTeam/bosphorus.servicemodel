using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.FaultProvider
{
    //TODO: Work on this class and set to public
    internal class WebFaultProvider : IFaultProvider
    {
        private readonly IWebFaultMessageBodyProvider webFaultMessageBodyProvider;
        private readonly IWebFaultHttpStatusCodeProvider webFaultHttpStatusCodeProvider;

        public WebFaultProvider(IWebFaultMessageBodyProvider webFaultMessageBodyProvider, IWebFaultHttpStatusCodeProvider webFaultHttpStatusCodeProvider)
        {
            this.webFaultMessageBodyProvider = webFaultMessageBodyProvider;
            this.webFaultHttpStatusCodeProvider = webFaultHttpStatusCodeProvider;
        }

        public bool CanProvideFault(Exception exception)
        {
            return webFaultMessageBodyProvider.CanProvideBody(exception);
        }

        public Message Get(Exception error, MessageVersion version)
        {
            object faultBody = webFaultMessageBodyProvider.Get(error);
            Message fault = Message.CreateMessage(version, string.Empty, faultBody, new DataContractJsonSerializer(faultBody.GetType()));
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Json));

            HttpResponseMessageProperty httpResponseMessageProperty = new HttpResponseMessageProperty();
            httpResponseMessageProperty.StatusCode = webFaultHttpStatusCodeProvider.Get(error, faultBody);
            httpResponseMessageProperty.Headers[HttpResponseHeader.ContentType] = "application/json; charset=utf-8";
            fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponseMessageProperty);

            return fault;
        }
    }

    public interface IWebFaultHttpStatusCodeProvider
    {
        HttpStatusCode Get(Exception exception, object faultBody);
    }

    public interface IWebFaultMessageBodyProvider
    {
        bool CanProvideBody(Exception exception);
        object Get(Exception exception);
    }
}
