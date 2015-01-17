using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.ErrorHandler;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public class ErrorHandler : IServiceBehaviorProvider
    {
        private readonly IList<IErrorHandlerProvider> errorHandlerProviders;

        public ErrorHandler(IList<IErrorHandlerProvider> errorHandlerProviders)
        {
            this.errorHandlerProviders = errorHandlerProviders;
        }

        public bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            bool isApplicable = this.errorHandlerProviders.Count > 0;
            
            return isApplicable;
        }

        public IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            List<IServiceBehavior> behaviors = new List<IServiceBehavior>();
            foreach (IErrorHandlerProvider errorHandlerProvider in this.errorHandlerProviders)
            {
                ErrorHandlerBehavior behavior = new ErrorHandlerBehavior(errorHandlerProvider);
                behaviors.Add(behavior);
            }

            return behaviors;
        }
    }
}