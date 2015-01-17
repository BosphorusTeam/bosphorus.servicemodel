using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Bosphorus.Library.Logging.Core.Facade;
using Bosphorus.Logging.Model;
using WcfMessage = System.ServiceModel.Channels.Message;

namespace Bosphorus.ServiceModel.Hosting.Logging.Error
{
    public class LoggingErrorHandler : IErrorHandler
    {
        private readonly Logger logger;

        public LoggingErrorHandler(Logger logger)
        {
            this.logger = logger;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref WcfMessage fault)
        {
            
        }

        public bool HandleError(Exception error)
        {
            ExceptionLog logModel = new ExceptionLog();
            logModel.DateTime = DateTime.Now;
            logModel.Id = Guid.NewGuid();
            logModel.Level = LogLevel.Error;
            logModel.Exception = error;
            logger.Log(logModel);

            //for (Exception exception = error; exception != null; exception = exception.InnerException)
            //{
            //    this.LogException(exception);
            //}

            return false;
        }

        //private void LogException(Exception error)
        //{
        //    ConsoleColor defaultForegroundColor = Console.ForegroundColor;
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(error.GetType().FullName);
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine();
        //    Console.WriteLine("Error: {0}", error.Message);
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("Stack Trace:");
        //    Console.WriteLine(error.StackTrace);
        //    Console.ForegroundColor = defaultForegroundColor;
        //}
    }
}
