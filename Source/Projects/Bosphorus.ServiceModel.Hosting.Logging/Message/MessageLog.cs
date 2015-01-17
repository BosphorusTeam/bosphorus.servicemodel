using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.Logging.Model;

namespace Bosphorus.ServiceModel.Hosting.Logging.Message
{
    public class MessageLog : AbstractLog
    {
        public virtual MessageDirection MessageDirection { get; set; }
    }
}