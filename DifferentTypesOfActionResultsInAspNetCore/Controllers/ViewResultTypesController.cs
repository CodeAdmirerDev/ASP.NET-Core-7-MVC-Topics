using DifferentTypesOfActionResultsInAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class ViewResultTypesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // PartialViewResult In ASP.NET Core
        [AjaxOnly]
        public PartialViewResult GetProductData()
        {
            /*
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



        public ViewResult ProductInfo()
        {
            Product product = new Product()
            {
                ProductId = 64,
                ProductName = "OnePlus Nord CE2 Lite",
                IsInStock= true,
                ProductCategory="SmartPhone",
                ProductDescription="It's a 5G Mobile"
            };
            return View(product);
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




    }
}
