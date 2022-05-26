using AutoMapper;
using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Categories;

public class GetAllMyCategoriesHandler : IRequestHandler<GetAllMyCategories, Response<List<CategoryDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityService _identityService;
    private readonly HashService _hashService;

    public GetAllMyCategoriesHandler(IUnitOfWork unitOfWork, IIdentityService identityService, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _identityService = identityService;
        _hashService = hashService;
    }

    public async Task<Response<List<CategoryDto>>> Handle(GetAllMyCategories request, CancellationToken cancellationToken)
    {
        var entities = _unitOfWork.CategoryReadRepository().Where(x => x.ApplicationUserId == _identityService.GetUserDecodeId);

        var dtos = await entities.Select(x => new CategoryDto()
        {
            Id = _hashService.Encode(x.Id),
            Title = x.Title,
            ArticleCount = x.Articles.Count
        }).ToListAsync();

        return Response<List<CategoryDto>>.Success(data: dtos, statusCode: 200);
    }
}