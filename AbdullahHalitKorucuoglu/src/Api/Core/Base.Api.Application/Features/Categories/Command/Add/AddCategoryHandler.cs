using AutoMapper;
using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Categories
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HashService _hashService;

        public AddCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, HashService hashService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<Response<string>> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.CategoryWriteRepository().AddAsync(_mapper.Map<Category>(request));

            var result = await _unitOfWork.SaveChangesAsync() > 0;

            if (!result)
            {
                return Response<string>.Fail("hata meydana geldi", 500);
            }

            return Response<string>.Success(data: _hashService.Encode(data.Id), 201);
        }
    }
}