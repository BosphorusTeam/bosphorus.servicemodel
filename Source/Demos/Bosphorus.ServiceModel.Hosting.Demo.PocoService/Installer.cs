using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<DemoService>(),

                Component
                    .For(typeof(IHttpStatusCodeProvider<>))
                    .ImplementedBy(typeof(FixedHttpStatusCodeProvider<>))
                    .DependsOn(
                        Dependency.OnValue<HttpStatusCode>(HttpStatusCode.MethodNotAllowed)
                    )
            );
        }
    }
}
