using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Default.Configuration
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<HostingConfiguration>(),

                Component
                    .For<IServiceConfigurationRepository>()
                    .ImplementedBy<DefaultServiceConfigurationRepository>()
            );
        }
    }
}
