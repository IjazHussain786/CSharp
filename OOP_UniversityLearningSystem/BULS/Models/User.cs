using System;
using System.Collections.Generic;
using Buls.Utilities;
using Buls.Data;
using Buls.Interfaces;

namespace Buls.Models
{
    public class User
    {
        private const int UserNameDefaultLength = 5;
        private const int PasswordDefaultLength = 6;
        
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new Repository<Course>();
        }
        
        public string Username 
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The username cannot be empty.");
                }

                if (value.Length < UserNameDefaultLength)
                {
                    throw new ArgumentException(string.Format("The username must be at least {0} symbols long.", 
                        UserNameDefaultLength));
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The password cannot be empty.");
                }

                if (value.Length < PasswordDefaultLength)
                {
                    throw new ArgumentException(string.Format("The password must be at least {0} symbols long.", 
                        PasswordDefaultLength));
                }

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IRepository<Course> Courses { get; private set; }
    }
}
