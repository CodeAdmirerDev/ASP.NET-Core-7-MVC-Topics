using System.ComponentModel.DataAnnotations;

namespace LearningMVC.Models
{
    public class Dept
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set;}
       
        public string DeptDescription { get; set;}
        [Required]
        public int DeptStatus { get; set;}

        [Required]
        public string DeptLocation { get; set;}


    }
}
