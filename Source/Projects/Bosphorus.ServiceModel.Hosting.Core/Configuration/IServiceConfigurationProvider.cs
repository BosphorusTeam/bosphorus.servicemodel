using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration
{
    public interface IServiceConfigurationProvider
    {
        IEnumerable<ServiceConfiguration> Get(string serviceGroupAlias);
    }
}