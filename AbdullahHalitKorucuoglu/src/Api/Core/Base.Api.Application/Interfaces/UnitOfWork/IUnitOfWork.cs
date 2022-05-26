using Base.Api.Application.Interfaces.Repositories;
using Base.Api.Domain.Common;
using System;
using System.Threading.Tasks;

namespace Base.Api.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> ReadRepository<T>() where T : BaseEntity;

        ICategoryReadRepository CategoryReadRepository();

        ICategoryWriteRepository CategoryWriteRepository();

        IArticleReadRepository ArticleReadRepository();

        IArticleWriteRepository ArticleWriteRepository();

        Task<int> SaveChangesAsync();
    }
}