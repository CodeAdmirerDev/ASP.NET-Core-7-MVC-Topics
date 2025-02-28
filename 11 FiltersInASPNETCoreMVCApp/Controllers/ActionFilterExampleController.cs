using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    public class ActionFilterExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(CustomLoggerActionFilter))]
        public string TestActionFilterProcess()
        {
            return "Action filter executed please check the logs";
        }

        [ServiceFilter(typeof(CustomAsyncCacheActionFilter))]
        public IActionResult TestAsyncActionFilter()
        {
            ViewData["CurrentDateTime"] = DateTime.Now;
            return View();
        }


        [DataTransformationActionFilter]
        public IActionResult ShowCustomModelDetails()
        {
            var model = new CustomModel
            {
                Name = "CodeAdmirer",
                Address = "India"
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateUserAccount()
        {
            return View();
        }

        [TypeFilter(typeof(CustomValidationActionFilter))]
        [HttpPost]
        public IActionResult CreateUserAccount(CustomModel userAccountModel)
        {
            if (ModelState.IsValid)
            {
                // Save the user account to the database
                TempData["Message"] = $"User account :{userAccountModel.Name} created successfully!";
                return RedirectToAction("Index");
            }
            return View(userAccountModel);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult ThrowException()
        {
            throw new Exception("This is a test exception");
        }

    }
}
