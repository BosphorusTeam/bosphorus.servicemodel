using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Endpoint
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IEndpointAddressSuffixProvider>()
                    .ImplementedBy<ProtocolSpecificAddressSuffixProvider>(),

                Component
                    .For<IEndpointAddressBuilder>()
                    .ImplementedBy<DefaultEndpointAddressBuilder>()
            );
        }
    }
}
