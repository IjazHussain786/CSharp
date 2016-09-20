using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models
{
    public class Project
    {
        public Project()
        {
            this.TeamMembers = new HashSet<ApplicationUser>();       
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }

        public int OccupationExperienceId { get; set; }

        public virtual Experience OccupationExperience { get; set; }

        public virtual ICollection<ApplicationUser> TeamMembers { get; set; }
    }
}
