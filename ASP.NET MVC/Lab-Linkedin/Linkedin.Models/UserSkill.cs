using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class UserSkill
    {
        public UserSkill()
        {
            this.Endorsements = new HashSet<Endorsement>();       
        }

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual ICollection<Endorsement> Endorsements { get; set; }
    }
}
