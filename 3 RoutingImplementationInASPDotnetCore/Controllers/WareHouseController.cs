using Microsoft.AspNetCore.Mvc;
using RoutingImplementationInASPDotnetCore.Models;

namespace RoutingImplementationInASPDotnetCore.Controllers
{
    [Route("WAStore")]
    public class WareHouseController : Controller
    {


        //To Ignore the Route Attribute Placed at the Controller Level 

        [Route("~/AboutWareHouse")]
        public string AboutWareHouse()
        {
            return "Welcome to WareHouse department. Please contact for more info wastore@admin.com";
        }



        //With Route attribute on Controller 
        [Route("")]
        [Route("/")]
        [Route("Index")]
        public string Index()
        {
            return "Welcome to WareHouse department.";
        }

        [Route("WareHouseDetails/{location}")]
        public string WareHouseDetails(string location)
        {
            return "Welcome to WareHouse department.";
        }


        /*
            //Adding Route using HTTP Methods
            [HttpGet("")]
            [HttpGet("/")]
            [HttpGet("Index")]
            public string Index()
            {
                return "Welcome to WareHouse department.";
            }

            [HttpGet("WareHouseDetails/{location}")]
            public string WareHouseDetails(string location)
            {
                return "Welcome to WareHouse department.";
            }

            [HttpGet("~/AboutWareHouse")]
            public string AboutWareHouse()
            {
                return "Welcome to WareHouse department. Please contact for more info wastore@admin.com";
            }

       */

        /*
             //Without Route attribute on Controller 
             [Route("")]
             [Route("WareHouse")]
             [Route("WareHouse/Index")]
             public string Index()
             {
                 return "Welcome to WareHouse department.";
             }

             [Route("WareHouse/WareHouseDetails/{location}")]
             public string WareHouseDetails(string location )
             {
                 return "Welcome to WareHouse department.";
             }
        */



        [Route("AboutWareHouse1")]
        public JsonResult GetWareHouseDetails1()
        {
            return Json("It is located in AP");
        }

        public JsonResult GetWareHouseDetails2()
        {
            return Json("It is located in TS");
        }



        List<Product> products;
        public WareHouseController()
        {

            products = new List<Product>() {

                new Product() { ProductId=1,ProductName="Laptop",IsInStock=true,ProductDescription="CoreI7",StockCount=12},
                new Product() { ProductId=2,ProductName="TV",IsInStock=true,ProductDescription="32Inch",StockCount=120},
                new Product() { ProductId=3,ProductName="Fridge",IsInStock=false,ProductDescription="5Star",StockCount=1200},
                new Product() { ProductId=4,ProductName="Sofa",IsInStock=true,ProductDescription="5 seater",StockCount=12000},

            };
        }

        //[Route("WareHouse/GetJsonData")] -- Without Route on Controller name
        [Route("GetData")]  // With Route() on Controller name
        public JsonResult GetJsonData()
        {
            return Json(products);
        }

        [Route("GetJsonData/{productId}")]  // For Param value to pass in Attribute routing
        public JsonResult GetJsonData(int productId)
        {
            return Json(products.Where(product=> product.ProductId==productId).FirstOrDefault());
        }

        //(You have to specify the ? post the param name)
        [Route("GetJsonWDataWithOptionalParam/{isFromVendor?}")] // For Optional Param value to pass in Attribute routing 
        public JsonResult GetJsonWareHouseDataWithOptionalParam(string isFromVendor="Yes")
        {
            if (isFromVendor=="Yes")
            {
                return Json(products);
            }
            else
            {
                return Json(products.Where(product=> product.IsInStock== true));
            }
        }

        [Route("GetJsonWareHouseData/{isFromVendor}")]
        public JsonResult GetJsonWareHouseData(string isFromVendor)
        {
            if (isFromVendor == "Yes")
            {
                return Json(products);
            }
            else
            {
                return Json(products.Where(product => product.IsInStock == true));
            }
        }


        // For adding param validation we can specify the Constraint name post the param name and put the : symbol
        [Route("GetJsonWareHouseData/{isFromAI:alphabetWithNumeric}")] 
        public JsonResult GetJsonWareHouseDataAnalytic(string isFromAI = "Yes")
        {
            if (isFromAI == "Yes")
            {
                return Json(products);
            }
            else
            {
                return Json(products.Where(prodcut => prodcut.IsInStock == true));
            }
        }


        public IActionResult GetProductList()
        {
            return View(products);
        }


        //If you want to Ignore the Route Attribute placed at the Controller level (~/ use in front of Route value)
        [Route("~/product/{productIdValue}/info")]
        public IActionResult GetProductInfoByProdId(int productIdValue)
        {
            Product? product = products.Where(prod => prod.ProductId== productIdValue).FirstOrDefault();

            return View(product);
        }


        //using Http Methods with Route template

        [HttpPost("~/AboutWareHouse")]
        public JsonResult GetWareHouseDetails()
        {
            return Json("It is located in AP");
        }


        [Route("~/GetWareHouseDetailsJson")]
        public JsonResult GetWareHouseDetailsJson()
        {
            return Json("It is located in AP");
        }


    }
}
