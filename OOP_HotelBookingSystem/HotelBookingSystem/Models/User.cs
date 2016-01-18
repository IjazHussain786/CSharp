using HotelBookingSystem.Interfaces;
using System.Collections.Generic;
using System;
using HotelBookingSystem.Utilities;

namespace HotelBookingSystem.Models
{
    public class User : IUser
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("The username cannot be empty."));
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException(string.Format("The username must be at least 5 symbols long."));
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("The password cannot be empty."));
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException(string.Format("The password must be at least 6 symbols long."));
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Role Role { get; private set; }
        public ICollection<Booking> Bookings { get; private set; }
    }
}
