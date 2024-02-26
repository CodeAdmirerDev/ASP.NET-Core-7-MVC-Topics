namespace RoutingImplementationInASPDotnetCore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int StockCount { get; set; }
        public bool IsInStock { get; set; }
    }
}
