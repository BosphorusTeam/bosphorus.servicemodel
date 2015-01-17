using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Extraction
{
    public interface IContextStorage
    {
        void Add(string key, object value);

        bool ContainsKey(string key);
        
        void Remove(string key);

        object Get(string key);
    }
}