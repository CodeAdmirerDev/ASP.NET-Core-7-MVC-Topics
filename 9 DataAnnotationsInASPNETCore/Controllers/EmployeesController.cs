using DataAnnotationsInASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAnnotationsInASPNETCore.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult CreateEmployee()
        {
            TempData["PageTitle"] = "Create Employee";

            Employee employee = new Employee();

            //employee.Address = new Address();
            //employee.Address.AddressId=1;
            
            //employee.JobDetail = new JobDetail();
            //employee.JobDetail.JobDetailId = 1;
            
            //employee.Address= new Address();    
            //employee.Address.AddressId=1;
            
            return View(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Scucess", "DAnnotations");
            }

            return View(employee);
        }
    }
}
