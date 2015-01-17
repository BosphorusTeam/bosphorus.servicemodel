using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Logging.Model;

namespace Bosphorus.ServiceModel.Hosting.Logging.Error
{
    public class ExceptionLog : AbstractLog
    {
        public Exception Exception { get; set; }
    }
}
