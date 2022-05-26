using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Articles;

public class UpdateArticleRequest : IRequest<Response<NoContent>>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsPublic { get; set; }
    public string CategoryId { get; set; }
}