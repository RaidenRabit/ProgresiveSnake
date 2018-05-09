using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTier
{
    class StartService
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service started");
            ServiceHost serviceHost = new ServiceHost(typeof(SnakeService));
            serviceHost.Open();
            DisplayHostInfo(serviceHost);
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine(); Console.WriteLine("****** Host Info *******");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine("Instance Context Menu: {0}", host.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode);
                Console.WriteLine("Concurrency Mode: {0}", host.Description.Behaviors.Find<ServiceBehaviorAttribute>().ConcurrencyMode);
                Console.WriteLine();
            }
            Console.WriteLine("************************");
            Console.WriteLine();
        }
    }
}
