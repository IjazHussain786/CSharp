using System;
using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class Certification
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime DateTaken { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
