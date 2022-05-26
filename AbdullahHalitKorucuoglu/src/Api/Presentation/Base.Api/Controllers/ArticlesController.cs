using Base.Api.Application.Features.Articles;
using Base.Api.Domain.Entities;
using Base.Api.Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Base.Api.Controllers;

[Authorize]
public class ArticlesController : BaseApiController
{
    private readonly IMediator _mediator;

    public ArticlesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var data = await _mediator.Send(new GetAllArticlesRequest());

        return Result(data);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _mediator.Send(new GetByIdArticleRequest() { Id = id });

        return Result(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddArticleRequest dto)
    {
        var data = await _mediator.Send(dto);
        return Result(data);
    }

    [HttpPut]
    [ServiceFilter(typeof(NotFoundFilterAttribute<Article>))]
    public async Task<IActionResult> Update(UpdateArticleRequest dto)
    {
        var data = await _mediator.Send(dto);
        return Result(data);
    }

    [ServiceFilter(typeof(NotFoundFilterAttribute<Article>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var data = await _mediator.Send(new DeleteMyArticleByIdRequest() { Id = id });
        return Result(data);
    }
}