namespace All
{
   public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Goods>? goods { get; set; }
        public IEnumerable<Customer>? customer { get; set; }

        public override string ToString() => $"Order Id: {Id}, Name: {Name}";
    }
}