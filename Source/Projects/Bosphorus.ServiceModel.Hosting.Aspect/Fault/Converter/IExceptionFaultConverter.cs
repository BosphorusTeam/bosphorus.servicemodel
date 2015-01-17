using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter
{
    public interface IExceptionFaultConverter
    {
        bool IsApplicable(Exception exception);

        FaultException Convert(Exception exception);
    }
}