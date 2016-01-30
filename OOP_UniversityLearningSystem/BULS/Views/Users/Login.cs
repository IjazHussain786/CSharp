using System.Text;
using Buls.Infrastructure;
using Buls.Models;
using System;

namespace Buls.Views.Users
{
    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged in successfully.{1}", user.Username, Environment.NewLine);
        }
    }
}
