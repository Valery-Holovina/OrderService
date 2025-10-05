
using System;
using All;

 public class Program
    {
        public static void Main()
        {
            var system = new OrderSystem();

           
            foreach (var order in CompanyContext.GetOrders())
                system.CreateOrder(order);

            Console.WriteLine("=== All Orders ===");
            foreach (var o in system.GetAll())
                Console.WriteLine(o);

         
            var newOrder = new Order
            {
                Id = 3,
                Name = "Order C",
                goods = new[] { CompanyContext.GetGoods().Last() },
                customer = new[] { CompanyContext.GetCustomers().Last() }
            };
            system.CreateOrder(newOrder);

            Console.WriteLine("\n=== After Adding New Order ===");
            foreach (var o in system.GetAll())
                Console.WriteLine(o);

            // Sort
            system.SortByName();
            Console.WriteLine("\n=== Sorted by Name ===");
            foreach (var o in system.GetAll())
                Console.WriteLine(o);

            // Search
            Console.WriteLine("\n=== Search 'Alice' ===");
            foreach (var o in system.Search("Alice"))
                Console.WriteLine(o);

            // Update
            var updated = new Order { Id = 1, Name = "Updated Order A", goods = CompanyContext.GetGoods(), customer = CompanyContext.GetCustomers() };
            system.UpdateOrder(1, updated);
            Console.WriteLine("\n=== After Update ===");
            foreach (var o in system.GetAll())
                Console.WriteLine(o);

            // Delete
            system.DeleteOrder(2);
            Console.WriteLine("\n=== After Delete Order with Id=2 ===");
            foreach (var o in system.GetAll())
                Console.WriteLine(o);
        }
    }
