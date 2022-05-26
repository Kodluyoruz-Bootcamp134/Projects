using Base.Api.Domain.Common;
using System;

namespace Base.Api.Domain.Entities;

public class Article : BaseEntity, IUpdateable, IAuthRequired
{
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsPublic { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public int ApplicationUserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}