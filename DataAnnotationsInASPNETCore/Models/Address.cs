using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsInASPNETCore.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage ="Street name is required")]
        [StringLength(50,ErrorMessage ="Street name can't be more than 50 chars")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(20, ErrorMessage = "City name can't be more than 20 chars")]
        public string City { get; set; }

        
        [Required(ErrorMessage = "State name is required")]
        [StringLength(30, ErrorMessage = "State name can't be more than 30 chars")]
        public string State { get; set; }

        
        [Required]
        [RegularExpression(@"\d{5}([ \-]\d{4})?", ErrorMessage ="Please enter valid Postal code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage ="Country name is required")]
        
        public string Country { get; set; }

    }
}
