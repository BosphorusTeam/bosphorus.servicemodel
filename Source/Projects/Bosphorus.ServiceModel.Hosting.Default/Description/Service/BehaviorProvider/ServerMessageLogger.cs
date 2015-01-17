using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.DispatchMessageInspector.MessageLogging;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public class ServerMessageLogger : AbstractDispatchMessageInspector<IServerMessageLoggerProvider>
    {
        public ServerMessageLogger(IList<IServerMessageLoggerProvider> serverMessageLoggerProviders) 
            : base(serverMessageLoggerProviders)
        {
        }

        protected override bool IsApplicableInternal(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            return true;
        }
    }
}
