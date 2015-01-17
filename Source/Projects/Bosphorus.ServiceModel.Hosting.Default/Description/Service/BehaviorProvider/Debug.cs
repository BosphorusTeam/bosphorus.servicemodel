using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.BootStapper.Common;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public class Debug : IServiceBehaviorProvider
    {
        private readonly Perspective perspective;

        public Debug(Perspective perspective)
        {
            this.perspective = perspective;
        }

        public bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            bool isApplicable = this.perspective == Perspective.Debug;

            return isApplicable;
        }

        public IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            ServiceDebugBehavior behavior = new ServiceDebugBehavior();
            behavior.IncludeExceptionDetailInFaults = true;
            behavior.HttpHelpPageUrl = new Uri("help", UriKind.Relative);
            
            return new[] {behavior};
        }
    }
}
