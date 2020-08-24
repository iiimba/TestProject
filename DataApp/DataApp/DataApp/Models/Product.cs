namespace DataApp.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }
        public Color Color { get; set; }

        public bool InStock { get; set; }

        public long SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }
}
