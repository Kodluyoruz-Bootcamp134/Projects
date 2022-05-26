using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Categories;

public class UpdateCategoryRequest : IRequest<Response<NoContent>>
{
    public string Id { get; set; }
    public string Title { get; set; }
}