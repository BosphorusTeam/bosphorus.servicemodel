using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter
{
    internal class CompositeExceptionFaultConverter : IExceptionFaultConverter
    {
        private readonly IList<IExceptionFaultConverter> items;

        public CompositeExceptionFaultConverter(IList<IExceptionFaultConverter> items)
        {
            this.items = items;
        }

        public bool IsApplicable(Exception exception)
        {
            bool anyApplicable = this.items.Any(item => item.IsApplicable(exception));

            return anyApplicable;
        }

        public FaultException Convert(Exception exception)
        {
            IExceptionFaultConverter builder = this.items.First(item => item.IsApplicable(exception));
            FaultException faultException = builder.Convert(exception);

            return faultException;
        }
    }
}