using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Articles;

public class DeleteMyArticleByIdRequest : IRequest<Response<NoContent>>
{
    public string Id { get; set; }
}