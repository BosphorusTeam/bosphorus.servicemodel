using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IServiceConfigurationProvider>()
                    .WithService
                    .FromInterface(),


                Component
                    .For<IServiceConfigurationProvider>()
                    .ImplementedBy<CompositeServiceConfigurationProvider>()
                    .IsDefault()
            );
        }
    }
}
