using HTMLHelpersInASP.NETCoreMVC.Models;
using HTMLHelpersInASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HTMLHelpersInASP.NETCoreMVC.Controllers
{
    public class HTMLHelpersTypeController : Controller
    {
        public IActionResult HTMLHelperTagInfo()
        {
            return View();
        }

        public Product getBasicProductInfo()
        {
            Product product = new Product();

            product.ProdcutId = 1;
            product.ProdcutName = "LG Mobile";
            product.Description = "This is latest 5G Mobile, having 8GB RAM 128GB Memory.";
            product.IsInStock = true;
            product.Rating = 10;

            return product;
        }

        public IActionResult TextBoxHelperView()
        {
            return View();
        }

        public IActionResult TextAreaHelperView()
        {
            return View(getBasicProductInfo());
        }

        public IActionResult DropDownListHelperView()
        {

            Product product = getBasicProductInfo();
            product.ProductCategory = "SmartTV";
            product.MadeInCountry = "India";

            ViewBag.ListproductCategories = new List<SelectListItem>
            {
                 new SelectListItem{ Text="Please select Category" , Value="0", Selected=true},
                new SelectListItem{ Text="SmartPhone" , Value="1" },
                new SelectListItem{ Text="SmartTV" , Value="2" },
                new SelectListItem{ Text="Fridge" , Value="3"},
            };

            ViewBag.ListCountries = new List<SelectListItem>
            {
                 new SelectListItem{ Text="Please select Country" , Value="0", Selected=true},
                new SelectListItem{ Text="India" , Value="1" },
                new SelectListItem{ Text="USA" , Value="2" },
                new SelectListItem{ Text="Russia" , Value="3"},
            };

            return View(product);
        }

        public IActionResult RadioButtonHelperView()
        {

            Product product = getBasicProductInfo();
            product.ProductCategory = "SmartTV";
            product.MadeInCountry = "India";

            ViewBag.ListproductCategories = new List<SelectListItem>
            {
                 new SelectListItem{ Text="Please select Category" , Value="0", Selected=true},
                new SelectListItem{ Text="SmartPhone" , Value="1" },
                new SelectListItem{ Text="SmartTV" , Value="2" },
                new SelectListItem{ Text="Fridge" , Value="3"},
            };

            ViewBag.ListCountries = new List<SelectListItem>
            {
                 new SelectListItem{ Text="Please select Country" , Value="0", Selected=true},
                new SelectListItem{ Text="India" , Value="1" },
                new SelectListItem{ Text="USA" , Value="2" },
                new SelectListItem{ Text="Russia" , Value="3"},
            };

           product.warrantyOfProducts = new List<WarrantyOfProduct>
            {

                new WarrantyOfProduct { Id = 1, WarrantyYears = "0-5 Years" },
                new WarrantyOfProduct { Id = 1, WarrantyYears = "5-10 Years" },
                new WarrantyOfProduct { Id = 1, WarrantyYears = "10-15 Years" },
                new WarrantyOfProduct { Id = 1, WarrantyYears = "15-20 Years" },
            };

            return View(product);
        }

    }
}
