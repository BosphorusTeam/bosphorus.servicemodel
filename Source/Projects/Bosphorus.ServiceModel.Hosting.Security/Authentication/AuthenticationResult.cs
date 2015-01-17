using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Security.Authentication
{
    public class AuthenticationResult
    {
        public bool Authenticated { get; set; }

        public string Message { get; set; }
    }
}
