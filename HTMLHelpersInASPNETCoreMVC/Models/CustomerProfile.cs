using System.ComponentModel.DataAnnotations;

namespace HTMLHelpersInASPNETCoreMVC.Models
{
    public class CustomerProfile
    {
        public int? CustomerId {  get; set; }
        [Required(ErrorMessage ="Customer name is required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer Bio is required")]
        public string Bio { get; set; }
        public string? Gender { get; set; }
            
        public List<string> Hobbies { get; set; }= new List<string>();

        public List<string> Nicknames { get; set; } = new List<string>();

        public bool RequiredUpdates { get; set; }

        public string? Feedback { get; set; }
        [Required(ErrorMessage = "Customer Password is required")]
        public string Password { get; set; }

    }
}
