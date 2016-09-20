using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models
{
    public class Group
    {
        public Group()
        {
            this.Members = new HashSet<ApplicationUser>();
            this.Discussions = new HashSet<Discussion>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public GroupType Type { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
