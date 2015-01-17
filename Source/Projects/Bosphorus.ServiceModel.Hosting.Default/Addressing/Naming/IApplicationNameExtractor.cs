using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Naming
{
    public interface IApplicationNameExtractor
    {
        string Extract(Type serviceType);
    }
}