using DependencyInjectionApp.Models.Interfaces;

namespace DependencyInjectionApp.Models.Services
{
    public class EmpServices : IEmpInfo, IDeptInfo
    {
        public List<Emp> EmployesList = new List<Emp>();

        public List<Dept> GetAllDepartments()
        {
            var departmentsList = new List<Dept>
            {
                new Dept
                {DeptId = 1,
                DeptName="IT",
                DeptDescription="IT Department"
                },
                new Dept
                {DeptId = 2,
                DeptName="Admin",
                DeptDescription="Admin Department"
                }
            };
            return departmentsList;
        }

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
                    Address = "XYZ",
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
