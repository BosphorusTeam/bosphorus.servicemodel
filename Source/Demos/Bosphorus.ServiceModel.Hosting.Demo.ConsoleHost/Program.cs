using System;
using Bosphorus.ServiceModel.Hosting.Hosting.Core;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Addressing;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.ServiceModel.Hosting.Demo.PocoService;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Configuration;
using Environment = Bosphorus.BootStapper.Common.Environment;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Demo.ConsoleHost
{
    class Program : IProgram
    {
        private readonly IServiceConfigurationRepository serviceConfigurationRepository;
        private readonly IServiceHostProvider serviceHostProvider;
        private readonly IUriBuilder uriBuilder;

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(Environment.Test, Perspective.Debug, args);
        }

        public Program(IServiceConfigurationRepository serviceConfigurationRepository, IServiceHostProvider serviceHostProvider, IUriBuilder uriBuilder)
        {
            this.serviceConfigurationRepository = serviceConfigurationRepository;
            this.serviceHostProvider = serviceHostProvider;
            this.uriBuilder = uriBuilder;

            
        }

        public void Run(string[] args)
        {
            ServiceConfiguration serviceConfiguration = serviceConfigurationRepository.Get(typeof (DemoService));

            ConsoleColor defaultForegroundColor = Console.ForegroundColor;

            Uri[] baseAddresses = uriBuilder.Build(serviceConfiguration).ToArray();
            ServiceHost host = serviceHostProvider.Get(serviceConfiguration, baseAddresses);
            host.Open();
            host.DumpEndpoints();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = defaultForegroundColor;

            Console.WriteLine("ServiceHosts started. <ENTER> to exit.");
            Console.ReadLine();
        }
    }
}
