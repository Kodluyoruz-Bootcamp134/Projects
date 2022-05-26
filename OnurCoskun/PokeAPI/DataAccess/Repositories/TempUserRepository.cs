using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TempUserRepository : IUserRepository
    {
        private List<User> user;
        public TempUserRepository()
        {
            user = new List<User>()
            {
                new User() { Id = 1, UserName= "Poseidon", Password = "Kowaii7", Email = "coskunonur01@gmail.com", Role = "Admin", Name = "Onur", Surname = "Coşkun" }
            };
        }
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Any(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(string userName, string password)
        {
            return user.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
