using Base.Api.Application.Interfaces.Repositories;
using Base.Api.Domain.Common;
using Base.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Base.Api.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _table;
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false)
        {
            var query = _table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate = null, bool tracking = false)
        {
            var query = _table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query.Any(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool tracking = false)
        {
            var query = _table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool tracking = false)
        {
            var query = _table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return predicate == null
                 ? await query.ToListAsync()
                 : await query.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindAsync(int id, bool tracking = false)
        {
            return tracking
                 ? await _table.FindAsync(id)
                 : await _table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> GetAllQueryableAsync(bool tracking = false)
        {
            var query = _table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public List<T> ExecuteQuery<T>(string query) where T : class, new()
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                _context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (reader.Read())
                    {
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {
                                continue;
                            }
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }
                        lst.Add(newObject);
                    }

                    return lst;
                }
            }
        }
    }
}