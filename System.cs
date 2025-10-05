using System;
using System.Collections.Generic;
using System.Linq;

namespace All
{
   public interface IOrderSystem
    {
        public void CreateOrder(Order order);
        public IEnumerable<Order> GetAll();
        public void UpdateOrder(int id, Order order);
        public void DeleteOrder(int id);
        public Order? GetOrderById(int id);
        public void SortByName();
        public IEnumerable<Order> Search(string keyword);
    }

    public class OrderSystem : IOrderSystem
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public void CreateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            Orders.Add(order);
        }

        public IEnumerable<Order> GetAll() => Orders;

        public Order? GetOrderById(int id) => Orders.FirstOrDefault(o => o.Id == id);

        public void UpdateOrder(int id, Order order)
        {
            var existing = GetOrderById(id);
            if (existing == null) throw new Exception($"Order with ID {id} not found.");

            existing.Name = order.Name;
            existing.goods = order.goods;
            existing.customer = order.customer;
        }

        public void DeleteOrder(int id)
        {
            var existing = GetOrderById(id);
            if (existing != null)
                Orders.Remove(existing);
            else
                throw new Exception($"Order with ID {id} not found.");
        }

        public void SortByName() => Orders = Orders.OrderBy(o => o.Name).ToList();

        public IEnumerable<Order> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return Orders;

            keyword = keyword.ToLower();
            return Orders.Where(o =>
                (o.Name != null && o.Name.ToLower().Contains(keyword)) ||
                (o.customer != null && o.customer.Any(c => c.Name != null && c.Name.ToLower().Contains(keyword))) ||
                (o.goods != null && o.goods.Any(g => g.Name != null && g.Name.ToLower().Contains(keyword)))
            );
        }
    }
}
