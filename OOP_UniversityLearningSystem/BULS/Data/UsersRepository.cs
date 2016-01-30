using Buls.Models;
using System.Collections.Generic;
using System.Linq;
using Buls.Interfaces;
using System;

namespace Buls.Data
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private Dictionary<string, User> usersByUsername;

        public UsersRepository()
            : base()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                return null;
            }

            return this.usersByUsername[username];
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.Username, user);
            base.Add(user);
        }
    }
}
