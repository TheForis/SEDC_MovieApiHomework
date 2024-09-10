using System.ComponentModel.DataAnnotations;

namespace Qinshift.Movies.DomainModels
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("")]
        public string Password { get; set; }
    }
}
