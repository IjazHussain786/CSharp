using System;
using HotelBookingSystem.Interfaces;
using System.Text;
using HotelBookingSystem.Infrastructure;

namespace HotelBookingSystem.Views.Users
{
    public class Logout : View
    {
        public Logout(IUser user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as IUser;
            viewResult.AppendFormat("The user {0} has logged out.{1}", user.Username, Environment.NewLine);
        }
    }
}
