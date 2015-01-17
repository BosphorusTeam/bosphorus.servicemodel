using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.FaultProvider;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher
{
    public class FaultProviderErrorHandler : IErrorHandler
    {
        private readonly IList<IFaultProvider> faultProviders;

        public FaultProviderErrorHandler(IList<IFaultProvider> faultProviders)
        {
            this.faultProviders = faultProviders;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            IFaultProvider faultProvider = faultProviders.FirstOrDefault(fp => fp.CanProvideFault(error));
            if (faultProvider == null)
            {
                return;
            }

            Message faultMessage = faultProvider.Get(error, version);
            fault = faultMessage;
        }

        public bool HandleError(Exception error)
        {
            bool handleError = faultProviders.Any(fp => fp.CanProvideFault(error));

            return handleError;
        }
    }
}
