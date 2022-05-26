using AutoMapper;
using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class AddArticleHandler : IRequestHandler<AddArticleRequest, Response<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly HashService _hashService;

    public AddArticleHandler(IUnitOfWork unitOfWork, IMapper mapper, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _hashService = hashService;
    }

    public async Task<Response<string>> Handle(AddArticleRequest request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.ArticleWriteRepository().AddAsync(_mapper.Map<Article>(request));

        var result = await _unitOfWork.SaveChangesAsync() > 0;

        if (!result)
        {
            return Response<string>.Fail("hata meydana geldi", 500);
        }

        return Response<string>.Success(data: _hashService.Encode(data.Id), 201);
    }
}