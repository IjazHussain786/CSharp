using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkedin.Data.Repositories;
using Linkedin.Models;

namespace Linkedin.Data
{
    public class LinkedinData : ILinkedinData
    {
        private ILinkedInDbContext context;
        private IDictionary<Type, object> repositories;

        public LinkedinData(ILinkedInDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<AdministrationLog> AdministrationLogs
        {
            get
            {
                return this.GetRepositpry<AdministrationLog>();
            }
        }

        public IRepository<Certification> Certifications
        {
            get
            {
                return this.GetRepositpry<Certification>();
            }
        }

        public IRepository<Discussion> Discussions
        {
            get
            {
                return this.GetRepositpry<Discussion>();
            }
        }

        public IRepository<Endorsement> Endorsements
        {
            get
            {
                return this.GetRepositpry<Endorsement>();
            }
        }

        public IRepository<Experience> Experiences
        {
            get
            {
                return this.GetRepositpry<Experience>();
            }
        }

        public IRepository<Group> Groups
        {
            get
            {
                return this.GetRepositpry<Group>();
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepositpry<Project>();
            }
        }

        public IRepository<Skill> Skills
        {
            get
            {
                return this.GetRepositpry<Skill>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepositpry<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepositpry<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
