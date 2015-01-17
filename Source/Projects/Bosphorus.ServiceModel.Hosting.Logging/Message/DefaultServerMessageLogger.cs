using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using Bosphorus.Library.Logging.Core.Facade;
using Bosphorus.Logging.Model;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher.MessageLogger;
using WcfMessage = System.ServiceModel.Channels.Message;

namespace Bosphorus.ServiceModel.Hosting.Logging.Message
{
    public class DefaultServerMessageLogger : IServerMessageLogger
    {
        private readonly Logger logger;

        public DefaultServerMessageLogger(Logger logger)
        {
            this.logger = logger;
        }

        public void LogAfterReceiveRequest(WcfMessage clonedMessage, IClientChannel channel, InstanceContext instanceContext)
        {
            MessageLog messageLog = new MessageLog();
            messageLog.Level = LogLevel.Debug;
            messageLog.MessageDirection = MessageDirection.Input;
            string messageAsString = this.GetMessageAsString(clonedMessage);
            messageLog.Message = messageAsString;
            logger.Log(messageLog);
        }

        public void LogBeforeSendReply(WcfMessage clonedMessage, object correlationState)
        {
            MessageLog messageLog = new MessageLog();
            messageLog.Level = LogLevel.Debug;
            messageLog.MessageDirection = MessageDirection.Output;
            string messageAsString = this.GetMessageAsString(clonedMessage);
            messageLog.Message = messageAsString;
            logger.Log(messageLog);
        }

        private string GetMessageAsString(WcfMessage clonedMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using(XmlWriter writer = new XmlTextWriter(new StringWriter(stringBuilder)))
            { 
                clonedMessage.WriteMessage(writer);
            }

            string messageAsString = stringBuilder.ToString();
            return messageAsString;
        }
    }
}
