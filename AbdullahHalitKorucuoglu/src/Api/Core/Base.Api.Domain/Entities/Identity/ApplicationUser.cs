using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Base.Api.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
}