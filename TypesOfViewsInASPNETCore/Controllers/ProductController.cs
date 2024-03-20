using Microsoft.AspNetCore.Mvc;
using TypesOfViewsInASPNETCore.Models;

namespace TypesOfViewsInASPNETCore.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>();
        public ProductController()
        {
            products = new List<Product>() { new Product() { Description="Good" , IsInStock=true,
            ProdcutId=1,ProdcutName="SmartPhone", Rating=5},
             new Product() { Description="Good" , IsInStock=true,
            ProdcutId=2,ProdcutName="HeadPhone", Rating=5},


 new Product() { Description="Good" , IsInStock=true,
            ProdcutId=3,ProdcutName="laptop", Rating=5},


             new Product() { Description="Good" , IsInStock=true,
            ProdcutId=4,ProdcutName="SmartWatch", Rating=5}
            };
        }

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Details(int ProductId)
        {
            TempData["Header"] = "Product Deatails";
            var ProductInfo = products.Where(p=> p.ProdcutId == ProductId).FirstOrDefault();

            return View(ProductInfo);
        }



    }
}
