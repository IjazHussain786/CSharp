

using Linkedin.Data.Repositories;
using Linkedin.Models;

namespace Linkedin.Data
{
    public interface ILinkedinData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Certification> Certifications { get; }

        IRepository<Discussion> Discussions { get; }

        IRepository<Experience> Experiences { get; }

        IRepository<Group> Groups { get; }

        IRepository<Project> Projects { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Endorsement> Endorsements { get; }

        IRepository<AdministrationLog> AdministrationLogs { get; }

        int SaveChanges();
    }
}
