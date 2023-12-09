using DependencyInjectionApp.Models.Interfaces;

namespace DependencyInjectionApp.Models.Services
{
    public class OnlyEmpServices : IEmpInfo
    {
        public List<Emp> EmployesList = new List<Emp>();


        public List<Emp> GetAllEmployees()
        {
            if(EmployesList.Count == 0)
            {
                var emp = new Emp
                {
                    EmpId = 1,
                    EmpName = "Suri",
                    Email = "Suri@CodeWithSuri.com",
                    Age = 28,
                    Address = "ABC",
                    DeptId = 1,
                    Phone = "0123456789"

                };

                EmployesList.Add(emp);
                return EmployesList;
            }
            else
            {
                return EmployesList;
            }

        }

        public List<Emp> SaveEmpRecord(Emp emp)
        {
            EmployesList.Add(emp);

            return EmployesList;
        }



    }
}
