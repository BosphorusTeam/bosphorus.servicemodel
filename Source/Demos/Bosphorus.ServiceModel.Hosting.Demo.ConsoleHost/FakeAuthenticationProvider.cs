using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model.Messaging.Request;
using Bosphorus.ServiceModel.Hosting.Security.Authentication;
using Bosphorus.ServiceModel.Hosting.Security.Authentication.Provider;

namespace Bosphorus.ServiceModel.Hosting.Demo.ConsoleHost
{
    public class FakeAuthenticationProvider : IAuthenticationProvider<ClientInformation>
    {
        public AuthenticationResult Authenticate(ClientInformation model)
        {
            return new AuthenticationResult {Authenticated = true};
        }
    }
}
