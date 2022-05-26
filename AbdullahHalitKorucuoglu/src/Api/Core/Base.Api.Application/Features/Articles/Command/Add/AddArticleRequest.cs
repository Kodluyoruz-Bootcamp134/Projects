using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Articles;

public class AddArticleRequest : IRequest<Response<string>>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsPublic { get; set; }
    public string CategoryId { get; set; }
}