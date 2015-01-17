using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using Bosphorus.ServiceModel.Hosting.Aspect.Fault.Converter;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class ValidationExceptionWebFaultConverter : AbstractExceptionWebFaultConverter<ValidationException>
    {
        public ValidationExceptionWebFaultConverter(IHttpStatusCodeProvider<ValidationException> httpStatusCodeProvider) 
            : base(httpStatusCodeProvider)
        {
        }

        protected override FaultException Convert(ValidationException exception, HttpStatusCode httpStatusCode)
        {
            ErrorModel detail = new ErrorModel();
            detail.Code = exception.ErrorCode;
            detail.Message = exception.Message;
            WebFaultException<ErrorModel> webFaultException = new WebFaultException<ErrorModel>(detail, httpStatusCode);

            return webFaultException;
        }
    }
}
