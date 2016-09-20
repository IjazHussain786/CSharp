using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class UserLanguage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
