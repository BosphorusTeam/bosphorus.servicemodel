using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.Library.Logging.Core.Facade;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.ErrorHandler;

namespace Bosphorus.ServiceModel.Hosting.Logging.Error
{
    public class LoggingErrorHandlerProvider : IErrorHandlerProvider
    {
        private readonly Logger logger;

        public LoggingErrorHandlerProvider(Logger logger)
        {
            this.logger = logger;
        }

        public IErrorHandler Get(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            return new LoggingErrorHandler(logger);
        }
    }
}
