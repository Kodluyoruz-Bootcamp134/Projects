using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Dal.Repository
{
    public interface IUserRepository
    {
        User ValidateUser(string username, string password);
    }
}
