using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<PocoServiceOperationDescriptionProvider>(),

                Component
                    .For<IOperationDescriptionProvider>()
                    .ImplementedBy<BehaviorEnrichmentDecorator>()
                    .DependsOn(
                        Dependency.OnComponent<IOperationDescriptionProvider, PocoServiceOperationDescriptionProvider>()
                    )
            );
        }
    }
}
