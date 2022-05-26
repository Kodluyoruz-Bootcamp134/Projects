using Base.Api.Application.Models.Dtos;
using MediatR;

namespace Base.Api.Application.Features.Articles;

public class GetMyArticleByIdRequest : IRequest<Response<ArticleDto>>
{
    public int Id { get; set; }
}