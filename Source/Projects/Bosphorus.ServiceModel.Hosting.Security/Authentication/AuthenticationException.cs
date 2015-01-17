using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication
{
    public class AuthenticationException : Exception
    {
        private readonly AuthenticationResult authenticationResult;

        public AuthenticationException(AuthenticationResult authenticationResult)
            : base(authenticationResult.Message)
        {
            this.authenticationResult = authenticationResult;
        }

        public AuthenticationException(AuthenticationResult authenticationResult, Exception innerException)
            : base(authenticationResult.Message, innerException)
        {
            this.authenticationResult = authenticationResult;
        }

        public AuthenticationResult AuthenticationResult
        {
            get { return this.authenticationResult; }
        }
    }
}
