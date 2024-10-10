using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsInASPNETCore.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Employee name is required")]
        [StringLength(15,MinimumLength =8,ErrorMessage = "Employee name should be min 8 and max 15 chars")]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage ="DOB is required")]
        [DataType(DataType.DateTime)]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "DOJ is required")]
        [DataType(DataType.DateTime)]
        public DateTime? DOJ { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "UserName should be min 8 and max 15 chars")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",ErrorMessage = "Minimum eight characters, at least one letter and one number:")]
        public string Password { get; set; }

        public Department Department { get; set; } = new Department();

        public JobDetail JobDetail { get; set; } = new JobDetail();

        public Address Address { get; set; } = new Address();

        public Skillset Skillsets { get; set; }



    }
}
