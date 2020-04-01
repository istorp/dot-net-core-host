using GenericHost1.DatabaseModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericHost1
{
    public class MainService : IHostedService
    {

        private readonly OrderContext orderContext;
        private IHostApplicationLifetime lifetime;

        public MainService(OrderContext orderContext, IHostApplicationLifetime lifetime)
        {

            this.orderContext = orderContext;
            this.lifetime = lifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var order1 = new Order()
            {
               Description="test",
               EmployeeID=1
            };

            orderContext.Orders.Add(order1);
            orderContext.SaveChanges();


            //Console.WriteLine("Hello Anders!");

            var allOrders = orderContext.Orders.Select(o => new { OrderId = o.OrderID }).ToList();
            foreach (var item in allOrders)
            {
                Console.WriteLine($"OrderID: {item.OrderId} ");
            }
            
            
            Console.ReadKey();
            lifetime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
