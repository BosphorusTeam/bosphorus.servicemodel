using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.MessageLogger
{
    public interface IServerMessageLogger
    {
        void LogAfterReceiveRequest(Message clonedMessage, IClientChannel channel, InstanceContext instanceContext);
        void LogBeforeSendReply(Message clonedMessage, object correlationState);
    }
}