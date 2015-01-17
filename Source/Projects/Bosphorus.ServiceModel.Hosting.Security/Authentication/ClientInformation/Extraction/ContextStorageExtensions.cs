using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Extraction
{
    public static class ContextStorageExtensions
    {
        public static TValue Get<TValue>(this IContextStorage extended, string key)
            where TValue : class
        {
            if (!extended.ContainsKey(key))
            {
                return null;
            }

            TValue value = extended.Get(key) as TValue;

            return value;
        }
    }
}
