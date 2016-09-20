using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

using Linkedin.Models;


namespace Linkedin.Web.ViewModels
{
    public class UserViewModel
    {
        public static Expression<Func<ApplicationUser, UserViewModel>> GetUserViewModel
        {
            get
            {
                return x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    FullName = x.FullName,
                    AvatarUrl = x.AvatarUrl,
                    Summary = x.Summary,
                    ContactInfo = x.ContactInfo,
                    Certifications = x.Certifications.AsQueryable().
                        Select(CertificationViewModel.GetCertificationViewModel),
                    Skills = x.UserSkills.AsQueryable().Select(SkillViewModel.GetSkillViewModel)
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public string Email { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        //public static object FromModel(ApplicationUser user)
        //{
        //    var userViewModel = new UserViewModel()
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        FullName = user.FullName,
        //        AvatarUrl = user.AvatarUrl,
        //        Summary = user.Summary,
        //        ContactInfo = user.ContactInfo
        //    };

        //    return userViewModel;
        //}
    }
}