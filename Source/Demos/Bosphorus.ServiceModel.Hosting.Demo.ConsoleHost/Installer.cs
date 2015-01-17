using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Demo.ConsoleHost
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(Component.For<ServiceExposureMode>().Instance(ServiceExposureMode.Intranet));
        }
    }
}
