using Microsoft.AspNetCore.Mvc;
using DependencyInjectionApp.Models.Interfaces;
using DependencyInjectionApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmpInfo _empInfo;
        private readonly IDeptInfo _deptInfo;

        public EmployeeController(IEmpInfo empInfo,IDeptInfo deptInfo )
        {
            _empInfo = empInfo;
            _deptInfo = deptInfo;
        }

        [Route("GetEmps")]
        [HttpGet]
        public List<Emp> GetAllEmpList()
        {

            return _empInfo.GetAllEmployees();
        }


        [Route("GetDeps")]
        [HttpGet]
        public List<Dept> GetAllDeptList()
        {

            return _deptInfo.GetAllDepartments();
        }

    }
}
