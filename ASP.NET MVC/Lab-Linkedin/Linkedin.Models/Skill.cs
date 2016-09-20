using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class Skill
    {
        public Skill()
        {
            this.Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
