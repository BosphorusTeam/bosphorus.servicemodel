using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Default.Addressing.Port;
using Bosphorus.ServiceModel.Hosting.Model;

namespace Bosphorus.ServiceModel.Hosting.Demo.ConsoleHost
{
    public class BindingSchemePortMapProvider : AbstractBindingSchemePortProvider
    {
        protected override IDictionary<BindingScheme, int> BuildBindingSchemePortMap()
        {
            IDictionary<BindingScheme, int> map = new Dictionary<BindingScheme, int>();
            map.Add(BindingScheme.Http, 10000);
            map.Add(BindingScheme.Https, 10002);
            map.Add(BindingScheme.NetTcp, 10001);
            return map;
        }
    }
}
