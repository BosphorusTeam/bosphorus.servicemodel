using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.ErrorHandler;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service
{
    public class ErrorHandlerBehavior : IServiceBehavior
    {
        private readonly IErrorHandlerProvider errorHandlerProvider;

        public ErrorHandlerBehavior(IErrorHandlerProvider errorHandlerProvider)
        {
            this.errorHandlerProvider = errorHandlerProvider;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                IErrorHandler errorHandler = this.errorHandlerProvider.Get(serviceDescription, serviceHostBase);
                dispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}
