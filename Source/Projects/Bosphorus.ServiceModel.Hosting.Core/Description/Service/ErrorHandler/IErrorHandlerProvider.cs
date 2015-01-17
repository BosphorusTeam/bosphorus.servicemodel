using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.ErrorHandler
{
    public interface IErrorHandlerProvider
    {
        IErrorHandler Get(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase);
    }
}