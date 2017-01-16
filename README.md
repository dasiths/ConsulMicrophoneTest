# ConsulMicrophoneTest
Testing Consul + Microphone with WebAPI (https://github.com/rogeralsing/Microphone)
Nuget Microphone.WebAPI v0.15

```
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
```
