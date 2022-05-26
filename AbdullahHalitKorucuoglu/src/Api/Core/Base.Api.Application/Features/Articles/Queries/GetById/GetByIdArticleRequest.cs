using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Articles;

public class GetByIdArticleRequest : IRequest<Response<ArticleDto>>
{
    public string Id { get; set; }
}