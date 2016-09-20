using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

using Linkedin.Models;


namespace Linkedin.Web.ViewModels
{
    public class SkillViewModel
    {
        public static Expression<Func<UserSkill, SkillViewModel>> GetSkillViewModel
        {
            get
            {
                return x => new SkillViewModel
                {
                    Id = x.Id,
                    Name = x.Skill.Name,
                    EndorsementCount = x.Endorsements.Count,
                    Endorsers = x.Endorsements.Select(e => e.User.UserName)
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int EndorsementCount { get; set; }

        public IEnumerable<string> Endorsers { get; set; }
    }
}