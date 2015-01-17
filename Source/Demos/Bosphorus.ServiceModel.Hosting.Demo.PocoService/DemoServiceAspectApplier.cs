using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault;
using Bosphorus.Aspect.Core.Aspect.Applier;
using Castle.Core;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class DemoServiceAspectApplier : IServiceAspectApplier
    {
        public bool IsApplicable(ComponentModel model)
        {
            bool isApplicable = model.Services.Contains(typeof(DemoService));

            return isApplicable;
        }

        public void Apply(ComponentModel model, ServiceAspectRegistry serviceAspectRegistry)
        {
            serviceAspectRegistry.Register(typeof(ExceptionFaultConversionAspect<>));
        }
    }
}
