using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;

using Linkedin.Data;
using Linkedin.Web.ViewModels;
using Linkedin.Models;

namespace Linkedin.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ILinkedinData data)
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            //var user = this.Data.Users.GetAll().
            //    FirstOrDefault(x => x.UserName == username);

            var user = this.Data.Users.GetAll().
                Include(x => x.Certifications).
                Include(x => x.UserSkills).
                Include("UserSkills.Skill").
                Include("UserSkills.Skill.User").
                Where(x => x.UserName == username).
                Select(UserViewModel.GetUserViewModel).
                FirstOrDefault();

            if (user == null)
            {
                return this.HttpNotFound("User does not exist!");
            }

            //var userViewModel = UserViewModel.FromModel(user);

            //var userViewModel = new UserViewModel()
            //{
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    FullName = user.FullName,
            //    AvatarUrl = user.AvatarUrl,
            //    Summary = user.Summary,
            //    ContactInfo = user.ContactInfo
            //};

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorseUserForSkill(int userSkillId)
        {
            bool hasExistingEndorsement = this.Data.Endorsements.GetAll().
                Any(x => x.UserId == this.UserProfile.Id && x.UserSkillId == userSkillId);
            if (!hasExistingEndorsement)
            {
                var endorsement = new Endorsement()
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = userSkillId
                };

                this.Data.Endorsements.Add(endorsement);
                this.Data.SaveChanges();
            }

            var endorsements = this.Data.Endorsements.GetAll().
                Where(x => x.UserSkillId == userSkillId);
            int endorsementCount = endorsements.Count();
            var endorsers = endorsements.Select(x => x.User.UserName).ToList();

            return this.Content(string.Format("{0} ({1})", endorsementCount, string.Join(", ", endorsers)));
        }
    }
}