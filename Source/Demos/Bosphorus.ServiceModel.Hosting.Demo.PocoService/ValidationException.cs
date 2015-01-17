using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class ValidationException : Exception
    {
        private readonly int errorCode;

        public ValidationException(int errorCode, string message)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        public int ErrorCode
        {
            get { return this.errorCode; }
        }
    }
}
