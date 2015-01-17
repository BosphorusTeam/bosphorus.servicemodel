using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.DispatchMessageInspector
{
    public interface IDispatchMessageInspectorProvider
    {
        IDispatchMessageInspector Get(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase);
    }
}