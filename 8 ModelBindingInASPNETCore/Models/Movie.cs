using System.ComponentModel.DataAnnotations;

namespace ModelBindingInASPNETCore.Models
{

    public enum Directors
    {
        SSR=1,
        Poori,
        Sukumar,
        ShekarKamula

    }

    public enum MovieType
    {
        Horror=1,
        Family,
        Comedy,
        SCFI

    }

    public class Movie
    {
        [Required(ErrorMessage = "Movie Name is required")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Hero Name is required")]
        public string? HeroName { get; set; }
        public double? MovieCollection { get; set; }
    }

    public class MovieDetails
    {
        public int? MovieId { get; set; }

        [Required(ErrorMessage="Movie Name is required")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Hero Name is required")]
        public string? HeroName { get; set; }
        public double? MovieCollection { get; set; }
        public Directors? Directors { get; set; }
        public MovieType? MovieType { get; set; }
        public List<string> Cast { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsMovieHit { get; set; }
        public string MovieStory { get; set; }
    }
}
