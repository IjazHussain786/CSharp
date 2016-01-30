using System.Text;
using Buls.Models;
using Buls.Infrastructure;
using System;

namespace Buls.Views.Users
{
    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged out successfully.{1}", user.Username, Environment.NewLine);
        }
    }
}
