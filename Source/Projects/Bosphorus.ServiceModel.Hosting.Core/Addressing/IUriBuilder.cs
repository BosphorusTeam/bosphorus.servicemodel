using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Addressing
{
    public interface IUriBuilder
    {
        Uri Build(EndpointConfiguration endpointConfiguration);
    }
}