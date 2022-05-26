using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Categories;

public class AddCategoryRequest : IRequest<Response<string>>
{
    public string Title { get; set; }
}