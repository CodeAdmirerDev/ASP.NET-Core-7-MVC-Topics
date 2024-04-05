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

        public JsonResult GetProductJsonInfo()
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

        public IActionResult GetProductInfoImplicit()
        {
            var jsonData= new Product[]{ new Product(){ProductId=1, ProductName="OnePlus",IsInStock=true,ProductCategory="SmartPhone",ProductDescription="20K " }, new Product() { ProductId = 1, ProductName = "OnePlus", IsInStock = true, ProductCategory = "SmartPhone", ProductDescription = "20K " } };
            // jsonData is Object array type
            return Ok(jsonData); //It will be automatically serialized to Json at runtime
        }



        public JsonResult GetProductJsonListInfo()
        {
            
            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            options.PropertyNameCaseInsensitive = true;

            List<Product> products = new List<Product>() {

      new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "Dell laptop having 8GB RAM and 1TB HDD"
            }
      ,
      new Product()
            {
                ProductId = 2,
                ProductName = "TV",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "LG TV having 2GB RAM and With magic remote"
            }
            };

            return Json(products, options);
        }


        //Using jQuery Ajax for getting the data from Action method which having the JsonResult as Action Result 


        public ActionResult GetProductListDetails()
        {
            List<Product> products = new();
          
            //Using below options we are changing the default case from Camel to Pascal and 
            // also we are specifying the Property Names should be Case sensitive
            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = null;
            options.PropertyNameCaseInsensitive = false;

            try
            {
                products=  new List<Product>() {

      new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "Dell laptop having 8GB RAM and 1TB HDD"
            }
      ,
      new Product()
            {
                ProductId = 2,
                ProductName = "TV",
                ProductCategory = "Digital",
                IsInStock = true,
                ProductDescription = "LG TV having 2GB RAM and With magic remote"
            }


            };


                // To generate 1000's of data by using for loop like below 


                for (long i=100; i>0; i--)
                {

                    if (i / 2 == 0)
                    {
                        products.Add(new Product()
                        {
                            ProductId = i,
                            ProductName = "TV",
                            ProductCategory = "Digital",
                            IsInStock = true,
                            ProductDescription = "LG TV having 2GB RAM and With magic remote"
                        });

                    }
                    else
                    {

                        products.Add(new Product()
                        {
                            ProductId = i,
                            ProductName = "TV",
                            ProductCategory = "Digital",
                            IsInStock = false,
                            ProductDescription = "LG TV having 2GB RAM and With magic remote"
                        });
                    }
                }
               
                //To get the exception you can uncomment the below code 

                //string productName = null;
                //string[] productInfo = productName.Split(",");

                return Json(products, options);

            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ExceptionType = "Server is not responding"
                }, options)
                { StatusCode = StatusCodes.Status500InternalServerError };
            }


        }


        public ActionResult DisplayProductListDetailsInTableFormat()
        {
            return View();

        }


    }
}
