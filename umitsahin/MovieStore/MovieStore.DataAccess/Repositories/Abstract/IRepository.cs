using MovieStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Repositories.Abstract;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task<bool> AnyAsync(int id);
}
