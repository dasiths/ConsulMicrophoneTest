using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microphone.Core;
using Microphone.Core.ClusterProviders;
using Microphone.WebApi;

namespace ConsulTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new ConsulProvider();
            Cluster.Bootstrap(new WebApiProvider(), provider, "orders", "v1");
            Console.ReadLine();
        }
    }

    public class OrdersController : ApiController
    {
        public string Get()
        {
            return "WebApi Service";
        }

    }

    public class ServiceTestController : ApiController
    {
        public string Get()
        {
            var instance = Cluster.FindServiceInstanceAsync("orders").Result;
            return instance.Address + instance.Port;
        }

    }
}
