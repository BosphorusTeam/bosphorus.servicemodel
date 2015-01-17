using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter
{
    public abstract class AbstractExceptionWebFaultConverter<TException> : AbstractExceptionFaultConverter<TException> 
        where TException : Exception
    {
        private readonly IHttpStatusCodeProvider<TException> httpStatusCodeProvider;

        protected AbstractExceptionWebFaultConverter(IHttpStatusCodeProvider<TException> httpStatusCodeProvider)
        {
            this.httpStatusCodeProvider = httpStatusCodeProvider;
        }

        protected sealed override FaultException Convert(TException exception)
        {
            HttpStatusCode httpStatusCode = this.httpStatusCodeProvider.Get(exception);
            FaultException webFaultException = this.Convert(exception, httpStatusCode);

            return webFaultException;
        }

        protected abstract FaultException Convert(TException exception, HttpStatusCode httpStatusCode);
    }
}