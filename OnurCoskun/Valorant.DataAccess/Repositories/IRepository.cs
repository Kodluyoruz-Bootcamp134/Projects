using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.Entities;

namespace Valorant.DataAccess.Repositories
{
    public interface IRepository<T> where T : IEntity, new()
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int Id);
        Task Add(T entity);
    }
}
