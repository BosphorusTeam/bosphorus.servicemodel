using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Library.Logging.Core;

namespace Bosphorus.ServiceModel.Hosting.Logging.Message
{
    public class ConsoleMessageLogger : ILogger<MessageLog>
    {
        public void Log(MessageLog log)
        {
            Console.WriteLine(log.Message);
        }
    }
}
