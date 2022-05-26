using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using Base.Api.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class GetAllMyArticlesHandler : IRequestHandler<GetAllArticlesRequest, Response<List<ArticleDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityService _identityService;
    private readonly HashService _hashService;

    public GetAllMyArticlesHandler(IUnitOfWork unitOfWork, IIdentityService identityService, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _identityService = identityService;
        _hashService = hashService;
    }

    public async Task<Response<List<ArticleDto>>> Handle(GetAllArticlesRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ArticleReadRepository();

        var entities = new List<Article>().AsQueryable();

        if (_identityService.IsAuthenticated)
        {
            entities = repository.Where(x => x.IsPublic || x.ApplicationUserId == _identityService.GetUserDecodeId);
        }
        else
        {
            entities = repository.Where(x => x.IsPublic);
        }

        var dtos = await entities.Select(x => new ArticleDto()
        {
            Id = _hashService.Encode(x.Id),
            Username = x.ApplicationUser.UserName,
            Title = x.Title,
            Content = x.Content,
            CreatedDate = x.CreatedDate,
            IsPublic = x.IsPublic,
            CategoryId = _hashService.Encode(x.CategoryId)
        }).ToListAsync();

        return Response<List<ArticleDto>>.Success(data: dtos, statusCode: 200);
    }
}