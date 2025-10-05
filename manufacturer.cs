namespace All
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name {Name}";
        }
    }
}