using AutoMapper;
using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class GetMyArticlesByCategoryIdHandler : IRequestHandler<GetMyArticlesByCategoryIdRequest, Response<List<ArticleDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;
    private readonly HashService _hashService;

    public GetMyArticlesByCategoryIdHandler(IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _identityService = identityService;
        _hashService = hashService;
    }

    public async Task<Response<List<ArticleDto>>> Handle(GetMyArticlesByCategoryIdRequest request, CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.ArticleReadRepository().
            Where(x => x.ApplicationUserId == _identityService.GetUserDecodeId && x.CategoryId == _hashService.Decode(request.Id));

        var dtos = await _mapper.ProjectTo<ArticleDto>(entities).ToListAsync();

        return Response<List<ArticleDto>>.Success(data: dtos, statusCode: 200);
    }
}