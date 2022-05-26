using System;

namespace Base.Api.Application.Models.Dtos;

public class ArticleDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool? IsPublic { get; set; }
    public DateTime CreatedDate { get; set; }

    public string Username { get; set; }
    public string CategoryId { get; set; }
}