using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.FaultProvider;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.ErrorHandler
{
    public class FaultProvider : IErrorHandlerProvider
    {
        private readonly IList<IFaultProvider> faultProviders;

        public FaultProvider(IList<IFaultProvider> faultProviders)
        {
            this.faultProviders = faultProviders;
        }

        public IErrorHandler Get(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            return new FaultProviderErrorHandler(faultProviders);
        }
    }
}
