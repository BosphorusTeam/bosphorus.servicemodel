using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Default
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<PocoServiceHostProvider>(),

                Component
                    .For<ServiceBehaviorEnrichmentDecorator>()
                    .DependsOn(
                        Dependency.OnComponent<IServiceHostProvider, PocoServiceHostProvider>()
                    ),

                Component
                     .For<IServiceHostProvider>()
                     .ImplementedBy<MetadataExchangeEndpointEnrichmentDecorator>()
                     .DependsOn(
                        Dependency.OnComponent<IServiceHostProvider, ServiceBehaviorEnrichmentDecorator>()
                     )
            );
        }
    }
}
