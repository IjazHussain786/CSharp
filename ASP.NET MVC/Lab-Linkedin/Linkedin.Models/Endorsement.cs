using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class Endorsement
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int UserSkillId { get; set; }

        public virtual UserSkill UserSkill { get; set; }
    }
}
