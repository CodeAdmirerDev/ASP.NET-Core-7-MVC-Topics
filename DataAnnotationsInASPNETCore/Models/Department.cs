using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsInASPNETCore.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Department name is required")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="Department name should be between 5 and 10 chars")]
        public string DepartmentName { get; set; }
    }
}
