using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class PartialtaghelperController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", Description = "A powerful laptop for professionals Developere", Price = 999.99, ImageUrl = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/inspiron-notebooks/14-5440/media-gallery/ice-blue-plastic/notebook-inspiron-14-5440-ice-blue-plastic-gallery-2.psd?fmt=png-alpha&pscan=auto&scl=1&wid=3320&hei=2635&qlt=100,1&resMode=sharp2&size=3320,2635&chrss=full&imwidth=5000", Category = "Electronics", InStock = true },
                new Product { ProductId = 2, ProductName = "Smartphone", Description = "Latest smartphone with cutting-edge features", Price = 799.99, ImageUrl = "https://f.media-amazon.com/images/I/61fDxgcyBDL._SL1500_.jpg", Category = "Electronics", InStock = true },
                new Product { ProductId = 3, ProductName = "Headphones", Description = "Noise-cancelling over-ear headphones good for health", Price = 199.9, ImageUrl = "https://f.media-amazon.com/images/I/51QTyJ107KL._SL1200_.jpg", Category = "Accessories", InStock = false }
            };
            return View(products);
        }
    }
}
