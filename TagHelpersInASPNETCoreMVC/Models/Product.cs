namespace TagHelpersInASPNETCoreMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public string? Category { get; set; }
        public bool InStock { get; set; }
    }
}
