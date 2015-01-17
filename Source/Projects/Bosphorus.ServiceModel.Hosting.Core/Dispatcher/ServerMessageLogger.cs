using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.MessageLogger;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher
{
    public class ServerMessageLogger : IDispatchMessageInspector
    {
        private readonly IList<IServerMessageLogger> messageLoggers;

        public ServerMessageLogger(IList<IServerMessageLogger> messageLoggers)
        {
            this.messageLoggers = messageLoggers;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (messageLoggers.Count == 0)
            {
                return null;
            }

            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            foreach (IServerMessageLogger messageLogger in messageLoggers)
            {
                Message clonedMessage = buffer.CreateMessage();
                messageLogger.LogAfterReceiveRequest(clonedMessage, channel, instanceContext);
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (messageLoggers.Count == 0)
            {
                return;
            }

            //TODO: CreateBufferedCopy veya CreateMessage HTML içerikli help sayfasını bozuyor
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);

            reply = buffer.CreateMessage();
            foreach (IServerMessageLogger messageLogger in messageLoggers)
            {
                Message clonedMessage = buffer.CreateMessage();
                messageLogger.LogBeforeSendReply(clonedMessage, correlationState);
            }
        }
    }
}
