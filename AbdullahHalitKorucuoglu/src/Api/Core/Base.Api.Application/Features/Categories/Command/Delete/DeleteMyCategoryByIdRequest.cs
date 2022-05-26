using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Categories;

public class DeleteMyCategoryByIdRequest : IRequest<Response<NoContent>>
{
    public string Id { get; set; }
}