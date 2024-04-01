using DifferentTypesOfActionResultsInAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        [AjaxOnly]  
        public PartialViewResult GetProductData()
        {
            
            /*
             * 
            To understand about the process , execute Demo/Index then
                you will get the Product Info As Index page having the ajax call.
            Where as If you are calling the Demo/ GetProductData method directly it will
                throw true error because it is not a Ajax method

            */


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


        public PartialViewResult GetProductDataAjaxHeaderCheckWithInTheMethod()
        {

            /*
             * 
            To understand about the process , execute Demo/Index then
                you will get the Product Info As Index page having the ajax call.
            Where as If you are calling the Demo/GetProductDataAjaxHeaderCheckWithInTheMethod method directly it will
                throw true error because it is not a Ajax method

            */

            string method = HttpContext.Request.Method;

            string requestedWith = HttpContext.Request.Headers["X-Requested-With"];

            if (method=="GET")
            {

                if(requestedWith== "XMLHttpRequest")
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
            //If the request is not matched with our requirement then will display the content of _InvalidPartialView
            return PartialView("_InvalidPartialView");

        }

        //JsonResult In ASP.NET Core

        public JsonResult GetProductListJsonInfo()
        {
            /*
             * 
            Serialization => C# Object to Stream (Json key value pair formant)
            
            DeSerialization =>  Stream (Json keyvalue pair formant) to C# Object 

            */

            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            options.PropertyNameCaseInsensitive = true;


            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "Dell laptop having 8GB RAM and 1TB HDD"
            };

            return Json(product, options);
        }
    }
}
