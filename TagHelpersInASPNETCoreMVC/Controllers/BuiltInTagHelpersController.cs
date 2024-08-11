using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class BuiltInTagHelpersController : Controller
    {
        private List<Product> products;

        public BuiltInTagHelpersController()
        {
            products = new List<Product>()
            {
                new Product(){ProductId=1,ProductName="Dell Laptop",Description="Inspiron 5559", Category="Laptops",InStock=true,Price=35000},
                new Product(){ProductId=1,ProductName="HP Laptop",Description="HP 5559", Category="Laptops",InStock=true,Price=55000},
                new Product(){ProductId=1,ProductName="LG Mobile",Description="LG smart phone", Category="Mobile",InStock=true,Price=15000},
                new Product(){ProductId=1,ProductName="Samsung Mobile",Description="Samsung smart phone", Category="Mobile",InStock=true,Price=35000},
            };
        }
        public IActionResult Index()
        {
            return View(products);
        }

        public ViewResult ProductDetailsById(int productid)
        {
            var productDetails = products.FirstOrDefault(prd => prd.ProductId == productid);

            return View(productDetails);
        }
    }
}
