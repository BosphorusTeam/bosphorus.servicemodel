using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter
{
    public abstract class AbstractExceptionFaultConverter<TException> : IExceptionFaultConverter
        where TException : Exception
    {
        public bool IsApplicable(Exception exception)
        {
            bool isApplicable = typeof(TException) == exception.GetType();

            return isApplicable;
        }

        public FaultException Convert(Exception exception)
        {
            TException typedException = exception as TException;
            FaultException faultException = this.Convert(typedException);

            return faultException;
        }

        protected abstract FaultException Convert(TException exception);
    }
}