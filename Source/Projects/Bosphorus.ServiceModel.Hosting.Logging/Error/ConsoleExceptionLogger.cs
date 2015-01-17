using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Library.Logging.Core;

namespace Bosphorus.ServiceModel.Hosting.Logging.Error
{
    public class ConsoleExceptionLogger : ILogger<ExceptionLog>
    {
        public void Log(ExceptionLog log)
        {
            Exception loggedException = log.Exception;
            for (Exception exception = loggedException; exception != null; exception = exception.InnerException)
            {
                this.LogException(exception);
            }
        }

        private void LogException(Exception error)
        {
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(error.GetType().FullName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Error: {0}", error.Message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stack Trace:");
            Console.WriteLine(error.StackTrace);
            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
