using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Extraction
{
    public class IncomingMessagePropertiesStorage : IContextStorage
    {
        public void Add(string key, object value)
        {
            OperationContext.Current.IncomingMessageProperties.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            bool containsKey = OperationContext.Current.IncomingMessageProperties.ContainsKey(key);

            return containsKey;
        }

        public void Remove(string key)
        {
            OperationContext.Current.IncomingMessageProperties.Remove(key);
        }

        public object Get(string key)
        {
            bool containsKey = OperationContext.Current.IncomingMessageProperties.ContainsKey(key);
            if (!containsKey)
            {
                return null;
            }

            object value = OperationContext.Current.IncomingMessageProperties[key];

            return value;
        }
    }
}