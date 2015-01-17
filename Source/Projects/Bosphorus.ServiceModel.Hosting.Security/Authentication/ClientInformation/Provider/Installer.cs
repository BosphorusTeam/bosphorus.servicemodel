using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.Provider;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.ClientInformation.Provider
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IAuthenticationProvider<Model.Messaging.Request.ClientInformation>>()
                    .WithService
                    .FromInterface()
            );
        }
    }
}
