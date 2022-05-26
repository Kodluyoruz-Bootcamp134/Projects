using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class GetByIdPublicArticleHandler : IRequestHandler<GetByIdPublicArticleRequest, Response<ArticleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HashService _hashService;

    public GetByIdPublicArticleHandler(IUnitOfWork unitOfWork
, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _hashService = hashService;
    }

    public async Task<Response<ArticleDto>> Handle(GetByIdPublicArticleRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ArticleReadRepository();

        var entity = repository.Where(x => x.IsPublic && x.Id == request.Id);

        var dto = await entity.Select(x => new ArticleDto()
        {
            Id = _hashService.Encode(x.Id),
            Username = x.ApplicationUser.UserName,
            Title = x.Title,
            Content = x.Content,
            CreatedDate = x.CreatedDate,
            IsPublic = x.IsPublic,
            CategoryId = _hashService.Encode(x.Category.Id),
        }).FirstOrDefaultAsync();

        return Response<ArticleDto>.Success(dto, 200);
    }
}