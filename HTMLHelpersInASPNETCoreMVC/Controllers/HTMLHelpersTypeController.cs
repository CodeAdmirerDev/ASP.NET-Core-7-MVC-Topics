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

            product.ProductId = 1;
            product.ProductName = "LG Mobile";
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

                new WarrantyOfProduct { Id = 1, WarrantyYears = "0-5 Years"},
                new WarrantyOfProduct { Id = 2, WarrantyYears = "5-10 Years" },
                new WarrantyOfProduct { Id = 3, WarrantyYears = "10-15 Years"  , defaultWarranty=true},
                new WarrantyOfProduct { Id = 4, WarrantyYears = "15-20 Years" },
            };

            return View(product);
        }



        public IActionResult CheckBoxHelperView()
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

                new WarrantyOfProduct { Id = 1, WarrantyYears = "0-5 Years"},
                new WarrantyOfProduct { Id = 2, WarrantyYears = "5-10 Years" },
                new WarrantyOfProduct { Id = 3, WarrantyYears = "10-15 Years"  , defaultWarranty=true},
                new WarrantyOfProduct { Id = 4, WarrantyYears = "15-20 Years" },
            };

            product.productFeatures = new List<ProductFeatures>
            {
                new ProductFeatures { FeatureId = 1, FeatureName = "Design",defaultFeature=true},
                new ProductFeatures { FeatureId = 2, FeatureName = "Durability" },
                new ProductFeatures { FeatureId = 3, FeatureName = "Performance",defaultFeature=true },
                new ProductFeatures { FeatureId = 4, FeatureName = "IsAffordable" },
            };

            return View(product);
        }

        public IActionResult ListBoxHelperView()
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

                new WarrantyOfProduct { Id = 1, WarrantyYears = "0-5 Years"},
                new WarrantyOfProduct { Id = 2, WarrantyYears = "5-10 Years" },
                new WarrantyOfProduct { Id = 3, WarrantyYears = "10-15 Years"  , defaultWarranty=true},
                new WarrantyOfProduct { Id = 4, WarrantyYears = "15-20 Years" },
            };

            product.productFeatures = new List<ProductFeatures>
            {
                new ProductFeatures { FeatureId = 1, FeatureName = "Design",defaultFeature=true},
                new ProductFeatures { FeatureId = 2, FeatureName = "Durability" },
                new ProductFeatures { FeatureId = 3, FeatureName = "Performance",defaultFeature=true },
                new ProductFeatures { FeatureId = 4, FeatureName = "IsAffordable" },
            };
            product.manufacturingBranches = new List<SelectListItem>
            {
                new SelectListItem {Text="Kadapa", Value="1", Selected=true},
                new SelectListItem {Text="HYD", Value="2", Selected=true},
                new SelectListItem {Text="BLR", Value="3", Selected=true},
                new SelectListItem {Text="Mumbai", Value="4", Selected=true},

            };

            return View(product);
        }

        public IActionResult EditorHTMLHelper()
        {
            Product product = getBasicProductInfo();
            product.SelectedBranch = "Kadapa";
            product.productMemberShipTypes = ProductMemberShipsTypes.Gold;
            product.ProductCategory = "SmartTV";
            product.MadeInCountry = "India";
            product.CreatedDate = Convert.ToDateTime("04-04-2022");


            return View(product);
        }

        public IActionResult PasswordAndHiddenHTMLHelpers()
        {

            Product product = getBasicProductInfo();

            product.DealerName = "Vamsi";
            product.IsDNEnabled = false;
            return View(product);
        }

        [HttpPost]
        public IActionResult DisplayProductInfo(Product product)
        {
           
            return View(product);
        }

        public IActionResult UsingCustomTagHelpers()
        {
            Product product = getBasicProductInfo();
            product.ProductPhotoPath = "/images/lgmobile.jpeg";
            product.AltTextIfPhotoNotExist = "This is the LG Mobile photo";

            return View(product);
        }
        public IActionResult DifferentWaysToGenerateLinks()
        {
            return View();
        }

        public IActionResult DisplayCustomLoginForm()
        {
            return View();
        }

    }
    }
