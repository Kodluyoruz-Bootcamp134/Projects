using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Categories;

public class GetMyCategoryById : IRequest<Response<CategoryDto>>
{
    public string Id { get; set; }
}