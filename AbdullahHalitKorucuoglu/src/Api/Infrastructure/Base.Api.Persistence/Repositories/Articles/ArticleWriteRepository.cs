using Base.Api.Application.Interfaces.Repositories;
using Base.Api.Domain.Entities;
using Base.Api.Persistence.Context;

namespace Base.Api.Persistence.Repositories;

public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
{
    public ArticleWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}