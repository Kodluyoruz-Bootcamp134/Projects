using Base.Api.Application.Interfaces.Repositories;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Domain.Common;
using Base.Api.Persistence.Context;
using Base.Api.Persistence.Repositories;
using System.Threading.Tasks;

namespace Base.Api.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IReadRepository<T> ReadRepository<T>() where T : BaseEntity => new ReadRepository<T>(_context);

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public ICategoryReadRepository CategoryReadRepository()
        {
            return new CategoryReadRepository(_context);
        }

        public ICategoryWriteRepository CategoryWriteRepository()
        {
            return new CategoryWriteRepository(_context);
        }

        public IArticleReadRepository ArticleReadRepository()
        {
            return new ArticleReadRepository(_context);
        }

        public IArticleWriteRepository ArticleWriteRepository()
        {
            return new ArticleWriteRepository(_context);
        }
    }
}