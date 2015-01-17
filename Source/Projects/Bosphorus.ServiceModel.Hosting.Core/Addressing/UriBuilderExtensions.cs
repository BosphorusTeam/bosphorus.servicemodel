using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Addressing
{
    public static class UriBuilderExtensions
    {
        public static IEnumerable<Uri> Build(this IUriBuilder extended, ServiceConfiguration serviceConfiguration)
        {
            IEnumerable<Uri> distinctUris = serviceConfiguration.EndpointConfigurations.Select(endpointConfiguration => extended.Build(endpointConfiguration)).Distinct();

            return distinctUris;
        }
    }
}
