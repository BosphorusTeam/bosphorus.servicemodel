using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.MessageLogger;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Endpoint.DispatchMessageInspector.MessageLogging
{
    public class ServerMessageLoggerProvider : IServerMessageLoggerProvider
    {
        private readonly IList<IServerMessageLogger> serverMessageLoggers;

        public ServerMessageLoggerProvider(IList<IServerMessageLogger> serverMessageLoggers)
        {
            this.serverMessageLoggers = serverMessageLoggers;
        }

        public IDispatchMessageInspector Get(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            return new ServerMessageLogger(this.serverMessageLoggers);
        }
    }
}