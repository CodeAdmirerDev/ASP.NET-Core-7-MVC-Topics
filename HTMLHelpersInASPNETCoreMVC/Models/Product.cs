using HTMLHelpersInASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTMLHelpersInASP.NETCoreMVC.Models
{
    public class Product
    {
        public int ProdcutId { get; set; }
        public string ProdcutName { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public int Rating { get; set; }
        public string ProductCategory { get; set; }
        public string MadeInCountry { get; set; }
        public string WarrantyOfProduct { get; set; }

        public List<WarrantyOfProduct> warrantyOfProducts { get; set; }

    }
}
