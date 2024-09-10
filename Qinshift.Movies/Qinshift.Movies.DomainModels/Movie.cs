using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Qinshift.Movies.DomainModels
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string? Plot { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public GenreEnum Genre { get; set; }
    }
}
