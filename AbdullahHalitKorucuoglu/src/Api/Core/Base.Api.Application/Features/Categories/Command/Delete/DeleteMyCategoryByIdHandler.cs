using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Categories;

public class DeleteMyCategoryByIdHandler : IRequestHandler<DeleteMyCategoryByIdRequest, Response<NoContent>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HashService _hashService;

    public DeleteMyCategoryByIdHandler(IUnitOfWork unitOfWork, HashService hashService)
    {
        _unitOfWork = unitOfWork;
        _hashService = hashService;
    }

    public async Task<Response<NoContent>> Handle(DeleteMyCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CategoryReadRepository().FindAsync(_hashService.Decode(request.Id), true);

        if (_unitOfWork.ArticleReadRepository().Any(x => x.CategoryId == entity.Id))
        {
            return Response<NoContent>.Fail("İçerisinde makale bulunan kategori silinemez", 500);
        }

        _unitOfWork.CategoryWriteRepository().Remove(entity);

        bool result = await _unitOfWork.SaveChangesAsync() > 0;

        if (!result)
        {
            return Response<NoContent>.Fail("hata meydana geldi", 500);
        }

        return Response<NoContent>.Success(204);
    }
}