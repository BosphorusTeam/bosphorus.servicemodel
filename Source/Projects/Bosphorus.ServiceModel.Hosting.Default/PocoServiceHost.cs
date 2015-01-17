using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Default
{
    public class PocoServiceHost : ServiceHost
    {
        public PocoServiceHost(Type serviceType, string serviceNamespace, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.Description.Namespace = serviceNamespace;
        }
    }
}
