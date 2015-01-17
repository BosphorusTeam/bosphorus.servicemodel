using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Demo.Client.DemoServiceReference;

namespace Bosphorus.ServiceModel.Hosting.Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<ENTER> to invoke service");
            Console.ReadLine();

            using (DemoServiceContractClient client = new DemoServiceContractClient())
            {
                string dateTime = client.GetDateTime();
                Console.WriteLine(dateTime);

                string result = client.HelloWorld("Ödül", "Kanberoğlu");
                Console.WriteLine(result);
            }
            Console.WriteLine("<ENTER> to exit");
            Console.ReadLine();
        }
    }
}
