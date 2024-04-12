namespace HTMLHelpersInASP.NETCoreMVC.Models
{
    public class Product
    {
        public int ProdcutId { get; set; }
        public string ProdcutName { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public int Rating { get; set; }
    }
}
