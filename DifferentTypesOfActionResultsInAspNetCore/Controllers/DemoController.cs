using DifferentTypesOfActionResultsInAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }



        //ActionResult is a base class
        public ActionResult GetInfo(string typeOfInfo)
        {
            if(typeOfInfo=="HTML")
            {
                return View();

            }else if (typeOfInfo=="json")
            {
                return Json("User selected Json output");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }


        public JsonResult GetJsonInfo() {

            return Json("User selected Json output");
        }


        //ViewResult In ASP.NET Core
        public ViewResult DisplayProductInfo()
        {
            Product product = new Product()
            {  ProductId=1,
            ProductName="Laptop",
            ProductCategory="Digital",
            IsInStock=true,
            ProductDescription="Dell laptop having 8GB RAM and 1TB HDD"
            };

            return View(product);

        }

        // PartialViewResult In ASP.NET Core

        public PartialViewResult GetProductData()
        {
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "Dell laptop having 8GB RAM and 1TB HDD"
            };

            return PartialView("_ProductInfo", product);
                
         }

    }
}
