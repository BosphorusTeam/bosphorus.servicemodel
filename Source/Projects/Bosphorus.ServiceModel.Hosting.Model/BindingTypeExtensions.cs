using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model
{
    public static class BindingTypeExtensions
    {
        public static BindingScheme GetScheme(this BindingType extended)
        {
            switch (extended)
            {
                case BindingType.BasicHttp:
                case BindingType.WebHttp:
                    return BindingScheme.Http;
                case BindingType.BasicHttps:
                case BindingType.WebHttps:
                    return BindingScheme.Https;
                case BindingType.NetTcp:
                    return BindingScheme.NetTcp;
                default:
                    throw new ArgumentOutOfRangeException("extended");
            }
        }
    }
}
