using BookCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string username, string password);
    }
}
