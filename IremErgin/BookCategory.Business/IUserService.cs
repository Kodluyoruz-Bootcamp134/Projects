using BookCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.Business
{
    public interface IUserService
    {
        User Validate(string username, string password);
    }
}
