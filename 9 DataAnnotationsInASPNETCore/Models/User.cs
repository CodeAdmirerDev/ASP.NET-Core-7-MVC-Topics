using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsInASPNETCore.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Please enter the UserName.")]
        [MaxLength(10, ErrorMessage = "Username max length is 10")]
        [MinLength(6,ErrorMessage ="Username min length is 6")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string CNPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Countries Country { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AccountCreatedDate { get; set; }

        [DataType(DataType.Currency)]
        [Range(10000,20000, ErrorMessage ="User income must be between 10000 and 20000")]
        public decimal UserIncome { get; set; }

    }
}
