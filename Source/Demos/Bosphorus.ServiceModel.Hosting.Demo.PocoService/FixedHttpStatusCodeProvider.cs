using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class FixedHttpStatusCodeProvider<TException> : IHttpStatusCodeProvider<TException> 
        where TException : Exception
    {
        private readonly HttpStatusCode fixedHttpStatusCode;

        public FixedHttpStatusCodeProvider(HttpStatusCode fixedHttpStatusCode)
        {
            this.fixedHttpStatusCode = fixedHttpStatusCode;
        }

        public HttpStatusCode Get(TException exception)
        {
            return this.fixedHttpStatusCode;
        }
    }
}
