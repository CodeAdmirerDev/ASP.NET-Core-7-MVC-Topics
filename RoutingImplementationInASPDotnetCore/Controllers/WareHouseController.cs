using Microsoft.AspNetCore.Mvc;
using RoutingImplementationInASPDotnetCore.Models;

namespace RoutingImplementationInASPDotnetCore.Controllers
{
    [Route("WAStore")]
    public class WareHouseController : Controller
    {

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

        [Route("GetJsonData/{prodcutId}")]  // For Param value to pass in Attribute routing
        public JsonResult GetJsonData(int prodcutId)
        {
            return Json(products.Where(product=> product.ProductId==prodcutId).FirstOrDefault());
        }

        //(You have to specify the ? post the param name)
        [Route("GetJsonWareHouseData/{isFromVendor?}")] // For Optional Param value to pass in Attribute routing 
        public JsonResult GetJsonWareHouseData(string isFromVendor="Yes")
        {
            if (isFromVendor=="Yes")
            {
                return Json(products);
            }
            else
            {
                return Json(products.Where(prodcut=> prodcut.IsInStock== true));
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


        public IActionResult GetProdcutList()
        {
            return View(products);
        }


        //If you want to Ignore the Route Attribute placed at the Controller level (~/ use in front of Route value)
        [Route("~/prodcut/{productIdValue}/info")]
        public IActionResult GetProdcutInfoByProdId(int productIdValue)
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


        [Route("~/AboutWareHouse1")]
        public JsonResult GetWareHouseDetails1()
        {
            return Json("It is located in AP");
        }


    }
}
