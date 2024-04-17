using HTMLHelpersInASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTMLHelpersInASP.NETCoreMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsInStock { get; set; }
        public int Rating { get; set; }
        public string ProductCategory { get; set; }
        public string MadeInCountry { get; set; }
        
        
        public List<WarrantyOfProduct> warrantyOfProducts { get; set; }
        public string WarrantyOfProduct { get; set; }


        public List<ProductFeatures> productFeatures { get; set; }
        public string ProductFeature { get; set; }


        public List<SelectListItem> manufacturingBranches { get; set; }
        public string SelectedBranch { get; set; }

        public ProductMemberShipsTypes productMemberShipTypes  { get; set; }

        public DateTime CreatedDate { get; set; }

    }

    public enum ProductMemberShipsTypes
    {
        Sliver,
        Gold,
        Platinum
    }
}
