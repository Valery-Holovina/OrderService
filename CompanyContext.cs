using System.Collections.Generic;

namespace All
{
    public class CompanyContext
    {
        public static IEnumerable<Category> GetCategories() => new List<Category>()
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Home" },
            new Category { Id = 3, Name = "Beauty" }
        };

        public static IEnumerable<Manufacturer> GetManufacturers() => new List<Manufacturer>()
        {
            new Manufacturer { Id = 1, Name = "Apple" },
            new Manufacturer { Id = 2, Name = "Samsung" },
            new Manufacturer { Id = 3, Name = "LG" }
        };

        public static IEnumerable<Goods> GetGoods()
        {
            var categories = new List<Category>(GetCategories());
            var manufacturers = new List<Manufacturer>(GetManufacturers());

            return new List<Goods>()
            {
                new Goods
                {
                    Id = 1,
                    Name = "iPhone 15",
                    category = new[] { categories[0] },
                    manufacturer = new[] { manufacturers[0] }
                },
                new Goods
                {
                    Id = 2,
                    Name = "Galaxy S24",
                    category = new[] { categories[0] },
                    manufacturer = new[] { manufacturers[1] }
                },
                new Goods
                {
                    Id = 3,
                    Name = "LG TV",
                    category = new[] { categories[1] },
                    manufacturer = new[] { manufacturers[2] }
                }
            };
        }

        public static IEnumerable<Customer> GetCustomers() => new List<Customer>()
        {
            new Customer { Id = 1, Name = "Alice" },
            new Customer { Id = 2, Name = "Bob" },
            new Customer { Id = 3, Name = "Clara" }
        };

        public static IEnumerable<Order> GetOrders()
        {
            var goods = new List<Goods>(GetGoods());
            var customers = new List<Customer>(GetCustomers());

            return new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    Name = "Order A",
                    goods = new[] { goods[0] },
                    customer = new[] { customers[0] }
                },
                new Order
                {
                    Id = 2,
                    Name = "Order B",
                    goods = new[] { goods[1] },
                    customer = new[] { customers[1] }
                }
            };
        }
    }
}
