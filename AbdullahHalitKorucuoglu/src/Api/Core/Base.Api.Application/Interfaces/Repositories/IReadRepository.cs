using Base.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Base.Api.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
    bool Any(Expression<Func<TEntity, bool>> predicate = null, bool tracking = false);

    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool tracking = false);

    IQueryable<TEntity> GetAllQueryableAsync(bool tracking = false);

    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool tracking = false);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false);

    Task<TEntity> FindAsync(int id, bool tracking = false);

    List<T> ExecuteQuery<T>(string query) where T : class, new();
}