using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Message
{
    public class CompositeMessageDescriptionProvider : IMessageDescriptionProvider
    {
        private readonly IMessageDescriptionProvider[] items;

        public CompositeMessageDescriptionProvider(params IMessageDescriptionProvider[] items)
        {
            this.items = items;
        }

        public IEnumerable<MessageDescription> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration)
        {
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            List<IEnumerable<MessageDescription>> messageDescriptions = new List<IEnumerable<MessageDescription>>();
            foreach (IMessageDescriptionProvider messageDescriptionProvider in this.items)
            {
                IEnumerable<MessageDescription> descriptions = messageDescriptionProvider.Get(contractDescription, operationConfiguration);
                messageDescriptions.Add(descriptions);
            }

            IEnumerable<MessageDescription> result = messageDescriptions.SelectMany(x => x);
            return result;
        }
    }
}