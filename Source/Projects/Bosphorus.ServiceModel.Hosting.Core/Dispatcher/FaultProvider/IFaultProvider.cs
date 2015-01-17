using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.FaultProvider
{
    public interface IFaultProvider
    {
        bool CanProvideFault(Exception exception);

        Message Get(Exception error, MessageVersion version);
    }
}