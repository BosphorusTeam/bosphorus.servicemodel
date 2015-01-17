using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter;
using Castle.DynamicProxy;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault
{
    public class ExceptionFaultConversionAspect<TService> : IExceptionFaultConversionAspect<TService>
    {
        private readonly IExceptionFaultConverter exceptionFaultConverter;

        public ExceptionFaultConversionAspect(IExceptionFaultConverter exceptionFaultConverter)
        {
            this.exceptionFaultConverter = exceptionFaultConverter;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception exception)
            {
                FaultException faultException = this.exceptionFaultConverter.Convert(exception);

                throw faultException;
            }
        }
    }
}
