using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Endpoint.DispatchMessageInspector
{
    public interface IDispatchMessageInspectorProvider
    {
        IDispatchMessageInspector Get(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher);
    }
}