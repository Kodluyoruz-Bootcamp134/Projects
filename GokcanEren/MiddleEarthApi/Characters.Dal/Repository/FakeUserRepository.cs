using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Dal.Repository
{
    public class FakeUserRepository : IUserRepository
    {

        private List<User> _users;
        public FakeUserRepository()
        {
            _users = new List<User>()
            {
                new User() { Id = 1, Email= "a@test.com", Role= "Admin", Password="123", UserName="user1" },
                new User() { Id = 1, Email= "a@test.com", Role= "Editor", Password="123", UserName="user2" },
                new User() { Id = 1, Email= "a@test.com", Role= "Client", Password="123", UserName="user3" },
            };
        }

        public User ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
