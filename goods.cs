namespace All
{
    public class Goods
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Category>? category { get; set; }
        public IEnumerable<Manufacturer>? manufacturer { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}