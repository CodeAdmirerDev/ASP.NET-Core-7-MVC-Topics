using DifferentTypesOfActionResultsInAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class JsonResultTypeController : Controller
    {

        public ViewResult IndexWithView()
        {
            return View();
        }

        public JsonResult Index()
        {
            var jsonArray = new[]
            {
                new { Name = "CodeAdmirer",  Type = "Instagram" },
                new { Name = "CodeAdmirerDev",  Type = "GitHub" }
            };
            return Json(jsonArray);
        }

        public JsonResult UserDetails()
        {
            var jsonData = new { ID = 4, Name = "CodeAdmirer", DateOfBirth = new DateTime(1988, 02, 29) };

            return Json(jsonData);
        }

        public JsonResult Index2()
        {
            var jsonData = new { ID = 4, Name = "CodeAdmirer", DateOfBirth = new DateTime(1988, 02, 29) };

            return new JsonResult(jsonData);
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

        public IActionResult ObjectToJson()
        {
            var jsonArray = new[]
            {
              new { ID = 1, Name = "CodeAdmirer", DateOfBirth = new DateTime(1988, 02, 29) },
               new { ID = 2, Name = "CodeAdmirerDev", DateOfBirth = new DateTime(1988, 02, 29) }
            };
            return Ok(jsonArray); // This will be automatically serialized to JSON
        }

        public IActionResult GetProductInfoImplicit()
        {
         var jsonData = new Product[] { 
         new Product() { ProductId = 1, ProductName = "OnePlus", IsInStock = true, ProductCategory = "SmartPhone", ProductDescription = "20K " }, 
         new Product() { ProductId = 1, ProductName = "OnePlus", IsInStock = true, ProductCategory = "SmartPhone", ProductDescription = "20K " } 
             };
            // jsonData is Object array type
            return Ok(jsonData); //It will be automatically serialized to Json at runtime
        }

        public JsonResult GetJsonInfo()
        {

            return Json("User selected Json output");
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
            },
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
             products = new List<Product>() {
             new Product() {ProductId = 1, ProductName = "Laptop", ProductCategory = "Digital",IsInStock = true, ProductDescription = "Dell Intel Core i7"},
             new Product() {ProductId = 2, ProductName = "TV", ProductCategory = "Digital",IsInStock = true, ProductDescription = "LG TV WEBOS"},
             };
                // To generate 1000's of data by using for loop like below 
                for (long i = 100; i > 0; i--)
                {
                    if (i / 2 == 0)
                    {
             products.Add(new Product() { ProductId = i, ProductName = "TV", ProductCategory = "Digital", IsInStock = true, ProductDescription = "LG TV WEBOS" });

                    }
                    else
                    {
             products.Add(new Product() { ProductId = i, ProductName = "TV", ProductCategory = "Digital", IsInStock = true, ProductDescription = "LG TV WEBOS" });
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

    }
}
