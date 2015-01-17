using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core
{
    public static class ServiceHostBaseExtensions
    {
        public static void DumpEndpoints(this ServiceHostBase extended)
        {
            foreach (ChannelDispatcher cd in extended.ChannelDispatchers)
            {
                foreach (EndpointDispatcher ep in cd.Endpoints)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(ep.ContractName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" @ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ep.EndpointAddress.Uri);
                    Console.ResetColor();
                }
            }
        }
    }
}
