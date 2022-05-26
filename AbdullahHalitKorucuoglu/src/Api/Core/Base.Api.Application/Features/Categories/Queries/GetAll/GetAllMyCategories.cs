using Base.Api.Application.Models.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Base.Api.Application.Features.Categories;

public class GetAllMyCategories : IRequest<Response<List<CategoryDto>>>
{
}