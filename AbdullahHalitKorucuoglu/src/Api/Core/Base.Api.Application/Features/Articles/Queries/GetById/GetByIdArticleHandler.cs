using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Const;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Articles;

public class GetByIdArticleHandler : IRequestHandler<GetByIdArticleRequest, Response<ArticleDto>>
{
    private readonly IMediator _mediator;
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HashService _hashService;

    public GetByIdArticleHandler(IMediator mediator, IIdentityService identityService, IUnitOfWork unitOfWork, HashService hashService)
    {
        _mediator = mediator;
        _identityService = identityService;
        _unitOfWork = unitOfWork;
        _hashService = hashService;
    }

    public async Task<Response<ArticleDto>> Handle(GetByIdArticleRequest request, CancellationToken cancellationToken)
    {
        var decodeId = _hashService.Decode(request.Id);
        var repository = _unitOfWork.ArticleReadRepository();

        if (!repository.Any(x => x.Id == decodeId)) // is id valid?
        {
            return Response<ArticleDto>.Fail(CustomResponseMessages.ArticleNotFound, 500);
        }

        if (!repository.Any(x => x.Id == decodeId && x.IsPublic)) // iss data private
        {
            if (!_identityService.IsAuthenticated) // is user not logged in throw error
            {
                return Response<ArticleDto>.Fail(CustomResponseMessages.ArticleNotFound, 500);
            }

            if (!repository.Any(x => x.Id == decodeId && x.ApplicationUserId == _identityService.GetUserDecodeId))
            { // data is private and it is not mine.
                return Response<ArticleDto>.Fail(CustomResponseMessages.ArticleNotFound, 500);
            }

            return await _mediator.Send(new GetMyArticleByIdRequest() { Id = decodeId }); // data is private and it is mine.
        }

        return await _mediator.Send(new GetByIdPublicArticleRequest() { Id = decodeId }); // data is public
    }
}