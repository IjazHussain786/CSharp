using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class GuestUser : User
    {
        public GuestUser(string username, string password, Role role)
            : base(username, password, role)
        {
        }
    }
}
