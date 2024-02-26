using Microsoft.AspNetCore.Mvc;
using RoutingImplementationInASPDotnetCore.Models;

namespace RoutingImplementationInASPDotnetCore.Controllers
{
    public class WareHouseController : Controller
    {

        List<Product> products;
        public WareHouseController()
        {

            products = new List<Product>() {

                new Product() { ProductId=1,ProductName="Laptop",IsInStock=true,ProductDescription="CoreI7",StockCount=12},
                new Product() { ProductId=2,ProductName="TV",IsInStock=true,ProductDescription="32Inch",StockCount=120},
                new Product() { ProductId=3,ProductName="Fridge",IsInStock=true,ProductDescription="5Star",StockCount=1200},
                new Product() { ProductId=4,ProductName="Sofa",IsInStock=true,ProductDescription="5 seater",StockCount=12000},

            };
        }

        public IActionResult GetProdcutList()
        {
            return View(products);
        }

        [Route("prodcut/{productIdValue}/info")]
        public IActionResult GetProdcutInfoByProdId(int productIdValue)
        {
            Product? product = products.Where(prod => prod.ProductId== productIdValue).FirstOrDefault();

            return View(product);
        }


    }
}
