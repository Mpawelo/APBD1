using System.Collections.Generic;
using APBD1.Domain.Users;

namespace APBD1.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}