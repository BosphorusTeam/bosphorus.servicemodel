using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Aspect.Exception;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault
{
    public interface IExceptionFaultConversionAspect<TService> : IExceptionAspect<TService>
    {
    }
}