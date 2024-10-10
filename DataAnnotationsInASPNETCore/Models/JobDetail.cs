using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsInASPNETCore.Models
{
    public class JobDetail
    {
        [Key]
        public int JobDetailId { get; set; }
        [Required(ErrorMessage ="Job title is required")]
        public string JobTitleName { get; set; }

        [DataType(DataType.Currency)]
        [Range(30000,50000,ErrorMessage ="The Salary should be between 30,000 and 50,000")]
        public decimal Salary { get; set; }


    }
}
