using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class GetMyArticleByIdHandler : IRequestHandler<GetMyArticleByIdRequest, Response<ArticleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HashService _hashService;
    private readonly IIdentityService _identityService;

    public GetMyArticleByIdHandler(IUnitOfWork unitOfWork, HashService hashService, IIdentityService identityService)
    {
        _unitOfWork = unitOfWork;
        _hashService = hashService;
        _identityService = identityService;
    }

    public async Task<Response<ArticleDto>> Handle(GetMyArticleByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = _unitOfWork.ArticleReadRepository().
            Where(x => x.Id == request.Id && x.ApplicationUserId == _identityService.GetUserDecodeId);

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