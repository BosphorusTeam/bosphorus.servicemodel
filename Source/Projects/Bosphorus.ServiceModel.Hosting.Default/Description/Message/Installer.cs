using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Default.Description.Message.Action;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Message
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<InputMessageDescriptionProvider>()
                    .DependsOn(
                        Dependency.OnComponent<IMessageActionProvider, InputMessageActionProvider>()
                    ),

                Component
                    .For<OutputMessageDescriptionProvider>()
                    .DependsOn(
                        Dependency.OnComponent<IMessageActionProvider, OutputMessageActionProvider>()
                    ),  

                Component
                    .For<IMessageDescriptionProvider>()
                    .ImplementedBy<CompositeMessageDescriptionProvider>()
                    .DependsOn(
                        Dependency.OnComponentCollection<IMessageDescriptionProvider[]>(
                            typeof(InputMessageDescriptionProvider), 
                            typeof(OutputMessageDescriptionProvider)
                        )
                    )
            );
        }
    }
}
