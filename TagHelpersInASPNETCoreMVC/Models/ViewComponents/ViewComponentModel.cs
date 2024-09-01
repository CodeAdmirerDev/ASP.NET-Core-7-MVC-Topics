namespace TagHelpersInASPNETCoreMVC.Models.ViewComponents
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public string? Category { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
    }
    public class CartItem
    {
        public TagHelpersInASPNETCoreMVC.Models.ViewComponents.Product Product { get; set; }
        public double Quantity { get; set; }
    }
    public class MenuItem
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
