using Base.Api.Application.Interfaces.Repositories;
using Base.Api.Domain.Entities;
using Base.Api.Persistence.Context;

namespace Base.Api.Persistence.Repositories;

public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
{
    public ArticleReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}