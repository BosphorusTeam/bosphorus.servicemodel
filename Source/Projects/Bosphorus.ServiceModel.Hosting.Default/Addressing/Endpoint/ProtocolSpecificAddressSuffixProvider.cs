using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint
{
    public class ProtocolSpecificAddressSuffixProvider : IEndpointAddressSuffixProvider
    {
        private static readonly IDictionary<BindingType, string> ProtocolSpecificSuffixes;

        static ProtocolSpecificAddressSuffixProvider()
        {
            ProtocolSpecificSuffixes = new Dictionary<BindingType, string>();
            ProtocolSpecificSuffixes.Add(BindingType.BasicHttp, "soap");
            ProtocolSpecificSuffixes.Add(BindingType.BasicHttps, "soap");
            ProtocolSpecificSuffixes.Add(BindingType.WebHttp, "rest");
            ProtocolSpecificSuffixes.Add(BindingType.WebHttps, "rest");
            ProtocolSpecificSuffixes.Add(BindingType.NetTcp, "nettcp");
        }
        public string Get(BindingType bindingType)
        {
            string protocolSpecificSuffix = ProtocolSpecificSuffixes[bindingType];

            return protocolSpecificSuffix;
        }
    }
}
