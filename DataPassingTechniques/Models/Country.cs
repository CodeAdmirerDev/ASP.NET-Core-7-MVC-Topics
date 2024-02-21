using System.ComponentModel.DataAnnotations;

namespace DataPassingTechniques.Models
{
    public class Country
    {
        [Required]
        public string CountryCode { get; set; }
        [MaxLength(10)]
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public string CountryDescription { get; set; }
        public double CountryPopulation { get; set; }


    }
}
