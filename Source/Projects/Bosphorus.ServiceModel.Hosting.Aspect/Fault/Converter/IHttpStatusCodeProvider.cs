using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter
{
    public interface IHttpStatusCodeProvider<in TException>
        where TException : Exception
    {
        HttpStatusCode Get(TException exception);
    }
}