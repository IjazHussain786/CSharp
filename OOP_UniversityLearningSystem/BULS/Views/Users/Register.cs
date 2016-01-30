using Buls.Infrastructure;
using Buls.Models;
using System.Text;
using System;

namespace Buls.Views.Users
{
    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} registered successfully.{1}", user.Username, Environment.NewLine);
        }
    }
}
