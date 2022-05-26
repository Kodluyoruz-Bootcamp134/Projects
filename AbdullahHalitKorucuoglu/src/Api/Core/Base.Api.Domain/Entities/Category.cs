using Base.Api.Domain.Common;
using System;
using System.Collections.Generic;

namespace Base.Api.Domain.Entities;

public class Category : BaseEntity, IUpdateable, IAuthRequired
{
    public string Title { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public virtual ICollection<Article> Articles { get; set; }
}