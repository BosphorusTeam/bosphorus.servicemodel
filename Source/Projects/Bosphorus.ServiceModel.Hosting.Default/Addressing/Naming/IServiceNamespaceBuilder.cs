using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming
{
    public interface IServiceNamespaceBuilder
    {
        string Build(Type serviceType);
    }
}
