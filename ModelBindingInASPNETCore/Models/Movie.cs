using System.ComponentModel.DataAnnotations;

namespace ModelBindingInASPNETCore.Models
{
    public class Movie
    {
        [Required(ErrorMessage="Movie Name is required")]
        public string MovieName { get; set; }
        public string? HeroName { get; set; }
        public double? MovieCollection { get; set; }
    }
}
