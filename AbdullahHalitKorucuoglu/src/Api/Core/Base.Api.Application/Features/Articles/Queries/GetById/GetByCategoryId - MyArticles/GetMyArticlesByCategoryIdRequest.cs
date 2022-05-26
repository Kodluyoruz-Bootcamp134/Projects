using Base.Api.Application.Models.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Base.Api.Application.Features.Articles;

public class GetMyArticlesByCategoryIdRequest : IRequest<Response<List<ArticleDto>>>
{
    public string Id { get; set; }
}